Imports Studio.Vision.POS.BLL.Business

Public Class DV_RecetaComunBEntityFactory
    Implements Studio.Net.BLL.IBEntityFactory

    Public Function Create() As Net.BLL.IBEntity Implements Net.BLL.IBEntityFactory.Create
        Return New DV_RecetaComunBEntity
    End Function

End Class
