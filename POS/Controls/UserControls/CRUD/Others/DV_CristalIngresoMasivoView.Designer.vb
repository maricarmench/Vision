<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_CristalIngresoMasivoView
    Inherits Studio.Net.Controls.[New].UserControls.DataViewBase

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.cboCristalId = New Studio.Net.Controls.[New].Controls.DXSearchLookUp()
        Me.cboCristalMaterialId = New Studio.Net.Controls.[New].Controls.DxGridLookUp()
        Me.GridLookUpEdit2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtAdicion = New Studio.Net.Controls.[New].Controls.DXSpinEdit()
        Me.txtCilindrico = New Studio.Net.Controls.[New].Controls.DXSpinEdit()
        Me.txtEsferico = New Studio.Net.Controls.[New].Controls.DXSpinEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.rgrRecetaComunTipo = New DevExpress.XtraEditors.RadioGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.grdDetalle = New Studio.Net.Controls.[New].MyDXGrid()
        Me.gvDetalle = New Studio.Net.Controls.[New].MyDXGridView()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtCantidad = New Studio.Net.Controls.[New].Controls.DXSpinEdit()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnAgregar = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider()
        Me.cboBonificacionId = New Studio.Net.Controls.[New].Controls.DXSearchLookUp()
        Me.lqifsBonificacion = New DevExpress.Data.Linq.LinqInstantFeedbackSource()
        Me.DxSearchLookUp1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCristalId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCristalMaterialId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit2View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdicion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCilindrico.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEsferico.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgrRecetaComunTipo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBonificacionId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxSearchLookUp1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.cboBonificacionId)
        Me.LayoutControl.Controls.Add(Me.btnAgregar)
        Me.LayoutControl.Controls.Add(Me.txtCantidad)
        Me.LayoutControl.Controls.Add(Me.grdDetalle)
        Me.LayoutControl.Controls.Add(Me.rgrRecetaComunTipo)
        Me.LayoutControl.Controls.Add(Me.cboCristalId)
        Me.LayoutControl.Controls.Add(Me.txtAdicion)
        Me.LayoutControl.Controls.Add(Me.cboCristalMaterialId)
        Me.LayoutControl.Controls.Add(Me.txtEsferico)
        Me.LayoutControl.Controls.Add(Me.txtCilindrico)
        Me.LayoutControl.OptionsFocus.EnableAutoTabOrder = False
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl.Size = New System.Drawing.Size(624, 333)
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem25, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem9, Me.LayoutControlItem5})
        Me.LayoutControlGroup.Size = New System.Drawing.Size(624, 333)
        '
        'cboCristalId
        '
        Me.cboCristalId.BusinessToUse = Nothing
        Me.cboCristalId.Location = New System.Drawing.Point(177, 60)
        Me.cboCristalId.Name = "cboCristalId"
        Me.cboCristalId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCristalId.Properties.NullText = ""
        Me.cboCristalId.Size = New System.Drawing.Size(219, 20)
        Me.cboCristalId.StyleController = Me.LayoutControl
        Me.cboCristalId.TabIndex = 6
        '
        'cboCristalMaterialId
        '
        Me.cboCristalMaterialId.BusinessToUse = Nothing
        Me.cboCristalMaterialId.Location = New System.Drawing.Point(399, 18)
        Me.cboCristalMaterialId.Name = "cboCristalMaterialId"
        Me.cboCristalMaterialId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCristalMaterialId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "Agregar un nuevo elemento", Nothing, Nothing, True)})
        Me.cboCristalMaterialId.Properties.NullText = ""
        Me.cboCristalMaterialId.Properties.View = Me.GridLookUpEdit2View
        Me.cboCristalMaterialId.Size = New System.Drawing.Size(140, 20)
        Me.cboCristalMaterialId.StyleController = Me.LayoutControl
        Me.cboCristalMaterialId.TabIndex = 5
        '
        'GridLookUpEdit2View
        '
        Me.GridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridLookUpEdit2View.Name = "GridLookUpEdit2View"
        Me.GridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridLookUpEdit2View.OptionsView.ShowGroupPanel = False
        '
        'txtAdicion
        '
        Me.txtAdicion.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtAdicion.Location = New System.Drawing.Point(285, 20)
        Me.txtAdicion.Name = "txtAdicion"
        Me.txtAdicion.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtAdicion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtAdicion.Properties.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.txtAdicion.Properties.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtAdicion.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtAdicion.RoundToNearest = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.txtAdicion.Size = New System.Drawing.Size(50, 20)
        Me.txtAdicion.StyleController = Me.LayoutControl
        Me.txtAdicion.TabIndex = 3
        '
        'txtCilindrico
        '
        Me.txtCilindrico.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCilindrico.Location = New System.Drawing.Point(177, 20)
        Me.txtCilindrico.Name = "txtCilindrico"
        Me.txtCilindrico.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtCilindrico.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCilindrico.Properties.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.txtCilindrico.Properties.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtCilindrico.Properties.MinValue = New Decimal(New Integer() {99, 0, 0, -2147483648})
        Me.txtCilindrico.RoundToNearest = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.txtCilindrico.Size = New System.Drawing.Size(50, 20)
        Me.txtCilindrico.StyleController = Me.LayoutControl
        Me.txtCilindrico.TabIndex = 1
        '
        'txtEsferico
        '
        Me.txtEsferico.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEsferico.Location = New System.Drawing.Point(231, 20)
        Me.txtEsferico.Name = "txtEsferico"
        Me.txtEsferico.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtEsferico.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtEsferico.Properties.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.txtEsferico.Properties.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtEsferico.Properties.MinValue = New Decimal(New Integer() {99, 0, 0, -2147483648})
        Me.txtEsferico.RoundToNearest = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.txtEsferico.Size = New System.Drawing.Size(50, 20)
        Me.txtEsferico.StyleController = Me.LayoutControl
        Me.txtEsferico.TabIndex = 2
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtAdicion
        Me.LayoutControlItem1.CustomizationFormText = "Adición"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(283, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(54, 42)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(54, 42)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(54, 42)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "Adición"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(34, 13)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtEsferico
        Me.LayoutControlItem2.CustomizationFormText = "Esférico"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(229, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(60, 42)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(54, 42)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(54, 42)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Esférico"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(38, 13)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtCilindrico
        Me.LayoutControlItem3.CustomizationFormText = "Cilindrico"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(175, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(60, 42)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(54, 42)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(54, 42)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Cilindrico"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(42, 13)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboCristalMaterialId
        Me.LayoutControlItem4.CustomizationFormText = "Material"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(397, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(144, 42)
        Me.LayoutControlItem4.Text = "Material"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboCristalId
        Me.LayoutControlItem5.CustomizationFormText = "Producto"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(175, 42)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(223, 40)
        Me.LayoutControlItem5.Text = "Producto"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(82, 13)
        '
        'rgrRecetaComunTipo
        '
        Me.rgrRecetaComunTipo.Location = New System.Drawing.Point(2, 18)
        Me.rgrRecetaComunTipo.Margin = New System.Windows.Forms.Padding(0)
        Me.rgrRecetaComunTipo.Name = "rgrRecetaComunTipo"
        Me.rgrRecetaComunTipo.Properties.AllowAsyncSelection = False
        Me.rgrRecetaComunTipo.Properties.Columns = 2
        Me.rgrRecetaComunTipo.Size = New System.Drawing.Size(171, 62)
        Me.rgrRecetaComunTipo.StyleController = Me.LayoutControl
        Me.rgrRecetaComunTipo.TabIndex = 0
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.rgrRecetaComunTipo
        Me.LayoutControlItem6.CustomizationFormText = "TIPO DE RECETA"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(175, 82)
        Me.LayoutControlItem6.Text = "TIPO DE RECETA"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(82, 13)
        '
        'grdDetalle
        '
        Me.grdDetalle.DoNotAddHiddenColumns = False
        Me.grdDetalle.EnablePasteMenuItem = False
        Me.grdDetalle.EnterMoveNextRow = False
        Me.grdDetalle.Location = New System.Drawing.Point(2, 102)
        Me.grdDetalle.MainView = Me.gvDetalle
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.Size = New System.Drawing.Size(620, 229)
        Me.grdDetalle.TabIndex = 33
        Me.grdDetalle.TabStop = False
        Me.grdDetalle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDetalle})
        '
        'gvDetalle
        '
        Me.gvDetalle.BusinessEntity = Nothing
        Me.gvDetalle.GridControl = Me.grdDetalle
        Me.gvDetalle.Name = "gvDetalle"
        Me.gvDetalle.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.grdDetalle
        Me.LayoutControlItem7.CustomizationFormText = "Detalles"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 82)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(624, 251)
        Me.LayoutControlItem7.Text = "Detalles"
        Me.LayoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(38, 13)
        Me.LayoutControlItem7.TextToControlDistance = 5
        '
        'txtCantidad
        '
        Me.txtCantidad.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtCantidad.Location = New System.Drawing.Point(339, 20)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtCantidad.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCantidad.Properties.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtCantidad.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtCantidad.RoundToNearest = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.txtCantidad.Size = New System.Drawing.Size(56, 20)
        Me.txtCantidad.StyleController = Me.LayoutControl
        Me.txtCantidad.TabIndex = 4
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem8.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem8.Control = Me.txtCantidad
        Me.LayoutControlItem8.CustomizationFormText = "Cantidad"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(337, 0)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(60, 42)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(54, 42)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(60, 42)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "Cantidad"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(50, 13)
        Me.LayoutControlItem8.TextToControlDistance = 5
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Shopping_cart_add
        Me.btnAgregar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(543, 2)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(79, 78)
        Me.btnAgregar.StyleController = Me.LayoutControl
        Me.btnAgregar.TabIndex = 8
        Me.btnAgregar.Text = "Agregar"
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.btnAgregar
        Me.LayoutControlItem25.CustomizationFormText = "Agregar"
        Me.LayoutControlItem25.Location = New System.Drawing.Point(541, 0)
        Me.LayoutControlItem25.MinSize = New System.Drawing.Size(83, 26)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(83, 82)
        Me.LayoutControlItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem25.Text = "Agregar"
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem25.TextVisible = False
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'cboBonificacionId
        '
        Me.cboBonificacionId.BusinessToUse = Nothing
        Me.cboBonificacionId.Location = New System.Drawing.Point(400, 60)
        Me.cboBonificacionId.Name = "cboBonificacionId"
        Me.cboBonificacionId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboBonificacionId.Properties.DataSource = Me.lqifsBonificacion
        Me.cboBonificacionId.Properties.DisplayMember = "Descripcion"
        Me.cboBonificacionId.Properties.NullText = ""
        Me.cboBonificacionId.Properties.ValueMember = "Id"
        Me.cboBonificacionId.Properties.View = Me.DxSearchLookUp1View
        Me.cboBonificacionId.Size = New System.Drawing.Size(139, 20)
        Me.cboBonificacionId.StyleController = Me.LayoutControl
        Me.cboBonificacionId.TabIndex = 7
        '
        'lqifsBonificacion
        '
        '
        'DxSearchLookUp1View
        '
        Me.DxSearchLookUp1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.DxSearchLookUp1View.Name = "DxSearchLookUp1View"
        Me.DxSearchLookUp1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DxSearchLookUp1View.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cboBonificacionId
        Me.LayoutControlItem9.CustomizationFormText = "Bonificación"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(398, 42)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(143, 40)
        Me.LayoutControlItem9.Text = "Bonificación"
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(82, 13)
        '
        'DV_CristalIngresoMasivoView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_CristalIngresoMasivoView"
        Me.Size = New System.Drawing.Size(624, 333)
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCristalId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCristalMaterialId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit2View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdicion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCilindrico.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEsferico.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgrRecetaComunTipo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBonificacionId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxSearchLookUp1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents cboCristalId As Studio.Net.Controls.New.Controls.DXSearchLookUp
    Protected Friend WithEvents txtAdicion As Studio.Net.Controls.New.Controls.DXSpinEdit
    Protected Friend WithEvents cboCristalMaterialId As Studio.Net.Controls.New.Controls.DxGridLookUp
    Protected Friend WithEvents GridLookUpEdit2View As DevExpress.XtraGrid.Views.Grid.GridView
    Protected Friend WithEvents txtEsferico As Studio.Net.Controls.New.Controls.DXSpinEdit
    Protected Friend WithEvents txtCilindrico As Studio.Net.Controls.New.Controls.DXSpinEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grdDetalle As Studio.Net.Controls.New.MyDXGrid
    Protected Friend WithEvents rgrRecetaComunTipo As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Protected Friend WithEvents txtCantidad As Studio.Net.Controls.New.Controls.DXSpinEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnAgregar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gvDetalle As Studio.Net.Controls.New.MyDXGridView
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents cboBonificacionId As Studio.Net.Controls.New.Controls.DXSearchLookUp
    Friend WithEvents DxSearchLookUp1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lqifsBonificacion As DevExpress.Data.Linq.LinqInstantFeedbackSource

End Class
