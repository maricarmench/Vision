<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_CrearVariantesCristalesView
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
        Me.txtAtributo1Min = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtAtributo1Max = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgPlantilla1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.txtAtributo2Min = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtAtributo2Max = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgPlantilla2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.btnGenerar = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAtributo1Min.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAtributo1Max.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgPlantilla1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAtributo2Min.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAtributo2Max.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgPlantilla2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.btnGenerar)
        Me.LayoutControl.Controls.Add(Me.txtAtributo2Max)
        Me.LayoutControl.Controls.Add(Me.txtAtributo2Min)
        Me.LayoutControl.Controls.Add(Me.txtAtributo1Max)
        Me.LayoutControl.Controls.Add(Me.txtAtributo1Min)
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl.Size = New System.Drawing.Size(492, 169)
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcgPlantilla1, Me.lcgPlantilla2, Me.LayoutControlItem5})
        Me.LayoutControlGroup.OptionsItemText.TextToControlDistance = 5
        Me.LayoutControlGroup.Size = New System.Drawing.Size(472, 178)
        '
        'txtAtributo1Min
        '
        Me.txtAtributo1Min.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAtributo1Min.Location = New System.Drawing.Point(54, 34)
        Me.txtAtributo1Min.Name = "txtAtributo1Min"
        Me.txtAtributo1Min.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtAtributo1Min.Size = New System.Drawing.Size(176, 24)
        Me.txtAtributo1Min.StyleController = Me.LayoutControl
        Me.txtAtributo1Min.TabIndex = 4
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtAtributo1Min
        Me.LayoutControlItem1.CustomizationFormText = "Desde"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(226, 34)
        Me.LayoutControlItem1.Text = "Desde"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(35, 16)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'txtAtributo1Max
        '
        Me.txtAtributo1Max.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAtributo1Max.Location = New System.Drawing.Point(280, 34)
        Me.txtAtributo1Max.Name = "txtAtributo1Max"
        Me.txtAtributo1Max.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtAtributo1Max.Size = New System.Drawing.Size(178, 24)
        Me.txtAtributo1Max.StyleController = Me.LayoutControl
        Me.txtAtributo1Max.TabIndex = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtAtributo1Max
        Me.LayoutControlItem2.CustomizationFormText = "Hasta"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(226, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(228, 34)
        Me.LayoutControlItem2.Text = "Hasta"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(35, 16)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'lcgPlantilla1
        '
        Me.lcgPlantilla1.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.13913059!, System.Drawing.FontStyle.Bold)
        Me.lcgPlantilla1.AppearanceGroup.Options.UseFont = True
        Me.lcgPlantilla1.CustomizationFormText = "Rango1"
        Me.lcgPlantilla1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.lcgPlantilla1.Location = New System.Drawing.Point(0, 0)
        Me.lcgPlantilla1.Name = "lcgPlantilla1"
        Me.lcgPlantilla1.OptionsItemText.TextToControlDistance = 5
        Me.lcgPlantilla1.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.lcgPlantilla1.Size = New System.Drawing.Size(472, 72)
        Me.lcgPlantilla1.Text = "Rango1"
        '
        'txtAtributo2Min
        '
        Me.txtAtributo2Min.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAtributo2Min.Location = New System.Drawing.Point(54, 106)
        Me.txtAtributo2Min.Name = "txtAtributo2Min"
        Me.txtAtributo2Min.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtAtributo2Min.Size = New System.Drawing.Size(176, 24)
        Me.txtAtributo2Min.StyleController = Me.LayoutControl
        Me.txtAtributo2Min.TabIndex = 6
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtAtributo2Min
        Me.LayoutControlItem3.CustomizationFormText = "Desde"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(226, 34)
        Me.LayoutControlItem3.Text = "Desde"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(35, 16)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'txtAtributo2Max
        '
        Me.txtAtributo2Max.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAtributo2Max.Location = New System.Drawing.Point(280, 106)
        Me.txtAtributo2Max.Name = "txtAtributo2Max"
        Me.txtAtributo2Max.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtAtributo2Max.Size = New System.Drawing.Size(178, 24)
        Me.txtAtributo2Max.StyleController = Me.LayoutControl
        Me.txtAtributo2Max.TabIndex = 7
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtAtributo2Max
        Me.LayoutControlItem4.CustomizationFormText = "Hasta"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(226, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(228, 34)
        Me.LayoutControlItem4.Text = "Hasta"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(35, 16)
        Me.LayoutControlItem4.TextToControlDistance = 5
        '
        'lcgPlantilla2
        '
        Me.lcgPlantilla2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.13913059!, System.Drawing.FontStyle.Bold)
        Me.lcgPlantilla2.AppearanceGroup.Options.UseFont = True
        Me.lcgPlantilla2.CustomizationFormText = "Rango2"
        Me.lcgPlantilla2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem3})
        Me.lcgPlantilla2.Location = New System.Drawing.Point(0, 72)
        Me.lcgPlantilla2.Name = "lcgPlantilla2"
        Me.lcgPlantilla2.OptionsItemText.TextToControlDistance = 5
        Me.lcgPlantilla2.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.lcgPlantilla2.Size = New System.Drawing.Size(472, 72)
        Me.lcgPlantilla2.Text = "Rango2"
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = Global.Studio.Vision.Controls.My.Resources.Resources.Commands_Icon
        Me.btnGenerar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(5, 149)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(462, 24)
        Me.btnGenerar.StyleController = Me.LayoutControl
        Me.btnGenerar.TabIndex = 11
        Me.btnGenerar.Text = "Generar"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnGenerar
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 144)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(81, 34)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(472, 34)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "LayoutControlItem5"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'DV_CrearVariantesCristalesView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_CrearVariantesCristalesView"
        Me.Size = New System.Drawing.Size(492, 169)
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAtributo1Min.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAtributo1Max.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgPlantilla1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAtributo2Min.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAtributo2Max.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgPlantilla2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtAtributo1Min As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtAtributo1Max As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lcgPlantilla1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtAtributo2Min As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtAtributo2Max As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcgPlantilla2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnGenerar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem

End Class
