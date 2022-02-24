Imports DevExpress.UserSkins
Imports DevExpress.Skins

Public Class Program

    <STAThread()> _
    Public Shared Sub Main(ByVal arguments() As String)

        BonusSkins.Register()
        OfficeSkins.Register()
        SkinManager.EnableFormSkins()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = True

        Studio.Net.Helper.UserManager.UserInfo = New Studio.Net.BLL.UserInfo("test") With {.Name = "Test"}

        Application.Run(New MainForm())

    End Sub

End Class
