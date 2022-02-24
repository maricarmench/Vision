<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisionSplashScreenForm
    Inherits Studio.Net.Controls.[New].SplashScreen1

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisionSplashScreenForm))
        CType(Me.pictureEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.marqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureEdit2
        '
        Me.pictureEdit2.EditValue = CType(resources.GetObject("pictureEdit2.EditValue"), Object)
        Me.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.pictureEdit2.Properties.Appearance.Options.UseBackColor = True
        '
        'labelControl1
        '
        Me.labelControl1.Location = New System.Drawing.Point(31, 324)
        '
        'marqueeProgressBarControl1
        '
        '
        'VisionSplashScreenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 369)
        Me.Name = "VisionSplashScreenForm"
        CType(Me.pictureEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.marqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
