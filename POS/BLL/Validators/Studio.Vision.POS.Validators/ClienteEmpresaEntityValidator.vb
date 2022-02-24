Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
'Imports Studio.Phone.DAL.DatabaseSpecific

<DependencyInjectionInfo(GetType(ClienteEmpresaEntity), "Validator", ContextType:=DependencyInjectionContextType.Singleton)> _
<Serializable()> _
Public Class ClienteEmpresaEntityValidator
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
            Dim cliente As ClienteEmpresaEntity = containingEntity

            With cliente

                If String.IsNullOrWhiteSpace(cliente.RazonSocial) Then
                    cliente.SetEntityFieldError(ClienteEmpresaFieldIndex.RazonSocial.ToString(), "Debe ingresar la razón social.", True)
                End If
                If String.IsNullOrWhiteSpace(cliente.NombreFantasia) Then
                    cliente.SetEntityFieldError(ClienteEmpresaFieldIndex.NombreFantasia.ToString(), "Debe ingresar el nombre de fantasía.", True)
                End If
                If String.IsNullOrWhiteSpace(cliente.Ruc) Then
                    cliente.SetEntityFieldError(ClienteEmpresaFieldIndex.Ruc.ToString(), "Debe ingresar el número de RUT.", True)
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

    Public Overrides Sub ValidateEntityBeforeDelete(ByVal involvedEntity As SD.LLBLGen.Pro.ORMSupportClasses.IEntityCore)
        'Throw New InvalidOperationException("No se puede eliminar un ajuste.")
    End Sub

    Public Overrides Function GetEntityToValidateType() As System.Type
        Return GetType(ClienteEmpresaEntity)
    End Function

End Class
