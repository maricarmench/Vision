Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Net.Controls.New
Imports Studio.Net.Controls.New.Forms
Imports Studio.Phone.Controls.New

Public Class DV_CajaDetailViewModuleFactory
    Implements IDetailViewModuleFactory

    Public Function Create(ByVal parent As MainFormBase, ByVal listModule As IListViewModule, ByVal isNew As Boolean) As DetailViewModule Implements IDetailViewModuleFactory.Create
        Return New DetailViewModule(parent, New DV_CajaDetailView(listModule.ListViewToUse.BusinessEntity, listModule.ListViewToUse.DataSource))
    End Function

End Class
