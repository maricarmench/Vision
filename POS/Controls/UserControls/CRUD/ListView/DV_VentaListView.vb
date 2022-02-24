Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL
Imports DevExpress.XtraGrid.Columns
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.Controls.New.VentaListView
Imports DevExpress.Data
Imports Studio.Net.Controls.New

Public Class DV_VentaListView


#Region "CTor"

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = True

    End Sub

    Public Sub New(ByVal business As DocumentoSalidaBEntity)

        MyBase.New(business)

        InitializeComponent()

        business.SysFilterExpression = CrearFiltroParaMantenimientoDeVentas()

    End Sub

    Protected Overrides Sub BindGridInternal()
        MyBase.BindGridInternal()
        'MyDXGridView.Columns(DocumentoSalidaFieldIndex.RId.ToString()).SortOrder = DevExpress.Data.ColumnSortOrder.Descending

        'Dim cInfo As GridColumnSortInfo = MyDXGridView.SortInfo.Add(MyDXGridView.Columns(DocumentoSalidaFieldIndex.RId.ToString()), DevExpress.Data.ColumnSortOrder.Descending)
        'MyDXGridView.Columns(DocumentoSalidaFieldIndex.RId.ToString()).SortMode = DevExpress.XtraGrid.ColumnSortMode.Value

    End Sub

    Public Shared Function CrearFiltroParaMantenimientoDeVentas() As IRelationPredicateBucket
        Dim toReturn As New RelationPredicateBucket
        toReturn.PredicateExpression.Add(DocumentoSalidaFields.CajaId = ConfigReaderSpecific.GetCajaId())

        'toReturn.PredicateExpression.Add(DV_RecetaFields.Id = System.DBNull.Value)
        'Las ventas que no tienen recetas asociadas

        'toReturn.PredicateExpression.Add(New FieldCompareSetPredicate(DocumentoSalidaFields.Id, Nothing, DocumentoSalidaFields.Id, Nothing, SetOperator.Exist, DocumentoSalidaFields.Id = DV_RecetaFields.Id And DocumentoSalidaFields.CajaId = DV_RecetaFields.CajaId, True))
        Return toReturn
    End Function


    'Protected Overrides Sub OnFetchEntityCollection(da As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, ByRef colToFetch As SD.LLBLGen.Pro.ORMSupportClasses.IEntityCollection2, filter As SD.LLBLGen.Pro.ORMSupportClasses.IRelationPredicateBucket, sort As SD.LLBLGen.Pro.ORMSupportClasses.SortExpression, prefetch As SD.LLBLGen.Pro.ORMSupportClasses.IPrefetchPath2, fields As SD.LLBLGen.Pro.ORMSupportClasses.ExcludeIncludeFieldsList, pageIndex As Integer, pageSize As Integer)
    '    If sort Is Nothing OrElse sort.Count = 0 Then
    '        sort = DocumentoSalidaController.CrearSortPorIdDesc()
    '    End If
    '    'If filter Is Nothing Then
    '    '    filter = New RelationPredicateBucket
    '    'End If
    '    'filter.PredicateExpression.Add(DocumentoSalidaFields.CajaId = ConfigReaderSpecific.GetCajaId)
    '    BindingSource.DataSource = Nothing
    '    da.FetchEntityCollection(colToFetch, filter, 0I, sort, prefetch, fields, pageIndex, pageSize)
    '    BindingSource.DataSource = New DV_RecetaComunEntityCollection(colToFetch)
    '    GridControl.DataSource = BindingSource.DataSource
    '    'MyBase.OnFetchEntityCollection(da, colToFetch, filter, sort, prefetch, fields, pageIndex, pageSize)
    'End Sub

