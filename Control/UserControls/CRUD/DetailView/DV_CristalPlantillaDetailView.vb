Imports Studio.Net.Controls.New
Imports Studio.Vision.BLL.Business

Public Class DV_CristalPlantillaDetailView

    Public Sub New(ByVal business As DV_CristalPlantillaBEntity, ByVal binding As MyBindingSource)
        MyBase.New(business, binding)

        InitializeComponent()
    End Sub

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
