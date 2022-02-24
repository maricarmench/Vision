Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Vision.POS.BLL.Business
Imports Studio.Phone.POS.BLL

'Imports Studio.Phone.DAL.DatabaseSpecific

<DependencyInjectionInfo(GetType(DV_RecetaComunEntity), "Validator", ContextType:=DependencyInjectionContextType.Singleton)>
<Serializable()>
Public Class DV_RecetaComunEntityValidator
    Inherits DV_RecetaEntityValidator

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

            Dim dvRecetaEntity As DV_RecetaComunEntity = containingEntity

            With dvRecetaEntity

                If .CristalIdCercaDerecho = 0 AndAlso (.CilindricoOjoCercaDerecho <> Decimal.Zero OrElse
                    .EsfericoOjoCercaDerecho <> Decimal.Zero) Then
                    .SetEntityFieldError(DV_RecetaComunFieldIndex.CristalIdCercaDerecho.ToString(), "Debe espeficicar el cristal de cerca derecho", True)
                End If
                If .CristalIdCercaIzquierdo = 0 AndAlso (.CilindricoOjoCercaIzquierdo <> Decimal.Zero OrElse
                                    .EsfericoOjoCercaIzquierdo <> Decimal.Zero) Then
                    .SetEntityFieldError(DV_RecetaComunFieldIndex.CristalIdCercaIzquierdo.ToString(), "Debe espeficicar el cristal de cerca izquierdo", True)
                End If

                If .CristalIdLejosDerecho = 0 AndAlso (.CilindricoOjoLejosDerecho <> Decimal.Zero OrElse
                    .EsfericoOjoLejosDerecho <> Decimal.Zero) Then
                    .SetEntityFieldError(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString(), "Debe espeficicar el cristal de Lejos derecho", True)
                End If

                If .CristalIdLejosIzquierdo = 0 AndAlso (.CilindricoOjoLejosIzquierdo <> Decimal.Zero OrElse
                    .EsfericoOjoLejosIzquierdo <> Decimal.Zero) Then
                    .SetEntityFieldError(DV_RecetaComunFieldIndex.CristalIdLejosIzquierdo.ToString(), "Debe espeficicar el cristal de Lejos izquierdo", True)
                End If

                If .IsNew Then
                    If .FechaEmitida > System.DateTime.MinValue AndAlso String.IsNullOrEmpty(.NumeroDocumento) Then
                        .SetEntityFieldError(DV_RecetaComunFieldIndex.NumeroDocumento.ToString(), "Debe ingresar el número de documento.", True)
                    End If
                    If Not .Devolucion AndAlso .FechaEntrega < .FechaEmitida Then
                        .SetEntityFieldError(DV_RecetaFieldIndex.FechaEntrega.ToString(), "La fecha de entrega no puede ser menor a la fecha de emisión.", True)
                    End If
                    If String.IsNullOrEmpty(.Numero) Then
                        .SetEntityFieldError(DV_RecetaFieldIndex.Numero.ToString(), "El número de receta no puede estar vacio.", True)
                    End If
                    If DV_RecetaBEntity.ExisteNumero(da, .Numero) Then
                        .SetEntityFieldError(DV_RecetaFieldIndex.Numero.ToString(), "El número de receta ya existe, guarde nuevamente para que se genere uno nuevo.", True)
                    End If
                    'If .Detalles.Count = 0 AndAlso DocSalidaDetalleController.CantidadDetallesDeDocumento(da, .CajaId, .Id) = 0 Then
                    '    .SetEntityError("Debe seleccionar algún producto")
                    'End If


                End If

                If .Fields(DV_RecetaComunFieldIndex.NumeroDocumento.ToString()).CurrentValue Is Nothing AndAlso Not String.IsNullOrEmpty(.NumeroDocumento) Then
                    If DocumentoSalidaController.ExisteNumeroDocumento(da, .DocumentoTipoId, .NumeroDocumento, .CajaId) Then
                        .SetEntityFieldError(DV_RecetaFieldIndex.NumeroDocumento.ToString(), "El número de documento ya fue ingresado.", True)
                    End If
                End If

                If .Detalles.Count > 0 Then
                    Dim cantidadReceta As Integer = 0, cantidadDetalle As Integer = 0

                    If .OjoLejosDerechoCargado() Then
                        cantidadReceta += .CantidadOjoLejosDerecho
                        'cantidadDetalle+=.Detalles.Where(Function(f) f.ArticuloId=.CristalIdOjoLejosDerecho).Sum(Function(f) f.Cantidad)
                    End If
                    If .OjoLejosIzquierdoCargado() Then
                        cantidadReceta += .CantidadOjoLejosIzquierdo
                        'cantidadDetalle+=.Detalles.Where(Function(f) f.ArticuloId=.CristalIdojoLejosIzquierdo).Sum(Function(f) f.Cantidad)
                    End If
                    If .OjoCercaDerechoCargado() Then
                        cantidadReceta += .CantidadOjoCercaDerecho
                        'cantidadDetalle+=.Detalles.Where(Function(f) f.ArticuloId=.CristalIdojoCercaDerecho).Sum(Function(f) f.Cantidad)
                    End If
                    If .OjoCercaIzquierdoCargado() Then
                        cantidadReceta += .CantidadOjoCercaIzquierdo
                        'cantidadDetalle+=.Detalles.Where(Function(f) f.ArticuloId=.CristalIdojoCercaIzquierdo).Sum(Function(f) f.Cantidad)
                    End If
                    cantidadDetalle += .Detalles.Where(Function(f) DV_CristalBEntity.Existe(DataAccessAdapterToUse, f.ArticuloId)).Sum(Function(f) f.Cantidad)
                    If cantidadReceta <> cantidadDetalle Then
                        .SetEntityError("La cantidad de cristales de la receta no coincide con la cantidad de cristales de la factura a generar, borre la información e intente cargar de nuevo la receta. ")
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

    Public Overrides Function GetEntityToValidateType() As System.Type
        Return GetType(DV_RecetaComunEntity)
    End Function

End Class
