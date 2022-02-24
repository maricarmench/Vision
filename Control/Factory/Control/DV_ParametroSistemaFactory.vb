Imports Studio.Net.Controls.New.Factory

Public Class DV_ParametroSistemaFactory
    Implements IControlFactory


    Public Function Create() As Object Implements Net.Controls.New.Factory.IControlFactory.Create
        Return New DV_ParametroSistemaView
    End Function

End Class
