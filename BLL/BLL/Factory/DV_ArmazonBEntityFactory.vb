Imports Studio.Vision.BLL.Business
Imports Studio.Phone.BLL

Public Class DV_ArmazonBEntityFactory
    Implements Studio.Net.BLL.IBEntityFactory

    Public Function Create() As Net.BLL.IBEntity Implements Net.BLL.IBEntityFactory.Create
        Return New DV_ArmazonBEntity With {.SysFilterExpression = DV_ArmazonBEntity.CrearFiltroPorArmazon()}
    End Function

End Class
