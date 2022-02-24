<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UtilsForm
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
        Me.txtCSDest = New System.Windows.Forms.TextBox()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFiltroDest = New System.Windows.Forms.TextBox()
        Me.SuspendLayout
        '
        'txtCSDest
        '
        Me.txtCSDest.Location = New System.Drawing.Point(205, 35)
        Me.txtCSDest.Name = "txtCSDest"
        Me.txtCSDest.Size = New System.Drawing.Size(403, 22)
        Me.txtCSDest.TabIndex = 0
        Me.txtCSDest.Text = "data source=localhost;initial catalog=Studio_Vision_delfino_NH;user id=sa;passwor"& _ 
    "d=sqladmin03;persist security info=True;packet size=4096"
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(313, 113)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(151, 41)
        Me.btnProcesar.TabIndex = 1
        Me.btnProcesar.Text = "Copiar Articulos"
        Me.btnProcesar.UseVisualStyleBackColor = true
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(31, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ConnectionString Destino"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(31, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Filtro a aplicar"
        '
        'txtFiltroDest
        '
        Me.txtFiltroDest.Location = New System.Drawing.Point(205, 76)
        Me.txtFiltroDest.Name = "txtFiltroDest"
        Me.txtFiltroDest.Size = New System.Drawing.Size(403, 22)
        Me.txtFiltroDest.TabIndex = 3
        Me.txtFiltroDest.Text = "Id > 12427 and RubroId <> 19"
        '
        'UtilsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFiltroDest)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.txtCSDest)
        Me.Name = "UtilsForm"
        Me.Text = "UtilsForm"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents txtCSDest As TextBox
    Friend WithEvents btnProcesar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFiltroDest As TextBox
End Class
