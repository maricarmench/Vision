<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiferenciasModels
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(12, 69)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Size = New System.Drawing.Size(827, 325)
        Me.MemoEdit1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(256, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(198, 38)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "Comenzar"
        '
        'DiferenciasModels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 401)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.MemoEdit1)
        Me.Name = "DiferenciasModels"
        Me.Text = "DiferenciasModels"
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
