Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Vision.BLL.Business

Public Class DV_BonificacionDinamicaMain
    Inherits Studio.Phone.Controls.[New].BonificacionDinamicaMain

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(bonificacion As BonificacionDinamicaParametroEntity)

        ' This call is required by the designer.
        MyBase.New(bonificacion)

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        ConfigGrid(grdCristal, New CristalBEntityParaBonificacionDinamica, BonificacionDinamicaIdsFields.CristalId, BonificacionDinamicaIdsFields.CristalCantidad, True)

    End Sub

    Protected Overrides Sub OnSaveGrids()
        MyBase.OnSaveGrids()
        SaveGrid(grdCristal, BonificacionDinamicaIdsFields.CristalId, BonificacionDinamicaIdsFields.CristalCantidad)

    End Sub
End Class
