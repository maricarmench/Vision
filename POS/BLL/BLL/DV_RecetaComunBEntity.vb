Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports SD.LLBLGen.Pro.LinqSupportClasses
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL
Imports Studio.Net.BLL
Imports System
Imports Studio.Phone.POS.DAL.Linq
Imports System.Linq

Namespace Business
    <Serializable()> Public Class DV_RecetaComunBEntity
        Inherits DV_RecetaBEntity

#Region "Constantes"
        Public Const STR_FLAG_DISTANCIA_LEJOS As String = "l"
        Public Const STR_FLAG_DISTANCIA_CERCA As String = "c"
#End Region

#Region "CTor"
        Public Sub New()
            MyBase.New()
        End Sub
#End Region

#Region "Métodos Públicos"

        Public Shared Function GetRecetasParaImpresion(cajaId As Integer, Optional maxItems As Integer = 50) As EntityCollection(Of DV_RecetaComunEntity)
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
                Return GetRecetasParaImpresion(da, cajaId, maxItems)
            End Using
        End Function

        Public Shared Function GetRecetasParaImpresion(da As IDataAccessAdapter, cajaId As Integer, Optional maxItems As Integer = 50) As EntityCollection(Of DV_RecetaComunEntity)
            Dim db As New LinqMetaData(da)
            Dim q = (From r In db.DV_RecetaComun Where r.CajaId = cajaId AndAlso r.Impreso = False Select r).WithPath(CrearPrefetchParaImpresion()).OrderBy(Function(f) f.RId).Take(maxItems)
            Return CType(q, ILLBLGenProQuery).Execute(Of EntityCollection(Of DV_RecetaComunEntity))()
        End Function


        Public Shared Function GetRecetaParaImpresion(id As Integer, cajaId As Integer) As DV_RecetaComunEntity
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
                Return GetRecetaParaImpresion(da, id, cajaId)
            End Using
        End Function

        Public Shared Function GetRecetaParaImpresion(da As IDataAccessAdapter, id As Integer, cajaId As Integer) As DV_RecetaComunEntity
            Dim db As New LinqMetaData(da)
            Return (From r In db.DV_RecetaComun Where r.CajaId = cajaId AndAlso r.Id = id Select r).WithPath(CrearPrefetchParaImpresion()).Single()
        End Function

        Public Shared Function CrearMeParaDatosTaller() As DV_RecetaComunBEntity
            Dim toReturn As New DV_RecetaComunBEntity
            toReturn.Fields.ToList().ForEach(Function(f) f.Locked = False) 'Marcarmos todos los campos como editables
            Return toReturn
        End Function

        Public Shared Function GenerarRecetaDesdePresupuesto(presupuesto As DV_RecetaComunEntity) As DV_RecetaComunEntity

            If Not presupuesto.TipoOperacion = RecetaComunOperacion.Presupuesto Then
                Throw New ArgumentException("La receta no es un presupuesto", "presupuesto")
            End If

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                Dim toClone As DV_RecetaComunEntity = presupuesto.DeepClone()
                FetchRecetaParaDevolucion(toClone)
                Dim toReturn As DV_RecetaComunEntity = toClone.DeepClone()
                With toReturn
                    .TipoOperacion = RecetaComunOperacion.Venta
                    .NumeroDocumento = Tmp_DocumentoSalidaController.NumeroDocumentoMask
                    .Numero = String.Empty
                    .Fields(DV_RecetaComunFieldIndex.DocumentoTipoId).CurrentValue = Nothing
                    .FechaEmitida = System.DateTime.Today
                    .FechaIngresada = .FechaEmitida

                    .Detalles.AddRange(toClone.Detalles.ToList())

                End With
                Return toReturn
            End Using
        End Function
        Public Shared Sub FetchParaRecetaDePresupuesto(receta As DV_RecetaComunEntity)
            FetchDetalles(receta)
        End Sub
        Public Shared Sub FetchDetalles(receta As DV_RecetaComunEntity)

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                receta.Detalles.Clear()
                'receta.DocSalida_PagoDocSalida.Clear()
                Dim prefetch As New PrefetchPath2(CInt(EntityType.DV_RecetaComunEntity))
                prefetch.Add(DV_RecetaComunEntity.PrefetchPathDetalles)
                da.FetchEntity(receta, prefetch)

            End Using

        End Sub

        Public Shared Sub FetchRecetaParaDevolucion(receta As DV_RecetaComunEntity)

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                receta.Detalles.Clear()
                receta.Cobros.Clear()
                Dim prefetch As New PrefetchPath2(CInt(EntityType.DV_RecetaComunEntity))
                prefetch.Add(DV_RecetaComunEntity.PrefetchPathDetalles).SubPath.Add(DocSalidaDetalleEntity.PrefetchPathImpuestos)
                prefetch.Add(DV_RecetaComunEntity.PrefetchPathCobros)

                da.FetchEntity(receta, prefetch)

            End Using

        End Sub
        Public Shared Function Facturar(cajaId As Integer, receta As DV_RecetaComunEntity, pagoManager As PagoManager, fechaEmitida As Date, numeroDocumento As String) As EntityCollection(Of DocumentoSalidaEntity)

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

                Try

                    ImpuestoController.ImpuestoController = New ImpuestoRecetaController()
                    If RecetaFacturada(receta.CajaId, receta.Id) Then
                        Throw New InvalidOperationException(String.Format("La receta {0} ya fue facturada.", receta.NumeroDocumento))
                    End If
                    If receta.VentaTipo = RecetaVentaTipo.Contado Then
                        Return FacturarContado(cajaId, receta, pagoManager, fechaEmitida, numeroDocumento)
                    Else
                        Return FacturarCredito(receta, fechaEmitida, numeroDocumento)
                    End If

                Finally

                    ImpuestoController.ImpuestoController = Nothing


                End Try

            End Using

        End Function

        Public Shared Sub CambiarArticulos(recetaCambiada As DV_RecetaComunEntity, recetaOriginal As DV_RecetaComunEntity)

            Dim devolucionEy As New Tmp_DocumentoSalidaEntity
            Dim entregaEy As New Tmp_DocumentoSalidaEntity

            Studio.Net.Helper.DAL.EntityHelper.CopySameFields(recetaCambiada, devolucionEy, True)
            Studio.Net.Helper.DAL.EntityHelper.CopySameFields(recetaCambiada, entregaEy, True)


            devolucionEy.DocumentoTipoId = DocumentoTipo.DevolucionPorCambio
            devolucionEy.NumeroDocumento = Tmp_DocumentoSalidaController.NumeroDocumentoMask
            devolucionEy.NumeroMovimiento = 1I
            devolucionEy.Terminal = ConfigReaderSpecific.GetStringDeTerminal()
            devolucionEy.Id = -1
            devolucionEy.FechaEmitida = System.DateTime.Today
            devolucionEy.FechaIngresada = System.DateTime.Today


            entregaEy.NumeroMovimiento = 1I
            entregaEy.DocumentoTipoId = DocumentoTipo.EntregaPorCambio
            entregaEy.NumeroDocumento = Tmp_DocumentoSalidaController.NumeroDocumentoMask
            entregaEy.Terminal = ConfigReaderSpecific.GetStringDeTerminal()
            entregaEy.Id = -2
            entregaEy.FechaEmitida = System.DateTime.Today
            entregaEy.FechaIngresada = System.DateTime.Today

            Using colToDel As New EntityCollection(Of Tmp_DocSalidaDetalleEntity)()
                Using colToAdd As New EntityCollection(Of Tmp_DocSalidaDetalleEntity)()

                    Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

                        If recetaOriginal.OjoLejosDerechoCargado AndAlso recetaOriginal.CristalIdOjoLejosDerecho <> recetaCambiada.CristalIdOjoLejosDerecho Then
                            Dim detalle As DocSalidaDetalleEntity = recetaOriginal.Detalles.Where(Function(f) f.ArticuloId = recetaOriginal.CristalIdOjoLejosDerecho).First()
                            colToAdd.Add(New Tmp_DocSalidaDetalleEntity() With {.ArticuloCodigo = recetaCambiada.CristalIdOjoLejosDerecho.ToString(), .ArticuloId = recetaCambiada.CristalIdOjoLejosDerecho, .Descripcion = ArticuloController.DescripcionFullFromId(da, recetaCambiada.CristalIdOjoLejosDerecho), .Cantidad = Decimal.One, .ImporteUnitario = detalle.ImporteUnitario, .ListaPreVtaId = detalle.ListaPreVtaId, .Importe = detalle.ImporteUnitario, .Numero = colToAdd.Count + 1})
                            colToDel.Add(New Tmp_DocSalidaDetalleEntity() With {.ArticuloCodigo = recetaOriginal.CristalIdOjoLejosDerecho.ToString(), .ArticuloId = recetaOriginal.CristalIdOjoLejosDerecho, .Descripcion = detalle.Descripcion, .Cantidad = Decimal.One, .ImporteUnitario = detalle.ImporteUnitario, .ListaPreVtaId = detalle.ListaPreVtaId, .Importe = detalle.ImporteUnitario, .Numero = colToDel.Count + 1})
                            If detalle.BonificacionId > 0 Then
                                colToAdd(colToAdd.Count - 1).BonificacionId = detalle.BonificacionId
                                colToDel(colToDel.Count - 1).BonificacionId = detalle.BonificacionId
                            End If
                        End If
                        If recetaOriginal.OjoLejosIzquierdoCargado AndAlso recetaOriginal.CristalIdOjoLejosIzquierdo <> recetaCambiada.CristalIdOjoLejosIzquierdo Then
                            Dim detalle As DocSalidaDetalleEntity = recetaOriginal.Detalles.Where(Function(f) f.ArticuloId = recetaOriginal.CristalIdOjoLejosIzquierdo).First()
                            colToAdd.Add(New Tmp_DocSalidaDetalleEntity() With {.ArticuloCodigo = recetaCambiada.CristalIdOjoLejosIzquierdo.ToString(), .ArticuloId = recetaCambiada.CristalIdOjoLejosIzquierdo, .Descripcion = ArticuloController.DescripcionFullFromId(da, recetaCambiada.CristalIdOjoLejosIzquierdo), .Cantidad = Decimal.One, .ImporteUnitario = detalle.ImporteUnitario, .ListaPreVtaId = detalle.ListaPreVtaId, .Importe = detalle.ImporteUnitario, .Numero = colToAdd.Count + 1})
                            colToDel.Add(New Tmp_DocSalidaDetalleEntity() With {.ArticuloCodigo = recetaOriginal.CristalIdOjoLejosIzquierdo.ToString(), .ArticuloId = recetaOriginal.CristalIdOjoLejosIzquierdo, .Descripcion = detalle.Descripcion, .Cantidad = Decimal.One, .ImporteUnitario = detalle.ImporteUnitario, .ListaPreVtaId = detalle.ListaPreVtaId, .Importe = detalle.ImporteUnitario, .Numero = colToDel.Count + 1})
                            If detalle.BonificacionId > 0 Then
                                colToAdd(colToAdd.Count - 1).BonificacionId = detalle.BonificacionId
                                colToDel(colToDel.Count - 1).BonificacionId = detalle.BonificacionId
                            End If
                        End If
                        If recetaOriginal.OjoCercaDerechoCargado AndAlso recetaOriginal.CristalIdOjoCercaDerecho <> recetaCambiada.CristalIdOjoCercaDerecho Then
                            Dim detalle As DocSalidaDetalleEntity = recetaOriginal.Detalles.Where(Function(f) f.ArticuloId = recetaOriginal.CristalIdOjoCercaDerecho).First()
                            colToAdd.Add(New Tmp_DocSalidaDetalleEntity() With {.ArticuloCodigo = recetaCambiada.CristalIdOjoCercaDerecho.ToString(), .ArticuloId = recetaCambiada.CristalIdOjoCercaDerecho, .Descripcion = ArticuloController.DescripcionFullFromId(da, recetaCambiada.CristalIdOjoCercaDerecho), .Cantidad = Decimal.One, .ImporteUnitario = detalle.ImporteUnitario, .ListaPreVtaId = detalle.ListaPreVtaId, .Importe = detalle.ImporteUnitario, .Numero = colToAdd.Count + 1})
                            colToDel.Add(New Tmp_DocSalidaDetalleEntity() With {.ArticuloCodigo = recetaOriginal.CristalIdOjoCercaDerecho.ToString(), .ArticuloId = recetaOriginal.CristalIdOjoCercaDerecho, .Descripcion = detalle.Descripcion, .Cantidad = Decimal.One, .ImporteUnitario = detalle.ImporteUnitario, .ListaPreVtaId = detalle.ListaPreVtaId, .Importe = detalle.ImporteUnitario, .Numero = colToDel.Count + 1})
                            If detalle.BonificacionId > 0 Then
                                colToAdd(colToAdd.Count - 1).BonificacionId = detalle.BonificacionId
                                colToDel(colToDel.Count - 1).BonificacionId = detalle.BonificacionId
                            End If
                        End If
                        If recetaOriginal.OjoCercaIzquierdoCargado AndAlso recetaOriginal.CristalIdOjoCercaIzquierdo <> recetaCambiada.CristalIdOjoCercaIzquierdo Then
                            Dim detalle As DocSalidaDetalleEntity = recetaOriginal.Detalles.Where(Function(f) f.ArticuloId = recetaOriginal.CristalIdOjoCercaIzquierdo).First()
                            colToAdd.Add(New Tmp_DocSalidaDetalleEntity() With {.ArticuloCodigo = recetaCambiada.CristalIdOjoCercaIzquierdo.ToString(), .ArticuloId = recetaCambiada.CristalIdOjoCercaIzquierdo, .Descripcion = ArticuloController.DescripcionFullFromId(da, recetaCambiada.CristalIdOjoCercaIzquierdo), .Cantidad = Decimal.One, .ImporteUnitario = detalle.ImporteUnitario, .ListaPreVtaId = detalle.ListaPreVtaId, .Importe = detalle.ImporteUnitario, .Numero = colToAdd.Count + 1})
                            colToDel.Add(New Tmp_DocSalidaDetalleEntity() With {.ArticuloCodigo = recetaOriginal.CristalIdOjoCercaIzquierdo.ToString(), .ArticuloId = recetaOriginal.CristalIdOjoCercaIzquierdo, .Descripcion = detalle.Descripcion, .Cantidad = Decimal.One, .ImporteUnitario = detalle.ImporteUnitario, .ListaPreVtaId = detalle.ListaPreVtaId, .Importe = detalle.ImporteUnitario, .Numero = colToDel.Count + 1})
                            If detalle.BonificacionId > 0 Then
                                colToAdd(colToAdd.Count - 1).BonificacionId = detalle.BonificacionId
                                colToDel(colToDel.Count - 1).BonificacionId = detalle.BonificacionId
                            End If
                        End If
                        If colToAdd.Count = 0 Then
                            Throw New InvalidOperationException("No se detectaron cambios de artículos.")
                        End If

                        entregaEy.Detalles.AddRange(colToAdd)
                        devolucionEy.Detalles.AddRange(colToDel)

                        entregaEy.ImporteTotal = entregaEy.Detalles.Sum(Function(f) f.Importe)
                        devolucionEy.ImporteTotal = devolucionEy.Detalles.Sum(Function(f) f.Importe)

                        da.StartTransaction(IsolationLevel.ReadCommitted, "trn")

                        Tmp_DocumentoSalidaController.LimpiarTemporales(da)

                        da.SaveEntity(entregaEy, True, True)
                        da.SaveEntity(devolucionEy, True, True)

                        da.SaveEntity(New Tmp_DocumentoRelacionEntity With {.DocumentoSalidaIdPadre = recetaOriginal.Id, .CajaIdPadre = recetaOriginal.CajaId, .DocumentoSalidaIdHijo = entregaEy.Id, .CajaIdHijo = entregaEy.CajaId, .Tipo = DocumentoSalidaRelacion.CambioDeArticulos, .Terminal = ConfigReaderSpecific.GetStringDeTerminal(), .TerminalHijo = .TerminalHijo, .TerminalPadre = .Terminal})
                        da.SaveEntity(New Tmp_DocumentoRelacionEntity With {.DocumentoSalidaIdPadre = recetaOriginal.Id, .CajaIdPadre = recetaOriginal.CajaId, .DocumentoSalidaIdHijo = devolucionEy.Id, .CajaIdHijo = devolucionEy.CajaId, .Tipo = DocumentoSalidaRelacion.CambioDeArticulos, .Terminal = ConfigReaderSpecific.GetStringDeTerminal(), .TerminalHijo = .TerminalHijo, .TerminalPadre = .Terminal})


                        DocumentoSalidaController.GrabarDocumentoSalidaTemporalADefinitiva(da, False, String.Empty, System.DateTime.MinValue, String.Empty, Nothing, Nothing, Nothing)

                        da.Commit()

                    End Using

                End Using

            End Using

        End Sub

        Public Shared Function FacturarCredito(recetas As EntityCollection(Of DV_RecetaComunEntity), fechaEmitida As Date, numeroDocumento As String) As EntityCollection(Of DocumentoSalidaEntity)

            If recetas.Count = 0 Then Return Nothing
            If recetas.Any(Function(f) f.VentaTipo = RecetaVentaTipo.Contado) Then
                Throw New InvalidOperationException("La órdenes al contado se deben facturar de a una.")
            End If

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                Try
                    If recetas.Any(Function(f) f.FechaFacturada > System.DateTime.MinValue) Then
                        Throw New InvalidOperationException(String.Format("La receta {0} ya fue facturada.", recetas.First(Function(f) f.FechaFacturada > System.DateTime.MinValue).NumeroDocumento))
                    End If
                    da.StartTransaction(IsolationLevel.Serializable, "trn")
                    Dim toReturn As EntityCollection(Of DocumentoSalidaEntity) = DocumentoSalidaController.FacturarOrdenes(da, New EntityCollection(Of DocumentoSalidaEntity)(recetas.Select(Function(f) DirectCast(f, DocumentoSalidaEntity)).ToList()), DocumentoTipo.Credito, DocumentoTipo.NotaCredito, fechaEmitida, numeroDocumento)

                    For Each receta As DV_RecetaComunEntity In recetas
                        'Volvemos a chequear que la receta no esté facturada. Este caso es contra la base de datos
                        'Ya que puede haberse facturado desde otra terminal
                        If DV_RecetaBEntity.RecetaFacturada(da, receta.CajaId, receta.Id) Then
                            Throw New InvalidOperationException(String.Format("La receta {0} ya fue facturada.", recetas.First(Function(f) f.FechaFacturada > System.DateTime.MinValue).NumeroDocumento))
                        End If
                        'receta.SaveFields("facturacion")
                        receta.FechaFacturada = System.DateTime.Now
                        da.FetchEntityCollection(receta.VentasEnRelacion, receta.GetRelationInfoVentasEnRelacion())
                        Dim relacion As DocumentoSalidaRelacionEntity = receta.VentasEnRelacion.Where(Function(f) f.Tipo = DocumentoSalidaRelacion.FacturacionDeOrdenDeVenta).Single()
                        relacion.PermiteBorrarDocumento2 = True
                        relacion.CamposModificados.Add(New DocumentoSalidaRelacion_CampoModificadoEntity With {.Relacion = relacion, .Nombre = DV_RecetaFieldIndex.FechaFacturada.ToString()})
                        da.SaveEntity(relacion, True)
                    Next
                    da.SaveEntityCollection(recetas, True, False)

                    da.Commit()

                    Return toReturn

                Catch ex As Exception
                    If da.IsTransactionInProgress Then
                        da.Rollback()
                    End If
                    'recetas.ToList().ForEach(Sub(f) f.RollbackFields("facturacion"))
                    Throw
                Finally
                    da.Dispose()
                End Try

            End Using

        End Function

        Public Shared Function FacturarCredito(recetas As EntityCollection(Of DV_RecetaComunEntity)) As EntityCollection(Of DocumentoSalidaEntity)
            Return FacturarCredito(recetas, System.DateTime.MinValue, Nothing)
        End Function

        Public Shared Function CrearFiltroParaFacturacion() As PredicateExpression
            Return New PredicateExpression(DV_RecetaComunFields.FechaFacturada = System.DBNull.Value And DV_RecetaComunFields.TipoOperacion = RecetaComunOperacion.Venta And DV_RecetaComunFields.VentaTipo = RecetaVentaTipo.Credito)
        End Function

        Public Shared Function CrearFiltroParaSeach(toFind As String) As IRelationPredicateBucket

            Dim toReturn As New RelationPredicateBucket
            'toReturn.Relations.Add(DV_RecetaComunEntity.Relations.GetSuperTypeRelation())
            'toReturn.Relations.Add(DV_RecetaEntity.Relations.GetSuperTypeRelation())

            If IsNumeric(toFind) Then

                toReturn.PredicateExpression.AddWithOr(New FieldCompareSetPredicate(DV_RecetaComunFields.ClienteId, Nothing, ClienteEmpresaFields.Id, Nothing, SetOperator.Exist,
                                            ClienteEmpresaFields.Ruc = toFind And DV_RecetaComunFields.ClienteId = ClienteEmpresaFields.Id))
                If toFind.Length <= 8 Then
                    toReturn.PredicateExpression.AddWithOr(New FieldCompareSetPredicate(DV_RecetaComunFields.ClienteId, Nothing, ClienteParticularFields.Id, Nothing, SetOperator.Exist,
                                                          ClienteParticularFields.DocumentoIdentidad = Decimal.Parse(toFind) And DV_RecetaComunFields.ClienteId = ClienteParticularFields.Id))
                End If

                toReturn.PredicateExpression.AddWithOr(New FieldLikePredicate(DV_RecetaComunFields.NumeroDocumento, Nothing, "%" & toFind))
                toReturn.PredicateExpression.AddWithOr(DV_RecetaFields.ClienteIdentificacion = Int32.Parse(toFind))

            Else

                If IsDate(toFind) Then

                    toReturn.PredicateExpression.AddWithOr(DV_RecetaComunFields.FechaIngresada = Date.Parse(toFind))
                    toReturn.PredicateExpression.AddWithOr(DV_RecetaComunFields.FechaEmitida = Date.Parse(toFind))

                Else

                    toReturn.PredicateExpression.AddWithOr(New FieldLikePredicate(DV_RecetaComunFields.NumeroDocumento, Nothing, String.Format("%{0}%", toFind)))

                    toReturn.PredicateExpression.AddWithOr(New FieldCompareSetPredicate(DV_RecetaComunFields.ClienteId, Nothing, ClienteEmpresaFields.Id, Nothing, SetOperator.Exist,
                                               New FieldLikePredicate(ClienteEmpresaFields.NombreFantasia, Nothing, String.Format("%{0}%", toFind)) And DV_RecetaComunFields.ClienteId = ClienteEmpresaFields.Id))

                    toReturn.PredicateExpression.AddWithOr(New FieldCompareSetPredicate(DV_RecetaComunFields.ClienteId, Nothing, ClienteFields.Id, Nothing, SetOperator.Exist,
                                             New FieldLikePredicate(ClienteFields.Descripcion, Nothing, String.Format("%{0}%", toFind)) And DV_RecetaComunFields.ClienteId = ClienteFields.Id))

                    toReturn.PredicateExpression.AddWithOr(New FieldLikePredicate(DV_RecetaComunFields.Numero, Nothing, String.Format("%{0}%", toFind)))

                End If

            End If


            Return toReturn
        End Function

        Public Shared Function CrearBusinessParaListView() As DV_RecetaComunBEntity
            Dim toReturn As DV_RecetaComunBEntity = CrearParaMantenimiento()
            Dim fieldsToShow As String() = New String() {DV_RecetaComunFieldIndex.Id.ToString(),
                                                         DV_RecetaComunFieldIndex.RecetaComunTipo.ToString(),
                                                         DV_RecetaComunFieldIndex.VentaTipo.ToString(),
                                                         DV_RecetaComunFieldIndex.TipoOperacion.ToString(),
                                                         DV_RecetaComunFieldIndex.DocumentoTipoId.ToString(),
                                                         DV_RecetaComunFieldIndex.NumeroDocumento.ToString(),
                                                         DV_RecetaComunFieldIndex.ClienteId.ToString(),
                                                         DV_RecetaComunFieldIndex.FechaEmitida.ToString(),
                                                         DV_RecetaComunFieldIndex.FechaIngresada.ToString(),
                                                         DV_RecetaComunFieldIndex.MonedaId.ToString(),
                                                         DV_RecetaComunFieldIndex.ImporteTotal.ToString(),
                                                         DV_RecetaComunFieldIndex.FechaFacturada.ToString(),
                                                         DV_RecetaComunFieldIndex.FechaEntrega.ToString()}
            For Each item As IBEField In toReturn.Fields
                Dim name As String = item.Name
                item.Displayable = fieldsToShow.Any(Function(f) f = name)
            Next
            Return toReturn
        End Function

        Public Shared Function CrearTmpDocumentoSalida(ByVal receta As DV_RecetaComunEntity, parametro As VisionParametroTree) As Tmp_DocumentoSalidaEntity


            'Dim documentoTipoId As Integer
            If receta.DocumentoTipoId = 0 Then
                If receta.TipoOperacion = RecetaComunOperacion.Presupuesto Then
                    receta.DocumentoTipoId = CInt(DocumentoTipo.Presupuesto)
                Else

                    If receta.Devolucion Then
                        receta.DocumentoTipoId = DocumentoTipo.DevolucionRecetaComun
                    Else
                        receta.DocumentoTipoId = DocumentoTipo.RecetaComun
                    End If
                End If
            End If

            'receta.DocumentoTipoId = documentoTipoId

            receta.MovimientoArticulos = (receta.TipoOperacion = CInt(RecetaComunOperacion.Venta))
            'receta.CajaId = receta.CajaId

            'If receta.TipoOperacion = RecetaComunOperacion.Presupuesto OrElse (receta.VentaTipo = RecetaVentaTipo.Contado AndAlso DirectCast(ParametroSistemaController.GetParametroTree(), VisionParametroTree).Optica.Venta.FacturarRecetaContadoAutomaticamente) Then
            receta.FechaEmitida = System.DateTime.Today
            receta.NumeroDocumento = Tmp_DocumentoSalidaController.NumeroDocumentoMask
            'receta.FechaFacturada = System.DateTime.Today
            'End If

            receta.FechaIngresada = System.DateTime.Today

            receta.Id = -1
            'receta.NumeroDocumento = Tmp_DocumentoSalidaController.NumeroDocumentoMask
            If receta.LocalId = 0 Then
                receta.LocalId = LocalController.BuscarLocalIdFromCaja(receta.CajaId)
            End If
            Dim toReturn As New Tmp_DocumentoSalidaEntity
            Studio.Net.Helper.DAL.EntityHelper.CopySameFields(receta, toReturn, True)
            toReturn.Terminal = ConfigReaderSpecific.GetStringDeTerminal()

            toReturn.NumeroMovimiento = 1I

            For Each detalle As DocSalidaDetalleEntity In receta.Detalles

                Dim toAdd As New Tmp_DocSalidaDetalleEntity

                Studio.Net.Helper.DAL.EntityHelper.CopySameFields(detalle, toAdd, True)


                'For Each impuesto As DocSalidaDetalle_ImpuestoEntity In detalle.Impuestos
                '    Dim tmpImpuesto As New Tmp_DocSalidaDetalle_ImpuestoEntity
                '    Studio.Net.Helper.DAL.EntityHelper.CopySameFields(impuesto, tmpImpuesto, True)
                '    toAdd.Tmp_DocSalidaDetalle_Impuesto.Add(tmpImpuesto)
                'Next

                toReturn.Detalles.Add(toAdd)

            Next

            Return toReturn

        End Function

        Public Shared Function SaveReceta(ByRef receta As DV_RecetaComunEntity, manager As PagoManager) As IEntityCollection2

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

                da.StartTransaction(IsolationLevel.ReadCommitted, "trn")

                Try

                    'Eliminar el detalle porque se va a dar en el método GrabarDocumentoSalidaTemporalADefinitiva
                    'en caso contrario daría valores duplicados

                    receta.Detalles.Clear()

                    Dim numeroRecibo As String = String.Empty
                    Dim fechaRecibo As Date = Date.MinValue
                    Dim obsRecibo As String = String.Empty

                    If manager IsNot Nothing Then
                        numeroRecibo = manager.NumeroRecibo
                        fechaRecibo = manager.FechaCotizacion
                        obsRecibo = manager.ObsRecibo
                    End If
                    Dim savedCol As IEntityCollection2
                    Try

                        'Sobrescribir los impuestos de la receta común, todos a la tasa mínima.
                        ImpuestoController.ImpuestoController = New ImpuestoRecetaController()

                        savedCol = DocumentoSalidaController.GrabarDocumentoSalidaTemporalADefinitiva(da, True, numeroRecibo,
                                                                            fechaRecibo, obsRecibo, Nothing, Nothing, manager, New MyRecetaComunFactory(receta))

                    Finally
                        ImpuestoController.ImpuestoController = Nothing
                    End Try
                    da.Commit()

                    receta = savedCol(0)

                    Return savedCol

                Catch ex As Exception
                    If da.IsTransactionInProgress Then
                        da.Rollback()
                    End If
                    Throw
                End Try
            End Using

        End Function
        Public Shared Function CreateNewEntity() As DV_RecetaComunEntity
            Dim toReturn As New DV_RecetaComunEntity
            'toReturn.Numero =entity.Numero = DV_RecetaBEntity.GetNumero(AdapterToUse, entity)
            Return toReturn
        End Function

        Public Shared Function CrearParaMantenimiento() As DV_RecetaComunBEntity

            Dim toReturn As New DV_RecetaComunBEntity
            toReturn.Fields(DV_RecetaComunFieldIndex.EjeOjoCercaDerecho.ToString()).DisplayDescription = "Eje"
            toReturn.Fields(DV_RecetaComunFieldIndex.EjeOjoCercaIzquierdo.ToString()).DisplayDescription = "Eje"
            toReturn.Fields(DV_RecetaComunFieldIndex.EjeOjoLejosDerecho.ToString()).DisplayDescription = "Eje"
            toReturn.Fields(DV_RecetaComunFieldIndex.EjeOjoLejosIzquierdo.ToString()).DisplayDescription = "Eje"
            toReturn.Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaDerecho.ToString()).DisplayDescription = "Cilíndrico"
            toReturn.Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaIzquierdo.ToString()).DisplayDescription = "Cilíndrico"
            toReturn.Fields(DV_RecetaComunFieldIndex.CilindricoOjoLejosDerecho.ToString()).DisplayDescription = "Cilíndrico"
            toReturn.Fields(DV_RecetaComunFieldIndex.CilindricoOjoLejosIzquierdo.ToString()).DisplayDescription = "Cilíndrico"
            toReturn.Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaDerecho.ToString()).DisplayDescription = "Esférico"
            toReturn.Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaIzquierdo.ToString()).DisplayDescription = "Esférico"
            toReturn.Fields(DV_RecetaComunFieldIndex.EsfericoOjoLejosDerecho.ToString()).DisplayDescription = "Esférico"
            toReturn.Fields(DV_RecetaComunFieldIndex.EsfericoOjoLejosIzquierdo.ToString()).DisplayDescription = "Esférico"
            toReturn.Fields(DV_RecetaComunFieldIndex.AdicionOjoLejosDerecho.ToString()).DisplayDescription = "Adición"
            toReturn.Fields(DV_RecetaComunFieldIndex.AdicionOjoLejosIzquierdo.ToString()).DisplayDescription = "Adición"
            toReturn.Fields(DV_RecetaComunFieldIndex.DistanciaOjoCercaDerecho.ToString()).DisplayDescription = "Distancia"
            toReturn.Fields(DV_RecetaComunFieldIndex.DistanciaOjoCercaIzquierdo.ToString()).DisplayDescription = "Distancia"
            toReturn.Fields(DV_RecetaComunFieldIndex.DistanciaOjoLejosDerecho.ToString()).DisplayDescription = "Distancia"
            toReturn.Fields(DV_RecetaComunFieldIndex.DistanciaOjoLejosIzquierdo.ToString()).DisplayDescription = "Distancia"
            toReturn.Fields(DV_RecetaComunFieldIndex.AlturaOjoCercaDerecho.ToString()).DisplayDescription = "Altura"
            toReturn.Fields(DV_RecetaComunFieldIndex.AlturaOjoCercaIzquierdo.ToString()).DisplayDescription = "Altura"
            toReturn.Fields(DV_RecetaComunFieldIndex.AlturaOjoLejosDerecho.ToString()).DisplayDescription = "Altura"
            toReturn.Fields(DV_RecetaComunFieldIndex.AlturaOjoLejosIzquierdo.ToString()).DisplayDescription = "Altura"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaOjoCercaDerecho.ToString()).DisplayDescription = "Prisma"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaOjoCercaIzquierdo.ToString()).DisplayDescription = "Prisma"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaOjoLejosDerecho.ToString()).DisplayDescription = "Prisma"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaOjoLejosIzquierdo.ToString()).DisplayDescription = "Prisma"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoCercaDerecho.ToString()).DisplayDescription = "º"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoCercaIzquierdo.ToString()).DisplayDescription = "º"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoLejosDerecho.ToString()).DisplayDescription = "º"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoLejosIzquierdo.ToString()).DisplayDescription = "º"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoCercaDerecho.ToString()).DisplayDescription = "Base"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoCercaIzquierdo.ToString()).DisplayDescription = "Base"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoLejosDerecho.ToString()).DisplayDescription = "Base"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoLejosIzquierdo.ToString()).DisplayDescription = "Base"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdCercaDerecho.ToString()).DisplayDescription = "Material"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdCercaIzquierdo.ToString()).DisplayDescription = "Material"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdLejosDerecho.ToString()).DisplayDescription = "Material"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdLejosIzquierdo.ToString()).DisplayDescription = "Material"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalIdCercaDerecho.ToString()).DisplayDescription = "Producto"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString()).DisplayDescription = "Producto"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalIdCercaIzquierdo.ToString()).DisplayDescription = "Producto"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalIdLejosIzquierdo.ToString()).DisplayDescription = "Producto"

            toReturn.Fields(DV_RecetaComunFieldIndex.ClienteId.ToString()).DisplayDescription = "SELECCIÓN POR NOMBRE:"
            toReturn.Fields(DV_RecetaComunFieldIndex.ClienteIdentificacion.ToString()).DisplayDescription = "ID. CLIENTE (CI/RUT/ID):"

            toReturn.Fields(DV_RecetaComunFieldIndex.ArmazonIdCerca.ToString()).ForeignBEntityFactory = New DV_ArmazonBEntityFactory
            toReturn.Fields(DV_RecetaComunFieldIndex.ArmazonIdLejos.ToString()).ForeignBEntityFactory = New DV_ArmazonBEntityFactory

            toReturn.Fields(DV_RecetaComunFieldIndex.DocumentoTipoId.ToString()).Locked = True
            toReturn.Fields(DV_RecetaComunFieldIndex.NumeroDocumento.ToString()).Locked = True
            toReturn.Fields(DV_RecetaComunFieldIndex.DocumentoTipoId.ToString()).EditMode = BEFieldEditMode.ReadOnly
            toReturn.Fields(DV_RecetaComunFieldIndex.NumeroDocumento.ToString()).EditMode = BEFieldEditMode.ReadOnly


            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoCercaDerecho.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoCercaIzquierdo.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoLejosDerecho.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoLejosIzquierdo.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoCercaDerecho.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoCercaIzquierdo.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoLejosDerecho.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoLejosIzquierdo.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoCercaDerecho.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoCercaIzquierdo.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoLejosDerecho.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoLejosIzquierdo.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoCercaDerecho.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoCercaIzquierdo.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoLejosDerecho.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoLejosIzquierdo.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.AireTipoArmadoCerca.ToString()).DisplayDescription = "Aire"
            toReturn.Fields(DV_RecetaComunFieldIndex.AireTipoArmadoLejos.ToString()).DisplayDescription = "Aire"
            toReturn.Fields(DV_RecetaComunFieldIndex.EnteroTipoArmadoCerca.ToString()).DisplayDescription = "Entero"
            toReturn.Fields(DV_RecetaComunFieldIndex.EnteroTipoArmadoLejos.ToString()).DisplayDescription = "Entero"
            toReturn.Fields(DV_RecetaComunFieldIndex.RanuraTipoArmadoCerca.ToString()).DisplayDescription = "Ranurado"
            toReturn.Fields(DV_RecetaComunFieldIndex.RanuraTipoArmadoLejos.ToString()).DisplayDescription = "Ranurado"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoCercaIzquierdo.ToString()).DisplayDescription = "Base O.I."
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoLejosIzquierdo.ToString()).DisplayDescription = "Base O.I."
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoCercaDerecho.ToString()).DisplayDescription = "Base O.D."
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoLejosDerecho.ToString()).DisplayDescription = "Base O.D."

            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadArmazonCerca.ToString()).DisplayDescription = "Cantidad"
            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadArmazonLejos.ToString()).DisplayDescription = "Cantidad"
            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadOjoCercaDerecho.ToString()).DisplayDescription = "Cantidad"
            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadOjoCercaIzquierdo.ToString()).DisplayDescription = "Cantidad"
            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadOjoLejosDerecho.ToString()).DisplayDescription = "Cantidad"
            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadOjoLejosIzquierdo.ToString()).DisplayDescription = "Cantidad"

            toReturn.Fields(DV_RecetaComunFieldIndex.ArmazonIdCerca.ToString()).DisplayDescription = "Armazón"
            toReturn.Fields(DV_RecetaComunFieldIndex.ArmazonIdLejos.ToString()).DisplayDescription = "Armazón"

            Return toReturn

        End Function

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.POS.DAL.FactoryClasses.DV_RecetaComunEntityFactory
        End Function

