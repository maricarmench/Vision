Imports DevExpress.Data.Linq
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Net.Controls.New
Imports DevExpress.XtraTab
Imports DevExpress.XtraPivotGrid
Imports Studio.Vision.BLL
Imports Studio.Phone.DAL
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Vision.BLL.Business
Imports Studio.Net.Helper
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Skins
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks

Public Class CristalMatrixView

#Region "CTor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal datasource As CristalesMatrixData)
        Me.New()
        _datasource = datasource
        '_atributoValores = atributoValores
    End Sub

#End Region

#Region "Propiedades Publicas"

    Public Property ValorFormat As String = "{0:n0}"

    Public Property ArticuloIDName As String = "Id"
    Public Property ArticuloDescripcionName As String = "Descripcion"

#End Region

#Region "Variables de módulo"

    Private _readOnlyMode As Boolean
    Private _datasource As CristalesMatrixData
    Private _controlColor As Color
    Private _bgColor As Color
    Private _textColor As Color

#End Region

#Region "Eventos"

    Public Event CellDoubleClick(sender As Object, e As CristalMatrixCellDoubleClickedEventArgs)

#End Region

#Region "Eventos de acción"

    Private Sub OnCellDoubleClick(sender As Object, e As PivotCellEventArgs)

        Dim grid As PivotGridControl = DirectCast(sender, PivotGridControl)
        Dim list As List(Of CristalValor) = DirectCast(grid.DataSource, List(Of CristalValor))
        Dim info As PivotCellEventArgs = grid.Cells.GetCellInfo(e.ColumnIndex, e.RowIndex)
        Dim ds As PivotDrillDownDataSource = info.CreateDrillDownDataSource()

        Dim data As CristalValor = list(ds(0).ListSourceRowIndex)

        RaiseEvent CellDoubleClick(sender, New CristalMatrixCellDoubleClickedEventArgs(data))

    End Sub

    Private Sub btnShowAddCristal_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles btnShowAddCristal.ButtonClick

        cboArticuloId.Properties.PopulateViewColumns()
        If cboArticuloId.Properties.View.Columns(ArticuloFieldIndex.Id.ToString()) IsNot Nothing Then
            cboArticuloId.Properties.View.Columns(ArticuloFieldIndex.Id.ToString()).MaxWidth = 50
            cboArticuloId.Properties.View.Columns(ArticuloFieldIndex.Descripcion.ToString()).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        End If

    End Sub

    Private Sub barManager_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles barManager.ItemClick

        Dim grid As PivotGridControl = DirectCast(tabControl.Tag, PivotGridControl)
        Dim list As List(Of CristalValor) = DirectCast(grid.DataSource, List(Of CristalValor))

        If e.Item.Name = bbiCopiar.Name Then
            CopiarEnPortapapeles(grid, list, False)
        ElseIf e.Item.Name = bbiCopyWithHeaders.Name Then
            CopiarEnPortapapeles(grid, list, True)

        ElseIf e.Item.Name = bbiPegar.Name Then

            If Not Studio.Net.Controls.[New].ClipboardHelper.IsDataExcel() Then
                Return
            End If

            PegarDesdeExcel(grid, list)

        ElseIf e.Item.Name = bbiSelectAll.Name Then
            grid.Cells.Selection = New Rectangle(0, 0, grid.Cells.ColumnCount - 1, grid.Cells.RowCount - 1)
        End If

    End Sub

    Private Sub ritePegarDesde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ritePegarDesde.KeyDown

        If e.KeyCode = Keys.Return Then
            Dim valor As Decimal
            Dim editor As DevExpress.XtraEditors.TextEdit = DirectCast(sender, DevExpress.XtraEditors.TextEdit)

            If Decimal.TryParse(editor.Text, valor) Then
                Dim grid As PivotGridControl = DirectCast(tabControl.Tag, PivotGridControl)
                Dim list As List(Of CristalValor) = DirectCast(grid.DataSource, List(Of CristalValor))
                PegarValores(grid, list, valor)
            End If
        End If

    End Sub

    Private Sub tabControl_CloseButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabControl.CloseButtonClick

        Dim tabToRemove As XtraTabPage = DirectCast(sender, XtraTabControl).SelectedTabPage

        If tabToRemove IsNot Nothing Then
            If MyMsgBox.Show("¿Seguro que desea quitar el artículo seleccionado?. No podrá deshacer esta acción", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim cristal As CristalData = DirectCast(tabToRemove.Tag, CristalData)
                _datasource.Cristales.Remove(cristal)
                tabControl.TabPages.Remove(tabToRemove)

            End If
        End If

    End Sub

    Private Sub btnAddCristal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCristal.Click

        Try

            CursorManager.WaitCursor()

            If cboArticuloId.EditValue Is Nothing Then
                MyMsgBox.Show("Debe seleccionar el artículo.", MsgBoxStyle.Exclamation)
                Return
            End If
            If _datasource.Cristales.Any(Function(f) f.ArticuloId = CInt(cboArticuloId.EditValue)) Then
                MyMsgBox.Show("Ese artículo ya fue seleccionado.", MsgBoxStyle.Exclamation)
                Return
            End If

            Dim cristal As CristalData = AddNewArticulo(CInt(cboArticuloId.EditValue))

            AddTabCristal(cristal)
            btnShowAddCristal.ClosePopup()

        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)

        Finally
            CursorManager.Default()
        End Try

    End Sub

    Private Sub lqifsArticulo_DismissQueryable(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles lqifsArticulo.DismissQueryable
        DirectCast(e.Tag, IDataAccessAdapter).Dispose()
    End Sub

    Private Sub lqifsArticulo_GetQueryable(ByVal sender As System.Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles lqifsArticulo.GetQueryable

        Dim da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
        Dim args As New MatrixViewGetQueryableEvenArgs(da)

        RaiseEvent GetQueryableForArticulo(sender, args)

        If args.Handled Then

            e.QueryableSource = args.QueryableSource
            e.KeyExpression = args.KeyExpression
            e.Tag = args.Adapter

        Else

            e.QueryableSource = Business.DV_CristalBEntity.GetQueryableForCristalesGuiaDeVariante(da)
            e.KeyExpression = DV_CristalFieldIndex.Id.ToString()
            e.Tag = da

        End If

    End Sub

#End Region

#Region "Eventos Públicos"

#End Region

#Region "Procedimientos Privados"

    Private Function CreateCompositeLink() As CompositeLink

        printingSystem1.Links.Clear()


        Dim pcl As New List(Of PrintableComponentLink)
        'Dim pgbk As New Link
        Try

            'cl.PrintingSystem.Begin()
            For Each item As XtraTabPage In tabControl.TabPages
                pcl.Add(New PrintableComponentLink(printingSystem1))
                pcl(pcl.Count - 1).Component = DirectCast(item.Controls(0), PivotGridControl)
                pcl(pcl.Count - 1).RtfReportHeader = item.Text
                'pcl(pcl.Count - 1).Landscape = True
                AddHandler pcl(pcl.Count - 1).CreateReportHeaderArea, AddressOf OnCreateReportHeaderArea
                'cl.Links.Add(pcl(pcl.Count - 1))
                'cl.Links.Add(pgbk)
                pcl(pcl.Count - 1).CreateDocument()
                'cl.CreatePageForEachLink()

            Next
            Dim cl As New CompositeLink(printingSystem1)
            cl.Links.AddRange(pcl.ToArray())
            'cl.PrintingSystem.PageSettings.Landscape = True
            cl.CreatePageForEachLink()
            cl.CreateDocument()

            'cl.PrintingSystem.End()
            'cl.ShowRibbonPreviewDialog(LookAndFeel.ActiveLookAndFeel)
            Return cl

        Catch
            Throw
        Finally
            For i As Integer = 0 To pcl.Count - 1 Step 1
                RemoveHandler pcl(i).CreateReportHeaderArea, AddressOf OnCreateReportHeaderArea
            Next
        End Try
        'End Using

        'Dim grid As PivotGridControl = tabControl.SelectedTabPage.Controls(0)
        'Dim p As New PrintableComponentLink()
        'p.Component = grid
        'p.Landscape = True
        'p.CreateDocument(New PrintingSystem())

        'p.ShowRibbonPreviewDialog(LookAndFeel.ActiveLookAndFeel)


    End Function

    Private Sub CopiarEnPortapapeles(grid As PivotGridControl, list As List(Of CristalValor), copyHeaders As Boolean)

        Dim strToCopy As New System.Text.StringBuilder

        'Primero agregar los encabezados
        Dim cells As PivotGridCells = grid.Cells
        ' Get the coordinates of the selected cells.
        Dim cellSelection As Rectangle = cells.Selection
        ' Get the index of the bottommost selected row.
        Dim maxRow As Integer = cellSelection.Y + cellSelection.Height - 1
        ' Get the index of the rightmost selected column.
        Dim maxColumn As Integer = cellSelection.X + cellSelection.Width - 1
        ' Iterate through the selected cells.
        Dim rowIndex, colIndex As Integer
        'Dim excelTable As System.Data.DataTable = Studio.Net.Helper.DAL.ExcelReader.FromClipboard()
        If copyHeaders Then
            'La primera columna en blanco porque se va a usar para cabezal de filas
            strToCopy.Append(vbTab)
            For colIndex = cellSelection.X To maxColumn
                Dim info As PivotCellEventArgs = cells.GetCellInfo(colIndex, rowIndex)
                Dim ds As PivotDrillDownDataSource = info.CreateDrillDownDataSource()

                strToCopy.Append(list(ds(0).ListSourceRowIndex).PlantillaValor2.ToString("n2") & vbTab)


            Next
            strToCopy.Append(vbCr)
        End If

        For rowIndex = cellSelection.Y To maxRow
            If copyHeaders Then

                Dim info As PivotCellEventArgs = cells.GetCellInfo(colIndex, rowIndex)
                Dim ds As PivotDrillDownDataSource = info.CreateDrillDownDataSource()

                strToCopy.Append(list(ds(0).ListSourceRowIndex).PlantillaValor1.ToString("n2") & vbTab)

            End If

            For colIndex = cellSelection.X To maxColumn
                ' Get the current cell's display text.
                Dim info As PivotCellEventArgs = cells.GetCellInfo(colIndex, rowIndex)
                Dim ds As PivotDrillDownDataSource = info.CreateDrillDownDataSource()

                If ds.RowCount > 0 Then
                    If Not list(ds.Item(0).ListSourceRowIndex).NoExiste Then
                        'list(ds.Item(0).ListSourceRowIndex).Valor = NumberConversor.ParseDecimal(excelTable.Rows(rowIndex).Item(colIndex))
                        Dim valor As Decimal = list(ds.Item(0).ListSourceRowIndex).Valor
                        strToCopy.Append(IIf(valor <> Decimal.Zero, valor.ToString(), String.Empty) & vbTab)
                    End If
                End If

            Next
            strToCopy.Append(vbCr)
        Next

        ClipboardHelper.SetData(strToCopy.ToString())

    End Sub

    Private Sub PegarDesdeExcel(ByVal grid As PivotGridControl, ByVal list As List(Of CristalValor))

        Try

            Dim cells As PivotGridCells = grid.Cells
            ' Get the coordinates of the selected cells.
            Dim cellSelection As Rectangle = cells.Selection
            ' Get the index of the bottommost selected row.
            Dim maxRow As Integer = cellSelection.Y + cellSelection.Height - 1
            ' Get the index of the rightmost selected column.
            Dim maxColumn As Integer = cellSelection.X + cellSelection.Width - 1
            ' Iterate through the selected cells.
            Dim rowIndex, colIndex As Integer
            Dim excelTable As System.Data.DataTable = Studio.Net.Helper.DAL.ExcelReader.FromClipboard()
            Dim selRowCount As Integer = maxRow - cellSelection.Y + 1
            Dim selColumnCount As Integer = maxColumn - cellSelection.X + 1

            If excelTable.Rows.Count <> selRowCount OrElse excelTable.Columns.Count <> selColumnCount Then
                If MyMsgBox.Show("No se copiaron la misma cantidad de celdas que va a pegar, solo se pogará parte de la información. ¿Desea continuar de todos modos?.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                    Return
                End If
            End If
              For rowIndex = cellSelection.Y To maxRow
                For colIndex = cellSelection.X To maxColumn
                    If rowIndex - cellSelection.Y < excelTable.Rows.Count AndAlso colIndex - cellSelection.X < excelTable.Columns.Count Then
                        ' Get the current cell's display text.
                        Dim info As PivotCellEventArgs = cells.GetCellInfo(colIndex, rowIndex)
                        Dim ds As PivotDrillDownDataSource = info.CreateDrillDownDataSource()
                        If ds.RowCount > 0 Then
                            If Not list(ds.Item(0).ListSourceRowIndex).NoExiste Then
                                list(ds.Item(0).ListSourceRowIndex).Valor = NumberConversor.ParseDecimal(excelTable.Rows(rowIndex - cellSelection.Y).Item(colIndex - cellSelection.X))
                            End If
                        End If
                    End If
                Next
            Next
            grid.RefreshData()
        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub OnCreateReportHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim link As PrintableComponentLink = DirectCast(sender, PrintableComponentLink)
        Dim grid As PivotGridControl = link.Component
        Dim brick As TextBrick = e.Graph.DrawString(grid.Tag, Color.Navy, New RectangleF(0, 0, 500, 40), BorderSide.None)
        brick.Font = New Font("Tahoma", 16)
        brick.StringFormat = New BrickStringFormat(StringAlignment.Center)
    End Sub
    Private Function GetFocusedGrid() As PivotGridControl
        Return DirectCast(tabControl.SelectedTabPage.Controls(0), PivotGridControl)
    End Function

    Private Sub OnShowingEditor(ByVal sender As Object, ByVal e As CancelPivotCellEditEventArgs)
        If e.RowValueType = PivotGridValueType.Value AndAlso e.ColumnValueType = PivotGridValueType.Value Then
            e.Cancel = GetValor(e).NoExiste
        Else
            e.Cancel = True
        End If
    End Sub

    Private Function GetValor(ByVal e As PivotCustomCellEditEventArgs) As CristalValor

        Dim ds As PivotDrillDownDataSource = e.CreateDrillDownDataSource()
        Dim cData As CristalData = DirectCast(tabControl.SelectedTabPage.Tag, CristalData)
        Return cData.Valores(ds.Item(0).ListSourceRowIndex)

    End Function

    Private Sub OnCustomDrawCell(ByVal sender As Object, ByVal e As PivotCustomDrawCellEventArgs)

        If e.ColumnValueType = PivotGridValueType.Value AndAlso _
                    e.RowValueType = PivotGridValueType.Value Then

            Dim pivot As PivotGridControl = DirectCast(sender, PivotGridControl)
            Dim ds As PivotDrillDownDataSource = e.CreateDrillDownDataSource()
            If ds Is Nothing OrElse ds.RowCount = 0 Then
                Return
            End If

            Dim index As Integer = ds.Item(0).ListSourceRowIndex
            Dim list As List(Of CristalValor) = pivot.DataSource
            If list(index).ArticuloId = 0I Then
                e.GraphicsCache.FillRectangle(Color.FromArgb(15, _controlColor), e.Bounds)
            Else

                If e.Selected Then
                    e.GraphicsCache.FillRectangle(New SolidBrush(Color.FromArgb(150, _controlColor)), e.Bounds)
                Else
                    e.GraphicsCache.FillRectangle(New SolidBrush(_bgColor), e.Bounds)
                End If

                If list(index).Valor <> Decimal.Zero Then

                    Dim innerRect As Rectangle = Rectangle.Inflate(e.Bounds, -3, -3)

                    'No mostramos ningún texto
                    e.GraphicsCache.DrawString(e.DisplayText, e.Appearance.Font, _
                      New SolidBrush(_textColor), innerRect, e.Appearance.GetStringFormat())
                End If

            End If

            If e.Focused Then

                Dim focusedRect As Rectangle = Rectangle.Inflate(e.Bounds, -1, -1)
                Dim p As New Pen(Color.FromArgb(255, _textColor))
                p.DashStyle = DashStyle.Dot
                e.GraphicsCache.DrawRectangle(p, focusedRect)

            End If
            e.Handled = True
        End If

    End Sub

    Private Sub OnShownEditor(ByVal sender As Object, ByVal e As PivotCellEditEventArgs)
        e.Edit.SelectAll()
    End Sub

    Private Sub OnGridMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)

        If e.Button = MouseButtons.Right Then
            Dim pivot As PivotGridControl = TryCast(sender, PivotGridControl)
            Dim pt As Point = pivot.PointToClient(MousePosition)
            Dim hit As PivotGridHitInfo = pivot.CalcHitInfo(pt)
            tabControl.Tag = Nothing
            If hit.HitTest = PivotGridHitTest.Cell Then
                'Setear grilla activa
                tabControl.Tag = sender
                popMenuCopiar.ShowPopup(Me.PointToScreen(pt))
            End If
        End If
    End Sub

    Private Shared Sub PegarValores(ByVal grid As PivotGridControl, ByVal list As List(Of CristalValor), ByVal valor As Decimal)

        Dim cells As PivotGridCells = grid.Cells
        ' Get the coordinates of the selected cells.
        Dim cellSelection As Rectangle = cells.Selection
        ' Get the index of the bottommost selected row.
        Dim maxRow As Integer = cellSelection.Y + cellSelection.Height - 1
        ' Get the index of the rightmost selected column.
        Dim maxColumn As Integer = cellSelection.X + cellSelection.Width - 1
        ' Iterate through the selected cells.
        Dim rowIndex, colIndex As Integer
        For rowIndex = cellSelection.Y To maxRow
            For colIndex = cellSelection.X To maxColumn
                ' Get the current cell's display text.
                Dim info As PivotCellEventArgs = cells.GetCellInfo(colIndex, rowIndex)
                Dim ds As PivotDrillDownDataSource = info.CreateDrillDownDataSource()
                If ds.RowCount > 0 Then
                    If Not list(ds.Item(0).ListSourceRowIndex).NoExiste Then
                        list(ds.Item(0).ListSourceRowIndex).Valor = valor
                    End If
                End If
            Next

        Next
        ' Copy the resulting text to the clipboard.
        grid.RefreshData()

    End Sub

    Private Sub OnGridEditValueChanged(ByVal sender As Object, ByVal e As EditValueChangedEventArgs)

        Dim ds As PivotDrillDownDataSource = e.CreateDrillDownDataSource()
        Dim pivot As PivotGridControl = DirectCast(sender, PivotGridControl)
        Dim valores As List(Of CristalValor) = DirectCast(pivot.DataSource, List(Of CristalValor))
        Dim index As Integer = ds.Item(0).ListSourceRowIndex
        valores(index).Valor = e.Editor.EditValue
        pivot.RefreshData()

    End Sub

    Private Sub ConfigGrid(ByVal grdToConfig As PivotGridControl, ByVal template As CristalData)

        Dim plantilla1 As AAtributoPlantillaEntity = AAtributoPlantillaBEntity.GetById(template.PlantillaId1)
        Dim plantilla2 As AAtributoPlantillaEntity = AAtributoPlantillaBEntity.GetById(template.PlantillaId2)

        Dim field1 As PivotGridField = grdToConfig.Fields.Add()
        field1.FieldName = "PlantillaValor1"
        'field1.AreaIndex = 0
        field1.AllowedAreas = PivotGridAllowedAreas.RowArea
        field1.Area = PivotArea.RowArea
        field1.Caption = plantilla1.Nombre
        'field1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
        field1.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
        field1.MinWidth = 50
        field1.GrandTotalText = "TOT"
        field1.SortOrder = PivotSortOrder.Descending

        If Not String.IsNullOrEmpty(plantilla1.Formato) Then
            field1.ValueFormat.FormatType = DevExpress.Utils.FormatType.Custom
            field1.ValueFormat.FormatString = plantilla1.Formato
        End If
        ' Dim valoresBs As New AAtributoPlantillaValorBEntity

        Dim field2 As PivotGridField = grdToConfig.Fields.Add()
        field2.FieldName = "PlantillaValor2"
        field2.Caption = plantilla2.Nombre
        'field2.AllowedAreas = PivotGridAllowedAreas.ColumnArea
        'field2.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
        field2.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
        field2.MinWidth = 50
        field2.GrandTotalText = "TOT."
        field2.Area = PivotArea.ColumnArea
        field2.SortOrder = PivotSortOrder.Descending
        If Not String.IsNullOrEmpty(plantilla2.Formato) Then
            field2.ValueFormat.FormatType = DevExpress.Utils.FormatType.Custom
            field2.ValueFormat.FormatString = plantilla2.Formato
        End If

        Dim fieldValor As PivotGridField = grdToConfig.Fields.Add()
        fieldValor.FieldName = "Valor"
        fieldValor.Area = PivotArea.DataArea
        fieldValor.AllowedAreas = PivotGridAllowedAreas.DataArea
        fieldValor.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
        fieldValor.CellFormat.FormatString = ValorFormat
        fieldValor.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom

        'fieldValor.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
        If Not ReadOnlyMode Then

            Dim editor As New RepositoryItemTextEdit
            editor.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            editor.EditFormat.FormatString = "{0:n0}"
            editor.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            fieldValor.FieldEdit = editor
        End If

        'fieldValor.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        fieldValor.MinWidth = 50

        Dim fieldNoExiste As PivotGridField = grdToConfig.Fields.Add()
        fieldNoExiste.FieldName = "NoExiste"
        fieldNoExiste.Visible = False

        Dim fieldArticuloId As PivotGridField = grdToConfig.Fields.Add()
        fieldArticuloId.FieldName = "ArticuloId"
        fieldArticuloId.Visible = False

        grdToConfig.OptionsBehavior.BestFitMode = PivotGridBestFitMode.Cell
        grdToConfig.OptionsBehavior.UseAsyncMode = True
        grdToConfig.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        grdToConfig.OptionsView.DrawFocusedCellRect = True
        grdToConfig.OptionsSelection.EnableAppearanceFocusedCell = True
        grdToConfig.OptionsSelection.MultiSelect = False

        grdToConfig.OptionsCustomization.AllowCustomizationForm = False
        grdToConfig.OptionsCustomization.AllowDrag = False
        grdToConfig.OptionsCustomization.AllowEdit = Not ReadOnlyMode
        grdToConfig.OptionsCustomization.AllowExpand = False
        grdToConfig.OptionsCustomization.AllowHideFields = False
        grdToConfig.OptionsView.ShowColumnHeaders = True
        grdToConfig.OptionsView.ShowColumnGrandTotals = True
        grdToConfig.OptionsView.ShowFilterHeaders = False

        grdToConfig.Tag = template.Descripcion

        tabControl.HeaderButtons = IIf(ReadOnlyMode, TabButtons.Default, TabButtons.Close)

        AddHandler grdToConfig.EditValueChanged, AddressOf OnGridEditValueChanged
        AddHandler grdToConfig.ShowingEditor, AddressOf OnShowingEditor
        AddHandler grdToConfig.CustomDrawCell, AddressOf OnCustomDrawCell
        AddHandler grdToConfig.ShownEditor, AddressOf OnShownEditor
        AddHandler grdToConfig.MouseUp, AddressOf OnGridMouseUp
        AddHandler grdToConfig.CellDoubleClick, AddressOf OnCellDoubleClick

    End Sub


    Public Function AddNewArticulo(ByVal articuloId As Integer) As CristalData

        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

            Dim cristalGuia As DV_CristalEntity = DirectCast(ArticuloController.BuscarPorId(da, articuloId), DV_CristalEntity)
            Dim template As DV_CristalPlantillaEntity = DV_CristalPlantillaBEntity.GetById(da, cristalGuia.CristalPlantillaID)
            Dim rango1 As List(Of Decimal) = DV_CristalPlantillaBEntity.GetValoresRango1(articuloId, template)
            Dim rango2 As List(Of Decimal) = DV_CristalPlantillaBEntity.GetValoresRango2(articuloId, template)

            Dim variantes As EntityCollection(Of ArticuloEntity) = ArticuloController.BuscarVariantes(da, articuloId, ArticuloController.CrearPrefetchPorCombinacionesYValores(), Function(f) f.Id, Function(f) f.Descripcion)
            Dim fieldName1 As String = AAtributoPlantillaValorBEntity.GetFieldFromPlantilla(AAtributoPlantillaBEntity.GetById(template.AAtributoPlantillaID1)).Name
            Dim fieldName2 As String = AAtributoPlantillaValorBEntity.GetFieldFromPlantilla(AAtributoPlantillaBEntity.GetById(template.AAtributoPlantillaID2)).Name


            Dim toReturn As CristalData
            If _datasource.Cristales.Any(Function(f) f.ArticuloId = articuloId) Then
                toReturn = _datasource.Cristales.First(Function(f) f.ArticuloId = articuloId)
            Else
                toReturn = New CristalData
                toReturn.ArticuloId = articuloId
                toReturn.Descripcion = cristalGuia.Descripcion
                toReturn.PlantillaId1 = template.AAtributoPlantillaID1
                toReturn.PlantillaId2 = template.AAtributoPlantillaID2
                _datasource.Cristales.Add(toReturn)
            End If

            For Each valor1 As Decimal In rango1

                For Each valor2 As Decimal In rango2

                    Dim v1 As Decimal = valor1
                    Dim v2 As Decimal = valor2
                    Dim variante As DV_CristalEntity
                    Try
                        'variante = variantes.Where(Function(a) a.CombinacionesDeVariante.Where(Function(c) c.ValorDePlantilla.Fields(fieldName1).CurrentValue = v1).Any() AndAlso a.CombinacionesDeVariante.Where(Function(c) c.ValorDePlantilla.Fields(fieldName2).CurrentValue = v2).Any()).SingleOrDefault()
                        variante = variantes.Where(Function(a) a.CombinacionesDeVariante(0).ValorDePlantilla.Fields(fieldName1).CurrentValue = v1 AndAlso a.CombinacionesDeVariante(1).ValorDePlantilla.Fields(fieldName2).CurrentValue = v2).SingleOrDefault()
                    Catch ex As Exception
                        Throw
                    End Try
                    Dim valorToAdd As New CristalValor
                    If variante IsNot Nothing Then
                        'Si ya está cargado el artículo entonces no hacemos nada.
                        If toReturn.Valores.Any(Function(f) f.ArticuloId = variante.Id) Then
                            Continue For
                        End If

                        valorToAdd.ArticuloId = variante.Id
                        'valorToAdd.PlantillaValorID1=
                    Else
                        valorToAdd.NoExiste = True
                    End If
                    valorToAdd.PlantillaValor1 = valor1
                    valorToAdd.PlantillaValor2 = valor2
                    toReturn.Valores.Add(valorToAdd)
                Next
            Next
            Return toReturn
        End Using

    End Function
#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        MyBase.OnLoad(e)

        If Not Environment.DesignMode Then

            _controlColor = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors.GetColor("Control")
            _bgColor = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors.GetColor("Window")
            _textColor = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors.GetColor("WindowText")
            If _datasource IsNot Nothing Then
                LoadData()
            End If
        End If

    End Sub

    Public Overrides Sub DisposeDataView()

        For Each tab As XtraTabPage In tabControl.TabPages

            Dim grd As PivotGridControl = DirectCast(tab.Controls(0), PivotGridControl)

            RemoveHandler grd.EditValueChanged, AddressOf OnGridEditValueChanged
            RemoveHandler grd.ShowingEditor, AddressOf OnShowingEditor
            RemoveHandler grd.CustomDrawCell, AddressOf OnCustomDrawCell
            RemoveHandler grd.ShownEditor, AddressOf OnShownEditor
            RemoveHandler grd.MouseUp, AddressOf OnGridMouseUp
            RemoveHandler grd.CellDoubleClick, AddressOf OnCellDoubleClick
        Next

        tabControl.TabPages.Clear()

        MyBase.DisposeDataView()

    End Sub

    Private Sub AddTabCristal(ByVal cristal As CristalData)

        '_datasource.Cristales.Add(cristal)
        Dim grid As New PivotGridControl With {.Dock = DockStyle.Fill}
        ConfigGrid(grid, cristal)
        grid.DataSource = cristal.Valores
        grid.BestFit()

        Dim newPage As XtraTabPage = tabControl.TabPages.Add(cristal.Descripcion)
        newPage.Tag = cristal
        newPage.Controls.Add(grid)
        tabControl.SelectedTabPage = newPage

    End Sub

#End Region

#Region "Eventos de acción"

    Public Event GetQueryableForArticulo(ByVal sender As Object, ByVal e As MatrixViewGetQueryableEvenArgs)

#End Region

#Region "MatrixViewGetQueryableEvenArgs"

    Public Class MatrixViewGetQueryableEvenArgs
        Inherits DevExpress.Data.Linq.GetQueryableEventArgs

        Public Sub New(ByVal adapter As IDataAccessAdapter)

            If adapter Is Nothing Then
                Throw New NullReferenceException("El argumento adapter no puede ser nulo")
            End If

            _adapter = adapter

        End Sub

        Public Property Handled As Boolean = False

        Private _adapter As IDataAccessAdapter
        Public ReadOnly Property Adapter As IDataAccessAdapter
            Get
                Return _adapter
            End Get
        End Property

    End Class

#End Region

#Region "Propiedades Públicas"

    Public Property ReadOnlyMode As Boolean
        Get
            Return _readOnlyMode
        End Get
        Set(ByVal Value As Boolean)
            _readOnlyMode = Value
            btnShowAddCristal.Enabled = Not Value
            bbiPegar.Enabled = Not Value
            bbiPegarValor.Enabled = Not Value

        End Set

    End Property
#End Region

#Region "Métodos Públicos"

    Public Function GetDataSource() As CristalesMatrixData
        Return _datasource
    End Function

    Public Sub SetDataSource(ByVal source As CristalesMatrixData)
        _datasource = source
    End Sub

    Public Sub LoadData(ByVal data As CristalesMatrixData)
        _datasource = data
        Clear()
        LoadData()
    End Sub

    Public Sub ShowPreview()
        Try

            Using cl As CompositeLink = CreateCompositeLink()
                'Dim cl As CompositeLink = CreateCompositeLink()
                cl.ShowRibbonPreviewDialog(LookAndFeel.ActiveLookAndFeel)
            End Using
            'cl.ShowRibbonPreview(LookAndFeel.ActiveLookAndFeel)
            'cl.ShowRibbonPreviewDialog(LookAndFeel.ActiveLookAndFeel)
        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Sub LoadData()

        For Each item As CristalData In _datasource.Cristales
            AddNewArticulo(item.ArticuloId)
            AddTabCristal(item)
        Next

    End Sub

    Public Sub Clear()
        Dim tabsToRemove As New List(Of XtraTabPage)(tabControl.TabPages)
        For Each item As XtraTabPage In tabsToRemove
            Dim cristal As CristalData = DirectCast(item.Tag, CristalData)
            _datasource.Cristales.Remove(cristal)
            tabControl.TabPages.Remove(item)
        Next

    End Sub

#End Region

#Region "Export"

    Public Sub ExportTo(ByVal ext As String, ByVal filter As String)

        Dim fileName As String = ObjectHelper.GetFileName(String.Format("*.{0}", ext), filter)
        If Not [String].IsNullOrEmpty(fileName) Then
            Try
                ExportToCore(fileName, ext)
                ObjectHelper.OpenExportedFile(fileName)
            Catch ex As Exception
                EndExport()
                ObjectHelper.ShowExportErrorMessage()
            End Try
        End If
    End Sub

    Private Sub ExportToCore(ByVal filename As [String], ByVal ext As String)


        StartExport()
        Dim currentCursor As Cursor = Cursor.Current
        Cursor.Current = Cursors.WaitCursor
        'Dim ps As DevExpress.XtraPrinting.IPrintingSystem = DevExpress.XtraPrinting.PrintHelper.GetCurrentPS()

        'AddHandler ps.AfterChange, AddressOf Export_Progress
        'Dim pivot As PivotGridControl = GetFocusedGrid()
        Dim cl As CompositeLink = CreateCompositeLink()

        If ext = "rtf" Then
            cl.ExportToRtf(filename)
        End If
        If ext = "pdf" Then
            cl.ExportToPdf(filename)
        End If
        If ext = "mht" Then
            cl.ExportToMht(filename)
        End If
        If ext = "html" Then
            cl.ExportToHtml(filename)
        End If
        If ext = "txt" Then
            cl.ExportToText(filename)
        End If
        If ext = "xls" Then

            Dim ept As XlsExportOptions = New XlsExportOptions()
            ept.ExportMode = XlsxExportMode.SingleFilePageByPage
            cl.ExportToXls(filename, ept)
        End If
        If ext = "xlsx" Then
            Dim ept As XlsxExportOptions = New XlsxExportOptions()
            ept.ExportMode = XlsxExportMode.SingleFilePageByPage
            cl.ExportToXlsx(filename)
        End If
        'RemoveHandler ps.AfterChange, AddressOf Export_Progress
        Cursor.Current = currentCursor
        EndExport()
        'End Using

    End Sub

    Private progressForm As Studio.Net.Controls.[New].Forms.ProgressForm = Nothing

    Protected Overridable Sub StartExport()
        'progressForm = New Studio.Net.Controls.[New].Forms.ProgressForm(Me.FindForm())
        'progressForm.ShowProgress( GetFocusedGrid().da, "<b>Exportación</b> de datos:")
    End Sub


    Protected Overridable Sub EndExport()
        If progressForm IsNot Nothing Then
            progressForm.HideProgress()
            progressForm.Dispose()
            progressForm = Nothing
        End If
    End Sub

    Protected Overridable Sub Export_Progress(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.ChangeEventArgs)
        If e.EventName = DevExpress.XtraPrinting.SR.ProgressPositionChanged Then
            Dim pos As Integer = CInt(e.ValueOf(DevExpress.XtraPrinting.SR.ProgressPosition))
            progressForm.Progress(pos)
        End If
    End Sub

    Protected Friend Overridable Sub ExportToPDF()
        ExportTo("pdf", ConstStrings.PDFOpenFileFilter)
    End Sub
    Protected Friend Overridable Sub ExportToHTML()
        ExportTo("html", ConstStrings.HTMLOpenFileFilter)
    End Sub
    Protected Friend Overridable Sub ExportToMHT()
        ExportTo("mht", ConstStrings.MHTOpenFileFilter)
    End Sub
    Protected Friend Overridable Sub ExportToXLS()
        ExportTo("xls", ConstStrings.XLSOpenFileFilter)
    End Sub
    Protected Friend Overridable Sub ExportToXLSX()
        ExportTo("xlsx", "XLSX documento (*.xlsx)|*.xlsx")
    End Sub
    Protected Friend Overridable Sub ExportToRTF()
        ExportTo("rtf", "RTF document (*.rtf)|*.rtf")
    End Sub
    Protected Friend Overridable Sub ExportToText()
        ExportTo("txt", "Text document (*.txt)|*.txt")
    End Sub
#End Region


End Class

#Region "CristalMatrixCellDoubleClickedEventArgs"

Public Class CristalMatrixCellDoubleClickedEventArgs
    Inherits EventArgs

    Private _cristalData As CristalValor

    Public ReadOnly Property CellData As CristalValor
        Get
            Return _cristalData
        End Get
    End Property

    Friend Sub New(data As CristalValor)
        _cristalData = data
    End Sub

End Class

#End Region
