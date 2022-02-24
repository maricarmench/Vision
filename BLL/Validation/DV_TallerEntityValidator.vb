Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Vision.BLL.Business

'Imports Studio.Phone.DAL.DatabaseSpecific

<DependencyInjectionInfo(GetType(DV_TallerEntity), "Validator", ContextType:=DependencyInjectionContextType.Singleton)> _
<Serializable()> _
Public Class DV_TallerEntityValidator
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

            Dim taller As DV_TallerEntity = DirectCast(containingEntity, DV_TallerEntity)
            If taller.TallerPropio AndAlso taller.DepositoId = 0 Then
                taller.SetEntityFieldError(DV_TallerFieldIndex.DepositoId.ToString(), "Debe seleccionar el depósito", True)
            End If

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
