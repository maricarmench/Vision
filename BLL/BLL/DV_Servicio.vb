Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.Linq


Namespace Business

    <Serializable()> Public Class DV_ServicioBEntity
        Inherits Studio.Phone.BLL.ArticuloBEntity

        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function CrearFiltroPorServicio() As IRelationPredicateBucket
            Return New RelationPredicateBucket(ArticuloFields.ArticuloClaseId = ArticuloClase.ServicioCristal)
        End Function

        Public Overrides Function GetDataForComboAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable
            If adapter Is Nothing Then
                adapter = CreateAdapter()
            End If
            Dim db As New LinqMetaData(adapter)
            Return (From a In db.Articulo Where a.ArticuloClaseId = ArticuloClase.ServicioCristal Select a.Id, a.Descripcion)
        End Function

        Public Shared Function GetDataFormComboForRecetaAsQueryable(ByRef da As IDataAccessAdapter, materialId As Integer, localId As Integer, listaPreVentaId As Integer) As IQueryable
            If da Is Nothing Then
                da = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
            End If
            Dim db As New LinqMetaData(da)
            Dim q = (From s In db.Articulo Where s.ArticuloClaseId = ArticuloClase.ServicioCristal AndAlso s.Activo = True AndAlso s.Vendible = True AndAlso
                (From l In s.Locales Where l.LocalId = localId AndAlso l.Activo = True).Any() AndAlso
                (From l In s.Servicios Where l.ListaPrecioVentaId = listaPreVentaId AndAlso l.CristalMaterialId = materialId).Any() Select s.Id, s.Descripcion Order By Descripcion)
            'Dim i As Integer = q.ToList().Count
            Return q
        End Function


    End Class

End Namespace