Imports Studio.Vision.POS.BLL.Business

Public Class DV_RecetaTipoBEntityFactory
    Implements Studio.Net.BLL.IBEntityFactory

    Public Function Create() As Net.BLL.IBEntity Implements Net.BLL.IBEntityFactory.Create
        Return New DV_RecetaTipoBEntity
    End Function
End Class
