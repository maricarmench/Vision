Imports Studio.Net.BLL
Imports Studio.Phone.DAL
Imports Studio.Phone.BLL
Imports Studio.Vision.BLL.Business
Imports Studio.Net.Controls.New
Imports Studio.Net.Helper
Imports Studio.Vision.BLL
Imports Studio.Phone.DAL.EntityClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.Controls.New
Imports Studio.Net.Controls.New.Forms

Public Class DV_HistoricoDocumentoSalidaCristalModule

#Region "Variables de módulo"
    Private _cristales As CristalesMatrixData
    Private _view As CristalMatrixView

#End Region

#Region "Eventos de acción"

    Private Sub btnCargarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarDatos.Click

        Try
            If Not DatosOK() Then
                MyMsgBox.Show("Debe seleccionar el depósito y el artículo.", MsgBoxStyle.OkOnly)
                Return
            End If
            _parent.ShowWaitForm("Cargando aguarde")
            Enabled = False
            CursorManager.WaitCursor()
            _cristales.Cristales.Clear()
            _cristales.Cristales.AddRange(GetMatrixData())
            View.Clear()
            View.LoadData()
            popUpFiltroContainer.FindForm().Close()
        Catch ex As Exception
            _parent.CloseWaitForm()
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            Enabled = True
            _parent.CloseWaitForm()
            CursorManager.Default()
        End Try
    End Sub

#End Region

#Region "Propiedades públicas"

    Private ReadOnly Property View() As CristalMatrixView
        Get
            Return _view
        End Get
    End Property

#End Region

#Region "Export"

    Protected Overrides Sub OnExportToPDFClicked()
        View.ExportToPDF()
    End Sub

    Protected Overrides Sub OnExportToXMLClicked()
    End Sub

    Protected Overrides Sub OnExportToHTMLClicked()
        View.ExportToHTML()
    End Sub

    Protected Overrides Sub OnExportToXLSClicked()
        View.ExportToXLS()
    End Sub

    Protected Overrides Sub OnExportToXLSXClicked()
        View.ExportToXLSX()
    End Sub

    Protected Overrides Sub OnExportToRTFClicked()
        View.ExportToRTF()
    End Sub

#End Region

