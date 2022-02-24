
Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New

Public Class DV_TraspasoIngresoListViewModuleFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New TraspasoIngresoListViewModule() With {.DetailFactory = New DV_TraspasoIngresoDetailViewModuleFactory(), .ListViewToUse = New DrakoListView(New TraspasoBentity), .MultiEditDisabled = True}
    End Function

End Class
