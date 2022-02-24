Imports Studio.Vision.BLL.Business
Imports Studio.Net.Controls.New
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL
Imports Studio.Phone.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Net.BLL
Imports Studio.Net.Helper
Imports DevExpress.XtraEditors
Imports Studio.Vision.BLL
Imports Studio.Net.Controls.New.Forms
Imports Studio.Phone.Controls.New
Imports DevExpress.Data.Linq
Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors.Controls
'Imports Studio.Phone.Controls.New.VentaDetailView
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Linq
Imports SD.LLBLGen.Pro.LinqSupportClasses

Public Class DV_RecetaLenteComunDetailView

#Region "CTor"

    Public Sub New()

        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As DV_RecetaComunBEntity, ByVal binding As MyBindingSource)

        MyBase.New(business, binding)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _parametroTree = DirectCast(ParametroSistemaController.GetParametroTree(), VisionParametroTree)

        labTotal.DataBindings.Add(New System.Windows.Forms.Binding("Text", binding, DV_RecetaComunFieldIndex.ImporteTotal.ToString(), True, DataSourceUpdateMode.OnPropertyChanged, Decimal.Zero, "n2"))


    End Sub

#End Region

#Region "Variable de módulo"


    Protected _lockUpdate As Boolean

    Protected _funcionarioId As Integer
    Protected _flagUpdating As Boolean
    Protected _parametroTree As Studio.Vision.BLL.VisionParametroTree
    Protected _ventaSaved As Boolean
    Protected _tmp_DocumentoSalida As Tmp_DocumentoSalidaEntity
    Protected _cercaEsSegundoPar As Boolean = False
    Protected _lastCargaArticulosOk As Boolean = False
    Protected _documentoRelacionado As DocumentoSalidaEntity
    Protected _documentoRelacionadoTipo As DocumentoSalidaRelacion

#End Region

#Region "Classes"

    Public Class ItemAFacturar
        Public Property Descripcion As String
        Public Property Cantidad As Decimal
        Public Property Importe As Decimal
        Public Property Modificado As Boolean
        Public Property UsrAutorizador As String
    End Class

    Public Class Pagos
        Public Property Descripcion As String
        Public Property Moneda As String
        Public Property Importe As Decimal
        Public Property Modificado As Boolean
        Public Property UsrAutorizador As String
    End Class

#End Region


    Protected ReadOnly Property EntityToEdit As DV_RecetaComunEntity
        Get
            Return GetCurrentEntity(Of DV_RecetaComunEntity)()
        End Get
    End Property

