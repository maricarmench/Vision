Imports Studio.Net.Controls.New.Factory

Public Class DV_ConsultaInventarioCristalModuleFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Net.Controls.New.Factory.IControlFactory.Create
        Return New DV_ConsultaInventarioCristalModule()
    End Function

End Class
