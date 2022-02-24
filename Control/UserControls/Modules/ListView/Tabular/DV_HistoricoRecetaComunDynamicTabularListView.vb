Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Net.Controls.New
Imports Studio.Phone.DAL
Imports Studio.Phone.BLL
Imports Studio.Net.BLL
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Columns
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Net.BLL.Model
Imports Studio.Net.BLL.GraphTreeHelper
Imports DevExpress.XtraGrid
Imports Studio.Vision.BLL

Public Class DV_HistoricoRecetaComunDynamicTabularListView

    Private Const STR_COL_Recibo As String = "Recibo"

#Region "CTor"

    Public Sub New(rootEntity As DocumentoSalidaEntity)

        MyBase.New(rootEntity)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New()

        MyBase.New(New DocumentoSalidaEntity)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

    Protected Overrides Sub OnAddFields(fields As List(Of DynamicFieldMetaData))
        'Dim d As New DocumentoSalidaEntity

        fields.Add(New DynamicFieldMetaData(CajaIdFieldName, GetRootEntity(), "Caja Id.") With {.Hidden = True})
        fields.Add(New DynamicFieldMetaData(DocumentoTipoFieldName, GetRootEntity(), "Documento Tipo Id.") With {.Hidden = True})
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.TipoOperacion.ToString), GetRootEntity(), "Tipo operación") With {.EnumTypeName = GetType(RecetaComunOperacion).ToFullName()})
        fields.Add(New DynamicFieldMetaData(String.Format("Tipo.{0}", DV_RecetaTipoFieldIndex.Descripcion.ToString), GetRootEntity(), "Tipo de receta"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.VentaTipo.ToString), GetRootEntity(), "Tipo de venta") With {.EnumTypeName = GetType(RecetaVentaTipo).ToFullName()})
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.FechaEntrega.ToString), GetRootEntity(), "Fecha entrega"))
        fields.Add(New DynamicFieldMetaData(String.Format("DocumentoTipo.{0}", DocumentoTipoFieldIndex.Descripcion.ToString), GetRootEntity(), "Documento"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.NumeroDocumento.ToString), GetRootEntity(), "Número"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.FechaEmitida.ToString), GetRootEntity(), "Fecha Emitida"))
        fields.Add(New DynamicFieldMetaData(String.Format("Moneda.{0}", MonedaFieldIndex.Simbolo.ToString), GetRootEntity(), "Moneda"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.ImporteTotal.ToString), GetRootEntity(), "Total") With {.ApplySignoExpression = True})
        fields.Add(New DynamicFieldMetaData(String.Format("Cliente.{0}", ClienteFieldIndex.Descripcion.ToString), GetRootEntity(), "Cliente"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.Ruc.ToString), GetRootEntity(), "RUT"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.Direccion.ToString), GetRootEntity(), "Dirección"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.Nombre.ToString), GetRootEntity(), "Nombre"))
        fields.Add(New DynamicFieldMetaData(String.Format("Vendedor.{0}", FuncionarioFieldIndex.Descripcion.ToString()), GetRootEntity(), "Vendedor"))
        fields.Add(New DynamicFieldMetaData(String.Format("Caja.{0}", CajaFieldIndex.Descripcion.ToString), GetRootEntity(), "Caja"))
        fields.Add(New DynamicFieldMetaData(String.Format("Caja.Local.{0}", LocalFieldIndex.Descripcion.ToString), GetRootEntity(), "Local"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.ImporteSubTotal.ToString), GetRootEntity(), "Sub total") With {.ApplySignoExpression = True})
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.ImporteIVA.ToString), GetRootEntity(), "IVA") With {.ApplySignoExpression = True})
        fields.Add(New DynamicFieldMetaData(String.Format("ListaDePrecios.{0}", ListaPreVtaFieldIndex.Descripcion.ToString), GetRootEntity(), "Lista Precio"))
        fields.Add(New DynamicFieldMetaData(String.Format("Bonificacion.{0}", BonificacionFieldIndex.Descripcion.ToString), GetRootEntity(), "Bonificación"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.FechaIngresada.ToString), GetRootEntity(), "Fecha Ingreso"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.FechaCancelada.ToString), GetRootEntity(), "Fecha Cancelada"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.Observaciones.ToString), GetRootEntity(), "Observaciones"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.ImporteSaldoRestante.ToString), GetRootEntity(), "Saldo Restante") With {.ApplySignoExpression = True})
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.ImportePagoTotal.ToString), GetRootEntity(), "Importe pago total") With {.ApplySignoExpression = True})
        fields.Add(New DynamicFieldMetaData(DocumentoSalidaIdFieldName, GetRootEntity(), "Id."))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.FechaCreado.ToString), GetRootEntity(), "Fecha Creado"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.UsrCreador.ToString), GetRootEntity(), "Creado Por"))
        fields.Add(New DynamicFieldMetaData(SignoFieldName, GetRootEntity(), "Signo") With {.IsSignoField = True, .Hidden = True})
        fields.Add(New DynamicFieldMetaData(String.Format("Doctor.{0}", DV_DoctorFieldIndex.Descripcion.ToString), GetRootEntity(), "Doctor"))


    End Sub

    Private Shared ReadOnly Property DocumentoTipoFieldName() As String
        Get
            Return String.Format("{0}", DV_RecetaComunFieldIndex.DocumentoTipoId.ToString)
        End Get
    End Property


    Private Shared ReadOnly Property SignoFieldName() As String
        Get
            Return String.Format("DocumentoTipo.Signo.{0}", SignoFieldIndex.Valor.ToString)
        End Get
    End Property

    Private Shared ReadOnly Property CajaIdFieldName() As String
        Get
            Return String.Format("{0}", DV_RecetaComunFieldIndex.CajaId.ToString)
        End Get
    End Property


    Private Shared ReadOnly Property DocumentoSalidaIdFieldName() As String
        Get
            Return String.Format("{0}", DV_RecetaComunFieldIndex.Id.ToString)
        End Get
    End Property

    Private ReadOnly Property ArticuloIdFieldName() As String
        Get
            Return String.Format("Detalles.Articulo.{0}", ArticuloFieldIndex.Id.ToString)
        End Get
    End Property

    Private ReadOnly Property DepositoIdFieldName() As String
        Get
            Return String.Format("Detalles.{0}", DocSalidaDetalleFieldIndex.DepositoId.ToString)
        End Get
    End Property

    Protected Overrides Sub BindGridInternal()
        MyBase.BindGridInternal()
        With MyDXGridView
            .OptionsDetail.EnableMasterViewMode = True
            .OptionsBehavior.Editable = False
        End With
        With gvDetalle
            .OptionsBehavior.AutoPopulateColumns = False
            .OptionsView.ShowGroupPanel = False
            .OptionsView.ColumnAutoWidth = False
            .OptionsDetail.EnableMasterViewMode = False
            .OptionsBehavior.Editable = False
        End With
        With gvPago
            .OptionsBehavior.AutoPopulateColumns = False
            .OptionsView.ShowGroupPanel = False
            .OptionsView.ColumnAutoWidth = False
            .OptionsDetail.EnableMasterViewMode = True
            .OptionsBehavior.Editable = False
        End With
        With gvDocumentoRecibo
            .OptionsBehavior.AutoPopulateColumns = False
            .OptionsView.ShowGroupPanel = False
            .OptionsView.ColumnAutoWidth = False
            .OptionsDetail.EnableMasterViewMode = False
            .OptionsBehavior.Editable = False
        End With
        ConfigGrds()

    End Sub

    Private Sub ConfigGrds()
        With MainView
            .GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
            '.Columns(DV_RecetaComunFieldIndex.ImporteTotal.ToString()).Summary.Add(SummaryItemType.Sum, DV_RecetaComunFieldIndex.ImporteTotal.ToString(), "SUM={0:n2}")

            Dim item1 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item1.FieldName = DV_RecetaComunFieldIndex.ImporteTotal.ToString()
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item1.DisplayFormat = "SUM={0:n2}"
            item1.ShowInGroupColumnFooter = .Columns(DV_RecetaComunFieldIndex.ImporteTotal.ToString())
            MainView.GroupSummary.Add(item1)

        End With

        Dim fmtDetalle As New DevGridFormater(gvDetalle)
        Dim bsDetalle As New DocSalidaDetalleBEntity
        bsDetalle.Fields(DocSalidaDetalleFieldIndex.ArticuloId.ToString()).ForeignBEntityFactory = Nothing
        bsDetalle.Fields(DocSalidaDetalleFieldIndex.ArticuloId.ToString()).ForeignBEntity = Nothing
        fmtDetalle.Format(bsDetalle)

        Dim fmtCobro As New DevGridFormater(gvPago)
        fmtCobro.Format(New DocSalida_PagoDocSalidaBEntity)

        Dim reciboDocumentoFields As New List(Of FieldData)
        reciboDocumentoFields.Add(ModelManager.GetInstance().GetFieldData(GetRootEntity(), DV_RecetaComunFieldIndex.DocumentoTipoId))
        reciboDocumentoFields.Add(ModelManager.GetInstance().GetFieldData(GetRootEntity(), DV_RecetaComunFieldIndex.NumeroDocumento))

        Dim fmtReciboDocumento As New DevGridFormater(gvDocumentoRecibo)
        fmtReciboDocumento.Format(reciboDocumentoFields)

        Dim relacionFields As List(Of DynamicFieldMetaData) = GetRelacionFields()
        Dim fmtRelacion As New DevGridFormater(gvRelacion)
        fmtRelacion.Format(relacionFields.ToFieldDataList(New DocumentoSalidaRelacionEntity))

        Dim relacionesFields As List(Of DynamicFieldMetaData) = GetRelacionesFields()
        Dim fmtRelaciones As New DevGridFormater(gvRelaciones)
        fmtRelaciones.Format(relacionesFields.ToFieldDataList(New DocumentoSalidaRelacionEntity))

        With gvDetalle
            .Columns(DocSalidaDetalleFieldIndex.Numero.ToString()).VisibleIndex = 1
            .Columns(DocSalidaDetalleFieldIndex.ArticuloId.ToString()).VisibleIndex = 2
            .Columns(DocSalidaDetalleFieldIndex.Descripcion.ToString()).VisibleIndex = 3
            .Columns(DocSalidaDetalleFieldIndex.Cantidad.ToString()).VisibleIndex = 4
            .Columns(DocSalidaDetalleFieldIndex.Importe.ToString()).VisibleIndex = 5
            .Columns(DocSalidaDetalleFieldIndex.DatoExtra.ToString()).VisibleIndex = 6
            .Columns(DocSalidaDetalleFieldIndex.BonificacionId.ToString()).VisibleIndex = 7
            .Columns(DocSalidaDetalleFieldIndex.ListaPreVtaId.ToString()).VisibleIndex = 8

            For Each col As GridColumn In .Columns
                Select Case col.FieldName
                    Case DocSalidaDetalleFieldIndex.Numero.ToString(),
                        DocSalidaDetalleFieldIndex.Descripcion.ToString(),
                        DocSalidaDetalleFieldIndex.Importe.ToString(),
                        DocSalidaDetalleFieldIndex.Cantidad.ToString(),
                        DocSalidaDetalleFieldIndex.ArticuloId.ToString(),
                        DocSalidaDetalleFieldIndex.DatoExtra.ToString(),
                        DocSalidaDetalleFieldIndex.BonificacionId.ToString(),
                        DocSalidaDetalleFieldIndex.ListaPreVtaId.ToString()
                        col.Visible = True
                    Case Else
                        col.Visible = False
                End Select

            Next

        End With

        With gvPago

            .Columns(DocSalida_PagoDocSalidaFieldIndex.MonedaId.ToString()).VisibleIndex = 1
            .Columns(DocSalida_PagoDocSalidaFieldIndex.PlanFinancieroId.ToString()).VisibleIndex = 2
            .Columns(DocSalida_PagoDocSalidaFieldIndex.Importe.ToString()).VisibleIndex = 3
            .Columns(DocSalida_PagoDocSalidaFieldIndex.IdentificadorAtributos.ToString()).VisibleIndex = 4

            For Each col As GridColumn In .Columns
                Select Case col.FieldName
                    Case DocSalida_PagoDocSalidaFieldIndex.MonedaId.ToString(),
                        DocSalida_PagoDocSalidaFieldIndex.PlanFinancieroId.ToString(),
                        DocSalida_PagoDocSalidaFieldIndex.Importe.ToString(),
                        DocSalida_PagoDocSalidaFieldIndex.IdentificadorAtributos.ToString()
                        col.Visible = True
                    Case Else
                        col.Visible = False
                End Select

            Next

            Dim colRecibo As New GridColumn
            colRecibo.UnboundType = UnboundColumnType.String
            colRecibo.Name = "colRecibo"
            colRecibo.FieldName = colRecibo.Name
            colRecibo.Caption = STR_COL_Recibo
            colRecibo.Visible = True
            colRecibo.VisibleIndex = .Columns.Count
            .Columns.Add(colRecibo)

        End With

    End Sub

    Public Shared Function GetRelacionFields() As List(Of DynamicFieldMetaData)

        Dim relacionFields As New List(Of DynamicFieldMetaData)
        Dim rootEntity As New DocumentoSalidaRelacionEntity
        relacionFields.Add(New DynamicFieldMetaData(String.Format("VentaEnRelacion.DocumentoTipo.{0}", DocumentoTipoFieldIndex.Descripcion.ToString), rootEntity, "Documento"))
        relacionFields.Add(New DynamicFieldMetaData(String.Format("VentaEnRelacion.{0}", DV_RecetaComunFieldIndex.NumeroDocumento.ToString), rootEntity, "Nro."))
        relacionFields.Add(New DynamicFieldMetaData(String.Format("VentaEnRelacion.{0}", DV_RecetaComunFieldIndex.FechaEmitida.ToString), rootEntity, "Emisión"))
        relacionFields.Add(New DynamicFieldMetaData(String.Format("{0}", DocumentoSalidaRelacionFieldIndex.Tipo.ToString), rootEntity, "Tipo de rel."))
        Return relacionFields
    End Function

    Public Shared Function GetRelacionesFields() As List(Of DynamicFieldMetaData)
        Dim relacionFields As New List(Of DynamicFieldMetaData)
        Dim rootEntity As New DocumentoSalidaRelacionEntity
        relacionFields.Add(New DynamicFieldMetaData(String.Format("VentaRelacionada.DocumentoTipo.{0}", DocumentoTipoFieldIndex.Descripcion.ToString), rootEntity, "Documento"))
        relacionFields.Add(New DynamicFieldMetaData(String.Format("VentaRelacionada.{0}", DV_RecetaComunFieldIndex.NumeroDocumento.ToString), rootEntity, "Nro."))
        relacionFields.Add(New DynamicFieldMetaData(String.Format("VentaRelacionada.{0}", DV_RecetaComunFieldIndex.FechaEmitida.ToString), rootEntity, "Emisión"))
        relacionFields.Add(New DynamicFieldMetaData(String.Format("{0}", DocumentoSalidaRelacionFieldIndex.Tipo.ToString), rootEntity, "Tipo de rel."))
        Return relacionFields

    End Function

    'Protected Overrides Function OnGetDataTable() As System.Data.DataTable

    '    Dim toReturn As DataTable = TryCast(DataSource.DataSource, DataTable)
    '    If toReturn IsNot Nothing Then
    '        toReturn.Rows.Clear()
    '    End If
    '    toReturn = New HistoricoVentasDataTableMaster()
    '    Return toReturn

    'End Function

    Protected Overrides Sub OnFetchData(ByVal da As IDataAccessAdapter, ByVal filter As IRelationPredicateBucket, ByVal sort As SortExpression, ByVal prefetch As IPrefetchPath2, ByVal fields As ExcludeIncludeFieldsList, ByVal pageIndex As Integer, ByVal pageSize As Integer)

        Dim fieldsInfo As List(Of FilterFieldInfo) = GetFieldsInfo()


        GraphTreeHelper.AddRelationsAndSetAliases(_rootEntity, fieldsInfo, filter.Relations, False, _LastMirror)
        OnFetchingData(fieldsInfo, filter)

        Dim dt As DataTable = OnGetDataTable()

        If dt IsNot Nothing Then
            dt.Rows.Clear()
        Else
            dt = New DataTable
        End If
        Dim setFields As EntityFields2 = GetResultSetFields(fieldsInfo, filter.Relations)
        da.FetchTypedList(setFields, dt, filter, pageSize, sort, False, GetGroupBy(fieldsInfo, setFields), PageNumber, pageSize)
        'BindingSource.DataSource = dt

        GridControl.DataSource = New HistoricoVentasDataTableViewMaster(dt)

    End Sub

