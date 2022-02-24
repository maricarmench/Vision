Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
'Imports Studio.Phone.DAL.DatabaseSpecific

<DependencyInjectionInfo(GetType(ClienteParticularEntity), "Validator", ContextType:=DependencyInjectionContextType.Singleton)> _
<Serializable()> _
Public Class ClienteParticularEntityValidator
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
            Dim cliente As ClienteParticularEntity = containingEntity
            With cliente
                If String.IsNullOrWhiteSpace(cliente.PrimerNombre) Then
                    cliente.SetEntityFieldError(ClienteParticularFieldIndex.PrimerNombre.ToString(), "Debe ingresar el primer nombre.", True)
                End If
                If String.IsNullOrWhiteSpace(cliente.PrimerApellido) Then
                    cliente.SetEntityFieldError(ClienteParticularFieldIndex.PrimerApellido.ToString(), "Debe ingresar el primer apeliido.", True)
                End If
                If String.IsNullOrWhiteSpace(cliente.DocumentoIdentidad) OrElse cliente.DocumentoIdentidad.ToString().Length < 7 Then
                    cliente.SetEntityFieldError(ClienteParticularFieldIndex.DocumentoIdentidad.ToString(), "El nro. de documento de identidad no es correcto.", True)
                End If

            End With
            'Catch ex As Exception
            '    Throw
        Finally
            If Me._adapterCreatedByMe Then
                Dispose()
            End If
            DataAccessAdapterToUse = Nothing
        End Try

    End Sub

    Public Overrides Sub ValidateEntityBeforeDelete(ByVal involvedEntity As SD.LLBLGen.Pro.ORMSupportClasses.IEntityCore)
        'Throw New InvalidOperationException("No se puede eliminar un ajuste.")
    End Sub

    Public Overrides Function GetEntityToValidateType() As System.Type
        Return GetType(ClienteParticularEntity)
    End Function

End Class
