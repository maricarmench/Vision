Imports Studio.Net.Controls.New.Forms
Imports Studio.Net.Controls.New
Imports Studio.Net.Helper
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Vision.POS.BLL.Business
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.Controls.New
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Vision.POS.BLL
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Net.BLL

Public Class DV_RecetaComunDetailViewModule

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RibbonControl1.SelectedPage = rpgDetail

    End Sub

    Protected Overrides Sub OnRibbonItemClick(item As DevExpress.XtraBars.ItemClickEventArgs)

        If _lockRibbonClick Then Return

        Try
            _lockRibbonClick = True
            item.Item.Enabled = False
            Application.DoEvents()

            Select Case item.Item.Name
                Case bbiFacturar.Name
                    OnFacturarClicked(System.DateTime.MinValue, Nothing)
                Case bbiImprimirOrden.Name
                    OnImprimirOrdenClicked()
                    'OnFacturarClicked(True)
                Case bbiImprimirFactura.Name
                    OnImprimirFacturaClicked()
                Case bbiIngresarPago.Name
                    OnIngresarPagoClicked()
                Case bbiCambiarCristales.Name
                    OnCambiarCristalesClicked()
                Case bbiDevolverReceta.Name
                    OnDevolverRecetaClicked()
                Case bbiConfirmarPresupuesto.Name
                    OnConfirmarPresupuestoClicked()
                Case bbiDatosTaller.Name
                    OnDatosTallerClicked()
                Case Else
                    _lockRibbonClick = False
                    MyBase.OnRibbonItemClick(item)

            End Select
        Finally
            item.Item.Enabled = True
            _lockRibbonClick = False
        End Try

        'MyBase.OnRibbonItemClick(item)
    End Sub

    Protected Overrides Sub OnCurrentItemChanged(sender As Object, e As System.EventArgs)

        MyBase.OnCurrentItemChanged(sender, e)

        Dim receta As DV_RecetaComunEntity = GetCurrentEntity(Of DV_RecetaComunEntity)()

        bbiFacturar.Enabled = receta IsNot Nothing AndAlso Not receta.IsNew AndAlso receta.Facturable AndAlso Not receta.Facturada AndAlso PtkOperacionBEntity.TienePermiso(PermisoOperacion.FacturarRecetas)
        bbiImprimirFactura.Enabled = receta IsNot Nothing AndAlso receta.Facturada AndAlso PtkOperacionBEntity.TienePermiso(PermisoOperacion.ReimprimirDocumentos) AndAlso receta.Imprimible
        bbiIngresarPago.Enabled = receta IsNot Nothing AndAlso receta.PagoIngresable AndAlso PtkOperacionBEntity.TienePermiso(PermisoOperacion.IngresarPagoDeDocumentosPendientes)
        bbiCambiarCristales.Enabled = receta IsNot Nothing AndAlso Not receta.IsNew AndAlso receta.Facturable AndAlso PtkOperacionBEntity.TienePermiso(PermisoOperacion.CambiarArticulosDeBoleta) AndAlso DocumentoSalidaRelacionBEntity.NoCambiado(receta)
        bbiDevolverReceta.Enabled = receta IsNot Nothing AndAlso Not receta.IsNew AndAlso receta.Devolvible AndAlso PtkOperacionBEntity.TienePermiso(PermisoOperacion.DevolverDocumentos) AndAlso Not DocumentoSalidaController.DocumentoYaDevuelto(receta)
        bbiConfirmarPresupuesto.Enabled = receta IsNot Nothing AndAlso Not receta.IsNew AndAlso receta.TipoOperacion = RecetaComunOperacion.Presupuesto
        bbiDatosTaller.Enabled = receta IsNot Nothing AndAlso Not receta.IsNew AndAlso PtkOperacionBEntity.TienePermiso(PermisoOperacion.EditarDatosAdicionalesReceta)

    End Sub

    Private Sub OnFacturarClicked(fechaEmitida As Date, numeroDocumento As String)

        Try
            Dim receta As DV_RecetaComunEntity = GetCurrentEntity(Of DV_RecetaComunEntity)()
            If receta IsNot Nothing Then
                Dim manual As Boolean = Not String.IsNullOrEmpty(numeroDocumento)
                If manual OrElse ShowMsgBox("¿Seguro que desea facturar la receta?" & vbCrLf & "Verifique que las boletas estén colocadas en la impresora.", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    CursorManager.WaitCursor()
                    DetailViewToUse.FacturarRecetaActiva(fechaEmitida, numeroDocumento)
                    DetailViewToUse.Refetch()
                End If
            End If

            OnCurrentItemChanged(Me, EventArgs.Empty)

        Catch ex As Exception

            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)

        Finally
            CursorManager.Default()
        End Try

    End Sub

    Private Sub OnIngresarPagoClicked()
        InicializarPago(False, GetCurrentEntity(Of DV_RecetaComunEntity))
    End Sub

