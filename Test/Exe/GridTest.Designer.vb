<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GridTest
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
        Me.MyDXGrid1 = New Studio.Net.Controls.[New].MyDXGrid()
        CType(Me.MyDXGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MyDXGrid1
        '
        Me.MyDXGrid1.Location = New System.Drawing.Point(10, 22)
        Me.MyDXGrid1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MyDXGrid1.Name = "MyDXGrid1"
        Me.MyDXGrid1.Size = New System.Drawing.Size(730, 366)
        Me.MyDXGrid1.TabIndex = 0
        '
        'GridTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 443)
        Me.Controls.Add(Me.MyDXGrid1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "GridTest"
        Me.Text = "GridTest"
        CType(Me.MyDXGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyDXGrid1 As Studio.Net.Controls.New.MyDXGrid
End Class
