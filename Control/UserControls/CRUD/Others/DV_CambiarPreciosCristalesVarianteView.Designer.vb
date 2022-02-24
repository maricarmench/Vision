<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_CambiarPreciosCristalesVarianteView
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cboListaPreVtaId = New Studio.Net.Controls.[New].Controls.DxGridLookUp()
        Me.lqsmsListaPreVenta = New DevExpress.Data.Linq.LinqServerModeSource()
        Me.DxGridLookUp1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.cboArticuloId = New Studio.Net.Controls.[New].Controls.DXSearchLookUp()
        Me.lqifsArticulo = New DevExpress.Data.Linq.LinqInstantFeedbackSource()
        Me.DxSearchLookUp1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.cboMonedaId = New Studio.Net.Controls.[New].Controls.DxGridLookUp()
        Me.lqsmsMoneda = New DevExpress.Data.Linq.LinqServerModeSource()
        Me.DxGridLookUp2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnCargar = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.matrixView = New Studio.Vision.Controls.CristalMatrixView()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboListaPreVtaId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lqsmsListaPreVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboArticuloId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxSearchLookUp1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMonedaId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lqsmsMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxGridLookUp2View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.btnGuardar)
        Me.LayoutControl.Controls.Add(Me.matrixView)
        Me.LayoutControl.Controls.Add(Me.btnCargar)
        Me.LayoutControl.Controls.Add(Me.cboMonedaId)
        Me.LayoutControl.Controls.Add(Me.cboArticuloId)
        Me.LayoutControl.Controls.Add(Me.cboListaPreVtaId)
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl.Size = New System.Drawing.Size(701, 344)
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.EmptySpaceItem1})
        Me.LayoutControlGroup.OptionsItemText.TextToControlDistance = 5
        Me.LayoutControlGroup.Size = New System.Drawing.Size(701, 344)
        '
        'cboListaPreVtaId
        '
        Me.cboListaPreVtaId.BusinessToUse = Nothing
        Me.cboListaPreVtaId.Location = New System.Drawing.Point(81, 47)
        Me.cboListaPreVtaId.Name = "cboListaPreVtaId"
        Me.cboListaPreVtaId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboListaPreVtaId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboListaPreVtaId.Properties.DataSource = Me.lqsmsListaPreVenta
        Me.cboListaPreVtaId.Properties.DisplayMember = "Descripcion"
        Me.cboListaPreVtaId.Properties.NullText = ""
        Me.cboListaPreVtaId.Properties.ValueMember = "Id"
        Me.cboListaPreVtaId.Properties.View = Me.DxGridLookUp1View
        Me.cboListaPreVtaId.Size = New System.Drawing.Size(618, 20)
        Me.cboListaPreVtaId.StyleController = Me.LayoutControl
        Me.cboListaPreVtaId.TabIndex = 4
        '
        'DxGridLookUp1View
        '
        Me.DxGridLookUp1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.DxGridLookUp1View.Name = "DxGridLookUp1View"
        Me.DxGridLookUp1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DxGridLookUp1View.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cboListaPreVtaId
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 45)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(701, 24)
        Me.LayoutControlItem1.Text = "Lista de precios"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(74, 13)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'cboArticuloId
        '
        Me.cboArticuloId.BusinessToUse = Nothing
        Me.cboArticuloId.Location = New System.Drawing.Point(81, 95)
        Me.cboArticuloId.Name = "cboArticuloId"
        Me.cboArticuloId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboArticuloId.Properties.DataSource = Me.lqifsArticulo
        Me.cboArticuloId.Properties.DisplayMember = "Descripcion"
        Me.cboArticuloId.Properties.NullText = ""
        Me.cboArticuloId.Properties.ValueMember = "Id"
        Me.cboArticuloId.Properties.View = Me.DxSearchLookUp1View
        Me.cboArticuloId.Size = New System.Drawing.Size(618, 20)
        Me.cboArticuloId.StyleController = Me.LayoutControl
        Me.cboArticuloId.TabIndex = 5
        '
        'lqifsArticulo
        '
        '
        'DxSearchLookUp1View
        '
        Me.DxSearchLookUp1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.DxSearchLookUp1View.Name = "DxSearchLookUp1View"
        Me.DxSearchLookUp1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DxSearchLookUp1View.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboArticuloId
        Me.LayoutControlItem2.CustomizationFormText = "Cristal"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 93)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(701, 24)
        Me.LayoutControlItem2.Text = "Cristal"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(74, 13)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'cboMonedaId
        '
        Me.cboMonedaId.BusinessToUse = Nothing
        Me.cboMonedaId.Location = New System.Drawing.Point(81, 71)
        Me.cboMonedaId.Name = "cboMonedaId"
        Me.cboMonedaId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboMonedaId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboMonedaId.Properties.DataSource = Me.lqsmsMoneda
        Me.cboMonedaId.Properties.DisplayMember = "Descripcion"
        Me.cboMonedaId.Properties.NullText = ""
        Me.cboMonedaId.Properties.ValueMember = "Id"
        Me.cboMonedaId.Properties.View = Me.DxGridLookUp2View
        Me.cboMonedaId.Size = New System.Drawing.Size(618, 20)
        Me.cboMonedaId.StyleController = Me.LayoutControl
        Me.cboMonedaId.TabIndex = 6
        '
        'DxGridLookUp2View
        '
        Me.DxGridLookUp2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.DxGridLookUp2View.Name = "DxGridLookUp2View"
        Me.DxGridLookUp2View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DxGridLookUp2View.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboMonedaId
        Me.LayoutControlItem3.CustomizationFormText = "Moneda"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 69)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(701, 24)
        Me.LayoutControlItem3.Text = "Moneda"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(74, 13)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'btnCargar
        '
        Me.btnCargar.Image = Global.Studio.Vision.Controls.My.Resources.Resources.Commands_Icon
        Me.btnCargar.Location = New System.Drawing.Point(2, 119)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(697, 30)
        Me.btnCargar.StyleController = Me.LayoutControl
        Me.btnCargar.TabIndex = 7
        Me.btnCargar.Text = "Cargar planilla"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnCargar
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 117)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(701, 34)
        Me.LayoutControlItem4.Text = "LayoutControlItem4"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextToControlDistance = 0
        Me.LayoutControlItem4.TextVisible = False
        '
        'matrixView
        '
        Me.matrixView.AllowAdd = False
        Me.matrixView.AllowDelete = False
        Me.matrixView.AllowEdit = False
        Me.matrixView.ArticuloDescripcionName = "Descripcion"
        Me.matrixView.ArticuloIDName = "Id"
        Me.matrixView.Caption = Nothing
        Me.matrixView.Enabled = False
        Me.matrixView.Icon = Nothing
        Me.matrixView.Location = New System.Drawing.Point(2, 153)
        Me.matrixView.Name = "matrixView"
        Me.matrixView.ReadOnlyMode = False
        Me.matrixView.Size = New System.Drawing.Size(697, 147)
        Me.matrixView.TabIndex = 8
        Me.matrixView.ValorFormat = "{0:n0}"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.matrixView
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 151)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(701, 151)
        Me.LayoutControlItem5.Text = "LayoutControlItem5"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.Studio.Vision.Controls.My.Resources.Resources.Action_Save_32x32
        Me.btnGuardar.Location = New System.Drawing.Point(2, 304)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(697, 38)
        Me.btnGuardar.StyleController = Me.LayoutControl
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "Guardar datos"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnGuardar
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 302)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(701, 42)
        Me.LayoutControlItem6.Text = "LayoutControlItem6"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextToControlDistance = 0
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.AppearanceItemCaption.Options.UseTextOptions = True
        Me.EmptySpaceItem1.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.EmptySpaceItem1.CustomizationFormText = "Seleccione todos los datos requeridos y presione el botón Cargar planilla para cr" & _
    "ear o cambiar los precios. Para confirmar los cambios presione el botón Guardar " & _
    "datos"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.MaxSize = New System.Drawing.Size(0, 45)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(10, 45)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(701, 45)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.Text = "Seleccione todos los datos requeridos y presione el botón Cargar planilla para cr" & _
    "ear o cambiar los precios. Para confirmar los cambios presione el botón Guardar " & _
    "datos."
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(74, 0)
        Me.EmptySpaceItem1.TextVisible = True
        '
        'DV_CambiarPreciosCristalesVarianteView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_CambiarPreciosCristalesVarianteView"
        Me.Size = New System.Drawing.Size(701, 344)
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboListaPreVtaId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lqsmsListaPreVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboArticuloId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxSearchLookUp1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMonedaId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lqsmsMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxGridLookUp2View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboListaPreVtaId As Studio.Net.Controls.New.Controls.DxGridLookUp
    Friend WithEvents DxGridLookUp1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents matrixView As Studio.Vision.Controls.CristalMatrixView
    Friend WithEvents btnCargar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboMonedaId As Studio.Net.Controls.New.Controls.DxGridLookUp
    Friend WithEvents DxGridLookUp2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboArticuloId As Studio.Net.Controls.New.Controls.DXSearchLookUp
    Friend WithEvents DxSearchLookUp1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lqsmsListaPreVenta As DevExpress.Data.Linq.LinqServerModeSource
    Friend WithEvents lqsmsMoneda As DevExpress.Data.Linq.LinqServerModeSource
    Friend WithEvents lqifsArticulo As DevExpress.Data.Linq.LinqInstantFeedbackSource
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem

End Class
