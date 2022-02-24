Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Net.BLL
Imports Studio.Phone.DAL
Imports Studio.Phone.BLL

Namespace Business
    <Serializable()> Public Class DV_DocumentoSalida
        Inherits Studio.Phone.BLL.DocumentoSalidaBEntity

        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function CrearBusinessParaListView() As DocumentoSalidaBEntity

            Dim toReturn As New DocumentoSalidaBEntity
            Dim fNames As String() = New String() {DV_RecetaFieldIndex.DocumentoTipoId.ToString(), _
                                       DV_RecetaFieldIndex.NumeroDocumento.ToString(), _
                                       DV_RecetaFieldIndex.ClienteId.ToString(), _
                                       DV_RecetaFieldIndex.FechaEmitida.ToString(), _
                                       DV_RecetaFieldIndex.FechaVencimiento.ToString() _
                                       }

            For Each item As BEField In toReturn.Fields
                item.Displayable = Array.IndexOf(fNames, item.Name) >= 0
            Next

            Return toReturn

        End Function

        Public Shared Function CrearSortParaListView() As SortExpression
            Dim toReturn As New SortExpression(New SortClause(DocumentoSalidaFields.RId, SortOperator.Descending))
            Return toReturn
        End Function

        Protected Overrides Sub CreateFields()
            MyBase.CreateFields()

            Dim fNames As String() = New String() {DV_RecetaFieldIndex.DocumentoTipoId.ToString(), _
                                                   DV_RecetaFieldIndex.NumeroDocumento.ToString(), _
                                                   DV_RecetaFieldIndex.ClienteId.ToString(), _
                                                   DV_RecetaFieldIndex.FechaEmitida.ToString(), _
                                                   DV_RecetaFieldIndex.FechaVencimiento.ToString() _
                                                   }

            For Each item As BEField In Fields
                item.Displayable = Array.IndexOf(fNames, item.Name) >= 0
            Next
        End Sub

    End Class

End Namespace