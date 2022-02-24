<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_RecetaComunListViewModule
    Inherits Studio.Net.Controls.[New].UserControls.ListViewModule

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
        Me.rpTareas = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgFacturacion = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.bbiSeleccionarFacturas = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiFacturar = New DevExpress.XtraBars.BarButtonItem()
        Me.rpgImpresion = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.bbiConfigurarImpresion = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.pmExport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ritxtCurrentPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riLkpPageSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ribeSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmFiltering, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMarqueeProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmReporting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmEditar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bbiDelete
        '
        Me.bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'ritxtCurrentPage
        '
        Me.ritxtCurrentPage.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.ExpandCollapseItem.Name = ""
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiSeleccionarFacturas, Me.bbiFacturar, Me.bbiConfigurarImpresion})
        Me.RibbonControl1.MaxItemId = 52
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpTareas})
        Me.RibbonControl1.Size = New System.Drawing.Size(867, 140)
        '
        'PanelControl
        '
        Me.PanelControl.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl.Appearance.Options.UseBackColor = True
        Me.PanelControl.Location = New System.Drawing.Point(0, 140)
        Me.PanelControl.Size = New System.Drawing.Size(867, 282)
        '
        'rpTareas
        '
        Me.rpTareas.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgFacturacion, Me.rpgImpresion})
        Me.rpTareas.Name = "rpTareas"
        Me.rpTareas.Text = "Tareas"
        '
        'rpgFacturacion
        '
        Me.rpgFacturacion.ItemLinks.Add(Me.bbiSeleccionarFacturas)
        Me.rpgFacturacion.ItemLinks.Add(Me.bbiFacturar)
        Me.rpgFacturacion.Name = "rpgFacturacion"
        Me.rpgFacturacion.Text = "Facturación"
        '
        'bbiSeleccionarFacturas
        '
        Me.bbiSeleccionarFacturas.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.bbiSeleccionarFacturas.Caption = "Seleccionar para facturar a crédito"
        Me.bbiSeleccionarFacturas.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.ActionGroup_EasyTestRecorder
        Me.bbiSeleccionarFacturas.Id = 49
        Me.bbiSeleccionarFacturas.LargeGlyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.ActionGroup_EasyTestRecorder_32x32
        Me.bbiSeleccionarFacturas.Name = "bbiSeleccionarFacturas"
        '
        'bbiFacturar
        '
        Me.bbiFacturar.Caption = "Facturar a crédito"
        Me.bbiFacturar.Enabled = False
        Me.bbiFacturar.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Facturar2_16x16
        Me.bbiFacturar.Id = 50
        Me.bbiFacturar.LargeGlyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Facturar2
        Me.bbiFacturar.Name = "bbiFacturar"
        '
        'rpgImpresion
        '
        Me.rpgImpresion.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Print
        Me.rpgImpresion.ItemLinks.Add(Me.bbiConfigurarImpresion)
        Me.rpgImpresion.Name = "rpgImpresion"
        Me.rpgImpresion.Text = "Impresión"
        '
        'bbiConfigurarImpresion
        '
        Me.bbiConfigurarImpresion.Caption = "Configuración"
        Me.bbiConfigurarImpresion.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.system_config_services_16
        Me.bbiConfigurarImpresion.Id = 51
        Me.bbiConfigurarImpresion.LargeGlyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.system_config_services_321
        Me.bbiConfigurarImpresion.Name = "bbiConfigurarImpresion"
        '
        'DV_RecetaComunListViewModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_RecetaComunListViewModule"
        CType(Me.pmExport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ritxtCurrentPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riLkpPageSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ribeSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmFiltering, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMarqueeProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmReporting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmEditar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bbiSeleccionarFacturas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiFacturar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpTareas As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgFacturacion As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiConfigurarImpresion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgImpresion As DevExpress.XtraBars.Ribbon.RibbonPageGroup

End Class
