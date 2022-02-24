Imports Studio.Net.Controls.New
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Phone.DAL.EntityClasses

Public Class DV_BonificacionDinamicaParametros
    Inherits BonificacionDinamicaParametros

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Sub ShowIds(parametro As BonificacionDinamicaParametroEntity)
        Try
            Studio.Net.Helper.CursorManager.WaitCursor()

            Using f As New DV_BonificacionDinamicaMain(parametro)
                If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    CargarDatos(False)
                End If
            End Using

        Catch ex As Exception
            LogError.Publish(ex)
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            Studio.Net.Helper.CursorManager.Default()

        End Try
    End Sub
End Class
