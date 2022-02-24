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
    End Class

End Namespace
