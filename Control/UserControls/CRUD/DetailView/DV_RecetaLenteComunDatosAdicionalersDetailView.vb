Imports Studio.Vision.POS.BLL.Business
Imports Studio.Net.Controls.New
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Net.BLL
Imports Studio.Net.Helper
Imports DevExpress.XtraEditors
Imports Studio.Vision.POS.BLL
Imports Studio.Net.Controls.New.Forms
Imports Studio.Phone.POS.Controls.New
Imports DevExpress.Data.Linq
Imports DevExpress.XtraLayout
Imports Studio.Phone.POS.Controls.New.VentaDetailView
Imports DevExpress.XtraGrid.Views.Grid

Public Class DV_RecetaLenteComunDatosAdicionalesDetailView

#Region "CTor"

    Public Sub New()

        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As DV_RecetaComunBEntity, ByVal binding As MyBindingSource)

        MyBase.New(business, binding)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub

#End Region

End Class
