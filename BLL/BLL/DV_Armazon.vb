Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.Linq


Namespace Business

    <Serializable()> Public Class DV_ArmazonBEntity
        Inherits Studio.Phone.BLL.ArticuloBEntity

        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function CrearFiltroPorArmazon() As IRelationPredicateBucket
            Return New RelationPredicateBucket(ArticuloFields.ArticuloClaseId = ArticuloClase.ArmazonLente)
        End Function

        Public Overrides Function GetDataForComboAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable
            If adapter Is Nothing Then
                adapter = CreateAdapter()
            End If
            Dim db As New LinqMetaData(adapter)
            Return (From a In db.Articulo Where a.ArticuloClaseId = ArticuloClase.ArmazonLente Select a.Id, a.Descripcion)
        End Function

    End Class

End Namespace