#Region "gvPagoDetalleViewMasterRow"

    'Private Sub gvPagoDetalle_MasterRowGetRelationCount(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles gvDetalle.MasterRowGetRelationCount
    '    e.RelationCount = 1

    'End Sub

    'Private Sub gvPagoDetalle_MasterRowGetRelatioName(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles gvDetalle.MasterRowGetRelationName

    '    Select Case e.RelationIndex
    '        Case 0
    '            e.RelationName = "Documentos"
    '    End Select

    'End Sub

    'Private Sub gvPagoDetalle_MasterRowIsEmpty(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles gvDetalle.MasterRowEmpty
    '    Try
    '        e.IsEmpty = True 'CType(MyDXGridView.GetRowCellValue(DirectCast(sender, GridView).SourceRowHandle, DocumentoTipoFieldName), DocumentoTipo) <> DocumentoTipo.Recibo
    '    Catch ex As Exception
    '        MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    'Private Sub gvPagoDetalle_MasterRowGetRelationDisplayCaption(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles gvDetalle.MasterRowGetRelationDisplayCaption
    '    e.RelationName = "Documentos"
    'End Sub

    'Private Sub gvPagoDetalle_MasterRowGetChildList(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles gvDetalle.MasterRowGetChildList

    '    'Studio.Net.Helper.CursorManager.WaitCursor()
    '    'Dim articuloId As Integer = gvPagoDetalle.GetRowCellValue(e.RowHandle, ArticuloIdFieldName)
    '    'Dim depositoId As Integer = gvPagoDetalle.GetRowCellValue(e.RowHandle, Deposito_ArticuloFieldIndex.DepositoId.ToString())
    '    'e.ChildList = Articulo_SerieController.BuscarPorDepositoYArticulo(depositoId, articuloId)
    '    'Studio.Net.Helper.CursorManager.Default()

    'End Sub

#End Region

#Region "HistoricoVentasDataTableViewMaster"

    Public Class HistoricoVentasDataTableViewMaster
        Inherits DataView
        Implements IRelationListEx

        Public Sub New(table As DataTable)
            MyBase.New(table)
        End Sub

        Public Function GetDetailList(index As Integer, relationIndex As Integer) As System.Collections.IList Implements DevExpress.Data.IRelationListEx.GetDetailList
            Try
                Studio.Net.Helper.CursorManager.WaitCursor()
                Dim documentoSalidaId As Integer = CType(Item(index)(DocumentoSalidaIdFieldName), Integer)
                Dim cajaId As Integer = CType(Item(index)(CajaIdFieldName), Integer)

                Select Case relationIndex
                    Case 0
                        Return DocSalidaDetalleController.GetDetallesDeDocumento(cajaId, documentoSalidaId)
                    Case 1
                        Dim toReturn As New HistoricoVentasEntityCollectionPago(New DocSalida_PagoDocSalidaEntityFactoryEx)
                        If CType(Item(index)(DocumentoTipoFieldName), DocumentoTipo) = DocumentoTipo.Recibo Then
                            toReturn = DocSalida_PagoDocSalidaController.BuscarPagosDeRecibo(toReturn, Nothing, documentoSalidaId, cajaId)
                        Else
                            toReturn = DocSalida_PagoDocSalidaController.BuscarPagosDeDocumento(toReturn, documentoSalidaId, cajaId)
                        End If
                        Return toReturn
                    Case 2

                        Dim rootEntity As New DocumentoSalidaRelacionEntity
                        Dim relacionFields As List(Of DynamicFieldMetaData) = GetRelacionFields()
                        Dim infos As List(Of FilterFieldInfo) = GraphTreeHelper.GetFilterFieldsInfoFromFieldFullNames(rootEntity, relacionFields.Select(Function(f) f.FieldPath).ToList())
                        Dim mirror As New PathMirror
                        Dim filtro As New RelationPredicateBucket
                        GraphTreeHelper.AddRelationsAndSetAliases(rootEntity, infos, filtro.Relations, False, mirror)
                        filtro.PredicateExpression.Add(DocumentoSalidaRelacionFields.DocumentoSalidaId2 = documentoSalidaId And DocumentoSalidaRelacionFields.CajaId2 = cajaId)

                        Dim toReturn As New DataTable
                        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                            da.FetchTypedList(infos.ToResultSetFields(mirror), toReturn, filtro)
                        End Using
                        Return toReturn.DefaultView

                    Case 3

                        Dim rootEntity As New DocumentoSalidaRelacionEntity
                        Dim relacionFields As List(Of DynamicFieldMetaData) = GetRelacionesFields()
                        Dim infos As List(Of FilterFieldInfo) = GraphTreeHelper.GetFilterFieldsInfoFromFieldFullNames(rootEntity, relacionFields.Select(Function(f) f.FieldPath).ToList())
                        Dim mirror As New PathMirror
                        Dim filtro As New RelationPredicateBucket
                        GraphTreeHelper.AddRelationsAndSetAliases(New DocumentoSalidaRelacionEntity, infos, filtro.Relations, False, mirror)
                        filtro.PredicateExpression.Add(DocumentoSalidaRelacionFields.DocumentoSalidaId1 = documentoSalidaId And DocumentoSalidaRelacionFields.CajaId1 = cajaId)

                        Dim toReturn As New DataTable
                        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                            da.FetchTypedList(infos.ToResultSetFields(mirror), toReturn, filtro)
                        End Using
                        Return toReturn.DefaultView

                End Select

                Return Nothing

            Catch ex As Exception
                MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            Finally
                Studio.Net.Helper.CursorManager.Default()
            End Try

        End Function

        Public Function GetRelationName(index As Integer, relationIndex As Integer) As String Implements DevExpress.Data.IRelationListEx.GetRelationName
            Select Case relationIndex
                Case 3
                    Return "Relaciones"
                Case 2
                    Return "Relacion"
                Case 1
                    Return "Cobro"
                Case 0
                    Return "Detalle"
                Case Else
                    Return String.Empty
            End Select
        End Function

        Public Function IsMasterRowEmpty(index As Integer, relationIndex As Integer) As Boolean Implements DevExpress.Data.IRelationListEx.IsMasterRowEmpty
            Return False
        End Function

        Public ReadOnly Property RelationCount As Integer Implements DevExpress.Data.IRelationListEx.RelationCount
            Get
                Return 4I
            End Get
        End Property

        Public Function GetRelacionCount(index As Integer) As Integer Implements IRelationListEx.GetRelationCount
            Return RelationCount
        End Function

        Public Function GetRelationDisplayName(index As Integer, relationIndex As Integer) As String Implements IRelationListEx.GetRelationDisplayName
            Select Case relationIndex
                Case 0
                    Return "Detalles"
                Case 1
                    Return "Cobros"
                Case 2
                    Return "Documentos dependientes"
                Case 3
                    Return "Documentos subordinadas"
            End Select
        End Function

    End Class

#End Region

    Private Sub gvPago_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles gvPago.CustomUnboundColumnData

        If e.IsGetData Then
            Dim pago As DocSalida_PagoDocSalidaEntity = TryCast(e.Row, DocSalida_PagoDocSalidaEntity)
            If pago.DocumentoSalidaIdRecibo <> 0I Then

                If pago IsNot Nothing Then
                    If pago.Recibo Is Nothing Then
                        Dim fields As New ExcludeIncludeFieldsList(False)
                        fields.Add(DocumentoSalidaFields.NumeroDocumento)
                        'fields.AddRange(New EntityFieldCore() {DocumentoSalidaFields.DocumentoTipoId, DocumentoSalidaFields.NumeroDocumento})

                        pago.Recibo = DocumentoSalidaController.BuscarPorId(Nothing, pago.DocumentoSalidaIdRecibo, pago.CajaIdRecibo, fields)
                    End If
                    If pago.Recibo IsNot Nothing Then
                        e.Value = pago.Recibo.NumeroDocumento ' DocumentoSalidaController.GetReciboIdentificacion(pago.DocumentoSalidaIdRecibo, pago.CajaIdRecibo)
                    End If
                End If

            End If
        End If

    End Sub

    Public Class HistoricoVentasEntityCollectionPago
        Inherits EntityCollection

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(entityFactoryToUse As IEntityFactory2)
            MyBase.New(entityFactoryToUse)
        End Sub

        Protected Overrides Function CreateDefaultEntityView() As EntityView2(Of EntityBase2)
            Return New HistoricoVentasEntityViewPago(Me)
        End Function
        'Protected Overrides Function CreateDefaultEntityView() As SD.LLBLGen.Pro.ORMSupportClasses.EntityView2()
        '    Return New HistoricoVentasEntityViewPago(Me)
        'End Function

        Protected Overloads Overrides Function GetEntityDescription(entity As EntityBase2, switchFlag As Boolean) As String

        End Function

        Protected Overloads Overrides Sub PerformAddToActiveContext(entity As EntityBase2)

        End Sub

        Protected Overloads Overrides Sub PerformSetRelatedEntity(entity As EntityBase2)

        End Sub

        Protected Overloads Overrides Sub PerformUnsetRelatedEntity(entity As EntityBase2)

        End Sub

        Protected Overloads Overrides Sub PlaceInRemovedEntitiesTracker(item As EntityBase2)

        End Sub
    End Class

    Public Class HistoricoVentasEntityViewPago
        Inherits EntityView2(Of EntityBase2)
        Implements IRelationListEx


        Public Sub New(relatedCollection As EntityCollection)
            MyBase.New(relatedCollection)
        End Sub

        Public Function GetDetailList(index As Integer, relationIndex As Integer) As System.Collections.IList Implements DevExpress.Data.IRelationList.GetDetailList

            Try

                Studio.Net.Helper.CursorManager.WaitCursor()
                Dim documento As DocSalida_PagoDocSalidaEntity = DirectCast(Item(index), DocSalida_PagoDocSalidaEntity)
                If documento.DocumentoSalidaIdRecibo > 0 Then

                    Dim fields As New ExcludeIncludeFieldsList(False)
                    fields.Add(DocumentoSalidaFields.DocumentoTipoId)
                    fields.Add(DocumentoSalidaFields.NumeroDocumento)
                    Return DocumentoSalidaController.BuscarPorRecibo(Nothing, documento.DocumentoSalidaIdRecibo, documento.CajaIdRecibo, fields)
                End If
            Catch ex As Exception
                MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            Finally
                Studio.Net.Helper.CursorManager.Default()
            End Try

            Return Nothing

        End Function

        Public Function GetRelationName(index As Integer, relationIndex As Integer) As String Implements DevExpress.Data.IRelationList.GetRelationName
            Return "ReciboDocumento"
        End Function

        Public Function IsMasterRowEmpty(index As Integer, relationIndex As Integer) As Boolean Implements DevExpress.Data.IRelationList.IsMasterRowEmpty
            Return DirectCast(Item(index), DocSalida_PagoDocSalidaEntity).DocumentoSalidaIdRecibo = 0
        End Function

        Public ReadOnly Property RelationCount As Integer Implements DevExpress.Data.IRelationList.RelationCount
            Get
                Return 1I
            End Get
        End Property

        Public Function GetRelationCount(index As Integer) As Integer Implements DevExpress.Data.IRelationListEx.GetRelationCount
            Return 1I
        End Function

        Public Function GetRelationDisplayName(index As Integer, relationIndex As Integer) As String Implements DevExpress.Data.IRelationListEx.GetRelationDisplayName
            Return "Documentos a asociados al recibo"
        End Function

    End Class

End Class
