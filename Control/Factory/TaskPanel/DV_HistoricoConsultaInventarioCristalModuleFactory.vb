﻿Imports Studio.Net.Controls.New.Factory

Public Class DV_HistoricoConsultaInventarioCristalModuleFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Net.Controls.New.Factory.IControlFactory.Create
        Return New DV_HistoricoConsultaInventarioCristalModule()
    End Function

End Class
