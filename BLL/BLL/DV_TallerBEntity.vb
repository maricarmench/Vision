Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.DAL.Linq
Imports Studio.Net.BLL

Namespace Business

    <Serializable()> Public Class DV_TallerBEntity
        Inherits Studio.Net.BLL.BEntityBase
        Implements IBEntityQueryable

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.DAL.FactoryClasses.DV_TallerEntityFactory
        End Function

        Public Function GetDataAsQueryable() As System.Linq.IQueryable Implements IBEntityQueryable.GetDataAsQueryable
            Return GetDataAsQueryable(Nothing)
        End Function

        Public Function GetDataAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable Implements IBEntityQueryable.GetDataAsQueryable
            If adapter Is Nothing Then
                adapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
            End If
            Dim db As New LinqMetaData(adapter)
            Return (From p In db.DV_Taller Select p)
        End Function

        Public Function GetDataForComboAsQueryable() As System.Linq.IQueryable Implements IBEntityQueryable.GetDataForComboAsQueryable
            Return GetDataForComboAsQueryable(Nothing)
        End Function

        Public Function GetDataForComboAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable Implements IBEntityQueryable.GetDataForComboAsQueryable
            If adapter Is Nothing Then
                adapter = MyBase.CreateAdapter()
            End If
            Dim db As New LinqMetaData(adapter)
            Return (From p In db.DV_Taller Select p.Id, p.Descripcion)

        End Function
    End Class

End Namespace