Imports DevExpress.UserSkins
Imports DevExpress.Skins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars.Controls
Imports Studio.Net.Controls.New.Forms

Public Class Program

    <STAThread()>
    Public Shared Sub Main(ByVal arguments() As String)

        Try

            Application.SetCompatibleTextRenderingDefault(True)

            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = True

            Studio.Phone.POS.BLL.ParametroSistemaController.xmlTreeType = GetType(Studio.Vision.POS.BLL.VisionParametroTree)

            If arguments.Length > 0 AndAlso arguments.Where(Function(f) f = "printrecetas").Any() Then
                'TODO
                ImprimirRecetas()
                Return
            End If
            
            Dim mainForm As New Mainform
            InitVisualStyles(mainForm)
            Application.Run(mainForm)

            Return

        Catch ex As Exception

            Studio.Net.Helper.LogError.Publish(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

        End

    End Sub
    
    Private Delegate Sub SafeApplicationThreadException(ByVal sender As Object, _
                                                        ByVal e As Threading.ThreadExceptionEventArgs) 

    Private Sub AppDomain_UnhandledException(ByVal sender As Object, _
                                             ByVal e As UnhandledExceptionEventArgs)

        ShowDebugOutput(DirectCast(e.ExceptionObject, Exception))

    End Sub
    Private Sub app_ThreadException(ByVal sender As Object, _
                                    ByVal e As Threading.ThreadExceptionEventArgs)

        'This is not thread safe, so make it thread safe.
        If MainForm.InvokeRequired Then
            ' Invoke back to the main thread
            MainForm.Invoke(New SafeApplicationThreadException(AddressOf app_ThreadException), _
                            New Object() {sender, e})
        Else
            ShowDebugOutput(e.Exception)
        End If

    End Sub

    'Private Sub MyApplication_UnhandledException(sender As Object, _
    '                                             e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) _
    '    Handles Me.UnhandledException

    '    ShowDebugOutput(e.Exception)

    'End Sub 
    Private Sub ShowDebugOutput(ByVal ex As Exception)

        'Display the output form
        'Dim frmD As New frmDebug()
        'frmD.rtfError.AppendText(ex.ToString())
        'frmD.ShowDialog()

        'Perform application cleanup
        'TODO: Add your application cleanup code here.

        'Exit the application - Or try to recover from the exception:
        Environment.Exit(0)

    End Sub

    Private Shared Sub ImprimirRecetas()

        Dim report As New Studio.Phone.POS.Reporting.DynamicReport()
        Dim col As SD.LLBLGen.Pro.ORMSupportClasses.IEntityCollection2 = Studio.Vision.POS.BLL.Business.DV_RecetaComunBEntity.GetRecetasParaImpresion(Phone.POS.BLL.ConfigReaderSpecific.GetCajaId())
        For Each receta As Phone.POS.DAL.EntityClasses.DV_RecetaComunEntity In col
            report.Print(receta)

        Next

    End Sub


#Region "Visual"

    Private Shared Sub InitVisualStyles(ByVal form As MainFormBase)
        BonusSkins.Register()
        If System.Windows.Forms.SystemInformation.TerminalServerSession AndAlso Not Studio.Net.Helper.Environment.RunningUnderIDE Then
            'InitXafSkinOptions()
            InitGlobalOptions(form)
        Else
            'OfficeSkins.Register()
            SkinManager.EnableFormSkins()

            Application.EnableVisualStyles()

        End If
    End Sub


    Private Shared Sub InitGlobalOptions(ByVal form As MainFormBase)
        'UserLookAndFeel.[Default].SetUltraFlatStyle() ' = ActiveLookAndFeelStyle.UltraFlat
        'UserLookAndFeel.[Default].SetSkinStyle("Metropolis")
        Animator.AllowFadeAnimation = False
        SkinManager.DisableFormSkins()
        SkinManager.DisableMdiFormSkins()
        'UserLookAndFeel.Default.SetStyle3D()
        BarAndDockingController.Default.PropertiesBar.MenuAnimationType = AnimationType.None
        BarAndDockingController.Default.PropertiesBar.SubmenuHasShadow = False
        BarAndDockingController.Default.PropertiesBar.AllowLinkLighting = False
        System.Windows.Forms.Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled
        InitRibbonOptions(form.Ribbon)
        'MsgBox("Terminal")
    End Sub

    Private Shared Sub InitRibbonOptions(ByVal ribbon As RibbonControl)
        If ribbon IsNot Nothing Then
            ribbon.ItemAnimationLength = 0
            ribbon.GroupAnimationLength = 0
            ribbon.PageAnimationLength = 0
            ribbon.ApplicationButtonAnimationLength = 0
            ribbon.GalleryAnimationLength = 0
            ribbon.TransparentEditors = False
            InitBarOptions(ribbon.Manager)
        End If
    End Sub

    Private Shared Sub InitBarOptions(ByVal manager As BarManager)
        If manager IsNot Nothing Then
            manager.AllowItemAnimatedHighlighting = False
        End If
    End Sub
#End Region

End Class
