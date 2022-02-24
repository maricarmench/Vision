Imports Studio.Phone.POS.DAL.EntityClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports System.Linq
Imports Studio.Phone.POS.DAL.Linq
Imports SD.LLBLGen.Pro.LinqSupportClasses
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL
Imports Drako.FE.Common
Imports Drako.FE.Common.Legacy

Public Class eFactGenerador

    Public Property Empresa As EmpresaEntity
    Public Property ListaId As Integer

    Private _clientes As New Studio.Phone.POS.DAL.HelperClasses.EntityCollection(Of ClienteEmpresaEntity)
    Private _articulos As Studio.Phone.POS.DAL.HelperClasses.EntityCollection(Of ArticuloEntity)

    Private AdapterToUse As IDataAccessAdapter

    Dim _envios As Drako.FE.Common.Legacy.EnvioDataCollection

    Public Sub Generar(threadsCount As Integer, cfcDesde As Integer)

        AdapterToUse = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
        'AdapterToUse.FetchEntityCollection(_clientes, New RelationPredicateBucket(ClienteEmpresaFields.Ruc <> DBNull.Value))

        Dim db As New LinqMetaData(AdapterToUse)
        Dim artPath As New PrefetchPath2(CInt(EntityType.ArticuloEntity))
        artPath.Add(ArticuloEntity.PrefetchPathImpuestos).SubPath.Add(Articulo_ImpuestoEntity.PrefetchPathImpuesto)
        artPath.Add(ArticuloEntity.PrefetchPathPreciosDeVenta, 1, New PredicateExpression(ListaPreVtaLinFields.ListaPrecioVentaId = ListaId))

        Dim fields As New ExcludeIncludeFieldsList(False)
        fields.Add(ArticuloFields.Id)
        fields.Add(ArticuloFields.Descripcion)

        Dim q = (From a In db.Articulo Where a.Activo = True AndAlso a.Vendible = True AndAlso (From l In a.PreciosDeVenta Where l.ListaPrecioVentaId = ListaId Select l).Count > 0 AndAlso a.Impuestos.Count > 0 Select a).WithPath(artPath).IncludeFields(Function(e) e.Id, Function(e) e.Descripcion)


        'AdapterToUse.FetchEntityCollection(_articulos, fields, Nothing)

        _articulos = CType(q, ILLBLGenProQuery).Execute(Of EntityCollection(Of ArticuloEntity))()
        Empresa = EmpresaController.BuscarPorCajaId(AdapterToUse, ConfigReaderSpecific.GetCajaId())
        '_adapter.FetchEntityCollection(_articulos, New RelationPredicateBucket(ArticuloFields.Activo = True And ArticuloFields.Vendible = True))
        'If False Then
        Dim envioCol As New List(Of Drako.FE.Common.Legacy.EnvioDataCollection)

        For i As Integer = 1 To threadsCount Step 1
            _envios = New Drako.FE.Common.Legacy.EnvioDataCollection

            _envios.AddRange(GenerarXTipo(101, 5, 2, 10, "FF", cfcDesde))
            _envios.AddRange(GenerarDevXTipo(102, 5, 1, 2, 2))
            _envios.AddRange(GenerarDevXTipo(103, 5, 1, 2, 2))
            '_envios.AddRange(GenerarXTipo(201, 5, 2, 5, "AA", cfcDesde))
            'End If

            _envios.AddRange(GenerarXTipo(111, 5, 2, 10, "A", cfcDesde))

            'If False Then

            _envios.AddRange(GenerarDevXTipo(112, 5, 2, 10, 2))
            _envios.AddRange(GenerarDevXTipo(113, 5, 1, 2, 2))
            '_envios.AddRange(GenerarXTipo(211, 5, 2, 10, "AA", cfcDesde))
            'End If
            If False Then


                '_envios.AddRange(GenerarResgXTipo(182, 5, 1, 1))
                '_envios.AddRange(GenerarResgXTipo(282, 5, 1, 1))

                _envios.AddRange(GenerarAjXTipo(131, 5, 2, 10))
                _envios.AddRange(GenerarDevAjXTipo(132, 5, 1, 2, 131))
                _envios.AddRange(GenerarDevAjXTipo(133, 5, 1, 2, 131))
                '_envios.AddRange(GenerarAjXTipo(231, 5, 2, 5))

                _envios.AddRange(GenerarAjXTipo(141, 5, 2, 10))
                _envios.AddRange(GenerarDevAjXTipo(142, 5, 1, 2, 141))
                _envios.AddRange(GenerarDevAjXTipo(143, 5, 1, 2, 141))
                '_envios.AddRange(GenerarAjXTipo(241, 5, 2, 5))

            End If

            envioCol.Add(_envios)

        Next i

        For i As Integer = 0 To threadsCount - 1 Step 1
            Dim index As Integer = i
            Dim caller As New MethodInvoker(Sub() EnviarCFE(envioCol(index)))
            caller.BeginInvoke(Nothing, Nothing)
        Next
        'End If
        'caller.BeginInvoke(Nothing, _envios)

        'EnviarCFE(_envios)


    End Sub

    Private Function GenerarXTipo(tipo As Integer, cantidadComprobantes As Integer, minLineas As Integer, maxLineas As Integer, cfcSerie As String, cfcDesde As Integer) As List(Of Drako.FE.Common.Legacy.EnvioData)

        Dim toReturn As New List(Of Drako.FE.Common.Legacy.EnvioData)
        Dim rnd As New Random()
        For i As Integer = 1 To cantidadComprobantes Step 1

            Dim cantLineas As Integer = rnd.Next(minLineas, maxLineas)
            'Dim cliente As ClienteEmpresaEntity = _clientes(rnd.Next(0, _clientes.Count - 1))
            'Do While Not cliente.Ruc.StartsWith("2")
            ' cliente = _clientes(rnd.Next(0, _clientes.Count - 1))
            ' Loop
            Dim envio As New Drako.FE.Common.Legacy.EnvioData


            With envio
                .CantidadLineas = cantLineas
                .CodigoComprobante = tipo
                .EmpresaCodigo = 2 'Empresa.Id.ToString()

                .FechaEmision = System.DateTime.Today
                .FechaVencimiento = .FechaEmision
                .FormaPago = Drako.FE.Common.FormaPago.Contado ' IIf(documento.DocumentoTipo.LiquidaEnCuentaCorriente, Drako.FE.Common.FormaPago.Credito, Drako.FE.Common.FormaPago.Contado)
                .IdentificadorExterno = Guid.NewGuid().ToString().Substring(1, 15)
                .IndicadorMontosBrutos = Drako.FE.Common.IndicadorMontosBrutos.LineasIvaIncluido 'IIf(documento.SinImpuestos, IndicadorMontosBrutos.LineasSinIVA, IndicadorMontosBrutos.LineasIvaIncluido)
                .MonedaCodigo = 1

                .Receptor.Direccion = "Charrua 1811" 'cliente.Direccion ' documento.Direccion
                .Receptor.Nombre = "El Arbolito" 'cliente.RazonSocial
                .Receptor.NroDocumento = "210602090016" ' cliente.Ruc
                .Receptor.PaisCodigo = 1 '"UY"
                .Receptor.TipoDocumento = Drako.FE.Common.TipoDocumentoReceptor.RUT
                .Receptor.Ciudad = "MONTEVIDEO"

                'If documento.Cliente.Ciudad IsNot Nothing Then
                '    .Receptor.Ciudad = documento.Cliente.Ciudad.Descripcion
                'End If
                If cfcDesde > 0 Then
                    .CFCNumero = cfcDesde + i - 1
                    .CFESerie = cfcSerie
                End If
                .RUTEmisor = "213300220019" 'Empresa.Ruc ' documento.Caja.Local.Empresa.Ruc

                .TasaBasicaIVA = ImpuestoController.BuscarPorId(AdapterToUse, Impuesto.IVABasico).Porcentaje
                .TasaMinimaIVA = ImpuestoController.BuscarPorId(AdapterToUse, Impuesto.IVAMinimo).Porcentaje
                .TerminalCodigo = 1

                'If documento.MonedaId = Moneda.Pesos Then
                '    .TipodeCambio = Decimal.One
                'Else
                '    .TipodeCambio = documento.TipoDeCambio
                'End If

                For j As Integer = 1 To cantLineas
                    envio.Items.Add(CrearDetalle(minLineas, maxLineas))
                    envio.Items(.Items.Count - 1).NumeroLinea = .Items.Count
                Next

                .TipoTrasladoBienes = Drako.FE.Common.TipoTrasladoBienes.Venta

                .TotalIVAOtraTasa = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoOtraTasa).Sum(Function(f) (f.Monto / (1 + (f.PorcentajeIVA / 100)) * f.PorcentajeIVA / 100)), 2)
                .TotalIVATasaBasica = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoTasaBasica).Sum(Function(f) (f.Monto / (1 + (f.PorcentajeIVA / 100)) * f.PorcentajeIVA / 100)), 2)
                .TotalIVATasaMinima = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoTasaMinima).Sum(Function(f) (f.Monto / (1 + (f.PorcentajeIVA / 100)) * f.PorcentajeIVA / 100)), 2)

                'TODO: ver si el importe neto es afectado por la bonificacion global
                .TotalMontoGravadoTasaBasica = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoTasaBasica).Sum(Function(f) f.Monto / (1 + (f.PorcentajeIVA / 100))), 2)
                .TotalMontoGravadoTasaMinima = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoTasaMinima).Sum(Function(f) f.Monto / (1 + (f.PorcentajeIVA / 100))), 2)
                .TotalMontoGravadoOtraTasa = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoOtraTasa).Sum(Function(f) f.Monto / (1 + (f.PorcentajeIVA / 100))), 2)
                .TotalMontoTotal = Decimal.Round(envio.Items.GetListItems.Sum(Function(f) f.Monto), 2) ' documento.ImporteTotal

                .EncriptarComplementoFiscal = CType(Studio.Net.Helper.ConfigManager.ReadDataFromConfig("FEEncriptarComplementoFiscal", "0"), Boolean)

                .IVATasaBasica = ImpuestoController.BuscarPorId(AdapterToUse, Impuesto.IVABasico).Porcentaje
                .IVATasaMinima = ImpuestoController.BuscarPorId(AdapterToUse, Impuesto.IVAMinimo).Porcentaje

                .MontoTotalaPagar = envio.TotalMontoTotal

                '.TotalIVATasaBasica = .TotalMontoGravadoTasaBasica * .TasaBasicaIVA / 100 ' documento.Detalles.Where(Function(f) f.ImpuestoId = Impuesto.IVABasico).Sum(Function(f) f.ImporteImpuestos)
                '.TotalIVATasaMinima = .TotalMontoGravadoTasaMinima * .TasaMinimaIVA / 100 ' documento.Detalles.Where(Function(f) f.ImpuestoId = Impuesto.IVAMinimo).Sum(Function(f) f.ImporteImpuestos)

            End With

            toReturn.Add(envio)

            'For Each detalle As DocSalidaDetalleEntity In documento.Detalles

            'Verificamos si el documento tiene venta consignada
            'Dim consignador As ConsignadorEntity = ConsignadorBEntity.BuscarConsignadorDeDocumento(AdapterToUse, documento.Id, documento.CajaId)
            'If consignador IsNot Nothing Then
            '    envio.ComplementoFiscal = New Drako.FE.Common.Legacy.EnvioData.ComplementoFiscalData With { _
            '        .NombreMandante = consignador.Descripcion, _
            '        .NumeroDocumentoMandante = consignador.NumeroDocumento, _
            '        .PaisCodigo = consignador.PaisId, _
            '        .RUCEmisor = envio.RUTEmisor, _
            '        .TipoDocumentoMandante = consignador.ClienteDocumentoTipoId _
            '        }
            'End If
            'If envio.CodigoComprobante = Drako.FE.Common.TipoComprobante.eResguardo OrElse envio.CodigoComprobante = Drako.FE.Common.TipoComprobante.eResguardoContingencia Then
            '    CargarDatosResguardo(envio, documento)
            'End If

        Next

        Return toReturn

    End Function

    Private Function GenerarDevXTipo(tipo As Integer, cantidadComprobantes As Integer, minLineas As Integer, maxLineas As Integer, tipoDevolver As Integer) As List(Of Drako.FE.Common.Legacy.EnvioData)
        Dim toReturn As List(Of Drako.FE.Common.Legacy.EnvioData) = GenerarXTipo(tipo, cantidadComprobantes, minLineas, maxLineas, String.Empty, 0)
        For Each item As Drako.FE.Common.Legacy.EnvioData In toReturn
            item.Referencias.Add(New EnvioData.ReferenciaData With {.IndicadorReferencia = Drako.FE.Common.IndicadorReferencia.RefGlobal, .RazonReferencia = "Dev no registrada", .NumeroLinea = 1})
        Next
        Return toReturn
    End Function

    Private Function GenerarDevAjXTipo(tipo As Integer, cantidadComprobantes As Integer, minLineas As Integer, maxLineas As Integer, tipoDevolver As Integer) As List(Of Drako.FE.Common.Legacy.EnvioData)
        Dim toReturn As List(Of Drako.FE.Common.Legacy.EnvioData) = GenerarDevXTipo(tipo, cantidadComprobantes, minLineas, maxLineas, tipoDevolver)
        For Each envio As Drako.FE.Common.Legacy.EnvioData In toReturn
            envio.EncriptarComplementoFiscal = True
            envio.ComplementoFiscal = New EnvioData.ComplementoFiscalData
            envio.ComplementoFiscal.NombreMandante = "DGI"
            envio.ComplementoFiscal.NumeroDocumentoMandante = "214844360018"
            envio.ComplementoFiscal.RUCEmisor = envio.RUTEmisor
            envio.ComplementoFiscal.TipoDocumentoMandante = TipoDocumentoReceptor.RUT
            envio.ComplementoFiscal.PaisCodigo = "UY"
        Next
        Return toReturn

    End Function

    Private Function GenerarResgXTipo(tipo As Integer, cantidadComprobantes As Integer, minLineas As Integer, maxLineas As Integer) As List(Of Drako.FE.Common.Legacy.EnvioData)

        Dim toReturn As New List(Of Drako.FE.Common.Legacy.EnvioData)
        Dim rnd As New Random()
        For i As Integer = 1 To cantidadComprobantes Step 1

            Dim cantLineas As Integer = rnd.Next(minLineas, maxLineas)
            Dim cliente As ClienteEmpresaEntity = _clientes(rnd.Next(0, _clientes.Count - 1))
            Dim envio As New Drako.FE.Common.Legacy.EnvioData


            With envio
                .CantidadLineas = cantLineas
                .CodigoComprobante = tipo
                .EmpresaCodigo = 2 'Empresa.Id.ToString()

                .FechaEmision = System.DateTime.Today
                .FechaVencimiento = .FechaEmision
                .FormaPago = Drako.FE.Common.FormaPago.Contado ' IIf(documento.DocumentoTipo.LiquidaEnCuentaCorriente, Drako.FE.Common.FormaPago.Credito, Drako.FE.Common.FormaPago.Contado)
                .IdentificadorExterno = Guid.NewGuid().ToString().Substring(1, 15)
                .IndicadorMontosBrutos = Drako.FE.Common.IndicadorMontosBrutos.LineasIvaIncluido 'IIf(documento.SinImpuestos, IndicadorMontosBrutos.LineasSinIVA, IndicadorMontosBrutos.LineasIvaIncluido)
                .MonedaCodigo = 1

                .Receptor.Direccion = cliente.Direccion ' documento.Direccion
                .Receptor.Nombre = cliente.RazonSocial
                .Receptor.NroDocumento = "210602090016" 'cliente.Ruc
                .Receptor.PaisCodigo = 1
                .Receptor.TipoDocumento = Drako.FE.Common.TipoDocumentoReceptor.RUT
                .Receptor.Ciudad = "MONTEVIDEO"

                'If documento.Cliente.Ciudad IsNot Nothing Then
                '    .Receptor.Ciudad = documento.Cliente.Ciudad.Descripcion
                'End If

                .RUTEmisor = "213300220019" ' Empresa.Ruc ' documento.Caja.Local.Empresa.Ruc

                .TasaBasicaIVA = ImpuestoController.BuscarPorId(AdapterToUse, Impuesto.IVABasico).Porcentaje
                .TasaMinimaIVA = ImpuestoController.BuscarPorId(AdapterToUse, Impuesto.IVAMinimo).Porcentaje
                .TerminalCodigo = 1

                'If documento.MonedaId = Moneda.Pesos Then
                '    .TipodeCambio = Decimal.One
                'Else
                '    .TipodeCambio = documento.TipoDeCambio
                'End If

                envio.Items.GetListItems.Add(CrearDetalleReguardo())

                'For j As Integer = 1 To cantLineas
                '    envio.Items.GetListItems.Add(CrearDetalle(minLineas, maxLineas))
                '    envio.Items(.Items.Count - 1).NumeroLinea = .Items.Count
                'Next

                .TipoTrasladoBienes = Drako.FE.Common.TipoTrasladoBienes.Venta

                .TotalIVAOtraTasa = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoOtraTasa).Sum(Function(f) (f.Monto / (1 + (f.PorcentajeIVA / 100)) * f.PorcentajeIVA / 100)), 2)
                .TotalIVATasaBasica = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoTasaBasica).Sum(Function(f) (f.Monto / (1 + (f.PorcentajeIVA / 100)) * f.PorcentajeIVA / 100)), 2)
                .TotalIVATasaMinima = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoTasaMinima).Sum(Function(f) (f.Monto / (1 + (f.PorcentajeIVA / 100)) * f.PorcentajeIVA / 100)), 2)

                'TODO: ver si el importe neto es afectado por la bonificacion global
                .TotalMontoGravadoTasaBasica = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoTasaBasica).Sum(Function(f) f.Monto / (1 + (f.PorcentajeIVA / 100))), 2)
                .TotalMontoGravadoTasaMinima = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoTasaMinima).Sum(Function(f) f.Monto / (1 + (f.PorcentajeIVA / 100))), 2)
                .TotalMontoGravadoOtraTasa = Decimal.Round(envio.Items.GetListItems.Where(Function(f) f.IndicadorFacturacion = Drako.FE.Common.IndicadorFacturacion.GravadoOtraTasa).Sum(Function(f) f.Monto / (1 + (f.PorcentajeIVA / 100))), 2)
                .TotalMontoTotal = Decimal.Round(envio.Items.GetListItems.Sum(Function(f) f.Monto), 2) ' documento.ImporteTotal

                .EncriptarComplementoFiscal = CType(Studio.Net.Helper.ConfigManager.ReadDataFromConfig("FEEncriptarComplementoFiscal", "0"), Boolean)

                .IVATasaBasica = ImpuestoController.BuscarPorId(AdapterToUse, Impuesto.IVABasico).Porcentaje
                .IVATasaMinima = ImpuestoController.BuscarPorId(AdapterToUse, Impuesto.IVAMinimo).Porcentaje

                .MontoTotalaPagar = envio.TotalMontoTotal

                '.TotalIVATasaBasica = .TotalMontoGravadoTasaBasica * .TasaBasicaIVA / 100 ' documento.Detalles.Where(Function(f) f.ImpuestoId = Impuesto.IVABasico).Sum(Function(f) f.ImporteImpuestos)
                '.TotalIVATasaMinima = .TotalMontoGravadoTasaMinima * .TasaMinimaIVA / 100 ' documento.Detalles.Where(Function(f) f.ImpuestoId = Impuesto.IVAMinimo).Sum(Function(f) f.ImporteImpuestos)

            End With

            toReturn.Add(envio)
        Next

        Return toReturn
    End Function

    Private Function CrearDetalle(cantDesde As Integer, cantHasta As Integer) As Drako.FE.Common.Legacy.EnvioData.ComprobanteItem

        Dim rnd As New Random
        Dim i As Integer = rnd.Next(0, _articulos.Count - 1)
        Dim articulo As ArticuloEntity = _articulos(i)

        Dim lista As ListaPreVtaLinEntity = articulo.PreciosDeVenta(0) ' ListaPreVtaLinController.Buscar(AdapterToUse, Moneda.Pesos, ListaId, articulo.Id, 1, True)
        Dim impuesto As ImpuestoEntity = articulo.Impuestos(0).Impuesto

        Dim toReturn As New Drako.FE.Common.Legacy.EnvioData.ComprobanteItem
        With toReturn
            .Cantidad = rnd.Next(cantDesde, cantHasta)
            .CodigoIVA = impuesto.Id
            .Descripcion = articulo.Descripcion
            .Monto = lista.Importe * .Cantidad
            .PorcentajeIVA = impuesto.Porcentaje
            .PrecioUnitario = lista.Importe
            If .PrecioUnitario = Decimal.Zero Then
                .IndicadorFacturacion = IndicadorFacturacion.EntregaGratuita
            Else
                .IndicadorFacturacion = impuesto.IndicadorFacturacion

            End If
            .UnidadMedida = "N/C"
        End With

        Return toReturn



    End Function
    Private Function CrearDetalleReguardo() As Drako.FE.Common.Legacy.EnvioData.ComprobanteItem

        Dim rnd As New Random
        Dim i As Integer = rnd.Next(0, _articulos.Count - 1)
        Dim articulo As ArticuloEntity = _articulos(i)

        Dim lista As ListaPreVtaLinEntity = articulo.PreciosDeVenta(0) ' ListaPreVtaLinController.Buscar(AdapterToUse, Moneda.Pesos, ListaId, articulo.Id, 1, True)
        Dim impuesto As ImpuestoEntity = articulo.Impuestos(0).Impuesto

        Dim toReturn As New Drako.FE.Common.Legacy.EnvioData.ComprobanteItem
        With toReturn
            .Cantidad = Decimal.One ' rnd.Next(cantDesde, cantHasta)
            .CodigoIVA = impuesto.Id
            .Descripcion = "RETENCIÓN POR ARRENDAMIENTO"
            .Monto = lista.Importe * .Cantidad
            .PorcentajeIVA = Decimal.Zero
            .PrecioUnitario = lista.Importe
            .UnidadMedida = "N/C"
            .NumeroLinea = 1
        End With

        toReturn.PercepcionesRetenciones.Add(New EnvioData.RetencionPercepcionData With _
            {.Codigo = "2183165", .Tasa = 50D, .Valor = toReturn.Monto, .Monto = .Valor / (.Tasa / 100)})
        Return toReturn



    End Function



    Private Function EnviarCFE(_envios As Drako.FE.Common.Legacy.EnvioDataCollection) As RespuestaEnvioInfo
        Dim proxy As IDefaultProxy = GetProxy()
        Return proxy.Enviar(_envios)
    End Function

    Private Shared Function GetProxy() As IDefaultProxy
        Dim t As Type = Type.GetType("Drako.FE.Common.IDefaultProxy, Drako.FE.Common", True, True)
        Dim toReturn As Drako.FE.Common.IDefaultProxy = CType(Activator.GetObject(t, String.Format("tcp://{0}/Proxy", RemoteConexion())), IDefaultProxy)
        Return toReturn
    End Function

    Private Shared Function RemoteConexion() As String
        Dim sock As String = Studio.Net.Helper.ConfigManager.ReadDataFromConfig("RemoteMachineFE")
        If sock.IndexOf(":") >= 0 Then
            Return sock
        End If
        Throw New ArgumentException("Se debe cargar el parámetro RemoteMachineFE en el archivo config, con el formato Destino:Puerto")
    End Function

    Private Function GenerarAjXTipo(tipo As Integer, cantidadComprobantes As Integer, minLineas As Integer, maxLineas As Integer) As List(Of Drako.FE.Common.Legacy.EnvioData)
        Dim toReturn As List(Of Drako.FE.Common.Legacy.EnvioData) = GenerarXTipo(tipo, cantidadComprobantes, minLineas, maxLineas, String.Empty, 0)
        For Each envio As Drako.FE.Common.Legacy.EnvioData In toReturn
            envio.EncriptarComplementoFiscal = True
            envio.ComplementoFiscal = New EnvioData.ComplementoFiscalData
            envio.ComplementoFiscal.NombreMandante = "DGI"
            envio.ComplementoFiscal.NumeroDocumentoMandante = "214844360018"
            envio.ComplementoFiscal.RUCEmisor = envio.RUTEmisor
            envio.ComplementoFiscal.TipoDocumentoMandante = TipoDocumentoReceptor.RUT
            envio.ComplementoFiscal.PaisCodigo = "UY"

        Next
        Return toReturn
    End Function

End Class
