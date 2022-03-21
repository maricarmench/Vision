<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ParComEmbedableListViewModule
    Inherits Studio.Net.Controls.[New].UserControls.EmbeddableListViewModule

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Orden = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()

        'colOrden
        '
        Me.Orden.Caption = "Orden"
        Me.Orden.FieldName = "Orden"
        Me.Orden.Name = "colOrden"

        components = New System.ComponentModel.Container()
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    End Sub

    Friend WithEvents Orden As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
