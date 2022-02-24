Imports Studio.Phone.BLL
Imports Studio.Phone.DAL
Imports DevExpress.XtraGrid.Columns

Public Class DV_VentaListView



#Region "CTor"

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = True

    End Sub

    Public Sub New(ByVal business As DocumentoSalidaBEntity)
        MyBase.New(business)

        InitializeComponent()

        'MyDXGridView.SortInfo.Add(MyDXGridView.Columns(DocumentoSalidaFieldIndex.RId.ToString()), DevExpress.Data.ColumnSortOrder.Descending)

    End Sub

    Protected Overrides Sub BindGridInternal()
        MyBase.BindGridInternal()
        'MyDXGridView.Columns(DocumentoSalidaFieldIndex.RId.ToString()).SortOrder = DevExpress.Data.ColumnSortOrder.Descending

        Dim cInfo As GridColumnSortInfo = MyDXGridView.SortInfo.Add(MyDXGridView.Columns(DocumentoSalidaFieldIndex.RId.ToString()), DevExpress.Data.ColumnSortOrder.Descending)
        MyDXGridView.Columns(DocumentoSalidaFieldIndex.RId.ToString()).SortMode = DevExpress.XtraGrid.ColumnSortMode.Value

    End Sub

#End Region


End Class
