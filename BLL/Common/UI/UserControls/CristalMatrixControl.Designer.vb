<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CristalMatrixControl
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
        Me.PopupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddArticulo = New DevExpress.XtraEditors.SimpleButton()
        Me.cboArticuloId = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tabControl = New DevExpress.XtraTab.XtraTabControl()
        Me.btnAddCristal = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.lqifsArticulo = New DevExpress.Data.Linq.LinqInstantFeedbackSource()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupContainerControl1.SuspendLayout()
        CType(Me.cboArticuloId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAddCristal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.btnAddCristal)
        Me.LayoutControl.Controls.Add(Me.tabControl)
        Me.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(925, 245, 250, 350)
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl.Size = New System.Drawing.Size(725, 285)
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlItem1})
        Me.LayoutControlGroup.Size = New System.Drawing.Size(725, 285)
        '
        'PopupContainerControl1
        '
        Me.PopupContainerControl1.Controls.Add(Me.LabelControl1)
        Me.PopupContainerControl1.Controls.Add(Me.btnCancelar)
        Me.PopupContainerControl1.Controls.Add(Me.btnAddArticulo)
        Me.PopupContainerControl1.Controls.Add(Me.cboArticuloId)
        Me.PopupContainerControl1.Location = New System.Drawing.Point(45, 85)
        Me.PopupContainerControl1.Name = "PopupContainerControl1"
        Me.PopupContainerControl1.Size = New System.Drawing.Size(414, 89)
        Me.PopupContainerControl1.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(21, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(173, 16)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Seleccione el artículo a cargar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(198, 53)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(99, 26)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAddArticulo
        '
        Me.btnAddArticulo.Image = Global.Studio.Vision.BLL.Common.My.Resources.Resources.add
        Me.btnAddArticulo.Location = New System.Drawing.Point(303, 53)
        Me.btnAddArticulo.Name = "btnAddArticulo"
        Me.btnAddArticulo.Size = New System.Drawing.Size(99, 26)
        Me.btnAddArticulo.TabIndex = 1
        Me.btnAddArticulo.Text = "Agregar"
        '
        'cboArticuloId
        '
        Me.cboArticuloId.Location = New System.Drawing.Point(21, 25)
        Me.cboArticuloId.Name = "cboArticuloId"
        Me.cboArticuloId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboArticuloId.Properties.View = Me.SearchLookUpEdit1View
        Me.cboArticuloId.Size = New System.Drawing.Size(381, 22)
        Me.cboArticuloId.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'tabControl
        '
        Me.tabControl.Location = New System.Drawing.Point(2, 43)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.Size = New System.Drawing.Size(721, 240)
        Me.tabControl.TabIndex = 0
        '
        'btnAddCristal
        '
        Me.btnAddCristal.Location = New System.Drawing.Point(673, 2)
        Me.btnAddCristal.Name = "btnAddCristal"
        Me.btnAddCristal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)})
        Me.btnAddCristal.Properties.PopupControl = Me.PopupContainerControl1
        Me.btnAddCristal.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.btnAddCristal.Size = New System.Drawing.Size(50, 18)
        Me.btnAddCristal.StyleController = Me.LayoutControl
        Me.btnAddCristal.TabIndex = 7
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnAddCristal
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(671, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(54, 22)
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.tabControl
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 22)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(725, 263)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(111, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "Para agregar un nuevo artículo presione el botón de la derecha"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(671, 22)
        Me.EmptySpaceItem1.Text = "Para agregar un nuevo artículo presione el botón de la derecha"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(111, 0)
        Me.EmptySpaceItem1.TextVisible = True
        '
        'lqifsArticulo
        '
        '
        'CristalMatrixControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PopupContainerControl1)
        Me.Name = "CristalMatrixControl"
        Me.Size = New System.Drawing.Size(725, 285)
        Me.Controls.SetChildIndex(Me.LayoutControl, 0)
        Me.Controls.SetChildIndex(Me.PopupContainerControl1, 0)
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupContainerControl1.ResumeLayout(False)
        Me.PopupContainerControl1.PerformLayout()
        CType(Me.cboArticuloId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAddCristal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PopupContainerControl1 As DevExpress.XtraEditors.PopupContainerControl
    Friend WithEvents btnAddCristal As DevExpress.XtraEditors.PopupContainerEdit
    Friend WithEvents tabControl As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAddArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboArticuloId As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lqifsArticulo As DevExpress.Data.Linq.LinqInstantFeedbackSource

End Class
