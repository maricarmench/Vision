Imports Studio.Net.BLL
Imports Studio.Vision.BLL.Business
Imports Studio.Net.Controls.New

Public Class DV_RecetaComunDatosTallerDetailView

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'BusinessToUse = New DynamicBEntity()
    End Sub

    Public Sub New(business As DV_RecetaComunBEntity, binding As MyBindingSource)

        MyBase.New(business, binding)

        InitializeComponent()

    End Sub

    Public Shadows Sub Entity2Controls()
        MyBase.Entity2Controls()
    End Sub

    Public Shadows Sub Control2Entity()
        MyBase.Controls2Entity()
    End Sub


End Class
