Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.BLL

Public Class DV_CristalListViewFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New DV_CristalListViewModule() With {.DetailFactory = New DV_CristalDetailModuleViewFactory(), .ListViewToUse = New DrakoListView((New DV_CristalBEntityFactoryParaListView).Create())}
    End Function

End Class
