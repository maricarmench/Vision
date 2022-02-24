<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_CristalDetailViewModule
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
        Me.bbiVariantes = New DevExpress.XtraBars.BarButtonItem()
        Me.rpTareas = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgTareas = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.bbiCambiarPrecios = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonPageCategory1
        '
        Me.RibbonPageCategory1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpTareas})
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.ExpandCollapseItem.Name = ""
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiVariantes, Me.bbiCambiarPrecios})
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonControl1.MaxItemId = 12
        Me.RibbonControl1.Size = New System.Drawing.Size(850, 140)
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        '
        'PanelControl
        '
        Me.PanelControl.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl.Appearance.Options.UseBackColor = True
        Me.PanelControl.Location = New System.Drawing.Point(0, 140)
        Me.PanelControl.Size = New System.Drawing.Size(850, 227)
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
        'bbiVariantes
        '
        Me.bbiVariantes.Caption = "Crear variantes"
        Me.bbiVariantes.Glyph = Global.Studio.Vision.Controls.My.Resources.Resources.stamp_add_32
        Me.bbiVariantes.Id = 10
        Me.bbiVariantes.LargeGlyph = Global.Studio.Vision.Controls.My.Resources.Resources.stamp_add_32
        Me.bbiVariantes.Name = "bbiVariantes"
        '
        'rpTareas
        '
        Me.rpTareas.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgTareas})
        Me.rpTareas.Name = "rpTareas"
        Me.rpTareas.Text = "Tareas"
        '
        'rpgTareas
        '
        Me.rpgTareas.ItemLinks.Add(Me.bbiVariantes)
        Me.rpgTareas.ItemLinks.Add(Me.bbiCambiarPrecios)
        Me.rpgTareas.Name = "rpgTareas"
        Me.rpgTareas.Text = "Tareas"
        '
        'bbiCambiarPrecios
        '
        Me.bbiCambiarPrecios.Caption = "Cambiar precios"
        Me.bbiCambiarPrecios.Glyph = Global.Studio.Vision.Controls.My.Resources.Resources.Cambiar_precios
        Me.bbiCambiarPrecios.Id = 11
        Me.bbiCambiarPrecios.LargeGlyph = Global.Studio.Vision.Controls.My.Resources.Resources.Cambiar_precios
        Me.bbiCambiarPrecios.Name = "bbiCambiarPrecios"
        '
        'DV_CristalDetailViewModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_CristalDetailViewModule"
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpgTask As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiVariantes As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiCambiarPrecios As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpTareas As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgTareas As DevExpress.XtraBars.Ribbon.RibbonPageGroup

End Class
