Imports Studio.Net.Controls.New.UserControls
Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New
Imports Studio.Net.Controls.New.Forms

Public Class DV_RecetaComunDetailViewModuleFactory
    Implements IDetailViewModuleFactory

    Public Function Create(ByVal parent As Net.Controls.New.Forms.MainFormBase, ByVal listModule As Net.Controls.New.IListViewModule, ByVal isNew As Boolean) As Net.Controls.New.UserControls.DetailViewModule Implements Net.Controls.New.Factory.IDetailViewModuleFactory.Create
        'Return New DV_RecetaComunDetailViewModule() With {.DetailViewToUse = New DV_DummyVentaDetailView(listModule.ListViewToUse.BusinessEntity, listModule.ListViewToUse.Source)}
        Return New DV_RecetaComunDetailViewModule() With {.DetailViewToUse = New DV_RecetaLenteComunDetailView(listModule.ListViewToUse.BusinessEntity, listModule.ListViewToUse.Source)}
    End Function

End Class

