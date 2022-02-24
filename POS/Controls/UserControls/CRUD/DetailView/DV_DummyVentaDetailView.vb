Imports Studio.Net.BLL
Imports Studio.Net.Controls.New

Public Class DV_DummyVentaDetailView

#Region "CTor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As BEntityBase, ByVal binding As MyBindingSource)

        MyBase.New(business, binding)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region
#Region "Overrides"
    Public Overrides Sub OnAddingToContainer()
        'MyBase.OnAddingToContainer()
    End Sub
#End Region

End Class
