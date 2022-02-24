Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.Plugins.Telko.ADM.Business
Imports ParametroComisionVendedorBEntity = Studio.Vision.Plugins.Telko.ADM.Business.ParametroComisionVendedorBEntity

Public Class ParametrosComisionFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Net.Controls.New.Factory.IControlFactory.Create
        Return New ParametroComisionVendedorListViewModule()

    End Function
End Class