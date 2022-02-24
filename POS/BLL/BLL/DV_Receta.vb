Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL
Imports System.Linq
Imports Studio.Phone.POS.DAL.Linq

Namespace Business
    <Serializable()> Public Class DV_RecetaBEntity
        Inherits Studio.Phone.POS.BLL.DocumentoSalidaBEntity

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub CreateFields()
            MyBase.CreateFields()
            Fields(DV_RecetaFieldIndex.FechaVencimiento.ToString()).DisplayDescription = "Fecha entrega"
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.POS.DAL.FactoryClasses.DV_RecetaEntityFactory
        End Function


        'Public Shared Function CrearFiltroParaFlujo(ByVal estado As RecetaEstado, ByVal clienteId As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date) As IRelationPredicateBucket
        '    Dim filtro As New RelationPredicateBucket
        '    filtro.PredicateExpression.Add(DV_RecetaFields.RecetaEstadoId = estado)
        '    If clienteId > 0 Then
        '        filtro.PredicateExpression.Add(DV_RecetaFields.ClienteId = clienteId)
        '    End If
        '    filtro.PredicateExpression.Add(DV_RecetaFields.FechaEmitida >= fechaInicio And DV_RecetaFields.FechaEmitida <= fechaFin)
        '    Return filtro
        'End Function


        Public Overrides Sub OnSaveEntity(ByVal entityToSave As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2, ByVal Cancel As Boolean)
            MyBase.OnSaveEntity(entityToSave, Cancel)
            Dim receta As DV_RecetaComunEntity = DirectCast(entityToSave, DV_RecetaComunEntity)
            receta.CajaId = ConfigReaderSpecific.GetCajaId()
            'Todavia no vamos a procesar el movimiento
            receta.MovimientoProcesado = False


        End Sub

        Public Shared Function GetNumero(receta As DV_RecetaEntity) As String
            Return String.Format("{0}-{1:00}", Studio.Net.Helper.RandomHelper.RNGCharacterMask(), receta.CajaId)
        End Function

        'Public Shared Function FacturarContado(receta As DV_RecetaEntity) As Tmp_DocumentoSalidaEntity
        '    Return FacturarContado(receta, Tmp_DocumentoSalidaController.NumeroDocumentoMask, System.DateTime.Today)
        'End Function

        'Public Shared Function FacturarContado(receta As DV_RecetaEntity, numeroDocumento As String, fecha As Date) As Tmp_DocumentoSalidaEntity

        '    If receta.VentaTipo <> RecetaVentaTipo.Contado Then
        '        Throw New ArgumentOutOfRangeException("receta", "El tipo de venta debe ser contado.")
        '    End If

        '    Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
        '        da.StartTransaction(IsolationLevel.Serializable, "trn")
        '        Dim toReturn As Tmp_DocumentoSalidaEntity = Tmp_DocumentoSalidaController.GenerarDesdeVentaParaFacturar(da, receta, DocumentoTipo.Contado, DocumentoTipo.NotaDevolucion)
        '        da.Commit()
        '        Return toReturn
        '    End Using

        'End Function

        'Public Shared Sub Facturar(receta As DV_RecetaEntity)
        '    Facturar(New EntityCollection(Of DV_RecetaEntity)(New DV_RecetaEntity() {receta}))
        'End Sub

        'Public Shared Sub Facturar(recetas As IEntityCollection2)
        '    'Dim toReturn As New EntityCollection(Of DV_RecetaEntity)
        '    Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

        '        da.StartTransaction(IsolationLevel.ReadCommitted, "trn")

        '        For Each receta As DV_RecetaEntity In recetas

        '            If receta.Facturada Then
        '                Throw New InvalidOperationException(String.Format("La receta {0} ya se encuentra facturada.", receta.Numero))
        '            End If
        '            If Not receta.IngresoManual Then
        '                receta.NumeroDocumento = DocumentoSalidaController.ProximoNumeroDocumento(da, receta.CajaId, receta.DocumentoTipoId)
        '                receta.FechaEmitida = System.DateTime.Today
        '            End If
        '            receta.FechaFacturada = System.DateTime.Now
        '            If DocumentoTipoController.NumeraRollo(da, receta.DocumentoTipoId) Then
        '                receta.NumeroRollo = Caja_DocumentoTipoController.GetNumeroRollo(da, receta.CajaId)
        '            End If

        '        Next

        '        da.SaveEntityCollection(recetas, True, False)

        '        da.Commit()

        '    End Using

        '    'Return New EntityCollection(Of DV_RecetaEntity)(recetas.Cast(Of IList(Of DV_RecetaEntity)))

        'End Sub

        Public Shared Function ExisteNumero(da As IDataAccessAdapter, numero As String) As Boolean
            Dim db As New LinqMetaData(da)
            Return (From r In db.DV_Receta Where r.Numero = numero).Any()
        End Function

        Public Shared Function RecetaFacturada(cajaId As Integer, Id As Integer) As Boolean
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                Return RecetaFacturada(da, cajaId, Id)
            End Using
        End Function

        Public Shared Function RecetaFacturada(da As IDataAccessAdapter, cajaId As Integer, Id As Integer) As Boolean
            Dim db As New LinqMetaData(da)
            Return (From r In db.DV_Receta Where r.CajaId = cajaId AndAlso r.Id = Id Select r.FechaFacturada).Single() > System.DateTime.MinValue
        End Function



        Public Shared Sub CopiarBonificaciones(toSave As Tmp_DocumentoSalidaEntity, receta As DV_RecetaComunEntity)
            If toSave.BonificacionId > 0 Then
                receta.BonificacionId = toSave.BonificacionId

            End If
            For i As Integer = 0 To toSave.Detalles.Count - 1 Step 1
                With toSave.Detalles(i)
                    If .BonificacionId > 0 Then
                        receta.Detalles(i).BonificacionId = .BonificacionId
                        receta.Detalles(i).Importe = .Importe
                    End If
                End With
            Next
            receta.ImporteTotal = toSave.ImporteTotal

        End Sub

    End Class

End Namespace