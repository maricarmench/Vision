<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_CrearVariantesDeCristales
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
        Me.labDescripcion = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtDiametro = New Studio.Net.Controls.[New].Controls.DXSpinEdit()
        Me.txtEsfericoDesde = New Studio.Net.Controls.[New].Controls.DXSpinEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtCilindricoDesde = New Studio.Net.Controls.[New].Controls.DXSpinEdit()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtEsfericoHasta = New Studio.Net.Controls.[New].Controls.DXSpinEdit()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.txtCilindricoHasta = New Studio.Net.Controls.[New].Controls.DXSpinEdit()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.chkValoresMesMenos = New DevExpress.XtraEditors.CheckEdit()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnGenerar = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiametro.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEsfericoDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCilindricoDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEsfericoHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCilindricoHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkValoresMesMenos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.btnGenerar)
        Me.LayoutControl.Controls.Add(Me.txtCilindricoHasta)
        Me.LayoutControl.Controls.Add(Me.txtEsfericoHasta)
        Me.LayoutControl.Controls.Add(Me.txtCilindricoDesde)
        Me.LayoutControl.Controls.Add(Me.txtEsfericoDesde)
        Me.LayoutControl.Controls.Add(Me.chkValoresMesMenos)
        Me.LayoutControl.Controls.Add(Me.labDescripcion)
        Me.LayoutControl.Controls.Add(Me.txtDiametro)
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl.Size = New System.Drawing.Size(443, 229)
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.LayoutControlItem6, Me.LayoutControlItem7})
        Me.LayoutControlGroup.Size = New System.Drawing.Size(443, 229)
        '
        'labDescripcion
        '
        Me.labDescripcion.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.labDescripcion.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.labDescripcion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labDescripcion.Location = New System.Drawing.Point(2, 2)
        Me.labDescripcion.Name = "labDescripcion"
        Me.labDescripcion.Size = New System.Drawing.Size(439, 14)
        Me.labDescripcion.StyleController = Me.LayoutControl
        Me.labDescripcion.TabIndex = 4
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.labDescripcion
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(0, 24)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(14, 17)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(443, 18)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtDiametro
        Me.LayoutControlItem2.CustomizationFormText = "Diámetro "
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 18)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(443, 26)
        Me.LayoutControlItem2.Text = "Diámetro "
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(56, 16)
        '
        'txtDiametro
        '
        Me.txtDiametro.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDiametro.Location = New System.Drawing.Point(62, 20)
        Me.txtDiametro.Name = "txtDiametro"
        Me.txtDiametro.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtDiametro.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtDiametro.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.txtDiametro.RoundToNearest = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDiametro.Size = New System.Drawing.Size(379, 22)
        Me.txtDiametro.StyleController = Me.LayoutControl
        Me.txtDiametro.TabIndex = 5
        '
        'txtEsfericoDesde
        '
        Me.txtEsfericoDesde.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEsfericoDesde.Location = New System.Drawing.Point(67, 73)
        Me.txtEsfericoDesde.Name = "txtEsfericoDesde"
        Me.txtEsfericoDesde.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtEsfericoDesde.RoundToNearest = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEsfericoDesde.Size = New System.Drawing.Size(152, 22)
        Me.txtEsfericoDesde.StyleController = Me.LayoutControl
        Me.txtEsfericoDesde.TabIndex = 6
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtEsfericoDesde
        Me.LayoutControlItem3.CustomizationFormText = "Desde"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(216, 26)
        Me.LayoutControlItem3.Text = "Desde"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(56, 16)
        '
        'txtCilindricoDesde
        '
        Me.txtCilindricoDesde.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCilindricoDesde.Location = New System.Drawing.Point(67, 131)
        Me.txtCilindricoDesde.Name = "txtCilindricoDesde"
        Me.txtCilindricoDesde.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCilindricoDesde.RoundToNearest = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCilindricoDesde.Size = New System.Drawing.Size(152, 22)
        Me.txtCilindricoDesde.StyleController = Me.LayoutControl
        Me.txtCilindricoDesde.TabIndex = 7
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtCilindricoDesde
        Me.LayoutControlItem4.CustomizationFormText = "Desde"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(216, 26)
        Me.LayoutControlItem4.Text = "Desde"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(56, 16)
        '
        'txtEsfericoHasta
        '
        Me.txtEsfericoHasta.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEsfericoHasta.Location = New System.Drawing.Point(283, 73)
        Me.txtEsfericoHasta.Name = "txtEsfericoHasta"
        Me.txtEsfericoHasta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtEsfericoHasta.RoundToNearest = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEsfericoHasta.Size = New System.Drawing.Size(153, 22)
        Me.txtEsfericoHasta.StyleController = Me.LayoutControl
        Me.txtEsfericoHasta.TabIndex = 7
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtEsfericoHasta
        Me.LayoutControlItem8.CustomizationFormText = "Hasta"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(216, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(217, 26)
        Me.LayoutControlItem8.Text = "Hasta"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(56, 16)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Esférico"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 44)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(443, 58)
        Me.LayoutControlGroup1.Text = "Esférico"
        '
        'txtCilindricoHasta
        '
        Me.txtCilindricoHasta.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCilindricoHasta.Location = New System.Drawing.Point(283, 131)
        Me.txtCilindricoHasta.Name = "txtCilindricoHasta"
        Me.txtCilindricoHasta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCilindricoHasta.RoundToNearest = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCilindricoHasta.Size = New System.Drawing.Size(153, 22)
        Me.txtCilindricoHasta.StyleController = Me.LayoutControl
        Me.txtCilindricoHasta.TabIndex = 8
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtCilindricoHasta
        Me.LayoutControlItem5.CustomizationFormText = "Hasta"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(216, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(217, 26)
        Me.LayoutControlItem5.Text = "Hasta"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(56, 16)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Cilíndrico"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(443, 58)
        Me.LayoutControlGroup2.Text = "Cilíndrico"
        '
        'chkValoresMesMenos
        '
        Me.chkValoresMesMenos.Location = New System.Drawing.Point(176, 162)
        Me.chkValoresMesMenos.Name = "chkValoresMesMenos"
        Me.chkValoresMesMenos.Properties.Caption = ""
        Me.chkValoresMesMenos.Size = New System.Drawing.Size(265, 21)
        Me.chkValoresMesMenos.StyleController = Me.LayoutControl
        Me.chkValoresMesMenos.TabIndex = 9
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.chkValoresMesMenos
        Me.LayoutControlItem6.CustomizationFormText = "Manejar los valores como +/-"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 160)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(443, 25)
        Me.LayoutControlItem6.Text = "Manejar los valores como +/-"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(169, 16)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = Global.Studio.Vision.Controls.My.Resources.Resources.Commands_Icon
        Me.btnGenerar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(2, 187)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(439, 40)
        Me.btnGenerar.StyleController = Me.LayoutControl
        Me.btnGenerar.TabIndex = 10
        Me.btnGenerar.Text = "Generar"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnGenerar
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 185)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(83, 26)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(443, 44)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "LayoutControlItem7"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        '
        'DV_CrearVariantesDeCristales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_CrearVariantesDeCristales"
        Me.Size = New System.Drawing.Size(443, 229)
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiametro.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEsfericoDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCilindricoDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEsfericoHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCilindricoHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkValoresMesMenos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labDescripcion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtCilindricoHasta As Studio.Net.Controls.[New].Controls.DXSpinEdit
    Friend WithEvents txtEsfericoHasta As Studio.Net.Controls.[New].Controls.DXSpinEdit
    Friend WithEvents txtCilindricoDesde As Studio.Net.Controls.[New].Controls.DXSpinEdit
    Friend WithEvents txtEsfericoDesde As Studio.Net.Controls.[New].Controls.DXSpinEdit
    Friend WithEvents chkValoresMesMenos As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnGenerar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDiametro As Studio.Net.Controls.[New].Controls.DXSpinEdit

End Class
