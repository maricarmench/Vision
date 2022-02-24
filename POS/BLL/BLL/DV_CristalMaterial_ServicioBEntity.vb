Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports System.Runtime.InteropServices

Namespace Business
    <Serializable()> Public Class DV_CristalMaterial_ServicioBEntity
        Inherits Studio.Net.BLL.BEntityBase

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.POS.DAL.FactoryClasses.DV_CristalMaterial_ServicioEntityFactory
        End Function

        Public Shared Function GetDataForComboByMaterial(materialId As Integer) As DataTable
            Return (New DV_CristalMaterial_ServicioBEntity).GetDataForCombo(CrearFiltroPorMaterial(materialId))
        End Function

        Public Shared Function CrearFiltroPorMaterial(materialId As Integer) As IRelationPredicateBucket
            Return New RelationPredicateBucket(DV_CristalMaterial_ServicioFields.CristalMaterialID = materialId)
        End Function

    End Class

End Namespace
