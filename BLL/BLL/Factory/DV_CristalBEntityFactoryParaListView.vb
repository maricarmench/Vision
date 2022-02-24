Imports Studio.Vision.BLL.Business

Public Class DV_CristalBEntityFactoryParaListView
    Implements Studio.Net.BLL.IBEntityFactory

    Public Function Create() As Net.BLL.IBEntity Implements Net.BLL.IBEntityFactory.Create
        Return New DV_CristalBEntity With {.SysFilterExpression = DV_CristalBEntity.CrearFiltroPorNoVariante()}
    End Function
End Class
