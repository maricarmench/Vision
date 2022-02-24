Imports Studio.Vision.BLL
Imports Studio.Net.Controls.New
Imports Studio.Vision.BLL.Business

Public Class DV_Cristal_PrecioGraduacionDetailView

    Public Sub New()

        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As DV_Cristal_PrecioGraduacionBEntity, ByVal binding As MyBindingSource)

        MyBase.New(business, binding)

        InitializeComponent()

    End Sub

End Class