#Region "Eventos de acción"

    'Private Sub bgwDetalles_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwDetalles.RunWorkerCompleted

    '    labTotal.Text = EntityToEdit.ImporteTotal.ToString("n2")

    '    _lastCargaArticulosOk = e.Result

    '    DxErrorProvider1.ClearErrors()

    '    Dim errors As Dictionary(Of String, String) = EntityToEdit.GetDataErrorInfoErroresPerField()
    '    If errors IsNot Nothing Then

    '        If errors.ContainsKey(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString()) Then
    '            DxErrorProvider1.SetError(cboCristalIdLejosDerecho, errors(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString()), DXErrorProvider.ErrorType.Warning)
    '        Else
    '            DxErrorProvider1.SetErrorType(cboCristalIdLejosDerecho, DXErrorProvider.ErrorType.None)
    '        End If
    '        If errors.ContainsKey(DV_RecetaComunFieldIndex.CristalIdLejosIzquierdo.ToString()) Then
    '            DxErrorProvider1.SetError(cboCristalIdLejosIzquierdo, errors(DV_RecetaComunFieldIndex.CristalIdLejosIzquierdo.ToString()), DXErrorProvider.ErrorType.Warning)
    '        Else
    '            DxErrorProvider1.SetErrorType(cboCristalIdLejosIzquierdo, DXErrorProvider.ErrorType.None)
    '        End If

    '        If errors.ContainsKey(DV_RecetaComunFieldIndex.CristalIdCercaDerecho.ToString()) Then
    '            DxErrorProvider1.SetError(cboCristalIdCercaDerecho, errors(DV_RecetaComunFieldIndex.CristalIdCercaDerecho.ToString()), DXErrorProvider.ErrorType.Warning)
    '        Else
    '            DxErrorProvider1.SetErrorType(cboCristalIdCercaDerecho, DXErrorProvider.ErrorType.None)
    '        End If
    '        If errors.ContainsKey(DV_RecetaComunFieldIndex.CristalIdCercaIzquierdo.ToString()) Then
    '            DxErrorProvider1.SetError(cboCristalIdCercaIzquierdo, errors(DV_RecetaComunFieldIndex.CristalIdCercaIzquierdo.ToString()), DXErrorProvider.ErrorType.Warning)
    '        Else
    '            DxErrorProvider1.SetErrorType(cboCristalIdCercaIzquierdo, DXErrorProvider.ErrorType.None)
    '        End If

    '        If errors.ContainsKey(DV_RecetaComunFieldIndex.ArmazonIdLejos.ToString()) Then
    '            DxErrorProvider1.SetError(cboArmazonIdLejos, errors(DV_RecetaComunFieldIndex.ArmazonIdLejos.ToString()), DXErrorProvider.ErrorType.Warning)
    '        Else
    '            DxErrorProvider1.SetErrorType(cboArmazonIdLejos, DXErrorProvider.ErrorType.None)
    '        End If
    '        If errors.ContainsKey(DV_RecetaComunFieldIndex.ArmazonIdCerca.ToString()) Then
    '            DxErrorProvider1.SetError(cboArmazonIdCerca, errors(DV_RecetaComunFieldIndex.ArmazonIdCerca.ToString()), DXErrorProvider.ErrorType.Warning)
    '        Else
    '            DxErrorProvider1.SetErrorType(cboArmazonIdCerca, DXErrorProvider.ErrorType.None)
    '        End If

    '        EntityToEdit.ClearErrors()
    '    End If

    'End Sub

    'Private Sub bgwDetalles_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwDetalles.DoWork
    '    e.Result = CargarArticulosInternal()
    'End Sub


    'Private Sub lqifsServicios_DismissQueryable(sender As Object, e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles lq

    '    Dim da As IDataAccessAdapter = TryCast(e.Tag, IDataAccessAdapter)
    '    If da IsNot Nothing Then
    '        da.Dispose()
    '    End If
    'End Sub



#End Region

