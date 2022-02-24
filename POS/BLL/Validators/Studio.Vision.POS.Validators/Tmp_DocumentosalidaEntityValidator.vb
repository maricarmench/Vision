Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.BLL

'Imports Studio.Phone.DAL.DatabaseSpecific

<DependencyInjectionInfo(GetType(Tmp_DocumentoSalidaEntity), "Validator", ContextType:=DependencyInjectionContextType.Singleton)> _
<Serializable()> _
Public Class Tmp_DocumentosalidaEntityValidator
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
            Dim documento As Tmp_DocumentoSalidaEntity = containingEntity

            With documento

                If .Observaciones.Contains(DocumentoSalidaController.STR_AUTOGENERADA) Then
                    Return
                End If

                If .IngresoManual And .NumeroDocumento = String.Empty Then
                    .SetEntityFieldError(Tmp_DocumentoSalidaFieldIndex.NumeroDocumento.ToString(), String.Format("Debe ingresar el número de {0}.", IIf(ConfigReaderSpecific.GetModoPreVenta() = ModoPreVenta.Ingreso, "pre-venta", "documento")), True)
                End If
                If .IsNew AndAlso .Detalles.Count = 0 Then
                    .SetEntityError("Debe ingresar al menos un artículo.")
                End If
                If .ImporteTotal < 0 Then
                    .SetEntityFieldError(Tmp_DocumentoSalidaFieldIndex.ImporteTotal.ToString(), "No puede ingresar el importe negativo.", True)
                End If
                If .ClienteId = 0 Then
                    .SetEntityFieldError(Tmp_DocumentoSalidaFieldIndex.ClienteId.ToString(), "Debe elegir el cliente.", True)
                End If
                If .ListaPreVtaId = 0 Then
                    .SetEntityFieldError(Tmp_DocumentoSalidaFieldIndex.ListaPreVtaId.ToString(), "Dele elegir la lista de precios.", True)
                End If
                If .MonedaId = 0 Then
                    .SetEntityFieldError(Tmp_DocumentoSalidaFieldIndex.MonedaId.ToString(), "Dele elegir la lista moneda.", True)
                End If
                If CajaController.Activa(da, .CajaId) AndAlso Not CajaMovHstController.CajaAbierta(da, .CajaId) Then
                    .SetEntityError("La caja no se encuentra abierta, no puede ingresar ventas hasta que no la abra.")
                End If
                If DocumentoSalidaController.FechaYHoraDeUltimoRegistro(da, .CajaId) > System.DateTime.Now Then
                    .SetEntityError("La fecha y hora de la última boleta ingresada es posterior a la fecha y hora actual. Verifique la hora del sistema antes de guardar la boleta.")
                End If

                If CajaMovHstController.FechaYHoraDeUltimoCierre(da, .CajaId) > System.DateTime.Now Then
                    .SetEntityError("La fecha del sistema es anterior al último cierre de caja. Verifique que la fecha y hora sean correctas.")
                End If
                'End If
                If .MovimientoArticulos AndAlso .ClienteId > 0 AndAlso .DepositoIdAdministrado = 0 AndAlso ClienteController.AdministraEmpresa(da, .ClienteId) Then
                    .SetEntityFieldError(Tmp_DocumentoSalidaFieldIndex.DepositoIdAdministrado.ToString(), "Debe seleccionar el depósito destino", True)

                End If
            End With

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
        Return GetType(Tmp_DocumentoSalidaEntity)
    End Function

End Class
