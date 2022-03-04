Imports Studio.Vision.BLL
Imports Studio.Net.Controls.New
Imports Studio.Vision.BLL.Business
Imports Studio.Vision.Plugins.Telko.ADM.Business
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox
Imports Studio.Phone.DAL.EntityClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.Linq

Public Class DV_Plantilla_RepDetalleDetailView
    Public OrdenCampo
    Public strOrden As String
    Public IdPlanilla As Integer
    Protected _lockUpdate As Boolean
    Public da As IDataAccessAdapter

    Public Sub New()

        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As PlantillaRepDetalleBEntity, ByVal binding As MyBindingSource)

        MyBase.New(business, binding)

        InitializeComponent()
        Try
            IdPlanilla = GetCurrentEntity(Of DV_PlantillaReposicionDetalleEntity).PlantillaReposicionId

            da = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
            Dim db As New LinqMetaData(da)
            Dim q = (From c In db.DV_PlantillaReposicionDetalle Where c.PlantillaReposicionId = IdPlanilla Order By c.Orden Select c.Orden)

            Dim ListaNueva = q.OrderBy(Function(x) x.ToString).ToList()
            If q.Count() > 0 Then
                ' Iterate through the list.
                For Each item As String In q
                    Debug.Write(item & " ")
                    strOrden = item
                    OrdenCampo = CInt(strOrden) + 1
                    strOrden = OrdenCampo
                Next
            Else
                strOrden = 1
            End If

        Catch ex As Exception
            strOrden = 1
        End Try
        txtOrden.DataBindings.Add(New System.Windows.Forms.Binding("Text", binding, "Orden", True))
    End Sub

    Private Sub txtOrden_EnabledChanged(sender As Object, e As EventArgs) Handles txtOrden.EnabledChanged
        MyBase.OnCurrentEntityChanged(sender, e)

    End Sub

    Private Sub txtOrden_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtOrden.EditValueChanging
        'If TryCast(e.NewValue, String) = "" Then
        If TryCast(e.NewValue, String) = "0" Then
            e.NewValue = strOrden
        End If
    End Sub
    Protected Overrides Sub CreateDataBindings(bindedControls As SD.LLBLGen.Pro.ORMSupportClasses.FastDictionary(Of String, DevExpress.XtraLayout.LayoutControlItem))
        Try
            _lockUpdate = True
            MyBase.CreateDataBindings(bindedControls)
        Finally
            _lockUpdate = False
        End Try
    End Sub

    Protected Overrides Sub BindControls()
        MyBase.BindControls()
        txtOrden.Enabled = False
    End Sub
End Class
