Imports Studio.Net.Controls.New
Imports Studio.Phone.POS.BLL
'Imports Studio.Phone.POS.Controls.New
Imports System.Reflection
Imports Studio.Phone.POS.DAL.EntityClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports Studio.Net.BLL
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Net.BLL.Model
Imports Studio.Phone.POS.DAL
Imports DevExpress.XtraNavBar
Imports Studio.Vision.POS.Controls
Imports DevExpress.XtraTreeList
Imports DevExpress.Utils
Imports TaskBarNotifierVB
Imports System.Net.Sockets
Imports System.Security.Permissions

Public Class Mainform

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' LoadMisReportes()
        MainFormHelper.LoadNavigationStatus(NavBarControl)

    End Sub


    Protected Overrides Function GetMenuTree() As Studio.Net.Controls.New.MainMenuTree

        Dim toReturn As MainMenuTree = MainMenuTree.Create(Of MainMenuTree)(Assembly.GetExecutingAssembly().GetManifestResourceStream("Studio.Vision.POS.Exe.MainMenu.xml"))
        Return toReturn

    End Function

    'Private Sub LoadMisReportes()
    '    Dim menuTree As MainMenuTree = GetMenuTree()
    '    Dim reportGroup As New MenuGroup With {.Caption = "Mis Reportes", .Name = "OnTheFlyReport"}
    '    menuTree.Groups.Add(reportGroup)
    '    'TODO: Check the licensing for this component in order to activate it
    '    Dim tv As New MyMainMenuTreeDynamicReports(reportGroup)

    '    Dim ng As NavBarGroup = NavBarControl.Groups.Add()
    '    ng.Caption = reportGroup.Caption
    '    ng.GroupStyle = NavBarGroupStyle.ControlContainer
    '    tv.Dock = DockStyle.Fill
    '    ng.Name = "OnTheFlyReports"
    '    ng.LargeImage = My.Resources.MisReportes24
    '    ng.SmallImage = My.Resources.MisReportes16
    '    ng.ControlContainer.Controls.Add(tv)
    'End Sub
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        MyBase.OnLoad(e)
        If Studio.Net.Helper.UserManager.UserInfo IsNot Nothing Then

            Dim cajaId As Integer = ConfigReaderSpecific.GetCajaId()
            bsiCaja.Caption = String.Format("{0}", CajaController.GetDescripcionCompleta(cajaId))
            bsiUsuario.Caption = String.Format("{0} - {1}", Studio.Net.Helper.UserManager.UserInfo.Login, FuncionarioController.NombreFuncionario(Studio.Net.Helper.UserManager.UserInfo.Login))

            For Each item As NavBarGroup In NavBarControl.Groups
                Dim tv As TreeList = TryCast(item.ControlContainer.Controls(0), TreeList)
                If tv IsNot Nothing Then
                    tv.ExpandAll()
                End If
            Next

        End If

    End Sub


    Protected Overrides Function OnLogin() As Boolean

        Try
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
            Using fLogin As New LoginForm(Me)
                Dim resultado As Boolean = fLogin.ValidarUsuario(New UsuarioController)
                If Not resultado Then
                    Application.Exit()
                    Return False
                End If
                LayoutManager.Load(Me)
            End Using
            Return True
        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            Application.Exit()
        End Try

    End Function

    Protected Overrides Function GetSplashScreenType() As System.Type
        Return GetType(VisionSplashScreenForm)
    End Function

    Protected Overrides Function GetPermisos() As System.Collections.Generic.List(Of String)
        Dim unUsuarioEntity As Studio.Phone.POS.DAL.EntityClasses.UsuarioEntity
        'Dim unGrpPerEntity As Studio.Phone.DAL.EntityClasses.Grupo_PermisoEntity

        Dim usuario As String = Studio.Net.Helper.UserManager.UserInfo.Login
        unUsuarioEntity = UsuarioController.BuscarPorLogin(usuario)
        Dim grpPerCol As Studio.Phone.POS.DAL.HelperClasses.EntityCollection
        Dim usrGrpBentity As New Studio.Phone.POS.BLL.Grupo_PermisoBentity

        grpPerCol = usrGrpBentity.GetData(Studio.Phone.POS.BLL.Grupo_PermisoBentity.CrearFiltroPorGrupoId(unUsuarioEntity.GrupoId))
        Return grpPerCol.Select(Function(p) DirectCast(p, Grupo_PermisoEntity).PermisoIdentificador).ToList()

    End Function

    Protected Overrides Sub OnSetPermision()
        'No hacemos nada
    End Sub
    'Protected Overrides Sub OnTreeViewCreated(tv As Net.Controls.New.MyMainMenuTree, item As Net.Controls.New.MenuGroup)
    '    tv.ImageSize = New Size(24, 24)
    'End Sub


