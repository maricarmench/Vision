Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.DAL.Linq

Namespace Business
    <Serializable()> Public Class DV_RecetaTipoBEntity
        Inherits Studio.Net.BLL.BEntityBase

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub CreateFields()
            MyBase.CreateFields()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.POS.DAL.FactoryClasses.DV_RecetaTipoEntityFactory
        End Function

        Public Shared Function GetById(Id As Integer) As DV_RecetaTipoEntity
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
                Return GetById(da, Id)
            End Using
        End Function

        Public Shared Function GetById(da As IDataAccessAdapter, Id As Integer) As DV_RecetaTipoEntity
            Dim db As New LinqMetaData(da)
            Return (From r In db.DV_RecetaTipo Where r.Id = Id Select r).Single()
        End Function

        Public Shared Function TipoEsSegundoPar(Id As Integer) As Boolean
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
                Dim db As New LinqMetaData(da)
                Return (From r In db.DV_RecetaTipo Where r.Id = Id Select r.CercaEsSegundoPar).Single()
            End Using
        End Function

    End Class

End Namespace