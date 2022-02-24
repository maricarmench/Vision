Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL.Linq


Namespace Business

    <Serializable()> Public Class DV_Armazon
        Inherits Studio.Phone.POS.BLL.ArticuloBEntity

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
            Return (From a In db.Articulo Where a.Activo = True AndAlso a.Vendible = True AndAlso
                    a.GuiaDeVariante = False AndAlso (CajaId = 0 OrElse (From l In a.Locales Where (From cj In l.Local.Caja Where cj.Id = CajaId).Any() AndAlso l.Activo = True).Any()) AndAlso
                    a.ArticuloClaseId = CInt(ArticuloClase.ArmazonLente) AndAlso (ListaPreVtaId = 0 OrElse (From p In a.PreciosDeVenta Where p.ListaPrecioVentaId = ListaPreVtaId).Any())
                    Select a.Id, a.Descripcion)

        End Function

        Public Function GetDataForComboAsQueryableMarca(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, marcaId As Integer, Optional soloWeb As Boolean = False) As System.Linq.IQueryable(Of MarcaEntity)

            If adapter Is Nothing Then
                adapter = CreateAdapter()
            End If

            Dim db As New LinqMetaData(adapter)
            Dim q = (From a In db.Articulo Where a.Activo = True AndAlso a.Vendible = True AndAlso
                    a.GuiaDeVariante = False AndAlso (CajaId = 0 OrElse (From l In a.Locales Where (From cj In l.Local.Caja Where cj.Id = CajaId).Any() AndAlso l.Activo = True).Any()) AndAlso
                    a.ArticuloClaseId = CInt(ArticuloClase.ArmazonLente) AndAlso (ListaPreVtaId = 0 OrElse (From p In a.PreciosDeVenta Where p.ListaPrecioVentaId = ListaPreVtaId).Any()))
            If soloWeb Then
                q = (From a In q Where a.PublicableWeb = True Select a)
            End If

            'Todas las marcas que tengan al menos un artículo de clase Armazón
            Return (From m In db.Marca Where q.Where(Function(f) f.MarcaId = m.Id).Any() Select m Order By m.Descripcion)


        End Function

        Public Function GetDataForComboAsQueryableNonGeneric(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, Optional soloWeb As Boolean = False) As System.Linq.IQueryable(Of ArticuloEntity)

            If adapter Is Nothing Then
                adapter = CreateAdapter()
            End If

            Dim db As New LinqMetaData(adapter)
            Dim q = (From a In db.Articulo Where a.Activo = True AndAlso a.Vendible = True AndAlso
                    a.GuiaDeVariante = False AndAlso (CajaId = 0 OrElse (From l In a.Locales Where (From cj In l.Local.Caja Where cj.Id = CajaId).Any() AndAlso l.Activo = True).Any()) AndAlso
                    a.ArticuloClaseId = CInt(ArticuloClase.ArmazonLente) AndAlso (ListaPreVtaId = 0 OrElse (From p In a.PreciosDeVenta Where p.ListaPrecioVentaId = ListaPreVtaId).Any()))
            If soloWeb Then
                q = (From a In q Where a.PublicableWeb = True Select a)
            End If
            Return (From a In q Select a Order By a.Descripcion)

        End Function

        Public Function GetDataForComboAsQueryablePorMarca(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, marcaId As Integer, Optional soloWeb As Boolean = False) As System.Linq.IQueryable
            Dim q As IQueryable(Of ArticuloEntity) = GetDataForComboAsQueryableNonGeneric(adapter, soloWeb)
            Return (From a In q Where a.MarcaId = marcaId Select a.Id, a.Descripcion, a.DescripcionCorta)
        End Function


        Public Property ListaPreVtaId As Integer
        Public Property CajaId As Integer

    End Class

End Namespace