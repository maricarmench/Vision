
Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New

Public Class DV_AjusteListViewModuleFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New AjusteListViewModule() With {.DetailFactory = New DV_AjusteDetailViewModuleFactory(), .ListViewToUse = New DrakoListView(New AjusteBEntity), .MultiEditDisabled = True}
    End Function

End Class
