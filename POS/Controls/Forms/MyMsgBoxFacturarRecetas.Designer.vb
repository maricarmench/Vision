<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyMsgBoxFacturarRecetas
    Inherits Studio.Net.Controls.[New].MyXtraMessageBoxForm


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.chkImprimir = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.chkImprimir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkImprimir
        '
        Me.chkImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkImprimir.EditValue = True
        Me.chkImprimir.Location = New System.Drawing.Point(-3, 139)
        Me.chkImprimir.Name = "chkImprimir"
        Me.chkImprimir.Properties.Caption = "Imprimir las facturas al finalizar"
        Me.chkImprimir.Size = New System.Drawing.Size(230, 19)
        Me.chkImprimir.TabIndex = 0
        '
        'MyMsgBoxFacturarRecetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 160)
        Me.Controls.Add(Me.chkImprimir)
        Me.Name = "MyMsgBoxFacturarRecetas"
        CType(Me.chkImprimir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkImprimir As DevExpress.XtraEditors.CheckEdit
End Class