#Region "Procedimientos Privados"


    Private Sub ShowDetailViewDialog(control As ConsultaMovimientoArticuloTaskPanelModule)

        control.ShowInCategoryView = True
        _parent.ShowModule(control)

        ''Dim pForm As System.Windows.Forms.Form = FindForm()

        'Try
        '    Using f As New DialogForm()
        '        Dim parentForm As MainFormBase = TryCast(FindForm(), MainFormBase)
        '        If parentForm IsNot Nothing Then
        '            f.Location = parentForm.PointToScreen(New System.Drawing.Point(parentForm.xTab.Left, parentForm.panel.Top))
        '            f.Size = parentForm.xTab.Size
        '        Else
        '            f.Location = FindForm().Location()
        '            f.Size = FindForm().Size
        '        End If
        '        f.StartPosition = Windows.Forms.FormStartPosition.Manual
        '        If pForm IsNot Nothing Then
        '            pForm.Enabled = False
        '        End If
        '        f.Text = "Consulta de movimientos"
        '        control.Dock = DockStyle.Fill
        '        f.Controls.Add(control)
        '        control.OnSetActive()
        '        If f.ShowDialog(pForm) = Windows.Forms.DialogResult.OK Then


        '        End If
        '    End Using
        'Catch ex As Exception
        '    MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        'Finally
        '    If pForm IsNot Nothing Then
        '        pForm.Enabled = True
        '    End If
        'End Try
    End Sub

    Private Sub ShowConsultaMovimiento(data As CristalValor)

        'Dim m As New ConsultaMovimientoArticuloTaskPanelModule(data.ArticuloId, CInt(cboDepositoId.EditValue)) With {.ListViewToUse = New ConsultaMovimientoDynamicTabularListView()}
        'm.Caption = "Consulta de movimiento de artículos"

        ''m.ShowInCategoryView = True
        '_parent.ShowModule(m)
        ''ShowDetailViewDialog(m)

    End Sub

    Private Function GetMatrixData() As List(Of CristalData)

        Dim toReturn As New List(Of CristalData)

        'Dim cristal As DV_CristalEntity = DV_CristalBEntity.GetDataForControlStock(GetSelectedCristales(), CInt(cboDepositoId.EditValue))
        For Each cristal As DV_CristalEntity In DV_CristalBEntity.GetDataForVentas(GetSelectedCristales(), txtFechaDesde.DateTime, txtFechaHasta.DateTime)
            Dim cData As New CristalData()
            cData.ArticuloId = cristal.Id
            cData.Descripcion = cristal.Descripcion
            cData.PlantillaId1 = cristal.Plantilla.AAtributoPlantillaID1
            cData.PlantillaId2 = cristal.Plantilla.AAtributoPlantillaID2
            Dim fieldsBuffer As New Dictionary(Of Integer, IEntityField2)
            For Each variante As DV_CristalEntity In cristal.Variantes

                Dim valor As New CristalValor With { _
                                    .ArticuloId = variante.Id, .NoExiste = False, _
                                    .PlantillaValorID1 = variante.CombinacionesDeVariante(0).AAtributoPlantillaValorID, _
                                    .PlantillaValorID2 = variante.CombinacionesDeVariante(1).AAtributoPlantillaValorID}
                If Not fieldsBuffer.ContainsKey(valor.PlantillaValorID1) Then
                    fieldsBuffer.Add(valor.PlantillaValorID1, AAtributoPlantillaValorBEntity.GetFieldFromPlantilla(AAtributoPlantillaBEntity.GetById(variante.CombinacionesDeVariante(0).AAtributoPlantillaID)))
                End If
                If Not fieldsBuffer.ContainsKey(valor.PlantillaValorID2) Then
                    fieldsBuffer.Add(valor.PlantillaValorID2, AAtributoPlantillaValorBEntity.GetFieldFromPlantilla(AAtributoPlantillaBEntity.GetById(variante.CombinacionesDeVariante(1).AAtributoPlantillaID)))
                End If
                valor.PlantillaValor1 = variante.CombinacionesDeVariante(0).ValorDePlantilla.Fields(fieldsBuffer(valor.PlantillaValorID1).Name).CurrentValue
                valor.PlantillaValor2 = variante.CombinacionesDeVariante(1).ValorDePlantilla.Fields(fieldsBuffer(valor.PlantillaValorID2).Name).CurrentValue
                If variante.Ventas.Count > 0 Then
                    valor.Valor = variante.Ventas.Sum(Function(f) f.Cantidad * f.Venta.DocumentoTipo.Signo.Valor)
                End If
                cData.Valores.Add(valor)
            Next
            toReturn.Add(cData)
        Next
        Return toReturn

    End Function

    Private Function DatosOK() As Boolean
        Return True ' cboDepositoId.EditValue IsNot Nothing 'AndAlso chkCristales.Properties.GetCheckedItems()
    End Function

    Private Sub ConfigParametros()

        Dim depArtBs As New Deposito_ArticuloBEntity
        Dim artField As BEField = depArtBs.Fields(Deposito_ArticuloFieldIndex.ArticuloId.ToString())
        Dim depField As BEField = depArtBs.Fields(Deposito_ArticuloFieldIndex.DepositoId.ToString())
        artField.ForeignBEntity = New DV_CristalBEntity

        'ConfigParameter(depField, cboDepositoId, "GetQueryableParaControlStockFull")
        lqsmsCristales.QueryableSource = DV_CristalBEntity.GetQueryableParaControlDeStock(Studio.Net.Helper.DAL.DataAccessAdapter.Create())
        'cboDepositoId.Properties.DisplayMember = "Deposito"
        'cboDepositoId.Properties.ValueMember = DepositoFieldIndex.Id.ToString()

        _cristales = New CristalesMatrixData
        _view = New CristalMatrixView(_cristales) With {.Dock = DockStyle.Fill, .ReadOnlyMode = True}
        PanelControl.Controls.Add(_view)

    End Sub

    Private Sub OnViewCellDoubleClick(sender As Object, e As CristalMatrixCellDoubleClickedEventArgs)
        ShowConsultaMovimiento(e.CellData)
    End Sub

    Private Function GetSelectedCristales() As List(Of Integer)
        Dim valores As String() = chkCristales.Properties.GetCheckedItems().ToString().Split(chkCristales.Properties.SeparatorChar)
        Dim toReturn As New List(Of Integer)
        For Each valor As String In valores
            Dim Id As Integer = 0I
            If Int32.TryParse(valor, Id) Then
                toReturn.Add(Id)
            End If
        Next
        Return toReturn
    End Function
#End Region

#Region "Overrides"

    Public Overrides Function GetFriendlyName() As String
        Return "Consulta de inventario"
    End Function

    Public Overrides Function GetUniqueName() As String
        Return Me.GetType().Name
    End Function

    Protected Overrides Sub OnPreviewClicked()
        View.ShowPreview()
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        'MyBase.OnLoad(e)
        ConfigParametros()
        AddHandler View.CellDoubleClick, AddressOf OnViewCellDoubleClick

    End Sub

    Protected Overrides Sub OnAddPageGroup(ByVal group As DevExpress.XtraBars.Ribbon.RibbonPageGroup, ByVal page As DevExpress.XtraBars.Ribbon.RibbonPage)
        If group Is rpgClose OrElse group Is rpgPrint OrElse group Is rpgCargarDatos Then
            MyBase.OnAddPageGroup(group, page)
        End If

    End Sub

    Public Overrides Sub DisposeModule()
        RemoveHandler View.CellDoubleClick, AddressOf OnViewCellDoubleClick
        MyBase.DisposeModule()
    End Sub

#End Region

End Class
