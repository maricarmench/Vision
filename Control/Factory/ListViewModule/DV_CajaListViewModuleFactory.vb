
Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New

Public Class DV_CajaListViewModuleFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New ListViewModule() With {.DetailFactory = New DV_CajaDetailViewModuleFactory(), .ListViewToUse = New DrakoListView(New CajaBEntity), .MultiEditDisabled = True}
    End Function

End Class
