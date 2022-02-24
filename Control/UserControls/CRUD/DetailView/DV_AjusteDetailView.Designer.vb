<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_AjusteDetailView
    Inherits Studio.Phone.Controls.[New].AjusteDetailView

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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        CType(Me.txtId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepositoId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAjusteMotivoId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaModificado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsrModificador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaCreado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsrCreador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rileArticuloId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtId
        '
        '
        'cboDepositoId
        '
        '
        'GridView1
        '
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        '
        'cboAjusteMotivoId
        '
        '
        'DxGridLookUp1View
        '
        Me.DxGridLookUp1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DxGridLookUp1View.OptionsView.ShowGroupPanel = False
        '
        'txtFechaModificado
        '
        '
        'txtUsrModificador
        '
        '
        'txtFechaCreado
        '
        '
        'txtUsrCreador
        '
        '
        'txtObservaciones
        '
        '
        'gvSeries
        '
        Me.gvSeries.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvSeries.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvSeries.OptionsView.ShowGroupPanel = False
        '
        'colFila
        '
        Me.colFila.OptionsColumn.AllowEdit = False
        Me.colFila.OptionsColumn.AllowFocus = False
        Me.colFila.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colFila.OptionsColumn.AllowMove = False
        Me.colFila.OptionsColumn.AllowSize = False
        Me.colFila.OptionsColumn.FixedWidth = True
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'grdDetalle
        '
        GridLevelNode1.LevelTemplate = Me.gvSeries
        GridLevelNode1.RelationName = "Series"
        Me.grdDetalle.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdDetalle.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rileArticuloId})
        '
        'gvDetalles
        '
        Me.gvDetalles.OptionsBehavior.AutoPopulateColumns = False
        '
        'LayoutControl
        '
        Me.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(552, 268, 250, 350)
        Me.LayoutControl.OptionsCustomizationForm.ShowLoadButton = False
        Me.LayoutControl.OptionsCustomizationForm.ShowPropertyGrid = True
        Me.LayoutControl.OptionsCustomizationForm.ShowSaveButton = False
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl.Controls.SetChildIndex(Me.txtId, 0)
        Me.LayoutControl.Controls.SetChildIndex(Me.cboDepositoId, 0)
        Me.LayoutControl.Controls.SetChildIndex(Me.txtFecha, 0)
        Me.LayoutControl.Controls.SetChildIndex(Me.cboAjusteMotivoId, 0)
        Me.LayoutControl.Controls.SetChildIndex(Me.txtUsrCreador, 0)
        Me.LayoutControl.Controls.SetChildIndex(Me.txtFechaCreado, 0)
        Me.LayoutControl.Controls.SetChildIndex(Me.txtUsrModificador, 0)
        Me.LayoutControl.Controls.SetChildIndex(Me.txtFechaModificado, 0)
        Me.LayoutControl.Controls.SetChildIndex(Me.grdDetalle, 0)
        Me.LayoutControl.Controls.SetChildIndex(Me.txtObservaciones, 0)
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        '
        'DV_AjusteDetailView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_AjusteDetailView"
        CType(Me.txtId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepositoId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAjusteMotivoId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxGridLookUp1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaModificado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsrModificador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaCreado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsrCreador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvSeries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rileArticuloId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

End Class
