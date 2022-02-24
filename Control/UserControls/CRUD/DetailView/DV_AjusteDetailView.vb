Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Vision.BLL
Imports Studio.Vision.BLL.Business
Imports Studio.Net.Controls.New.Forms
Imports Studio.Net.Helper
Imports Studio.Net.Controls.New
Imports Studio.Phone.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses

Public Class DV_AjusteDetailView

#Region "CTor"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As AjusteBEntity, ByVal binding As BindingSource)

        MyBase.New(business, binding)

        InitializeComponent()
    End Sub

#End Region

#Region "Eventos de acción"

    Private Sub OnGetQueryableForArticulo(ByVal sender As Object, ByVal e As CristalMatrixView.MatrixViewGetQueryableEvenArgs)
        e.QueryableSource = DV_CristalBEntity.GetQueryableForCristalesGuiaDeVariante(e.Adapter, CInt(cboDepositoId.EditValue))
        e.Handled = True
    End Sub

    Private Sub OnProcessGridKey(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.F11 AndAlso CurrentEntity.IsNew AndAlso cboDepositoId.EditValue IsNot Nothing Then
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

    Private Sub ShowCristalForm()

        Try

            CursorManager.WaitCursor()
            If _parent IsNot Nothing Then
                _parent.Enabled = False
            End If
            Dim dsSource As CristalesMatrixData = DV_CristalBEntity.GetMatrixData(GetCurrentEntity(Of AjusteEntity).Detalles)
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
                            DV_CristalBEntity.UpdateMatrixData(dsSource, GetCurrentEntity(Of AjusteEntity).Detalles)
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
