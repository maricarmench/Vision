Imports Studio.Vision.BLL
Imports Studio.Net.Controls.New
Imports Studio.Vision.BLL.Business

Public Class DV_TallerDetailView

#Region "CTor"

    Public Sub New()

        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As DV_TallerBEntity, ByVal binding As MyBindingSource)

        MyBase.New(business, binding)

        InitializeComponent()

    End Sub
#End Region

#Region "Eventos de acción"

    Private Sub chkTallerPropio_CheckedChanged(sender As Object, e As EventArgs) Handles chkTallerPropio.CheckedChanged
        LayoutControl.GetItemByControl(cboDepositoId).Visibility = IIf(chkTallerPropio.Checked, DevExpress.XtraLayout.Utils.LayoutVisibility.Always, DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
        'cboDepositoId.Visible = chkTallerPropio.Checked

        'LayoutControl.Refresh()
    End Sub

#End Region

End Class