#End Region


    '#Region "HistoricoVentasDataTableViewMaster"

    '    Public Class DV_RecetaComunEntityCollection
    '        Inherits EntityCollection(Of DV_RecetaComunEntity)

    '        Protected Overrides Function CreateDefaultEntityView() As SD.LLBLGen.Pro.ORMSupportClasses.EntityView2(Of DV_RecetaComunEntity)
    '            Return New DV_RecetaComunEntityView(Me)
    '        End Function

    '        Public Sub New(source As EntityCollection)
    '            MyBase.New() '.ToList(Of DV_RecetaComunEntity))
    '            'Dim list As New List(Of DV_RecetaComunEntity)
    '            'list.AddRange()
    '            For Each documento As DV_RecetaComunEntity In source
    '                Add(documento)
    '            Next
    '            'MyBase.New(list)

    '            'MyBase.New(source.ToArray(Of DV_RecetaComunEntity))
    '            'AddRange()
    '        End Sub

    '    End Class

    '#End Region

    '    'Private Sub gvPago_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles gvPago.CustomUnboundColumnData

    '    '    If e.IsGetData Then
    '    '        Dim pago As DocSalida_PagoDocSalidaEntity = TryCast(e.Row, DocSalida_PagoDocSalidaEntity)
    '    '        If pago.DocumentoSalidaIdRecibo <> 0I Then

    '    '            If pago IsNot Nothing Then
    '    '                If pago.Recibo Is Nothing Then
    '    '                    Dim fields As New ExcludeIncludeFieldsList(False)
    '    '                    fields.Add(DV_RecetaComunFields.NumeroDocumento)
    '    '                    pago.Recibo = DocumentoSalidaController.BuscarPorId(Nothing, pago.DocumentoSalidaIdRecibo, pago.CajaIdRecibo, Nothing, fields)
    '    '                End If
    '    '                e.Value = pago.Recibo.NumeroDocumento ' DV_RecetaComunController.GetReciboIdentificacion(pago.DV_RecetaComunIdRecibo, pago.CajaIdRecibo)
    '    '            End If

    '    '        End If
    '    '    End If

    '    'End Sub

    '    Public Class HistoricoVentasEntityCollectionPago
    '        Inherits EntityCollection(Of DocSalida_PagoDocSalidaEntity)

    '        Protected Overrides Function CreateDefaultEntityView() As SD.LLBLGen.Pro.ORMSupportClasses.EntityView2(Of DocSalida_PagoDocSalidaEntity)
    '            Return New HistoricoVentasEntityViewPago(Me)
    '        End Function

    '    End Class

    '    Public Class DV_RecetaComunEntityView
    '        Inherits EntityView2(Of DV_RecetaComunEntity)
    '        Implements IRelationListEx

    '        Public Sub New(relatedCollection As EntityCollection(Of DV_RecetaComunEntity))
    '            MyBase.New(relatedCollection)
    '        End Sub


    '        Public Function GetDetailList(index As Integer, relationIndex As Integer) As System.Collections.IList Implements DevExpress.Data.IRelationList.GetDetailList
    '            Try
    '                Studio.Net.Helper.CursorManager.WaitCursor()

    '                Dim DV_RecetaComunId As Integer = Item(index).Id ' CType(Item(index )(DV_RecetaComunFieldIndex.Id.ToString()), Integer)
    '                Dim cajaId As Integer = Item(index).CajaId 'CType(Item(index)(DV_RecetaComunFieldIndex.CajaId.ToString()), Integer)

    '                If relationIndex = 0 Then
    '                    Return DocSalidaDetalleController.GetDetallesDeDocumento(cajaId, DV_RecetaComunId)
    '                ElseIf relationIndex = 1 Then

    '                    Dim toReturn As New HistoricoVentasEntityCollectionPago

    '                    If CType(Item(index).DocumentoTipoId, DocumentoTipo) = DocumentoTipo.Recibo Then
    '                        toReturn = DocSalida_PagoDocSalidaController.BuscarPagosDeRecibo(toReturn, Nothing, DV_RecetaComunId, cajaId)
    '                    Else
    '                        toReturn = DocSalida_PagoDocSalidaController.BuscarPagosDeDocumento(toReturn, DV_RecetaComunId, cajaId)
    '                    End If
    '                    Return toReturn
    '                End If

    '                Return Nothing

    '            Catch ex As Exception
    '                MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
    '            Finally
    '                Studio.Net.Helper.CursorManager.Default()
    '            End Try
    '        End Function

    '        Public Function GetRelationName(index As Integer, relationIndex As Integer) As String Implements DevExpress.Data.IRelationList.GetRelationName
    '            If relationIndex = 1 Then
    '                Return "Cobro"
    '            ElseIf relationIndex = 0 Then
    '                Return "Detalle"
    '            End If
    '            Return String.Empty
    '        End Function

    '        Public Function IsMasterRowEmpty(index As Integer, relationIndex As Integer) As Boolean Implements DevExpress.Data.IRelationList.IsMasterRowEmpty
    '            Return False
    '        End Function

    '        Public ReadOnly Property RelationCount As Integer Implements DevExpress.Data.IRelationList.RelationCount
    '            Get
    '                Return 2I
    '            End Get
    '        End Property

    '        Public Function GetRelationCount(index As Integer) As Integer Implements DevExpress.Data.IRelationListEx.GetRelationCount
    '            Return 2I
    '        End Function

    '        Public Function GetRelationDisplayName(index As Integer, relationIndex As Integer) As String Implements DevExpress.Data.IRelationListEx.GetRelationDisplayName
    '            Select Case relationIndex
    '                Case 0
    '                    Return "Detalles"
    '                Case 1
    '                    Return "Cobros"
    '            End Select
    '            Return String.Empty
    '        End Function
    '    End Class

    '    Public Class HistoricoVentasEntityViewPago
    '        Inherits EntityView2(Of DocSalida_PagoDocSalidaEntity)
    '        Implements IRelationListEx


    '        Public Sub New(relatedCollection As EntityCollection(Of DocSalida_PagoDocSalidaEntity))
    '            MyBase.New(relatedCollection)
    '        End Sub

    '        Public Function GetDetailList(index As Integer, relationIndex As Integer) As System.Collections.IList Implements DevExpress.Data.IRelationList.GetDetailList

    '            Try

    '                Studio.Net.Helper.CursorManager.WaitCursor()

    '                If Item(index).DocumentoSalidaIdRecibo > 0 Then

    '                    Dim fields As New ExcludeIncludeFieldsList(False)
    '                    fields.Add(DV_RecetaComunFields.DocumentoTipoId)
    '                    fields.Add(DV_RecetaComunFields.NumeroDocumento)


    '                    Return DocumentoSalidaController.BuscarPorRecibo(Nothing, Item(index).DocumentoSalidaIdRecibo, Item(index).CajaIdRecibo, fields)
    '                End If
    '            Catch ex As Exception
    '                MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
    '            Finally
    '                Studio.Net.Helper.CursorManager.Default()
    '            End Try

    '            Return Nothing

    '        End Function

    '        Public Function GetRelationName(index As Integer, relationIndex As Integer) As String Implements DevExpress.Data.IRelationList.GetRelationName
    '            Return "ReciboDocumento"
    '        End Function

    '        Public Function IsMasterRowEmpty(index As Integer, relationIndex As Integer) As Boolean Implements DevExpress.Data.IRelationList.IsMasterRowEmpty
    '            Return Item(index).DocumentoSalidaIdRecibo = 0
    '        End Function

    '        Public ReadOnly Property RelationCount As Integer Implements DevExpress.Data.IRelationList.RelationCount
    '            Get
    '                Return 1I
    '            End Get
    '        End Property

    '        Public Function GetRelationCount(index As Integer) As Integer Implements DevExpress.Data.IRelationListEx.GetRelationCount
    '            Return 1I
    '        End Function

    '        Public Function GetRelationDisplayName(index As Integer, relationIndex As Integer) As String Implements DevExpress.Data.IRelationListEx.GetRelationDisplayName
    '            Return "Documentos a asociados al recibo"
    '        End Function

    '    End Class

    'Protected Overrides Sub OnFetchEntityCollection(ByVal da As IDataAccessAdapter, ByRef colToFetch As IEntityCollection2, ByVal filter As IRelationPredicateBucket, ByVal sort As SortExpression, ByVal prefetch As IPrefetchPath2, ByVal fields As ExcludeIncludeFieldsList, ByVal pageIndex As Integer, ByVal pageSize As Integer)
    '    BindingSource.DataSource = Nothing
    '    da.FetchEntityCollection(colToFetch, filter, 0I, sort, prefetch, fields, pageIndex, pageSize)
    '    BindingSource.DataSource =New DV_RecetaComunEntityCollection( colToFetch)
    'End Sub


End Class


