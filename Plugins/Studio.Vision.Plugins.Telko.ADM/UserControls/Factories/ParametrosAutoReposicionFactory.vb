Imports Studio.Net.Controls.New.Factory

Public Class ParametrosAutoReposicionFactory
    Implements IControlFactory

    Public Function Create() As Object Implements IControlFactory.Create
        Return New ParametrosAutoReposicionModule()
    End Function

End Class
