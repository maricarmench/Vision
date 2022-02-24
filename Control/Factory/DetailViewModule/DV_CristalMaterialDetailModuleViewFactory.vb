Imports Studio.Net.Controls.New.UserControls
Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New
Imports Studio.Net.Controls.New.Forms

Public Class DV_CristalMaterialDetailModuleViewFactory
    Implements IDetailViewModuleFactory

    Public Function Create(ByVal parent As MainFormBase, ByVal listModule As IListViewModule, ByVal isNew As Boolean) As DetailViewModule Implements IDetailViewModuleFactory.Create
        Return New DetailViewModule(parent, New DV_CristalMaterialDetailView(listModule.ListViewToUse.BusinessEntity, listModule.ListViewToUse.Source))
    End Function

End Class

