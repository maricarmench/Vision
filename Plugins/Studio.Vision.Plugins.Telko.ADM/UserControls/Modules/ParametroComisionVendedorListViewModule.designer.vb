<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParametroComisionVendedorListViewModule
    'Inherits Studio.Net.Controls.[New].UserControls.ListViewModule
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
        Me.rpgSort = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.bbiMoveUp = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiMoveDown = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiSave = New DevExpress.XtraBars.BarButtonItem()
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
        'rpgRecordManager
        '
        Me.rpgRecordManager.ItemLinks.Add(Me.bbiSave, True)
        '
        'ritxtCurrentPage
        '
        Me.ritxtCurrentPage.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiMoveUp, Me.bbiMoveDown, Me.bbiSave})
        Me.RibbonControl1.MaxItemId = 48
        '
        'rpInicio
        '
        Me.rpInicio.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgSort})
        '
        'PanelControl
        '
        Me.PanelControl.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl.Appearance.Options.UseBackColor = True
        '
        'rpgSort
        '
        Me.rpgSort.ItemLinks.Add(Me.bbiMoveUp)
        Me.rpgSort.ItemLinks.Add(Me.bbiMoveDown)
        Me.rpgSort.Name = "rpgSort"
        Me.rpgSort.Text = "Reordenar"
        '
        'bbiMoveUp
        '
        Me.bbiMoveUp.Caption = "Mover hacia arriba"
        Me.bbiMoveUp.Id = 45
        Me.bbiMoveUp.ImageOptions.Image = Global.Studio.Vision.Plugins.Telko.ADM.My.Resources.Resources.Action_Save
        Me.bbiMoveUp.ImageOptions.LargeImage = Global.Studio.Vision.Plugins.Telko.ADM.My.Resources.Resources.Action_Save_32x32
        Me.bbiMoveUp.Name = "bbiMoveUp"
        '
        'bbiMoveDown
        '
        Me.bbiMoveDown.Caption = "Mover hacia abajo"
        Me.bbiMoveDown.Id = 46
        Me.bbiMoveDown.ImageOptions.Image = Global.Studio.Vision.Plugins.Telko.ADM.My.Resources.Resources.Action_Save
        Me.bbiMoveDown.ImageOptions.LargeImage = Global.Studio.Vision.Plugins.Telko.ADM.My.Resources.Resources.Action_Save_32x32
        Me.bbiMoveDown.Name = "bbiMoveDown"
        '
        'bbiSave
        '
        Me.bbiSave.Caption = "Guardar cambios"
        Me.bbiSave.Id = 47
        Me.bbiSave.ImageOptions.Image = Global.Studio.Vision.Plugins.Telko.ADM.My.Resources.Resources.Action_Save
        Me.bbiSave.ImageOptions.LargeImage = Global.Studio.Vision.Plugins.Telko.ADM.My.Resources.Resources.Action_Save_32x32
        Me.bbiSave.Name = "bbiSave"
        '
        'ParametroComisionVendedorListViewModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "ParametroComisionVendedorListViewModule"
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
        Me.PerformLayout()

    End Sub
    Friend WithEvents bbiMoveUp As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgSort As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiMoveDown As DevExpress.XtraBars.BarButtonItem


End Class
