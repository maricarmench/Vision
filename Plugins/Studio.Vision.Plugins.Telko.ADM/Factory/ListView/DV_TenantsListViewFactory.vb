Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.Plugins.Telko.ADM.Business

Public Class DV_TenantsListViewFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New ListViewModule() With {.DetailFactory = New DV_TenantsDetailModuleViewFactory(), .ListViewToUse = New DrakoListView(New TenantBEntity)}

    End Function
End Class
