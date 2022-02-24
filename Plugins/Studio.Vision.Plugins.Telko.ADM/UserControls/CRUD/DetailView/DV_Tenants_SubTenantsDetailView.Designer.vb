<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_Tenants_SubTenantsDetailView
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
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor..
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtId = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.cboTenantId = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()

        ''Me.cboClienteId = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboClienteId = New Studio.Net.Controls.[New].Controls.DxGridLookUp()
        Me.DxGridLookUp1View = New DevExpress.XtraGrid.Views.Grid.GridView()

        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtDescripcion = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtLocalIdDestino = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.chkActivo = New DevExpress.XtraEditors.CheckEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtUsrCreador = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtFechaCreado = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtUsrModificador = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtFechaModificado = New DevExpress.XtraEditors.TextEdit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTenantId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()

        CType(Me.cboClienteId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).BeginInit()

        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocalIdDestino.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkActivo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsrCreador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaCreado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsrModificador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaModificado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.txtFechaModificado)
        Me.LayoutControl.Controls.Add(Me.txtUsrModificador)
        Me.LayoutControl.Controls.Add(Me.txtFechaCreado)
        Me.LayoutControl.Controls.Add(Me.txtUsrCreador)
        Me.LayoutControl.Controls.Add(Me.txtId)
        Me.LayoutControl.Controls.Add(Me.cboTenantId)
        Me.LayoutControl.Controls.Add(Me.cboClienteId)
        Me.LayoutControl.Controls.Add(Me.txtDescripcion)
        Me.LayoutControl.Controls.Add(Me.txtLocalIdDestino)
        Me.LayoutControl.Controls.Add(Me.chkActivo)
        Me.LayoutControl.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(552, 268, 250, 350)
        Me.LayoutControl.OptionsCustomizationForm.ShowLoadButton = False
        Me.LayoutControl.OptionsCustomizationForm.ShowPropertyGrid = True
        Me.LayoutControl.OptionsCustomizationForm.ShowSaveButton = False
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabbedControlGroup1})
        Me.LayoutControlGroup.OptionsItemText.TextToControlDistance = 5
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.CustomizationFormText = "TabbedControlGroup1"
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup1
        Me.TabbedControlGroup1.SelectedTabPageIndex = 0
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(748, 433)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1})
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Datos Generales"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem9, Me.LayoutControlItem10})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(724, 387)
        Me.LayoutControlGroup1.Text = "Datos Generales"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtId
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(102, 13)
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(121, 36)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(613, 20)
        Me.txtId.StyleController = Me.LayoutControl
        Me.txtId.TabIndex = 28
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboTenantId
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(102, 13)
        '
        'cboTenantId
        '
        Me.cboTenantId.Location = New System.Drawing.Point(121, 60)
        Me.cboTenantId.Name = "cboTenantId"
        Me.cboTenantId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTenantId.Size = New System.Drawing.Size(613, 20)
        Me.cboTenantId.StyleController = Me.LayoutControl
        Me.cboTenantId.TabIndex = 29
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboClienteId
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(102, 13)
        '
        'cboClienteId
        '
        ''Me.cboClienteId.Location = New System.Drawing.Point(121, 84)
        ''Me.cboClienteId.Name = "cboClienteId"
        ''Me.cboClienteId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        ''Me.cboClienteId.Size = New System.Drawing.Size(613, 20)
        ''Me.cboClienteId.StyleController = Me.LayoutControl
        ''Me.cboClienteId.TabIndex = 30
        Me.cboClienteId.BusinessToUse = Nothing
        Me.cboClienteId.Location = New System.Drawing.Point(121, 84)
        Me.cboClienteId.Name = "cboClienteId"
        Me.cboClienteId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboClienteId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboClienteId.Properties.View = Me.DxGridLookUp1View
        Me.cboClienteId.Size = New System.Drawing.Size(613, 20)
        Me.cboClienteId.StyleController = Me.LayoutControl
        Me.cboClienteId.TabIndex = 30
        '
        'DxGridLookUp1View
        '
        Me.DxGridLookUp1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.DxGridLookUp1View.Name = "DxGridLookUp1View"
        Me.DxGridLookUp1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DxGridLookUp1View.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtDescripcion
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(102, 13)
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(121, 108)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(613, 20)
        Me.txtDescripcion.StyleController = Me.LayoutControl
        Me.txtDescripcion.TabIndex = 31
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtLocalIdDestino
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(102, 13)
        '
        'txtLocalIdDestino
        '
        Me.txtLocalIdDestino.Location = New System.Drawing.Point(121, 132)
        Me.txtLocalIdDestino.Name = "txtLocalIdDestino"
        Me.txtLocalIdDestino.Size = New System.Drawing.Size(613, 20)
        Me.txtLocalIdDestino.StyleController = Me.LayoutControl
        Me.txtLocalIdDestino.TabIndex = 32
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.chkActivo
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(724, 267)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(102, 13)
        '
        'chkActivo
        '
        Me.chkActivo.Location = New System.Drawing.Point(121, 156)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Properties.Caption = "CheckEdit1"
        Me.chkActivo.Size = New System.Drawing.Size(613, 19)
        Me.chkActivo.StyleController = Me.LayoutControl
        Me.chkActivo.TabIndex = 33
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Auditoría"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.OptionsItemText.TextToControlDistance = 5
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(724, 387)
        Me.LayoutControlGroup2.Text = "Auditoría"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtUsrCreador
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(96, 13)
        '
        'txtUsrCreador
        '
        Me.txtUsrCreador.Location = New System.Drawing.Point(115, 36)
        Me.txtUsrCreador.Name = "txtUsrCreador"
        Me.txtUsrCreador.Size = New System.Drawing.Size(619, 20)
        Me.txtUsrCreador.StyleController = Me.LayoutControl
        Me.txtUsrCreador.TabIndex = 21
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtFechaCreado
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(96, 13)
        '
        'txtFechaCreado
        '
        Me.txtFechaCreado.Location = New System.Drawing.Point(115, 60)
        Me.txtFechaCreado.Name = "txtFechaCreado"
        Me.txtFechaCreado.Size = New System.Drawing.Size(619, 20)
        Me.txtFechaCreado.StyleController = Me.LayoutControl
        Me.txtFechaCreado.TabIndex = 22
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtUsrModificador
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(96, 13)
        '
        'txtUsrModificador
        '
        Me.txtUsrModificador.Location = New System.Drawing.Point(115, 84)
        Me.txtUsrModificador.Name = "txtUsrModificador"
        Me.txtUsrModificador.Size = New System.Drawing.Size(619, 20)
        Me.txtUsrModificador.StyleController = Me.LayoutControl
        Me.txtUsrModificador.TabIndex = 23
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtFechaModificado
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem8"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(724, 315)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(96, 13)
        '
        'txtFechaModificado
        '
        Me.txtFechaModificado.Location = New System.Drawing.Point(115, 108)
        Me.txtFechaModificado.Name = "txtFechaModificado"
        Me.txtFechaModificado.Size = New System.Drawing.Size(619, 20)
        Me.txtFechaModificado.StyleController = Me.LayoutControl
        Me.txtFechaModificado.TabIndex = 24
        '
        'DV_Tenants_SubTenantsDetailView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_Tenants_SubTenantsDetailView"
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTenantId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()

        CType(Me.cboClienteId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).EndInit()

        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocalIdDestino.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkActivo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsrCreador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaCreado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsrModificador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaModificado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtFechaModificado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUsrModificador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFechaCreado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUsrCreador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtId As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboTenantId As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    'Friend WithEvents cboClienteId As DevExpress.XtraEditors.ComboBoxEdit

    Friend WithEvents cboClienteId As Studio.Net.Controls.New.Controls.DxGridLookUp
    Friend WithEvents DxGridLookUp1View As DevExpress.XtraGrid.Views.Grid.GridView

    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDescripcion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtLocalIdDestino As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkActivo As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
End Class
