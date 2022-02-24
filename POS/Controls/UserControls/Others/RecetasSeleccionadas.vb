Imports DevExpress.XtraGrid.Columns
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL

Public Class RecetasSeleccionadas

    Public Sub New(ds As ICollection)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        grd.DataSource = ds
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        ConfigGrid()

    End Sub

    Private Sub ConfigGrid()

        Dim formater As New Studio.Net.Controls.[New].DevGridFormater(gView)
        formater.Format(New DocumentoSalidaBEntity)
        Dim fields As String() = New String() {DocumentoSalidaFieldIndex.DocumentoTipoId.ToString(), DocumentoSalidaFieldIndex.NumeroDocumento.ToString(), DocumentoSalidaFieldIndex.ImporteTotal.ToString()}
        For Each col As GridColumn In gView.Columns
            col.Visible = fields.Contains(col.FieldName)
        Next
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        With FindForm()
            .DialogResult = DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        With FindForm()
            .DialogResult = DialogResult.Cancel
            .Close()
        End With
    End Sub
End Class
