Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.Linq
Imports Studio.Net.BLL


Namespace Business

    <Serializable()> Public Class DV_Cristal_Local_Proveedor_PrecioGraduacionBEntity
        Inherits BEntityBase

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function CreateEntityFactory() As IEntityFactory2
            'Return New DV_Cristal_Local_Proveedor_PrecioGraduacionEntityfactory
        End Function

    End Class

End Namespace