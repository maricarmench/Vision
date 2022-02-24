Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.Controls.New
Imports Studio.Vision.POS.BLL
Imports Studio.Vision.POS.BLL.Business

Public Class DV_RecetaComunListViewModuleFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        'Return New DV_VentaListViewModule() With {.DetailFactory = New DV_VentaOpticaDetailViewModuleFactory(), .ListViewToUse = New DV_VentaListView(DV_DocumentoSalida.CrearBusinessParaListView())}
        Return New DV_RecetaComunListViewModule() With {.DetailFactory = New DV_RecetaComunDetailViewModuleFactory(), .ListViewToUse = New DV_RecetaComunListView(DV_RecetaComunBEntity.CrearBusinessParaListView())}
    End Function

End Class
