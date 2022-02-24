Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.FactoryClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.BLL
Imports Studio.Net.BLL
Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.DAL.Linq
Imports SD.LLBLGen.Pro.LinqSupportClasses
Imports System.Linq.Dynamic
Imports System.Linq

Namespace Business
    <Serializable()> Public Class DV_CristalBEntity
        Inherits ArticuloBEntity

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.POS.DAL.FactoryClasses.DV_CristalEntityFactory
        End Function


        Public Shared Function CrearFiltroPorNoVariante() As IRelationPredicateBucket
            Return New RelationPredicateBucket(DV_CristalFields.ArticuloIdGuia = System.DBNull.Value)
        End Function


        Public Shared Function GetQueryableForCristalesGuiaDeVariante(ByRef da As IDataAccessAdapter) As System.Linq.IQueryable
            Return GetQueryableForCristalesGuiaDeVariante(da, Nothing)
        End Function

        Public Shared Function GetQueryableForCristalesGuiaDeVariante(ByRef da As IDataAccessAdapter, ByVal ParamArray depositos() As Integer) As System.Linq.IQueryable

            If da Is Nothing Then
                da = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
            End If
            Dim db As New LinqMetaData(da)
            Dim q = (From c In db.DV_Cristal Where c.GuiaDeVariante = True Select c)
            'Todos los articulo que estén asociados a TODOS los depósitos de la lista
            If depositos IsNot Nothing AndAlso depositos.Count > 0 Then
                q = (From c In q Where (From s In c.Stock Where depositos.Contains(s.DepositoId)).Count() = depositos.Count())
            End If

            'Workaround para que solo devuelva registros de la tabla cristal
            q = (From c In q Where c.CristalMaterialId > 0)
            Return (From c In q Select c.Id, c.Descripcion)

        End Function


        Public Shared Function GetQueryableForCristalesGuiaDeVarianteVentas(ByRef da As IDataAccessAdapter, ByVal documento As Tmp_DocumentoSalidaEntity) As System.Linq.IQueryable

            If da Is Nothing Then
                da = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
            End If

            Dim localId As Integer = LocalController.BuscarLocalIdFromCaja(da, documento.CajaId)

            Dim db As New LinqMetaData(da)

            Dim q = (From c In db.DV_Cristal Where c.GuiaDeVariante = True AndAlso c.Activo = True AndAlso c.Vendible = True _
                AndAlso (From s In c.Stock Where s.Deposito.LocalId = localId AndAlso s.Deposito.AutorizadoVenta = True).Any() _
                AndAlso (From l In c.Locales Where l.LocalId = localId AndAlso l.Activo = True).Any() _
                AndAlso (From p In c.PreciosDeVenta Where p.ListaPrecioVentaId = documento.ListaPreVtaId).Any()
                     Select c)

            Return (From c In q Select c.Id, c.Descripcion)

        End Function

        Private Shared Function GetGuiasDeArticulos(ByVal da As IDataAccessAdapter, ByVal guias As List(Of Integer)) As List(Of DV_CristalEntity)
            Dim db As New LinqMetaData(da)
            Return (From c In db.DV_Cristal Where guias.Contains(c.Id) Select c).WithPath(CrearPrefetchPorPlantillas()).ToList()
        End Function

        Public Shared Function CrearPrefetchPorPlantillas() As IPrefetchPath2
            Dim toReturn As New PrefetchPath2(CInt(EntityType.DV_CristalEntity))
            toReturn.Add(DV_CristalEntity.PrefetchPathPlantilla)
            Return toReturn
        End Function

        Public Shared Function GetMatrixData(ByVal detalles As EntityCollection(Of Tmp_DocSalidaDetalleEntity)) As CristalesMatrixData

            Dim toReturn As New CristalesMatrixData
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                For Each detalle As Tmp_DocSalidaDetalleEntity In detalles
                    If detalle.Articulo Is Nothing Then
                        detalle.Articulo = da.FetchNewEntity(Of ArticuloEntity)(detalle.GetRelationInfoArticulo(), ArticuloController.CrearPrefetchPorCombinacionesYValores())
                    End If
                    If detalle.Articulo.CombinacionesDeVariante.Count = 0 Then
                        da.FetchEntityCollection(detalle.Articulo.CombinacionesDeVariante, detalle.Articulo.GetRelationInfoCombinacionesDeVariante(), ArticuloVariante_CombinacionBEntity.CrearPrefetchPorValor())
                    End If
                Next

                Dim cristales As List(Of DV_CristalEntity) = detalles.Where(Function(f) (TypeOf f.Articulo Is DV_CristalEntity)).Select(Function(f) DirectCast(f.Articulo, DV_CristalEntity)).ToList()
                Dim fieldsBuffer As New Dictionary(Of Integer, IEntityField2)

                If cristales.Count > 0 Then

                    Dim guias As List(Of DV_CristalEntity) = GetGuiasDeArticulos(da, cristales.Select(Function(f) f.ArticuloIdGuia).Distinct().ToList())
                    For Each guia As DV_CristalEntity In guias

                        Dim toAdd As New CristalData With {.ArticuloId = guia.Id, .Descripcion = guia.Descripcion, .PlantillaId1 = guia.Plantilla.AAtributoPlantillaID1, .PlantillaId2 = guia.Plantilla.AAtributoPlantillaID2}
                        toReturn.Cristales.Add(toAdd)

                        For Each detalle As Tmp_DocSalidaDetalleEntity In detalles.Where(Function(f) f.Articulo.ArticuloIdGuia = toAdd.ArticuloId)

                            Dim plantillaID1 = detalle.Articulo.CombinacionesDeVariante(0).AAtributoPlantillaID
                            Dim plantillaID2 = detalle.Articulo.CombinacionesDeVariante(1).AAtributoPlantillaID

                            If Not fieldsBuffer.ContainsKey(plantillaID1) Then
                                fieldsBuffer.Add(plantillaID1, AAtributoPlantillaValorBEntity.GetFieldFromPlantilla(AAtributoPlantillaBEntity.GetById(da, plantillaID1)))
                            End If
                            If Not fieldsBuffer.ContainsKey(plantillaID2) Then
                                fieldsBuffer.Add(plantillaID2, AAtributoPlantillaValorBEntity.GetFieldFromPlantilla(AAtributoPlantillaBEntity.GetById(da, plantillaID2)))
                            End If

                            Dim field1 As IEntityField2 = fieldsBuffer(plantillaID1)
                            Dim field2 As IEntityField2 = fieldsBuffer(plantillaID2)

                            toAdd.Valores.Add(New CristalValor With {.ArticuloId = detalle.ArticuloId,
                                                                    .PlantillaValorID1 = detalle.Articulo.CombinacionesDeVariante(0).AAtributoPlantillaValorID,
                                                                    .PlantillaValorID2 = detalle.Articulo.CombinacionesDeVariante(1).AAtributoPlantillaValorID,
                                                                    .PlantillaValor1 = detalle.Articulo.CombinacionesDeVariante(0).ValorDePlantilla.Fields(field1.Name).CurrentValue,
                                                                    .PlantillaValor2 = detalle.Articulo.CombinacionesDeVariante(1).ValorDePlantilla.Fields(field2.Name).CurrentValue,
                                                                     .Valor = detalle.Cantidad})

                        Next
                    Next
                End If

            End Using
            Return toReturn
        End Function


        ''' <summary>
        ''' Filtra los cristales para el ingreso de las recetas
        ''' </summary>
        ''' <param name="da">El adapter para usar en el LinqInstantFeddeBackSource</param>
        ''' <param name="cilindrico1">El valor cilíndrico de unos de los ojos</param>
        ''' <param name="cilindrico2">El valor cilíndrico del otro ojo</param>
        ''' <param name="esferico1">El valor esférico de uno de los dos ojos</param>
        ''' <param name="esferico2">El valor esférico del otro ojo</param>
        ''' <param name="listaPrecioVentaId"></param>
        ''' <param name="parametroTree"></param>
        ''' <returns></returns>
        Public Shared Function GetQueryableForReceta(ByRef da As IDataAccessAdapter,
                                                ByVal cilindrico1 As Decimal, ByVal cilindrico2 As Decimal,
                                                ByVal esferico1 As Decimal, ByVal esferico2 As Decimal,
                                                ByVal adicion1 As Decimal, adicion2 As Decimal,
                                                ByVal listaPrecioVentaId As Integer, ByVal cristalMaterialID As Integer, ByVal tipo As Integer,
                                                ByVal parametroTree As VisionParametroTree, Optional soloWeb As Boolean = False) As IQueryable

            If da Is Nothing Then
                da = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
            End If

            Dim db As New LinqMetaData(da)
            Dim q = (From c In db.DV_Cristal Where c.Vendible = True AndAlso c.VisibleEnReceta = True AndAlso c.Activo = True AndAlso c.ArticuloGuiaDeVariante Is Nothing _
                     AndAlso c.Tipo = tipo AndAlso c.CristalMaterialId = cristalMaterialID AndAlso
                    (c.Clasificacion = CInt(CristalClasificacion.Maquina) OrElse parametroTree.Optica.Venta.EsfericoMaxParaTerminados = Decimal.Zero OrElse
                     (Math.Abs(esferico1) <= parametroTree.Optica.Venta.EsfericoMaxParaTerminados AndAlso Math.Abs(esferico2) <= parametroTree.Optica.Venta.EsfericoMaxParaTerminados)) AndAlso
                 (
                     (c.GuiaDeVariante = False AndAlso (From loc In c.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso
                       (From p In c.PreciosPorGraduacion Where p.ListaPreVtaId = listaPrecioVentaId AndAlso
                         p.EsfericoDesde <= esferico1 AndAlso p.EsfericoHasta >= esferico1 AndAlso
                         ((p.CilindricoDesde <= cilindrico1 AndAlso p.CilindricoHasta >= cilindrico1) AndAlso (p.AdicionDesde <= adicion1 AndAlso p.AdicionHasta >= adicion1))).Any() AndAlso
                        (From p In c.PreciosPorGraduacion Where p.ListaPreVtaId = listaPrecioVentaId AndAlso
                        ((p.CilindricoDesde <= cilindrico2 AndAlso p.CilindricoHasta >= cilindrico2) AndAlso (p.AdicionDesde <= adicion2 AndAlso p.AdicionHasta >= adicion2)) AndAlso
                    p.EsfericoDesde <= esferico2 AndAlso p.EsfericoHasta >= esferico2).Any()) _
                  OrElse
                  (
                      (From var In
                          (From col In c.Variantes Where
                                (From v In col.CombinacionesDeVariante Where ((v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesCilindrico _
                                AndAlso v.ValorDePlantilla.ValorDecimal = cilindrico1) OrElse (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesAdicion _
                                AndAlso v.ValorDePlantilla.ValorDecimal = adicion1))).Any() AndAlso
                                (From v In col.CombinacionesDeVariante Where (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesEsferico _
                                AndAlso v.ValorDePlantilla.ValorDecimal = esferico1)).Any())
                       Where (From loc In var.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso
                            (From p In var.PreciosDeVenta Where p.ListaPrecioVentaId = listaPrecioVentaId).Any()).Any() AndAlso
            (From var In
                          (From col In c.Variantes Where
                                (From v In col.CombinacionesDeVariante Where ((v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesCilindrico _
                                AndAlso v.ValorDePlantilla.ValorDecimal = cilindrico2) OrElse (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesAdicion _
                                AndAlso v.ValorDePlantilla.ValorDecimal = adicion2))).Any() AndAlso
                                (From v In col.CombinacionesDeVariante Where (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesEsferico _
                                AndAlso v.ValorDePlantilla.ValorDecimal = esferico2)).Any())
             Where (From loc In var.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso
                            (From p In var.PreciosDeVenta Where p.ListaPrecioVentaId = listaPrecioVentaId).Any()).Any()
           )))

            If soloWeb Then
                q = (From c In q Where c.PublicableWeb = True Select c)
            End If

            '     Dim q = (From c In db.DV_Cristal Where c.Vendible = True AndAlso c.VisibleEnReceta = True AndAlso c.Activo = True AndAlso c.ArticuloGuiaDeVariante Is Nothing _
            '          AndAlso c.Tipo = tipo AndAlso c.CristalMaterialId = cristalMaterialID AndAlso _
            '         (c.Clasificacion = CInt(CristalClasificacion.Maquina) OrElse parametroTree.Optica.Venta.EsfericoMaxParaTerminados = Decimal.Zero OrElse _
            '          (Math.Abs(esferico1) <= parametroTree.Optica.Venta.EsfericoMaxParaTerminados AndAlso Math.Abs(esferico2) <= parametroTree.Optica.Venta.EsfericoMaxParaTerminados)) AndAlso _
            '      ( _
            '          (c.GuiaDeVariante = False AndAlso _
            '            (From p In c.PreciosPorGraduacion Where p.ListaPreVtaId = listaPrecioVentaId AndAlso _
            '              p.EsfericoDesde <= esferico1 AndAlso p.EsfericoHasta >= esferico1 AndAlso _
            '              ((p.CilindricoDesde <= cilindrico1 AndAlso p.CilindricoHasta >= cilindrico1) AndAlso (p.AdicionDesde <= adicion1 AndAlso p.AdicionHasta >= adicion1))).Any() AndAlso _
            '             (From p In c.PreciosPorGraduacion Where p.ListaPreVtaId = listaPrecioVentaId AndAlso _
            '             ((p.CilindricoDesde <= cilindrico2 AndAlso p.CilindricoHasta >= cilindrico2) AndAlso (p.AdicionDesde <= adicion2 AndAlso p.AdicionHasta >= adicion2)) AndAlso _
            '         p.EsfericoDesde <= esferico2 AndAlso p.EsfericoHasta >= esferico2).Any()) _
            '       OrElse
            '       ( _
            '           (From var In _
            '               (From col In c.Variantes Where _
            '                     (From v In col.CombinacionesDeVariante Where ((v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesCilindrico _
            '                     AndAlso v.ValorDePlantilla.ValorDecimal = cilindrico1) OrElse (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesAdicion _
            '                     AndAlso v.ValorDePlantilla.ValorDecimal = adicion1))).Any() AndAlso _
            '                     (From v In col.CombinacionesDeVariante Where ((v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesCilindrico _
            '                     AndAlso v.ValorDePlantilla.ValorDecimal = cilindrico2) OrElse (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesAdicion _
            '                     AndAlso v.ValorDePlantilla.ValorDecimal = adicion2))).Any() AndAlso _
            '                     (From v In col.CombinacionesDeVariante Where (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesEsferico _
            '                     AndAlso v.ValorDePlantilla.ValorDecimal = esferico1)).Any() AndAlso _
            '                     (From v In col.CombinacionesDeVariante Where (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesEsferico _
            '                     AndAlso v.ValorDePlantilla.ValorDecimal = esferico2)).Any()) _
            '             Where (From loc In var.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso _
            '                 (From p In var.Precios Where p.ListaPrecioVentaId = listaPrecioVentaId).Any()).Any() _
            ')))
            Return (From c In q Select c.Id, c.Descripcion, c.DescripcionVariante, c.DescripcionCorta)

        End Function


        ' ''' <summary>
        ' ''' Filtra los cristales para el ingreso de las recetas
        ' ''' </summary>
        ' ''' <param name="da">El adapter para usar en el LinqInstantFeddeBackSource</param>
        ' ''' <param name="cilindrico1">El valor cilíndrico de unos de los ojos</param>
        ' ''' <param name="cilindrico2">El valor cilíndrico del otro ojo</param>
        ' ''' <param name="esferico1">El valor esférico de uno de los dos ojos</param>
        ' ''' <param name="esferico2">El valor esférico del otro ojo</param>
        ' ''' <param name="listaPrecioVentaId"></param>
        ' ''' <param name="parametroTree"></param>
        ' ''' <returns></returns>
        'Public Shared Function GetQueryableForReceta(ByRef da As IDataAccessAdapter, _
        '                                        ByVal cilindrico1 As Decimal, ByVal cilindrico2 As Decimal, _
        '                                        ByVal esferico1 As Decimal, ByVal esferico2 As Decimal, _
        '                                        ByVal adicion1 As Decimal, adicion2 As Decimal, _
        '                                        ByVal listaPrecioVentaId As Integer, ByVal cristalMaterialID As Integer, ByVal tipo As Integer, _
        '                                        ByVal parametroTree As VisionParametroTree) As IQueryable

        '    If da Is Nothing Then
        '        da = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
        '    End If

        '    Dim db As New LinqMetaData(da)
        '    Dim q = (From c In db.DV_Cristal Where c.Vendible = True AndAlso c.VisibleEnReceta = True AndAlso c.Activo = True AndAlso c.ArticuloGuiaDeVariante Is Nothing _
        '             AndAlso c.Tipo = tipo AndAlso c.CristalMaterialId = cristalMaterialID AndAlso _
        '            (c.Clasificacion = CInt(CristalClasificacion.Maquina) OrElse parametroTree.Optica.Venta.EsfericoMaxParaTerminados = Decimal.Zero OrElse _
        '             (Math.Abs(esferico1) <= parametroTree.Optica.Venta.EsfericoMaxParaTerminados AndAlso Math.Abs(esferico2) <= parametroTree.Optica.Venta.EsfericoMaxParaTerminados)) AndAlso _
        '         ((c.GuiaDeVariante = False AndAlso (From loc In c.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso _
        '           (From p In c.PreciosPorGraduacion Where p.ListaPreVtaId = listaPrecioVentaId AndAlso _
        '             p.EsfericoDesde <= esferico1 AndAlso p.EsfericoHasta >= esferico1 AndAlso _
        '             ((p.CilindricoDesde <= cilindrico1 AndAlso p.CilindricoHasta >= cilindrico1) AndAlso (p.AdicionDesde <= adicion1 AndAlso p.AdicionHasta >= adicion1))).Any() AndAlso _
        '            (From p In c.PreciosPorGraduacion Where p.ListaPreVtaId = listaPrecioVentaId AndAlso _
        '            ((p.CilindricoDesde <= cilindrico2 AndAlso p.CilindricoHasta >= cilindrico2) AndAlso (p.AdicionDesde <= adicion2 AndAlso p.AdicionHasta >= adicion2)) AndAlso _
        '            p.EsfericoDesde <= esferico2 AndAlso p.EsfericoHasta >= esferico2).Any()) _
        '          OrElse
        '          ( _
        '              (From col In c.Variantes Where _
        '                    (From loc In col.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso _
        '                    (From p In col.Precios Where p.ListaPrecioVentaId = listaPrecioVentaId).Any() AndAlso _
        '                    (From v In col.CombinacionesDeVariante Where ((v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesCilindrico _
        '                    AndAlso v.ValorDePlantilla.ValorDecimal = cilindrico1) OrElse (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesAdicion _
        '                    AndAlso v.ValorDePlantilla.ValorDecimal = adicion1))).Any()).Any() AndAlso _
        '              (From col In c.Variantes Where _
        '                    (From loc In col.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso _
        '                    (From p In col.Precios Where p.ListaPrecioVentaId = listaPrecioVentaId).Any() AndAlso _
        '                    (From v In col.CombinacionesDeVariante Where ((v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesCilindrico _
        '                    AndAlso v.ValorDePlantilla.ValorDecimal = cilindrico2) OrElse (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesAdicion _
        '                    AndAlso v.ValorDePlantilla.ValorDecimal = adicion2))).Any()).Any() AndAlso _
        '              (From col In c.Variantes Where _
        '                    (From loc In col.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso _
        '                    (From p In col.Precios Where p.ListaPrecioVentaId = listaPrecioVentaId).Any() AndAlso _
        '                    (From v In col.CombinacionesDeVariante Where v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesEsferico _
        '                    AndAlso v.ValorDePlantilla.ValorDecimal = esferico1).Any()).Any() AndAlso _
        '              (From col In c.Variantes Where _
        '                    (From loc In col.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso _
        '                    (From p In col.Precios Where p.ListaPrecioVentaId = listaPrecioVentaId).Any() AndAlso _
        '                    (From v In col.CombinacionesDeVariante Where v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesEsferico _
        '               AndAlso v.ValorDePlantilla.ValorDecimal = esferico2).Any()).Any() _
        '           ) _
        '       ))

        '    Return (From c In q Select c.Id, c.Descripcion, c.DescripcionVariante)

        'End Function

        Public Shared Function GetByIdForReceta(da As IDataAccessAdapter, Id As Integer) As DV_CristalEntity

            Dim fields As New ExcludeIncludeFieldsList(False)
            fields.Add(DV_CristalFields.CristalPlantillaID)
            fields.Add(DV_CristalFields.GuiaDeVariante)
            fields.Add(DV_CristalFields.CristalPlantillaID)
            fields.Add(DV_CristalFields.Descripcion)
            fields.Add(DV_CristalFields.DescripcionVariante)

            Return da.FetchNewEntity(Of DV_CristalEntity)(New RelationPredicateBucket(DV_CristalFields.Id = Id), Nothing, Nothing, fields)

        End Function

        Public Shared Function BuscarPorGraduacion(da As IDataAccessAdapter, articuloId As Integer, valor1 As Decimal, valor2 As Decimal, plantillaId1 As Integer, plantillaId2 As Integer) As ArticuloEntity

            Dim db As New LinqMetaData(da)
            Dim q As IQueryable(Of DV_CristalEntity) = (From c In db.DV_Cristal Where c.ArticuloGuiaDeVariante.Id = articuloId AndAlso
                  (
                      (From v In c.CombinacionesDeVariante Where v.AAtributoPlantillaID = plantillaId1 _
                       AndAlso v.ValorDePlantilla.ValorDecimal = valor1).Any() AndAlso
                      (From v In c.CombinacionesDeVariante Where v.AAtributoPlantillaID = plantillaId2 _
                       AndAlso v.ValorDePlantilla.ValorDecimal = valor2).Any()
               ))
            Return q.IncludeFields(Function(f) f.Id, Function(f) f.Descripcion, Function(f) f.DescripcionVariante,
                                   Function(f) f.ControlaStock, Function(f) f.GuiaDeVariante, Function(f) f.ArticuloIdGuia).SingleOrDefault()
        End Function


        Public Shared Function GetValorPlantilla(da As IDataAccessAdapter, articuloId As Integer, plantillaId As Integer) As Decimal

            Dim db As New LinqMetaData(da)
            Return (From q In db.DV_Cristal Join c In db.ArticuloVariante_Combinacion On c.ArticuloId Equals q.Id Where q.Id = articuloId AndAlso c.AAtributoPlantillaID = plantillaId Select c.ValorDePlantilla.ValorDecimal).Single()

        End Function

        Shared Function Existe(ByVal da As IDataAccessAdapter, ByVal articuloId As Integer) As Boolean
            If da Is Nothing Then
                da = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
            End If
            Dim db As New LinqMetaData(da)
            Return (From q In db.DV_Cristal Where q.Id = articuloId).Any()

        End Function

        'Public Shared Function BuscarPorRangoCilindrico(da As IDataAccessAdapter, articuloId As Integer, cilindricoDesde As Decimal, cilindricoHasta As Decimal, plantillaId As Integer) As ArticuloEntity

        '    Dim db As New LinqMetaData(da)
        '    Dim q As IQueryable(Of DV_CristalEntity) = (From c In db.DV_Cristal Where c.ArticuloGuiaDeVariante.Id = articuloId AndAlso
        '          (
        '              (From v In c.CombinacionesDeVariante Where v.AAtributoPlantillaID = plantillaId _
        '               AndAlso v.ValorDePlantilla.ValorDecimal >= cilindricoDesde AndAlso v.ValorDePlantilla.ValorDecimal).Any()
        '       ))
        '    Return q '.IncludeFields(Function(f) f.Id, Function(f) f.Descripcion, Function(f) f.DescripcionVariante,
        '    'Function(f) f.ControlaStock, Function(f) f.GuiaDeVariante, Function(f) f.ArticuloIdGuia).SingleOrDefault()
        'End Function

    End Class



