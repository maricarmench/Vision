Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Vision.BLL.Business

'Imports Studio.Phone.DAL.DatabaseSpecific

<DependencyInjectionInfo(GetType(DV_CristalMaterial_ServicioEntity), "Validator", ContextType:=DependencyInjectionContextType.Singleton)> _
<Serializable()> _
Public Class DV_CristalMaterial_ServicioEntityValidator
    Inherits Studio.Net.BLL.BEntityValidatorBase

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal dataAccessAdapterToUse As IDataAccessAdapter)
        MyBase.New(dataAccessAdapterToUse)
    End Sub

    Public Overrides Sub ValidateEntityBeforeSave(ByVal containingEntity As IEntityCore)

        Dim da As IDataAccessAdapter = MyBase.CreateAdapterIfIsNothing()

        Try
            Dim precio As DV_CristalMaterial_ServicioEntity = containingEntity
            With precio
                If precio.IsNew AndAlso DV_CristalMaterial_ServicioBEntity.BuscarPorPk(da, precio.CristalMaterialId, precio.ArticuloId, precio.ListaPrecioVentaId, precio.MonedaId) IsNot Nothing Then
                    precio.SetEntityError("Ya existe el registro ingresado, de haber guardado generaría valores duplicados.")
                End If
            End With
        Finally
            DataAccessAdapterToUse = Nothing
            If Me._adapterCreatedByMe Then
                da.Dispose()
            End If
        End Try

    End Sub

    Public Overrides Function GetEntityToValidateType() As System.Type
        Return GetType(DV_CristalMaterial_ServicioEntity)
    End Function

End Class
