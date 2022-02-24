Imports Studio.Vision.POS.BLL.Business
Imports Studio.Net.Controls.New
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Net.BLL
Imports Studio.Net.Helper
Imports DevExpress.XtraEditors
Imports Studio.Vision.POS.BLL
Imports Studio.Net.Controls.New.Forms
Imports Studio.Phone.POS.Controls.New
Imports DevExpress.Data.Linq
Imports DevExpress.XtraLayout
Imports Studio.Phone.POS.Controls.New.VentaDetailView
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Linq
Imports SD.LLBLGen.Pro.LinqSupportClasses
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Controls

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

        CajaId = ConfigReaderSpecific.GetCajaId()

        SetBusinessProperties(business)

        _parametroTree = DirectCast(ParametroSistemaController.GetParametroTree(), VisionParametroTree)

        labTotal.DataBindings.Add(New System.Windows.Forms.Binding("Text", binding, DV_RecetaComunFieldIndex.ImporteTotal.ToString(), True, DataSourceUpdateMode.OnPropertyChanged, Decimal.Zero, "n2"))
        'AddHandler txtArmazonLejosCodigo.PropertiesChanged, AddressOf OnArmazonLejosPropChanged


    End Sub

#End Region

#Region "Variable de módulo"

    Private _facturaManualInfo As facturaManualInfo

    Private Structure facturaManualInfo
        Dim fechaEmitida As Date
        Dim numeroDocumento As String
    End Structure


    Protected _lockUpdate As Boolean

    Protected _funcionarioId As Integer
    Protected _flagUpdating As Boolean
    Protected _parametroTree As Studio.Vision.POS.BLL.VisionParametroTree
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

#Region "Delegates"

    Protected Delegate Sub SetControlEditValueDelegate(control As Control, value As Object)
    Protected Delegate Sub SetControlReadOnlyDelegate(control As Control, value As Object)

#End Region

