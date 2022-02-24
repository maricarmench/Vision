Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.BLL

Public Class DV_ListaPreVtaListViewFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New ListViewModule() With {.DetailFactory = New ListaPreVtaDetailModuleViewFactory(), .ListViewToUse = New DrakoListView(New DV_ListaPreVtaBEntity)}
    End Function

End Class