#Region "Overrides"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Protected Overrides Sub CreateDataBindings(bindedControls As SD.LLBLGen.Pro.ORMSupportClasses.FastDictionary(Of String, DevExpress.XtraLayout.LayoutControlItem))
        Try
            _lockUpdate = True
            MyBase.CreateDataBindings(bindedControls)
        Finally
            _lockUpdate = False
        End Try
    End Sub

    Protected Overrides Sub OnSaveCurrent()
        'MyBase.OnSaveCurrent()
        'NO HACER NADA
    End Sub



    Protected Overrides Sub OnLoad(e As System.EventArgs)

        If Not Environment.DesignMode Then
            MyBase.OnLoad(e)
            LayoutControl.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True
            'If CurrentEntityIsNew() Then
            '    CargarDatosPorDefecto()
            'End If
            'OnSetSecurity()

            'Dim q As IQueryable = DV_CristalBEntity.GetQueryableForReceta(Studio.Net.Helper.DAL.DataAccessAdapter.Create(), 0, 0, 0, 0, 0, 0, 1, 1, rgrRecetaComunTipo.EditValue, _parametroTree)

            'Dim l As String = (From d In q Select d).ToString

            ''Dim col As IEntityCollection2 = CType(q, ILLBLGenProQuery).Execute(Of EntityCollection(Of DV_CristalEntity))()
            'Stop
        End If

    End Sub

    Protected Overrides Sub OnCurrentEntityChanged(sender As Object, e As EventArgs)

        MyBase.OnCurrentEntityChanged(sender, e)

        If (EntityToEdit.Detalles.Count = 0I OrElse EntityToEdit.Cobros.Count = 0I) AndAlso Not CurrentEntityIsNew() Then
            DocumentoSalidaController.FetchDetalles(EntityToEdit)
        End If

        grdItems.DataSource = EntityToEdit.Detalles
        grdFPago.DataSource = DocSalida_PagoDocSalidaController.FetchTypeListPagos(EntityToEdit)

        LayoutControl.OptionsView.IsReadOnly = IIf(CurrentEntityIsNew(), DevExpress.Utils.DefaultBoolean.Default, DevExpress.Utils.DefaultBoolean.True)

        If EntityToEdit.Devolucion Then
            labTotal.ForeColor = Color.Red
        Else
            labTotal.ForeColor = SystemColors.MenuHighlight
        End If

        If Not bgDatosFactura.IsBusy Then
            bgDatosFactura.RunWorkerAsync(EntityToEdit)
        End If

    End Sub

    Public Overrides Sub DisposeDataView()

        '        _lockUpdate = True

        MyBase.DisposeDataView()

        RemoveHandler DirectCast(cboCristalIdOjoCercaDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCristal
        RemoveHandler DirectCast(cboCristalIdOjoCercaIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCristal
        RemoveHandler DirectCast(cboCristalIdOjoLejosDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCristal
        RemoveHandler DirectCast(cboCristalIdOjoLejosIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCristal
        RemoveHandler DirectCast(cboCristalIdOjoCercaDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        RemoveHandler DirectCast(cboCristalIdOjoLejosDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        RemoveHandler DirectCast(cboCristalIdOjoCercaIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        RemoveHandler DirectCast(cboCristalIdOjoLejosIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable

    End Sub


    Protected Overrides Sub BindControls()

        MyBase.BindControls()

        cboDocumentoTipoIdFactura.Properties.DisplayMember = cboDocumentoTipoId.Properties.DisplayMember
        cboDocumentoTipoIdFactura.Properties.ValueMember = cboDocumentoTipoId.Properties.ValueMember
        cboDocumentoTipoIdFactura.Properties.DataSource = cboDocumentoTipoId.Properties.DataSource

        cboDocumentoTipoIdFactura.Enabled = False
        txtNumeroDocumentoFactura.Enabled = False
        txtFechaEmitidaFactura.Enabled = False

        AddHandler DirectCast(cboCristalIdOjoCercaDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCristal
        AddHandler DirectCast(cboCristalIdOjoCercaIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCristal
        AddHandler DirectCast(cboCristalIdOjoLejosDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCristal
        AddHandler DirectCast(cboCristalIdOjoLejosIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCristal
        AddHandler DirectCast(cboCristalIdOjoCercaDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        AddHandler DirectCast(cboCristalIdOjoLejosDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        AddHandler DirectCast(cboCristalIdOjoCercaIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        AddHandler DirectCast(cboCristalIdOjoLejosIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable

    End Sub

    Protected Overrides Sub OnEditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        MyBase.OnEditValueChanged(sender, e)

        Select Case DirectCast(sender, BaseEdit).Name
            Case txtCilindricoOjoCercaDerecho.Name, txtCilindricoOjoCercaIzquierdo.Name,
                txtEsfericoOjoCercaDerecho.Name, txtEsfericoOjoCercaIzquierdo.Name

            Case txtCilindricoOjoLejosDerecho.Name, txtCilindricoOjoLejosIzquierdo.Name,
                txtEsfericoOjoLejosDerecho.Name, txtEsfericoOjoLejosIzquierdo.Name

        End Select

    End Sub

    Protected Overrides Sub Entity2Controls()

        Entity2Controls(True)

    End Sub

    Public Overloads Sub Entity2Controls(lockUpdate As Boolean)

        Try

            If CurrentEntity Is Nothing OrElse CurrentEntity.GetType() IsNot GetType(DV_RecetaComunEntity) Then
                Return
            End If

            _lockUpdate = lockUpdate

            'If EntityToEdit.RecetaComunTipo > 0 Then
            '    Dim tipo As DV_RecetaTipoEntity = DV_RecetaTipoBEntity.GetById(EntityToEdit.RecetaComunTipo)
            '    _cercaEsSegundoPar = tipo.CercaEsSegundoPar
            'End If

            cboServiciosCerca.Properties.Items.Clear()
            cboServiciosLejos.Properties.Items.Clear()

            'If Not CurrentEntityIsNew() Then
            CargarServicios()
            'End If

            MyBase.Entity2Controls()

        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            _lockUpdate = False
        End Try

    End Sub
#End Region

#Region "Procedimientos privados"
    Protected Overridable Function CurrentEntityIsNew() As Boolean
        Return CurrentEntity IsNot Nothing AndAlso CurrentEntity.IsNew
    End Function


    Private Function GetClienteId() As Integer
        Return CInt(cboClienteId.EditValue)
    End Function

    Private Function HayQueIngresarPago() As Boolean

        Dim ingresoPago As Boolean = False
        If EntityToEdit.TipoOperacion <> RecetaComunOperacion.Presupuesto Then
            If _parametroTree.Optica.Venta.PorcentajeSeñaRecetaComun > Decimal.Zero Then
                ingresoPago = (EntityToEdit.VentaTipo = RecetaVentaTipo.Contado)
            End If
        End If

        If EntityToEdit.ImporteTotal > Decimal.Zero Then
            Return ingresoPago '= DocumentoTipoIngresoPago.Obligatorio)
        End If

        Return False

    End Function


    Private Function GetSelectedServicios(combo As CheckedComboBoxEdit) As List(Of Integer)

        Dim valores As String() = combo.Properties.GetCheckedItems().ToString().Split(combo.Properties.SeparatorChar)
        Dim toReturn As New List(Of Integer)
        For Each valor As String In valores
            Dim Id As Integer = 0I
            If Int32.TryParse(valor, Id) Then
                toReturn.Add(Id)
            End If
        Next

        Return toReturn

    End Function

    Private Function GetLocalId() As Integer
        Return LocalController.BuscarLocalIdFromCaja(EntityToEdit.CajaId)
    End Function


    Private Sub CargarCotizaciones()

        ilbCotizacion.Items.Clear()
        imgMonedas.Images.Clear()

        'ilbCotizacion.ImageIndexMember = MonedaFieldIndex.Id.ToString()
        Dim monedas As IEntityCollection2 = MonedaController.BuscarActivas(Nothing)
        Dim flagImages As Boolean = imgMonedas.Images.Count = 0

        'Dim imgMoneda As System.Windows.Forms.ImageList = ilbCotizacion.ImageList
        'If imgMoneda Is Nothing Then
        '    imgMoneda = New ImageList
        '    ilbCotizacion.ImageList = imgMoneda
        '    flagImages = True
        'End If

        For Each monedaEy As MonedaEntity In monedas

            If monedaEy.Id <> CInt(Moneda.Pesos) Then
                Dim conImagen As Boolean = False
                If flagImages AndAlso monedaEy.Imagen IsNot Nothing AndAlso monedaEy.Imagen.Length > 0 Then
                    imgMonedas.Images.Add(Image.FromStream(New System.IO.MemoryStream(monedaEy.Imagen)))
                    conImagen = True
                End If
                Dim cotiz As CotizacionEntity = CotizacionController.BuscarUltimaCotizacion(Moneda.Pesos, monedaEy.Id)
                If cotiz IsNot Nothing Then
                    Dim imageIndex As Integer = IIf(conImagen, imgMonedas.Images.Count - 1, -1I)
                    ilbCotizacion.Items.Add(String.Format("{0,5:n2}", cotiz.Importe), imageIndex)
                End If

            End If
        Next
        EntityToEdit.Id = -1
    End Sub


    Private Sub OnDismissQueryable(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

        Dim da As IDataAccessAdapter = TryCast(e.Tag, IDataAccessAdapter)
        If da IsNot Nothing Then
            da.Dispose()
        End If
        e.Tag = Nothing

    End Sub

    Private Sub OnGetQueryableCristal(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

        e.QueryableSource = (New DV_CristalBEntity).GetDataForComboAsQueryable()

    End Sub

    'Private Sub OnGetQueryableLejosDerecho(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

    '    Dim da As IDataAccessAdapter = Nothing


    '    e.QueryableSource = (New DV_CristalBEntity).GetDataForComboAsQueryable()
    '    e.Tag = da

    'End Sub

    'Private Sub OnGetQueryableCercaDerecho(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

    '    Dim da As IDataAccessAdapter = Nothing
    '    e.QueryableSource = (New DV_CristalBEntity).GetDataForComboAsQueryable()
    '    e.Tag = da

    'End Sub

    'Private Sub OnGetQueryableCercaIzquierdo(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

    '    Dim da As IDataAccessAdapter = Nothing
    '    e.QueryableSource = (New DV_CristalBEntity).GetDataForComboAsQueryable()

    '    e.Tag = da

    'End Sub


    Private Sub SetBusinessProperties(ByVal business As DV_RecetaBEntity)

        'business.Fields(DV_RecetaComunFieldIndex.CristalIdCerca.ToString()).ForeignBEntity = New DV_CristalFiltrado
        'business.Fields(DV_RecetaComunFieldIndex.CristalIdLejos.ToString()).ForeignBEntity = New DV_CristalFiltrado
        'business.Fields(DV_RecetaComunFieldIndex.ClienteId.ToString()).ForeignBEntity = New ClienteParaVentaBEntity(GetLocalId())
        'business.Fields(DV_RecetaComunFieldIndex.ConvenioId.ToString()).ForeignBEntity = New ConvenioParaVentaBEntity(GetLocalId())
        'business.Fields(DV_RecetaComunFieldIndex.BonificacionId.ToString()).ForeignBEntity = (New BonificacionBentityFactoryParaVenta(GetLocalId())).Create()
        rilkpBonificacion.DataSource = business.Fields(DV_RecetaComunFieldIndex.BonificacionId.ToString()).ForeignBEntity.GetDataForCombo()

    End Sub

    'Private Sub SetFilterParametersLejos()
    '    If cboCristalIdLejos.BusinessToUse Is Nothing Then Return

    '    With DirectCast(cboCristalIdLejos.BusinessToUse, DV_CristalFiltrado)
    '        Int32.TryParse(rgrRecetaComunTipo.EditValue, .RecetaTipoId)
    '        Int32.TryParse(cboCristalMaterialIdLejos.EditValue, .CristalMaterialId)
    '    End With
    '    cboCristalIdLejos.EditValue = Nothing
    '    cboCristalIdLejos.RefresDataSource()
    'End Sub


#End Region


    Private Sub ConfigGrds()
    End Sub


    Private Sub OnSetSecurity()

        'cboClienteId.Enabled = PtkOperacionBEntity.TienePermiso(PermisoOperacion.EditarDocumentoSalida)

    End Sub

    Private Structure facturaManualInfo
        Dim fechaEmitida As Date
        Dim numeroDocumento As String
    End Structure

    Private _facturaManualInfo As facturaManualInfo

    Private Sub bgDatosFactura_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgDatosFactura.DoWork
        Dim entity As DV_RecetaComunEntity = TryCast(e.Argument, DV_RecetaComunEntity)
        If entity IsNot Nothing Then
            e.Result = DocumentoSalidaController.BuscarFacturaDeOrden(entity.Id, entity.CajaId)
        End If

    End Sub

    Private Sub bgDatosFactura_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgDatosFactura.RunWorkerCompleted

        txtFechaEmitidaFactura.EditValue = Nothing
        cboDocumentoTipoIdFactura.EditValue = Nothing
        txtNumeroDocumentoFactura.EditValue = Nothing


        Dim documento As DocumentoSalidaEntity = TryCast(e.Result, DocumentoSalidaEntity)
        If documento IsNot Nothing Then
            cboDocumentoTipoIdFactura.EditValue = documento.DocumentoTipoId
            txtNumeroDocumentoFactura.EditValue = documento.NumeroDocumento
            txtFechaEmitidaFactura.EditValue = documento.FechaEmitida
        End If

    End Sub

    Protected Overrides Sub OnParentKeyDown(e As KeyEventArgs)
        MyBase.OnParentKeyDown(e)
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            SendKeys.SendWait("{TAB}")
        End If

    End Sub

    Public Overrides Sub OnAddingToContainer()
        'FiltrarDatosPorCaja()
        MyBase.OnAddingToContainer()
    End Sub


    'Private Sub FiltrarDatosPorCaja()

    'With BusinessToUse
    '    .Fields(dv_recetacomunfieldindex.DocumentoTipoId.ToString()).ForeignBEntity = Nothing
    '    .Fields(dv_recetacomunfieldindex.DocumentoTipoId.ToString()).ForeignBEntityFactory = New DocumentoTipoBEntityFactoryParaVenta(Me.CajaId)
    '    .Fields(dv_recetacomunfieldindex.FuncionarioId.ToString()).ForeignBEntity = Nothing
    '    .Fields(dv_recetacomunfieldindex.FuncionarioId.ToString()).ForeignBEntityFactory = New FuncionarioBEntityFactoryParaVenta(Me.CajaId)
    '    .Fields(dv_recetacomunfieldindex.ClienteId.ToString()).ForeignBEntity = Nothing
    '    .Fields(DV_RecetaComunFieldIndex.ClienteId.ToString()).ForeignBEntity = New ClienteParaVentaBEntity(LocalController.BuscarLocalIdFromCaja(CajaId))
    '    .Fields(dv_recetacomunfieldindex.ListaPreVtaId.ToString()).ForeignBEntity = Nothing
    '    .Fields(DV_RecetaComunFieldIndex.ListaPreVtaId.ToString()).ForeignBEntityFactory = New ListaPreVtaBEntityFactoryParaVenta(Me.CajaId)
    'End With

    'End Sub

    Private Sub CargarServicios()

        With GetCurrentEntity(Of DV_RecetaComunEntity)()

            If .Detalles.Count = 0 Then
                DV_RecetaComunBEntity.FetchDetalles(EntityToEdit)
            End If
            FiltrarServicios(.CristalMaterialIdLejosDerecho, cboServiciosLejos)
            FiltrarServicios(.CristalMaterialIdCercaDerecho, cboServiciosCerca)
            CheckServicios(.Detalles)

        End With

    End Sub
    Private Sub CheckServicios(detalles As EntityCollection(Of DocSalidaDetalleEntity))

        CheckServicios(detalles, cboServiciosLejos, DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS)
        CheckServicios(detalles, cboServiciosCerca, DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA)

    End Sub

    Private Sub CheckServicios(detalles As EntityCollection(Of DocSalidaDetalleEntity), combo As CheckedComboBoxEdit, flagDistancia As String)

        combo.RefreshEditValue()

        Dim servicios As List(Of DocSalidaDetalleEntity) = detalles.Where(Function(f) f.DatoExtra = flagDistancia).ToList()

        For Each servicio As DocSalidaDetalleEntity In servicios
            'Buscamos el artículo en la lista de servicios y lo marcamos como chequeado
            For Each item As CheckedListBoxItem In combo.Properties.Items
                If item.Value = servicio.ArticuloId Then
                    item.CheckState = CheckState.Checked
                    Exit For
                End If
            Next
        Next

    End Sub


    Private Sub FiltrarServicios(materialId As Integer, combo As CheckedComboBoxEdit)

        If CurrentEntity Is Nothing Then Return
        combo.Properties.Items.Clear()
        Dim da As IDataAccessAdapter = TryCast(combo, IDataAccessAdapter)
        If CurrentEntityIsNew() Then
            DirectCast(combo.Properties.DataSource, LinqServerModeSource).QueryableSource = DV_ServicioBEntity.GetDataFormComboForRecetaAsQueryable(da, materialId, GetLocalId(), CInt(cboListaPreVtaId.EditValue))
        Else
            DirectCast(combo.Properties.DataSource, LinqServerModeSource).QueryableSource = (New DV_ServicioBEntity).GetDataForComboAsQueryable(da)
        End If
        combo.Tag = da
        'combo.RefreshDataSource()

    End Sub

End Class