#End Region

#Region "Overrides"

        Public Overrides Function SaveEntity(da As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, entity As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2) As Boolean
            'Dim receta As DV_RecetaComunEntity=
            Return MyBase.SaveEntity(da, entity)
        End Function

        Public Overrides Sub BeforeSaveEntity(ByVal entityToSave As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2)
            MyBase.BeforeSaveEntity(entityToSave)
            'MyBase.BeforeSaveEntity(entityToSave)

            Dim receta As DV_RecetaComunEntity = DirectCast(entityToSave, DV_RecetaComunEntity)
            If String.IsNullOrEmpty(receta.Numero) Then
                receta.Numero = GetNumero(receta)
            End If
            'receta.CajaId = ConfigReaderSpecific.GetCajaId()
            'receta.LocalId = LocalController.BuscarLocalIdFromCaja(receta.CajaId)
            'receta.Id = 1
            'receta.FechaIngresada = System.DateTime.Today
            'receta.FechaEmitida = System.DateTime.Today
            receta.MovimientoProcesado = False
            'receta.MovimientoArticulos = (receta.TipoOperacion = CInt(RecetaComunOperacion.Venta))
            'receta.DocumentoTipoId = DocumentoTipo.Contado
            'receta.NumeroDocumento = Tmp_DocumentoSalidaController.NumeroDocumentoMask


        End Sub

        Protected Overrides Sub CreateFields()
            MyBase.CreateFields()
            Fields(DV_RecetaComunFieldIndex.FechaVencimiento.ToString()).DisplayDescription = "F. Entrega"

        End Sub

