Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.Controls.New

Public Class DV_VentaListViewModuleFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New VentaListViewModule() With {.DetailFactory = New DV_VentaDetailViewModuleFactory(), .ListViewToUse = New DV_VentaListView(New DocumentoSalidaBEntity)}
    End Function

End Class
