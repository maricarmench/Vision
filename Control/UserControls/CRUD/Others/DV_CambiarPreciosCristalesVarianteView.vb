Imports Studio.Phone.BLL
Imports Studio.Phone.DAL
Imports DevExpress.XtraEditors
Imports Studio.Net.BLL
Imports Studio.Net.Controls.New
Imports Studio.Vision.BLL.Business
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Net.Helper
Imports Studio.Vision.BLL
Imports Studio.Net.Controls.New.Forms
Imports DevExpress.XtraPivotGrid

Public Class DV_CambiarPreciosCristalesVarianteView

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ConfigParametros()

    End Sub

    Public Sub New(articuloId As Integer)
        MyBase.New()

        InitializeComponent()


        cboArticuloId.EditValue = articuloId

        ConfigParametros()
    End Sub

    Private Sub ConfigParametros()

        lqsmsListaPreVenta.QueryableSource = (New ListaPreVtaBEntity).GetDataForComboSoloMadresAsQueryable()
        lqsmsMoneda.QueryableSource = (New MonedaBEntity).GetDataForComboAsQueryable()
        matrixView.btnAddCristal.Enabled = False

    End Sub


    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click

        Try
            If DatosOk() Then
                CursorManager.WaitCursor()
                Enabled = False
                Dim data As CristalesMatrixData = DV_CristalBEntity.GetMatrixData(ListaPreVtaLinBEntity.GetByListaArticuloYMoneda(CInt(cboListaPreVtaId.EditValue), CInt(cboMonedaId.EditValue), CInt(cboArticuloId.EditValue)))
                matrixView.Clear()
                matrixView.ValorFormat = "{0:n2}"
                If data.Cristales.Count = 0 Then
                    matrixView.SetDataSource(data)
                    matrixView.AddNewArticulo(CInt(cboArticuloId.EditValue))
                End If
                matrixView.LoadData(data)
                Dim grid As PivotGridControl = matrixView.tabControl.SelectedTabPage.Controls(0)
                Dim style As New PivotGridStyleFormatCondition() With {.ApplyToCell = True, .Expression = "IsChanged = True", .Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression}
                style.Appearance.Font = New Font(PivotGridControl.DefaultFont, FontStyle.Bold)

                grid.FormatConditions.Add(style)
                ChangeViewMode(ViewMode.Actualizar)
            End If

        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            Enabled = True
            CursorManager.Default()
        End Try

    End Sub

    Private Function DatosOk() As Boolean
        If cboArticuloId.EditValue Is Nothing Then
            MyMsgBox.Show("Debe seleccionar el artículo.", MsgBoxStyle.Exclamation)
            Return False
        End If
        If cboListaPreVtaId.EditValue Is Nothing Then
            MyMsgBox.Show("Debe seleccionar la lista de precios.", MsgBoxStyle.Exclamation)
            Return False
        End If
        If cboMonedaId.EditValue Is Nothing Then
            MyMsgBox.Show("Debe seleccionar la moneda.", MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Try
            CursorManager.WaitCursor()
            ShowWaitForm("Actualizando precios")
            Enabled = False
            Dim data As CristalesMatrixData = matrixView.GetDataSource()
            DV_CristalBEntity.SaveMatrixData(data, CInt(cboListaPreVtaId.EditValue), CInt(cboMonedaId.EditValue), CInt(cboArticuloId.EditValue))
            ChangeViewMode(ViewMode.Consulta)
        Catch ex As EntitiesValidationException
            CloseWaitForm()
            ShowErrors(ex.InvalidEntities)
        Catch ex As ORMEntityValidationException
            CurrentEntity.SetEntityError(ex.Message)
            CloseWaitForm()
            ShowErrors(CurrentEntity)
        Catch ex As Exception
            CloseWaitForm()
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseWaitForm()
            Enabled = True
            CursorManager.Default()
        End Try
    End Sub

    Private Sub ShowWaitForm(ByVal message As String)
        Dim form As MainFormBase = TryCast(FindForm().Owner, MainFormBase)
        If form IsNot Nothing Then
            form.ShowWaitForm(message)
        End If
    End Sub
    Private Sub CloseWaitForm()
        Dim form As MainFormBase = TryCast(FindForm().Owner, MainFormBase)
        If form IsNot Nothing Then
            form.CloseWaitForm()
        End If
    End Sub

    Private Sub parametros_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboArticuloId.EditValueChanged, cboMonedaId.EditValueChanged, cboListaPreVtaId.EditValueChanged
        ChangeViewMode(ViewMode.Consulta)
    End Sub

    Private Enum ViewMode
        Consulta
        Actualizar
    End Enum

    Private Sub ChangeViewMode(ByVal view As ViewMode)

        If view = ViewMode.Consulta Then
            matrixView.Clear()
            matrixView.Enabled = False
            btnGuardar.Enabled = False
        Else
            matrixView.Enabled = True
            btnGuardar.Enabled = True
        End If

    End Sub


    Private Sub lqifsArticulo_DismissQueryable(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles lqifsArticulo.DismissQueryable
        DirectCast(e.Tag, IDataAccessAdapter).Dispose()
    End Sub

    Private Sub lqifsArticulo_GetQueryable(ByVal sender As System.Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles lqifsArticulo.GetQueryable
        Dim da As IDataAccessAdapter
        e.QueryableSource = DV_CristalBEntity.GetQueryableForCristalesGuiaDeVariante(da)
        e.Tag = da
    End Sub

End Class
