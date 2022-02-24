Imports DevExpress.UserSkins
Imports DevExpress.Skins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars.Controls
Imports Studio.Net.Controls.New.Forms

Public Class Program

    <STAThread()> _
    Public Shared Sub Main(ByVal arguments() As String)
        Try

            Application.SetCompatibleTextRenderingDefault(True)

            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf UnhandledExceptionTrapper

            Studio.Phone.BLL.ParametroSistemaController.xmlTreeType = GetType(Studio.Vision.BLL.VisionParametroTree)
            DatabaseUpdate.Update()

            'Esto hace que se cargue los modelos
            'Dim a = Studio.Net.BLL.Model.ModelManager.GetInstance().Models
            'Studio.Net.Helper.UserManager.UserInfo = New Studio.Net.BLL.UserInfo("test") With {.Name = "Test"}

            Dim mainForm As New MainForm
            InitVisualStyles(mainForm)
            Application.Run(mainForm)

            Return

        Catch ex As Exception
            Studio.Net.Helper.LogError.Publish(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Application.Exit()
        End Try



    End Sub


#Region "Visual"

    Private Shared Sub InitVisualStyles(ByVal form As MainFormBase)

        BonusSkins.Register()

        If System.Windows.Forms.SystemInformation.TerminalServerSession AndAlso Not Studio.Net.Helper.Environment.RunningUnderIDE Then
            InitGlobalOptions(form)
        Else
            SkinManager.EnableFormSkins()
            Application.EnableVisualStyles()
        End If

    End Sub


    Private Shared Sub InitGlobalOptions(ByVal form As MainFormBase)
        'UserLookAndFeel.[Default].SetUltraFlatStyle() ' = ActiveLookAndFeelStyle.UltraFlat
        UserLookAndFeel.[Default].SetSkinStyle("Metropolis")
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

    Private Shared Sub UnhandledExceptionTrapper(sender As Object, e As UnhandledExceptionEventArgs)
        Studio.Net.Helper.LogError.Publish(e.ExceptionObject)
    End Sub

End Class
