Imports Studio.Phone.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Net.Controls.[New]
Imports Studio.Net.Helper
Imports DevExpress.Data.Filtering
Imports Studio.Net.BLL
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL
Imports Studio.Net.Controls.New.Forms
Imports System.ComponentModel
Imports Studio.Vision.BLL.Business

Public Class DV_HistoricoRecetaComunTaskPanel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFechaEmisionDesde.EditValue = System.DateTime.Today
        txtFechaEmisionHasta.EditValue = System.DateTime.Today
        RibbonControl1.SelectedPage = rpInicio

    End Sub


    Private Sub btnCargarDatos_Click(sender As System.Object, e As System.EventArgs) Handles btnCargarDatos.Click
        Try
            System.Windows.Forms.Application.DoEvents()
            CursorManager.WaitCursor()

            AsignarFiltroPorPantalla()
            'ListViewToUse.UserFilter = DocSalidaDetalle_ComisionController.CrearFiltroParaListadoComisiones(GetComisionesInfo())

            LoadData()
            popUpFiltroContainer.FindForm().Close()
        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            CursorManager.Default()
        End Try
    End Sub

    Private Sub ConfigParametros()

        lqsmsEmpresa.QueryableSource = (New EmpresaBEntity).GetDataForComboAsQueryable()
        lqsmsFuncionario.QueryableSource = (New FuncionarioBEntity).GetDataForComboAsQueryable()
        lqsmsArticuloClase.QueryableSource = (New ArticuloClaseBEntity).GetDataForComboAsQueryable()
        lqsmsRubro.QueryableSource = (New RubroBEntity).GetDataForComboAsQueryable()
        'lqsmsDocumentoTipo.QueryableSource = (New DocumentoTipoBEntity).GetDataForComboAsQueryable()
        lqsmsMoneda.QueryableSource = (New MonedaBEntity).GetDataForComboAsQueryable()
        ConfigParameter((New Articulo_LocalBEntity).Fields(Articulo_LocalFieldIndex.ArticuloId.ToString()), cboArticuloId)
        ConfigParameter((New DocumentoSalidaBEntity).Fields(DocumentoSalidaFieldIndex.ClienteId.ToString()), cboClienteId, "GetDataForComboAsQueryableActivos")
        cboDocumentoTipoId.BindFromBusiness(New DocumentoTipoBEntity)

    End Sub

    Private Sub cboEmpresa_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboEmpresaId.EditValueChanged
        lqsmsLocal.QueryableSource = LocalController.GetQueryableExpressionPorEmpresa(GetEmpresaId())
        cboLocalId.EditValue = Nothing
        cboCajaId.EditValue = Nothing
        cboLocalId.RefresDataSource()
    End Sub

    Private Function GetEmpresaId() As Integer
        Return CType(cboEmpresaId.EditValue, Integer)
    End Function

    Private Function GetLocalId() As Integer
        Return CType(cboLocalId.EditValue, Integer)
    End Function

    Private Function GetCajaId() As Integer
        Return CType(cboCajaId.EditValue, Integer)
    End Function

    Private Function GetFuncionarioId() As Integer
        Return CType(cboFuncionarioId.EditValue, Integer)
    End Function

    Protected Overrides Sub OnLoad(e As System.EventArgs)

        MyBase.OnLoad(e)
        ConfigParametros()
        OnSetSecurity()

    End Sub


    Protected Overrides Function GetListviewGridLayoutName() As String
        Return Me.GetType().Name
    End Function


    Private ReadOnly Property FechaEmitidaFieldName() As String
        Get
            Return String.Format("{0}", DocumentoSalidaFieldIndex.FechaEmitida.ToString())
        End Get
    End Property

    Private Sub AsignarFiltroPorPantalla()

        Dim criteria As New GroupOperator
        Dim fields As New List(Of FilterFieldInfo)
        Dim root As New DV_RecetaComunEntity

        Dim fInfo As FilterFieldInfo
        If cboArticuloId.HasValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("Detalles.{0}", DocSalidaDetalleFieldIndex.ArticuloId.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, CType(cboArticuloId.EditValue, Integer)))
            fields.Add(fInfo)
        End If

        If cboArticuloClaseId.HasValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("Detalles.Articulo.{0}", ArticuloFieldIndex.ArticuloClaseId.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, CType(cboArticuloClaseId.EditValue, Integer)))
            fields.Add(fInfo)
        End If

        If cboRubroId.HasValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("Detalles.Articulo.{0}", ArticuloFieldIndex.RubroId.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, CType(cboRubroId.EditValue, Integer)))
            fields.Add(fInfo)
        End If

        If cboNivelId.EditValue IsNot Nothing Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("Detalles.Articulo.{0}", ArticuloFieldIndex.NivelId.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, cboNivelId.EditValue.ToString() & "%", BinaryOperatorType.Like))
            fields.Add(fInfo)
        End If

        If cboEmpresaId.HasValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("Caja.Local.{0}", LocalFieldIndex.EmpresaId.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, CType(cboEmpresaId.EditValue, Integer)))
            fields.Add(fInfo)
        End If

        If cboLocalId.HasValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("Caja.{0}", CajaFieldIndex.LocalId.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, CType(cboLocalId.EditValue, Integer)))
            fields.Add(fInfo)
        End If

        If cboClienteId.HasValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("{0}", DocumentoSalidaFieldIndex.ClienteId.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, CType(cboClienteId.EditValue, Integer)))
            fields.Add(fInfo)
        End If

        If cboCajaId.HasValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("{0}", DocumentoSalidaFieldIndex.CajaId.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, CType(cboCajaId.EditValue, Integer)))
            fields.Add(fInfo)
        End If

        If cboDocumentoTipoId.HasValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("{0}", DocumentoSalidaFieldIndex.DocumentoTipoId.ToString()))
            Dim group As New InOperator(fInfo.PropertyInfo.FullPath, cboDocumentoTipoId.ListOfValues())

            'criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, CType(cboDocumentoTipoId.EditValue, Integer)))
            criteria.Operands.Add(group)
            fields.Add(fInfo)
        End If



        If txtNumeroDocumento.Text <> String.Empty Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("{0}", DocumentoSalidaFieldIndex.NumeroDocumento.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, txtNumeroDocumento.Text))
            fields.Add(fInfo)
        End If

        If cboFuncionarioId.HasValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("{0}", DocumentoSalidaFieldIndex.FuncionarioId.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, cboFuncionarioId.EditValue))
            fields.Add(fInfo)
        End If

        If cboMonedaId.HasValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("{0}", DocumentoSalidaFieldIndex.MonedaId.ToString()))
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, cboMonedaId.EditValue))
            fields.Add(fInfo)
        End If

        If lccPeriodo.Expanded Then

            If txtFechaEmisionDesde.DateTime > System.DateTime.MinValue Then
                fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, FechaEmitidaFieldName)
                criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, txtFechaEmisionDesde.DateTime, BinaryOperatorType.GreaterOrEqual))
                fields.Add(fInfo)

            End If

            If txtFechaEmisionHasta.DateTime > System.DateTime.MinValue Then

                fInfo = fields.FirstOrDefault(Function(f) f.PropertyInfo.FullPath = FechaEmitidaFieldName)
                If fInfo Is Nothing Then
                    fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, FechaEmitidaFieldName)
                    fields.Add(fInfo)
                End If

                criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, txtFechaEmisionHasta.DateTime, BinaryOperatorType.LessOrEqual))

            End If
        End If

        ListViewToUse.DXCriteria = String.Empty
        ListViewToUse.UserFilter = Nothing

        If fields.Count > 0 Then
            ListViewToUse.ApplyFilter(fields, criteria)

        End If



    End Sub

    Private Sub cboLocalId_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboLocalId.EditValueChanged
        lqsmsCaja.QueryableSource = CajaController.GetQueryableExpressionPorLocal(GetLocalId())
        cboCajaId.EditValue = Nothing
        cboCajaId.RefresDataSource()
    End Sub

    Protected Overrides Sub OnRibbonItemClick(item As DevExpress.XtraBars.ItemClickEventArgs)
        If item.Item.Name = bbiVerReceta.Name Then
            OnVerDocumentoClicked()
        Else
            MyBase.OnRibbonItemClick(item)
        End If
    End Sub

    Private Sub OnVerDocumentoClicked()

        If ListViewToUse.MainView.FocusedRowHandle >= 0 Then

            Dim documento As DV_RecetaComunEntity = GetDocumento()
            If documento IsNot Nothing Then
                Studio.Net.Helper.CursorManager.WaitCursor()
                'New DetailViewDialog(DV_RecetaComunBEntity.CrearBusinessParaListView(), GetType(DV_RecetaLenteComunDetailView), documento)
                'Using f As DetailViewDialog = 
                Try
                    Studio.Net.Controls.[New].FormHelper.ShowDetailViewDialog(_parent, GetType(DV_RecetaLenteComunDetailView), DV_RecetaComunBEntity.CrearBusinessParaListView(), documento, False, False, FormWindowState.Maximized)
                    'f.WindowState = FormWindowState.Maximized
                    'f.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                    'f.AllowDelete = False

                    'If f.ShowDialog(FindForm()) = Windows.Forms.DialogResult.OK Then

                    'End If

                Catch ex As Exception
                    MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
                    '    Finally
                    Studio.Net.Helper.CursorManager.Default()
                End Try
                'End Using
            End If
        End If
    End Sub

    Private Function GetDocumento() As DV_RecetaComunEntity

        If ListViewToUse.MainView.FocusedRowHandle >= 0 Then
            Dim documentoSalidaId As Integer = ListViewToUse.MainView.GetFocusedRowCellValue(DocumentoSalidaFieldIndex.Id.ToString())
            Dim cajaId As Integer = ListViewToUse.MainView.GetFocusedRowCellValue(DocumentoSalidaFieldIndex.CajaId.ToString())
            Return TryCast(DocumentoSalidaController.BuscarPorId(documentoSalidaId, cajaId), DV_RecetaComunEntity)
        End If

        Return Nothing
    End Function

    Private Sub OnSetSecurity()

        'bbiEditar.Enabled = PtkOperacionBEntity.TienePermiso(PermisoOperacion.EditarDocumentoSalida)

    End Sub

    Protected Overrides Sub OnListViewAssigned(listViewToUse As UserControls.ListView)
        MyBase.OnListViewAssigned(listViewToUse)
        If listViewToUse IsNot Nothing Then
            AddHandler listViewToUse.MainView.DoubleClick, AddressOf OnListDoubleClick
        End If
    End Sub

    Public Overrides Sub DisposeModule()
        MyBase.DisposeModule()
        If ListViewToUse IsNot Nothing Then
            RemoveHandler ListViewToUse.MainView.DoubleClick, AddressOf OnListDoubleClick
        End If
    End Sub

    Private Sub OnListDoubleClick(sender As Object, e As EventArgs)
        If ListViewToUse.MainView.FocusedRowHandle >= 0 Then
            OnVerDocumentoClicked()
        End If

    End Sub

End Class