#Region "Eventos de acción"

    Protected Sub SetControlEditValue_ThreadSafe(control As BaseEdit, value As Object)

        If control.InvokeRequired() Then
            Dim del As New SetControlEditValueDelegate(AddressOf SetControlEditValue_ThreadSafe)
            Me.Invoke(del, New Object() {control, value})
        Else
            control.EditValue = value
        End If
    End Sub

    Protected Sub SetControlReadonly_ThreadSafe(control As BaseEdit, value As Boolean)

        If control.InvokeRequired() Then
            Dim del As New SetControlEditValueDelegate(AddressOf SetControlReadonly_ThreadSafe)
            Me.Invoke(del, New Object() {control, value})
        Else
            control.Properties.ReadOnly = value
        End If

    End Sub

    Private Sub txtFechaEmitida_EditValueChanged(sender As Object, e As EventArgs) Handles txtFechaEmitida.EditValueChanged
        If CurrentEntity IsNot Nothing Then
            If CurrentEntity.IsNew Then
                txtFechaEntrega.Properties.MinValue = txtFechaEmitida.DateTime
            Else
                txtFechaEntrega.Properties.MinValue = System.DateTime.MinValue

            End If
        End If
    End Sub

    Private Sub txtConvenioImporte_LostFocus(sender As Object, e As EventArgs) Handles txtConvenioImporte.LostFocus
        If txtConvenioImporte.Tag <> txtConvenioImporte.EditValue Then
            CargarArticulos()
        End If
    End Sub

    Private Sub txtConvenioImporte_Enter(sender As Object, e As EventArgs) Handles txtConvenioImporte.Enter
        txtConvenioImporte.Tag = txtConvenioImporte.EditValue
    End Sub

    Private Sub cboConvenioId_EditValueChanged(sender As Object, e As EventArgs) Handles cboConvenioId.EditValueChanged

        If cboConvenioId.EditValue Is Nothing Then
            txtConvenioImporte.Properties.ReadOnly = True
            txtConvenioNumero.Properties.ReadOnly = True
            txtConvenioImporte.EditValue = Nothing
            txtConvenioNumero.EditValue = Nothing
            cboBonificacionId.Properties.ReadOnly = False

        Else
            Dim convenio As ConvenioEntity = ConvenioController.BuscarPorId(Nothing, CInt(cboConvenioId.EditValue))
            txtConvenioNumero.Properties.ReadOnly = False
            txtConvenioImporte.Properties.ReadOnly = Not (convenio.TipoDescuento = ConvenioTipoDescuento.ImporteFijo)
            cboBonificacionId.Properties.ReadOnly = convenio.BonificacionId > 0

        End If

    End Sub

    Private Sub cboCristalIdLejosDerecho_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboCristalIdLejosDerecho.QueryPopUp

        If CurrentEntityIsNew() Then

            DxErrorProvider1.SetErrorType(cboCristalIdLejosDerecho, DXErrorProvider.ErrorType.None)
            If Not OjoLejosDerechoCargado() Then
                DxErrorProvider1.SetError(cboCristalIdLejosDerecho, "Debe ingresar algún dato de graduación antes de seleccionar el cristal", DXErrorProvider.ErrorType.Information)
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub cboCristalIdLejosIzquierdo_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboCristalIdLejosIzquierdo.QueryPopUp

        If CurrentEntityIsNew() Then

            DxErrorProvider1.SetErrorType(cboCristalIdLejosIzquierdo, DXErrorProvider.ErrorType.None)
            If Not OjoLejosIzquierdoCargado() Then
                DxErrorProvider1.SetError(cboCristalIdLejosIzquierdo, "Debe ingresar algún dato de graduación antes de seleccionar el cristal", DXErrorProvider.ErrorType.Information)
                e.Cancel = True
            End If
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

    Private Sub bgDatosFactura_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgDatosFactura.DoWork
        Dim entity As DV_RecetaComunEntity = TryCast(e.Argument, DV_RecetaComunEntity)
        If entity IsNot Nothing Then
            e.Result = DocumentoSalidaController.BuscarFacturaDeOrden(entity.Id, entity.CajaId)
        End If

    End Sub

    Private Sub rilkpBonificacion_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles rilkpBonificacion.ParseEditValue

        If e.Value Is Nothing Then
            e.Value = 0
            e.Handled = True
        End If

    End Sub

    Private Sub cboCristalIdCerca_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboCristalIdCercaDerecho.QueryPopUp

        If EntityToEdit.IsNew Then
            DxErrorProvider1.SetErrorType(cboCristalIdCercaDerecho, DXErrorProvider.ErrorType.None)
            If Not OjoCercaDerechoCargado() Then
                DxErrorProvider1.SetError(cboCristalIdCercaDerecho, "Debe ingresar algún dato de graduación antes de seleccionar el cristal", DXErrorProvider.ErrorType.Information)
                e.Cancel = True
            End If

        End If

    End Sub

    Private Sub cboCristalIdCerca_GotFocus(sender As Object, e As EventArgs) Handles cboCristalIdCercaDerecho.GotFocus
        'VerificarConversionesCerca()
    End Sub

    Private Sub VerificarConversionesCerca()
        If _parametroTree.Optica.ManejoCilindrico = ManejoCilindricos.SoloNegativo Then
            Dim cilindrico As Decimal = txtCilindricoOjoCercaDerecho.EditValue
            If cilindrico > Decimal.Zero Then
                'txtCilindricoOjoCercaDerecho.EditValue = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoCercaDerecho.EditValue += NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.Text) + cilindrico
                'txtCilindricoOjoCercaDerecho.Tag = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoCercaDerecho.Tag = txtEsfericoOjoCercaDerecho.EditValue + NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.Text) + cilindrico

                txtCilindricoOjoCercaDerecho.Tag = cilindrico * Decimal.MinusOne
                'txtEsfericoOjocercaDerecho.EditValue += cilindrico
                txtEsfericoOjoCercaDerecho.Tag = txtEsfericoOjoCercaDerecho.EditValue + cilindrico
                If txtEjeOjoCercaDerecho.Text <> String.Empty Then
                    'txtEjeOjocercaDerecho.EditValue = (NumberConversor.ParseDecimal(txtEjeOjocercaDerecho.Text) + 90) Mod 180
                    'Aquí hacemos la transposición
                    txtEjeOjoCercaDerecho.Tag = (NumberConversor.ParseDecimal(txtEjeOjoCercaDerecho.Text) + 90) Mod 180
                End If

            Else
                txtCilindricoOjoCercaDerecho.Tag = Nothing
                txtEsfericoOjoCercaDerecho.Tag = Nothing
                txtEjeOjoCercaDerecho.Tag = Nothing
            End If

            cilindrico = txtCilindricoOjoCercaIzquierdo.EditValue
            If cilindrico > Decimal.Zero Then
                'txtCilindricoOjoCercaIzquierdo.EditValue = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoCercaIzquierdo.EditValue += NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.Text) + cilindrico
                'txtCilindricoOjoCercaIzquierdo.Tag = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoCercaIzquierdo.Tag = txtEsfericoOjoCercaIzquierdo.EditValue + NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.Text) + cilindrico

                txtCilindricoOjoCercaIzquierdo.Tag = cilindrico * Decimal.MinusOne
                txtEsfericoOjoCercaIzquierdo.Tag = txtEsfericoOjoCercaIzquierdo.EditValue + cilindrico

                If txtEjeOjoCercaIzquierdo.Text <> String.Empty Then
                    'txtEjeOjocercaIzquierdo.EditValue = (NumberConversor.ParseDecimal(txtEjeOjocercaIzquierdo.Text) + 90) Mod 180
                    txtEjeOjoCercaIzquierdo.Tag = (NumberConversor.ParseDecimal(txtEjeOjoCercaIzquierdo.Text) + 90) Mod 180
                End If
            Else
                txtCilindricoOjoCercaIzquierdo.Tag = Nothing
                txtEsfericoOjoCercaIzquierdo.Tag = Nothing
                txtEjeOjoCercaIzquierdo.Tag = Nothing
            End If

        ElseIf _parametroTree.Optica.ManejoCilindrico = ManejoCilindricos.SoloPositivo Then
            Dim cilindrico As Decimal = txtCilindricoOjoCercaDerecho.EditValue
            If cilindrico < Decimal.Zero Then
                'txtCilindricoOjoCercaDerecho.EditValue = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoCercaDerecho.EditValue += NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.Text) + cilindrico
                'txtCilindricoOjoCercaDerecho.Tag = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoCercaDerecho.Tag = txtEsfericoOjoCercaDerecho.EditValue + NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.Text) + cilindrico
                txtCilindricoOjoCercaDerecho.Tag = cilindrico * Decimal.MinusOne
                txtEsfericoOjoCercaDerecho.Tag = txtEsfericoOjoCercaDerecho.EditValue + cilindrico
                If txtEjeOjoCercaDerecho.Text <> String.Empty Then
                    'txtEjeOjoCercaDerecho.EditValue = (NumberConversor.ParseDecimal(txtEjeOjoCercaDerecho.Text) + 90) Mod 180
                    txtEjeOjoCercaDerecho.Tag = (NumberConversor.ParseDecimal(txtEjeOjoCercaDerecho.Text) + 90) Mod 180
                End If
            Else
                txtCilindricoOjoCercaDerecho.Tag = Nothing
                txtEsfericoOjoCercaDerecho.Tag = Nothing
                txtEjeOjoCercaDerecho.Tag = Nothing

            End If
            cilindrico = txtCilindricoOjoCercaIzquierdo.EditValue
            If cilindrico < Decimal.Zero Then
                'txtCilindricoOjoCercaIzquierdo.EditValue = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoCercaIzquierdo.EditValue += NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.Text) + cilindrico
                'txtCilindricoOjoCercaIzquierdo.Tag = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoCercaIzquierdo.Tag = txtEsfericoOjoCercaIzquierdo.EditValue + NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.Text) + cilindrico

                txtEsfericoOjoCercaIzquierdo.Tag = txtEsfericoOjoCercaIzquierdo.EditValue + cilindrico
                If txtEjeOjoCercaIzquierdo.Text <> String.Empty Then
                    'txtEjeOjoCercaIzquierdo.EditValue = (NumberConversor.ParseDecimal(txtEjeOjoCercaIzquierdo.Text) + 90) Mod 180
                    txtEjeOjoCercaIzquierdo.Tag = (NumberConversor.ParseDecimal(txtEjeOjoCercaIzquierdo.Text) + 90) Mod 180

                End If
            Else

                txtCilindricoOjoCercaIzquierdo.Tag = Nothing
                txtEsfericoOjoCercaIzquierdo.Tag = Nothing
                txtEjeOjoCercaIzquierdo.Tag = Nothing
            End If

        End If
    End Sub

    Private Sub txtArmazonLejosCodigo_Validating(sender As Object, e As CancelEventArgs)

        'e.Cancel = txtArmazonLejosCodigo.Text <> String.Empty AndAlso Not BuscarArmazon(cboArmazonIdLejos, txtArmazonLejosCodigo.Text)
        'If e.Cancel Then
        '    txtArmazonLejosCodigo.ErrorText = "Código inválido"
        '    txtArmazonLejosCodigo.EditValue = Nothing
        'End If
        'txtArmazonLejosCodigo.EditValue = Nothing
    End Sub

    Private Sub txtArmazonCercaCodigo_Validating(sender As Object, e As CancelEventArgs)

        'e.Cancel = txtArmazonCercaCodigo.Text <> String.Empty AndAlso Not BuscarArmazon(cboArmazonIdCerca, txtArmazonCercaCodigo.Text)
        'If e.Cancel Then
        '    txtArmazonCercaCodigo.ErrorText = "Código inválido"
        '    txtArmazonCercaCodigo.EditValue = Nothing
        'End If

    End Sub

    Private Sub bgwImporteSeña_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwImporteSeña.RunWorkerCompleted
        txtImporteSeña.EditValue = e.Result
    End Sub

    Private Sub cboCristalIdLejos_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboCristalIdLejosDerecho.QueryPopUp

        If EntityToEdit.IsNew Then

            DxErrorProvider1.SetErrorType(cboCristalIdLejosDerecho, DXErrorProvider.ErrorType.None)
            If Not OjoLejosDerechoCargado() Then
                DxErrorProvider1.SetError(cboCristalIdLejosDerecho, "Debe ingresar algún dato de graduación antes de seleccionar el cristal", DXErrorProvider.ErrorType.Information)
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub cboCristalIdLejos_GotFocus(sender As Object, e As EventArgs) Handles cboCristalIdLejosDerecho.GotFocus, cboCristalIdLejosIzquierdo.GotFocus

        'If _parametroTree.Optica.ManejoCilindrico = ManejoCilindricos.SoloNegativo Then

        '    Dim cilindrico As Decimal = txtCilindricoOjoLejosDerecho.EditValue
        '    If cilindrico > Decimal.Zero Then
        '        'txtCilindricoOjoLejosDerecho.EditValue = cilindrico * Decimal.MinusOne
        '        txtCilindricoOjoLejosDerecho.Tag = cilindrico * Decimal.MinusOne
        '        'txtEsfericoOjoLejosDerecho.EditValue += cilindrico
        '        txtEsfericoOjoLejosDerecho.Tag = txtEsfericoOjoLejosDerecho.EditValue + cilindrico
        '        If txtEjeOjoLejosDerecho.Text <> String.Empty Then
        '            'txtEjeOjoLejosDerecho.EditValue = (NumberConversor.ParseDecimal(txtEjeOjoLejosDerecho.Text) + 90) Mod 180
        '            'Aquí hacemos la transposición
        '            txtEjeOjoLejosDerecho.Tag = (NumberConversor.ParseDecimal(txtEjeOjoLejosDerecho.Text) + 90) Mod 180
        '        End If

        '    End If

        '    cilindrico = txtCilindricoOjoLejosIzquierdo.EditValue

        '    If cilindrico > Decimal.Zero Then
        '        'txtCilindricoOjoLejosIzquierdo.EditValue = cilindrico * Decimal.MinusOne
        '        'txtEsfericoOjoLejosIzquierdo.EditValue += cilindrico
        '        txtCilindricoOjoLejosIzquierdo.Tag = cilindrico * Decimal.MinusOne
        '        txtEsfericoOjoLejosIzquierdo.Tag = txtEsfericoOjoLejosIzquierdo.EditValue + cilindrico

        '        If txtEjeOjoLejosIzquierdo.Text <> String.Empty Then
        '            'txtEjeOjoLejosIzquierdo.EditValue = (NumberConversor.ParseDecimal(txtEjeOjoLejosIzquierdo.Text) + 90) Mod 180
        '            txtEjeOjoLejosIzquierdo.Tag = (NumberConversor.ParseDecimal(txtEjeOjoLejosIzquierdo.Text) + 90) Mod 180
        '        End If
        '    End If

        'ElseIf _parametroTree.Optica.ManejoCilindrico = ManejoCilindricos.SoloPositivo Then


        '    Dim cilindrico As Decimal = txtCilindricoOjoLejosDerecho.EditValue
        '    If cilindrico < Decimal.Zero Then

        '        'txtCilindricoOjoLejosDerecho.EditValue = cilindrico * Decimal.MinusOne
        '        'txtEsfericoOjoLejosDerecho.EditValue += cilindrico
        '        txtCilindricoOjoLejosDerecho.Tag = cilindrico * Decimal.MinusOne
        '        txtEsfericoOjoLejosDerecho.Tag = txtEsfericoOjoLejosDerecho.EditValue + cilindrico
        '        If txtEjeOjoCercaDerecho.Text <> String.Empty Then
        '            'txtEjeOjoCercaDerecho.EditValue = (NumberConversor.ParseDecimal(txtEjeOjoCercaDerecho.Text) + 90) Mod 180
        '            txtEjeOjoCercaDerecho.Tag = (NumberConversor.ParseDecimal(txtEjeOjoCercaDerecho.Text) + 90) Mod 180
        '        End If


        '    End If
        '    cilindrico = txtCilindricoOjoLejosIzquierdo.EditValue
        '    If cilindrico < Decimal.Zero Then
        '        'txtCilindricoOjoLejosIzquierdo.EditValue = cilindrico * Decimal.MinusOne
        '        'txtEsfericoOjoLejosIzquierdo.EditValue += cilindrico
        '        txtCilindricoOjoLejosIzquierdo.Tag = cilindrico * Decimal.MinusOne
        '        txtEsfericoOjoLejosIzquierdo.Tag = txtEsfericoOjoLejosIzquierdo.EditValue + cilindrico
        '        If txtEjeOjoCercaIzquierdo.Text <> String.Empty Then
        '            'txtEjeOjoCercaIzquierdo.EditValue = (NumberConversor.ParseDecimal(txtEjeOjoCercaIzquierdo.Text) + 90) Mod 180
        '            txtEjeOjoCercaIzquierdo.Tag = (NumberConversor.ParseDecimal(txtEjeOjoCercaIzquierdo.Text) + 90) Mod 180

        '        End If
        '    End If

        'End If
    End Sub

    Private Sub bgwDetalles_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwDetalles.RunWorkerCompleted

        If EntityToEdit Is Nothing Then Return

        labTotal.Text = EntityToEdit.ImporteTotal.ToString("n2")

        _lastCargaArticulosOk = e.Result

        DxErrorProvider1.ClearErrors()

        Dim errors As Dictionary(Of String, String) = EntityToEdit.GetDataErrorInfoErroresPerField()
        If errors IsNot Nothing Then

            If errors.ContainsKey(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString()) Then
                DxErrorProvider1.SetError(cboCristalIdLejosDerecho, errors(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString()), DXErrorProvider.ErrorType.Warning)
            Else
                DxErrorProvider1.SetErrorType(cboCristalIdLejosDerecho, DXErrorProvider.ErrorType.None)
            End If
            If errors.ContainsKey(DV_RecetaComunFieldIndex.CristalIdLejosIzquierdo.ToString()) Then
                DxErrorProvider1.SetError(cboCristalIdLejosIzquierdo, errors(DV_RecetaComunFieldIndex.CristalIdLejosIzquierdo.ToString()), DXErrorProvider.ErrorType.Warning)
            Else
                DxErrorProvider1.SetErrorType(cboCristalIdLejosIzquierdo, DXErrorProvider.ErrorType.None)
            End If

            If errors.ContainsKey(DV_RecetaComunFieldIndex.CristalIdCercaDerecho.ToString()) Then
                DxErrorProvider1.SetError(cboCristalIdCercaDerecho, errors(DV_RecetaComunFieldIndex.CristalIdCercaDerecho.ToString()), DXErrorProvider.ErrorType.Warning)
            Else
                DxErrorProvider1.SetErrorType(cboCristalIdCercaDerecho, DXErrorProvider.ErrorType.None)
            End If
            If errors.ContainsKey(DV_RecetaComunFieldIndex.CristalIdCercaIzquierdo.ToString()) Then
                DxErrorProvider1.SetError(cboCristalIdCercaIzquierdo, errors(DV_RecetaComunFieldIndex.CristalIdCercaIzquierdo.ToString()), DXErrorProvider.ErrorType.Warning)
            Else
                DxErrorProvider1.SetErrorType(cboCristalIdCercaIzquierdo, DXErrorProvider.ErrorType.None)
            End If

            If errors.ContainsKey(DV_RecetaComunFieldIndex.ArmazonIdLejos.ToString()) Then
                DxErrorProvider1.SetError(cboArmazonIdLejos, errors(DV_RecetaComunFieldIndex.ArmazonIdLejos.ToString()), DXErrorProvider.ErrorType.Warning)
            Else
                DxErrorProvider1.SetErrorType(cboArmazonIdLejos, DXErrorProvider.ErrorType.None)
            End If
            If errors.ContainsKey(DV_RecetaComunFieldIndex.ArmazonIdCerca.ToString()) Then
                DxErrorProvider1.SetError(cboArmazonIdCerca, errors(DV_RecetaComunFieldIndex.ArmazonIdCerca.ToString()), DXErrorProvider.ErrorType.Warning)
            Else
                DxErrorProvider1.SetErrorType(cboArmazonIdCerca, DXErrorProvider.ErrorType.None)
            End If

            EntityToEdit.ClearErrors()
        End If

    End Sub

    Private Sub bgwDetalles_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwDetalles.DoWork
        e.Result = CargarArticulosInternal()
    End Sub

    Private Sub datosCercaOtros_EditValueChanged(sender As Object, e As EventArgs) Handles txtEsfericoOjoCercaDerecho.EditValueChanged, txtEsfericoOjoCercaIzquierdo.EditValueChanged

        Dim item As LayoutControlItem = TryCast(LayoutControl.FocusHelper.SelectedComponent, LayoutControlItem)
        If item IsNot Nothing Then

            Dim fControl As Control = item.Control
            If Not _cercaEsSegundoPar AndAlso (fControl Is txtEsfericoOjoCercaDerecho OrElse fControl Is txtEsfericoOjoCercaIzquierdo) Then
                UpdateDatosLejos()
            End If
        End If

    End Sub

    Private Sub precios_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboCristalIdLejosDerecho.EditValueChanged, cboCristalIdCercaDerecho.EditValueChanged, cboCristalIdLejosIzquierdo.EditValueChanged, cboCristalIdCercaIzquierdo.EditValueChanged, cboMonedaId.EditValueChanged, cboListaPreVtaId.EditValueChanged, cboServiciosCerca.EditValueChanged, cboServiciosLejos.EditValueChanged, cboArmazonIdCerca.EditValueChanged, cboArmazonIdLejos.EditValueChanged, txtCantidadArmazonCerca.EditValueChanged, txtCantidadArmazonLejos.EditValueChanged

        If Not _lockUpdate Then
            CargarArticulos()
        End If

        If sender Is cboMonedaId Then
            lciTotal.Text = String.Format("Total {0}:", cboMonedaId.Text)
        End If
    End Sub


    Private Sub datosOtrosLejos_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEjeOjoLejosDerecho.EditValueChanged, txtEjeOjoLejosIzquierdo.EditValueChanged, txtAdicionOjoLejosDerecho.EditValueChanged, txtAdicionOjoLejosIzquierdo.EditValueChanged, txtDistanciaOjoLejosDerecho.EditValueChanged, txtDistanciaOjoLejosIzquierdo.EditValueChanged, txtAlturaOjoLejosDerecho.EditValueChanged, txtAlturaOjoLejosIzquierdo.EditValueChanged, txtPrismaOjoLejosDerecho.EditValueChanged, txtPrismaOjoLejosIzquierdo.EditValueChanged

        If Not _cercaEsSegundoPar AndAlso Not _lockUpdate Then
            UpdateDatosCerca()
        End If

    End Sub

    Private Sub datosClaveLejosIzquierdo_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCilindricoOjoLejosIzquierdo.EditValueChanged, txtEsfericoOjoLejosIzquierdo.EditValueChanged, cboCristalMaterialIdLejosIzquierdo.EditValueChanged, rgrRecetaComunTipo.EditValueChanged, cboListaPreVtaId.EditValueChanged, txtAdicionOjoLejosIzquierdo.EditValueChanged, cboCristalIdLejosIzquierdo.EditValueChanged, txtCantidadOjoLejosIzquierdo.EditValueChanged, txtEjeOjoLejosIzquierdo.EditValueChanged

        If CurrentEntityIsNew() AndAlso Not _lockUpdate Then

            If sender Is rgrRecetaComunTipo Then
                OnRecetaTipoChanged(DirectCast(sender, RadioGroup))
            End If

            If sender IsNot cboCristalIdLejosIzquierdo Then
                cboCristalIdLejosIzquierdo.RefreshDataSource()
            End If

            If sender Is cboListaPreVtaId Then
                With DirectCast(BusinessToUse.Fields(DV_RecetaComunFieldIndex.ArmazonIdLejos.ToString()).ForeignBEntity, DV_Armazon)
                    .CajaId = Me.CajaId
                    .ListaPreVtaId = CInt(cboListaPreVtaId.EditValue)
                End With
                cboArmazonIdLejos.RefresDataSource()
            End If

            If sender Is cboCristalMaterialIdLejosIzquierdo Then
                FiltrarServicios(CInt(cboCristalMaterialIdLejosIzquierdo.EditValue), cboServiciosLejos)
            End If

            If Not _cercaEsSegundoPar Then

                UpdateDatosCerca()

            Else

                If sender Is txtAdicionOjoLejosIzquierdo OrElse sender Is cboCristalIdLejosIzquierdo Then
                    If txtAdicionOjoLejosIzquierdo.Text <> String.Empty AndAlso IsNumeric(txtEsfericoOjoLejosIzquierdo.EditValue) Then

                        UpdateDatosCerca()

                        If Not cboCristalMaterialIdCercaIzquierdo.HasValue() Then
                            cboCristalMaterialIdCercaIzquierdo.EditValue = cboCristalMaterialIdLejosIzquierdo.EditValue
                        End If
                        If Not cboCristalIdCercaIzquierdo.HasValue() Then
                            cboCristalIdCercaIzquierdo.EditValue = cboCristalIdLejosIzquierdo.EditValue
                        End If

                    End If
                End If

                If sender Is txtAdicionOjoLejosIzquierdo OrElse sender Is cboCristalIdLejosIzquierdo Then
                    If txtAdicionOjoLejosIzquierdo.Text <> String.Empty AndAlso IsNumeric(txtEsfericoOjoLejosIzquierdo.EditValue) Then

                        'txtEsfericoOjoCercaIzquierdo.EditValue = NumberConversor.ParseDecimal(txtEsfericoOjoLejosIzquierdo.Text) + NumberConversor.ParseDecimal(txtAdicionOjoLejosIzquierdo.Text)
                        UpdateDatosCerca()

                        If Not cboCristalMaterialIdCercaIzquierdo.HasValue() Then
                            cboCristalMaterialIdCercaIzquierdo.EditValue = cboCristalMaterialIdLejosIzquierdo.EditValue
                        End If
                        If Not cboCristalIdCercaIzquierdo.HasValue() Then
                            cboCristalIdCercaIzquierdo.EditValue = cboCristalIdLejosIzquierdo.EditValue
                        End If

                    End If
                End If
            End If

        End If

    End Sub

    Private Sub datosClaveLejosDerecho_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCilindricoOjoLejosDerecho.EditValueChanged, txtEsfericoOjoLejosDerecho.EditValueChanged, cboCristalMaterialIdLejosDerecho.EditValueChanged, rgrRecetaComunTipo.EditValueChanged, cboListaPreVtaId.EditValueChanged, txtAdicionOjoLejosDerecho.EditValueChanged, cboCristalIdLejosDerecho.EditValueChanged, txtCantidadOjoLejosDerecho.EditValueChanged, txtEjeOjoLejosDerecho.EditValueChanged

        If CurrentEntityIsNew() AndAlso Not _lockUpdate Then

            If sender Is rgrRecetaComunTipo Then
                OnRecetaTipoChanged(DirectCast(sender, RadioGroup))
            End If

            If sender IsNot cboCristalIdLejosDerecho Then
                cboCristalIdLejosDerecho.RefreshDataSource()
            End If

            If sender Is cboListaPreVtaId Then
                With DirectCast(BusinessToUse.Fields(DV_RecetaComunFieldIndex.ArmazonIdLejos.ToString()).ForeignBEntity, DV_Armazon)
                    .CajaId = Me.CajaId
                    .ListaPreVtaId = CInt(cboListaPreVtaId.EditValue)
                End With
                cboArmazonIdLejos.RefresDataSource()
            End If

            If sender Is cboCristalMaterialIdLejosDerecho Then
                FiltrarServicios(CInt(cboCristalMaterialIdLejosDerecho.EditValue), cboServiciosLejos)
            End If

            If Not _cercaEsSegundoPar Then

                UpdateDatosCerca()

            Else

                If sender Is txtAdicionOjoLejosDerecho OrElse sender Is cboCristalIdLejosDerecho Then
                    If txtAdicionOjoLejosDerecho.Text <> String.Empty AndAlso IsNumeric(txtEsfericoOjoLejosDerecho.EditValue) Then

                        'txtEsfericoOjoCercaDerecho.EditValue = NumberConversor.ParseDecimal(txtEsfericoOjoLejosDerecho.Text) + NumberConversor.ParseDecimal(txtAdicionOjoLejosDerecho.Text)
                        UpdateDatosCerca()

                        If Not cboCristalMaterialIdCercaDerecho.HasValue() Then
                            cboCristalMaterialIdCercaDerecho.EditValue = cboCristalMaterialIdLejosDerecho.EditValue
                        End If
                        If Not cboCristalIdCercaDerecho.HasValue() Then
                            cboCristalIdCercaDerecho.EditValue = cboCristalIdLejosDerecho.EditValue
                        End If

                    End If
                End If

                If sender Is txtAdicionOjoLejosIzquierdo OrElse sender Is cboCristalIdLejosDerecho Then
                    If txtAdicionOjoLejosIzquierdo.Text <> String.Empty AndAlso IsNumeric(txtEsfericoOjoLejosIzquierdo.EditValue) Then

                        'txtEsfericoOjoCercaIzquierdo.EditValue = NumberConversor.ParseDecimal(txtEsfericoOjoLejosIzquierdo.Text) + NumberConversor.ParseDecimal(txtAdicionOjoLejosIzquierdo.Text)
                        UpdateDatosCerca()

                        If Not cboCristalMaterialIdCercaDerecho.HasValue() Then
                            cboCristalMaterialIdCercaDerecho.EditValue = cboCristalMaterialIdLejosDerecho.EditValue
                        End If
                        If Not cboCristalIdCercaDerecho.HasValue() Then
                            cboCristalIdCercaDerecho.EditValue = cboCristalIdLejosDerecho.EditValue
                        End If

                    End If
                End If
            End If

        End If

    End Sub

    Private Sub datosCerca_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCilindricoOjoCercaDerecho.EditValueChanged, txtCilindricoOjoCercaIzquierdo.EditValueChanged, txtEsfericoOjoCercaDerecho.EditValueChanged, txtEsfericoOjoCercaIzquierdo.EditValueChanged, cboCristalMaterialIdCercaDerecho.EditValueChanged, cboCristalMaterialIdCercaIzquierdo.EditValueChanged, rgrRecetaComunTipo.EditValueChanged, cboListaPreVtaId.EditValueChanged, txtCantidadOjoCercaDerecho.EditValueChanged, txtCantidadOjoCercaIzquierdo.EditValueChanged, txtEjeOjoCercaDerecho.EditValueChanged, txtEjeOjoCercaIzquierdo.EditValueChanged

        If CurrentEntityIsNew() AndAlso Not _lockUpdate Then

            If sender Is rgrRecetaComunTipo Then
                OnRecetaTipoChanged(DirectCast(sender, RadioGroup))
            End If

            If sender IsNot txtCilindricoOjoCercaIzquierdo AndAlso sender IsNot txtEsfericoOjoCercaIzquierdo AndAlso sender IsNot cboCristalMaterialIdCercaIzquierdo Then
                cboCristalIdCercaDerecho.RefreshDataSource()
            End If
            If sender IsNot txtCilindricoOjoCercaDerecho AndAlso sender IsNot txtEsfericoOjoCercaDerecho AndAlso sender IsNot cboCristalMaterialIdCercaDerecho Then
                cboCristalIdCercaIzquierdo.RefreshDataSource()
            End If


            If sender Is cboListaPreVtaId Then
                With DirectCast(BusinessToUse.Fields(DV_RecetaComunFieldIndex.ArmazonIdCerca.ToString()).ForeignBEntity, DV_Armazon)
                    .CajaId = Me.CajaId
                    .ListaPreVtaId = CInt(cboListaPreVtaId.EditValue)
                End With
                cboArmazonIdCerca.RefresDataSource()
            End If
            If sender Is cboCristalMaterialIdCercaDerecho Then
                FiltrarServicios(CInt(cboCristalMaterialIdCercaDerecho.EditValue), cboServiciosCerca)
            End If
        End If

    End Sub

    Private Sub rgrTipoOperacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles rgrTipoOperacion.SelectedIndexChanged

        rgrVentaTipo.EditValue = CType(RecetaVentaTipo.Contado, Integer)

        If rgrTipoOperacion.EditValue = RecetaComunOperacion.Presupuesto Then
            rgrVentaTipo.Properties.ReadOnly = True
            cboDoctorId.Properties.ReadOnly = True
            txtFechaEntrega.Properties.ReadOnly = True

            'TODO: Agregar vigencia de presupuesto
            txtFechaEntrega.EditValue = System.DateTime.Today
            _lockUpdate = True
            txtCilindricoOjoLejosDerecho.EditValue = Decimal.Zero
            txtCilindricoOjoLejosIzquierdo.EditValue = Decimal.Zero
            _lockUpdate = False
            txtEsfericoOjoLejosDerecho.EditValue = Decimal.Zero
            txtEsfericoOjoLejosIzquierdo.EditValue = Decimal.Zero
            CargarArticulos()
        Else

            rgrVentaTipo.Properties.ReadOnly = False
            cboDoctorId.Properties.ReadOnly = False
            txtFechaEntrega.Properties.ReadOnly = False
            If _parametroTree.Optica.DiaEntregaRecetaComun > 0 Then
                txtFechaEntrega.EditValue = System.DateTime.Today.AddBusinessDays(_parametroTree.Optica.DiaEntregaRecetaComun, _parametroTree.Calendario)
            End If

        End If

    End Sub

    Private Sub BarManager1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarManager1.ItemClick

        Select Case e.Item.Name
            Case bbiNuevoClienteEmpresa.Name
                NewCliente(ClienteTipo.Empresa)
            Case bbiNuevoClienteParticular.Name
                NewCliente(ClienteTipo.Particular)
        End Select

    End Sub

    Private Sub cboClienteId_LostFocus(sender As Object, e As System.EventArgs) Handles cboClienteId.LostFocus

        If Not IsDisposed Then

            If cboClienteId.EditValue Is Nothing AndAlso cboClienteId.Tag IsNot Nothing Then
                LimpiarCliente()
            Else
                'If cboClienteId.EditValue <> cboClienteId.Tag OrElse (cboClienteId.Tag Is Nothing AndAlso cboClienteId.EditValue IsNot Nothing) Then
                '    CargarDatosCliente(CType(cboClienteId.EditValue, Integer))
                'End If

            End If

        End If

    End Sub



    Private Sub cboClienteId_GotFocus(sender As Object, e As System.EventArgs) Handles cboClienteId.GotFocus
        cboClienteId.Tag = cboClienteId.EditValue

    End Sub

    Private Sub txtClienteIdentificacion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtClienteIdentificacion.Validating

        Try
            If Not CurrentEntityIsNew() Then Return

            DxErrorProvider1.SetError(txtClienteIdentificacion, String.Empty)
            If txtClienteIdentificacion.Text <> txtClienteIdentificacion.Tag AndAlso
                    Not String.IsNullOrEmpty(txtClienteIdentificacion.Text) Then
                CursorManager.WaitCursor()

                Dim clienteId As Integer = ClienteController.BuscarPorIdentificacion(txtClienteIdentificacion.Text, GetLocalId())

                If clienteId = 0 Then
                    DxErrorProvider1.SetError(txtClienteIdentificacion, "Cliente no identificado")
                    cboClienteId.EditValue = Nothing
                    e.Cancel = True
                Else

                    cboClienteId.EditValue = clienteId

                    CargarDatosCliente(clienteId)
                End If
            ElseIf txtClienteIdentificacion.Text <> txtClienteIdentificacion.Tag AndAlso
                String.IsNullOrEmpty(txtClienteIdentificacion.Text) Then
                cboClienteId.EditValue = Nothing
                LimpiarDatosCliente()
            End If

        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            CursorManager.Default()
        End Try

    End Sub

    Private Sub txtClienteIdentificacion_GotFocus(sender As Object, e As System.EventArgs) Handles txtClienteIdentificacion.GotFocus
        txtClienteIdentificacion.Tag = txtClienteIdentificacion.Text
    End Sub

    Private Sub cboBonificacionId_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboBonificacionId.EditValueChanged
        RefrescarTotal()
    End Sub

    Private Sub RecetaLenteComun_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetLayoutProperties()
        LayoutControl.ActiveControl = txtClienteIdentificacion

    End Sub

    Private Sub cboClienteId_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClienteId.EditValueChanged

        Try

            If CurrentEntityIsNew() Then

                Dim clienteId As Integer = CType(cboClienteId.EditValue, Integer)
                If clienteId <> 0 Then
                    Do While bgwCliente.IsBusy
                        Application.DoEvents()
                    Loop
                    bgwCliente.RunWorkerAsync(clienteId)
                Else
                    LimpiarDatosCliente()
                End If
                'DxErrorProvider1.ClearErrors()
            End If

        Catch ex As Exception

            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

