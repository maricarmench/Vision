<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_TallerDetailView
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
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtId = New DevExpress.XtraEditors.TextEdit()
        Me.txtDescripcion = New DevExpress.XtraEditors.TextEdit()
        Me.chkTallerPropio = New DevExpress.XtraEditors.CheckEdit()
        Me.cboDepositoId = New Studio.Net.Controls.[New].Controls.DxGridLookUp()
        Me.DxGridLookUp1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtUsrCreador = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
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
        CType(Me.txtId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTallerPropio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepositoId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsrCreador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LayoutControl.Controls.Add(Me.cboDepositoId)
        Me.LayoutControl.Controls.Add(Me.chkTallerPropio)
        Me.LayoutControl.Controls.Add(Me.txtDescripcion)
        Me.LayoutControl.Controls.Add(Me.txtId)
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
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(114, 36)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(620, 20)
        Me.txtId.StyleController = Me.LayoutControl
        Me.txtId.TabIndex = 4
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(114, 60)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(620, 20)
        Me.txtDescripcion.StyleController = Me.LayoutControl
        Me.txtDescripcion.TabIndex = 5
        '
        'chkTallerPropio
        '
        Me.chkTallerPropio.Location = New System.Drawing.Point(114, 84)
        Me.chkTallerPropio.Name = "chkTallerPropio"
        Me.chkTallerPropio.Properties.Caption = ""
        Me.chkTallerPropio.Size = New System.Drawing.Size(258, 19)
        Me.chkTallerPropio.StyleController = Me.LayoutControl
        Me.chkTallerPropio.TabIndex = 6
        '
        'cboDepositoId
        '
        Me.cboDepositoId.BusinessToUse = Nothing
        Me.cboDepositoId.Location = New System.Drawing.Point(476, 84)
        Me.cboDepositoId.Name = "cboDepositoId"
        Me.cboDepositoId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboDepositoId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDepositoId.Properties.View = Me.DxGridLookUp1View
        Me.cboDepositoId.Size = New System.Drawing.Size(258, 20)
        Me.cboDepositoId.StyleController = Me.LayoutControl
        Me.cboDepositoId.TabIndex = 7
        '
        'DxGridLookUp1View
        '
        Me.DxGridLookUp1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.DxGridLookUp1View.Name = "DxGridLookUp1View"
        Me.DxGridLookUp1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DxGridLookUp1View.OptionsView.ShowGroupPanel = False
        '
        'txtUsrCreador
        '
        Me.txtUsrCreador.Location = New System.Drawing.Point(114, 36)
        Me.txtUsrCreador.Name = "txtUsrCreador"
        Me.txtUsrCreador.Size = New System.Drawing.Size(620, 20)
        Me.txtUsrCreador.StyleController = Me.LayoutControl
        Me.txtUsrCreador.TabIndex = 8
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
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.CustomizationFormText = "TabbedControlGroup1"
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup1
        Me.TabbedControlGroup1.SelectedTabPageIndex = 0
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(748, 433)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlGroup2})
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "General"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(724, 387)
        Me.LayoutControlGroup1.Text = "General"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.chkTallerPropio
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(362, 339)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboDepositoId
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(362, 48)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(362, 339)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(96, 13)
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtDescripcion
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtId
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(724, 24)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Auditoría"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(724, 387)
        Me.LayoutControlGroup2.Text = "Auditoría"
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
        Me.txtFechaCreado.Location = New System.Drawing.Point(114, 60)
        Me.txtFechaCreado.Name = "txtFechaCreado"
        Me.txtFechaCreado.Size = New System.Drawing.Size(620, 20)
        Me.txtFechaCreado.StyleController = Me.LayoutControl
        Me.txtFechaCreado.TabIndex = 9
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
        Me.txtUsrModificador.Location = New System.Drawing.Point(114, 84)
        Me.txtUsrModificador.Name = "txtUsrModificador"
        Me.txtUsrModificador.Size = New System.Drawing.Size(620, 20)
        Me.txtUsrModificador.StyleController = Me.LayoutControl
        Me.txtUsrModificador.TabIndex = 10
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
        Me.txtFechaModificado.Location = New System.Drawing.Point(114, 108)
        Me.txtFechaModificado.Name = "txtFechaModificado"
        Me.txtFechaModificado.Size = New System.Drawing.Size(620, 20)
        Me.txtFechaModificado.StyleController = Me.LayoutControl
        Me.txtFechaModificado.TabIndex = 11
        '
        'DV_TallerDetailView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_TallerDetailView"
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTallerPropio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepositoId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsrCreador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaCreado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsrModificador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaModificado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkTallerPropio As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtDescripcion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtId As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboDepositoId As Studio.Net.Controls.New.Controls.DxGridLookUp
    Friend WithEvents DxGridLookUp1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtFechaModificado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUsrModificador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFechaCreado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUsrCreador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem

End Class
