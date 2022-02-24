Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.BLL
Imports Studio.Vision.BLL.Business

Public Class DV_CristalMaterialListViewFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New ListViewModule() With {.DetailFactory = New DV_CristalMaterialDetailModuleViewFactory(), .ListViewToUse = New DrakoListView(New DV_CristalMaterialBEntity)}
    End Function

End Class
