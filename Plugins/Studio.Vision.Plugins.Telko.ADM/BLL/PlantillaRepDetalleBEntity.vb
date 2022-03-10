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
            Return New MyPlantillaReposicionDetalleEntityFactory
            'Return New Studio.Phone.DAL.FactoryClasses.DV_PlantillaReposicionDetalleEntityFactory
        End Function
        Public Overrides Function CreateEmptyEntity() As IEntity2
            Return MyBase.CreateEmptyEntity()
        End Function
        Public Overrides Function SaveEntity(da As IDataAccessAdapter, entity As IEntity2) As Boolean
            If da Is Nothing Then
                da = CreateAdapter(True)
            End If
            Dim plantila As DV_PlantillaReposicionDetalleEntity = DirectCast(entity, DV_PlantillaReposicionDetalleEntity)
            If plantila.Id <= 0 Then
                plantila.Id = ProximoId(da)
            End If
            If plantila.Orden <= 0 Then
                plantila.Orden = ProximoOrden(da)
            End If
            Return MyBase.SaveEntity(da, entity)
        End Function

        Private Function ProximoId(da As IDataAccessAdapter) As Integer
            Dim db As New LinqMetaData(da)
            Return (From p In db.DV_PlantillaReposicionDetalle Select p.Id).Max() + 1
        End Function
        Private Function ProximoOrden(da As IDataAccessAdapter) As Integer
            Dim db As New LinqMetaData(da)
            Return (From p In db.DV_PlantillaReposicionDetalle Select p.Orden).Max() + 1
        End Function

    End Class



    Public Class MyPlantillaReposicionDetalleEntityFactory
        Inherits DV_PlantillaReposicionDetalleEntityFactory
        Public Overrides Function Create() As IEntity2
            Dim entity As DV_PlantillaReposicionDetalleEntity = MyBase.Create()
            'Asignamos un valor -1 para que el proceso automático de validación no salte ya que si el valor es cero no va a dejar guardar el registro.
            'Tener en cuenta que en el evento OnSaving de la BEntity vamos a cargarle un valor internamente.
            entity.Orden = -1
            entity.Id = -1
            Return entity
        End Function
    End Class

End Namespace
