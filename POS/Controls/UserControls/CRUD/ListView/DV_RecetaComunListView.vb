Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL
Imports DevExpress.XtraGrid.Columns
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.Controls.New.VentaListView
Imports DevExpress.Data
Imports Studio.Net.Controls.New
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Vision.POS.BLL.Business
Imports Studio.Net.Helper
Imports Studio.Phone.POS.Controls.New
Imports DevExpress.XtraGrid.Views.Grid

Public Class DV_RecetaComunListView

    Public Enum ViewMode
        Normal = 1
        Facturacion = 2
    End Enum

    Private _viewMode As ViewMode


#Region "CTor"

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = True
        ConfigGrid()

    End Sub

    Private Sub ConfigGrid()
        'GridControl.MyMainView.OptionsSelection.MultiSelect = True
        'GridControl.MyMainView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect

    End Sub

    Public Sub New(ByVal business As DV_RecetaComunBEntity)

        MyBase.New(business)

        InitializeComponent()
        business.SysFilterExpression = CrearFiltroParaMantenimientoDeVentas()

    End Sub

    Protected Overrides Sub BindGridInternal()

        GridControl.DoNotAddHiddenColumns = True
        MyBase.BindGridInternal()
        'MyDXGridView.Columns(DocumentoSalidaFieldIndex.RId.ToString()).SortOrder = DevExpress.Data.ColumnSortOrder.Descending

        'Dim cInfo As GridColumnSortInfo = MyDXGridView.SortInfo.Add(MyDXGridView.Columns(DocumentoSalidaFieldIndex.RId.ToString()), DevExpress.Data.ColumnSortOrder.Descending)
        'MyDXGridView.Columns(DocumentoSalidaFieldIndex.RId.ToString()).SortMode = DevExpress.XtraGrid.ColumnSortMode.Value

    End Sub

    Private Function CrearFiltroParaMantenimientoDeVentas() As IRelationPredicateBucket
        Dim toReturn As New RelationPredicateBucket
        toReturn.PredicateExpression.Add(DV_RecetaComunFields.CajaId = ConfigReaderSpecific.GetCajaId())
        If _viewMode = ViewMode.Facturacion Then
            toReturn.PredicateExpression.Add(DV_RecetaComunBEntity.CrearFiltroParaFacturacion())
        End If
        Return toReturn
    End Function

    Public Overrides Sub FilterByDescription(toFind As String)


        If String.IsNullOrEmpty(toFind) Then
            UserFilter = Nothing

        Else

            UserFilter = DV_RecetaComunBEntity.CrearFiltroParaSeach(toFind)

        End If
        LoadData(False)

    End Sub

    Protected Overrides Function OnGetPkField() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityField2
        Return DV_RecetaComunFields.Id
    End Function

    Public Property ActiveMode As ViewMode
        Get
            Return _viewMode
        End Get
        Set(value As ViewMode)
            ChangeViewMode(value)
        End Set
    End Property


#End Region

#Region "Procedimientos Privados"

    Private Sub ChangeViewMode(value As ViewMode)

        If value = _viewMode Then Return

        If value = ViewMode.Facturacion Then

            'If _selector IsNot Nothing Then
            '    _selector.Dispose()
            '    _selector = Nothing
            'End If

            MainView.OptionsSelection.MultiSelect = True
            MainView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect

            '_selector = New GridCheckMarksSelection(Of DV_RecetaComunEntity)()
            '_selector.View = Nothing
            '_selector.View = MyDXGridView
            '_selector.CheckMarkColumn.VisibleIndex = 0

            _viewMode = value
            BusinessEntity.SysFilterExpression = CrearFiltroParaMantenimientoDeVentas()

            LoadData(False)


        ElseIf value = ViewMode.Normal Then

            '    If _selector IsNot Nothing Then
            '    _selector.View = Nothing
            'End If



            _viewMode = value

            BusinessEntity.SysFilterExpression = CrearFiltroParaMantenimientoDeVentas()

            LoadData(False)
            MainView.OptionsSelection.MultiSelect = False
            MainView.OptionsBehavior.Editable = False

        End If

    End Sub

#End Region

#Region "Propiedades Publicas"

    'Public ReadOnly Property Selector As GridCheckMarksSelection(Of DV_RecetaComunEntity)
    '    Get
    '        Return _selector
    '    End Get
    'End Property

#End Region

#Region "Métodos Públicos"

    Public Function FacturarSeleccion(imprimir As Boolean) As Boolean

        Dim view As GridView = GridControl.MainView

        Using colToFacturar As New EntityCollection(Of DV_RecetaComunEntity)(view.GetSelectedRows(Of DV_RecetaComunEntity))
            '_selector.ClearSelection()

            view.ClearSelection()

            Using facturas As EntityCollection(Of DocumentoSalidaEntity) = DV_RecetaComunBEntity.FacturarCredito(colToFacturar)
                If imprimir Then
                    For Each factura As DocumentoSalidaEntity In facturas
                        If Not factura.Imprimible Then
                            Continue For
                        End If
                        If Caja_DocumentoTipoController.DocumentoImprimible(factura.DocumentoTipoId, factura.CajaId) Then
                            Dim documento As DocumentoSalidaEntity = DocumentoSalidaController.CrearDocumentoSalidaParaImpresion(factura.Id, factura.CajaId)
                            Dim report As New Studio.Phone.POS.BLL.Printing.DynamicReport
                            report.Proceso(documento)

                        End If
                    Next
                End If
            End Using
        End Using

        Return True

    End Function

#End Region

#Region "Overrides"

    Protected Overrides Sub OnEditModule(lModule As IListViewModule, view As GridView)
        If _viewMode = ViewMode.Normal Then
            MyBase.OnEditModule(lModule, view)
        End If
    End Sub

    Protected Overrides Sub SetearCamposEnNegativo(colToFetch As IEntityCollection2, filter As IRelationPredicateBucket)
        MyBase.SetearCamposEnNegativo(colToFetch, filter)
        colToFetch.EntityFactoryToUse = New DocumentoSalidaController.DV_RecetaComunConSignoEntityFactory() With {.SignoAlias = VentaListView.STR_SignoListView}
        'filter.Relations.Add(DocumentoSalidaEntity.Relations.DocumentoTipoEntityUsingDocumentoTipoId, STR_DocumentoTipoListView)
        'filter.Relations.Add(DocumentoTipoEntity.Relations.SignoEntityUsingSignoId, STR_DocumentoTipoListView, STR_SignoListView, JoinHint.Inner)
    End Sub
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        ChangeViewMode(ViewMode.Normal)
    End Sub

#End Region

End Class


