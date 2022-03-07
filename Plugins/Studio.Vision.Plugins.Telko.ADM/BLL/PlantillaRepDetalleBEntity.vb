Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.DAL.Linq
Imports Studio.Net.BLL

Namespace Business
    <Serializable()> Public Class PlantillaRepDetalleBEntity
        Inherits BEntityBase
        Public Sub New()
            MyBase.New()
        End Sub
        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.DAL.FactoryClasses.DV_PlantillaReposicionDetalleEntityFactory
        End Function

        Public Overrides Function SaveEntity(da As IDataAccessAdapter, entity As IEntity2) As Boolean
            Dim plantila As DV_PlantillaReposicionEntity = DirectCast(entity, DV_PlantillaReposicionEntity)
            If plantila.Id = 0 Then
                If da Is Nothing Then
                    da = CreateAdapter(True)
                End If
                plantila.Id = ProximoId(da)
            End If
            Return MyBase.SaveEntity(da, entity)
        End Function

        Private Function ProximoId(da As IDataAccessAdapter) As Integer
            Dim db As New LinqMetaData(da)
            Return (From p In db.DV_PlantillaReposicionDetalle Select p.Id).Max() + 1
        End Function
    End Class

End Namespace
