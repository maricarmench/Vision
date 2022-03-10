Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.Plugins.Telko.ADM.Business

Public Class DV_PlantillaRep_PlantRepDetEmbeddedListViewFactory
    Implements IEmbeddedListViewModuleFactory
    Public Function Create(ByVal parent As Net.Controls.New.Forms.MainFormBase, ByVal relationName As String) As Net.Controls.New.IEmbeddedListViewModule Implements Net.Controls.New.Factory.IEmbeddedListViewModuleFactory.Create
        Return New ParComEmbedableListViewModule(relationName, parent) With {.DetailFactory = New DV_PlantillaRep_DetalleModuleViewFactory(), .ListViewToUse = New DrakoListView(New PlantillaRepDetalleBEntity)}
        'Return New EmbeddableListViewModule(relationName, parent) With {.DetailFactory = New DV_PlantillaRep_DetalleModuleViewFactory(), .ListViewToUse = New DrakoListView(New PlantillaRepDetalleBEntity)}
    End Function

End Class
