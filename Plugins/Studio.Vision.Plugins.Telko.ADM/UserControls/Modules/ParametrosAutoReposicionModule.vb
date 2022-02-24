Public Class ParametrosAutoReposicionModule

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AgregarContentView(New DV_ParametrosAutoReposicionParametros)

    End Sub


    Public Sub New(view As DV_ParametrosAutoReposicionParametros)

        InitializeComponent()

        AgregarContentView(view)

    End Sub

    Private Sub AgregarContentView(view As DV_ParametrosAutoReposicionParametros)

        view.Dock = Windows.Forms.DockStyle.Fill
        PanelControl.Controls.Add(view)
    End Sub
End Class
