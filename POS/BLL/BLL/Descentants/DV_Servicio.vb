Imports Studio.Phone.POS.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.Linq

Public Class DV_ServicioBEntity
    Inherits ArticuloBEntity

    Public Sub New()
        MyBase.New()
        SysFilterExpression = CrearFiltroPorServicio()
    End Sub

    Public Shared Function CrearFiltroPorServicio() As IRelationPredicateBucket
        Return New RelationPredicateBucket(ArticuloFields.ArticuloClaseId = ArticuloClase.ServicioCristal)
    End Function

    Public Shared Function GetDataFormComboForRecetaAsQueryable(ByRef da As IDataAccessAdapter, materialId As Integer, materialId2 As Integer, localId As Integer, listaPreVentaId As Integer) As IQueryable
        If da Is Nothing Then
            da = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
        End If
        Dim db As New LinqMetaData(da)
        Dim q = (From s In db.Articulo Where s.ArticuloClaseId = ArticuloClase.ServicioCristal AndAlso s.Activo = True AndAlso s.Vendible = True AndAlso
                (From l In s.Locales Where l.LocalId = localId AndAlso l.Activo = True).Any() AndAlso
                (From l In s.Servicios Where l.ListaPrecioVentaId = listaPreVentaId AndAlso l.CristalMaterialId = materialId AndAlso l.CristalMaterialId = materialId2).Any() Select s.Id, s.Descripcion Order By Descripcion)
        'Dim i As Integer = q.ToList().Count
        Return q
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

    Public Shared Function GetDataFormComboForReceta(materialId As Integer, localId As Integer, listaPreVentaId As Integer) As DataTable
        Return (New DV_ServicioBEntity).GetDataForCombo(CrearFiltroForReceta(materialId, localId, listaPreVentaId))
    End Function

    Public Shared Function CrearFiltroForReceta(materialId As Integer, localId As Integer, listaPreVentaId As Integer) As IRelationPredicateBucket
        Dim toReturn As New RelationPredicateBucket '= CrearFiltroPorServicio()
        toReturn.PredicateExpression.Add(ArticuloFields.Activo = True And ArticuloFields.Vendible = True)

        Dim filtroLocal As New PredicateExpression(Articulo_LocalFields.LocalId = localId And Articulo_LocalFields.Activo = True And Articulo_LocalFields.ArticuloId = ArticuloFields.Id)
        toReturn.PredicateExpression.Add(New FieldCompareSetPredicate(ArticuloFields.Descripcion, Nothing, Articulo_LocalFields.ArticuloId, Nothing, SetOperator.Exist, filtroLocal))

        Dim filtroLista As New PredicateExpression(ArticuloFields.Id = ListaPreVtaLinFields.ArticuloId And ListaPreVtaLinFields.ListaPrecioVentaId = listaPreVentaId)
        toReturn.PredicateExpression.Add(New FieldCompareSetPredicate(ArticuloFields.Descripcion, Nothing, ListaPreVtaLinFields.ArticuloId, Nothing, SetOperator.Exist, filtroLista))
        Return toReturn

    End Function

    Public Overrides Function GetDataForComboAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable

        If adapter Is Nothing Then
            adapter = CreateAdapter()
        End If
        Dim db As New LinqMetaData(adapter)
        Return (From a In db.Articulo Where a.ArticuloClaseId = CInt(ArticuloClase.ServicioCristal) Select a.Id, a.Descripcion, a.DescripcionVariante)

    End Function
End Class
