<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_HistoricoConsultaInventarioCristalModule
    Inherits Studio.Net.Controls.[New].UserControls.ListViewTaskPanelModule

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
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.cboDepositoId = New Studio.Net.Controls.[New].Controls.DXSearchLookUp()
        Me.DxSearchLookUp1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnCargarDatos = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.chkCristales = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.lqsmsCristales = New DevExpress.Data.Linq.LinqServerModeSource()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.popUpFiltroContainer,System.ComponentModel.ISupportInitialize).BeginInit
        Me.popUpFiltroContainer.SuspendLayout
        CType(Me.LayoutControl,System.ComponentModel.ISupportInitialize).BeginInit
        Me.LayoutControl.SuspendLayout
        CType(Me.LayoutControlGroup,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pmExport,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ritxtCurrentPage,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.riLkpPageSize,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ribeSearch,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pmFiltering,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemMarqueeProgressBar1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ApplicationMenu1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pmReporting,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pmEditar,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RibbonControl1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PanelControl,System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelControl.SuspendLayout
        CType(Me.cboDepositoId.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DxSearchLookUp1View,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlItem1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlItem3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.chkCristales.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lqsmsCristales,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlItem4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtFecha.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtFecha.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlItem2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'popUpFiltroContainer
        '
        Me.popUpFiltroContainer.Location = New System.Drawing.Point(210, 17)
        Me.popUpFiltroContainer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.popUpFiltroContainer.Size = New System.Drawing.Size(468, 136)
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.txtFecha)
        Me.LayoutControl.Controls.Add(Me.chkCristales)
        Me.LayoutControl.Controls.Add(Me.btnCargarDatos)
        Me.LayoutControl.Controls.Add(Me.cboDepositoId)
        Me.LayoutControl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1072, 397, 450, 400)
        Me.LayoutControl.OptionsSerialization.DiscardOldItems = true
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = false
        Me.LayoutControl.Size = New System.Drawing.Size(464, 132)
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem2})
        Me.LayoutControlGroup.Name = "Root"
        Me.LayoutControlGroup.OptionsItemText.TextToControlDistance = 5
        Me.LayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3)
        Me.LayoutControlGroup.Size = New System.Drawing.Size(464, 132)
        '
        'ritxtCurrentPage
        '
        Me.ritxtCurrentPage.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1})
        Me.RibbonControl1.MaxItemId = 2
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        '
        'PanelControl
        '
        Me.PanelControl.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl.Appearance.Options.UseBackColor = true
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'cboDepositoId
        '
        Me.cboDepositoId.BusinessToUse = Nothing
        Me.cboDepositoId.Location = New System.Drawing.Point(118, 5)
        Me.cboDepositoId.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboDepositoId.MenuManager = Me.RibbonControl1
        Me.cboDepositoId.Name = "cboDepositoId"
        Me.cboDepositoId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDepositoId.Properties.NullText = "[Seleccione el depósito]"
        Me.cboDepositoId.Properties.View = Me.DxSearchLookUp1View
        Me.cboDepositoId.Size = New System.Drawing.Size(341, 20)
        Me.cboDepositoId.StyleController = Me.LayoutControl
        Me.cboDepositoId.TabIndex = 4
        '
        'DxSearchLookUp1View
        '
        Me.DxSearchLookUp1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.DxSearchLookUp1View.Name = "DxSearchLookUp1View"
        Me.DxSearchLookUp1View.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.DxSearchLookUp1View.OptionsView.ShowGroupPanel = false
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cboDepositoId
        Me.LayoutControlItem1.CustomizationFormText = "Depósito"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(458, 24)
        Me.LayoutControlItem1.Text = "Depósito"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(108, 13)
        '
        'btnCargarDatos
        '
        Me.btnCargarDatos.Image = Global.Studio.Vision.Controls.My.Resources.Resources.Query32
        Me.btnCargarDatos.Location = New System.Drawing.Point(5, 77)
        Me.btnCargarDatos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCargarDatos.Name = "btnCargarDatos"
        Me.btnCargarDatos.Size = New System.Drawing.Size(454, 50)
        Me.btnCargarDatos.StyleController = Me.LayoutControl
        Me.btnCargarDatos.TabIndex = 6
        Me.btnCargarDatos.Text = "Cargar datos"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnCargarDatos
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(97, 27)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(458, 54)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = false
        '
        'chkCristales
        '
        Me.chkCristales.Location = New System.Drawing.Point(118, 29)
        Me.chkCristales.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkCristales.MenuManager = Me.RibbonControl1
        Me.chkCristales.Name = "chkCristales"
        Me.chkCristales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.chkCristales.Properties.DataSource = Me.lqsmsCristales
        Me.chkCristales.Properties.DisplayMember = "Descripcion"
        Me.chkCristales.Properties.ValueMember = "Id"
        Me.chkCristales.Size = New System.Drawing.Size(341, 20)
        Me.chkCristales.StyleController = Me.LayoutControl
        Me.chkCristales.TabIndex = 7
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.chkCristales
        Me.LayoutControlItem4.CustomizationFormText = "Seleccione los cristales"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(458, 24)
        Me.LayoutControlItem4.Text = "Seleccione los cristales"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(108, 13)
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.Location = New System.Drawing.Point(118, 53)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFecha.Size = New System.Drawing.Size(341, 20)
        Me.txtFecha.StyleController = Me.LayoutControl
        Me.txtFecha.TabIndex = 14
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtFecha
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(458, 24)
        Me.LayoutControlItem2.Text = "Fecha de corte"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(108, 13)
        '
        'DV_HistoricoConsultaInventarioCristalModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_HistoricoConsultaInventarioCristalModule"
        CType(Me.popUpFiltroContainer,System.ComponentModel.ISupportInitialize).EndInit
        Me.popUpFiltroContainer.ResumeLayout(false)
        CType(Me.LayoutControl,System.ComponentModel.ISupportInitialize).EndInit
        Me.LayoutControl.ResumeLayout(false)
        CType(Me.LayoutControlGroup,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pmExport,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ritxtCurrentPage,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.riLkpPageSize,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ribeSearch,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pmFiltering,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemMarqueeProgressBar1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ApplicationMenu1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pmReporting,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pmEditar,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RibbonControl1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PanelControl,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelControl.ResumeLayout(false)
        CType(Me.cboDepositoId.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DxSearchLookUp1View,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlItem1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlItem3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.chkCristales.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lqsmsCristales,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlItem4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFecha.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFecha.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlItem2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cboDepositoId As Studio.Net.Controls.New.Controls.DXSearchLookUp
    Friend WithEvents DxSearchLookUp1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnCargarDatos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkCristales As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lqsmsCristales As DevExpress.Data.Linq.LinqServerModeSource
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
