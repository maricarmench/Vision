<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class eFacturaForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtListaId = New System.Windows.Forms.TextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtListaId
        '
        Me.txtListaId.Location = New System.Drawing.Point(88, 47)
        Me.txtListaId.Name = "txtListaId"
        Me.txtListaId.Size = New System.Drawing.Size(100, 20)
        Me.txtListaId.TabIndex = 0
        Me.txtListaId.Text = "1"
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(63, 84)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(158, 54)
        Me.btnEnviar.TabIndex = 1
        Me.btnEnviar.Text = "Enviar comprobantes"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'eFacturaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 176)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.txtListaId)
        Me.Name = "eFacturaForm"
        Me.Text = "eFacturaForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtListaId As System.Windows.Forms.TextBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
End Class
