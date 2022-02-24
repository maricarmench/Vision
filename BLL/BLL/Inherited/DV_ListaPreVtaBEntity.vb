Imports Studio.Phone.BLL
Imports Studio.Vision.BLL.Business

Public Class DV_ListaPreVtaBEntity
    Inherits ListaPreVtaBEntity

    Protected Overrides Sub EliminarDetallesDeLista(da As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, unListaPreVtaEntity As Phone.DAL.EntityClasses.ListaPreVtaEntity)
        MyBase.EliminarDetallesDeLista(da, unListaPreVtaEntity)
        DV_CristalMaterial_ServicioBEntity.EliminarDetallesDeLista(da, unListaPreVtaEntity)
        DV_Cristal_PrecioGraduacionBEntity.EliminarDetallesDeLista(da, unListaPreVtaEntity)
    End Sub

    Protected Overrides Sub GuardarDetallesDeLista(da As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, unListaPreVtaEntity As Phone.DAL.EntityClasses.ListaPreVtaEntity, unDetalleCollection As SD.LLBLGen.Pro.ORMSupportClasses.IEntityCollection2)
        MyBase.GuardarDetallesDeLista(da, unListaPreVtaEntity, unDetalleCollection)
        DV_Cristal_PrecioGraduacionBEntity.GenerarDetallesDependientes(da, unListaPreVtaEntity)
        DV_CristalMaterial_ServicioBEntity.GenerarDetallesDependientes(da, unListaPreVtaEntity)
    End Sub

End Class
