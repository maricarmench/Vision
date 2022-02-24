Imports DevExpress.XtraGrid.Columns
Imports Studio.Net.BLL
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL

Public Class GridTest

    Private Sub GridTest_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim fields As New List(Of IBEField)
        fields.Add((New ArticuloBEntity).Fields(ArticuloFieldIndex.Descripcion.ToString()))
        fields.Add((New RubroBEntity).Fields(RubroFieldIndex.Descripcion.ToString()))
        MyDXGrid1.BindGridFromBusiness()

    End Sub

End Class