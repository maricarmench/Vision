Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports SD.LLBLGen.Pro.LinqSupportClasses
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.DAL.Linq
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL
Imports System.Linq

Namespace Business

    <Serializable()> Public Class DV_CristalPlantillaBEntity
        Inherits Studio.Phone.POS.BLL.PersonaBEntity


        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.POS.DAL.FactoryClasses.DV_CristalPlantillaEntityFactory
        End Function

        Public Overrides Function GetDataAsQueryable() As System.Linq.IQueryable
            Return GetDataAsQueryable(Nothing)
        End Function

        Public Overrides Function GetDataAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable
            If adapter Is Nothing Then
                adapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
            End If
            Dim db As New LinqMetaData(adapter)
            Return (From p In db.DV_CristalPlantilla Select p)
        End Function

        Public Overrides Function GetDataForComboAsQueryable() As System.Linq.IQueryable
            Return GetDataForComboAsQueryable(Nothing)
        End Function

        Public Overrides Function GetDataForComboAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable
            If adapter Is Nothing Then
                adapter = MyBase.CreateAdapter()
            End If
            Dim db As New LinqMetaData(adapter)
            Return (From p In db.DV_CristalPlantilla Select p.ID, p.Descripcion)

        End Function


        Public Shared Function GetDescripcion(ByVal Id As Integer) As String
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
                Return GetDescripcion(da, Id)
            End Using
        End Function

        Public Shared Function GetDescripcion(ByVal da As IDataAccessAdapter, ByVal Id As Integer) As String
            Dim db As New LinqMetaData(da)
            Return (From c In db.DV_CristalPlantilla Where c.ID = Id Select c.Descripcion).Single()
        End Function

        Public Shared Function GetById(ByVal Id As Integer) As DV_CristalPlantillaEntity
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
                Return GetById(da, Id)
            End Using
        End Function

        Public Shared Function GetById(ByVal da As IDataAccessAdapter, ByVal Id As Integer) As DV_CristalPlantillaEntity
            Return GetById(da, Id, Nothing)
        End Function

        Public Shared Function GetById(ByVal da As IDataAccessAdapter, ByVal Id As Integer, ByVal prefetch As IPrefetchPath2) As DV_CristalPlantillaEntity

            Dim db As New LinqMetaData(da)
            Dim q = (From p In db.DV_CristalPlantilla Where p.ID = Id Select p)

            If prefetch IsNot Nothing Then
                q.WithPath(prefetch)
            End If

            Return q.SingleOrDefault()

        End Function

        Public Shared Function CrearPrefetchPorPlantillas() As IPrefetchPath2
            Dim toReturn As New PrefetchPath2(CInt(EntityType.DV_CristalPlantillaEntity))
            toReturn.Add(DV_CristalPlantillaEntity.PrefetchPathAAtributoPlantilla1)
            toReturn.Add(DV_CristalPlantillaEntity.PrefetchPathAAtributoPlantilla2)
            Return toReturn
        End Function

        Public Shared Function GetValoresDeRango(ByVal da As IDataAccessAdapter, ByVal template As DV_CristalPlantillaEntity, ByVal primerAtributo As Boolean) As DataTable
            Return (New AAtributoPlantillaBEntity).GetDataForCombo(CrearFiltroPorRango(da, template, primerAtributo))
        End Function

        Public Shared Function CrearFiltroPorRango(ByVal da As IDataAccessAdapter, ByVal template As DV_CristalPlantillaEntity, ByVal primerAtributo As Boolean) As IRelationPredicateBucket

            Dim fieldToCompare As IEntityField2 = Nothing
            Dim min As Decimal = Decimal.Zero
            Dim max As Decimal = Decimal.Zero
            If primerAtributo Then
                fieldToCompare = AAtributoPlantillaValorBEntity.GetFieldFromPlantilla(AAtributoPlantillaBEntity.GetById(da, template.AAtributoPlantillaID1))
                min = template.AAtributoPlantilla1Minimo
                max = template.AAtributoPlantilla1Maximo
            Else
                fieldToCompare = AAtributoPlantillaValorBEntity.GetFieldFromPlantilla(AAtributoPlantillaBEntity.GetById(da, template.AAtributoPlantillaID2))
                min = template.AAtributoPlantilla2Minimo
                max = template.AAtributoPlantilla2Maximo
            End If

            Return New RelationPredicateBucket(New FieldBetweenPredicate(fieldToCompare, Nothing, min, max))

        End Function

        Public Shared Function GetValoresRango1(ByVal template As DV_CristalPlantillaEntity) As List(Of Decimal)
            Dim toReturn As New List(Of Decimal)
            Dim valor As Decimal = template.AAtributoPlantilla1Minimo
            Do
                toReturn.Add(valor)
                valor += template.AAtributoPlantilla1Intervalo
            Loop Until valor > template.AAtributoPlantilla1Maximo
            Return toReturn
        End Function

        Public Shared Function GetValoresRango2(ByVal template As DV_CristalPlantillaEntity) As List(Of Decimal)
            Dim toReturn As New List(Of Decimal)
            Dim valor As Decimal = template.AAtributoPlantilla2Minimo
            Do
                toReturn.Add(valor)
                valor += template.AAtributoPlantilla2Intervalo
            Loop Until valor > template.AAtributoPlantilla2Maximo
            Return toReturn

        End Function


        Public Shared Function GetValoresRango1(articuloId As Integer, template As DV_CristalPlantillaEntity) As List(Of Decimal)
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                Dim db As New LinqMetaData(da)
                'Dim res=(From c In db.DV_Cristal Join  v In db.ArticuloVariante_Combinacion On c.Id Equals v.ArticuloId Join av In db.AAtributoPlantillaValor On v.AAtributoPlantillaValorID Equals av.ID
                '         Where c.ArticuloIdGuia=articuloId AndAlso av.AAtributoPlantillaID=template.AAtributoPlantillaID1
                Dim valores As List(Of Decimal) = (From c In db.DV_Cristal Join v In db.ArticuloVariante_Combinacion On c.Id Equals v.ArticuloId Join av In db.AAtributoPlantillaValor On v.AAtributoPlantillaValorID Equals av.ID
                         Where c.ArticuloIdGuia = articuloId AndAlso v.AAtributoPlantillaID = template.AAtributoPlantillaID1 _
                         Select av.ValorDecimal).ToList()

                Dim desde As Decimal = valores.Min()
                Dim hasta As Decimal = valores.Max()
                Dim toReturn As New List(Of Decimal)
                Dim valor As Decimal = desde
                Do
                    toReturn.Add(valor)
                    valor += template.AAtributoPlantilla1Intervalo
                Loop Until valor > hasta
                Return toReturn

            End Using

        End Function


        Public Shared Function GetValoresRango2(articuloId As Integer, template As DV_CristalPlantillaEntity) As List(Of Decimal)
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                Dim db As New LinqMetaData(da)
                'Dim res=(From c In db.DV_Cristal Join  v In db.ArticuloVariante_Combinacion On c.Id Equals v.ArticuloId Join av In db.AAtributoPlantillaValor On v.AAtributoPlantillaValorID Equals av.ID
                '         Where c.ArticuloIdGuia=articuloId AndAlso av.AAtributoPlantillaID=template.AAtributoPlantillaID1
                Dim valores As List(Of Decimal) = (From c In db.DV_Cristal Join v In db.ArticuloVariante_Combinacion On c.Id Equals v.ArticuloId Join av In db.AAtributoPlantillaValor On v.AAtributoPlantillaValorID Equals av.ID
                         Where c.ArticuloIdGuia = articuloId AndAlso v.AAtributoPlantillaID = template.AAtributoPlantillaID2 _
                         Select av.ValorDecimal).ToList()

                Dim desde As Decimal = valores.Min()
                Dim hasta As Decimal = valores.Max()
                Dim toReturn As New List(Of Decimal)
                Dim valor As Decimal = desde
                Do
                    toReturn.Add(valor)
                    valor += template.AAtributoPlantilla1Intervalo
                Loop Until valor > hasta
                Return toReturn

            End Using

        End Function



    End Class


End Namespace