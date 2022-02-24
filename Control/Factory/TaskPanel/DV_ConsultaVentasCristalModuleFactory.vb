Imports Studio.Net.Controls.New.Factory

Public Class DV_HistoricoDocumentoSalidaCristalModuleFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Net.Controls.New.Factory.IControlFactory.Create
        Return New DV_HistoricoDocumentoSalidaCristalModule()
    End Function

End Class
