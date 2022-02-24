<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_HistoricoDocumentoSalidaCristalModule
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
        Me.btnCargarDatos = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.chkCristales = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.lqsmsCristales = New DevExpress.Data.Linq.LinqServerModeSource()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtFechaDesde = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtFechaHasta = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        CType(Me.popUpFiltroContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popUpFiltroContainer.SuspendLayout()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PanelControl.SuspendLayout()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCristales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lqsmsCristales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaDesde.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaHasta.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'popUpFiltroContainer
        '
        Me.popUpFiltroContainer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.popUpFiltroContainer.Size = New System.Drawing.Size(469, 143)
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.txtFechaHasta)
        Me.LayoutControl.Controls.Add(Me.txtFechaDesde)
        Me.LayoutControl.Controls.Add(Me.chkCristales)
        Me.LayoutControl.Controls.Add(Me.btnCargarDatos)
        Me.LayoutControl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl.OptionsSerialization.DiscardOldItems = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl.Size = New System.Drawing.Size(465, 139)
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlGroup1})
        Me.LayoutControlGroup.OptionsItemText.TextToControlDistance = 5
        Me.LayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3)
        Me.LayoutControlGroup.Size = New System.Drawing.Size(465, 139)
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
        'PanelControl
        '
        Me.PanelControl.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl.Appearance.Options.UseBackColor = True
        Me.PanelControl.Location = New System.Drawing.Point(0, 139)
        Me.PanelControl.Size = New System.Drawing.Size(867, 283)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'btnCargarDatos
        '
        Me.btnCargarDatos.Image = Global.Studio.Vision.Controls.My.Resources.Resources.Query32
        Me.btnCargarDatos.Location = New System.Drawing.Point(5, 78)
        Me.btnCargarDatos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCargarDatos.Name = "btnCargarDatos"
        Me.btnCargarDatos.Size = New System.Drawing.Size(455, 56)
        Me.btnCargarDatos.StyleController = Me.LayoutControl
        Me.btnCargarDatos.TabIndex = 6
        Me.btnCargarDatos.Text = "Cargar datos"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnCargarDatos
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 73)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(97, 27)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(459, 60)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'chkCristales
        '
        Me.chkCristales.Location = New System.Drawing.Point(118, 54)
        Me.chkCristales.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkCristales.MenuManager = Me.RibbonControl1
        Me.chkCristales.Name = "chkCristales"
        Me.chkCristales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.chkCristales.Properties.DataSource = Me.lqsmsCristales
        Me.chkCristales.Properties.DisplayMember = "Descripcion"
        Me.chkCristales.Properties.ValueMember = "Id"
        Me.chkCristales.Size = New System.Drawing.Size(342, 20)
        Me.chkCristales.StyleController = Me.LayoutControl
        Me.chkCristales.TabIndex = 7
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.chkCristales
        Me.LayoutControlItem4.CustomizationFormText = "Seleccione los cristales"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 49)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(459, 24)
        Me.LayoutControlItem4.Text = "Seleccione los cristales"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(108, 13)
        '
        'txtFechaDesde
        '
        Me.txtFechaDesde.EditValue = Nothing
        Me.txtFechaDesde.Location = New System.Drawing.Point(121, 27)
        Me.txtFechaDesde.MenuManager = Me.RibbonControl1
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFechaDesde.Size = New System.Drawing.Size(109, 20)
        Me.txtFechaDesde.StyleController = Me.LayoutControl
        Me.txtFechaDesde.TabIndex = 8
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtFechaDesde
        Me.LayoutControlItem1.CustomizationFormText = "Desde"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(226, 24)
        Me.LayoutControlItem1.Text = "Desde"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(108, 13)
        '
        'txtFechaHasta
        '
        Me.txtFechaHasta.EditValue = Nothing
        Me.txtFechaHasta.Location = New System.Drawing.Point(347, 27)
        Me.txtFechaHasta.MenuManager = Me.RibbonControl1
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFechaHasta.Size = New System.Drawing.Size(110, 20)
        Me.txtFechaHasta.StyleController = Me.LayoutControl
        Me.txtFechaHasta.TabIndex = 9
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtFechaHasta
        Me.LayoutControlItem2.CustomizationFormText = "Hasta"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(226, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(227, 24)
        Me.LayoutControlItem2.Text = "Hasta"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup1.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup1.CustomizationFormText = "Periodo"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(459, 49)
        Me.LayoutControlGroup1.Text = "Periodo"
        '
        'DV_HistoricoDocumentoSalidaCristalModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_HistoricoDocumentoSalidaCristalModule"
        CType(Me.popUpFiltroContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popUpFiltroContainer.ResumeLayout(False)
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.PanelControl.ResumeLayout(False)
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCristales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lqsmsCristales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaDesde.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaHasta.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCargarDatos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkCristales As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lqsmsCristales As DevExpress.Data.Linq.LinqServerModeSource
    Friend WithEvents txtFechaHasta As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtFechaDesde As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem

End Class