#Region "Pago de receta"

    Private _documentoCollection As IEntityCollection2 '(Of DocumentoSalidaEntity)
    Private _documentoACuentaEy As DocumentoSalidaEntity

    Private Function InicializarPago(ByVal manual As Boolean, receta As DV_RecetaComunEntity) As Boolean


        Try

            _documentoACuentaEy = Nothing
            _documentoCollection = New EntityCollection(New DocumentoSalidaEntityFactory)
            _documentoCollection.Add(receta)

            'Si no estoy directo contra central hay que guardarse los documentos en la base local
            If Not ConfigReaderSpecific.GetAdminMode() Then
                DocumentoSalidaController.GuardarDocumentosPendientesDePago(_documentoCollection)
            End If

            MostrarPago(DocumentoSalidaController.GenerarTemporalesDesdeVenta(Nothing, _documentoCollection), IIf(receta.VentaTipo = RecetaVentaTipo.Contado, PagoManager.ModoPagoMayorEnum.DevolverCambio, PagoManager.ModoPagoMayorEnum.GenerarPagoACuenta), manual)

            Return True

        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

        Return False

    End Function

    Private Sub PagoFinalizado(ByVal sender As Object, ByVal e As PagoFinalizadoEventArgs)

        Try
            '1ero guardar el pago en POS
            Dim numeroRecibo As String = e.NumeroRecibo
            Dim fechaRecibo As Date = e.FechaRecibo
            Dim obsRecibo As String = e.ObsRecibo

            Dim unCollection As New EntityCollection(New DocumentoSalidaEntityFactory)

            Dim saldoRestante As Decimal = e.SaldoRestante
            If Me._documentoACuentaEy Is Nothing Then
                unCollection = Me._documentoCollection
            Else
                'Si se ingreso un pago a cuenta sin documentos entonces forzar que el saldo restante 
                'sea el mismo que el documento a cuenta para que genere el documento pago a cuenta necesario
                saldoRestante = Me._documentoACuentaEy.ImporteTotal
            End If
            Dim info As New PagoDocSalidaController.PagoOnLineInfo
            Dim unReciboCollection As EntityCollection = _
                PagoDocSalidaController.GuardarPagoDeDocumentos(Nothing, DirectCast(DetailViewToUse, DV_RecetaLenteComunDetailView).CajaId, unCollection, numeroRecibo, fechaRecibo, _
                obsRecibo, saldoRestante, Not ConfigReaderSpecific.GetAdminMode(), info, e.PagoAdm)

            'flagGenerado = True

            '2do guardar en Central los pagos para evitar la duplicación de pagos
            'DocumentoSalidaController.Remoting.GuardarPagoDeDocumentos(unReciboCollection, Me._documentoCollection)
            'Studio.Phone.Traffic.Services.Proxy.GuardarPagoDeDocumentos(unReciboCollection, Me._documentoCollection)

            'Si lo corremos desde el entorno dar la posibilidad de no imprimir los recibos
            If unReciboCollection.Count > Decimal.Zero And e.NumeroRecibo = String.Empty Then
                Dim flag As Boolean = True
                If Studio.Net.Helper.Environment.RunningUnderIDE() Then
                    If ShowMsgBox("¿Desea imprimir los recibos?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        flag = False
                    End If
                Else
                    ShowMsgBox("Pago generado satisfactoriamente, se procederá a la impresión de los recibos.", MsgBoxStyle.Information)
                End If
                If flag Then
                    Me.ImprimirRecibos(unReciboCollection)
                End If
            End If
            DetailViewToUse.Refetch()
            OnCurrentItemChanged(Me, EventArgs.Empty)
        Catch ex As ORMConcurrencyException
            showmsgbox("Se detectaron cambios en los documentos involucrados, para preservar la consistencia de los datos se canceló la ejecución del proceso. Puede volver a intentar relizar la operación", MsgBoxStyle.Exclamation)
            '            Me.ChangeViewMode(ViewMode.Consulta)

        Catch ex As Exception
            showmsgbox(ex.Message, MsgBoxStyle.Exclamation)
            'Me.ChangeViewMode(ViewMode.Consulta)
        Finally
            'If flagGenerado Then
            ' Me.ChangeViewMode(ViewMode.Consulta)
            ' End If
        End Try

    End Sub

    Private Sub MostrarPago(ByVal unDocumentoCollection As IEntityCollection2, ByVal modoPago As PagoManager.ModoPagoMayorEnum, ByVal manual As Boolean)


        Using pagoDV As New PagoDocumentoSalidaView()

            Try
                Dim documento As Tmp_DocumentoSalidaEntity = unDocumentoCollection(0)
                pagoDV.InicializarPago(unDocumentoCollection, documento.CajaId, documento.ClienteId, modoPago, manual)
                'Me._documentoCollection = unDocumentoCollection
                AddHandler pagoDV.PagoFinalizado, AddressOf PagoFinalizado
                pagoDV.ShowDialog(FindForm())

            Catch ex As Exception
                showmsgbox(ex.Message, MsgBoxStyle.Critical)
            Finally
                RemoveHandler pagoDV.PagoFinalizado, AddressOf PagoFinalizado

            End Try
        End Using

    End Sub

    Private Sub ImprimirRecibos(ByVal unReciboCollection As IEntityCollection2)

        Try
            For Each unReciboOrigEntity As DocumentoSalidaEntity In unReciboCollection
                Dim unReciboEntity As DocumentoSalidaEntity = Studio.Phone.POS.BLL.DocumentoSalidaController.CrearDocumentoSalidaParaImpresion(unReciboOrigEntity.Id, unReciboOrigEntity.CajaId)
                Dim report As New Studio.Phone.POS.Reporting.DynamicReport
                report.Print(unReciboEntity)
                'Dim unFacturaImpresion As IImprimirFactura = ImprimirFacturaFactory.Create()
                'unFacturaImpresion.Proceso(unReciboEntity)
            Next
        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub



    Private Sub OnSetSecurity()

        'bbiIngresarPago.Enabled = PtkOperacionBEntity.TienePermiso(PermisoOperacion.IngresarPagoDeDocumentosPendientes)
        'bbiFacturar.Enabled = PtkOperacionBEntity.TienePermiso(PermisoOperacion.FacturarRecetas)

    End Sub

    Public Shadows Property DetailViewToUse As DV_RecetaLenteComunDetailView
        Get
            Return MyBase.DetailViewToUse
        End Get
        Set(value As DV_RecetaLenteComunDetailView)
            MyBase.DetailViewToUse = value
        End Set
    End Property

#End Region

    Private Sub OnCambiarCristalesClicked()

        Dim toEdit As DV_RecetaEntity = GetCurrentEntity(Of DV_RecetaComunEntity).DeepClone()

        Studio.Net.Controls.[New].FormHelper.ShowDetailViewDialog(_parent, GetType(DV_RecetaComunChange_DetailView), DetailViewToUse.BusinessToUse, toEdit, False, True)

        OnCurrentItemChanged(Me, EventArgs.Empty)

    End Sub

    Private Sub OnDevolverRecetaClicked()

        If ShowMsgBox("¿Seguro que desea devolver la receta actual?.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            DetailViewToUse.DevolverReceta()
        End If

    End Sub

    Private Sub btnFacturaManual_Click(sender As System.Object, e As System.EventArgs) Handles btnFacturaManual.Click

        DxErrorProvider1.ClearErrors()
        If txtFechaEmitida.EditValue Is Nothing Then
            DxErrorProvider1.SetError(txtFechaEmitida, "Debe ingresar la fecha de emisión.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
        End If
        If txtNumeroDocumento.Text = String.Empty Then
            DxErrorProvider1.SetError(txtNumeroDocumento, "Debe ingresar el número de documento.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
        End If
        If Not DxErrorProvider1.HasErrors Then
            popUpFactura.HidePopup()
            OnFacturarClicked(txtFechaEmitida.DateTime, txtNumeroDocumento.Text)
            txtFechaEmitida.EditValue = Nothing
            txtNumeroDocumento.EditValue = Nothing
        End If

    End Sub

    Private Sub OnImprimirOrdenClicked()

        If ShowMsgBox("¿Seguro que desea reimprimir la orden de trabajo?. Recuerde colocar hojas en blanco en la impresora.", MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            Dim receta As DV_RecetaComunEntity = GetCurrentEntity(Of DV_RecetaComunEntity)()
            If receta IsNot Nothing Then
                DetailViewToUse.ImprimirOrden(receta)
            End If
        End If

    End Sub

    Private Sub OnImprimirFacturaClicked()


        If ShowMsgBox("¿Seguro que desea reimprimir la factura asociada a la receta?. Recuerde colocar las facturas en la impresora.", MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            Dim receta As DV_RecetaComunEntity = GetCurrentEntity(Of DV_RecetaComunEntity)()
            If receta IsNot Nothing Then
                DetailViewToUse.ImprimirFactura(receta)
            End If
        End If

    End Sub

    Private Sub OnConfirmarPresupuestoClicked()
        Try
            DetailViewToUse.ConfirmarPresupuesto()
        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub OnDatosTallerClicked()

        Dim toEdit As DV_RecetaEntity = GetCurrentEntity(Of DV_RecetaComunEntity)()
        Dim bs As DV_RecetaComunBEntity = DV_RecetaComunBEntity.CrearMeParaDatosTaller()

        Studio.Net.Controls.[New].FormHelper.ShowDetailViewDialog(_parent, GetType(DV_RecetaLenteComunDatosAdicionalesDetailView), bs, toEdit, False, True)
        DetailViewToUse.Entity2Controls(False)
        'DetailViewToUse.RaiseDirtyChanged()

    End Sub

End Class
