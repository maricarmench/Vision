Imports System.Reflection
Imports Studio.Net.Controls.New
Imports Studio.Phone.Plugins

Public Class Plugin
    Implements IPhonePlugin

    Public Sub Initialize() Implements IPhonePlugin.Initialize
        'Throw New NotImplementedException()
    End Sub

    Public Sub Terminate() Implements IPhonePlugin.Terminate
        'Throw New NotImplementedException()
    End Sub

    Public Sub OnAddSeries(e As AddSerieEventArgs) Implements IPhonePlugin.OnAddSeries
        'Throw New NotImplementedException()
    End Sub

    Public Sub OnAddSeriesDetalle(e As AddSerieEventArgs) Implements IPhonePlugin.OnAddSeriesDetalle
        'Throw New NotImplementedException()
    End Sub

    Public Function CreateMenuTree() As MainMenuTree Implements IPhonePlugin.CreateMenuTree
        Dim stream = Assembly.GetAssembly(Me.GetType()).GetManifestResourceStream("Studio.Vision.Plugins.Telko.ADM.PluginMenu.xml")
        'Dim reader As New System.IO.StreamReader(stream)
        'Dim texto As String = reader.ReadToEnd()

        Return MainMenuTree.Create(Of MainMenuTree)(Assembly.GetAssembly(Me.GetType()).GetManifestResourceStream("Studio.Vision.Plugins.Telko.ADM.PluginMenu.xml"))
    End Function

End Class
