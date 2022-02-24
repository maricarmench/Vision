Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.Plugins.Telko.ADM.Business

Public Class ParametrosReposicionFactory
    Implements IControlFactory
    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New ListViewModule() With {.DetailFactory = New DV_PlantillaRepDetailModuleViewFactory(), .ListViewToUse = New DrakoListView(New PlantillaReposicionBEntity)}
    End Function
End Class