#Region "Overrides"

    Public Overrides Sub UndoChanges()
        MyBase.UndoChanges()
        CargarDatosPorDefecto()
        'OnSetSecurity()
    End Sub

    Protected Overrides Sub Controls2Entity()

        If EntityToEdit Is Nothing Then Return

        MyBase.Controls2Entity()

        With DirectCast(EntityToEdit, DV_RecetaComunEntity)

            .CajaId = Me.CajaId
            .FechaIngresada = System.DateTime.Today

            If .ClienteId > 0 AndAlso ClienteController.AdministraEmpresa(.ClienteId) Then
                .DepositoIdAdministrado = CInt(cboDepositoIdAdministrado.EditValue)
            End If

            Decimal.TryParse(txtCilindricoOjoCercaDerecho.GetEditValueWithTag(), .CilindricoOjoCercaDerechoCalc)
            Decimal.TryParse(txtCilindricoOjoCercaIzquierdo.GetEditValueWithTag(), .CilindricoOjoCercaIzquierdoCalc)
            Decimal.TryParse(txtCilindricoOjoLejosDerecho.GetEditValueWithTag(), .CilindricoOjoLejosDerechoCalc)
            Decimal.TryParse(txtCilindricoOjoLejosIzquierdo.GetEditValueWithTag(), .CilindricoOjoLejosIzquierdoCalc)

            Decimal.TryParse(txtEsfericoOjoCercaDerecho.GetEditValueWithTag(), .EsfericoOjoCercaDerechoCalc)
            Decimal.TryParse(txtEsfericoOjoCercaIzquierdo.GetEditValueWithTag(), .EsfericoOjoCercaIzquierdoCalc)
            Decimal.TryParse(txtEsfericoOjoLejosDerecho.GetEditValueWithTag(), .EsfericoOjoLejosDerechoCalc)
            Decimal.TryParse(txtEsfericoOjoLejosIzquierdo.GetEditValueWithTag(), .EsfericoOjoLejosIzquierdoCalc)

            Decimal.TryParse(txtEjeOjoCercaDerecho.GetEditValueWithTag(), .EjeOjoCercaDerechoCalc)
            Decimal.TryParse(txtEjeOjoCercaIzquierdo.GetEditValueWithTag(), .EjeOjoCercaIzquierdoCalc)
            Decimal.TryParse(txtEjeOjoLejosDerecho.GetEditValueWithTag(), .EjeOjoLejosDerechoCalc)
            Decimal.TryParse(txtEjeOjoLejosIzquierdo.GetEditValueWithTag(), .EjeOjoLejosIzquierdoCalc)

            If Not .ArmazonIdCerca > 0 Then
                .SetNewFieldValue(DV_RecetaComunFieldIndex.CantidadArmazonCerca.ToString(), 0S)
            End If
            If Not .ArmazonIdLejos > 0 Then
                .SetNewFieldValue(DV_RecetaComunFieldIndex.CantidadArmazonLejos.ToString(), 0S)
            End If
            If Not .CristalIdLejosDerecho > 0 Then
                .SetNewFieldValue(DV_RecetaComunFieldIndex.CristalMaterialIdLejosDerecho.ToString(), Nothing)
                .SetNewFieldValue(DV_RecetaComunFieldIndex.CantidadOjoLejosDerecho.ToString(), 0S)
            End If
            If Not .CristalIdLejosIzquierdo > 0 Then
                .SetNewFieldValue(DV_RecetaComunFieldIndex.CristalMaterialIdLejosIzquierdo.ToString(), Nothing)
                .SetNewFieldValue(DV_RecetaComunFieldIndex.CantidadOjoLejosIzquierdo.ToString(), 0S)
            End If
            If Not .CristalIdCercaDerecho > 0 Then
                .SetNewFieldValue(DV_RecetaComunFieldIndex.CristalMaterialIdCercaDerecho.ToString(), Nothing)
                .SetNewFieldValue(DV_RecetaComunFieldIndex.CantidadOjoCercaDerecho.ToString(), 0S)
            End If
            If Not .CristalIdCercaIzquierdo > 0 Then
                .SetNewFieldValue(DV_RecetaComunFieldIndex.CristalMaterialIdCercaIzquierdo.ToString(), Nothing)
                .SetNewFieldValue(DV_RecetaComunFieldIndex.CantidadOjoCercaIzquierdo.ToString(), 0S)
            End If


        End With

    End Sub

    Public Overrides Sub OnAddingToContainer()
        FiltrarDatosPorCaja()
        MyBase.OnAddingToContainer()
    End Sub

    Protected Overrides Sub OnParentKeyUp(e As KeyEventArgs)
        MyBase.OnParentKeyUp(e)
    End Sub

    Protected Overrides Sub OnParentKeyDown(e As KeyEventArgs)

        MyBase.OnParentKeyDown(e)

        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            LayoutControl.FocusHelper.ProcessDialogKey(Keys.Tab)

        Else
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                If TypeOf ActiveControl Is LayoutControl Then
                    If DirectCast(ActiveControl, LayoutControl).ActiveControl IsNot Nothing AndAlso DirectCast(ActiveControl, LayoutControl).ActiveControl.Parent IsNot Nothing Then
                        If TypeOf DirectCast(ActiveControl, LayoutControl).ActiveControl.Parent Is SpinEdit OrElse
                            TypeOf DirectCast(ActiveControl, LayoutControl).ActiveControl Is RadioGroup Then

                            If Not e.Shift Then
                                e.SuppressKeyPress = True
                                e.Handled = True
                            End If
                        End If
                    End If
                End If
            End If
        End If

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


    Public Overrides Function SaveCurrent() As Boolean

        If Not CurrentEntity.IsNew Then Return False
        gvItems.UpdateCurrentRow()

        Do While bgwCliente.IsBusy OrElse bgwDetalles.IsBusy
            Application.DoEvents()
            System.Threading.Thread.Sleep(100)
        Loop

        'If Not CargarArticulosInternal() Then
        '    Return False
        'End If
        'bgwDetalles.RunWorkerAsync()

        'Do While bgwCliente.IsBusy OrElse bgwDetalles.IsBusy
        ' System.Threading.Thread.Sleep(500)
        'Application.DoEvents()
        'Loop

        If Not _lastCargaArticulosOk Then Return False
        'Dim flag As Boolean = MyBase.SaveCurrent()

        Try

            'If flag Then
            Dim ok As Boolean = False
            If Not Me._flagUpdating Then
                _ventaSaved = False

                Me._flagUpdating = True

                If Save(True) Then

                    If Me.HayQueIngresarPago() Then
                        ok = Me.InicializarPago()
                    Else
                        Dim args As New PagoFinalizadoEventArgs(Decimal.Zero, Nothing, String.Empty, System.DateTime.Today, String.Empty, Nothing)
                        Me.FinalizarVenta(False, args)
                        ok = Not args.Cancel
                    End If

                End If
            Else
                Return False

            End If
            If ok Then

                OnCurrentEntityChanged(Me, EventArgs.Empty)

                Entity2Controls()
            End If
            'End If
            Return _ventaSaved
        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Me._flagUpdating = False
            'Me.btConfirmarVenta.Enabled = True
        End Try

        Return False 'Devolver false aparqa que no haga AddNew automaticamente

    End Function

    Protected Overrides Sub OnCurrentEntityChanged(sender As Object, e As System.EventArgs)

        MyBase.OnCurrentEntityChanged(sender, e)

        If CurrentEntity IsNot Nothing Then

            If (EntityToEdit.Detalles.Count = 0I OrElse EntityToEdit.Cobros.Count = 0I) AndAlso Not CurrentEntityIsNew() Then
                DocumentoSalidaController.FetchDetalles(EntityToEdit)
            End If

            grdItems.DataSource = EntityToEdit.Detalles
            grdFPago.DataSource = DocSalida_PagoDocSalidaController.FetchTypeListPagos(EntityToEdit)

            LayoutControl.OptionsView.IsReadOnly = IIf(CurrentEntityIsNew(), DevExpress.Utils.DefaultBoolean.Default, DevExpress.Utils.DefaultBoolean.True)
            Dim isReadOnly As Boolean = LayoutControl.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True

            If Not isReadOnly Then
                LockControls()
            End If

            btnOpcionCliente.Enabled = Not isReadOnly AndAlso PtkOperacionBEntity.TienePermiso(PermisoOperacion.CrearClientes)
            cboBonificacionId.Properties.ReadOnly = isReadOnly OrElse Not PtkOperacionBEntity.TienePermiso(PermisoOperacion.BonificarRecetas)

            gColBonificacion.OptionsColumn.ReadOnly = cboBonificacionId.Properties.ReadOnly
            gColUnitario.OptionsColumn.ReadOnly = isReadOnly

            gvItems.OptionsBehavior.Editable = Not isReadOnly

            If EntityToEdit.Devolucion Then
                labTotal.ForeColor = Color.Red
            Else
                labTotal.ForeColor = SystemColors.MenuHighlight
            End If

            If Not bgDatosFactura.IsBusy Then
                bgDatosFactura.RunWorkerAsync(EntityToEdit)
            End If
            If Not bgwImporteSeña.IsBusy Then
                bgwImporteSeña.RunWorkerAsync(EntityToEdit)
            End If

            _documentoRelacionado = Nothing
        End If

    End Sub

    Protected Overrides Sub OnLoad(e As System.EventArgs)

        If Not Environment.DesignMode Then
            MyBase.OnLoad(e)
            If CurrentEntityIsNew() Then
                CargarDatosPorDefecto()
            End If
            OnSetSecurity()
            'Dim q As IQueryable = DV_CristalBEntity.GetQueryableForReceta(Studio.Net.Helper.DAL.DataAccessAdapter.Create(), 0, 0, 0, 0, 0, 0, 1, 1, rgrRecetaComunTipo.EditValue, _parametroTree)

            'Dim l As String = (From d In q Select d).ToString

            ''Dim col As IEntityCollection2 = CType(q, ILLBLGenProQuery).Execute(Of EntityCollection(Of DV_CristalEntity))()
            'Stop
        End If

    End Sub


    Public Overrides Sub AddNew()
        MyBase.AddNew()
        CargarDatosPorDefecto()
    End Sub

    Public Overrides Sub DisposeDataView()

        '        _lockUpdate = True

        MyBase.DisposeDataView()

        RemoveHandler DirectCast(cboCristalIdCercaDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCercaDerecho
        RemoveHandler DirectCast(cboCristalIdCercaIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCercaIzquierdo
        RemoveHandler DirectCast(cboCristalIdLejosDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableLejosDerecho
        RemoveHandler DirectCast(cboCristalIdLejosIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableLejosIzquierdo
        RemoveHandler DirectCast(cboCristalIdCercaDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        RemoveHandler DirectCast(cboCristalIdLejosDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        RemoveHandler DirectCast(cboCristalIdCercaIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        RemoveHandler DirectCast(cboCristalIdLejosIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable

    End Sub

    Protected Overrides Sub BindControls()

        MyBase.BindControls()

        cboDocumentoTipoIdFactura.Properties.DisplayMember = cboDocumentoTipoId.Properties.DisplayMember
        cboDocumentoTipoIdFactura.Properties.ValueMember = cboDocumentoTipoId.Properties.ValueMember
        cboDocumentoTipoIdFactura.Properties.DataSource = cboDocumentoTipoId.Properties.DataSource

        cboDocumentoTipoIdFactura.Enabled = False
        txtNumeroDocumentoFactura.Enabled = False
        txtFechaEmitidaFactura.Enabled = False

        'txtNumeroDocumentoFactura.Properties.ReadOnly = True
        'txtFechaEmitidaFactura.Properties.ReadOnly = True

        AddHandler DirectCast(cboCristalIdCercaDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCercaDerecho
        AddHandler DirectCast(cboCristalIdCercaIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableCercaIzquierdo
        AddHandler DirectCast(cboCristalIdLejosDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableLejosDerecho
        AddHandler DirectCast(cboCristalIdLejosIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).GetQueryable, AddressOf OnGetQueryableLejosIzquierdo
        AddHandler DirectCast(cboCristalIdCercaDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        AddHandler DirectCast(cboCristalIdLejosDerecho.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        AddHandler DirectCast(cboCristalIdCercaIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable
        AddHandler DirectCast(cboCristalIdLejosIzquierdo.Properties.DataSource, MyLinqInstantFeedbackSource).DismissQueryable, AddressOf OnDismissQueryable

        'cboCristalIdLejosDerecho.RefresDataSource()
        'cboCristalIdLejosIzquierdo.RefresDataSource()
        'cboCristalIdCercaIzquierdo.RefresDataSource()
        'cboCristalIdCercaDerecho.RefresDataSource()

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

            If EntityToEdit.RecetaComunTipo > 0 Then
                Dim tipo As DV_RecetaTipoEntity = DV_RecetaTipoBEntity.GetById(EntityToEdit.RecetaComunTipo)
                _cercaEsSegundoPar = tipo.CercaEsSegundoPar
            End If

            cboServiciosCerca.Properties.Items.Clear()
            cboServiciosLejos.Properties.Items.Clear()

            ClearTags()

            MyBase.Entity2Controls()

            If Not CurrentEntityIsNew() Then
                CargarServicios()
            End If

        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            _lockUpdate = False
        End Try

    End Sub
#End Region

#Region "Procedimientos privados"

    Private Sub ClearTags()

        For Each field As BEField In BusinessToUse.Fields
            If TypeOf field.DisplayControl Is BaseEdit Then
                DirectCast(field.DisplayControl, BaseEdit).Tag = Nothing
            End If
        Next

    End Sub

    Private Function BuscarArmazon(comboArmazon As SearchLookUpEdit, codigo As String) As Boolean

        Dim tipo As ArticuloController.TipoCodigo
        Dim articulo As ArticuloEntity = ArticuloController.BuscarPorCualquierCodigo(codigo, LocalController.BuscarLocalIdFromCaja(Me.CajaId), tipo)
        'comboArmazon.Properties.CreateViewInfo()
        If articulo IsNot Nothing AndAlso articulo.ArticuloClaseId = ArticuloClase.ArmazonLente Then
            comboArmazon.EditValue = articulo.Id
        Else
            comboArmazon.EditValue = Nothing
        End If
        'System.Windows.Forms.Application.DoEvents()
        Return comboArmazon.HasValue()
    End Function

    ''' <summary>
    ''' Calculamos el importe de la seña
    ''' </summary>
    ''' <returns>El importe calculado</returns>
    ''' <remarks>Como tenemos identificado el importe de la seña en los pagos
    ''' asumimos que la seña pertence al primer grupo de pagos de la receta 
    ''' </remarks>
    Private Function CalcularImporteSeña() As Decimal

        Dim impToReturn As Decimal = Decimal.Zero
        With GetCurrentEntity(Of DV_RecetaComunEntity)()
            Dim pagos As IEntityCollection2 = DocSalida_PagoDocSalidaController.BuscarPagosDeDocumento(.Id, .CajaId)
            If pagos.Count > 0 Then
                Dim pagoRef As DocSalida_PagoDocSalidaEntity = pagos(0)
                For Each pago As DocSalida_PagoDocSalidaEntity In pagos
                    If pago.PagoDocSalidaId = pagoRef.PagoDocSalidaId Then
                        impToReturn += pago.ImporteAjustado
                    End If
                Next
            End If
            Return impToReturn
        End With

    End Function

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

    Private Sub CheckServicios(detalles As EntityCollection(Of DocSalidaDetalleEntity))

        CheckServicios(detalles, cboServiciosLejos, DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS)
        CheckServicios(detalles, cboServiciosCerca, DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA)

    End Sub

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


    Private Sub FiltrarDatosPorCaja()

        With BusinessToUse
            '.Fields(dv_recetacomunfieldindex.DocumentoTipoId.ToString()).ForeignBEntity = Nothing
            '.Fields(dv_recetacomunfieldindex.DocumentoTipoId.ToString()).ForeignBEntityFactory = New DocumentoTipoBEntityFactoryParaVenta(Me.CajaId)
            .Fields(DV_RecetaComunFieldIndex.FuncionarioId.ToString()).ForeignBEntity = Nothing
            .Fields(DV_RecetaComunFieldIndex.FuncionarioId.ToString()).ForeignBEntityFactory = New FuncionarioBEntityFactoryParaVenta(Me.CajaId)
            .Fields(DV_RecetaComunFieldIndex.ClienteId.ToString()).ForeignBEntity = Nothing
            .Fields(DV_RecetaComunFieldIndex.ClienteId.ToString()).ForeignBEntity = New ClienteParaVentaBEntity(LocalController.BuscarLocalIdFromCaja(CajaId))
            .Fields(DV_RecetaComunFieldIndex.ListaPreVtaId.ToString()).ForeignBEntity = Nothing
            .Fields(DV_RecetaComunFieldIndex.ListaPreVtaId.ToString()).ForeignBEntityFactory = New ListaPreVtaBEntityFactoryParaVenta(Me.CajaId)
            .Fields(DV_RecetaComunFieldIndex.ConvenioId.ToString()).ForeignBEntityFactory = New ConvenioBEntityFactoryParaVenta(Me.CajaId)

        End With

    End Sub

    Private Sub PagoFinalizadoContado(sender As Object, e As PagoFinalizadoEventArgs)

        Try

            ImprimirFacturas(DV_RecetaComunBEntity.Facturar(CajaId, EntityToEdit, e.PagoAdm, _facturaManualInfo.fechaEmitida, _facturaManualInfo.numeroDocumento))

        Catch ex As ORMConcurrencyException
            MyMsgBox.Show("Se detectaron cambios en los documentos involucrados, para preservar la consistencia de los datos se canceló la ejecución del proceso. Intente cancelar la operación y volver a ingresarla desde el principio.", MsgBoxStyle.Exclamation)
            'Me.ChangeViewMode(ViewMode.Consulta)

        Catch ex As Exception
            Studio.Phone.POS.BLL.LogError.Publish(ex)
            ShowMsgBox(ex.Message, MsgBoxStyle.Exclamation)
            'Me.ChangeViewMode(ViewMode.Consulta)
        Finally
            'If flagGenerado Then
            ' Me.ChangeViewMode(ViewMode.Consulta)
            ' End If
        End Try

    End Sub

    Private Sub InicializarPagoContado(fechaEmitida As Date, numeroDocumento As String)

        Using pagoDV As New PagoDocumentoSalidaView()

            Try

                _facturaManualInfo = New facturaManualInfo With {.fechaEmitida = fechaEmitida, .numeroDocumento = numeroDocumento}

                If EntityToEdit.ImporteSaldoRestante > Decimal.Zero Then

                    pagoDV.InicializarPago(DocumentoSalidaController.GenerarTemporalesDesdeVenta(CType(Nothing, IDataAccessAdapter), EntityToEdit, True), ConfigReaderSpecific.GetCajaId(), EntityToEdit.ClienteId, PagoManager.ModoPagoMayorEnum.DevolverCambio, True)

                    AddHandler pagoDV.PagoFinalizado, AddressOf PagoFinalizadoContado
                    pagoDV.ShowDialog(FindForm())

                Else

                    'Dim factura As DocumentoSalidaEntity =
                    ImprimirFacturas(DV_RecetaComunBEntity.Facturar(CajaId, EntityToEdit, New PagoManager With {.MonedaIdCambio = Moneda.Pesos}, _facturaManualInfo.fechaEmitida, _facturaManualInfo.numeroDocumento))

                End If


            Catch ex As Exception
                ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                RemoveHandler pagoDV.PagoFinalizado, AddressOf PagoFinalizadoContado

            End Try
        End Using


    End Sub

    Private Sub InicializarPagoContado()
        InicializarPagoContado(System.DateTime.MinValue, Nothing)
    End Sub

    Private Function ImporteRedondeo(ByVal total As Decimal, ByVal monedaId As Integer) As Decimal
        Return total + Me.DiferenciaRedondeo(total, monedaId)
    End Function

    Private Function DiferenciaRedondeo(ByVal total As Decimal, ByVal monedaId As Integer) As Decimal
        Dim redondeo As Short = MonedaController.RedondeoPorMoneda(monedaId)
        Return Decimal.Round(total, redondeo) - total
    End Function


    Private Function TotalDetalle() As TotalDetalleInfo

        Dim totalInfo As TotalDetalleInfo
        If Me.EntityToEdit.CajaId = 0I Then
            Me.EntityToEdit.CajaId = Me.CajaId
        End If

        For Each detalle As DocSalidaDetalleEntity In EntityToEdit.Detalles

            Dim importe As Decimal = detalle.Importe

            If importe <> Decimal.Zero Then
                totalInfo.Impuestos += detalle.ImporteImpuestos
                totalInfo.IVA += detalle.ImporteImpuestos

                totalInfo.Total += detalle.Importe
                If Me.EntityToEdit.SinImpuestos Then
                    totalInfo.Total += detalle.ImporteImpuestos
                End If
            End If
        Next

        Return totalInfo

    End Function


    Private Sub RefrescarTotal()

        Dim totalInfo As TotalDetalleInfo = TotalDetalle()
        totalInfo.Primario = totalInfo.Total - totalInfo.Impuestos

        If cboBonificacionId.HasValue() Then
            Dim bonificacionId As Integer = CInt(cboBonificacionId.EditValue)
            totalInfo.Total = BonificacionController.DescontarBonificacion(bonificacionId, totalInfo.Total)
            'totalInfo.Impuestos = BonificacionController.DescontarBonificacion(bonificacionId, totalInfo.Impuestos)
            'totalInfo.IVA = BonificacionController.DescontarBonificacion(bonificacionId, totalInfo.IVA)
            'totalInfo.Cofis = BonificacionController.DescontarBonificacion(bonificacionId, totalInfo.Cofis)
        End If
        If EntityToEdit.DocumentoSalida_DtoRecCollection.Count > 0 Then
            'totalInfo.Total
        End If

        totalInfo.Total += EntityToEdit.CalcularTotalDescuentoRecargo(totalInfo.Total)

        Dim Total As Decimal = totalInfo.Total


        'Dim diferenciaRedondeo As Decimal = Me.DiferenciaRedondeo(Total, Me.cboMonedaId.EditValue)
        Dim totalRdo As Decimal = Me.ImporteRedondeo(Total, Me.cboMonedaId.EditValue)

        EntityToEdit.ImporteTotal = totalRdo
        'EntityToEdit.ImporteIVA = EntityToEdit.ImporteIVA

    End Sub

    Private Sub OnSetSecurity()

        'cboClienteId.Enabled = PtkOperacionBEntity.TienePermiso(PermisoOperacion.EditarDocumentoSalida)

    End Sub

    Private Sub bgwImporteSeña_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwImporteSeña.DoWork
        If Not CurrentEntityIsNew() Then
            e.Result = CalcularImporteSeña()
        Else
            e.Result = Nothing
        End If

    End Sub

    Private Sub CheckStockCristalCercaIzquierdo(articulos As List(Of ArticuloEntity), cantidad As Decimal)

        If EntityToEdit.TipoOperacion = RecetaComunOperacion.Venta AndAlso CajaController.VentaConStockNegativo(CajaId) <> VentaStockNegativo.Permitir Then
            For Each item As ArticuloEntity In articulos
                If item.ControlaStock Then
                    Dim depositoId As Integer = DepositoController.BuscarDepositoVentaDeArticulo(item.Id, GetLocalId())
                    If depositoId > 0 Then
                        If Not Deposito_ArticuloController.StockSuficiente(item.Id, depositoId, cantidad / articulos.Count) Then
                            EntityToEdit.SetEntityFieldError(DV_RecetaComunFieldIndex.CristalIdCercaIzquierdo.ToString(), String.Format(
                                                             "No hay stock suficiente del artículo {0}", item.DescripcionFull), True)
                        End If
                    End If
                End If

            Next

        End If

    End Sub

    Private Sub CheckStockCristalCercaDerecho(articulos As List(Of ArticuloEntity), cantidad As Decimal)

        If EntityToEdit.TipoOperacion = RecetaComunOperacion.Venta AndAlso CajaController.VentaConStockNegativo(CajaId) <> VentaStockNegativo.Permitir Then
            For Each item As ArticuloEntity In articulos
                If item.ControlaStock Then
                    Dim depositoId As Integer = DepositoController.BuscarDepositoVentaDeArticulo(item.Id, GetLocalId())
                    If depositoId > 0 Then
                        If Not Deposito_ArticuloController.StockSuficiente(item.Id, depositoId, cantidad / articulos.Count) Then
                            EntityToEdit.SetEntityFieldError(DV_RecetaComunFieldIndex.CristalIdCercaDerecho.ToString(), String.Format(
                                                             "No hay stock suficiente del artículo {0}", item.DescripcionFull), True)
                        End If
                    End If
                End If

            Next

        End If

    End Sub

    Private Sub CheckStockArmazonCerca(articulo As ArticuloEntity)
        If articulo.ControlaStock Then
            Dim depositoId As Integer = DepositoController.BuscarDepositoVentaDeArticulo(articulo.Id, GetLocalId())
            If depositoId > 0 Then
                If Not Deposito_ArticuloController.StockSuficiente(articulo.Id, depositoId, IIf(cboArmazonIdCerca.EditValue = cboArmazonIdLejos.EditValue, txtCantidadArmazonCerca.EditValue + txtCantidadArmazonLejos.EditValue, txtCantidadArmazonCerca.EditValue)) Then
                    EntityToEdit.SetEntityFieldError(DV_RecetaComunFieldIndex.ArmazonIdCerca.ToString(), String.Format(
                                                     "No hay stock suficiente del artículo {0}", articulo.DescripcionFull), True)
                End If
            End If

        End If
    End Sub

    Private Sub CheckStockArmazonLejos(articulo As ArticuloEntity)
        If articulo.ControlaStock Then
            Dim depositoId As Integer = DepositoController.BuscarDepositoVentaDeArticulo(articulo.Id, GetLocalId())
            If depositoId > 0 Then
                If Not Deposito_ArticuloController.StockSuficiente(articulo.Id, depositoId, IIf(cboArmazonIdCerca.EditValue = cboArmazonIdLejos.EditValue, txtCantidadArmazonCerca.EditValue + txtCantidadArmazonLejos.EditValue, txtCantidadArmazonLejos.EditValue)) Then
                    EntityToEdit.SetEntityFieldError(DV_RecetaComunFieldIndex.ArmazonIdLejos.ToString(), String.Format(
                                                     "No hay stock suficiente del artículo {0}", articulo.DescripcionFull), True)
                End If
            End If

        End If
    End Sub

    Private Sub CheckStockCristalLejosIzquierdo(articulos As List(Of ArticuloEntity), cantidad As Decimal)

        If rgrTipoOperacion.EditValue = RecetaComunOperacion.Venta AndAlso CajaController.VentaConStockNegativo(CajaId) <> VentaStockNegativo.Permitir Then
            For Each item As ArticuloEntity In articulos
                If item.ControlaStock Then
                    Dim depositoId As Integer = DepositoController.BuscarDepositoVentaDeArticulo(item.Id, GetLocalId())
                    If depositoId > 0 Then
                        If Not Deposito_ArticuloController.StockSuficiente(item.Id, depositoId, cantidad / articulos.Count) Then
                            EntityToEdit.SetEntityFieldError(DV_RecetaComunFieldIndex.CristalIdLejosIzquierdo.ToString(), String.Format(
                                                             "No hay stock suficiente del artículo {0}", item.DescripcionFull), True)
                        End If
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub CheckStockCristalLejosDerecho(articulos As List(Of ArticuloEntity), cantidad As Decimal)

        If rgrTipoOperacion.EditValue = RecetaComunOperacion.Venta AndAlso CajaController.VentaConStockNegativo(CajaId) <> VentaStockNegativo.Permitir Then
            For Each item As ArticuloEntity In articulos
                If item.ControlaStock Then
                    Dim depositoId As Integer = DepositoController.BuscarDepositoVentaDeArticulo(item.Id, GetLocalId())
                    If depositoId > 0 Then
                        If Not Deposito_ArticuloController.StockSuficiente(item.Id, depositoId, cantidad / articulos.Count) Then
                            EntityToEdit.SetEntityFieldError(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString(), String.Format(
                                                             "No hay stock suficiente del artículo {0}", item.DescripcionFull), True)
                        End If
                    End If
                End If
            Next
        End If

    End Sub

    Protected Overridable Sub LockControls()

        For Each item As KeyValuePair(Of String, LayoutControlItem) In _bindedControls

            Dim c As BaseEdit = TryCast(item.Value.Control, BaseEdit)

            If c IsNot Nothing Then
                Dim fieldName As String = BindingControlHelper.Control2FieldName(c)

                If Not String.IsNullOrEmpty(fieldName) AndAlso BusinessToUse.Fields.FindByName(fieldName) IsNot Nothing Then
                    Dim field As BEField = BusinessToUse.Fields(fieldName)
                    If field IsNot Nothing Then
                        c.Properties.ReadOnly = field.Locked
                    End If
                End If
            End If
        Next
        cboServiciosLejos.Properties.ReadOnly = False
        'txtArmazonLejosCodigo.Properties.ReadOnly = False
        'txtArmazonCercaCodigo.Properties.ReadOnly = False

    End Sub

    Protected Overridable Function CurrentEntityIsNew() As Boolean
        Return CurrentEntity IsNot Nothing AndAlso CurrentEntity.IsNew
    End Function

    Private Sub UpdateDatosLejos()

        If IsNumeric(txtEsfericoOjoCercaDerecho.Text) Then

            Dim adicion As Decimal = NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.Text) - NumberConversor.ParseDecimal(txtEsfericoOjoLejosDerecho.Text)

            If adicion <> txtAdicionOjoLejosDerecho.EditValue Then
                txtAdicionOjoLejosDerecho.EditValue = adicion
            End If

            adicion = NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.Text) - NumberConversor.ParseDecimal(txtEsfericoOjoLejosIzquierdo.Text)
            If adicion <> txtAdicionOjoLejosIzquierdo.EditValue Then
                txtAdicionOjoLejosIzquierdo.EditValue = adicion
            End If
        End If

    End Sub

    Private Sub UpdateDatosCerca()

        txtEjeOjoCercaDerecho.EditValue = txtEjeOjoLejosDerecho.EditValue
        txtEjeOjoCercaIzquierdo.EditValue = txtEjeOjoLejosIzquierdo.EditValue
        txtCilindricoOjoCercaDerecho.EditValue = txtCilindricoOjoLejosDerecho.EditValue
        txtCilindricoOjoCercaIzquierdo.EditValue = txtCilindricoOjoLejosIzquierdo.EditValue

        If IsNumeric(txtEsfericoOjoLejosDerecho.EditValue) Then
            txtEsfericoOjoCercaDerecho.EditValue = NumberConversor.ParseDecimal(txtEsfericoOjoLejosDerecho.Text) + NumberConversor.ParseDecimal(txtAdicionOjoLejosDerecho.Text)
        Else
            txtEsfericoOjoCercaDerecho.EditValue = Nothing
        End If
        If IsNumeric(txtEsfericoOjoLejosIzquierdo.EditValue) Then
            txtEsfericoOjoCercaIzquierdo.EditValue = NumberConversor.ParseDecimal(txtEsfericoOjoLejosIzquierdo.Text) + NumberConversor.ParseDecimal(txtAdicionOjoLejosIzquierdo.Text)
        Else
            txtEsfericoOjoCercaIzquierdo.EditValue = Nothing
        End If

        txtDistanciaOjoCercaDerecho.EditValue = txtDistanciaOjoLejosDerecho.EditValue
        txtDistanciaOjoCercaIzquierdo.EditValue = txtDistanciaOjoLejosIzquierdo.EditValue
        txtAlturaOjoCercaDerecho.EditValue = txtAlturaOjoLejosDerecho.EditValue
        txtAlturaOjoCercaIzquierdo.EditValue = txtAlturaOjoLejosIzquierdo.EditValue
        txtPrismaOjoCercaDerecho.EditValue = txtPrismaOjoLejosDerecho.EditValue
        txtPrismaOjoCercaIzquierdo.EditValue = txtPrismaOjoLejosIzquierdo.EditValue
        txtPrismaGraduacionOjoCercaDerecho.EditValue = txtPrismaGraduacionOjoLejosDerecho.EditValue
        txtPrismaGraduacionOjoCercaIzquierdo.EditValue = txtPrismaGraduacionOjoLejosIzquierdo.EditValue
        txtBaseOjoCercaDerecho.EditValue = txtBaseOjoLejosDerecho.EditValue
        txtBaseOjoCercaIzquierdo.EditValue = txtBaseOjoLejosIzquierdo.EditValue
        txtCantidadArmazonCerca.EditValue = txtCantidadArmazonLejos.EditValue
        txtCantidadOjoCercaDerecho.EditValue = txtCantidadOjoLejosDerecho.EditValue
        txtCantidadOjoCercaIzquierdo.EditValue = txtCantidadOjoLejosIzquierdo.EditValue

        cboCristalMaterialIdCercaDerecho.EditValue = cboCristalMaterialIdLejosDerecho.EditValue
        cboCristalMaterialIdCercaIzquierdo.EditValue = cboCristalMaterialIdLejosIzquierdo.EditValue
        cboCristalIdCercaDerecho.EditValue = cboCristalIdLejosDerecho.EditValue
        cboCristalIdCercaIzquierdo.EditValue = cboCristalIdLejosIzquierdo.EditValue

    End Sub

    Private Sub EnableCercaControls(enabled As Boolean)

        txtEjeOjoCercaDerecho.Properties.ReadOnly = Not enabled
        txtEjeOjoCercaIzquierdo.Properties.ReadOnly = Not enabled
        txtCilindricoOjoCercaDerecho.Properties.ReadOnly = Not enabled
        txtCilindricoOjoCercaIzquierdo.Properties.ReadOnly = Not enabled
        txtCantidadOjoCercaDerecho.Properties.ReadOnly = Not enabled
        txtCantidadOjoCercaIzquierdo.Properties.ReadOnly = Not enabled
        txtCantidadArmazonCerca.Properties.ReadOnly = Not enabled

        'txtEsfericoOjoCercaDerecho.properties.readonly = Not enabled
        'txtEsfericoOjoCercaIzquierdo.properties.readonly = Not enabled
        txtDistanciaOjoCercaDerecho.Properties.ReadOnly = Not enabled
        txtDistanciaOjoCercaIzquierdo.Properties.ReadOnly = Not enabled
        txtAlturaOjoCercaDerecho.Properties.ReadOnly = Not enabled
        txtAlturaOjoCercaIzquierdo.Properties.ReadOnly = Not enabled
        txtPrismaOjoCercaDerecho.Properties.ReadOnly = Not enabled
        txtPrismaOjoCercaIzquierdo.Properties.ReadOnly = Not enabled
        txtPrismaGraduacionOjoCercaDerecho.Properties.ReadOnly = Not enabled
        txtPrismaGraduacionOjoCercaIzquierdo.Properties.ReadOnly = Not enabled
        cboCristalMaterialIdCercaDerecho.Properties.ReadOnly = Not enabled
        cboCristalIdCercaDerecho.Properties.ReadOnly = Not enabled
        cboCristalMaterialIdCercaIzquierdo.Properties.ReadOnly = Not enabled
        cboCristalIdCercaIzquierdo.Properties.ReadOnly = Not enabled
        txtBaseOjoCercaDerecho.Properties.ReadOnly = Not enabled
        txtBaseOjoCercaIzquierdo.Properties.ReadOnly = Not enabled
        cboArmazonIdCerca.Properties.ReadOnly = Not enabled
        cboServiciosCerca.Properties.ReadOnly = Not enabled
        'txtArmazonCercaCodigo.Properties.ReadOnly = Not enabled

        'cboServiciosLejos.Properties.ReadOnly = Not enabled

    End Sub

    Private Function GetMontoSeña() As Decimal
        Return _parametroTree.Optica.Venta.PorcentajeSeñaRecetaComun * EntityToEdit.ImporteTotal / 100
    End Function

    Private Function VerificarRecargo(ByVal pagoCollection As IEntityCollection2) As Boolean
        Tmp_DocumentoSalidaController.ProcesarPagos(_tmp_DocumentoSalida, pagoCollection)
        'Me.RecargarDetalle()
        Return Save(False)
    End Function

    Private Function GetClienteId() As Integer
        Return CInt(cboClienteId.EditValue)
    End Function

    Private Function HayQueIngresarPago() As Boolean

        Dim ingresoPago As Boolean = False
        If EntityToEdit.TipoOperacion <> RecetaComunOperacion.Presupuesto Then
            If (_parametroTree.Optica.Venta.PorcentajeSeñaRecetaComun > Decimal.Zero) AndAlso (Not cboConvenioId.HasValue() OrElse _parametroTree.Optica.Venta.NoPedirSeñaEnConvenios = False) Then
                ingresoPago = (EntityToEdit.VentaTipo = RecetaVentaTipo.Contado)
            End If
        End If

        If EntityToEdit.ImporteTotal > Decimal.Zero Then
            Return ingresoPago '= DocumentoTipoIngresoPago.Obligatorio)
        End If

        Return False

    End Function

    Private Function FinalizarVenta(ByVal guardarPago As Boolean, ByRef pagoArgs As PagoFinalizadoEventArgs) As EntityCollection

        'Primero verificar si hay que agregar el recargo correspondiente a la venta
        If guardarPago AndAlso Not Me.VerificarRecargo(pagoArgs.PagoDocSalidaEntity.Tmp_DocSalida_PagoDocSalida) Then
            pagoArgs.Cancel = True
            Return Nothing
        End If

        Dim unDocumentoSalidaCollection As IEntityCollection2 = Nothing

        Try

            _parent.ShowWaitForm("Guardando el documento")

            unDocumentoSalidaCollection = DV_RecetaComunBEntity.SaveReceta(EntityToEdit, pagoArgs.PagoAdm)
            If EntityToEdit.ImporteSaldoRestante = Decimal.Zero AndAlso EntityToEdit.ImporteTotal > Decimal.Zero Then
                _parent.CloseWaitForm()
                If MyMsgBox.Show("¿Desea facturar la receta en este momento?.", MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    _parent.ShowWaitForm("Generando la factura")
                    FacturarRecetaActiva()
                End If
            End If
            _ventaSaved = True
            'TODO: Imprimor orden de trabajo
            ImprimirDocumentos(unDocumentoSalidaCollection)
            Entity2Controls()

        Catch ex As EntitiesValidationException
            _parent.CloseWaitForm()
            ShowErrors(ex.InvalidEntities)
            pagoArgs.Cancel = True
        Catch ex As ORMEntityValidationException
            _parent.CloseWaitForm()
            'CurrentEntity.SetEntityError(ex.Message)

            ShowErrors(CurrentEntity)
            pagoArgs.Cancel = True
        Catch ex As Exception
            _parent.CloseWaitForm()
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
            If Environment.RunningUnderIDE Then
                ShowMsgBox(ex.StackTrace)
            Else
                ShowMsgBox("Se há producido un problema al intentar confirmar la venta, intente confirmarla nuevamente, si el problema continua cancélela y vuelva a ingresarla. En caso de persistir el problema contáctese con el administrador del sistema.", MsgBoxStyle.Exclamation)
            End If
            pagoArgs.Cancel = True
        Finally
            _parent.CloseWaitForm()
        End Try

        Return unDocumentoSalidaCollection

    End Function

    Private Sub NuevoRegistro()

        AddNew()

    End Sub


    Private Sub PagoFinalizado(ByVal sender As Object, ByVal e As PagoFinalizadoEventArgs)

        'Dim unDocumentoTipoEntity As DocumentoTipoEntity = DocumentoTipoController.BuscarPorId(_tmp_DocumentoSalida.DocumentoTipoId)
        Dim unDocumentoSalidaCollection As IEntityCollection2 = Me.FinalizarVenta(True, e)

        'If Not e.Cancel Then
        '    Me.NuevoRegistro()
        'End If

    End Sub

    Private Function InicializarPago() As Boolean

        Using pagoDV As New PagoDocumentoSalidaView()

            Try

                Using unDocumentoCollection As New EntityCollection(Of Tmp_DocumentoSalidaEntity)
                    unDocumentoCollection.Add(_tmp_DocumentoSalida)
                    If rgrVentaTipo.EditValue = CInt(RecetaVentaTipo.Contado) AndAlso Not EntityToEdit.Devolucion Then
                        pagoDV.InicializarPago(unDocumentoCollection, Me.CajaId, Me.GetClienteId(), PagoManager.ModoPagoMayorEnum.DevolverCambio, False, GetMontoSeña())
                    Else
                        pagoDV.InicializarPago(unDocumentoCollection, Me.CajaId, Me.GetClienteId(), PagoManager.ModoPagoMayorEnum.DevolverCambio, False)
                    End If
                End Using

                AddHandler pagoDV.PagoFinalizado, AddressOf PagoFinalizado
                If pagoDV.ShowDialog(FindForm()) = DialogResult.OK Then
                    Me.Focus()

                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                RemoveHandler pagoDV.PagoFinalizado, AddressOf PagoFinalizado
            End Try
        End Using

        Return False

    End Function

    Private Sub ValidarVenta()

        Dim venta As DV_RecetaComunEntity = EntityToEdit

        Const C_MSG = "Debe ingresar {0} antes de agregar una línea."

        If venta.GetCurrentFieldValue(DV_RecetaComunFieldIndex.ClienteId) Is Nothing Then
            Throw New ApplicationException(String.Format(C_MSG, "el cliente"))
        End If

        If venta.GetCurrentFieldValue(DV_RecetaComunFieldIndex.ListaPreVtaId) Is Nothing Then
            Throw New ApplicationException(String.Format(C_MSG, "la lista de precios"))
        End If

        If venta.GetCurrentFieldValue(DV_RecetaComunFieldIndex.MonedaId) Is Nothing Then
            Throw New ApplicationException(String.Format(C_MSG, "la moneda"))
        End If

        If venta.GetCurrentFieldValue(DV_RecetaComunFieldIndex.NumeroDocumento) = String.Empty Then
            Throw New ApplicationException(String.Format(C_MSG, String.Format("el número de {0}", IIf(ConfigReaderSpecific.GetModoPreVenta() = ModoPreVenta.Ingreso, "pre-venta", "documento"))))
        End If

    End Sub

    Private Function GetFuncionarioId() As Integer
        Return Convert.ToInt32(cboFuncionarioId.EditValue)
    End Function

    Protected Function Save(ByVal borrarTodo As Boolean) As Boolean

        Try

            _parent.ShowWaitForm("Guardando la informacion...")
            'Dim entityToEdit As DV_RecetaComunEntity = entitytoedit
            'ValidarVenta()

            'Controls2Entity()
            'Me.CopiarDetalleACabezal(Me.EntityToEdit)

            EntityToEdit.ClearErrors()

            Controls2Entity()

            If Not CargarArticulosInternal() Then
                Return False
            End If

            'Recordar el funcionario
            Me._funcionarioId = Me.GetFuncionarioId()
            Dim toSave As Tmp_DocumentoSalidaEntity = _tmp_DocumentoSalida
            ' If toSave Is Nothing Then

            If borrarTodo Then
                toSave = DV_RecetaComunBEntity.CrearTmpDocumentoSalida(EntityToEdit, _parametroTree)
                Tmp_DocumentoSalidaController.BorrarTodo(Nothing, ConfigReaderSpecific.GetStringDeTerminal())
                Tmp_DocumentoSalidaController.MarcarParaAlta(toSave)
            End If

            'End If

            EntityToEdit.DocumentoTipoId = toSave.DocumentoTipoId

            EntityToEdit.ClearErrors()

            Dim valid As New ValidatorHelper
            valid.Validate(toSave, False, False)

            If toSave.HasErrors() Then
                CopiarErrores(New List(Of IEntity2)(New IEntity2() {toSave}), False)
                valid = New ValidatorHelper
                valid.Validate(EntityToEdit, False, True, False)
            End If
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

                Tmp_DocumentoSalidaController.GuardarDocumento(da, toSave, _documentoRelacionado, _documentoRelacionadoTipo, True)
                '************** BONIFICACIÓN DINAMICA *************************
                'toSave = Tmp_DocumentoSalidaController.FetchParaVerificarBonificacionDinamica(da, toSave)

                'If DocumentoTipoController.EsDeSalidaDeArticulos(da, toSave.DocumentoTipoId) Then
                Dim controller As New Studio.Vision.POS.BLL.BonificacionDinamicaController
                Tmp_DocumentoSalidaController.FetchParaVerificarBonificacionDinamica(da, toSave)
                toSave.Bonificacion = controller.VerificarBonificacion(da, toSave)
                If toSave.Bonificacion IsNot Nothing Then
                    toSave.ImporteTotal = BonificacionController.DescontarBonificacion(toSave.BonificacionId, toSave.ImporteTotal)
                End If
                'End If
                da.SaveEntity(toSave, True, True)

                DV_RecetaBEntity.CopiarBonificaciones(toSave, EntityToEdit)

            End Using

            'Entity2Controls()

            '************** FIN BONIFICACIÓN DINAMICA *************************

            _tmp_DocumentoSalida = toSave

            Return MyBase.SaveCurrent()

        Catch ex As EntitiesValidationException
            ShowErrors(ex.InvalidEntities)
        Catch ex As ORMEntityValidationException
            CurrentEntity.SetEntityError(ex.Message)
            ShowErrors(CurrentEntity)
        Catch ex As ORMConcurrencyException
            _parent.CloseWaitForm()
            ShowMsgBox(String.Format("Se ha producido un error al intentar guardar un registro de la tabla {0}. El error se debió a que la información fue modificada por otro usuario antes de ser guardada", ex.EntityWhichFailed.ToString()), ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            Studio.Net.Helper.LogError.Publish(ex)
            _parent.CloseWaitForm()
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            _parent.CloseWaitForm()
            ShowFieldErrors()
        End Try

        Return False

    End Function

    Private Sub CopiarErrores(list As List(Of IEntity2), append As Boolean)

        Dim entity As Tmp_DocumentoSalidaEntity = TryCast(list(0), Tmp_DocumentoSalidaEntity)
        If entity IsNot Nothing Then
            With DirectCast(entity, IDataErrorInfo)
                If Not String.IsNullOrEmpty(.Error) Then
                    CurrentEntity.SetEntityError(.Error)
                End If
                Dim fieldErrors As Dictionary(Of String, String) = entity.GetDataErrorInfoErroresPerField()
                If fieldErrors IsNot Nothing Then
                    For Each fieldError As KeyValuePair(Of String, String) In fieldErrors
                        If CurrentEntity.Fields(fieldError.Key) IsNot Nothing Then
                            CurrentEntity.SetEntityFieldError(fieldError.Key, fieldError.Value, append)
                        End If
                    Next
                End If

            End With
        End If

        LayoutControl.Refresh()

    End Sub

    Private Sub OnRecetaTipoChanged(radioGroup As RadioGroup)

        If CurrentEntityIsNew() AndAlso Not _lockUpdate Then

            If radioGroup.EditValue IsNot Nothing AndAlso radioGroup.EditValue > 0 Then

                Dim tipo As DV_RecetaTipoEntity = DV_RecetaTipoBEntity.GetById(CInt(radioGroup.EditValue))
                _cercaEsSegundoPar = tipo.CercaEsSegundoPar

                'cboServiciosLejos.Properties.ReadOnly = False
                lcgCerca.Enabled = True
                lcgLejos.Enabled = True
                lcgCondiciones.Enabled = True
                lcgConvenio.Enabled = True



                If _cercaEsSegundoPar Then
                    cboCristalIdLejosDerecho.EditValue = Nothing
                    cboCristalIdCercaDerecho.EditValue = Nothing
                    cboArmazonIdCerca.EditValue = Nothing

                    'cboServiciosCerca.Properties.Items.Clear()
                    'lcgCerca.Enabled = False
                    EnableCercaControls(True)

                Else
                    EnableCercaControls(False)
                End If
            Else
                lcgLejos.Enabled = False
                lcgCondiciones.Enabled = False
                lcgConvenio.Enabled = False

            End If
        End If

    End Sub

    Private Function OjoCercaDerechoCargado() As Boolean
        Return txtCilindricoOjoCercaDerecho.Text <> String.Empty OrElse txtEsfericoOjoCercaDerecho.Text <> String.Empty
    End Function

    Private Function OjoCercaIzquierdoCargado() As Boolean
        Return txtCilindricoOjoCercaIzquierdo.Text <> String.Empty OrElse txtEsfericoOjoCercaIzquierdo.Text <> String.Empty
    End Function

    Private Function OjoCercaCargado() As Boolean
        Return OjoCercaDerechoCargado() OrElse OjoCercaIzquierdoCargado()
    End Function

    Private Function OjoLejosDerechoCargado() As Boolean
        Return txtCilindricoOjoLejosDerecho.Text <> String.Empty OrElse txtEsfericoOjoLejosDerecho.Text <> String.Empty
    End Function

    Private Function OjoLejosIzquierdoCargado() As Boolean
        Return txtCilindricoOjoLejosIzquierdo.Text <> String.Empty OrElse txtEsfericoOjoLejosIzquierdo.Text <> String.Empty
    End Function

    Private Function OjoLejosCargado() As Boolean
        Return (OjoLejosDerechoCargado() OrElse OjoLejosIzquierdoCargado())
    End Function

    Protected Function CargarArticulosInternal() As Boolean

        If CurrentEntityIsNew() Then

            Dim coltoAdd As New EntityCollection(Of DocSalidaDetalleEntity)

            Try

                EntityToEdit.LimpiarCristales()

                Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

                    If cboListaPreVtaId.HasValue() AndAlso cboMonedaId.HasValue() AndAlso EntityToEdit IsNot Nothing Then


                        Dim parametro As VisionParametroTree = ParametroSistemaController.GetParametroTree(da)

                        Dim cantCristales As Integer = Decimal.Zero


                        If cboCristalIdLejosDerecho.HasValue() Then


                            Dim cristal As DV_CristalEntity = DV_CristalBEntity.GetByIdForReceta(da, CInt(cboCristalIdLejosDerecho.EditValue))

                            If cristal.GuiaDeVariante Then

                                Dim articulosCtrlStock As New List(Of ArticuloEntity)

                                If OjoLejosDerechoCargado() Then
                                    Dim articulo As ArticuloEntity = DV_CristalBEntity.BuscarPorGraduacion(da, cristal.Id, NumberConversor.ParseDecimal(txtEsfericoOjoLejosDerecho.GetEditValueWithTag()),
                                                            IIf(_cercaEsSegundoPar, NumberConversor.ParseDecimal(txtCilindricoOjoLejosDerecho.GetEditValueWithTag()), NumberConversor.ParseDecimal(txtAdicionOjoLejosDerecho.Text)),
                                                            parametro.Optica.AAtributoPlantillaIDCristalesEsferico, IIf(_cercaEsSegundoPar, parametro.Optica.AAtributoPlantillaIDCristalesCilindrico, parametro.Optica.AAtributoPlantillaIDCristalesAdicion))


                                    If articulo IsNot Nothing Then

                                        EntityToEdit.CristalIdOjoLejosDerecho = articulo.Id

                                        AgregarADetalle(coltoAdd, articulo, cantidad:=txtCantidadOjoLejosDerecho.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS)
                                        'AgregarADetalle(coltoAdd, articulo, cantidad:=txtCantidadOjoLejosDerecho.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS, descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00}", cristal.DescripcionFull, txtCilindricoOjoLejosDerecho.GetEditValueWithTagOrZero(), txtEsfericoOjoLejosDerecho.GetEditValueWithTagOrZero()))
                                        articulosCtrlStock.Add(articulo)
                                        cantCristales = txtCantidadOjoLejosDerecho.EditValue
                                    End If

                                End If


                                CheckStockCristalLejosDerecho(articulosCtrlStock, cantCristales)


                            Else

                                Dim articulosCtrlStock As New List(Of ArticuloEntity)

                                If OjoLejosDerechoCargado() Then
                                    EntityToEdit.CristalIdOjoLejosDerecho = cristal.Id
                                    If _cercaEsSegundoPar Then
                                        articulosCtrlStock.Add(cristal)
                                        AgregarADetalle(coltoAdd, cristal, cantidad:=txtCantidadOjoLejosDerecho.EditValue, cilindrico:=NumberConversor.ParseDecimal(txtCilindricoOjoLejosDerecho.GetEditValueWithTag()), esferico:=NumberConversor.ParseDecimal(txtEsfericoOjoLejosDerecho.GetEditValueWithTag()), datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS, descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00} a{3:00.00}", cristal.DescripcionFull, txtCilindricoOjoLejosDerecho.GetEditValueWithTagOrZero(), txtEsfericoOjoLejosDerecho.GetEditValueWithTagOrZero(), txtAdicionOjoLejosDerecho.EditValue))
                                    Else
                                        AgregarADetalle(coltoAdd, cristal, cantidad:=txtCantidadOjoLejosDerecho.EditValue, adicion:=NumberConversor.ParseDecimal(txtAdicionOjoLejosDerecho.GetEditValueWithTag()), esferico:=NumberConversor.ParseDecimal(txtEsfericoOjoLejosDerecho.GetEditValueWithTag()), datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS, descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00} a{3:00.00}", cristal.DescripcionFull, txtCilindricoOjoLejosDerecho.GetEditValueWithTagOrZero(), txtEsfericoOjoLejosDerecho.GetEditValueWithTagOrZero(), txtAdicionOjoLejosDerecho.EditValue))
                                    End If
                                    cantCristales = txtCantidadOjoLejosDerecho.EditValue
                                End If

                                CheckStockCristalLejosDerecho(articulosCtrlStock, cantCristales)


                            End If


                            Dim servicios As List(Of Integer) = GetSelectedServicios(cboServiciosLejos)


                            For Each servicioId As Integer In servicios
                                Dim servicio As ArticuloEntity = ArticuloController.BuscarPorId(da, servicioId, New ExcludeIncludeFieldsList(False, New IEntityFieldCore() {ArticuloFields.Descripcion, ArticuloFields.DescripcionVariante}))
                                AgregarADetalle(coltoAdd, servicio, cantidad:=txtCantidadOjoLejosDerecho.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS)

                            Next


                        End If


                        If cboCristalIdLejosIzquierdo.HasValue() Then

                            Dim cristal As DV_CristalEntity = DV_CristalBEntity.GetByIdForReceta(da, CInt(cboCristalIdLejosIzquierdo.EditValue))

                            If cristal.GuiaDeVariante Then

                                Dim articulosCtrlStock As New List(Of ArticuloEntity)

                                If OjoLejosIzquierdoCargado() Then
                                    Dim articulo As ArticuloEntity = DV_CristalBEntity.BuscarPorGraduacion(da, cristal.Id, NumberConversor.ParseDecimal(txtEsfericoOjoLejosIzquierdo.GetEditValueWithTag()),
                                                            IIf(_cercaEsSegundoPar, NumberConversor.ParseDecimal(txtCilindricoOjoLejosIzquierdo.GetEditValueWithTag()), NumberConversor.ParseDecimal(txtAdicionOjoLejosIzquierdo.Text)),
                                                            parametro.Optica.AAtributoPlantillaIDCristalesEsferico, IIf(_cercaEsSegundoPar, parametro.Optica.AAtributoPlantillaIDCristalesCilindrico, parametro.Optica.AAtributoPlantillaIDCristalesAdicion))


                                    If articulo IsNot Nothing Then
                                        EntityToEdit.CristalIdOjoLejosIzquierdo = articulo.Id
                                        AgregarADetalle(coltoAdd, articulo, cantidad:=txtCantidadOjoLejosIzquierdo.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS)
                                        'AgregarADetalle(coltoAdd, articulo, cantidad:=txtCantidadOjoLejosIzquierdo.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS, descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00}", cristal.DescripcionFull, txtCilindricoOjoLejosIzquierdo.GetEditValueWithTagOrZero(), txtEsfericoOjoLejosIzquierdo.GetEditValueWithTagOrZero()))
                                        articulosCtrlStock.Add(articulo)
                                        cantCristales = txtCantidadOjoLejosIzquierdo.EditValue
                                    End If

                                End If


                                CheckStockCristalLejosIzquierdo(articulosCtrlStock, cantCristales)


                            Else

                                Dim articulosCtrlStock As New List(Of ArticuloEntity)

                                If OjoLejosIzquierdoCargado() Then
                                    EntityToEdit.CristalIdOjoLejosIzquierdo = cristal.Id
                                    If _cercaEsSegundoPar Then
                                        articulosCtrlStock.Add(cristal)
                                        AgregarADetalle(coltoAdd, cristal, cantidad:=txtCantidadOjoLejosIzquierdo.EditValue, cilindrico:=NumberConversor.ParseDecimal(txtCilindricoOjoLejosIzquierdo.GetEditValueWithTag()), esferico:=NumberConversor.ParseDecimal(txtEsfericoOjoLejosIzquierdo.GetEditValueWithTag()), datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS, descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00} a{3:00.00}", cristal.DescripcionFull, txtCilindricoOjoLejosIzquierdo.GetEditValueWithTagOrZero(), txtEsfericoOjoLejosIzquierdo.GetEditValueWithTagOrZero(), txtAdicionOjoLejosIzquierdo.EditValue))
                                    Else
                                        AgregarADetalle(coltoAdd, cristal, cantidad:=txtCantidadOjoLejosIzquierdo.EditValue, adicion:=NumberConversor.ParseDecimal(txtAdicionOjoLejosIzquierdo.GetEditValueWithTag()), esferico:=NumberConversor.ParseDecimal(txtEsfericoOjoLejosIzquierdo.GetEditValueWithTag()), datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS, descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00} a{3:00.00}", cristal.DescripcionFull, txtCilindricoOjoLejosIzquierdo.GetEditValueWithTagOrZero(), txtEsfericoOjoLejosIzquierdo.GetEditValueWithTagOrZero(), txtAdicionOjoLejosIzquierdo.EditValue))
                                    End If
                                    cantCristales = txtCantidadOjoLejosIzquierdo.EditValue
                                End If

                                CheckStockCristalLejosIzquierdo(articulosCtrlStock, cantCristales)

                            End If


                            Dim servicios As List(Of Integer) = GetSelectedServicios(cboServiciosLejos)

                            For Each servicioId As Integer In servicios
                                Dim servicio As ArticuloEntity = ArticuloController.BuscarPorId(da, servicioId, New ExcludeIncludeFieldsList(False, New IEntityFieldCore() {ArticuloFields.Descripcion, ArticuloFields.DescripcionVariante}))
                                AgregarADetalle(coltoAdd, servicio, cantidad:=txtCantidadOjoLejosIzquierdo.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS)
                            Next

                        End If


                        If cboCristalIdCercaDerecho.HasValue() AndAlso _cercaEsSegundoPar Then

                            'Dim cantCristales As Integer = Decimal.Zero
                            Dim cristal As DV_CristalEntity = DV_CristalBEntity.GetByIdForReceta(da, CInt(cboCristalIdCercaDerecho.EditValue))

                            Dim articulosCtrlStock As New List(Of ArticuloEntity)

                            If cristal.GuiaDeVariante AndAlso cristal.CristalPlantillaID > 0 Then

                                If OjoCercaDerechoCargado() Then
                                    Dim articulo As ArticuloEntity = DV_CristalBEntity.BuscarPorGraduacion(da, cristal.Id, NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.GetEditValueWithTag()), NumberConversor.ParseDecimal(txtCilindricoOjoCercaDerecho.GetEditValueWithTag()), parametro.Optica.AAtributoPlantillaIDCristalesEsferico, parametro.Optica.AAtributoPlantillaIDCristalesCilindrico)
                                    If articulo IsNot Nothing Then
                                        EntityToEdit.CristalIdOjoCercaDerecho = articulo.Id
                                        articulosCtrlStock.Add(articulo)
                                        AgregarADetalle(coltoAdd, articulo, cantidad:=txtCantidadOjoCercaDerecho.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA)
                                        'AgregarADetalle(coltoAdd, articulo, cantidad:=txtCantidadOjoCercaDerecho.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA, descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00}", cristal.DescripcionFull, txtCilindricoOjoCercaDerecho.GetEditValueWithTagOrZero(), txtEsfericoOjoCercaDerecho.GetEditValueWithTagOrZero()))
                                        cantCristales += txtCantidadOjoCercaDerecho.EditValue
                                    End If
                                End If



                                CheckStockCristalCercaDerecho(articulosCtrlStock, cantCristales)

                            Else

                                If OjoCercaDerechoCargado() Then
                                    articulosCtrlStock.Add(cristal)
                                    EntityToEdit.CristalIdOjoCercaDerecho = cristal.Id
                                    AgregarADetalle(coltoAdd, cristal, cantidad:=txtCantidadOjoCercaDerecho.EditValue, cilindrico:=NumberConversor.ParseDecimal(txtCilindricoOjoCercaDerecho.GetEditValueWithTag()), esferico:=NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.GetEditValueWithTag()), datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA, adicion:=Decimal.Zero)
                                    'AgregarADetalle(coltoAdd, cristal, cantidad:=txtCantidadOjoCercaDerecho.EditValue, cilindrico:=NumberConversor.ParseDecimal(txtCilindricoOjoCercaDerecho.GetEditValueWithTag()), esferico:=NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.GetEditValueWithTag()), datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA, descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00}", cristal.DescripcionFull, txtCilindricoOjoCercaDerecho.GetEditValueWithTagOrZero(), txtEsfericoOjoCercaDerecho.GetEditValueWithTagOrZero()), adicion:=Decimal.Zero)
                                    cantCristales = txtCantidadOjoCercaDerecho.EditValue
                                End If

                                CheckStockCristalCercaDerecho(articulosCtrlStock, cantCristales)

                            End If

                            Dim servicios As List(Of Integer) = GetSelectedServicios(cboServiciosCerca)
                            For Each servicioId As Integer In servicios
                                Dim servicio As ArticuloEntity = ArticuloController.BuscarPorId(da, servicioId, New ExcludeIncludeFieldsList(False, New IEntityFieldCore() {ArticuloFields.Descripcion, ArticuloFields.DescripcionVariante}))
                                AgregarADetalle(coltoAdd, servicio, cantidad:=txtCantidadOjoCercaDerecho.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA)
                            Next

                        End If


                        If cboCristalIdCercaIzquierdo.HasValue() AndAlso _cercaEsSegundoPar Then

                            'Dim cantCristales As Integer = Decimal.Zero
                            Dim cristal As DV_CristalEntity = DV_CristalBEntity.GetByIdForReceta(da, CInt(cboCristalIdCercaIzquierdo.EditValue))

                            Dim articulosCtrlStock As New List(Of ArticuloEntity)

                            If cristal.GuiaDeVariante AndAlso cristal.CristalPlantillaID > 0 Then

                                If OjoCercaIzquierdoCargado() Then
                                    Dim articulo As ArticuloEntity = DV_CristalBEntity.BuscarPorGraduacion(da, cristal.Id, NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.GetEditValueWithTag()), NumberConversor.ParseDecimal(txtCilindricoOjoCercaIzquierdo.GetEditValueWithTag()), parametro.Optica.AAtributoPlantillaIDCristalesEsferico, parametro.Optica.AAtributoPlantillaIDCristalesCilindrico)
                                    If articulo IsNot Nothing Then

                                        EntityToEdit.CristalIdOjoCercaIzquierdo = articulo.Id

                                        articulosCtrlStock.Add(articulo)
                                        AgregarADetalle(coltoAdd, articulo, cantidad:=txtCantidadOjoCercaIzquierdo.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA)
                                        'AgregarADetalle(coltoAdd, articulo, cantidad:=txtCantidadOjoCercaIzquierdo.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA, descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00}", cristal.DescripcionFull, txtCilindricoOjoCercaIzquierdo.GetEditValueWithTagOrZero(), txtEsfericoOjoCercaIzquierdo.GetEditValueWithTagOrZero()))
                                        cantCristales += txtCantidadOjoCercaIzquierdo.EditValue
                                    End If
                                End If


                                CheckStockCristalCercaIzquierdo(articulosCtrlStock, cantCristales)

                            Else

                                If OjoCercaIzquierdoCargado() Then
                                    articulosCtrlStock.Add(cristal)
                                    EntityToEdit.CristalIdOjoCercaIzquierdo = cristal.Id
                                    AgregarADetalle(coltoAdd, cristal, cantidad:=txtCantidadOjoCercaIzquierdo.EditValue, cilindrico:=NumberConversor.ParseDecimal(txtCilindricoOjoCercaIzquierdo.GetEditValueWithTag()), esferico:=NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.GetEditValueWithTag()), datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA, adicion:=Decimal.Zero)
                                    'AgregarADetalle(coltoAdd, cristal, cantidad:=txtCantidadOjoCercaIzquierdo.EditValue, cilindrico:=NumberConversor.ParseDecimal(txtCilindricoOjoCercaIzquierdo.GetEditValueWithTag()), esferico:=NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.GetEditValueWithTag()), datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA, descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00}", cristal.DescripcionFull, txtCilindricoOjoCercaIzquierdo.GetEditValueWithTagOrZero(), txtEsfericoOjoCercaIzquierdo.GetEditValueWithTagOrZero()), adicion:=Decimal.Zero)
                                    cantCristales = txtCantidadOjoCercaIzquierdo.EditValue
                                End If

                                CheckStockCristalCercaIzquierdo(articulosCtrlStock, cantCristales)

                            End If

                            Dim servicios As List(Of Integer) = GetSelectedServicios(cboServiciosCerca)
                            For Each servicioId As Integer In servicios
                                Dim servicio As ArticuloEntity = ArticuloController.BuscarPorId(da, servicioId, New ExcludeIncludeFieldsList(False, New IEntityFieldCore() {ArticuloFields.Descripcion, ArticuloFields.DescripcionVariante}))
                                AgregarADetalle(coltoAdd, servicio, cantidad:=txtCantidadOjoCercaIzquierdo.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA)
                            Next

                        End If

                    End If

                    If cboArmazonIdCerca.HasValue() Then
                        Dim armazon As ArticuloEntity = ArticuloController.BuscarPorId(da, CInt(cboArmazonIdCerca.EditValue), New ExcludeIncludeFieldsList(False, New IEntityFieldCore() {ArticuloFields.Descripcion, ArticuloFields.DescripcionVariante, ArticuloFields.ControlaStock}))
                        AgregarADetalle(coltoAdd, armazon, cantidad:=txtCantidadArmazonCerca.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA)
                        CheckStockArmazonCerca(armazon)
                    End If


                    If cboArmazonIdLejos.HasValue() Then
                        Dim armazon As ArticuloEntity = ArticuloController.BuscarPorId(da, CInt(cboArmazonIdLejos.EditValue), New ExcludeIncludeFieldsList(False, New IEntityFieldCore() {ArticuloFields.Descripcion, ArticuloFields.DescripcionVariante, ArticuloFields.ControlaStock}))
                        AgregarADetalle(coltoAdd, armazon, cantidad:=txtCantidadArmazonLejos.EditValue, datoExtra:=DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS)
                        CheckStockArmazonLejos(armazon)
                    End If

                    EntityToEdit.AgregarDetalles(coltoAdd)

                    EntityToEdit.ConvenioImporte = Decimal.Zero
                    EntityToEdit.SetNewFieldValue(DV_RecetaComunFieldIndex.ConvenioId.ToString(), Nothing)
                    If cboConvenioId.EditValue IsNot Nothing Then
                        EntityToEdit.ConvenioId = CInt(cboConvenioId.EditValue)
                        Decimal.TryParse(txtConvenioImporte.Text, EntityToEdit.ConvenioImporte)
                        ConvenioController.ProcesarConvenio(EntityToEdit, TotalDetalle().Total, CInt(cboConvenioId.EditValue))
                        If EntityToEdit.BonificacionId > 0 Then
                            SetControlEditValue_ThreadSafe(cboBonificacionId, EntityToEdit.BonificacionId)
                        End If
                        'Dim convenio As ConvenioEntity = ConvenioController.BuscarPorId(CInt(cboConvenioId.EditValue))
                        'Dim importe As Decimal = Decimal.Zero
                        'If convenio.TipoDescuento = ConvenioTipoDescuento.Porcentaje Then
                        '    Dim total As TotalDetalleInfo = TotalDetalle()
                        '    importe = total.Total * (convenio.PorcentajeDescuento / 100)
                        'Else
                        '    importe = txtConvenioImporte.EditValue
                        'End If

                        ''Agregar al convenio
                        'If importe > Decimal.Zero Then
                        '    AgregarADetalle(coltoAdd, ArticuloController.BuscarPorId(convenio.ArticuloIdDescuento), String.Empty, importeDiferencial:=importe * Decimal.MinusOne, cantidad:=Decimal.One)
                        'End If

                    End If
                    RefrescarTotal()

                End Using


                Return True

            Catch ex As Exception

                ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
                Dim trace As String = ex.StackTrace

            End Try
        End If

        Return False
    End Function

    Protected Overridable Sub CargarArticulos()

        If Not _lockUpdate Then

            Do While bgwDetalles.IsBusy
                Application.DoEvents()
            Loop

            bgwDetalles.RunWorkerAsync()
        End If

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
        Return LocalController.BuscarLocalIdFromCaja(CajaId)
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
        'EntityToEdit.Id = -1
    End Sub

    Private Sub CargarDatosPorDefecto()

        Try

            If CurrentEntity Is Nothing Then Return

            _lockUpdate = True
            Dim unCajaEntity As CajaEntity = CajaController.BuscarPorId(CajaId)
            Me.cboMonedaId.EditValue = unCajaEntity.MonedaId
            Me.cboClienteId.EditValue = unCajaEntity.ClienteId
            txtFechaEmitida.EditValue = System.DateTime.Today

            CargarDatosCliente(cboClienteId.EditValue)
            'ActualizarDatosCliente(CInt(cboClienteId.EditValue))
            If unCajaEntity.ListaPreVtaId > 0I Then
                _lockUpdate = False
                Me.cboListaPreVtaId.EditValue = unCajaEntity.ListaPreVtaId
                _lockUpdate = True
            End If

            Me.cboFuncionarioId.EditValue = FuncionarioController.BuscarFuncionarioIdFromUsuario(Studio.Net.Helper.UserManager.UserInfo.Login)
            GetCurrentEntity(Of DV_RecetaComunEntity).CajaId = CajaId
            CargarCotizaciones()
            lcgLejos.Enabled = False
            lcgCondiciones.Enabled = False
            lcgCerca.Enabled = False
            lcgConvenio.Enabled = False

            _tmp_DocumentoSalida = Nothing
            If Not String.IsNullOrEmpty(unCajaEntity.XML) Then
                Dim parametro As ParametroCaja = ParametroCaja.FromXML(unCajaEntity.XML)
                Dim lockUpdate As Boolean = _lockUpdate
                _lockUpdate = False
                rgrRecetaComunTipo.EditValue = parametro.TipoReceta
                rgrTipoOperacion.EditValue = parametro.TipoOperacion
                rgrVentaTipo.EditValue = parametro.TipoDeVenta
                cboCristalMaterialIdLejosDerecho.EditValue = parametro.CristalMaterialId
                cboCristalMaterialIdLejosIzquierdo.EditValue = parametro.CristalMaterialId
                cboCristalMaterialIdCercaDerecho.EditValue = parametro.CristalMaterialId
                cboCristalMaterialIdCercaIzquierdo.EditValue = parametro.CristalMaterialId

                _lockUpdate = lockUpdate
            End If

            txtConvenioImporte.Properties.ReadOnly = Not cboConvenioId.HasValue()
            txtConvenioNumero.Properties.ReadOnly = Not cboConvenioId.HasValue()

            txtCantidadArmazonCerca.EditValue = 1
            txtCantidadArmazonLejos.EditValue = 1
            txtCantidadOjoCercaDerecho.EditValue = 1
            txtCantidadOjoCercaIzquierdo.EditValue = 1
            txtCantidadOjoLejosDerecho.EditValue = 1
            txtCantidadOjoLejosIzquierdo.EditValue = 1

        Finally
            _lockUpdate = False
        End Try

    End Sub

    Private Sub OnDismissQueryable(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

        Dim da As IDataAccessAdapter = TryCast(e.Tag, IDataAccessAdapter)
        If da IsNot Nothing Then
            da.Dispose()
        End If
        e.Tag = Nothing

    End Sub

    Private Sub OnGetQueryableLejosIzquierdo(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

        Dim da As IDataAccessAdapter = Nothing
        If (CurrentEntityIsNew()) Then
            If OjoLejosIzquierdoCargado() Then

                VerificarConversionsLejos()

                Dim esferico1 As Decimal = NumberConversor.ParseDecimal(txtEsfericoOjoLejosIzquierdo.GetEditValueWithTag())
                Dim esferico2 As Decimal = NumberConversor.ParseDecimal(txtEsfericoOjoLejosIzquierdo.GetEditValueWithTag())
                Dim cilindrico1 As Decimal = NumberConversor.ParseDecimal(txtCilindricoOjoLejosIzquierdo.GetEditValueWithTag())
                Dim cilindrico2 As Decimal = NumberConversor.ParseDecimal(txtCilindricoOjoLejosIzquierdo.GetEditValueWithTag())
                Dim adicion1 As Decimal = NumberConversor.ParseDecimal(txtAdicionOjoLejosIzquierdo.GetEditValueWithTag())
                Dim adicion2 As Decimal = NumberConversor.ParseDecimal(txtAdicionOjoLejosIzquierdo.GetEditValueWithTag())

                If txtEsfericoOjoLejosIzquierdo.Text = String.Empty Then
                    esferico1 = esferico2
                End If
                'If txtEsfericoOjoLejosIzquierdo.Text = String.Empty Then
                '    esferico2 = esferico1
                'End If
                If txtCilindricoOjoLejosIzquierdo.Text = String.Empty Then
                    cilindrico1 = cilindrico2
                End If
                'If txtCilindricoOjoLejosIzquierdo.Text = String.Empty Then
                '    cilindrico2 = cilindrico1
                'End If
                If txtAdicionOjoLejosIzquierdo.Text = String.Empty Then
                    adicion2 = adicion1
                End If
                'If txtAdicionOjoLejosIzquierdo.Text = String.Empty Then
                '    adicion2 = adicion1
                'End If

                e.QueryableSource = (DV_CristalBEntity.GetQueryableForReceta(da, cilindrico1, cilindrico2,
                                                        esferico1, esferico2,
                                                        adicion1, adicion2,
                                                        CInt(cboListaPreVtaId.EditValue),
                                                         CInt(cboCristalMaterialIdLejosIzquierdo.EditValue), CInt(rgrRecetaComunTipo.EditValue),
                                                        _parametroTree))
            Else
                e.QueryableSource = Nothing
            End If

        Else
            e.QueryableSource = (New DV_CristalBEntity).GetDataForComboAsQueryable()
        End If
        e.Tag = da

    End Sub

    Private Sub VerificarConversionsLejos()
        If _parametroTree.Optica.ManejoCilindrico = ManejoCilindricos.SoloNegativo Then

            Dim cilindrico As Decimal = txtCilindricoOjoLejosDerecho.EditValue
            If cilindrico > Decimal.Zero Then
                'txtCilindricoOjoLejosDerecho.EditValue = cilindrico * Decimal.MinusOne
                txtCilindricoOjoLejosDerecho.Tag = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoLejosDerecho.EditValue += cilindrico
                txtEsfericoOjoLejosDerecho.Tag = txtEsfericoOjoLejosDerecho.EditValue + cilindrico
                If txtEjeOjoLejosDerecho.Text <> String.Empty Then
                    'txtEjeOjoLejosDerecho.EditValue = (NumberConversor.ParseDecimal(txtEjeOjoLejosDerecho.Text) + 90) Mod 180
                    'Aquí hacemos la transposición
                    txtEjeOjoLejosDerecho.Tag = (NumberConversor.ParseDecimal(txtEjeOjoLejosDerecho.Text) + 90) Mod 180
                End If

            Else
                txtCilindricoOjoLejosDerecho.Tag = Nothing
                txtEsfericoOjoLejosDerecho.Tag = Nothing
                txtEjeOjoLejosDerecho.Tag = Nothing
            End If

            cilindrico = txtCilindricoOjoLejosIzquierdo.EditValue

            If cilindrico > Decimal.Zero Then
                'txtCilindricoOjoLejosIzquierdo.EditValue = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoLejosIzquierdo.EditValue += cilindrico
                txtCilindricoOjoLejosIzquierdo.Tag = cilindrico * Decimal.MinusOne
                txtEsfericoOjoLejosIzquierdo.Tag = txtEsfericoOjoLejosIzquierdo.EditValue + cilindrico

                If txtEjeOjoLejosIzquierdo.Text <> String.Empty Then
                    'txtEjeOjoLejosIzquierdo.EditValue = (NumberConversor.ParseDecimal(txtEjeOjoLejosIzquierdo.Text) + 90) Mod 180
                    txtEjeOjoLejosIzquierdo.Tag = (NumberConversor.ParseDecimal(txtEjeOjoLejosIzquierdo.Text) + 90) Mod 180
                End If
            Else
                txtCilindricoOjoLejosIzquierdo.Tag = Nothing
                txtEsfericoOjoLejosIzquierdo.Tag = Nothing
                txtEjeOjoLejosIzquierdo.Tag = Nothing
            End If

        ElseIf _parametroTree.Optica.ManejoCilindrico = ManejoCilindricos.SoloPositivo Then


            Dim cilindrico As Decimal = txtCilindricoOjoLejosDerecho.EditValue
            If cilindrico < Decimal.Zero Then

                'txtCilindricoOjoLejosDerecho.EditValue = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoLejosDerecho.EditValue += cilindrico
                txtCilindricoOjoLejosDerecho.Tag = cilindrico * Decimal.MinusOne
                txtEsfericoOjoLejosDerecho.Tag = txtEsfericoOjoLejosDerecho.EditValue + cilindrico
                If txtEjeOjoCercaDerecho.Text <> String.Empty Then
                    'txtEjeOjoCercaDerecho.EditValue = (NumberConversor.ParseDecimal(txtEjeOjoCercaDerecho.Text) + 90) Mod 180
                    txtEjeOjoCercaDerecho.Tag = (NumberConversor.ParseDecimal(txtEjeOjoCercaDerecho.Text) + 90) Mod 180
                End If
            Else
                txtCilindricoOjoLejosDerecho.Tag = Nothing
                txtEsfericoOjoLejosDerecho.Tag = Nothing
                txtEjeOjoCercaDerecho.Tag = Nothing

            End If
            cilindrico = txtCilindricoOjoLejosIzquierdo.EditValue
            If cilindrico < Decimal.Zero Then
                'txtCilindricoOjoLejosIzquierdo.EditValue = cilindrico * Decimal.MinusOne
                'txtEsfericoOjoLejosIzquierdo.EditValue += cilindrico
                txtCilindricoOjoLejosIzquierdo.Tag = cilindrico * Decimal.MinusOne
                txtEsfericoOjoLejosIzquierdo.Tag = txtEsfericoOjoLejosIzquierdo.EditValue + cilindrico
                If txtEjeOjoCercaIzquierdo.Text <> String.Empty Then
                    'txtEjeOjoCercaIzquierdo.EditValue = (NumberConversor.ParseDecimal(txtEjeOjoCercaIzquierdo.Text) + 90) Mod 180
                    txtEjeOjoCercaIzquierdo.Tag = (NumberConversor.ParseDecimal(txtEjeOjoCercaIzquierdo.Text) + 90) Mod 180

                End If
            Else
                txtCilindricoOjoLejosIzquierdo.Tag = Nothing
                txtEsfericoOjoLejosIzquierdo.Tag = Nothing
                txtEjeOjoCercaIzquierdo.Tag = Nothing
            End If

        End If
    End Sub

    Private Sub OnGetQueryableLejosDerecho(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

        Dim da As IDataAccessAdapter = Nothing
        If (CurrentEntityIsNew()) Then
            If OjoLejosDerechoCargado() Then

                VerificarConversionsLejos()

                Dim esferico1 As Decimal = NumberConversor.ParseDecimal(txtEsfericoOjoLejosDerecho.GetEditValueWithTag())
                Dim esferico2 As Decimal = NumberConversor.ParseDecimal(txtEsfericoOjoLejosDerecho.GetEditValueWithTag())
                Dim cilindrico1 As Decimal = NumberConversor.ParseDecimal(txtCilindricoOjoLejosDerecho.GetEditValueWithTag())
                Dim cilindrico2 As Decimal = NumberConversor.ParseDecimal(txtCilindricoOjoLejosDerecho.GetEditValueWithTag())
                Dim adicion1 As Decimal = NumberConversor.ParseDecimal(txtAdicionOjoLejosDerecho.Text)
                Dim adicion2 As Decimal = NumberConversor.ParseDecimal(txtAdicionOjoLejosDerecho.Text)

                If txtEsfericoOjoLejosDerecho.Text = String.Empty Then
                    esferico1 = esferico2
                End If
                'If txtEsfericoOjoLejosIzquierdo.Text = String.Empty Then
                '    esferico2 = esferico1
                'End If
                If txtCilindricoOjoLejosDerecho.Text = String.Empty Then
                    cilindrico1 = cilindrico2
                End If
                'If txtCilindricoOjoLejosIzquierdo.Text = String.Empty Then
                '    cilindrico2 = cilindrico1
                'End If
                If txtAdicionOjoLejosDerecho.Text = String.Empty Then
                    adicion2 = adicion1
                End If
                'If txtAdicionOjoLejosIzquierdo.Text = String.Empty Then
                '    adicion2 = adicion1
                'End If
                'Try
                '    Throw New Exception("")
                'Catch ex As Exception
                '    Stop
                'End Try

                e.QueryableSource = (DV_CristalBEntity.GetQueryableForReceta(da, cilindrico1, cilindrico2,
                                                        esferico1, esferico2,
                                                        adicion1, adicion2,
                                                        CInt(cboListaPreVtaId.EditValue),
                                                         CInt(cboCristalMaterialIdLejosDerecho.EditValue), CInt(rgrRecetaComunTipo.EditValue),
                                                        _parametroTree))
            Else
                e.QueryableSource = Nothing
            End If

        Else
            e.QueryableSource = (New DV_CristalBEntity).GetDataForComboAsQueryable()
        End If
        e.Tag = da

    End Sub

    Private Sub OnGetQueryableCercaDerecho(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

        Dim da As IDataAccessAdapter = Nothing

        If CurrentEntityIsNew() AndAlso _cercaEsSegundoPar Then

            If OjoCercaDerechoCargado() Then

                VerificarConversionesCerca()

                Dim esferico1 As Decimal = NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.GetEditValueWithTag())
                Dim esferico2 As Decimal = NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.GetEditValueWithTag())
                Dim cilindrico1 As Decimal = NumberConversor.ParseDecimal(txtCilindricoOjoCercaDerecho.GetEditValueWithTag())
                Dim cilindrico2 As Decimal = NumberConversor.ParseDecimal(txtCilindricoOjoCercaDerecho.GetEditValueWithTag())

                If txtEsfericoOjoCercaDerecho.Text = String.Empty Then
                    esferico1 = esferico2
                End If
                If txtEsfericoOjoCercaIzquierdo.Text = String.Empty Then
                    esferico2 = esferico1
                End If
                If txtCilindricoOjoCercaDerecho.Text = String.Empty Then
                    cilindrico1 = cilindrico2
                End If
                If txtCilindricoOjoCercaIzquierdo.Text = String.Empty Then
                    cilindrico2 = cilindrico1
                End If


                e.QueryableSource = (DV_CristalBEntity.GetQueryableForReceta(da, cilindrico1, cilindrico2,
                                                        esferico1, esferico2,
                                                        Decimal.Zero, Decimal.Zero,
                                                        CInt(cboListaPreVtaId.EditValue),
                                                         CInt(cboCristalMaterialIdCercaDerecho.EditValue), CInt(rgrRecetaComunTipo.EditValue),
                                                        _parametroTree))

                'e.QueryableSource = (DV_CristalBEntity.GetQueryableForReceta(da, NumberConversor.ParseDecimal(txtCilindricoOjoCercaDerecho.Text), NumberConversor.ParseDecimal(txtCilindricoOjoCercaIzquierdo.Text), _
                '                                        NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.Text), NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.Text), _
                '                                        Decimal.Zero, Decimal.Zero, _
                '                                        CInt(cboListaPreVtaId.EditValue), _
                '                                        CInt(cboCristalMaterialIdCerca.EditValue), CInt(rgrRecetaComunTipo.EditValue), _
                '                                        _parametroTree))
            Else
                e.QueryableSource = Nothing
            End If
        Else
            e.QueryableSource = (New DV_CristalBEntity).GetDataForComboAsQueryable()
        End If
        e.Tag = da

    End Sub

    Private Sub OnGetQueryableCercaIzquierdo(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

        Dim da As IDataAccessAdapter = Nothing

        If CurrentEntityIsNew() AndAlso _cercaEsSegundoPar Then

            If OjoCercaIzquierdoCargado() Then

                VerificarConversionesCerca()

                Dim esferico1 As Decimal = NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.GetEditValueWithTag())
                Dim esferico2 As Decimal = NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.GetEditValueWithTag())
                Dim cilindrico1 As Decimal = NumberConversor.ParseDecimal(txtCilindricoOjoCercaIzquierdo.GetEditValueWithTag())
                Dim cilindrico2 As Decimal = NumberConversor.ParseDecimal(txtCilindricoOjoCercaIzquierdo.GetEditValueWithTag())

                If txtEsfericoOjoCercaDerecho.Text = String.Empty Then
                    esferico1 = esferico2
                End If
                If txtEsfericoOjoCercaIzquierdo.Text = String.Empty Then
                    esferico2 = esferico1
                End If
                If txtCilindricoOjoCercaDerecho.Text = String.Empty Then
                    cilindrico1 = cilindrico2
                End If
                If txtCilindricoOjoCercaIzquierdo.Text = String.Empty Then
                    cilindrico2 = cilindrico1
                End If


                e.QueryableSource = (DV_CristalBEntity.GetQueryableForReceta(da, cilindrico1, cilindrico2,
                                                        esferico1, esferico2,
                                                        Decimal.Zero, Decimal.Zero,
                                                        CInt(cboListaPreVtaId.EditValue),
                                                         CInt(cboCristalMaterialIdCercaIzquierdo.EditValue), CInt(rgrRecetaComunTipo.EditValue),
                                                        _parametroTree))

                'e.QueryableSource = (DV_CristalBEntity.GetQueryableForReceta(da, NumberConversor.ParseDecimal(txtCilindricoOjoCercaDerecho.Text), NumberConversor.ParseDecimal(txtCilindricoOjoCercaIzquierdo.Text), _
                '                                        NumberConversor.ParseDecimal(txtEsfericoOjoCercaDerecho.Text), NumberConversor.ParseDecimal(txtEsfericoOjoCercaIzquierdo.Text), _
                '                                        Decimal.Zero, Decimal.Zero, _
                '                                        CInt(cboListaPreVtaId.EditValue), _
                '                                        CInt(cboCristalMaterialIdCerca.EditValue), CInt(rgrRecetaComunTipo.EditValue), _
                '                                        _parametroTree))
            Else
                e.QueryableSource = Nothing
            End If
        Else
            e.QueryableSource = (New DV_CristalBEntity).GetDataForComboAsQueryable()
        End If
        e.Tag = da

    End Sub


    Private Sub NewCliente(tipo As ClienteTipo)

        Dim d As DetailViewDialog = Nothing
        Dim entityToAdd As ClienteEntity = Nothing
        If tipo = ClienteTipo.Empresa Then
            entityToAdd = ClienteEmpresaBEntity.NewEntity()
            d = New DetailViewDialog(New ClienteBEntity, GetType(ClienteDetailView), ClienteEmpresaBEntity.NewEntity())
        ElseIf tipo = ClienteTipo.Particular Then
            entityToAdd = ClienteParticularBEntity.NewEntity()
            d = New DetailViewDialog(New ClienteBEntity, GetType(ClienteDetailView), ClienteParticularBEntity.NewEntity())
        End If

        Dim parentForm As MainFormBase = TryCast(FindForm(), MainFormBase)

        If parentForm IsNot Nothing Then
            d.Location = parentForm.PointToScreen(New System.Drawing.Point(parentForm.xTab.Left, parentForm.panel.Top))
            d.Size = parentForm.xTab.Size
        Else
            d.Location = FindForm().Location()
            d.Size = FindForm().Size
        End If

        d.StartPosition = Windows.Forms.FormStartPosition.Manual

        Try

            parentForm.Enabled = False

            If d.ShowDialog(FindForm()) = Windows.Forms.DialogResult.OK Then
                cboClienteId.RefresDataSource()
                cboClienteId.EditValue = d.AddedEntity.Fields(ClienteFieldIndex.Id.ToString()).CurrentValue
                CargarDatosCliente(CInt(cboClienteId.EditValue))
            End If

        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            parentForm.Enabled = True
        End Try

    End Sub

    Private Sub LimpiarCliente()
        txtClienteIdentificacion.Text = String.Empty
        'txtClienteDireccion.Text = String.Empty
        txtDireccion.Text = String.Empty
        txtRuc.Text = String.Empty
        cboClienteId.EditValue = Nothing
    End Sub

    Private Sub CargarDatosCliente(clienteId As Integer)

        Me.txtRuc.Text = String.Empty
        Me.txtNombre.Text = String.Empty
        Me.txtDireccion.Text = String.Empty
        cboPaisId.EditValue = Nothing

        If clienteId > 0 Then
            Dim cliente As ClienteEntity = ClienteController.GetClienteConIdentificacion(clienteId)
            Try
                Dim toReturn As New RelationPredicateBucket
                toReturn.PredicateExpression.Add(New FieldCompareSetPredicate(DocumentoSalidaFields.Id, Nothing, DocSalidaDetalleFields.DocumentoSalidaId, Nothing, SetOperator.Exist, ArticuloFields.ArticuloClaseId = 4, New RelationCollection(DocSalidaDetalleEntity.Relations.ArticuloEntityUsingArticuloId)))
                If cliente IsNot Nothing Then
                    'txtClienteDireccion.Text = cliente.DirecOcion
                        txtDireccion.Text = cliente.Direccion
                    txtNombre.Text = cliente.Descripcion

                    'If TypeOf cliente Is ClienteParticularEntity Then
                    '    'If cliente.ClienteParticular IsNot Nothing Then
                    '    txtClienteIdentificacion.Text = DirectCast(cliente, ClienteParticularEntity).DocumentoIdentidad
                    'ElseIf TypeOf cliente Is ClienteEmpresaEntity Then
                    '    txtClienteIdentificacion.Text = DirectCast(cliente, ClienteEmpresaEntity).Ruc
                    '    txtRuc.Text = txtClienteIdentificacion.Text
                    'End If
                    'ActualizarDatosCliente(CInt(cboClienteId.EditValue))


                    If cliente.ClienteTipoId = ClienteTipo.Particular Then
                        Dim fields As New ExcludeIncludeFieldsList(False)
                        fields.Add(ClienteParticularFields.DocumentoIdentidad)
                        Dim cp As ClienteParticularEntity = ClienteParticularController.BuscarPorId(Nothing, clienteId, fields)
                        If cp.DocumentoIdentidad > Decimal.Zero Then
                            txtClienteIdentificacion.Text = cp.DocumentoIdentidad.ToString()
                        Else
                            txtClienteIdentificacion.Text = cp.Id
                        End If

                    Else
                        Dim fields As New ExcludeIncludeFieldsList(False)
                        fields.Add(ClienteEmpresaFields.Ruc)
                        Dim cp As ClienteEmpresaEntity = ClienteEmpresaController.BuscarPorId(Nothing, clienteId, fields)
                        If Not String.IsNullOrEmpty(cp.Ruc) Then
                            txtClienteIdentificacion.Text = cp.Ruc
                        Else
                            txtClienteIdentificacion.Text = cp.Id.ToString()
                        End If
                        txtRuc.EditValue = cp.Ruc
                        'Me.txtRuc.Text = DirectCast(cliente, ClienteEmpresaEntity).Ruc
                        cboClienteDocumentoTipoId.EditValue = Drako.FE.Common.TipoDocumentoReceptor.RUT
                        If cliente.CiudadId > 0 AndAlso txtRuc.Text <> String.Empty Then
                            cboPaisId.EditValue = PaisController.BuscarPorCiudadId(Nothing, cliente.CiudadId).Id
                        End If
                        cboClienteDocumentoTipoId.EditValue = Drako.FE.Common.TipoDocumentoReceptor.RUT
                        'txtDireccion.Text = cp.Direccion
                    End If


                    txtNombre.Properties.ReadOnly = Not cliente.Ficticio
                    txtRuc.Properties.ReadOnly = Not cliente.Ficticio

                    Me.VerificarClienteAdministrado(clienteId)

                End If

            Catch ex As Exception
                ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
        'txtClienteIdentificacion.Text = ClienteController.GetIdentificacion(cliente)
    End Sub

    Private Sub VerificarClienteAdministrado(ByVal clienteId As Integer)

        lciDepositoIdAdministrado.ContentVisible = clienteId > 0 AndAlso ClienteController.AdministraEmpresa(clienteId) AndAlso
            Not DocumentoTipoController.BuscarPorId(DocumentoTipo.RecetaComun).OmitirDepositoDestino
        If Me.lciDepositoIdAdministrado.ContentVisible Then
            Me.FiltrarDepositoAdministrado(clienteId)
        Else
            Me.cboDepositoIdAdministrado.EditValue = Nothing
        End If
        lciDepositoIdAdministrado.Visibility = IIf(lciDepositoIdAdministrado.ContentVisible, DevExpress.XtraLayout.Utils.LayoutVisibility.Always, DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
        LayoutControl.Refresh()
    End Sub

    Private Sub FiltrarDepositoAdministrado(ByVal clienteId As Integer)

        BusinessToUse.Fields(DV_RecetaComunFieldIndex.DepositoIdAdministrado.ToString()).ForeignBEntity = DepositoController.CrearBEntityParaDepositoAdministrado(clienteId)
        CreateDataBinding(_bindedControls.Single(Function(f) f.Key = cboDepositoIdAdministrado.Name))
        cboDepositoIdAdministrado.RefreshDataSource()

    End Sub
    Private Function GetDocumentoTipoId() As Integer
        Return CType(Me.cboDocumentoTipoId.EditValue, Integer)
    End Function


    Private Sub SetLayoutProperties()
        LayoutControl.AllowCustomizationMenu = Studio.Net.Helper.Environment.RunningUnderIDE
        LayoutControl.OptionsCustomizationForm.ShowSaveButton = Studio.Net.Helper.Environment.RunningUnderIDE
        LayoutControl.OptionsCustomizationForm.ShowLoadButton = Studio.Net.Helper.Environment.RunningUnderIDE
    End Sub

    'Private Sub SetFilterParametersCerca()
    '    If cboCristalIdCerca.BusinessToUse Is Nothing Then Return

    '    With DirectCast(cboCristalIdCerca.BusinessToUse, DV_CristalFiltrado)
    '        Int32.TryParse(rgrRecetaComunTipo.EditValue, .RecetaTipoId)
    '        Int32.TryParse(cboCristalMaterialIdCerca.EditValue, .CristalMaterialId)
    '    End With
    '    cboCristalIdCerca.EditValue = Nothing
    '    cboCristalIdCerca.RefresDataSource()
    'End Sub

    Private Sub SetBusinessProperties(ByVal business As DV_RecetaBEntity)

        'business.Fields(DV_RecetaComunFieldIndex.CristalIdCerca.ToString()).ForeignBEntity = New DV_CristalFiltrado
        business.Fields(DV_RecetaComunFieldIndex.DepositoIdAdministrado.ToString()).Displayable = True
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

    Private Sub LimpiarDatosCliente()

        txtClienteIdentificacion.Text = String.Empty
        'txtClienteDireccion.Text = String.Empty
        txtDireccion.Text = String.Empty
        txtNombre.Text = String.Empty


        txtRuc.Text = String.Empty

    End Sub

    Private Sub ActualizarDatosCliente(ByVal clienteId As Integer)

        Dim cliente As ClienteEntity = ClienteController.BuscarPorId(clienteId)
        'txtClienteDireccion.Text = cliente.Direccion
        txtDireccion.Text = cliente.Direccion
        txtRuc.Text = cliente.Telefono
        If cliente.ClienteTipoId = ClienteTipo.Particular Then
            Dim fields As New ExcludeIncludeFieldsList(False)
            fields.Add(ClienteParticularFields.DocumentoIdentidad)
            Dim cp As ClienteParticularEntity = ClienteParticularController.BuscarPorId(Nothing, clienteId, fields)
            If cp.DocumentoIdentidad > Decimal.Zero Then
                txtClienteIdentificacion.Text = cp.DocumentoIdentidad.ToString()
            Else
                txtClienteIdentificacion.Text = cp.Id
            End If

        Else
            Dim fields As New ExcludeIncludeFieldsList(False)
            fields.Add(ClienteEmpresaFields.Ruc)
            Dim cp As ClienteEmpresaEntity = ClienteEmpresaController.BuscarPorId(Nothing, clienteId, fields)
            If Not String.IsNullOrEmpty(cp.Ruc) Then
                txtClienteIdentificacion.Text = cp.Ruc
            Else
                txtClienteIdentificacion.Text = cp.Id.ToString()
            End If
        End If
        cboClienteId.EditValue = clienteId

    End Sub


#End Region

#Region "Métodos públicos"

    Public Sub ConfirmarPresupuesto()

        Dim relacion As DocumentoSalidaRelacionEntity = DocumentoSalidaRelacionBEntity.BuscarPorPadre(EntityToEdit.Id, EntityToEdit.CajaId, DocumentoSalidaRelacion.ConfirmacionDePresupuesto)

        If relacion IsNot Nothing Then

            If MyMsgBox.Show(String.Format("El presupuesto ya fue confirmado en la receta {0}.{1}¿Seguro que desea generar otra receta?.", DocumentoSalidaController.BuscarPorId(Nothing, relacion.DocumentoSalidaId2, relacion.CajaId2, Nothing, New ExcludeIncludeFieldsList(False, New EntityField2() {DocumentoSalidaFields.NumeroDocumento})).NumeroDocumento, vbCrLf), MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                Return
            End If
        End If

        CursorManager.WaitCursor()

        Dim receta As DV_RecetaEntity = DV_RecetaComunBEntity.GenerarRecetaDesdePresupuesto(EntityToEdit)
        Dim documentoRelacionado As DocumentoSalidaEntity = EntityToEdit


        Try

            DirectCast(BindingSource.DataSource, IEntityCollection2).Add(receta)
            BindingSource.Position = BindingSource.Count - 1
            cboCristalMaterialIdCercaDerecho.EditValue = Nothing
            cboCristalIdCercaDerecho.EditValue = Nothing
            cboCristalMaterialIdLejosDerecho.EditValue = Nothing
            cboCristalIdCercaDerecho.EditValue = Nothing

            cboCristalMaterialIdLejosDerecho.EditValue = EntityToEdit.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdLejosDerecho).CurrentValue
            cboCristalMaterialIdLejosIzquierdo.EditValue = EntityToEdit.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdLejosIzquierdo).CurrentValue
            cboCristalIdLejosDerecho.EditValue = EntityToEdit.Fields(DV_RecetaComunFieldIndex.CristalIdLejosDerecho).CurrentValue
            cboCristalIdLejosIzquierdo.EditValue = EntityToEdit.Fields(DV_RecetaComunFieldIndex.CristalIdLejosIzquierdo).CurrentValue
            cboCristalMaterialIdCercaDerecho.EditValue = EntityToEdit.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdCercaDerecho).CurrentValue
            cboCristalMaterialIdCercaIzquierdo.EditValue = EntityToEdit.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdCercaIzquierdo).CurrentValue
            cboCristalIdCercaDerecho.EditValue = EntityToEdit.Fields(DV_RecetaComunFieldIndex.CristalIdLejosDerecho).CurrentValue
            cboCristalIdCercaIzquierdo.EditValue = EntityToEdit.Fields(DV_RecetaComunFieldIndex.CristalIdCercaIzquierdo).CurrentValue

            _documentoRelacionado = documentoRelacionado
            _documentoRelacionadoTipo = DocumentoSalidaRelacion.ConfirmacionDePresupuesto

            'Entity2Controls(False)

            'CargarDatosPorDefecto()
            'OnRecetaTipoChanged(DirectCast(rgrRecetaComunTipo, RadioGroup))
            'SaveCurrent()
        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        CursorManager.Default()

    End Sub

    Public Sub ImprimirOrden(receta As DV_RecetaComunEntity)
        ImprimirDocumento(receta)
    End Sub

    Public Sub DevolverReceta()

        Dim lastPosition As Integer = -1

        Try

            CursorManager.WaitCursor()

            Dim unDocumentoEy As DocumentoSalidaEntity =
                    DocumentoSalidaController.RemotingClass.DocumentoSalidaOkParaDevolucion(EntityToEdit.Id, EntityToEdit.CajaId)
            If unDocumentoEy Is Nothing Then
                ShowMsgBox("El documento seleccionado no se puede devolver", MsgBoxStyle.Exclamation) 'Throw New ApplicationException("El documento seleccionado no se puede devolver") 
                Return
            End If

            ParentForm.Enabled = False

            DV_RecetaComunBEntity.FetchRecetaParaDevolucion(EntityToEdit)

            Dim aDevolver As DV_RecetaComunEntity = EntityToEdit.DeepClone()
            'aDevolver.Id = 0
            aDevolver.Cobros.Clear()
            aDevolver.Devolucion = True
            aDevolver.Numero = String.Empty
            aDevolver.SetNewFieldValue(DV_RecetaComunFieldIndex.FechaCancelada, Nothing)
            aDevolver.SetNewFieldValue(DV_RecetaComunFieldIndex.FechaFacturada, Nothing)
            aDevolver.SetNewFieldValue(DV_RecetaComunFieldIndex.FechaEmitida, Nothing)
            aDevolver.SetNewFieldValue(DV_RecetaComunFieldIndex.FechaVencimiento, Nothing)
            aDevolver.MovimientoProcesado = False
            aDevolver.ImporteSaldoRestante = aDevolver.ImporteTotal
            aDevolver.ImportePagoTotal = Decimal.Zero
            aDevolver.NumeroDocumento = Tmp_DocumentoSalidaController.NumeroDocumentoMask

            Dim toSave As Tmp_DocumentoSalidaEntity = DV_RecetaComunBEntity.CrearTmpDocumentoSalida(aDevolver, _parametroTree)
            Tmp_DocumentoSalidaController.BorrarTodo(Nothing, ConfigReaderSpecific.GetStringDeTerminal())
            Tmp_DocumentoSalidaController.MarcarParaAlta(toSave)

            aDevolver.DocumentoTipoId = toSave.DocumentoTipoId
            Dim numeroDocumento As String = Tmp_DocumentoSalidaController.NumeroDocumentoMask
            If aDevolver.IngresoManual Then
                numeroDocumento = MyInputBox.Show(FindForm(), "Ingrese el número de documento.")
                If String.IsNullOrEmpty(numeroDocumento) Then
                    Return
                End If
            End If
            toSave.NumeroDocumento = numeroDocumento

            Dim valid As New ValidatorHelper
            valid.Validate(toSave, False)
            _documentoRelacionado = EntityToEdit
            _documentoRelacionadoTipo = DocumentoSalidaRelacion.DevolucionDeVenta
            Tmp_DocumentoSalidaController.GuardarDocumento(Nothing, toSave, _documentoRelacionado, _documentoRelacionadoTipo, True)
            lastPosition = BindingSource.Position
            DirectCast(BindingSource.DataSource, IEntityCollection2).Add(aDevolver)
            BindingSource.MoveLast() ' = BindingSource.Count - 1

            _tmp_DocumentoSalida = toSave

            BusinessToUse.BeforeSaveEntity(aDevolver)
            valid.Validate(aDevolver, False)
            Dim args As New PagoFinalizadoEventArgs(Decimal.Zero, Nothing, String.Empty, System.DateTime.Today, String.Empty, Nothing)
            If Me.HayQueIngresarPago() Then
                If Not Me.InicializarPago() Then
                    args.Cancel = True
                End If
            Else
                Me.FinalizarVenta(False, args)
            End If
            If Not args.Cancel Then
                lastPosition = -1
                Entity2Controls()
                OnCurrentEntityChanged(Me, EventArgs.Empty)
            End If
        Catch ex As EntitiesValidationException
            ShowErrors(ex.InvalidEntities)
        Catch ex As ORMEntityValidationException
            CurrentEntity.SetEntityError(ex.Message)
            ShowErrors(CurrentEntity)
        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If lastPosition >= 0 Then
                BindingSource.RemoveAt(BindingSource.Count - 1)
                BindingSource.Position = lastPosition
            End If
            ParentForm.Enabled = True
            CursorManager.Default()
        End Try

    End Sub

    Public Sub ImprimirFacturas(facturas As EntityCollection(Of DocumentoSalidaEntity))

        Try
            CursorManager.WaitCursor()


            For Each factura As DocumentoSalidaEntity In facturas

                Dim receta As DV_RecetaComunEntity = TryCast(factura, DV_RecetaComunEntity)

                If receta IsNot Nothing Then
                    If Not receta.Facturada Then
                        ShowMsgBox("La receta no fue facturada, debe facturarla antes de poder reimprimir.", MsgBoxStyle.Exclamation)
                        Return
                    End If
                    factura = DocumentoSalidaController.BuscarFacturaDeOrden(receta.Id, receta.CajaId)
                    If factura Is Nothing Then
                        ShowMsgBox("No se encontró la factura para la receta especificada.", MsgBoxStyle.Exclamation)
                        Return
                    End If
                End If

                If Not factura.Imprimible Then
                    ShowMsgBox("Este tipo de receta no permite inmprimir la factura.", MsgBoxStyle.Exclamation)
                    Return
                End If

                'Dim factura As DocumentoSalidaEntity = DocumentoSalidaController.BuscarFacturaDeOrden(receta.Id, receta.CajaId)
                'For Each unDocumentoSalidaEntity As DocumentoSalidaEntity In documentoSalidaCollection
                If Caja_DocumentoTipoController.DocumentoImprimible(factura.DocumentoTipoId, factura.CajaId) Then
                    Dim documento As DocumentoSalidaEntity = DocumentoSalidaController.CrearDocumentoSalidaParaImpresion(factura.Id, factura.CajaId)
                    Dim report As New Studio.Phone.POS.BLL.Printing.DynamicReport
                    report.Proceso(documento)
                    'Dim unFacturaImpresion As IImprimirFactura = ImprimirFacturaFactory.Create()
                    'unFacturaImpresion.Proceso(documento)
                End If
            Next
        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            CursorManager.Default()
        End Try

    End Sub

    Public Sub ImprimirDocumentos(ByVal documentoSalidaCollection As IEntityCollection2)

        Try
            CursorManager.WaitCursor()
            _parent.ShowWaitForm("Imprimiendo...")
            For Each unDocumentoSalidaEntity As DocumentoSalidaEntity In documentoSalidaCollection
                Dim report As New Studio.Phone.POS.Reporting.DynamicReport()
                report.Print(unDocumentoSalidaEntity)
            Next
        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            _parent.CloseWaitForm()
            CursorManager.Default()
        End Try

    End Sub

    Public Sub ImprimirDocumento(ByVal documento As DocumentoSalidaEntity)
        ImprimirDocumentos(New EntityCollection(Of DocumentoSalidaEntity)(New DocumentoSalidaEntity() {documento}))
    End Sub

    Public Sub ImprimirFactura(factura As DocumentoSalidaEntity)
        ImprimirFacturas(New EntityCollection(Of DocumentoSalidaEntity)(New DocumentoSalidaEntity() {factura}))
    End Sub

    Public Function FacturarRecetaActiva(fechaEmision As Date, numeroDocumento As String) As Boolean

        Dim manual As Boolean = Not String.IsNullOrEmpty(numeroDocumento)

        Try
            Dim receta As DV_RecetaComunEntity = GetCurrentEntity(Of DV_RecetaComunEntity)()
            If DV_RecetaBEntity.RecetaFacturada(receta.CajaId, receta.Id) Then
                MyMsgBox.Show("La receta ya fue facturada.", MsgBoxStyle.Exclamation)
                Return False
            End If

            If receta IsNot Nothing Then
                'If ShowMsgBox("¿Seguro que desea facturar la receta?" & IIf(manual, String.Empty, vbCrLf & "Verifique que las boletas estén colocadas en la impresora."), MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                CursorManager.WaitCursor()
                If EntityToEdit.VentaTipo = RecetaVentaTipo.Contado Then
                    InicializarPagoContado(fechaEmision, numeroDocumento)
                Else

                    For Each factura As DocumentoSalidaEntity In DV_RecetaComunBEntity.Facturar(CajaId, receta, Nothing, fechaEmision, numeroDocumento)
                        If Not manual Then
                            ImprimirFactura(factura)
                        End If
                    Next

                End If

                Entity2Controls()
                OnCurrentEntityChanged(Me, EventArgs.Empty)
                Return True
            End If
            'End If

            'OnCurrentItemChanged(Me, EventArgs.Empty)

        Catch ex As Exception

            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)

        Finally
            Me.Refetch()
            CursorManager.Default()
        End Try

        Return False
    End Function

    Public Function FacturarRecetaActiva() As Boolean
        Return FacturarRecetaActiva(System.DateTime.MinValue, Nothing)
    End Function
    Friend Function CalcularImporteUnitario(ByVal articulo As ArticuloEntity, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As Decimal

        Dim cristal As DV_CristalEntity = TryCast(articulo, DV_CristalEntity)
        If cristal IsNot Nothing Then
            If cristal.ArticuloIdGuia = 0 Then
                Return DV_Cristal_PrecioGraduacionBEntity.CalularPrecioUnitarioDeArticulo(articulo.Id, CInt(cboListaPreVtaId.EditValue), CInt(cboMonedaId.EditValue), esferico, cilindrico, adicion)
            End If
        End If
        Return ListaPreVtaLinController.CalularPrecioUnitarioDeArticulo(articulo.Id, Decimal.One, CInt(cboListaPreVtaId.EditValue), CInt(cboMonedaId.EditValue))
    End Function

    Friend Sub AgregarADetalle(coltoAdd As Studio.Phone.POS.DAL.HelperClasses.EntityCollection(Of DocSalidaDetalleEntity), articulo As ArticuloEntity, datoExtra As String, cantidad As Decimal, Optional cilindrico As Decimal = Decimal.MinValue, Optional esferico As Decimal = Decimal.MinValue, Optional adicion As Decimal = Decimal.MinValue, Optional descripcionOverride As String = Nothing, Optional importeDiferencial As Nullable(Of Decimal) = Nothing)

        Dim detalle As DocSalidaDetalleEntity
        Dim importe As Decimal = Decimal.Zero
        If importeDiferencial IsNot Nothing Then
            importe = importeDiferencial.Value
        Else
            importe = CalcularImporteUnitario(articulo, esferico, cilindrico, adicion)
        End If

        Dim descripcion As String = descripcionOverride
        If String.IsNullOrEmpty(descripcion) Then
            descripcion = articulo.DescripcionFull
        End If

        'If esferico > Decimal.MinValue AndAlso cilindrico > Decimal.MinValue Then
        detalle = coltoAdd.Where(Function(f) f.ArticuloId = articulo.Id And f.ImporteUnitario = importe And f.DatoExtra = datoExtra And f.Descripcion = descripcion).SingleOrDefault()
        'Else
        'detalle = coltoAdd.Where(Function(f) f.ArticuloId = articulo.Id).SingleOrDefault()
        'End If

        If detalle Is Nothing Then
            detalle = New DocSalidaDetalleEntity With {.ArticuloId = articulo.Id, .Descripcion = descripcion,
                                                            .Cantidad = cantidad, .ImporteUnitario = importe, .Importe = .ImporteUnitario * .Cantidad, .ListaPreVtaId = CInt(cboListaPreVtaId.EditValue),
                                                            .Numero = coltoAdd.Count + 1, .Articulo = articulo, .DatoExtra = datoExtra}
            coltoAdd.Add(detalle)
        Else
            detalle.Cantidad += cantidad
            detalle.Importe = Decimal.Round(detalle.Cantidad * detalle.ImporteUnitario, 2)
        End If
        Dim i As Integer = coltoAdd.IndexOf(detalle)
        With GetCurrentEntity(Of DV_RecetaEntity)()
            If i < .Detalles.Count Then
                If detalle.ArticuloId = .Detalles(i).ArticuloId AndAlso .Detalles(i).BonificacionId > 0 Then
                    detalle.BonificacionId = .Detalles(i).BonificacionId
                    detalle.Importe = Decimal.Round(BonificacionController.DescontarBonificacion(detalle.BonificacionId, detalle.ImporteUnitario * detalle.Cantidad), 2)
                End If
            End If
        End With

    End Sub

#End Region

#Region "Propiedades"

    Protected ReadOnly Property EntityToEdit As DV_RecetaComunEntity
        Get
            Return GetCurrentEntity(Of DV_RecetaComunEntity)()
        End Get
    End Property

    Public Property CajaId As Integer

#End Region

#Region "bgWorkerCliente"

    Private Sub bgwCliente_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwCliente.DoWork

        Dim clienteId As Integer = CInt(e.Argument)
        If clienteId > 0 Then
            e.Result = ClienteController.GetSaldo(clienteId)
        End If

    End Sub

    Private Sub bgwCliente_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwCliente.RunWorkerCompleted

        Dim saldo As Decimal = CType(e.Result, Decimal)

        If saldo > Decimal.Zero Then
            DxErrorProvider1.SetError(cboClienteId, "El cliente mantiene saldo pendiente por boletas impagas.", DXErrorProvider.ErrorType.Information)
        Else
            DxErrorProvider1.SetErrorType(cboClienteId, DXErrorProvider.ErrorType.None)
        End If

        CargarDatosCliente(CInt(cboClienteId.EditValue))

    End Sub


#End Region

#Region "gvItems"

    Private Sub grvItems_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gvItems.ValidateRow
        Dim detalle As DocSalidaDetalleEntity = DirectCast(e.Row, DocSalidaDetalleEntity)
        If detalle.BonificacionId > 0 Then
            detalle.Importe = Decimal.Round(BonificacionController.DescontarBonificacion(detalle.BonificacionId, detalle.ImporteUnitario * detalle.Cantidad), 2)
        Else
            detalle.Importe = Decimal.Round(detalle.ImporteUnitario * detalle.Cantidad, 2)
        End If

    End Sub

    Private Sub grvItems_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvItems.CellValueChanged

        gvItems.PostEditor()
        gvItems.UpdateCurrentRow()

    End Sub

    Private Sub grvItems_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles gvItems.RowUpdated
        RefrescarTotal()
    End Sub

    Private Sub grvItems_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gvItems.ShowingEditor

        Dim detalle As DocSalidaDetalleEntity = DirectCast(gvItems.GetFocusedRow(), DocSalidaDetalleEntity)

        gvItems.ClearColumnErrors()
        Dim view As GridView = DirectCast(sender, GridView)

        If detalle IsNot Nothing Then
            If view.FocusedColumn Is gColBonificacion Then
                e.Cancel = Not Articulo_LocalController.ArticuloBonificable(GetLocalId(), detalle.ArticuloId)
            Else
                If view.FocusedColumn Is gColUnitario Then
                    e.Cancel = Not PtkOperacionBEntity.TienePermiso(PermisoOperacion.EditarPrecioRecetas) AndAlso Not ArticuloController.ArticuloEsOverrides(DirectCast(view.GetFocusedRow, DocSalidaDetalleEntity).ArticuloId)
                End If
            End If


        End If

    End Sub

    Private Sub txtConvenioImporte_Validating(sender As Object, e As CancelEventArgs) Handles txtConvenioImporte.Validating

        Dim importe As Decimal = Decimal.Zero

        If Decimal.TryParse(txtConvenioImporte.Text, importe) Then
            Dim totalInfo As TotalDetalleInfo = TotalDetalle()
            If importe > totalInfo.Total Then
                e.Cancel = True
                MyMsgBox.Show("El importe del convenio no puede ser mayor al importe de la factura.")
            End If
        End If
    End Sub



#End Region

End Class