#Region "Traffic"

    Private m_Notifier As TaskBarNotifier

    Private Delegate Sub simpleDel()

    Private Delegate Sub NotifyDel(ByVal mensaje As String)

    'Private _trafficThread As System.Threading.Thread
    ''Thread que se encarga de actualizar la información recibida en TareaPendiente hacia las tab
    'Private _actualizerThread As System.Threading.Thread
    ''Thread que se encarga de enviar a Traffic la información generada en POS
    'Private _senderThread As System.Threading.Thread

    Private _managerThread As System.Threading.Thread

    'Objeto de negocio que contiene las rutinas para el intercambio de la información
    Private _actualizer As New Studio.Phone.Traffic.BLL.Actualizer

    Private m_LastMsjErrTraffic As Date
    Private m_TrafficErrCnt As Integer

    'Private m_Notifier As TaskBarNotifier


    Private Sub IniciarTraffic()

        _actualizer.CajaId = ConfigReaderSpecific.GetCajaId()

        AddHandler _actualizer.Enviando, AddressOf EnviandoPos
        AddHandler _actualizer.Enviado, AddressOf PosEnviado
        AddHandler _actualizer.FalloEnTransmision, AddressOf FalloPosEnTransmision
        AddHandler _actualizer.Recibiendo, AddressOf RecibiendoPos
        AddHandler _actualizer.Recibido, AddressOf PosRecibido
        AddHandler _actualizer.FalloEnActualizacion, AddressOf FalloPosEnActualizacion
        AddHandler _actualizer.FalloEnRecepcion, AddressOf FalloPosEnRecepcion
        AddHandler _actualizer.Actualizando, AddressOf ActualizandoPos
        AddHandler _actualizer.Actualizado, AddressOf PosActualizado
        AddHandler _actualizer.FechaYHoraError, AddressOf FalloFechaYHora

        Dim manager As New Studio.Net.Helper.Threading.InvokerManager
        _managerThread = New System.Threading.Thread(AddressOf manager.StarCheck)
        manager.AddInvokeMethod(New simpleDel(AddressOf _actualizer.GenerarTareasPendiente))
        manager.AddInvokeMethod(New simpleDel(AddressOf _actualizer.ActualizarDBEnPOSDesdeTareasPendiente))
        manager.AddInvokeMethod(New simpleDel(AddressOf _actualizer.TransferirDatosATraffic))
        manager.AddInvokeMethod(New simpleDel(AddressOf _actualizer.CheckFechaYHora))

        _managerThread.IsBackground = True
        _managerThread.Priority = ThreadPriority.Lowest

        _managerThread.Start()


    End Sub

    <SecurityPermissionAttribute(SecurityAction.Demand, ControlThread:=True)> _
    Private Sub FinalizarTraffic()
        If Not ConfigReaderSpecific.EjecutarTraffic() Then Return
        _actualizer.Abort = True

        RemoveHandler _actualizer.Enviando, AddressOf EnviandoPos
        RemoveHandler _actualizer.Enviado, AddressOf PosEnviado
        RemoveHandler _actualizer.FalloEnTransmision, AddressOf FalloPosEnTransmision
        RemoveHandler _actualizer.Recibiendo, AddressOf RecibiendoPos
        RemoveHandler _actualizer.Recibido, AddressOf PosRecibido
        RemoveHandler _actualizer.Actualizando, AddressOf ActualizandoPos
        RemoveHandler _actualizer.Actualizado, AddressOf PosActualizado
        RemoveHandler _actualizer.FalloEnRecepcion, AddressOf FalloPosEnRecepcion
        RemoveHandler _actualizer.FalloEnTransmision, AddressOf FalloPosEnActualizacion
        RemoveHandler _actualizer.FechaYHoraError, AddressOf FalloFechaYHora

        '_managerThread.Abort()

        _actualizer = Nothing
        _managerThread = Nothing

    End Sub

    Private Sub EnviandoPos(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CambiarPanelEnvio("Enviando información", False)
    End Sub

    Private Sub RecibiendoPos(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CambiarPanelRecepcion("Recibiendo información", False)
    End Sub

    Private Sub ActualizandoPos(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CambiarPanelActualizacion("Actualizando información", False)
    End Sub

    Private Sub PosRecibido(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CambiarPanelRecepcion(String.Empty, False)
        'Si la recepción es ok cambiar el 
        m_LastMsjErrTraffic = System.DateTime.MinValue
        m_TrafficErrCnt = 0I
    End Sub

    Private Sub PosEnviado(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CambiarPanelEnvio(String.Empty, False)
    End Sub

    Private Sub PosActualizado(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CambiarPanelActualizacion(String.Empty, False)
    End Sub

    Private Sub FalloPosEnRecepcion(ByVal sender As Object, ByVal e As Studio.Phone.Traffic.BLL.TrafficErrorEventArgs)
        Me.CambiarPanelRecepcion(String.Format("Error al recepcionar:{0}", e.Exception.Message), True)

        m_TrafficErrCnt += 1
        'Si pasaron mas de 60 minutos desde el último mensaje entonces avisar
        If TypeOf e.Exception Is SocketException _
            AndAlso (DateTime.Now > m_LastMsjErrTraffic.AddMinutes(60) And m_TrafficErrCnt > 3) Then
            ShowNotifier("No fue posible conectarse con el nodo central, verifique es estado de la conexión.")
            m_LastMsjErrTraffic = System.DateTime.Now
        End If

    End Sub

    Private Sub FalloFechaYHora(ByVal sender As Object, ByVal e As EventArgs)
        ShowNotifier("La fecha del sistema es incorrecta, por favor regularice esta situación lo antes posible.")
    End Sub

    Private Sub FalloPosEnActualizacion(ByVal sender As Object, ByVal e As Studio.Phone.Traffic.BLL.TrafficErrorEventArgs)
        Me.CambiarPanelActualizacion(String.Format("Error al actualizar:{0}", e.Exception.Message), True)
    End Sub

    Private Sub FalloPosEnTransmision(ByVal sender As Object, ByVal e As Studio.Phone.Traffic.BLL.TrafficErrorEventArgs)
        Me.CambiarPanelEnvio(String.Format("Error al enviar:{0}", e.Exception.Message), True)
    End Sub

    Private Sub CambiarPanelRecepcion(ByVal toolTipText As String, ByVal isError As Boolean)
        With bsiDownloading
            DirectCast(.SuperTip.Items(0), ToolTipItem).Text = toolTipText
            If String.IsNullOrEmpty(toolTipText) Then
                .Glyph = Nothing
            Else
                If isError Then
                    .Glyph = My.Resources.Download___Error
                Else
                    .Glyph = My.Resources.Download
                End If
            End If
        End With
    End Sub

    Private Sub CambiarPanelEnvio(ByVal toolTipText As String, ByVal isError As Boolean)
        With bsiUploading
            DirectCast(.SuperTip.Items(0), ToolTipItem).Text = toolTipText
            If String.IsNullOrEmpty(toolTipText) Then
                .Glyph = Nothing
            Else
                If isError Then
                    .Glyph = Global.Studio.Trade.POS.Exe.My.Resources.Upload___Error
                Else
                    .Glyph = Global.Studio.Trade.POS.Exe.My.Resources.Upload
                End If
            End If
        End With
    End Sub

    Private Sub CambiarPanelActualizacion(ByVal toolTipText As String, isError As Boolean)

        With bsiWriting
            DirectCast(.SuperTip.Items(0), ToolTipItem).Text = toolTipText
            If String.IsNullOrEmpty(toolTipText) Then
                .Glyph = Nothing
            Else
                If isError Then
                    .Glyph = Global.Studio.Trade.POS.Exe.My.Resources.Write___Error
                Else
                    .Glyph = Global.Studio.Trade.POS.Exe.My.Resources.Write
                End If
            End If
        End With

    End Sub


    Private Sub ShowNotifier(ByVal mensaje As String)

        If Me.InvokeRequired Then

            Dim d As New NotifyDel(AddressOf ShowNotifier)
            Me.Invoke(d, New Object() {mensaje})
        Else

            If m_Notifier Is Nothing Then
                m_Notifier = New TaskBarNotifier
            End If

            With m_Notifier

                .SetBackgroundBitmap(New Bitmap(m_Notifier.GetType(), "skin.bmp"), Color.FromArgb(255, 0, 255))
                .SetCloseBitmap(New Bitmap(m_Notifier.GetType(), "close.bmp"), Color.FromArgb(255, 0, 255), New Point(127, 8))
                .TitleRectangle = New Rectangle(40, 9, 70, 25)
                .TextRectangle = New Rectangle(8, 41, 133, 68)

                .CloseButtonClickEnabled = True
                .TitleClickEnabled = False
                .TextClickEnabled = True
                .DrawTextFocusRect = True
                .KeepVisibleOnMouseOver = True
                .ReShowOnMouseOver = False
                .Show(My.Application.Info.Title, _
                       mensaje, _
                       300, _
                       10000, _
                        300)
            End With

        End If

    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        FinalizarTraffic()
        MyBase.OnClosing(e)
    End Sub

    Protected Overrides Function OnLogin() As Boolean

        Try

            If ConfigReaderSpecific.EjecutarTraffic() Then
                IniciarTraffic()
            End If


            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
            Using fLogin As New LoginForm(Me)
                Dim resultado As Boolean = fLogin.ValidarUsuario(New UsuarioController)
                If Not resultado Then
                    Close()
                    Application.Exit()
                    Return False
                End If
                LayoutManager.Load(Me)
            End Using
            Return True
        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            Application.Exit()
        End Try

    End Function


#End Region

End Class
