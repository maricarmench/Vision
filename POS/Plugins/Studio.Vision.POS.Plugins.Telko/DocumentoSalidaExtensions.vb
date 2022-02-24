Imports SD.LLBLGen.Pro.LinqSupportClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.DAL.Linq
Imports Studio.Phone.POS.BLL
Imports Studio.Vision.POS.Plugins.Telko.DTOs

Public Class DocumentoSalidaExtensions

    Public Shared Function GetFacturasParaIngresoRecibo(clienteId As Integer) As IEntityCollection2

        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
            Return GetFacturasParaIngresoRecibo(da, clienteId)
        End Using

    End Function

    ''' <summary>
    ''' Buscamos las facturas pendientes de pago de un cliente
    ''' Para esto vamos a tomar en cuenta primero las facturas de recetas anteriores al mes corriente, y luego el resto.
    ''' </summary>
    ''' <param name="da"></param>
    ''' <param name="clienteId"></param>
    ''' <returns></returns>
    Private Shared Function GetFacturasParaIngresoRecibo(da As IDataAccessAdapter, clienteId As Integer, monedaId As Integer) As IEntityCollection2

        If da Is Nothing Then Throw New ArgumentNullException("da")
        Dim db As New LinqMetaData(da)
        'Dim recetas As List(Of Integer) = New List(Of Integer)(DocumentoTipo.RecetaComun, DocumentoTipo.RecetaContacto)

        'Primero buscamos los documentos pendientes de recetas de meses anteriores
        Dim q = (From d In db.DocumentoSalida Join dt In db.DocumentoTipo On d.DocumentoTipoId Equals dt.Id
                 Where dt.GeneraRecibo = True AndAlso d.MonedaId = monedaId AndAlso d.ClienteId = clienteId AndAlso (d.FechaCancelada > System.DateTime.MinValue) = False _
                     AndAlso d.FechaEmitida < New Date(System.DateTime.Now.Year, System.DateTime.Now.Month, 1) _
                     AndAlso (From rel In d.DocumentosRelacionados Join
                        r In db.DV_Receta On rel.DocumentoSalidaId1 Equals r.Id And rel.CajaId1 Equals r.CajaId).Any() Select d).OrderBy(Function(f) f.FechaEmitida)


        'Luego buscamos el todos los pendientes
        Dim colPrioritario = CType(q, ILLBLGenProQuery).Execute(Of EntityCollection(Of DocumentoSalidaEntity))()

        q = (From d In db.DocumentoSalida Join dt In db.DocumentoTipo On d.DocumentoTipoId Equals dt.Id
             Where dt.GeneraRecibo = True AndAlso d.MonedaId = monedaId AndAlso d.ClienteId = clienteId AndAlso (d.FechaCancelada > System.DateTime.MinValue) = False Select d).OrderBy(Function(f) f.FechaEmitida)

        Dim colTodo = CType(q, ILLBLGenProQuery).Execute(Of EntityCollection(Of DocumentoSalidaEntity))()

        Dim colToReturn As New EntityCollection(Of DocumentoSalidaEntity)
        For Each documento As DocumentoSalidaEntity In colPrioritario
            colToReturn.Add(documento)
        Next

        Dim comparer As New DocumentoSalidaComparer

        'Aqui cargamos
        For Each documento As DocumentoSalidaEntity In colTodo
            If Not colToReturn.Contains(documento, comparer) Then
                colToReturn.Add(documento)
            End If
        Next

        Return colToReturn

    End Function

    Public Shared Sub IngresarRecibo(recibo As ReciboDTO)

        Dim manager As New PagoManager
        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
            Dim documentos As EntityCollection(Of DocumentoSalidaEntity) = GetFacturasParaIngresoRecibo(da, recibo.ClienteId, recibo.MonedaId)

            Tmp_DocumentoSalidaController.LimpiarTemporales(da)
            Dim saldo As Decimal = Decimal.Zero

            Dim indexFromToRemove As Integer = -1
            For Each documento As DocumentoSalidaEntity In documentos
                saldo += documento.ImporteSaldoRestante * SignoController.SignoDeDocumento(da, documento.DocumentoTipoId)
                If saldo >= recibo.Importe Then

                End If
            Next

            Dim temporales = DocumentoSalidaController.GenerarTemporalesDesdeVenta(da, documentos)


        End Using

    End Sub
End Class

