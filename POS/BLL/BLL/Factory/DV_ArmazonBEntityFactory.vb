Imports Studio.Vision.POS.BLL.Business
Imports Studio.Phone.POS.BLL

Public Class DV_ArmazonBEntityFactory
    Implements Studio.Net.BLL.IBEntityFactory

    Public Function Create() As Net.BLL.IBEntity Implements Net.BLL.IBEntityFactory.Create
        Return New DV_Armazon With {.SysFilterExpression = DV_Armazon.CrearFiltroPorArmazon()}
    End Function

End Class
