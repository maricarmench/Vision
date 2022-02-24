<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParametroComisionVendedorListView
    'Inherits Studio.Phone.Controls.[New].DrakoListView
    Inherits Studio.Phone.Controls.[New].ParametroComisionVendedorListView

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ParametroComisionVendedorListView))
        Me.AdvBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colArticuloId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.rislkArticulo = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.lqsmsArticulo = New DevExpress.Data.Linq.LinqServerModeSource()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colRubroId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colNivId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCargoId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFuncionarioId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colClienteId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colLocalId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colListaPreVtaId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colImporte = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colMonedaId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPorcentaje = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colOrden = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository(Me.components)
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rislkArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lqsmsArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EntityCollection1
        '
        Me.EntityCollection1.EntityFactoryToUse = CType(resources.GetObject("EntityCollection1.EntityFactoryToUse"), SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2)
        '
        'LayoutControl
        '
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        '
        'AdvBandedGridView1
        '
        Me.AdvBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand1, Me.GridBand2, Me.GridBand4})
        Me.AdvBandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colId, Me.colArticuloId, Me.colCargoId, Me.colFuncionarioId, Me.colClienteId, Me.colLocalId, Me.colListaPreVtaId, Me.colRubroId, Me.colNivId, Me.colPorcentaje, Me.colMonedaId, Me.colImporte, Me.colOrden})
        Me.AdvBandedGridView1.CustomizationFormBounds = New System.Drawing.Rectangle(568, 378, 222, 219)
        Me.AdvBandedGridView1.GridControl = Me.MyDXGrid
        Me.AdvBandedGridView1.Name = "AdvBandedGridView1"
        Me.AdvBandedGridView1.OptionsBehavior.AutoPopulateColumns = False
        Me.AdvBandedGridView1.OptionsBehavior.Editable = False
        Me.AdvBandedGridView1.OptionsFilter.AllowFilterEditor = False
        Me.AdvBandedGridView1.OptionsFind.AllowFindPanel = False
        Me.AdvBandedGridView1.OptionsView.ColumnAutoWidth = True
        Me.AdvBandedGridView1.OptionsView.ShowBands = False
        Me.AdvBandedGridView1.OptionsView.ShowGroupPanel = False
        '
        'gridBand1
        '
        Me.gridBand1.Caption = "gridBand1"
        Me.gridBand1.Columns.Add(Me.colId)
        Me.gridBand1.MinWidth = 20
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.OptionsBand.ShowCaption = False
        Me.gridBand1.RowCount = 2
        Me.gridBand1.VisibleIndex = 0
        Me.gridBand1.Width = 31
        '
        'colId
        '
        Me.colId.FieldName = "Id"
        Me.colId.Name = "colId"
        Me.colId.RowCount = 2
        Me.colId.Visible = True
        Me.colId.Width = 31
        '
        'GridBand2
        '
        Me.GridBand2.Caption = "Condiciones artículo"
        Me.GridBand2.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand3})
        Me.GridBand2.MinWidth = 20
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 1
        Me.GridBand2.Width = 385
        '
        'GridBand3
        '
        Me.GridBand3.Caption = "Condiciones adicionales"
        Me.GridBand3.Columns.Add(Me.colArticuloId)
        Me.GridBand3.Columns.Add(Me.colRubroId)
        Me.GridBand3.Columns.Add(Me.colNivId)
        Me.GridBand3.Columns.Add(Me.colCargoId)
        Me.GridBand3.Columns.Add(Me.colFuncionarioId)
        Me.GridBand3.Columns.Add(Me.colClienteId)
        Me.GridBand3.Columns.Add(Me.colLocalId)
        Me.GridBand3.Columns.Add(Me.colListaPreVtaId)
        Me.GridBand3.Name = "GridBand3"
        Me.GridBand3.VisibleIndex = 0
        Me.GridBand3.Width = 385
        '
        'colArticuloId
        '
        Me.colArticuloId.Caption = "Artículo"
        Me.colArticuloId.ColumnEdit = Me.rislkArticulo
        Me.colArticuloId.FieldName = "ArticuloId"
        Me.colArticuloId.Name = "colArticuloId"
        Me.colArticuloId.Visible = True
        Me.colArticuloId.Width = 135
        '
        'rislkArticulo
        '
        Me.rislkArticulo.AutoHeight = False
        Me.rislkArticulo.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.rislkArticulo.DataSource = Me.lqsmsArticulo
        Me.rislkArticulo.DisplayMember = "Descripcion"
        Me.rislkArticulo.Name = "rislkArticulo"
        Me.rislkArticulo.NullText = ""
        Me.rislkArticulo.ValueMember = "Id"
        Me.rislkArticulo.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colRubroId
        '
        Me.colRubroId.Caption = "Rubro"
        Me.colRubroId.FieldName = "RubroId"
        Me.colRubroId.Name = "colRubroId"
        Me.colRubroId.Visible = True
        Me.colRubroId.Width = 119
        '
        'colNivId
        '
        Me.colNivId.Caption = "Nivel"
        Me.colNivId.FieldName = "NivId"
        Me.colNivId.Name = "colNivId"
        Me.colNivId.Visible = True
        Me.colNivId.Width = 131
        '
        'colCargoId
        '
        Me.colCargoId.Caption = "Cargo"
        Me.colCargoId.FieldName = "CargoId"
        Me.colCargoId.Name = "colCargoId"
        Me.colCargoId.RowIndex = 1
        Me.colCargoId.Visible = True
        Me.colCargoId.Width = 56
        '
        'colFuncionarioId
        '
        Me.colFuncionarioId.Caption = "Funcionario"
        Me.colFuncionarioId.FieldName = "FuncionarioId"
        Me.colFuncionarioId.Name = "colFuncionarioId"
        Me.colFuncionarioId.RowIndex = 1
        Me.colFuncionarioId.Visible = True
        Me.colFuncionarioId.Width = 86
        '
        'colClienteId
        '
        Me.colClienteId.Caption = "Cliente"
        Me.colClienteId.FieldName = "ClienteId"
        Me.colClienteId.Name = "colClienteId"
        Me.colClienteId.RowIndex = 1
        Me.colClienteId.Visible = True
        Me.colClienteId.Width = 61
        '
        'colLocalId
        '
        Me.colLocalId.Caption = "Local"
        Me.colLocalId.FieldName = "LocalId"
        Me.colLocalId.Name = "colLocalId"
        Me.colLocalId.RowIndex = 1
        Me.colLocalId.Visible = True
        Me.colLocalId.Width = 54
        '
        'colListaPreVtaId
        '
        Me.colListaPreVtaId.Caption = "Lista de precios"
        Me.colListaPreVtaId.FieldName = "ListaPreVtaId"
        Me.colListaPreVtaId.Name = "colListaPreVtaId"
        Me.colListaPreVtaId.RowIndex = 1
        Me.colListaPreVtaId.Visible = True
        Me.colListaPreVtaId.Width = 128
        '
        'GridBand4
        '
        Me.GridBand4.Caption = "Valores"
        Me.GridBand4.Columns.Add(Me.colImporte)
        Me.GridBand4.Columns.Add(Me.colMonedaId)
        Me.GridBand4.Columns.Add(Me.colPorcentaje)
        Me.GridBand4.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.GridBand4.MinWidth = 20
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.VisibleIndex = 2
        Me.GridBand4.Width = 262
        '
        'colImporte
        '
        Me.colImporte.Caption = "Importe"
        Me.colImporte.FieldName = "Importe"
        Me.colImporte.Name = "colImporte"
        Me.colImporte.Visible = True
        Me.colImporte.Width = 133
        '
        'colMonedaId
        '
        Me.colMonedaId.Caption = "Moneda"
        Me.colMonedaId.FieldName = "MonedaId"
        Me.colMonedaId.Name = "colMonedaId"
        Me.colMonedaId.Visible = True
        Me.colMonedaId.Width = 129
        '
        'colPorcentaje
        '
        Me.colPorcentaje.Caption = "Porcentaje"
        Me.colPorcentaje.FieldName = "Porcentaje"
        Me.colPorcentaje.Name = "colPorcentaje"
        Me.colPorcentaje.RowIndex = 1
        Me.colPorcentaje.Visible = True
        Me.colPorcentaje.Width = 133
        '
        'colOrden
        '
        Me.colOrden.Caption = "Orden"
        Me.colOrden.FieldName = "Orden"
        Me.colOrden.Name = "colOrden"
        '
        'ParametroComisionVendedorListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "ParametroComisionVendedorListView"
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rislkArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lqsmsArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AdvBandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents colId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colArticuloId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents rislkArticulo As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colRubroId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colNivId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCargoId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFuncionarioId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colClienteId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colLocalId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colListaPreVtaId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colImporte As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colMonedaId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPorcentaje As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents lqsmsArticulo As DevExpress.Data.Linq.LinqServerModeSource
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colOrden As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
End Class
