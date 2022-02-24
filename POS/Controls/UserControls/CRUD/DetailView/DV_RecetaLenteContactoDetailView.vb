Imports System.Data.Linq
Imports Studio.Net.Controls.[New]
Imports Studio.Vision.POS.BLL
Imports Studio.Vision.POS.BLL.Business

Public Class DV_RecetaLenteContactoDetailView

#Region "CTor"

    Public Sub New()

        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As DV_RecetaBEntity, ByVal binding As MyBindingSource)

        MyBase.New(business, binding)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region


    Private Sub ConfigDetail()
        rgTipoOperacion.BindFromEnum(GetType(RecetaComunOperacion))
        If True Then
            Dim a As New Studio.Phone.POS.DAL.EntityClasses.DV_RecetaComunEntity

        End If
    End Sub

End Class
