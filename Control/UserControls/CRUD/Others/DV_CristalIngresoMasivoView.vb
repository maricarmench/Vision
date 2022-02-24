Imports Studio.Phone.DAL
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.BLL
Imports DevExpress.XtraGrid.Views.Grid
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Vision.BLL.Business
Imports Studio.Net.Helper
Imports Studio.Net.Controls.[New]
Imports Studio.Vision.BLL
Imports System.Linq
Imports Studio.Net.BLL
Imports DevExpress.XtraGrid

Public Class DV_CristalIngresoMasivoView

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _parametroTree = DirectCast(ParametroSistemaController.GetParametroTree(), VisionParametroTree)

    End Sub

    Public Sub New(documento As DocumentoEntradaEntity)

        Me.New()
        _entityToEdit = documento.DeepClone()
        _entityToEdit.Detalles.Clear()
        _localId = LocalController.BuscarLocalIdFromDeposito(_entityToEdit.DepositoId)

    End Sub

    Protected Overridable Sub ConfigDbg()

        Try

            With gvDetalle

                .OptionsBehavior.AutoExpandAllGroups = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
                .OptionsBehavior.Editable = False
                .OptionsBehavior.FocusLeaveOnTab = False

                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowColumnResizing = True
                .OptionsCustomization.AllowFilter = False
                .OptionsCustomization.AllowGroup = False
                .OptionsCustomization.AllowQuickHideColumns = False
                .OptionsDetail.EnableMasterViewMode = False
                '.OptionsView.ColumnAutoWidth = True
                .OptionsView.NewItemRowPosition = NewItemRowPosition.None
                .OptionsView.ShowGroupPanel = False
                '.OptionsNavigation.AutoFocusNewRow = True
                .OptionsNavigation.EnterMoveNextColumn = True
                .OptionsNavigation.UseTabKey = True

                .BusinessEntity = New tmp_DocSalidaDetalleBEntity
                .BindGridFromBusiness()

            End With

            With gvDetalle.Columns

                .Item(Tmp_DocSalidaDetalleFieldIndex.ArticuloCodigo.ToString()).VisibleIndex = 0
                .Item(Tmp_DocSalidaDetalleFieldIndex.Descripcion.ToString()).VisibleIndex = 1
                .Item(Tmp_DocSalidaDetalleFieldIndex.Cantidad.ToString()).VisibleIndex = 2
                .Item(Tmp_DocSalidaDetalleFieldIndex.ImporteUnitario.ToString()).VisibleIndex = 3
                .Item(Tmp_DocSalidaDetalleFieldIndex.BonificacionId.ToString()).VisibleIndex = 4
                .Item(Tmp_DocSalidaDetalleFieldIndex.DatoExtra.ToString()).VisibleIndex = 5
                .Item(Tmp_DocSalidaDetalleFieldIndex.ArticuloCodigo.ToString()).MinWidth = 57
                .Item(Tmp_DocSalidaDetalleFieldIndex.ArticuloCodigo.ToString()).MaxWidth = 57
                .Item(Tmp_DocSalidaDetalleFieldIndex.Cantidad.ToString()).MinWidth = 55
                .Item(Tmp_DocSalidaDetalleFieldIndex.Cantidad.ToString()).MaxWidth = 55
                .Item(Tmp_DocSalidaDetalleFieldIndex.Importe.ToString()).MinWidth = 150
                .Item(Tmp_DocSalidaDetalleFieldIndex.Importe.ToString()).MaxWidth = 150
                .Item(Tmp_DocSalidaDetalleFieldIndex.ImporteUnitario.ToString()).MinWidth = 79
                .Item(Tmp_DocSalidaDetalleFieldIndex.ImporteUnitario.ToString()).MaxWidth = 79
                .Item(Tmp_DocSalidaDetalleFieldIndex.DatoExtra.ToString()).MinWidth = 123
                .Item(Tmp_DocSalidaDetalleFieldIndex.DatoExtra.ToString()).MaxWidth = 143
                .Item(Tmp_DocSalidaDetalleFieldIndex.BonificacionId.ToString()).MinWidth = 69
                .Item(Tmp_DocSalidaDetalleFieldIndex.BonificacionId.ToString()).MaxWidth = 69

                .Item(Tmp_DocSalidaDetalleFieldIndex.Importe.ToString()).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .Item(Tmp_DocSalidaDetalleFieldIndex.ImporteUnitario.ToString()).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                .Item(Tmp_DocSalidaDetalleFieldIndex.Cantidad.ToString()).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .Item(Tmp_DocSalidaDetalleFieldIndex.Cantidad.ToString()).DisplayFormat.FormatString = "{0:n3}"
                .Item(Tmp_DocSalidaDetalleFieldIndex.ImporteUnitario.ToString()).DisplayFormat.FormatString = "{0:n2}"
                .Item(Tmp_DocSalidaDetalleFieldIndex.Importe.ToString()).DisplayFormat.FormatString = "{0:n2}"
                Dim sumItem As GridColumnSummaryItem = .Item(Tmp_DocSalidaDetalleFieldIndex.Importe.ToString()).Summary.Add(DevExpress.Data.SummaryItemType.Sum, Tmp_DocSalidaDetalleFieldIndex.Importe.ToString(), "TOTAL={0:n2}")


                .Item(Tmp_DocSalidaDetalleFieldIndex.DatoExtra.ToString()).ColumnEdit = Nothing


            End With
            With gvDetalle
                .OptionsView.ShowFooter = True
            End With
            grdDetalle.DataSource = EntityToEdit.Detalles

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private _entityToEdit As DocumentoEntradaEntity
    Public ReadOnly Property EntityToEdit As DocumentoEntradaEntity
        Get
            Return _entityToEdit
        End Get
    End Property

    Private _cercaEsSegundoPar As Boolean

    Private Sub OnGetQueryableCristal(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

        Dim da As IDataAccessAdapter = Nothing

        If (txtCilindrico.Text <> String.Empty AndAlso txtEsferico.Text <> String.Empty) Then
            e.QueryableSource = (DV_CristalBEntity.GetQueryableForReceta(da, NumberConversor.ParseDecimal(txtCilindrico.Text), NumberConversor.ParseDecimal(txtCilindrico.Text), _
                                                    NumberConversor.ParseDecimal(txtEsferico.Text), NumberConversor.ParseDecimal(txtEsferico.Text), _
                                                    NumberConversor.ParseDecimal(txtAdicion.Text), NumberConversor.ParseDecimal(txtAdicion.Text), _
                                                    EntityToEdit.ListaPreVtaId, _
                                                    CInt(cboCristalMaterialId.EditValue), _
                                                    CInt(rgrRecetaComunTipo.EditValue), _
                                                    _parametroTree))
        Else
            e.QueryableSource = Nothing
        End If

        e.Tag = da

    End Sub

    Private Sub OnDismissQueryableCristal(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

        Dim da As IDataAccessAdapter = TryCast(e.Tag, IDataAccessAdapter)
        If da IsNot Nothing Then
            da.Dispose()
        End If
        e.Tag = Nothing

    End Sub

    Private _parametroTree As VisionParametroTree
    Private _localId As Integer
    'Private _parametroCaja As ParametroCaja

    Private Function DatosOk() As Boolean

        DxErrorProvider1.ClearErrors()

        If Not rgrRecetaComunTipo.HasValue() Then
            DxErrorProvider1.SetError(rgrRecetaComunTipo, "El tipo de receta es requerido")
        End If
        If Not cboCristalMaterialId.HasValue() Then
            DxErrorProvider1.SetError(cboCristalMaterialId, "El material es requerido")
        End If
        If Not cboCristalId.HasValue() Then
            DxErrorProvider1.SetError(cboCristalId, "El cristal es requerido")
        End If
        If txtEsferico.Text = String.Empty Then
            DxErrorProvider1.SetError(txtEsferico, "Debe ingresar el valor del esférico.")
        End If
        If txtCilindrico.Text = String.Empty Then
            DxErrorProvider1.SetError(txtCilindrico, "Debe ingresar el valor del cilíndrico.")
        End If
        If Not NumberConversor.ParseDecimal(txtCantidad.Text) > Decimal.Zero Then
            DxErrorProvider1.SetError(txtCantidad, "La cantidad debe ser mayor a cero.")
        End If
        If cboBonificacionId.HasValue AndAlso Not Articulo_LocalController.ArticuloBonificable(_localId, CInt(cboCristalId.EditValue)) Then
            DxErrorProvider1.SetError(cboBonificacionId, String.Format("El artículo no es bonificable. Para poder cargarle una bonificación debe marcarlo como bonificable en el local {0} - {1}", _localId, LocalController.DescripcionFromId(Nothing, _localId)))
        End If
        Return Not DxErrorProvider1.HasErrors

    End Function

    Private Sub rgrRecetaComunTipo_EditValueChanged(sender As Object, e As System.EventArgs) Handles rgrRecetaComunTipo.EditValueChanged
        _cercaEsSegundoPar = DV_RecetaTipoBEntity.TipoEsSegundoPar(CInt(rgrRecetaComunTipo.EditValue))
        txtAdicion.Enabled = Not _cercaEsSegundoPar
        'cboCristalId.RefresDataSource()
    End Sub

    Private Sub datosEditables_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtCilindrico.EditValueChanged, txtEsferico.EditValueChanged, txtAdicion.EditValueChanged, cboCristalMaterialId.EditValueChanged, rgrRecetaComunTipo.EditValueChanged
        cboCristalId.RefreshDataSource()
    End Sub

    Private Sub ConfigControls()

        Dim business As DV_RecetaComunBEntity = DV_RecetaComunBEntity.CrearParaMantenimiento()

        With business

            .Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaDerecho.ToString()).DisplayControl = txtCilindrico
            .Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaDerecho.ToString()).DisplayControl = txtEsferico
            .Fields(DV_RecetaComunFieldIndex.AdicionOjoLejosDerecho.ToString()).DisplayControl = txtAdicion
            .Fields(DV_RecetaComunFieldIndex.CristalMaterialIdLejosDerecho.ToString()).DisplayControl = cboCristalMaterialId
            .Fields(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString()).DisplayControl = cboCristalId
            .Fields(DV_RecetaComunFieldIndex.RecetaComunTipo.ToString()).DisplayControl = rgrRecetaComunTipo


            'Dim source As MyLinqInstantFeedbackSource = New MyLinqInstantFeedbackSource(.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdLejos.ToString()).ForeignBEntity)
            'Me.components.Add(source)
            'cboCristalMaterialId.Properties.DataSource = source


            Dim source As MyLinqInstantFeedbackSource = New MyLinqInstantFeedbackSource(.Fields(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString()).ForeignBEntity)
            Me.components.Add(source)
            cboCristalId.Properties.DataSource = source

            BindingControlHelper.setControlProperties(.Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaDerecho.ToString()), True)
            BindingControlHelper.setControlProperties(.Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaDerecho.ToString()), True)
            BindingControlHelper.setControlProperties(.Fields(DV_RecetaComunFieldIndex.AdicionOjoLejosDerecho.ToString()), True)
            BindingControlHelper.setControlProperties(.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdLejosDerecho.ToString()), True)
            BindingControlHelper.setControlProperties(.Fields(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString()), True)
            BindingControlHelper.setControlProperties(.Fields(DV_RecetaComunFieldIndex.RecetaComunTipo.ToString()), True)


            AddHandler source.GetQueryable, AddressOf OnGetQueryableCristal
            AddHandler source.DismissQueryable, AddressOf OnDismissQueryableCristal

            .Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaDerecho.ToString()).DisplayControl = Nothing
            .Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaDerecho.ToString()).DisplayControl = Nothing
            .Fields(DV_RecetaComunFieldIndex.AdicionOjoLejosDerecho.ToString()).DisplayControl = Nothing
            .Fields(DV_RecetaComunFieldIndex.CristalMaterialIdLejosDerecho.ToString()).DisplayControl = Nothing
            .Fields(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString()).DisplayControl = Nothing
            .Fields(DV_RecetaComunFieldIndex.RecetaComunTipo.ToString()).DisplayControl = Nothing
        End With

    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click

        Try

            CursorManager.WaitCursor()

            If Not DatosOk() Then
                Return
            End If

            AgregarArticulos(CInt(cboCristalId.EditValue))
            LimpiarControles()
            Me.ActiveControl = txtCilindrico


        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            CursorManager.Default()
        End Try

    End Sub

    Private Sub AgregarRenglon()

        Dim toAdd As New docentradadetalleentity

        With toAdd

            .ArticuloId = CInt(cboCristalId.EditValue)
            .ArticuloCodigo = .ArticuloId.ToString()
            .Descripcion = ArticuloController.DescripcionFromId(.ArticuloId)
            .Cantidad = NumberConversor.ParseDecimal(txtCantidad.Text)
            .ImporteUnitario = DV_Cristal_Local_Proveedor_PrecioGraduacionBEntity.CalcularPrecioUnitarioDeArticulo(toAdd)

        End With

        EntityToEdit.Detalles.Add(toAdd)

        LimpiarControles()

    End Sub

    Public Overrides Sub DisposeDataView()

        With DirectCast(cboCristalId.Properties.DataSource, MyLinqInstantFeedbackSource)
            RemoveHandler .GetQueryable, AddressOf OnGetQueryableCristal
            RemoveHandler .DismissQueryable, AddressOf OnDismissQueryableCristal
        End With
        RemoveHandler FindForm().KeyDown, AddressOf OnParent_KeyDown

        MyBase.DisposeDataView()

    End Sub

    Private Sub LimpiarControles()

        txtAdicion.EditValue = Nothing
        txtEsferico.EditValue = Decimal.Zero
        txtCantidad.EditValue = Decimal.One
        txtCilindrico.EditValue = Decimal.Zero
        cboCristalId.EditValue = Nothing
        cboBonificacionId.EditValue = Nothing

        If _parametroCaja IsNot Nothing Then
            rgrRecetaComunTipo.EditValue = _parametroCaja.TipoReceta
            cboCristalMaterialId.EditValue = _parametroCaja.CristalMaterialId
        End If

    End Sub

    Protected Overrides Sub OnLoad(e As System.EventArgs)
        ConfigDbg()
        ConfigControls()
        LimpiarControles()
        MyBase.OnLoad(e)
        FindForm().KeyPreview = True
        AddHandler FindForm().KeyDown, AddressOf OnParent_KeyDown

    End Sub


    Private Sub AgregarArticulos(cristalId As Integer)

        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

            Dim cantCristales As Integer = Decimal.Zero
            Dim cristal As DV_CristalEntity = DV_CristalBEntity.GetByIdForReceta(da, cristalId)
            If cristal.GuiaDeVariante Then

                Dim articulosCtrlStock As New List(Of ArticuloEntity)

                Dim articulo As ArticuloEntity = DV_CristalBEntity.BuscarPorGraduacion(da, cristal.Id, NumberConversor.ParseDecimal(txtEsferico.Text), _
                                        IIf(_cercaEsSegundoPar, NumberConversor.ParseDecimal(txtCilindrico.Text), NumberConversor.ParseDecimal(txtAdicion.Text)), _
                                        _parametroTree.Optica.AAtributoPlantillaIDCristalesEsferico, IIf(_cercaEsSegundoPar, _
                                        _parametroTree.Optica.AAtributoPlantillaIDCristalesCilindrico, _parametroTree.Optica.AAtributoPlantillaIDCristalesAdicion))

                If articulo IsNot Nothing Then
                    AgregarADetalle(EntityToEdit.Detalles, articulo, String.Empty, cantidad:=txtCantidad.EditValue, bonificacionId:=CInt(cboBonificacionId.EditValue))
                    articulosCtrlStock.Add(articulo)
                    cantCristales = Decimal.One
                End If
            Else

                AgregarADetalle(EntityToEdit.Detalles, cristal, String.Empty, cantidad:=NumberConversor.ParseDecimal(txtCantidad.Text), cilindrico:=NumberConversor.ParseDecimal(txtCilindrico.Text), _
                                esferico:=NumberConversor.ParseDecimal(txtEsferico.Text), adicion:=NumberConversor.ParseDecimal(txtAdicion.Text), descripcionOverride:=String.Format("{0} c{1:00.00} e{2:00.00}", cristal.DescripcionFull, txtCilindrico.EditValue, txtEsferico.EditValue), bonificacionId:=CInt(cboBonificacionId.EditValue))
            End If

        End Using

        gvDetalle.RefreshData()

    End Sub

    Private Sub AgregarADetalle(coltoAdd As Studio.Phone.DAL.HelperClasses.EntityCollection(Of DocEntradaDetalleEntity), articulo As ArticuloEntity, datoExtra As String, Optional cantidad As Decimal = Decimal.One, Optional cilindrico As Decimal = Decimal.MinValue, Optional esferico As Decimal = Decimal.MinValue, Optional adicion As Decimal = Decimal.MinValue, Optional descripcionOverride As String = Nothing, Optional bonificacionId As Integer = 0)

        Dim descripcion As String = descripcionOverride
        If String.IsNullOrEmpty(descripcion) Then
            descripcion = articulo.DescripcionFull
        End If

        'If esferico > Decimal.MinValue AndAlso cilindrico > Decimal.MinValue Then

        Dim detalle As docentradadetalleentity

        Dim importe As Decimal = CalcularImporteUnitario(articulo, _entityToEdit.FechaEmitida, esferico, cilindrico, adicion)

        detalle = coltoAdd.Where(Function(f) f.ArticuloId = articulo.Id And f.ImporteUnitario = importe And f.DatoExtra = datoExtra And f.Descripcion = descripcion).SingleOrDefault()

        If detalle Is Nothing Then
            detalle = New docentradadetalleentity With {.ArticuloId = articulo.Id, .ArticuloCodigo = articulo.Id.ToString(), .Descripcion = descripcion, _
                                                        .Cantidad = cantidad, .ImporteUnitario = importe, .Importe = .ImporteUnitario * .Cantidad, .ListaPreVtaId = EntityToEdit.ListaPreVtaId, _
                                                        .Numero = coltoAdd.Count + 1, .Articulo = articulo, .DatoExtra = datoExtra}
            coltoAdd.Add(detalle)
        Else
            detalle.Cantidad += cantidad
            detalle.Importe = detalle.Cantidad * detalle.ImporteUnitario
        End If
        If bonificacionId > 0 Then
            detalle.BonificacionId = bonificacionId
            detalle.Importe = BonificacionController.DescontarBonificacion(bonificacionId, detalle.Importe)
        End If

    End Sub

    Friend Function CalcularImporteUnitario(ByVal articulo As ArticuloEntity, fecha As Date, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As Decimal

        Dim cristal As DV_CristalEntity = TryCast(articulo, DV_CristalEntity)
        If cristal IsNot Nothing Then
            If cristal.ArticuloIdGuia = 0 Then
                Return DV_Cristal_PrecioGraduacionBEntity.CalularPrecioUnitarioDeArticulo(articulo.Id, fecha, EntityToEdit.ListaPreVtaId, EntityToEdit.MonedaId, esferico, cilindrico, adicion)
            End If
        End If
        Return ListaPreVtaLinController.CalularPrecioUnitarioDeArticulo(articulo.Id, Decimal.One, EntityToEdit.ListaPreVtaId, EntityToEdit.MonedaId)
    End Function


    Private Sub cboCristalId_GotFocus(sender As Object, e As EventArgs) Handles cboCristalId.GotFocus

        If _parametroTree.Optica.ManejoCilindrico = ManejoCilindricos.SoloNegativo Then

            Dim cilindrico As Decimal = txtCilindrico.EditValue
            If cilindrico > Decimal.Zero Then
                txtCilindrico.EditValue = cilindrico * Decimal.MinusOne
                txtEsferico.EditValue += cilindrico
            End If

        ElseIf _parametroTree.Optica.ManejoCilindrico = ManejoCilindricos.SoloPositivo Then

            Dim cilindrico As Decimal = txtCilindrico.EditValue
            If cilindrico < Decimal.Zero Then
                txtCilindrico.EditValue = cilindrico * Decimal.MinusOne
                txtEsferico.EditValue += cilindrico
            End If

        End If

    End Sub

    Private Sub gvDetalle_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles gvDetalle.CustomDrawFooterCell
        e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
    End Sub


    Private Sub OnParent_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            SendKeys.SendWait("{TAB}")
        End If

    End Sub

    Private Sub lqifsBonificacion_DismissQueryable(sender As Object, e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles lqifsBonificacion.DismissQueryable
        Dim da As IDataAccessAdapter = TryCast(e.Tag, IDataAccessAdapter)
        If da IsNot Nothing Then
            da.Dispose()
        End If
        e.Tag = Nothing
    End Sub

    Private Sub lqifsBonificacion_GetQueryable(sender As Object, e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles lqifsBonificacion.GetQueryable
        Dim da As IDataAccessAdapter
        e.QueryableSource = (New BonificacionBEntity).GetDataForComboAsQueryable(da, _localId)
        e.Tag = da
    End Sub

End Class
