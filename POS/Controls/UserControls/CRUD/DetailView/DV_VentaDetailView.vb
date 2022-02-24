Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Vision.POS.BLL
Imports Studio.Vision.POS.BLL.Business
Imports Studio.Net.Controls.New.Forms
Imports Studio.Net.Helper
Imports Studio.Net.Controls.New
Imports Studio.Phone.POS.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports DevExpress.XtraGrid.Views.Grid
Imports Studio.Phone.POS.Controls.New

Public Class DV_VentaDetailView

#Region "CTor"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As DocumentoSalidaBEntity, ByVal binding As BindingSource)

        MyBase.New(business, binding)

        InitializeComponent()
    End Sub

    Public Sub New(ByVal business As DocumentoSalidaBEntity, ByVal binding As BindingSource, ByVal cajaId As Integer)

        MyBase.New(business, binding, cajaId)

        InitializeComponent()

    End Sub

#End Region

#Region "Eventos de acción"

    Private Sub OnGetQueryableForArticulo(ByVal sender As Object, ByVal e As CristalMatrixView.MatrixViewGetQueryableEvenArgs)

        Controls2Entity()
        e.QueryableSource = DV_CristalBEntity.GetQueryableForCristalesGuiaDeVarianteVentas(e.Adapter, _
                                GetCurrentEntity(Of Tmp_DocumentoSalidaEntity))
        e.Handled = True
    End Sub

    Private Sub OnProcessGridKey(ByVal sender As Object, ByVal e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.F11 AndAlso e.Shift AndAlso CurrentEntity.IsNew AndAlso PermitirIngresarDetalle() Then
                ShowCristalForm()
            ElseIf e.KeyCode = Keys.F11 AndAlso CurrentEntity.IsNew AndAlso PermitirIngresarDetalle() Then
                ShowIngresoEstiloRecetaForm()
            End If

        Catch ex As Exception
            Studio.Net.Helper.LogError.Publish(ex)
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub
#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        MyBase.OnLoad(e)

        AddHandler grdDetalle.ProcessGridKey, AddressOf OnProcessGridKey

    End Sub

    Public Overrides Sub DisposeDataView()
        MyBase.DisposeDataView()
        RemoveHandler grdDetalle.ProcessGridKey, AddressOf OnProcessGridKey
    End Sub

#End Region

#Region "Procedimientos Privados"

    Private Shared Function ArticuloAProcesarPredicate() As Func(Of CristalValor, Boolean)
        Return Function(v) v.Valor > Decimal.Zero AndAlso v.ArticuloId > 0
    End Function

    Private Sub UpdateMaxtrixData(ByVal dsSource As CristalesMatrixData)

        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

            CursorManager.WaitCursor()

            Try
                _parent.ShowWaitForm("Cargando cristales seleccionados.")
                'Eliminar los datos viejos
                Dim detalles As EntityCollection(Of Tmp_DocSalidaDetalleEntity) = GetCurrentEntity(Of Tmp_DocumentoSalidaEntity).Detalles
                detalles.RemoveRange(detalles.Where(Function(f) (TypeOf f.Articulo Is DV_CristalEntity)).ToList())

                Dim dummyView As New Studio.Phone.POS.DAL.TypedListClasses.ArticuloSeekerTypedList
                Dim total As Integer = dsSource.Cristales.Sum(Function(f) f.Valores.Where(ArticuloAProcesarPredicate()).Count())
                Dim i As Integer = 1I

                For Each guia As CristalData In dsSource.Cristales
                    For Each valor As CristalValor In guia.Valores.Where(ArticuloAProcesarPredicate())
                        _parent.SetWaiFormDescription(String.Format("Agregando artículo {0} de {1}", i, total))

                        Dim view As GridView = grdDetalle.MainView
                        view.AddNewRow()
                        view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle

                        Dim row As Studio.Phone.POS.DAL.TypedListClasses.ArticuloSeekerRow = dummyView.NewRow()
                        'row.Articulo = ArticuloController.DescripcionFullFromId(da, valor.ArticuloId)
                        row.Id = valor.ArticuloId
                        row.ListaPrecioVentaId = GetListaPreVtaId()
                        dummyView.Rows.Add(row)

                        Dim args As New Studio.Phone.POS.Controls.[New].RecordSelectedEventArgs(dummyView.DefaultView(dummyView.Rows.Count - 1))
                        OnSelectingArticulo(Me, args)

                        If args.CloseForm Then
                            view.SetFocusedRowCellValue(DocSalidaDetalleFieldIndex.Cantidad.ToString(), valor.Valor)
                            'view.SetFocusedRowCellValue(DocSalidaDetalleFieldIndex.ListaPreVtaId.ToString(), CInt(cboListaPreVtaId.EditValue))
                            'view.SetFocusedRowCellValue(DocSalidaDetalleFieldIndex.Cantidad.ToString(), valor.Valor)
                            'view.SetFocusedRowCellValue(DocSalidaDetalleFieldIndex.ImporteUnitario.ToString(), view.GetFocusedRowCellValue(DocSalidaDetalleFieldIndex.ImporteLista.ToString()))
                        End If

                        i += 1
                        If Not view.UpdateCurrentRow() Then
                            MyMsgBox.Show("No se pudieron cargar todos los artículos debido a errores de validación, solo fueron agregados los artículos previos al primero error encontrado." & vbCrLf & "Corrija los errores y vuelva a intentar.", MsgBoxStyle.Exclamation)
                            Exit For
                        End If                        '                                              })
                    Next
                Next
            Catch ex As Exception
                _parent.CloseWaitForm()
                MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            Finally
                CursorManager.Default()
                _parent.CloseWaitForm()
            End Try
        End Using
    End Sub

    Private Sub ShowCristalForm()

        Try

            CursorManager.WaitCursor()
            If _parent IsNot Nothing Then
                _parent.Enabled = False
            End If
            Dim dsSource As CristalesMatrixData = DV_CristalBEntity.GetMatrixData(GetCurrentEntity(Of Tmp_DocumentoSalidaEntity).Detalles)
            grvDetalle.HideEditor()
            grvDetalle.CancelUpdateCurrentRow()
            Using v As New CristalMatrixView(dsSource)
                AddHandler v.GetQueryableForArticulo, AddressOf OnGetQueryableForArticulo
                Try
                    'v.Caption = "Ingreso de stock de cristales"
                    Using f As New Studio.Net.Controls.[New].Forms.SaveDeleteGenericDialog(v)
                        f.Text = "Ingreso de stock de cristales"
                        f.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
                        f.Location = ParentForm.PointToScreen(New System.Drawing.Point(_parent.xTab.Left, _parent.panel.Top))
                        f.Size = _parent.xTab.Size
                        f.StartPosition = Windows.Forms.FormStartPosition.Manual

                        'If FormHelper.ShowControl(_parent, v, _parent.xTab.Size, _
                        '                ParentForm.PointToScreen(New System.Drawing.Point(_parent.xTab.Left, _parent.panel.Top)), False) Then
                        If f.ShowDialog(_parent) = Windows.Forms.DialogResult.OK Then
                            UpdateMaxtrixData(dsSource)
                            'DV_CristalBEntity.UpdateMatrixData(dsSource, GetCurrentEntity(Of DocumentoSalidaEntity))
                        End If
                    End Using
                Catch
                    Throw
                Finally
                    RemoveHandler v.GetQueryableForArticulo, AddressOf OnGetQueryableForArticulo
                End Try
                v.DisposeDataView()
            End Using
        Catch ex As Exception
            Studio.Net.Helper.LogError.Publish(ex)
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            CursorManager.Default()
            _parent.Enabled = True
        End Try
    End Sub

#End Region

    Private Sub ShowIngresoEstiloRecetaForm()

        Try

            CursorManager.WaitCursor()
            If _parent IsNot Nothing Then
                _parent.Enabled = False
            End If
            grvDetalle.HideEditor()
            grvDetalle.CancelUpdateCurrentRow()

            Using v As New DV_CristalIngresoMasivoView(EntityToEdit)
                Try

                    'v.Caption = "Ingreso de stock de cristales"
                    Using f As New Studio.Net.Controls.[New].Forms.SaveDeleteGenericDialog(v)
                        f.Text = "Agregar cristales"
                        f.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
                        f.Location = ParentForm.PointToScreen(New System.Drawing.Point(_parent.xTab.Left, _parent.panel.Top))
                        f.Size = _parent.xTab.Size
                        f.SaveVisible = False
                        f.StartPosition = Windows.Forms.FormStartPosition.Manual
                        If f.ShowDialog(_parent) = Windows.Forms.DialogResult.OK Then
                            UpdateDetalles(v.EntityToEdit.Detalles)
                        End If

                    End Using
                Catch
                    Throw
                End Try
                'v.DisposeDataView()
            End Using
        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            CursorManager.Default()
            _parent.Enabled = True
        End Try
    End Sub

    Private Sub UpdateDetalles(ByVal dsSource As EntityCollection(Of Tmp_DocSalidaDetalleEntity))

        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

            CursorManager.WaitCursor()

            Try
                _parent.ShowWaitForm("Cargando cristales seleccionados.")
                Dim i As Integer = 1I
                Dim total As Integer = dsSource.Count
                For Each detalle As Tmp_DocSalidaDetalleEntity In dsSource
                    _parent.SetWaiFormDescription(String.Format("Agregando artículo {0} de {1}", i, total))

                    Dim view As GridView = grdDetalle.MainView
                    view.AddNewRow()
                    view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle

                    view.SetFocusedRowCellValue(Tmp_DocSalidaDetalleFieldIndex.ArticuloCodigo.ToString(), detalle.ArticuloCodigo)
                    view.SetFocusedRowCellValue(Tmp_DocSalidaDetalleFieldIndex.ArticuloId.ToString(), detalle.ArticuloId)
                    view.SetFocusedRowCellValue(Tmp_DocSalidaDetalleFieldIndex.Descripcion.ToString(), detalle.Descripcion)
                    view.SetFocusedRowCellValue(Tmp_DocSalidaDetalleFieldIndex.ListaPreVtaId.ToString(), detalle.ListaPreVtaId)
                    view.SetFocusedRowCellValue(Tmp_DocSalidaDetalleFieldIndex.Cantidad.ToString(), detalle.Cantidad)
                    view.SetFocusedRowCellValue(Tmp_DocSalidaDetalleFieldIndex.ImporteUnitario.ToString(), detalle.ImporteUnitario)
                    view.SetFocusedRowCellValue(Tmp_DocSalidaDetalleFieldIndex.Importe.ToString(), detalle.Importe)
                    view.SetFocusedRowCellValue(Tmp_DocSalidaDetalleFieldIndex.DatoExtra.ToString(), detalle.DatoExtra)


                    If detalle.BonificacionId > 0 Then
                        view.SetFocusedRowCellValue(Tmp_DocSalidaDetalleFieldIndex.BonificacionId.ToString(), detalle.BonificacionId)
                    End If
                    i += 1
                    If Not view.UpdateCurrentRow() Then
                        _parent.CloseWaitForm()
                        MyMsgBox.Show("No se pudieron cargar todos los artículos debido a errores de validación, solo fueron agregados los artículos previos al primero error encontrado." & vbCrLf & "Corrija los errores y vuelva a intentar.", MsgBoxStyle.Exclamation)
                        Exit For
                    End If                        '                                              })
                Next

            Catch ex As Exception
                _parent.CloseWaitForm()
                MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            Finally

                'RefrescarTotal()
                CursorManager.Default()
                _parent.CloseWaitForm()
            End Try
        End Using
    End Sub

    Protected Overrides Function GetController() As Phone.POS.BLL.BonificacionDinamicaController
        Return New Studio.Vision.POS.BLL.BonificacionDinamicaController
    End Function


End Class
