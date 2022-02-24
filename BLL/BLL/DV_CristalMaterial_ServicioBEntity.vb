Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.Linq


Namespace Business

    <Serializable()> Public Class DV_CristalMaterial_ServicioBEntity
        Inherits Studio.Net.BLL.BEntityBase

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New DV_CristalMaterial_ServicioEntityFactory
        End Function
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
                Dim crisMat As DV_CristalMaterial_ServicioEntity = DirectCast(entity, DV_CristalMaterial_ServicioEntity)
                Dim listaMadre As Boolean = ListaEsMadre(da, crisMat.ListaPrecioVentaId)
                Dim isNew As Boolean = entity.IsNew
                MyBase.SaveEntity(da, entity)
                If listaMadre Then
                    If isNew Then
                        Me.GenerarDetallesDependientes(da, crisMat)
                    Else
                        Me.ActualizarDetallesDependientes(da, crisMat)
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

        Private Sub GenerarDetallesDependientes(ByVal da As IDataAccessAdapter, ByVal cristalMaterial As DV_CristalMaterial_ServicioEntity)

            Dim colToSave As New EntityCollection(Of DV_CristalMaterial_ServicioEntity)
            cristalMaterial.ListaPreVta = da.FetchNewEntity(New ListaPreVtaEntityFactory, cristalMaterial.GetRelationInfoListaPreVta())
            Dim filtro As IRelationPredicateBucket = cristalMaterial.ListaPreVta.GetRelationInfoListasEncadenadas()
            Dim unListaCollection As IEntityCollection2 = cristalMaterial.ListaPreVta.ListasEncadenadas
            da.FetchEntityCollection(unListaCollection, filtro)
            For Each lista As ListaPreVtaEntity In unListaCollection
                Dim unListaPreVtaLinEntityNue As DV_CristalMaterial_ServicioEntity = CrearEntityDeMadre(cristalMaterial, lista)
                colToSave.Add(unListaPreVtaLinEntityNue)
            Next
            Dim unCriMatEy As New DV_CristalMaterial_ServicioBEntity
            unCriMatEy.SaveEntityCollection(da, colToSave)

        End Sub


        Private Sub ActualizarDetallesDependientes(ByVal da As IDataAccessAdapter, ByVal cristalMaterial As DV_CristalMaterial_ServicioEntity)
            cristalMaterial.ListaPreVta = da.FetchNewEntity(New ListaPreVtaEntityFactory, cristalMaterial.GetRelationInfoListaPreVta())
            Dim filtro As IRelationPredicateBucket = cristalMaterial.ListaPreVta.GetRelationInfoListasEncadenadas()
            da.FetchEntityCollection(cristalMaterial.ListaPreVta.ListasEncadenadas, filtro) ', CrearPreFetchParaActualizarDetalleDependiente())
            For Each lista As ListaPreVtaEntity In cristalMaterial.ListaPreVta.ListasEncadenadas
                Dim unDetalleDependiente As DV_CristalMaterial_ServicioEntity = BuscarPorPk(da, cristalMaterial.CristalMaterialId, cristalMaterial.ArticuloId, lista.Id, cristalMaterial.MonedaId)
                If Not unDetalleDependiente Is Nothing Then
                    Dim unOperadorBEntity As New OperadorBEntity
                    unDetalleDependiente.Importe = unOperadorBEntity.Calcular(cristalMaterial.ListaPreVta.OperadorId, cristalMaterial.ListaPreVta.Coeficiente, cristalMaterial.Importe)
                    Me.SaveEntity(da, unDetalleDependiente)
                End If
            Next
            cristalMaterial.ListaPreVta = Nothing
        End Sub

        Public Shared Function BuscarPorPk(da As IDataAccessAdapter, cristalMaterialId As Integer, articuloIdServicio As Integer, listaPreVtaId As Integer, monedaId As Integer) As DV_CristalMaterial_ServicioEntity
            Dim db As New LinqMetaData(da)
            Return (From c In db.DV_CristalMaterial_Servicio Where c.CristalMaterialId = cristalMaterialId AndAlso c.ArticuloId = articuloIdServicio _
                    AndAlso c.ListaPrecioVentaId = listaPreVtaId AndAlso c.MonedaId = monedaId Select c).SingleOrDefault()
        End Function

        Private Shared Function CrearEntityDeMadre(ByVal cristal As DV_CristalMaterial_ServicioEntity, ByVal lista As ListaPreVtaEntity) As DV_CristalMaterial_ServicioEntity
            Dim unOperadorBEntity As New OperadorBEntity
            'Crear al entity y asociarla a la lista
            Dim unCristalNue As New DV_CristalMaterial_ServicioEntity
            With unCristalNue
                .ListaPrecioVentaId = lista.Id
                .ArticuloId = cristal.ArticuloId
                .MonedaId = cristal.MonedaId
                .CristalMaterialId = cristal.CristalMaterialId
                .Importe = unOperadorBEntity.Calcular(lista.OperadorId, lista.Coeficiente, cristal.Importe)
            End With
            Return unCristalNue

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

                If Me.ListaEsMadre(da, DirectCast(entity, DV_CristalMaterial_ServicioEntity).ListaPrecioVentaId) Then
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

        Private Sub EliminarListasDependientes(ByVal da As IDataAccessAdapter, ByVal servicio As DV_CristalMaterial_ServicioEntity)
            Dim unDV_CristalMaterial_ServicioBE As New DV_CristalMaterial_ServicioBEntity
            Dim colToDelete As IEntityCollection2 = unDV_CristalMaterial_ServicioBE.GetData(da, Me.CrearFiltroPorDetalleHijo(servicio))
            unDV_CristalMaterial_ServicioBE.DeleteEntityCollection(da, colToDelete)
        End Sub

        Public Function CrearFiltroPorDetalleHijo(ByVal servicio As DV_CristalMaterial_ServicioEntity) As IRelationPredicateBucket
            Dim filtro As New RelationPredicateBucket
            filtro.Relations.Add(DV_CristalMaterial_ServicioEntity.Relations.ListaPreVtaEntityUsingListaPrecioVentaId)
            filtro.PredicateExpression.Add(ListaPreVtaFields.ListaPreVtaIdPadre = servicio.ListaPrecioVentaId)
            filtro.PredicateExpression.Add(DV_CristalMaterial_ServicioFields.ArticuloId = servicio.ArticuloId)
            filtro.PredicateExpression.Add(DV_CristalMaterial_ServicioFields.MonedaId = servicio.MonedaId)
            filtro.PredicateExpression.Add(DV_CristalMaterial_ServicioFields.CristalMaterialId = servicio.CristalMaterialId)
            Return filtro
        End Function


