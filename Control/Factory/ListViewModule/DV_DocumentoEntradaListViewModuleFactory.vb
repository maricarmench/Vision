
Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New

Public Class DV_DocumentoEntradaListViewModuleFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New DocumentoEntradaListViewModule() With {.DetailFactory = New DV_DocumentoEntradaDetailViewModuleFactory(), .ListViewToUse = New DrakoListView(New DocumentoEntradaBEntity), .MultiEditDisabled = True}
    End Function

End Class
