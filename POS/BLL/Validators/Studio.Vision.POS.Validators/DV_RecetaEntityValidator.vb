Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Vision.POS.BLL.Business
Imports Studio.Phone.POS.BLL

'Imports Studio.Phone.DAL.DatabaseSpecific

<DependencyInjectionInfo(GetType(DV_RecetaEntity), "Validator", ContextType:=DependencyInjectionContextType.Singleton)> _
<Serializable()> _
Public Class DV_RecetaEntityValidator
    Inherits DocumentoSalidaEntityValidator

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal dataAccessAdapterToUse As IDataAccessAdapter)
        MyBase.New(dataAccessAdapterToUse)
    End Sub

    Public Overloads Overrides Sub ValidateEntityBeforeSave(ByVal containingEntity As IEntityCore)

        Dim da As IDataAccessAdapter = MyBase.CreateAdapterIfIsNothing()

        Try

            MyBase.ValidateEntityBeforeSave(containingEntity)

            Dim dvRecetaEntity As DV_RecetaEntity = containingEntity

            With dvRecetaEntity

            End With

        Finally
            If Me._adapterCreatedByMe Then
                da.Dispose()
            End If
            DataAccessAdapterToUse = Nothing
        End Try

    End Sub

    Public Overrides Function GetEntityToValidateType() As System.Type
        Return GetType(DV_RecetaEntity)
    End Function

End Class
