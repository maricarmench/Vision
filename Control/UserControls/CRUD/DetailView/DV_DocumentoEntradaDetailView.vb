Imports Studio.Phone.DAL
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Vision.BLL
Imports Studio.Vision.BLL.Business
Imports Studio.Net.Controls.New.Forms
Imports Studio.Net.Helper
Imports Studio.Net.Controls.New
Imports Studio.Phone.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports DevExpress.XtraGrid.Views.Grid

Public Class DV_DocumentoEntradaDetailView

#Region "CTor"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As DocumentoEntradaBEntity, ByVal binding As BindingSource)

        MyBase.New(business, binding)

        InitializeComponent()
    End Sub

#End Region

#Region "Eventos de acción"

    Private Sub OnGetQueryableForArticulo(ByVal sender As Object, ByVal e As CristalMatrixView.MatrixViewGetQueryableEvenArgs)
        Controls2Entity()
        e.QueryableSource = DV_CristalBEntity.GetQueryableForCristalesGuiaDeVarianteCompras(e.Adapter, _
                                GetCurrentEntity(Of DocumentoEntradaEntity), ModoLibre)
        e.Handled = True
    End Sub

    Private Sub OnProcessGridKey(ByVal sender As Object, ByVal e As KeyEventArgs)

        If e.KeyCode = Keys.F11 AndAlso CurrentEntity.IsNew AndAlso PermitirIngresarDetalle() Then
            ShowCristalForm()
        End If

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
                Dim detalles As EntityCollection(Of DocEntradaDetalleEntity) = GetCurrentEntity(Of DocumentoEntradaEntity).Detalles
                detalles.RemoveRange(detalles.Where(Function(f) (TypeOf f.Articulo Is DV_CristalEntity)).ToList())

                Dim dummyView As New Studio.Phone.DAL.TypedListClasses.ArticuloSeekerTypedList
                Dim total As Integer = dsSource.Cristales.Sum(Function(f) f.Valores.Where(ArticuloAProcesarPredicate()).Count())
                Dim i As Integer = 1I

                For Each guia As CristalData In dsSource.Cristales
                    For Each valor As CristalValor In guia.Valores.Where(ArticuloAProcesarPredicate())
                        _parent.SetWaiFormDescription(String.Format("Agregando artículo {0} de {1}", i, total))

                        Dim view As GridView = grdDetalle.MainView
                        view.AddNewRow()
                        view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle

                        Dim row As Studio.Phone.DAL.TypedListClasses.ArticuloSeekerRow = dummyView.NewRow()
                        row.Articulo = ArticuloController.DescripcionFromId(da, valor.ArticuloId)
                        row.Id = valor.ArticuloId
                        dummyView.Rows.Add(row)

                        Dim args As New Studio.Phone.Controls.[New].RecordSelectedEventArgs(dummyView.DefaultView(dummyView.Rows.Count - 1))
                        OnSelectingArticulo(Me, args)

                        If args.CloseForm Then
                            view.SetFocusedRowCellValue(DocEntradaDetalleFieldIndex.Cantidad.ToString(), valor.Valor)
                            view.SetFocusedRowCellValue(DocEntradaDetalleFieldIndex.ImporteBoleta.ToString(), view.GetFocusedRowCellValue(DocEntradaDetalleFieldIndex.ImporteLista.ToString()))
                        End If

                        i += 1
                        If Not view.UpdateCurrentRow() Then
                            _parent.CloseWaitForm()
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
            Dim dsSource As CristalesMatrixData = DV_CristalBEntity.GetMatrixData(GetCurrentEntity(Of DocumentoEntradaEntity).Detalles)
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
                            'DV_CristalBEntity.UpdateMatrixData(dsSource, GetCurrentEntity(Of DocumentoEntradaEntity))
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
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            CursorManager.Default()
            _parent.Enabled = True
        End Try
    End Sub

#End Region

End Class
