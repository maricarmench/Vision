﻿Imports Studio.Vision.BLL.Business

Public Class DV_CristalBEntityFactory
    Implements Studio.Net.BLL.IBEntityFactory

    Public Function Create() As Net.BLL.IBEntity Implements Net.BLL.IBEntityFactory.Create
        Return New DV_CristalBEntity
    End Function
End Class
