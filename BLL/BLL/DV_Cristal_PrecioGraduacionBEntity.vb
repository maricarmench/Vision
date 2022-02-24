Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.Linq
Imports Studio.Phone.DAL


Namespace Business

    <Serializable()> Public Class DV_Cristal_PrecioGraduacionBEntity
        Inherits Studio.Net.BLL.BEntityBase

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New DV_Cristal_PrecioGraduacionEntityFactory
        End Function
        Protected Overrides Sub CreateFields()
            MyBase.CreateFields()
        End Sub

#Region "Encadenamiento"

        Public Overrides Function SaveEntity(da As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, entity As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2) As Boolean
            'Return MyBase.SaveEntity(da, entity)
            Dim flagDA As Boolean
            Dim flagTRN As Boolean

            Try
                If da Is Nothing Then
                    da = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                    flagDA = True
                End If

                If Not da.IsTransactionInProgress Then
                    da.StartTransaction(IsolationLevel.ReadCommitted, "trn")
                    flagTRN = True
                End If
                Dim precio As DV_Cristal_PrecioGraduacionEntity = DirectCast(entity, DV_Cristal_PrecioGraduacionEntity)
                Dim listaMadre As Boolean = ListaEsMadre(da, precio.ListaPreVtaId)
                Dim isNew As Boolean = entity.IsNew
                MyBase.SaveEntity(da, entity)
                If listaMadre Then
                    If isNew Then
                        Me.GenerarDetallesDependientes(da, precio)
                    Else
                        Me.ActualizarDetallesDependientes(da, precio)
                    End If
                End If
                If flagTRN Then
                    da.Commit()
                End If
                Return True
            Catch ex As Exception
                If da.IsTransactionInProgress AndAlso flagTRN Then
                    da.Rollback()
                End If
                Throw
            Finally
                If flagTRN Then
                    da.Dispose()
                End If
            End Try

            Return False

        End Function

        Private Function ListaEsMadre(da As IDataAccessAdapter, listaPreVtaId As Integer) As Boolean
            Return ListaPreVtaController.EsMadre(da, listaPreVtaId)
        End Function

        Private Sub GenerarDetallesDependientes(ByVal da As IDataAccessAdapter, ByVal precio As DV_Cristal_PrecioGraduacionEntity)

            Dim colToSave As New EntityCollection(Of DV_Cristal_PrecioGraduacionEntity)
            precio.ListaPreVta = da.FetchNewEntity(New ListaPreVtaEntityFactory, precio.GetRelationInfoListaPreVta())
            Dim filtro As IRelationPredicateBucket = precio.ListaPreVta.GetRelationInfoListasEncadenadas()
            Dim unListaCollection As IEntityCollection2 = precio.ListaPreVta.ListasEncadenadas
            da.FetchEntityCollection(unListaCollection, filtro)
            For Each lista As ListaPreVtaEntity In unListaCollection
                Dim unListaPreVtaLinEntityNue As DV_Cristal_PrecioGraduacionEntity = CrearEntityDeMadre(precio, lista)
                colToSave.Add(unListaPreVtaLinEntityNue)
            Next
            Dim unCriMatEy As New DV_Cristal_PrecioGraduacionBEntity
            unCriMatEy.SaveEntityCollection(da, colToSave)

        End Sub


        Private Sub ActualizarDetallesDependientes(ByVal da As IDataAccessAdapter, ByVal precio As DV_Cristal_PrecioGraduacionEntity)
            precio.ListaPreVta = da.FetchNewEntity(New ListaPreVtaEntityFactory, precio.GetRelationInfoListaPreVta())
            Dim filtro As IRelationPredicateBucket = precio.ListaPreVta.GetRelationInfoListasEncadenadas()
            da.FetchEntityCollection(precio.ListaPreVta.ListasEncadenadas, filtro) ', CrearPreFetchParaActualizarDetalleDependiente())
            For Each lista As ListaPreVtaEntity In precio.ListaPreVta.ListasEncadenadas
                Dim unDetalleDependiente As DV_Cristal_PrecioGraduacionEntity = BuscarPorPk(da, precio.ArticuloId, lista.Id, precio.MonedaId, _
                                                    precio.EsfericoDesde, precio.EsfericoHasta, precio.CilindricoDesde, precio.CilindricoHasta, precio.AdicionDesde, precio.AdicionHasta)
                If Not unDetalleDependiente Is Nothing Then
                    Dim unOperadorBEntity As New OperadorBEntity
                    unDetalleDependiente.Importe = unOperadorBEntity.Calcular(precio.ListaPreVta.OperadorId, precio.ListaPreVta.Coeficiente, precio.Importe)
                    Me.SaveEntity(da, unDetalleDependiente)
                End If
            Next
            precio.ListaPreVta = Nothing
        End Sub

        Public Shared Function BuscarPorPk(da As IDataAccessAdapter, cristalId As Integer, listaPreVtaId As Integer, monedaId As Integer, esfericoDesde As Decimal, esfericoHasta As Decimal, cilindricoDesde As Decimal, cilindricoHasta As Decimal, adicionDesde As Decimal, adicionHasta As Decimal) As DV_Cristal_PrecioGraduacionEntity
            Dim db As New LinqMetaData(da)
            Return (From c In db.DV_Cristal_PrecioGraduacion Where c.ArticuloId = cristalId _
                    AndAlso c.ListaPreVtaId = listaPreVtaId AndAlso c.MonedaId = monedaId _
                    AndAlso c.CilindricoDesde = cilindricoDesde AndAlso c.CilindricoHasta = cilindricoHasta _
                    AndAlso c.EsfericoDesde = esfericoDesde AndAlso c.EsfericoHasta = esfericoHasta _
                    AndAlso c.AdicionDesde = adicionDesde AndAlso c.AdicionHasta = adicionHasta _
                    Select c).SingleOrDefault()
        End Function

        Private Shared Function CrearEntityDeMadre(ByVal precio As DV_Cristal_PrecioGraduacionEntity, ByVal lista As ListaPreVtaEntity) As DV_Cristal_PrecioGraduacionEntity
            Dim unOperadorBEntity As New OperadorBEntity
            'Crear al entity y asociarla a la lista
            Dim unPrecioNue As New DV_Cristal_PrecioGraduacionEntity
            Studio.Net.Helper.DAL.EntityHelper.CopySameFields(precio, unPrecioNue, True)
            With unPrecioNue
                .ListaPreVtaId = lista.Id
                .Importe = unOperadorBEntity.Calcular(lista.OperadorId, lista.Coeficiente, precio.Importe)
            End With
            Return unPrecioNue

        End Function


        Public Overloads Overrides Function DeleteEntity(ByVal da As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, ByVal entity As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2) As Boolean

            Dim flag As Boolean, flagTRN As Boolean

            Try
                If da Is Nothing Then
                    da = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                    flag = True
                End If
                If Not da.IsTransactionInProgress Then
                    da.StartTransaction(IsolationLevel.ReadCommitted, "trn")
                    flagTRN = True
                End If

                If Me.ListaEsMadre(da, DirectCast(entity, DV_Cristal_PrecioGraduacionEntity).ListaPreVtaId) Then
                    Me.EliminarListasDependientes(da, entity)
                End If
                MyBase.DeleteEntity(da, entity)
                If flagTRN Then
                    da.Commit()
                End If
                Return True
            Catch ex As Exception
                If da.IsTransactionInProgress Then
                    da.Rollback()
                End If
                Throw
            Finally
                If flag Then
                    da.Dispose()
                End If
            End Try

        End Function

        Private Sub EliminarListasDependientes(ByVal da As IDataAccessAdapter, ByVal servicio As DV_Cristal_PrecioGraduacionEntity)
            Dim unDV_Cristal_PrecioGraduacionBE As New DV_Cristal_PrecioGraduacionBEntity
            Dim colToDelete As IEntityCollection2 = unDV_Cristal_PrecioGraduacionBE.GetData(da, Me.CrearFiltroPorDetalleHijo(servicio))
            unDV_Cristal_PrecioGraduacionBE.DeleteEntityCollection(da, colToDelete)
        End Sub

        Public Function CrearFiltroPorDetalleHijo(ByVal servicio As DV_Cristal_PrecioGraduacionEntity) As IRelationPredicateBucket
            Dim filtro As New RelationPredicateBucket
            filtro.Relations.Add(DV_Cristal_PrecioGraduacionEntity.Relations.ListaPreVtaEntityUsingListaPreVtaId)
            filtro.PredicateExpression.Add(ListaPreVtaFields.ListaPreVtaIdPadre = servicio.ListaPreVtaId)
            filtro.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.ArticuloId = servicio.ArticuloId)
            filtro.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.MonedaId = servicio.MonedaId)
            filtro.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.EsfericoDesde = servicio.EsfericoDesde)
            filtro.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.EsfericoHasta = servicio.EsfericoHasta)
            filtro.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.CilindricoDesde = servicio.CilindricoDesde)
            filtro.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.CilindricoHasta = servicio.CilindricoHasta)
            filtro.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.AdicionDesde = servicio.AdicionDesde)
            filtro.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.AdicionHasta = servicio.AdicionHasta)
            Return filtro
        End Function


        Public Overrides Sub BeforeSaveEntity(entityToSave As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2)
            Dim precio As DV_Cristal_PrecioGraduacionEntity = DirectCast(entityToSave, DV_Cristal_PrecioGraduacionEntity)
            With entityToSave
                .Fields(DV_Cristal_PrecioGraduacionFieldIndex.EsfericoDesde).CurrentValue = precio.EsfericoDesde
                .Fields(DV_Cristal_PrecioGraduacionFieldIndex.EsfericoHasta).CurrentValue = precio.EsfericoHasta
                .Fields(DV_Cristal_PrecioGraduacionFieldIndex.CilindricoDesde).CurrentValue = precio.CilindricoDesde
                .Fields(DV_Cristal_PrecioGraduacionFieldIndex.CilindricoHasta).CurrentValue = precio.CilindricoHasta
                .Fields(DV_Cristal_PrecioGraduacionFieldIndex.AdicionDesde).CurrentValue = precio.AdicionDesde
                .Fields(DV_Cristal_PrecioGraduacionFieldIndex.AdicionHasta).CurrentValue = precio.AdicionHasta
            End With

        End Sub
