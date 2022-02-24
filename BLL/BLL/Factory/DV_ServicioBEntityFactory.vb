Imports Studio.Vision.BLL.Business
Imports Studio.Phone.BLL

Public Class DV_ServicioBEntityFactory
    Implements Studio.Net.BLL.IBEntityFactory

    Public Function Create() As Net.BLL.IBEntity Implements Net.BLL.IBEntityFactory.Create
        Return New DV_ServicioBEntity With {.SysFilterExpression = DV_ServicioBEntity.CrearFiltroPorServicio()}
    End Function

End Class
