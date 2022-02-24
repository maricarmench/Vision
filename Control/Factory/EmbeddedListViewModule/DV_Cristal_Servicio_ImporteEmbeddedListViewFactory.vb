Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Net.Controls.New.Forms
Imports Studio.Phone.Controls.New
Imports Studio.Vision.BLL.Business

Public Class DV_Cristal_Servicio_ImporteEmbeddedListViewFactory
    Implements IEmbeddedListViewModuleFactory

    Public Function Create(ByVal parent As MainFormBase, ByVal relationName As String) As Studio.Net.Controls.New.IEmbeddedListViewModule Implements Studio.Net.Controls.New.Factory.IEmbeddedListViewModuleFactory.Create
        Return New EmbeddableListViewModule(relationName, parent) With {.DetailFactory = Nothing, .ListViewToUse = New DrakoListView(New DV_Cristal_Servicio_ImporteBEntity)}
    End Function

End Class