#End Region

#Region "Procedimientos Privados"

        Private Shared Function CrearPrefetchParaImpresion() As IPrefetchPath2

            Dim toReturn As New PrefetchPath2(CInt(EntityType.DV_RecetaComunEntity))
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathDetalles).SubPath.Add(DocSalidaDetalleEntity.PrefetchPathArticulo)
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathArmazonLejos)
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathArmazonCerca)
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathMaterialOjoCercaDerecho)
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathMaterialOjoCercaIzquierdo)
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathMaterialOjoLejosDerecho)
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathMaterialOjoLejosIzquierdo)
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathCristalOjoCercaDerecho)
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathCristalOjoCercaIzquierdo)
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathCristalOjoLejosDerecho)
            toReturn.Add(DV_RecetaComunEntity.PrefetchPathCristalOjoLejosIzquierdo)

            Return toReturn

        End Function

        Private Shared Function FacturarContado(cajaId As Integer, receta As DV_RecetaComunEntity, pagoManager As PagoManager, fechaEmitida As Date, numeroDocumento As String) As EntityCollection(Of DocumentoSalidaEntity)

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

                Try
                    receta.SaveFields("facturacion")
                    da.StartTransaction(IsolationLevel.Serializable, "trn")
                    Dim toReturn As EntityCollection(Of DocumentoSalidaEntity) = Tmp_DocumentoSalidaController.FacturarOrdenContado(da, cajaId, receta, pagoManager, fechaEmitida, numeroDocumento)
                    receta.FechaFacturada = System.DateTime.Now
                    da.SaveEntity(receta, True)
                    'receta.FechaFacturada = System.DateTime.Now
                    da.FetchEntityCollection(receta.VentasEnRelacion, receta.GetRelationInfoVentasEnRelacion())
                    Dim relacion As DocumentoSalidaRelacionEntity = receta.VentasEnRelacion.Where(Function(f) f.Tipo = DocumentoSalidaRelacion.FacturacionDeOrdenDeVenta).Single()
                    relacion.PermiteBorrarDocumento2 = True
                    relacion.CamposModificados.Add(New DocumentoSalidaRelacion_CampoModificadoEntity With {.Relacion = relacion, .Nombre = DV_RecetaFieldIndex.FechaFacturada.ToString()})
                    da.SaveEntity(relacion, True)
                    da.Commit()
                    Return toReturn

                Catch
                    If da.IsTransactionInProgress Then
                        da.Rollback()
                    End If
                    receta.RollbackFields("facturacion")
                    Throw
                End Try

            End Using

        End Function

        Private Shared Function FacturarContado(cajaId As Integer, receta As DV_RecetaComunEntity, pagoManager As PagoManager) As EntityCollection(Of DocumentoSalidaEntity)
            Return FacturarContado(cajaId, receta, pagoManager, System.DateTime.MinValue, Nothing)
        End Function

        Private Shared Function FacturarCredito(receta As DV_RecetaComunEntity, fechaEmitida As Date, numeroDocumento As String) As EntityCollection(Of DocumentoSalidaEntity)
            Return FacturarCredito(New EntityCollection(Of DV_RecetaComunEntity)(New DV_RecetaComunEntity() {receta}), fechaEmitida, numeroDocumento)
        End Function

        Private Shared Function FacturarCredito(receta As DV_RecetaComunEntity) As EntityCollection(Of DocumentoSalidaEntity)
            Return FacturarCredito(New EntityCollection(Of DV_RecetaComunEntity)(New DV_RecetaComunEntity() {receta}))
        End Function

        Private Shared Function CrearDetalle(origDetalle As DocSalidaDetalleEntity) As Tmp_DocSalidaDetalleEntity

            Dim toReturn As New Tmp_DocSalidaDetalleEntity
            Studio.Net.Helper.DAL.EntityHelper.CopySameFields(origDetalle, toReturn)
            Return toReturn

        End Function

        Public Shared Function ImprimirRecetas(Optional maxItems As Integer = 100) As IEntityCollection

            Dim filtro As New RelationPredicateBucket
            filtro.PredicateExpression.Add(DV_RecetaComunFields.Impreso = False)
            Dim sort As New SortExpression(New SortClause(DV_RecetaComunFields.RId, SortOperator.Ascending))

            Return (New DV_RecetaBEntity).GetData(filtro, maxItems, sort)

        End Function

