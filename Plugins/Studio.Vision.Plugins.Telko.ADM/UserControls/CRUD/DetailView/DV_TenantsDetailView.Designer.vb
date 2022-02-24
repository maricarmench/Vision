<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_TenantsDetailView
    Inherits Studio.Phone.Controls.[New].DrakoDetailView

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
    'It can be modified using the Windows Form Designer.. 
    'Do not modify it using the code editor..
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtId = New DevExpress.XtraEditors.TextEdit()
        Me.txtNombre = New DevExpress.XtraEditors.TextEdit()
        Me.txtFechaModificado = New DevExpress.XtraEditors.TextEdit()
        Me.txtUsrModificador = New DevExpress.XtraEditors.TextEdit()
        Me.txtFechaCreado = New DevExpress.XtraEditors.TextEdit()
        Me.txtUsrCreador = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ListViewModuleContainer1 = New Studio.Net.Controls.[New].ListViewModuleContainer()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()

        Me.cboIdProveedorDrako = New DevExpress.XtraEditors.ComboBoxEdit()
        ''Me.cboIdProveedorDrako = New Studio.Net.Controls.[New].Controls.DxGridLookUp()
        ''Me.DxGridLookUp1View = New DevExpress.XtraGrid.Views.Grid.GridView()

        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtRUT = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.chkActivo = New DevExpress.XtraEditors.CheckEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaModificado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsrModificador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaCreado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsrCreador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()

        CType(Me.cboIdProveedorDrako.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        ''CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).BeginInit()

        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRUT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkActivo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.ListViewModuleContainer1)
        Me.LayoutControl.Controls.Add(Me.txtFechaModificado)
        Me.LayoutControl.Controls.Add(Me.txtNombre)
        Me.LayoutControl.Controls.Add(Me.txtUsrModificador)
        Me.LayoutControl.Controls.Add(Me.txtId)
        Me.LayoutControl.Controls.Add(Me.txtFechaCreado)
        Me.LayoutControl.Controls.Add(Me.txtUsrCreador)
        Me.LayoutControl.Controls.Add(Me.cboIdProveedorDrako)
        Me.LayoutControl.Controls.Add(Me.txtRUT)
        Me.LayoutControl.Controls.Add(Me.chkActivo)
        Me.LayoutControl.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(552, 268, 765, 575)
        Me.LayoutControl.OptionsCustomizationForm.ShowLoadButton = False
        Me.LayoutControl.OptionsCustomizationForm.ShowPropertyGrid = True
        Me.LayoutControl.OptionsCustomizationForm.ShowSaveButton = False
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl.Size = New System.Drawing.Size(748, 400)
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabbedControlGroup1})
        Me.LayoutControlGroup.Name = "Root"
        Me.LayoutControlGroup.OptionsItemText.TextToControlDistance = 5
        Me.LayoutControlGroup.Size = New System.Drawing.Size(748, 400)
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(121, 36)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(613, 20)
        Me.txtId.StyleController = Me.LayoutControl
        Me.txtId.TabIndex = 4
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(121, 60)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(613, 20)
        Me.txtNombre.StyleController = Me.LayoutControl
        Me.txtNombre.TabIndex = 5
        '
        'txtFechaModificado
        '
        Me.txtFechaModificado.Location = New System.Drawing.Point(115, 108)
        Me.txtFechaModificado.Name = "txtFechaModificado"
        Me.txtFechaModificado.Size = New System.Drawing.Size(619, 20)
        Me.txtFechaModificado.StyleController = Me.LayoutControl
        Me.txtFechaModificado.TabIndex = 20
        '
        'txtUsrModificador
        '
        Me.txtUsrModificador.Location = New System.Drawing.Point(115, 84)
        Me.txtUsrModificador.Name = "txtUsrModificador"
        Me.txtUsrModificador.Size = New System.Drawing.Size(619, 20)
        Me.txtUsrModificador.StyleController = Me.LayoutControl
        Me.txtUsrModificador.TabIndex = 19
        '
        'txtFechaCreado
        '
        Me.txtFechaCreado.Location = New System.Drawing.Point(115, 60)
        Me.txtFechaCreado.Name = "txtFechaCreado"
        Me.txtFechaCreado.Size = New System.Drawing.Size(619, 20)
        Me.txtFechaCreado.StyleController = Me.LayoutControl
        Me.txtFechaCreado.TabIndex = 18
        '
        'txtUsrCreador
        '
        Me.txtUsrCreador.Location = New System.Drawing.Point(115, 36)
        Me.txtUsrCreador.Name = "txtUsrCreador"
        Me.txtUsrCreador.Size = New System.Drawing.Size(619, 20)
        Me.txtUsrCreador.StyleController = Me.LayoutControl
        Me.txtUsrCreador.TabIndex = 17
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtUsrCreador
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtFechaCreado
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtUsrModificador
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtFechaModificado
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(724, 282)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(96, 13)
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.CustomizationFormText = "TabbedControlGroup1"
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup1
        Me.TabbedControlGroup1.SelectedTabPageIndex = 0
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(748, 400)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1})
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Datos Generales"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(724, 354)
        Me.LayoutControlGroup1.Text = "Datos Generales"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtNombre
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtId
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.ListViewModuleContainer1
        Me.LayoutControlItem7.CustomizationFormText = "SubTenants"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 119)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(724, 235)
        Me.LayoutControlItem7.Text = "SubTenants"
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'ListViewModuleContainer1
        '
        Me.ListViewModuleContainer1.CurrentEntity = Nothing
        Me.ListViewModuleContainer1.Location = New System.Drawing.Point(14, 155)
        Me.ListViewModuleContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListViewModuleContainer1.Name = "ListViewModuleContainer1"
        Me.ListViewModuleContainer1.Size = New System.Drawing.Size(720, 231)
        Me.ListViewModuleContainer1.TabIndex = 21
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cboIdProveedorDrako
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(102, 13)
        '
        'cboIdProveedorDrako
        '
        Me.cboIdProveedorDrako.Location = New System.Drawing.Point(121, 84)
        Me.cboIdProveedorDrako.Name = "cboIdProveedorDrako"
        Me.cboIdProveedorDrako.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboIdProveedorDrako.Size = New System.Drawing.Size(613, 20)
        Me.cboIdProveedorDrako.StyleController = Me.LayoutControl
        Me.cboIdProveedorDrako.TabIndex = 22
        ''Me.cboIdProveedorDrako.BusinessToUse = Nothing
        ''Me.cboIdProveedorDrako.Location = New System.Drawing.Point(121, 84)
        ''Me.cboIdProveedorDrako.Name = "cboIdProveedorDrako"
        ''Me.cboIdProveedorDrako.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        ''Me.cboIdProveedorDrako.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        ''Me.cboIdProveedorDrako.Properties.View = Me.DxGridLookUp1View
        ''Me.cboIdProveedorDrako.Size = New System.Drawing.Size(613, 20)
        ''Me.cboIdProveedorDrako.StyleController = Me.LayoutControl
        ''Me.cboIdProveedorDrako.TabIndex = 22
        '
        'DxGridLookUp1View
        '
        ''Me.DxGridLookUp1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        ''Me.DxGridLookUp1View.Name = "DxGridLookUp1View"
        ''Me.DxGridLookUp1View.OptionsSelection.EnableAppearanceFocusedCell = False
        ''Me.DxGridLookUp1View.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtRUT
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(102, 13)
        '
        'txtRUT
        '
        Me.txtRUT.Location = New System.Drawing.Point(121, 108)
        Me.txtRUT.Name = "txtRUT"
        Me.txtRUT.Size = New System.Drawing.Size(613, 20)
        Me.txtRUT.StyleController = Me.LayoutControl
        Me.txtRUT.TabIndex = 23
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.chkActivo
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(724, 23)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(102, 13)
        '
        'chkActivo
        '
        Me.chkActivo.Location = New System.Drawing.Point(121, 132)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Properties.Caption = "CheckEdit1"
        Me.chkActivo.Size = New System.Drawing.Size(613, 19)
        Me.chkActivo.StyleController = Me.LayoutControl
        Me.chkActivo.TabIndex = 24
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Auditoría"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.OptionsItemText.TextToControlDistance = 5
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(724, 354)
        Me.LayoutControlGroup2.Text = "Auditoría"
        '
        'DV_TenantsDetailView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_TenantsDetailView"
        Me.Size = New System.Drawing.Size(748, 400)
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaModificado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsrModificador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaCreado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsrCreador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()

        CType(Me.cboIdProveedorDrako.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        ''CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).EndInit()

        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRUT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkActivo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtId As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFechaModificado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUsrModificador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFechaCreado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUsrCreador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ListViewModuleContainer1 As Studio.Net.Controls.New.ListViewModuleContainer
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem

    Friend WithEvents cboIdProveedorDrako As DevExpress.XtraEditors.ComboBoxEdit
    ''Friend WithEvents cboIdProveedorDrako As Studio.Net.Controls.New.Controls.DxGridLookUp
    ''Friend WithEvents DxGridLookUp1View As DevExpress.XtraGrid.Views.Grid.GridView

    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRUT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkActivo As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
End Class
