Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.DAL.Linq

Namespace Business

    <Serializable()> Public Class DV_DoctorBEntity
        Inherits Studio.Phone.POS.BLL.PersonaBEntity


        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.POS.DAL.FactoryClasses.DV_DoctorEntityFactory
        End Function



        Public Overrides Function GetDataAsQueryable() As System.Linq.IQueryable
            Return GetDataAsQueryable(Nothing)
        End Function

        Public Overrides Function GetDataAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable
            If adapter Is Nothing Then
                adapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
            End If
            Dim db As New LinqMetaData(adapter)
            Return (From p In db.DV_Doctor Select p)
        End Function

        Public Overrides Function GetDataForComboAsQueryable() As System.Linq.IQueryable
            Return GetDataForComboAsQueryable(Nothing)
        End Function

        Public Overrides Function GetDataForComboAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable
            If adapter Is Nothing Then
                adapter = MyBase.CreateAdapter()
            End If
            Dim db As New LinqMetaData(adapter)
            Return (From p In db.DV_Doctor Select p.Id, p.Descripcion)

        End Function
    End Class

End Namespace