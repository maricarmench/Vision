<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_VentaListViewModule
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
        Me.bbiNewVenta = New DevExpress.XtraBars.BarButtonItem()
        Me.pmNewVenta = New DevExpress.XtraBars.PopupMenu()
        Me.bbiNewRecetaComun = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiNewRecetaLenteContacto = New DevExpress.XtraBars.BarButtonItem()
        Me.pnlBuscar = New DevExpress.XtraEditors.PanelControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtNroDocumento = New DevExpress.XtraEditors.TextEdit()
        Me.btnBuscar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCedulaRUT = New DevExpress.XtraEditors.TextEdit()
        Me.cboClienteId = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.LinqInstantFeedbackSource1 = New DevExpress.Data.Linq.LinqInstantFeedbackSource()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtFDesde = New DevExpress.XtraEditors.DateEdit()
        Me.txtFHasta = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciBuscar = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.bbiBuscar = New DevExpress.XtraBars.BarButtonItem()
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
        CType(Me.pmNewVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBuscar.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtNroDocumento.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedulaRUT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboClienteId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFDesde.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFHasta.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bbiAdd
        '
        Me.bbiAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbiDelete
        '
        Me.bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'rpgRecordManager
        '
        Me.rpgRecordManager.ItemLinks.Add(Me.bbiNewVenta)
        '
        'ritxtCurrentPage
        '
        Me.ritxtCurrentPage.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        '
        'beiSearch
        '
        Me.beiSearch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'rpgFind
        '
        Me.rpgFind.ItemLinks.Add(Me.bbiBuscar)
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.ExpandCollapseItem.Name = ""
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiNewVenta, Me.bbiNewRecetaComun, Me.bbiNewRecetaLenteContacto, Me.bbiBuscar})
        '
        'PanelControl
        '
        Me.PanelControl.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl.Appearance.Options.UseBackColor = True
        Me.PanelControl.Location = New System.Drawing.Point(0, 103)
        Me.PanelControl.Size = New System.Drawing.Size(867, 319)
        '
        'bbiNewVenta
        '
        Me.bbiNewVenta.ActAsDropDown = True
        Me.bbiNewVenta.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.bbiNewVenta.Caption = "Nueva venta"
        Me.bbiNewVenta.DropDownControl = Me.pmNewVenta
        Me.bbiNewVenta.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_New
        Me.bbiNewVenta.Id = 45
        Me.bbiNewVenta.LargeGlyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_New_32x32
        Me.bbiNewVenta.Name = "bbiNewVenta"
        '
        'pmNewVenta
        '
        Me.pmNewVenta.ItemLinks.Add(Me.bbiNewRecetaComun)
        Me.pmNewVenta.ItemLinks.Add(Me.bbiNewRecetaLenteContacto)
        Me.pmNewVenta.Name = "pmNewVenta"
        Me.pmNewVenta.Ribbon = Me.RibbonControl1
        '
        'bbiNewRecetaComun
        '
        Me.bbiNewRecetaComun.Caption = "Receta lentes de armazón"
        Me.bbiNewRecetaComun.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Rx_32x32
        Me.bbiNewRecetaComun.Id = 46
        Me.bbiNewRecetaComun.LargeGlyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Rx_32x32
        Me.bbiNewRecetaComun.Name = "bbiNewRecetaComun"
        '
        'bbiNewRecetaLenteContacto
        '
        Me.bbiNewRecetaLenteContacto.Caption = "Receta lentes de contacto"
        Me.bbiNewRecetaLenteContacto.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Contact_Lens1
        Me.bbiNewRecetaLenteContacto.Id = 47
        Me.bbiNewRecetaLenteContacto.LargeGlyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Contact_Lens1
        Me.bbiNewRecetaLenteContacto.Name = "bbiNewRecetaLenteContacto"
        '
        'pnlBuscar
        '
        Me.pnlBuscar.Controls.Add(Me.LayoutControl1)
        Me.pnlBuscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBuscar.Location = New System.Drawing.Point(0, 47)
        Me.pnlBuscar.Name = "pnlBuscar"
        Me.pnlBuscar.Size = New System.Drawing.Size(867, 56)
        Me.pnlBuscar.TabIndex = 3
        Me.pnlBuscar.Visible = False
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtNroDocumento)
        Me.LayoutControl1.Controls.Add(Me.btnBuscar)
        Me.LayoutControl1.Controls.Add(Me.txtCedulaRUT)
        Me.LayoutControl1.Controls.Add(Me.cboClienteId)
        Me.LayoutControl1.Controls.Add(Me.txtFDesde)
        Me.LayoutControl1.Controls.Add(Me.txtFHasta)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(417, 373, 250, 350)
        Me.LayoutControl1.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(863, 52)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtNroDocumento
        '
        Me.txtNroDocumento.Location = New System.Drawing.Point(428, 26)
        Me.txtNroDocumento.MenuManager = Me.RibbonControl1
        Me.txtNroDocumento.Name = "txtNroDocumento"
        Me.txtNroDocumento.Size = New System.Drawing.Size(131, 20)
        Me.txtNroDocumento.StyleController = Me.LayoutControl1
        Me.txtNroDocumento.TabIndex = 9
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_Search_32x32
        Me.btnBuscar.Location = New System.Drawing.Point(780, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(81, 48)
        Me.btnBuscar.StyleController = Me.LayoutControl1
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "Buscar"
        '
        'txtCedulaRUT
        '
        Me.txtCedulaRUT.Location = New System.Drawing.Point(513, 2)
        Me.txtCedulaRUT.MenuManager = Me.RibbonControl1
        Me.txtCedulaRUT.Name = "txtCedulaRUT"
        Me.txtCedulaRUT.Size = New System.Drawing.Size(263, 20)
        Me.txtCedulaRUT.StyleController = Me.LayoutControl1
        Me.txtCedulaRUT.TabIndex = 5
        '
        'cboClienteId
        '
        Me.cboClienteId.Location = New System.Drawing.Point(83, 2)
        Me.cboClienteId.MenuManager = Me.RibbonControl1
        Me.cboClienteId.Name = "cboClienteId"
        Me.cboClienteId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboClienteId.Properties.DataSource = Me.LinqInstantFeedbackSource1
        Me.cboClienteId.Properties.DisplayMember = "Descripcion"
        Me.cboClienteId.Properties.NullText = ""
        Me.cboClienteId.Properties.ValueMember = "Id"
        Me.cboClienteId.Properties.View = Me.SearchLookUpEdit1View
        Me.cboClienteId.Size = New System.Drawing.Size(345, 20)
        Me.cboClienteId.StyleController = Me.LayoutControl1
        Me.cboClienteId.TabIndex = 4
        '
        'LinqInstantFeedbackSource1
        '
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'txtFDesde
        '
        Me.txtFDesde.EditValue = Nothing
        Me.txtFDesde.Location = New System.Drawing.Point(83, 26)
        Me.txtFDesde.MenuManager = Me.RibbonControl1
        Me.txtFDesde.Name = "txtFDesde"
        Me.txtFDesde.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFDesde.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.txtFDesde.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFDesde.Size = New System.Drawing.Size(111, 20)
        Me.txtFDesde.StyleController = Me.LayoutControl1
        Me.txtFDesde.TabIndex = 7
        '
        'txtFHasta
        '
        Me.txtFHasta.EditValue = Nothing
        Me.txtFHasta.Location = New System.Drawing.Point(212, 26)
        Me.txtFHasta.MenuManager = Me.RibbonControl1
        Me.txtFHasta.Name = "txtFHasta"
        Me.txtFHasta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFHasta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.txtFHasta.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFHasta.Size = New System.Drawing.Size(131, 20)
        Me.txtFHasta.StyleController = Me.LayoutControl1
        Me.txtFHasta.TabIndex = 8
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.lciBuscar, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.EmptySpaceItem2, Me.EmptySpaceItem1, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(863, 52)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cboClienteId
        Me.LayoutControlItem1.CustomizationFormText = "Cliente:"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(430, 24)
        Me.LayoutControlItem1.Text = "Cliente:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtCedulaRUT
        Me.LayoutControlItem2.CustomizationFormText = "Cédula / RUT"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(430, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(348, 24)
        Me.LayoutControlItem2.Text = "Cédula / RUT"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(77, 13)
        '
        'lciBuscar
        '
        Me.lciBuscar.Control = Me.btnBuscar
        Me.lciBuscar.CustomizationFormText = "Buscar"
        Me.lciBuscar.Location = New System.Drawing.Point(778, 0)
        Me.lciBuscar.MinSize = New System.Drawing.Size(83, 26)
        Me.lciBuscar.Name = "lciBuscar"
        Me.lciBuscar.Size = New System.Drawing.Size(85, 52)
        Me.lciBuscar.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.lciBuscar.Text = "Buscar"
        Me.lciBuscar.TextSize = New System.Drawing.Size(0, 0)
        Me.lciBuscar.TextToControlDistance = 0
        Me.lciBuscar.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtFHasta
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(210, 24)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(50, 25)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(135, 28)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "LayoutControlItem4"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextToControlDistance = 0
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtFDesde
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(196, 28)
        Me.LayoutControlItem3.Text = "Periodo"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(77, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(196, 24)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(14, 0)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(14, 10)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(14, 28)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.Text = "EmptySpaceItem2"
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(561, 24)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(217, 28)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtNroDocumento
        Me.LayoutControlItem5.CustomizationFormText = "Nro. documento"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(345, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(216, 28)
        Me.LayoutControlItem5.Text = "Nro. documento"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(77, 13)
        '
        'bbiBuscar
        '
        Me.bbiBuscar.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.bbiBuscar.Caption = "Buscar..."
        Me.bbiBuscar.Description = "Muestra la opciones de búsqueda"
        Me.bbiBuscar.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_Search
        Me.bbiBuscar.Id = 48
        Me.bbiBuscar.LargeGlyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_Search_32x32
        Me.bbiBuscar.Name = "bbiBuscar"
        '
        'DV_VentaListViewModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlBuscar)
        Me.Name = "DV_VentaListViewModule"
        Me.Controls.SetChildIndex(Me.RibbonControl1, 0)
        Me.Controls.SetChildIndex(Me.RibbonStatusBar1, 0)
        Me.Controls.SetChildIndex(Me.pnlBuscar, 0)
        Me.Controls.SetChildIndex(Me.PanelControl, 0)
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
        CType(Me.pmNewVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBuscar.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtNroDocumento.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedulaRUT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboClienteId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFDesde.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFHasta.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bbiNewVenta As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiNewRecetaComun As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiNewRecetaLenteContacto As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pmNewVenta As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiBuscar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlBuscar As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnBuscar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCedulaRUT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboClienteId As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciBuscar As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LinqInstantFeedbackSource1 As DevExpress.Data.Linq.LinqInstantFeedbackSource
    Friend WithEvents txtFDesde As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtFHasta As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtNroDocumento As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem

End Class
