Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.BLL
Imports Studio.Vision.BLL.Business

Public Class DV_ArmazonListViewFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New ListViewModule() With {.DetailFactory = New DV_ArmazonDetailModuleViewFactory(), .ListViewToUse = New DrakoListView(New DV_ArmazonBEntity With {.SysFilterExpression = DV_ArmazonBEntity.CrearFiltroPorArmazon()})}
    End Function

End Class
