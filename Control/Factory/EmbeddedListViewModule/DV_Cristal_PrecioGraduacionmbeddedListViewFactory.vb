Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.BLL
Imports Studio.Vision.BLL.Business

Public Class DV_Cristal_PrecioGraduacionEmbeddedListViewFactory
    Implements IEmbeddedListViewModuleFactory


    Public Function Create(ByVal parent As Net.Controls.New.Forms.MainFormBase, ByVal relationName As String) As Net.Controls.New.IEmbeddedListViewModule Implements Net.Controls.New.Factory.IEmbeddedListViewModuleFactory.Create
        Return New EmbeddableListViewModule(relationName, parent) With {.DetailFactory = New DV_Cristal_PrecioGraduacionDetailModuleViewFactory(), .ListViewToUse = New DrakoListView(New DV_Cristal_PrecioGraduacionBEntity)}
    End Function

End Class
