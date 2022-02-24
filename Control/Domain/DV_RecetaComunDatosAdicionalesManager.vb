Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Vision.BLL.Business
Imports Studio.Net.Controls.New
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Net.Controls.New.Forms
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.Controls.New

Public Class DV_RecetaComunDatosAdicionalesManager
    Implements IWorkFlowManager, IDisposable

    Private _workFlow As WorkFlowEntity
    Private _relation As WorkFlowStepRelationEntity


    Public Function ApplyWorkFlowStepChange(owner As IWin32Window, workFlow As Phone.DAL.EntityClasses.WorkFlowEntity, IDs As System.Collections.Generic.List(Of Integer), workFlowStepRelation As Phone.DAL.EntityClasses.WorkFlowStepRelationEntity) As Boolean Implements IWorkFlowManager.ApplyWorkFlowStepChange

        If IDs.Count > 1I Then
            Throw New InvalidOperationException("Debe seleccionar un solo registro.")
        End If

        _workFlow = workFlow
        _relation = workFlowStepRelation

        Dim receta As DV_RecetaComunEntity = DV_RecetaComunBEntity.GetByRId(IDs(0))

        Using binding As New MyBindingSource()

            binding.DataSource = New EntityCollection(Of DV_RecetaComunEntity)(New DV_RecetaComunEntity() {receta})

            Using detail As New DV_RecetaComunDatosTallerDetailView(DV_RecetaComunBEntity.CrearBusinessParaDatosTaller(), binding)
                Using f As New Studio.Net.Controls.[New].Forms.SaveDeleteGenericDialog(detail)
                    Try
                        f.ClientSize = New Size(528, 319)
                        detail.OnAddingToContainer()
                        AddHandler f.OnSave, AddressOf OnSaveClicked
                        f.AllowDelete = False
                        f.SaveVisible = False
                        f.StartPosition = FormStartPosition.CenterScreen
                        Dim ok As Boolean = f.ShowDialog(owner) = DialogResult.OK
                        Return ok
                    Finally
                        RemoveHandler f.OnSave, AddressOf OnSaveClicked

                    End Try
                End Using
            End Using

        End Using

    End Function

    Private Sub OnSaveClicked(sender As Object, e As System.ComponentModel.CancelEventArgs)

        Try

            Dim form As SaveDeleteGenericDialog = DirectCast(sender, SaveDeleteGenericDialog)
            Dim view As DV_RecetaComunDatosTallerDetailView = DirectCast(form.DataView, DV_RecetaComunDatosTallerDetailView)
            view.Control2Entity()

            Dim receta As DV_RecetaComunEntity = TryCast(view.BindingSource.CurrentEntity, DV_RecetaComunEntity)
            DV_RecetaComunBEntity.SaveEdicionReceta(receta, _relation)

        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            e.Cancel = True
        End Try

    End Sub



#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


End Class
