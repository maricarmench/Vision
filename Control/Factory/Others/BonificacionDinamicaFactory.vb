Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New

Public Class BonificacionDinamicaFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Net.Controls.New.Factory.IControlFactory.Create
        'Return Studio.Net.Controls.[New].FormHelper.ShowControl(Nothing, New AsociarArticulosWizard(New LocalAsociador))
        Return New DV_BonificacionDinamicaParametros
    End Function

End Class
