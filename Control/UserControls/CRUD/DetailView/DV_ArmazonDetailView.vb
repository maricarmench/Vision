Public Class DV_ArmazonDetailView

    Private _bEntityBase As Net.BLL.BEntityBase
    Private _myBindingSource As Net.Controls.New.MyBindingSource

    Sub New(bEntityBase As Net.BLL.BEntityBase, myBindingSource As Net.Controls.New.MyBindingSource)
        MyBase.New(bEntityBase, myBindingSource)
    End Sub

    Public Sub New()

        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class