#End Region
        Public Shared Sub EliminarDetallesDeLista(da As IDataAccessAdapter, unListaPreVtaEntity As ListaPreVtaEntity)
            Dim business As New DV_CristalMaterial_ServicioBEntity
            Dim colToDelete As IEntityCollection2 = business.GetData(da, CrearFiltroPorLista(unListaPreVtaEntity.Id))
            business.DeleteEntityCollection(da, colToDelete)
        End Sub

        Public Shared Function CrearFiltroPorLista(listaPreVtaId As Integer) As IRelationPredicateBucket
            Return New RelationPredicateBucket(DV_CristalMaterial_ServicioFields.ListaPrecioVentaId = listaPreVtaId)
        End Function

        Private Shared Function CrearFiltroPorListaHija(listaPreVtaId As Integer) As IRelationPredicateBucket
            Dim toReturn As New RelationPredicateBucket(ListaPreVtaFields.ListaPreVtaIdPadre = listaPreVtaId)
            toReturn.Relations.Add(DV_CristalMaterial_ServicioEntity.Relations.ListaPreVtaEntityUsingListaPrecioVentaId)
            Return toReturn
        End Function

        Public Shared Sub GenerarDetallesDependientes(da As IDataAccessAdapter, listaPreVta As ListaPreVtaEntity)

            Dim business As New DV_CristalMaterial_ServicioBEntity
            If listaPreVta.ListaMadre Is Nothing Then
                listaPreVta.ListaMadre = da.FetchNewEntity(Of ListaPreVtaEntity)(listaPreVta.GetRelationInfoListaMadre())
            End If

            Dim colToSave As New EntityCollection(Of DV_CristalMaterial_ServicioEntity)

            'Cargar el detalle de la lista madre
            da.FetchEntityCollection(listaPreVta.ListaMadre.DV_CristalMaterial_ServicioCollection, listaPreVta.ListaMadre.GetRelationInfoDV_CristalMaterial_ServicioCollection())
            For Each detalleMadre As DV_CristalMaterial_ServicioEntity In listaPreVta.ListaMadre.DV_CristalMaterial_ServicioCollection
                Dim detalleHijo As DV_CristalMaterial_ServicioEntity = BuscarPorPk(da, detalleMadre.CristalMaterialId, detalleMadre.ArticuloId, listaPreVta.Id, detalleMadre.MonedaId)

                'Si no existe se genera, en caso contrario significa que es independiente
                If detalleHijo Is Nothing Then
                    Dim unListaPreVtaLinEntity As DV_CristalMaterial_ServicioEntity = CrearEntityDeMadre(detalleMadre, listaPreVta)
                    'unListaPreVtaEntity.ListaPreVtaLin.Add(unListaPreVtaLinEntity)
                    colToSave.Add(unListaPreVtaLinEntity)
                End If
            Next

            business.SaveEntityCollection(da, colToSave)

        End Sub

    End Class

End Namespace