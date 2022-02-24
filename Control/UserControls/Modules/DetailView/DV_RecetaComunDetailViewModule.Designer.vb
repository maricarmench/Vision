<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_RecetaComunDetailViewModule
    Inherits Studio.Net.Controls.[New].UserControls.DetailViewModule


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
        Me.rpgTask = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpgSave
        '
        Me.rpgSave.Visible = False
        '
        'rpgEdit
        '
        Me.rpgEdit.Visible = False
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.RibbonControl1.MaxItemId = 12
        Me.RibbonControl1.Size = New System.Drawing.Size(992, 153)
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        '
        'PanelControl
        '
        Me.PanelControl.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl.Appearance.Options.UseBackColor = True
        Me.PanelControl.Location = New System.Drawing.Point(0, 153)
        Me.PanelControl.Size = New System.Drawing.Size(992, 302)
        '
        'rpgTask
        '
        Me.rpgTask.Name = "rpgTask"
        Me.rpgTask.Text = "Tareas"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Tareas"
        '
        'DV_RecetaComunDetailViewModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_RecetaComunDetailViewModule"
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpgTask As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup

End Class
