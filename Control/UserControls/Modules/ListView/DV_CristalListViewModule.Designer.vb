<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_CristalListViewModule
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
        Me.rpgPrecios = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.bbiCambiarPrecios = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiCopiar = New DevExpress.XtraBars.BarButtonItem()
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
        'ritxtCurrentPage
        '
        Me.ritxtCurrentPage.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.ExpandCollapseItem.Name = ""
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiCambiarPrecios, Me.bbiCopiar})
        Me.RibbonControl1.MaxItemId = 51
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpTareas})
        Me.RibbonControl1.Size = New System.Drawing.Size(867, 142)
        '
        'PanelControl
        '
        Me.PanelControl.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl.Appearance.Options.UseBackColor = True
        Me.PanelControl.Location = New System.Drawing.Point(0, 142)
        Me.PanelControl.Size = New System.Drawing.Size(867, 278)
        '
        'rpTareas
        '
        Me.rpTareas.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgPrecios})
        Me.rpTareas.Name = "rpTareas"
        Me.rpTareas.Text = "Tareas"
        '
        'rpgPrecios
        '
        Me.rpgPrecios.ItemLinks.Add(Me.bbiCambiarPrecios)
        Me.rpgPrecios.ItemLinks.Add(Me.bbiCopiar, True)
        Me.rpgPrecios.Name = "rpgPrecios"
        Me.rpgPrecios.Text = "Precios"
        '
        'bbiCambiarPrecios
        '
        Me.bbiCambiarPrecios.Caption = "Cambiar precios"
        Me.bbiCambiarPrecios.Glyph = Global.Studio.Vision.Controls.My.Resources.Resources.Cambiar_precios
        Me.bbiCambiarPrecios.Id = 49
        Me.bbiCambiarPrecios.LargeGlyph = Global.Studio.Vision.Controls.My.Resources.Resources.Cambiar_precios
        Me.bbiCambiarPrecios.Name = "bbiCambiarPrecios"
        '
        'bbiCopiar
        '
        Me.bbiCopiar.Caption = "Copiar cristal"
        Me.bbiCopiar.Glyph = Global.Studio.Vision.Controls.My.Resources.Resources.Action_Copy_32x32
        Me.bbiCopiar.Id = 50
        Me.bbiCopiar.LargeGlyph = Global.Studio.Vision.Controls.My.Resources.Resources.Action_Copy_32x32
        Me.bbiCopiar.Name = "bbiCopiar"
        '
        'DV_CristalListViewModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "DV_CristalListViewModule"
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
    Friend WithEvents bbiCambiarPrecios As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpTareas As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgPrecios As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiCopiar As DevExpress.XtraBars.BarButtonItem

End Class
