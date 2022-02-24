Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL

Namespace Business
    <Serializable()> Public Class DV_Cristal_PrecioGraduacionBEntity
        Inherits Studio.Phone.POS.BLL.DocumentoSalidaBEntity

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub CreateFields()
            MyBase.CreateFields()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.POS.DAL.FactoryClasses.DV_Cristal_PrecioGraduacionEntityFactory
        End Function

        Public Shared Function CalularPrecioUnitarioDeArticulo(ByVal articuloId As Integer, ByVal listaPreVtaId As Integer, ByVal monedaId As Integer, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As Decimal

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

                Dim col As IEntityCollection2 = Buscar(da, articuloId, listaPreVtaId, monedaId, esferico, cilindrico, adicion)

                If col.Count = 0 Then
                    col = Buscar(da, articuloId, listaPreVtaId, esferico, cilindrico, adicion)
                    If col.Count = 0 Then
                        Throw New ApplicationException(String.Format("No se ha encontrado información del artículo {0} en la lista de precios especificada, consulte al administrador del sistema.", ArticuloController.BuscarPorId(articuloId).DescripcionFull))
                        Return Nothing
                    End If
                End If

                Dim listaPreVtaLin As DV_Cristal_PrecioGraduacionEntity = DirectCast(col(0), DV_Cristal_PrecioGraduacionEntity)

                'Si la moneda de la lista de precios no es la misma que la factura hay que realizar una conversión
                Dim impToReturn As Decimal = listaPreVtaLin.Importe
                If listaPreVtaLin.MonedaId <> monedaId Then
                    Dim cotiz As CotizacionEntity = CotizacionController.BuscarUltimaCotizacion(da, monedaId, listaPreVtaLin.MonedaId)
                    If Not cotiz Is Nothing Then
                        impToReturn = CType(listaPreVtaLin.Importe * cotiz.Importe, Decimal)
                    Else
                        'Si no encuentro la cotizacion Moneda 1 / Moneda 2, busco al reves yen vez de multiplicar divido
                        cotiz = CotizacionController.BuscarUltimaCotizacion(da, listaPreVtaLin.MonedaId, monedaId)
                        If Not cotiz Is Nothing Then
                            impToReturn = CType(listaPreVtaLin.Importe / cotiz.Importe, Decimal)
                        Else
                            'Cotización no encontrada
                            Throw New ApplicationException("La moneda de la factura difiere de la lista de precios, pero no se ha encontrado información el tipo de cambio entre ambas.")
                        End If
                    End If
                End If

                Return Decimal.Round(impToReturn, 2)

            End Using

        End Function

        Public Shared Function Buscar(da As IDataAccessAdapter, articuloId As Integer, listaPreVtaId As Integer, monedaId As Integer, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As IEntityCollection2
            Return (New DV_Cristal_PrecioGraduacionBEntity).GetData(da, CrearFiltroParaPrecio(articuloId, listaPreVtaId, monedaId, esferico, cilindrico, adicion))
        End Function

        Public Shared Function Buscar(da As IDataAccessAdapter, articuloId As Integer, listaPreVtaId As Integer, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As IEntityCollection2
            Return (New DV_Cristal_PrecioGraduacionBEntity).GetData(da, CrearFiltroParaPrecio(articuloId, listaPreVtaId, esferico, cilindrico, adicion))
        End Function

        Public Shared Function CrearFiltroParaPrecio(articuloId As Integer, listaPreVtaId As Integer, monedaId As Integer, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As IRelationPredicateBucket
            Dim toReturn As IRelationPredicateBucket = New RelationPredicateBucket(DV_Cristal_PrecioGraduacionFields.ArticuloId = articuloId And DV_Cristal_PrecioGraduacionFields.ListaPreVtaId = listaPreVtaId And DV_Cristal_PrecioGraduacionFields.MonedaId = monedaId And _
                                                        DV_Cristal_PrecioGraduacionFields.EsfericoDesde <= esferico And DV_Cristal_PrecioGraduacionFields.EsfericoHasta >= esferico)
            If adicion > Decimal.Zero Then
                toReturn.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.AdicionDesde <= adicion And DV_Cristal_PrecioGraduacionFields.AdicionHasta >= adicion)
            ElseIf cilindrico > Decimal.MinValue Then
                toReturn.PredicateExpression.Add(DV_Cristal_PrecioGraduacionFields.CilindricoDesde <= cilindrico And DV_Cristal_PrecioGraduacionFields.CilindricoHasta >= cilindrico)
            End If
            Return toReturn
        End Function

        Public Shared Function CrearFiltroParaPrecio(articuloId As Integer, listaPreVtaId As Integer, esferico As Decimal, cilindrico As Decimal, adicion As Decimal) As IRelationPredicateBucket
            Return New RelationPredicateBucket(DV_Cristal_PrecioGraduacionFields.ArticuloId = articuloId And DV_Cristal_PrecioGraduacionFields.ListaPreVtaId = listaPreVtaId And _
                                                        DV_Cristal_PrecioGraduacionFields.CilindricoDesde <= cilindrico And DV_Cristal_PrecioGraduacionFields.CilindricoHasta >= cilindrico And _
                                                        DV_Cristal_PrecioGraduacionFields.EsfericoDesde <= esferico And DV_Cristal_PrecioGraduacionFields.EsfericoHasta >= esferico)
        End Function

    End Class

End Namespace