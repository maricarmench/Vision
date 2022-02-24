Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.Plugins.Telko.ADM.Business

Public Class DV_Tenants_SubTenantsEmbeddedListViewFactory
    Implements IEmbeddedListViewModuleFactory

    Public Function Create(ByVal parent As Net.Controls.New.Forms.MainFormBase, ByVal relationName As String) As Net.Controls.New.IEmbeddedListViewModule Implements Net.Controls.New.Factory.IEmbeddedListViewModuleFactory.Create
        Return New EmbeddableListViewModule(relationName, parent) With {.DetailFactory = New DV_Tenants_SubTenanatsDetailModuleViewFactory(), .ListViewToUse = New DrakoListView(New SubTenantBEntity)}
        'Return Nothing
    End Function

End Class
