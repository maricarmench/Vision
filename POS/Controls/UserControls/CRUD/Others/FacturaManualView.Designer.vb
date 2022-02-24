<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacturaManualView
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FacturaManualView))
        Me.cboDocumentoTipoId = New Studio.Net.Controls.[New].Controls.DxGridLookUp()
        Me.DxGridLookUp1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtNumeroDocumento = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtFechaEmitida = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDocumentoTipoId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroDocumento.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaEmitida.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaEmitida.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.btnCancelar)
        Me.LayoutControl.Controls.Add(Me.btnAceptar)
        Me.LayoutControl.Controls.Add(Me.txtFechaEmitida)
        Me.LayoutControl.Controls.Add(Me.txtNumeroDocumento)
        Me.LayoutControl.Controls.Add(Me.cboDocumentoTipoId)
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl.Size = New System.Drawing.Size(450, 85)
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControlGroup.Size = New System.Drawing.Size(450, 85)
        '
        'cboDocumentoTipoId
        '
        Me.cboDocumentoTipoId.BusinessToUse = Nothing
        Me.cboDocumentoTipoId.Location = New System.Drawing.Point(60, 2)
        Me.cboDocumentoTipoId.Name = "cboDocumentoTipoId"
        Me.cboDocumentoTipoId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboDocumentoTipoId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDocumentoTipoId.Properties.View = Me.DxGridLookUp1View
        Me.cboDocumentoTipoId.Size = New System.Drawing.Size(388, 20)
        Me.cboDocumentoTipoId.StyleController = Me.LayoutControl
        Me.cboDocumentoTipoId.TabIndex = 4
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
        Me.LayoutControlItem1.Control = Me.cboDocumentoTipoId
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(450, 24)
        Me.LayoutControlItem1.Text = "Documento"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(54, 13)
        '
        'txtNumeroDocumento
        '
        Me.txtNumeroDocumento.Location = New System.Drawing.Point(60, 26)
        Me.txtNumeroDocumento.Name = "txtNumeroDocumento"
        Me.txtNumeroDocumento.Size = New System.Drawing.Size(172, 20)
        Me.txtNumeroDocumento.StyleController = Me.LayoutControl
        Me.txtNumeroDocumento.TabIndex = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtNumeroDocumento
        Me.LayoutControlItem2.CustomizationFormText = "Número"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(234, 24)
        Me.LayoutControlItem2.Text = "Número"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(54, 13)
        '
        'txtFechaEmitida
        '
        Me.txtFechaEmitida.EditValue = Nothing
        Me.txtFechaEmitida.Location = New System.Drawing.Point(294, 26)
        Me.txtFechaEmitida.Name = "txtFechaEmitida"
        Me.txtFechaEmitida.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaEmitida.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFechaEmitida.Size = New System.Drawing.Size(154, 20)
        Me.txtFechaEmitida.StyleController = Me.LayoutControl
        Me.txtFechaEmitida.TabIndex = 6
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtFechaEmitida
        Me.LayoutControlItem3.CustomizationFormText = "Fecha"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(234, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(216, 24)
        Me.LayoutControlItem3.Text = "Fecha"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(54, 13)
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_Save_New_32x32
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(2, 50)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(221, 33)
        Me.btnAceptar.StyleController = Me.LayoutControl
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "&Aceptar"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnAceptar
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(83, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(225, 37)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "LayoutControlItem4"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextToControlDistance = 0
        Me.LayoutControlItem4.TextVisible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(227, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(221, 33)
        Me.btnCancelar.StyleController = Me.LayoutControl
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "&Cancelar"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnCancelar
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(225, 48)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(83, 26)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(225, 37)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "LayoutControlItem5"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'FacturaManualView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Factura manual de receta"
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FacturaManualView"
        Me.Size = New System.Drawing.Size(450, 85)
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDocumentoTipoId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroDocumento.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaEmitida.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaEmitida.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboDocumentoTipoId As Studio.Net.Controls.New.Controls.DxGridLookUp
    Friend WithEvents DxGridLookUp1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtFechaEmitida As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtNumeroDocumento As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider

End Class
