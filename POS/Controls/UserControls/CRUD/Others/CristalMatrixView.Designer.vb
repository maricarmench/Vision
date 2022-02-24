<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CristalMatrixView
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
        Me.PopupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAddCristal = New DevExpress.XtraEditors.SimpleButton()
        Me.cboArticuloId = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.lqifsArticulo = New DevExpress.Data.Linq.LinqInstantFeedbackSource()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tabControl = New DevExpress.XtraTab.XtraTabControl()
        Me.btnShowAddCristal = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.barManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPegar = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiCopiar = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPegarValor = New DevExpress.XtraBars.BarEditItem()
        Me.ritePegarDesde = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.bbiCopiarWithHeaders = New DevExpress.XtraBars.BarButtonItem()
        Me.popMenuCopiar = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.bbiSelectAll = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupContainerControl1.SuspendLayout()
        CType(Me.cboArticuloId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnShowAddCristal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.barManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ritePegarDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popMenuCopiar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.btnShowAddCristal)
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
        Me.PopupContainerControl1.Controls.Add(Me.btnAddCristal)
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
        Me.LabelControl1.Size = New System.Drawing.Size(142, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Seleccione el artículo a cargar"
        '
        'btnAddCristal
        '
        Me.btnAddCristal.Location = New System.Drawing.Point(303, 53)
        Me.btnAddCristal.Name = "btnAddCristal"
        Me.btnAddCristal.Size = New System.Drawing.Size(99, 26)
        Me.btnAddCristal.TabIndex = 1
        Me.btnAddCristal.Text = "Aceptar"
        '
        'cboArticuloId
        '
        Me.cboArticuloId.Location = New System.Drawing.Point(21, 25)
        Me.cboArticuloId.Name = "cboArticuloId"
        Me.cboArticuloId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboArticuloId.Properties.DataSource = Me.lqifsArticulo
        Me.cboArticuloId.Properties.DisplayMember = "Descripcion"
        Me.cboArticuloId.Properties.NullText = ""
        Me.cboArticuloId.Properties.ValueMember = "Id"
        Me.cboArticuloId.Properties.View = Me.SearchLookUpEdit1View
        Me.cboArticuloId.Size = New System.Drawing.Size(381, 20)
        Me.cboArticuloId.TabIndex = 0
        '
        'lqifsArticulo
        '
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
        Me.tabControl.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[False]
        Me.tabControl.HeaderButtons = CType((DevExpress.XtraTab.TabButtons.Close Or DevExpress.XtraTab.TabButtons.[Default]), DevExpress.XtraTab.TabButtons)
        Me.tabControl.Location = New System.Drawing.Point(2, 24)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.Size = New System.Drawing.Size(721, 259)
        Me.tabControl.TabIndex = 0
        '
        'btnShowAddCristal
        '
        Me.btnShowAddCristal.Location = New System.Drawing.Point(673, 2)
        Me.btnShowAddCristal.Name = "btnShowAddCristal"
        Me.btnShowAddCristal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)})
        Me.btnShowAddCristal.Properties.PopupControl = Me.PopupContainerControl1
        Me.btnShowAddCristal.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.btnShowAddCristal.Size = New System.Drawing.Size(50, 18)
        Me.btnShowAddCristal.StyleController = Me.LayoutControl
        Me.btnShowAddCristal.TabIndex = 7
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnShowAddCristal
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(671, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(54, 22)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(54, 22)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(54, 22)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
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
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "Para agregar un nuevo artículo presione el botón de la derecha"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(671, 22)
        Me.EmptySpaceItem1.Text = "Para agregar un nuevo artículo presione el botón de la derecha"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.EmptySpaceItem1.TextVisible = True
        '
        'barManager
        '
        Me.barManager.DockControls.Add(Me.barDockControlTop)
        Me.barManager.DockControls.Add(Me.barDockControlBottom)
        Me.barManager.DockControls.Add(Me.barDockControlLeft)
        Me.barManager.DockControls.Add(Me.barDockControlRight)
        Me.barManager.Form = Me
        Me.barManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPegar, Me.bbiCopiar, Me.bbiPegarValor, Me.bbiCopiarWithHeaders, Me.bbiSelectAll})
        Me.barManager.MaxItemId = 5
        Me.barManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ritePegarDesde})
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(725, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 285)
        Me.barDockControlBottom.Size = New System.Drawing.Size(725, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 285)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(725, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 285)
        '
        'bbiPegar
        '
        Me.bbiPegar.Caption = "Pegar desde el Excel"
        Me.bbiPegar.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.ExcelNew
        Me.bbiPegar.Id = 0
        Me.bbiPegar.Name = "bbiPegar"
        '
        'bbiCopiar
        '
        Me.bbiCopiar.Caption = "Copiar celda"
        Me.bbiCopiar.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_Copy
        Me.bbiCopiar.Id = 1
        Me.bbiCopiar.Name = "bbiCopiar"
        '
        'bbiPegarValor
        '
        Me.bbiPegarValor.Caption = "Pegar el siguiente valor"
        Me.bbiPegarValor.Edit = Me.ritePegarDesde
        Me.bbiPegarValor.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_Paste
        Me.bbiPegarValor.Id = 2
        Me.bbiPegarValor.LargeGlyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_Paste_32x32
        Me.bbiPegarValor.Name = "bbiPegarValor"
        Me.bbiPegarValor.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.bbiPegarValor.Width = 70
        '
        'ritePegarDesde
        '
        Me.ritePegarDesde.AutoHeight = False
        Me.ritePegarDesde.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ritePegarDesde.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ritePegarDesde.Name = "ritePegarDesde"
        '
        'bbiCopiarWithHeaders
        '
        Me.bbiCopiarWithHeaders.Caption = "Copiar selección (incluir encabezados)"
        Me.bbiCopiarWithHeaders.Glyph = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_Copy
        Me.bbiCopiarWithHeaders.Id = 3
        Me.bbiCopiarWithHeaders.Name = "bbiCopiarWithHeaders"
        '
        'popMenuCopiar
        '
        Me.popMenuCopiar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiSelectAll), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiCopiar, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiCopiarWithHeaders), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPegar, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPegarValor)})
        Me.popMenuCopiar.Manager = Me.barManager
        Me.popMenuCopiar.Name = "popMenuCopiar"
        '
        'bbiSelectAll
        '
        Me.bbiSelectAll.Caption = "Seleccionar todo"
        Me.bbiSelectAll.Id = 4
        Me.bbiSelectAll.Name = "bbiSelectAll"
        '
        'CristalMatrixView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PopupContainerControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "CristalMatrixView"
        Me.Size = New System.Drawing.Size(725, 285)
        Me.Controls.SetChildIndex(Me.barDockControlTop, 0)
        Me.Controls.SetChildIndex(Me.barDockControlBottom, 0)
        Me.Controls.SetChildIndex(Me.barDockControlRight, 0)
        Me.Controls.SetChildIndex(Me.barDockControlLeft, 0)
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
        CType(Me.btnShowAddCristal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.barManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ritePegarDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popMenuCopiar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PopupContainerControl1 As DevExpress.XtraEditors.PopupContainerControl
    Friend WithEvents btnShowAddCristal As DevExpress.XtraEditors.PopupContainerEdit
    Friend WithEvents tabControl As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAddCristal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboArticuloId As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lqifsArticulo As DevExpress.Data.Linq.LinqInstantFeedbackSource
    Friend WithEvents barManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPegar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents popMenuCopiar As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiCopiar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPegarValor As DevExpress.XtraBars.BarEditItem
    Friend WithEvents ritePegarDesde As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents bbiCopiarWithHeaders As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiSelectAll As DevExpress.XtraBars.BarButtonItem

End Class