#End Region

#Region "ImpuestoRecetaController"

        Public Class ImpuestoRecetaController
            Implements IImpuestoController

            Dim _parametro As VisionParametroTree

            Public Sub New()
                _parametro = ParametroSistemaController.GetParametroTree()
            End Sub

            Public Function GetImpuestos(da As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, localId As Integer, articuloId As Integer, impuestoIdSinControl As Integer) As SD.LLBLGen.Pro.ORMSupportClasses.IEntityCollection2 Implements Phone.POS.BLL.IImpuestoController.GetImpuestos

                If _parametro.Optica.Venta.IVAIdOverrideReceta.HasValue() Then
                    Dim colToReturn As New EntityCollection(New ImpuestoEntityFactory)
                    colToReturn.Add(ImpuestoController.BuscarPorId(da, CInt(_parametro.Optica.Venta.IVAIdOverrideReceta)))
                    Return colToReturn
                Else
                    Dim impuesto As New ImpuestoBEntity
                    Return impuesto.GetData(da, ImpuestoController.CrearFiltroPorHijosArticuloYLocal(localId, articuloId, impuestoIdSinControl), 0, Nothing)
                End If

            End Function

        End Class
#End Region

    End Class

    Public Class MyRecetaComunFactory
        Inherits DV_RecetaComunEntityFactory

        Private _receta As DV_RecetaComunEntity
        Public Sub New(origReceta As DV_RecetaComunEntity)
            _receta = origReceta
        End Sub

        Public Overrides Function Create() As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2
            Return _receta
        End Function

    End Class

End Namespace
