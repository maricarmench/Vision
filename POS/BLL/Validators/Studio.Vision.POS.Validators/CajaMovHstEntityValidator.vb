Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.BLL

'Imports Studio.Phone.DAL.DatabaseSpecific

<DependencyInjectionInfo(GetType(CajaMovHstEntity), "Validator", ContextType:=DependencyInjectionContextType.Singleton)> _
<Serializable()> _
Public Class CajaMovHstEntityValidator
    Inherits Studio.Net.BLL.BEntityValidatorBase

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal dataAccessAdapterToUse As IDataAccessAdapter)
        MyBase.New(dataAccessAdapterToUse)
    End Sub

    Public Overloads Overrides Sub ValidateEntityBeforeSave(ByVal containingEntity As IEntityCore)

        Dim da As IDataAccessAdapter = MyBase.CreateAdapterIfIsNothing()

        Try
            Dim documento As CajaMovHstEntity = containingEntity

            With documento
                If .CajaMovTipoId = CajaMovTipo.Ingreso OrElse .CajaMovTipoId = CajaMovTipo.Egreso Then
                    If Not CajaMovHstController.CajaAbierta(da, .CajaId) Then
                        .SetEntityError("La caja no se encuentra abierta, no esta permitida esta operación. Debe abrir la caja para poder realizar la operación.")
                    End If
                End If

            End With

            'Catch ex As Exception
            '    Throw
        Finally
            If Me._adapterCreatedByMe Then
                da.Dispose()
            End If
            DataAccessAdapterToUse = Nothing
        End Try

    End Sub

    'Public Overrides Sub ValidateEntityBeforeDelete(ByVal involvedEntity As SD.LLBLGen.Pro.ORMSupportClasses.IEntityCore)
    '    Throw New InvalidOperationException("No se puede eliminar un ajuste.")
    'End Sub

    Public Overrides Function GetEntityToValidateType() As System.Type
        Return GetType(CajaMovHstEntity)
    End Function

End Class