#Region "DV_CristalFiltrado Class"

    Public Class DV_CristalFiltrado
        Inherits DV_CristalBEntity

        Public Property Diametro As Integer
        Public Property Esferico As Decimal
        Public Property Cilindrico As Decimal
        Public Property CristalMaterialId As Integer
        Public Property RecetaTipoId As Integer

        Public Overrides Function GetDataForComboAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable

            If adapter Is Nothing Then
                adapter = CreateAdapter()
            End If

            Dim db As New LinqMetaData(adapter)

            Dim whereExpr As New System.Text.StringBuilder()
            whereExpr.AppendLine(String.Format("({0} = {1} And {2} = {3} And {4} = NULL)",
                                               DV_CristalFieldIndex.Tipo.ToString(), RecetaTipoId,
                                               DV_CristalFieldIndex.CristalMaterialId.ToString(), CristalMaterialId,
                                               DV_CristalFieldIndex.ArticuloIdGuia.ToString()))

            Dim q As IQueryable(Of DV_CristalEntity) = db.DV_Cristal.Where(whereExpr.ToString(), Nothing)

            Return (From c In q Select c.Id, c.Descripcion, Tipo = IIf(c.Clasificacion = CristalClasificacion.Maquina, "Laboratorio", "Terminado"))

        End Function


    End Class

#End Region

End Namespace

