Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Vision.BLL.Business

'Imports Studio.Phone.DAL.DatabaseSpecific

<DependencyInjectionInfo(GetType(DV_Cristal_PrecioGraduacionEntity), "Validator", ContextType:=DependencyInjectionContextType.Singleton)> _
<Serializable()> _
Public Class DV_Cristal_PrecioGraduacionEntityValidator
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
            Dim precio As DV_Cristal_PrecioGraduacionEntity = containingEntity
            With precio
                If precio.IsNew AndAlso DV_Cristal_PrecioGraduacionBEntity.BuscarPorPk(da, precio.ArticuloId, precio.ListaPreVtaId, precio.MonedaId, precio.EsfericoDesde, precio.EsfericoHasta, _
                                                                                       precio.CilindricoDesde, precio.CilindricoHasta, precio.AdicionDesde, precio.AdicionHasta) IsNot Nothing Then
                    precio.SetEntityError("Ya existe el registro ingresado, de haber guardado generaría valores duplicados.")
                End If
                If precio.EsfericoDesde > precio.EsfericoHasta Then
                    precio.SetEntityFieldError(DV_Cristal_PrecioGraduacionFieldIndex.EsfericoHasta.ToString(), "El valor del esférico hasta no puede ser menor que el esférico desde.", True)
                End If
                If precio.CilindricoDesde > precio.CilindricoHasta Then
                    precio.SetEntityFieldError(DV_Cristal_PrecioGraduacionFieldIndex.CilindricoHasta.ToString(), "El valor del cilíndrico hasta no puede ser menor que el cilíndrico desde.", True)
                End If
                If precio.CilindricoDesde > Decimal.Zero Then
                    precio.SetEntityFieldError(DV_Cristal_PrecioGraduacionFieldIndex.CilindricoDesde.ToString(), "El valor del cilíndrico desde no puede ser mayor a cero.", True)
                End If
                If precio.AdicionDesde > precio.AdicionHasta Then
                    precio.SetEntityFieldError(DV_Cristal_PrecioGraduacionFieldIndex.AdicionHasta.ToString(), "El valor de la adición hasta no puede ser menor que la adición desde.", True)
                End If
                If precio.AdicionDesde < Decimal.Zero Then
                    precio.SetEntityFieldError(DV_Cristal_PrecioGraduacionFieldIndex.AdicionDesde.ToString(), "El valor de la adición debe ser mayor a cero.", True)
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
        Return GetType(DV_Cristal_PrecioGraduacionEntity)
    End Function

End Class
