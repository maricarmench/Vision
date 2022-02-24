Imports Studio.Net.Controls.New.Factory

Public Class DistribucionRegistroFactory
    Implements IControlFactory

    Public Function Create() As Object Implements IControlFactory.Create
        Return New ParametrosAutoReposicionModule() '**** ESTO LO DEBO QUITAR ***
        '**** E INVOCAR Studio.Vision.Telko.Shared.DistribucionRegistro.GetDistribucionRegistro
    End Function

End Class