#End Region

        Public Shared Sub EliminarDetallesDeLista(da As IDataAccessAdapter, unListaPreVtaEntity As ListaPreVtaEntity)
            Dim business As New DV_Cristal_PrecioGraduacionBEntity
            Dim colToDelete As IEntityCollection2 = business.GetData(da, CrearFiltroPorLista(unListaPreVtaEntity.Id))
            business.DeleteEntityCollection(da, colToDelete)
        End Sub

        Public Shared Function CrearFiltroPorLista(listaPreVtaId As Integer) As IRelationPredicateBucket
            Return New RelationPredicateBucket(DV_Cristal_PrecioGraduacionFields.ListaPreVtaId = listaPreVtaId)
        End Function

        Private Shared Function CrearFiltroPorListaHija(listaPreVtaId As Integer) As IRelationPredicateBucket
            Dim toReturn As New RelationPredicateBucket(ListaPreVtaFields.ListaPreVtaIdPadre = listaPreVtaId)
            toReturn.Relations.Add(DV_Cristal_PrecioGraduacionEntity.Relations.ListaPreVtaEntityUsingListaPreVtaId)
            Return toReturn
        End Function

        Public Shared Sub GenerarDetallesDependientes(da As IDataAccessAdapter, listaPreVta As ListaPreVtaEntity)

            Dim business As New DV_Cristal_PrecioGraduacionBEntity
            If listaPreVta.ListaMadre Is Nothing Then
                listaPreVta.ListaMadre = da.FetchNewEntity(Of ListaPreVtaEntity)(listaPreVta.GetRelationInfoListaMadre())
            End If

            Dim colToSave As New EntityCollection(Of DV_Cristal_PrecioGraduacionEntity)

            'Cargar el detalle de la lista madre
            da.FetchEntityCollection(listaPreVta.ListaMadre.DV_Cristal_PrecioGraduacionCollection, listaPreVta.ListaMadre.GetRelationInfoDV_Cristal_PrecioGraduacionCollection())
            For Each detalleMadre As DV_Cristal_PrecioGraduacionEntity In listaPreVta.ListaMadre.DV_Cristal_PrecioGraduacionCollection
                Dim detalleHijo As DV_Cristal_PrecioGraduacionEntity = BuscarPorPk(da, detalleMadre.ArticuloId, listaPreVta.Id, detalleMadre.MonedaId, _
                                                                    detalleMadre.EsfericoDesde, detalleMadre.EsfericoHasta, detalleMadre.CilindricoDesde, detalleMadre.CilindricoHasta, _
                                                                    detalleMadre.AdicionDesde, detalleMadre.AdicionHasta)
                'Si no existe se genera, en caso contrario significa que es independiente
                If detalleHijo Is Nothing Then
                    Dim unListaPreVtaLinEntity As DV_Cristal_PrecioGraduacionEntity = CrearEntityDeMadre(detalleMadre, listaPreVta)
                    'unListaPreVtaEntity.ListaPreVtaLin.Add(unListaPreVtaLinEntity)
                    colToSave.Add(unListaPreVtaLinEntity)
                End If
            Next
            
            business.SaveEntityCollection(da, colToSave)

        End Sub

        Public Shared Function CalularPrecioUnitarioDeArticulo(ByVal articuloId As Integer, fecha As Date, ByVal listaPreVtaId As Integer, ByVal monedaId As Integer, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As Decimal

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

                Dim col As IEntityCollection2 = Buscar(da, articuloId, listaPreVtaId, monedaId, esferico, cilindrico, adicion)

                If col.Count = 0 Then
                    col = Buscar(da, articuloId, listaPreVtaId, esferico, cilindrico, adicion)
                    If col.Count = 0 Then
                        Throw New ApplicationException(String.Format("No se ha encontrado información del artículo {0} en la lista de precios especificada, consulte al administrador del sistema.", ArticuloController.BuscarPorId(articuloId).DescripcionFull))
                        Return Nothing
                    End If
                End If

                Dim listaPreVtaLin As DV_Cristal_PrecioGraduacionEntity = DirectCast(col(0), DV_Cristal_PrecioGraduacionEntity)

                'Si la moneda de la lista de precios no es la misma que la factura hay que realizar una conversión
                Dim impToReturn As Decimal = listaPreVtaLin.Importe
                If listaPreVtaLin.MonedaId <> monedaId Then
                    Dim cotiz As CotizacionEntity = CotizacionController.BuscarUltimaCotizacionDeCompra(da, monedaId, listaPreVtaLin.MonedaId, fecha, CotizacionTipo.Compra)
                    If Not cotiz Is Nothing Then
                        impToReturn = CType(listaPreVtaLin.Importe * cotiz.Importe, Decimal)
                    Else
                        'Si no encuentro la cotizacion Moneda 1 / Moneda 2, busco al reves yen vez de multiplicar divido
                        cotiz = CotizacionController.BuscarUltimaCotizacion(da, listaPreVtaLin.MonedaId, monedaId, fecha, CotizacionTipo.Compra)
                        If Not cotiz Is Nothing Then
                            impToReturn = CType(listaPreVtaLin.Importe / cotiz.Importe, Decimal)
                        Else
                            'Cotización no encontrada
                            Throw New ApplicationException("La moneda de la factura difiere de la lista de precios, pero no se ha encontrado información el tipo de cambio entre ambas.")
                        End If
                    End If
                End If

                Return Decimal.Round(impToReturn, 2)

            End Using

        End Function


        Public Shared Function Buscar(da As IDataAccessAdapter, articuloId As Integer, listaPreVtaId As Integer, monedaId As Integer, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As IEntityCollection2
            Return (New DV_Cristal_PrecioGraduacionBEntity).GetData(da, CrearFiltroParaPrecio(articuloId, listaPreVtaId, monedaId, esferico, cilindrico, adicion))
        End Function

        Public Shared Function Buscar(da As IDataAccessAdapter, articuloId As Integer, listaPreVtaId As Integer, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As IEntityCollection2
            Return (New DV_Cristal_PrecioGraduacionBEntity).GetData(da, CrearFiltroParaPrecio(articuloId, listaPreVtaId, esferico, cilindrico, adicion))
        End Function

        Public Shared Function CrearFiltroParaPrecio(articuloId As Integer, listaPreVtaId As Integer, monedaId As Integer, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As IRelationPredicateBucket
            Dim toReturn As IRelationPredicateBucket = New RelationPredicateBucket(DV_Cristal_PrecioGraduacionFields.ArticuloId = articuloId And DV_Cristal_PrecioGraduacionFields.ListaPreVtaId = listaPreVtaId And DV_Cristal_PrecioGraduacionFields.MonedaId = monedaId And _
                                                        DV_Cristal_PrecioGraduacionFields.EsfericoDesde <= esferico And DV_Cristal_PrecioGraduacionFields.EsfericoHasta >= esferico)
            If adicion > Decimal.Zero Then
                toReturn.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.AdicionDesde <= adicion And DV_Cristal_PrecioGraduacionFields.AdicionHasta >= adicion)
            ElseIf cilindrico > Decimal.MinValue Then
                toReturn.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.CilindricoDesde <= cilindrico And DV_Cristal_PrecioGraduacionFields.CilindricoHasta >= cilindrico)
            End If
            Return toReturn
        End Function

        Public Shared Function CrearFiltroParaPrecio(articuloId As Integer, listaPreVtaId As Integer, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As IRelationPredicateBucket
            Return New RelationPredicateBucket(DV_Cristal_PrecioGraduacionFields.ArticuloId = articuloId And DV_Cristal_PrecioGraduacionFields.ListaPreVtaId = listaPreVtaId And _
                                                        DV_Cristal_PrecioGraduacionFields.CilindricoDesde <= cilindrico And DV_Cristal_PrecioGraduacionFields.CilindricoHasta >= cilindrico And _
                                                        DV_Cristal_PrecioGraduacionFields.EsfericoDesde <= esferico And DV_Cristal_PrecioGraduacionFields.EsfericoHasta >= esferico)
        End Function

    End Class


End Namespace