Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.BLL
Imports Studio.Net.BLL
Imports Studio.Phone.DAL
Imports Studio.Phone.DAL.Linq
Imports SD.LLBLGen.Pro.LinqSupportClasses
Imports System.Linq.Dynamic

Namespace Business
    <Serializable()> Public Class DV_CristalBEntity
        Inherits ArticuloBEntity

        Public Event CrearVarianteProgress(ByVal sender As Object, ByVal e As PercentageStepEventArgs)

        Public Shared Function CreateForVariante() As DV_CristalBEntity
            Dim toReturn As New DV_CristalBEntity
            For Each item As BEField In toReturn.Fields
                item.Displayable = (item.Name = DV_CristalFieldIndex.Diametro.ToString() OrElse item.Name = DV_CristalFieldIndex.Esferico.ToString() OrElse item.Name = DV_CristalFieldIndex.Cilindrico.ToString())
            Next
            Return toReturn
        End Function

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.DAL.FactoryClasses.DV_CristalEntityFactory
        End Function

        Public Overrides Sub BeforeSaveEntity(ByVal entityToSave As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2)
            'TODO: cambiar esto por parámetro
            'DirectCast(entityToSave, DV_CristalEntity).RubroId = 1
            MyBase.BeforeSaveEntity(entityToSave)

        End Sub

        Protected Overrides Sub CreateFields()
            MyBase.CreateFields()
            'Ocular los campos de los artículo que no interesa
            For Each field As BEField In Fields
                'If field.DataField.ActualContainingObjectName <> field.DataField.ContainingObjectName Then
                Select Case field.Name
                    Case DV_CristalFieldIndex.Id.ToString(), DV_CristalFieldIndex.Descripcion.ToString(),
                        DV_CristalFieldIndex.CristalMaterialId.ToString(), DV_CristalFieldIndex.Tipo.ToString()
                        field.Displayable = True
                    Case Else
                        field.Displayable = False
                End Select
                'End If
            Next
        End Sub

        Public Shared Function CrearFiltroPorNoVariante() As IRelationPredicateBucket
            Return New RelationPredicateBucket(DV_CristalFields.ArticuloIdGuia = System.DBNull.Value)
        End Function

        Public Sub CrearVariantes(ByVal cristal As DV_CristalEntity, ByVal articuloController As ArticuloController, ByVal desdePlanilla1 As Decimal, ByVal hastaPlanilla1 As Decimal, ByVal desdePlanilla2 As Decimal, ByVal hastaPlanilla2 As Decimal)

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                da.StartTransaction(IsolationLevel.Serializable, "ttt")

                Try

                    Dim plantilla As DV_CristalPlantillaEntity = DV_CristalPlantillaBEntity.GetById(da, cristal.CristalPlantillaID, DV_CristalPlantillaBEntity.CrearPrefetchPorPlantillas())

                    If desdePlanilla1 Mod plantilla.AAtributoPlantilla1Intervalo <> 0 Then
                        Throw New ArgumentOutOfRangeException("desdePlanilla1", String.Format("El valor inicial de la plantilla {0} está fuera del intervalo permitido.", DV_CristalPlantillaBEntity.GetDescripcion(da, plantilla.AAtributoPlantillaID1)))
                    End If
                    If hastaPlanilla1 Mod plantilla.AAtributoPlantilla1Intervalo <> 0 Then
                        Throw New ArgumentOutOfRangeException("hastaPlanilla1", String.Format("El valor final de la plantilla {0} está fuera del intervalo permitido.", DV_CristalPlantillaBEntity.GetDescripcion(da, plantilla.AAtributoPlantillaID1)))
                    End If

                    If desdePlanilla2 Mod plantilla.AAtributoPlantilla2Intervalo <> 0 Then
                        Throw New ArgumentOutOfRangeException("desdePlanilla2", String.Format("El valor inicial de la plantilla {0} está fuera del intervalo permitido.", DV_CristalPlantillaBEntity.GetDescripcion(da, plantilla.AAtributoPlantillaID2)))
                    End If
                    If hastaPlanilla2 Mod plantilla.AAtributoPlantilla2Intervalo <> 0 Then
                        Throw New ArgumentOutOfRangeException("hastaPlanilla2", String.Format("El valor final de la plantilla {0} está fuera del intervalo permitido.", DV_CristalPlantillaBEntity.GetDescripcion(da, plantilla.AAtributoPlantillaID2)))
                    End If

                    Dim dtComb As New ArticuloController.CombinacionDt(cristal.Id)

                    dtComb.Init()

                    dtComb.LoadData(da)



                    Dim atributo1ColName As String = ArticuloController.CombinacionDt.GetColName(plantilla.AAtributoPlantillaID1)
                    Dim atributo2ColName As String = ArticuloController.CombinacionDt.GetColName(plantilla.AAtributoPlantillaID2)
                    plantilla.AAtributoPlantilla1 = da.FetchNewEntity(Of AAtributoPlantillaEntity)(plantilla.GetRelationInfoAAtributoPlantilla1())
                    plantilla.AAtributoPlantilla2 = da.FetchNewEntity(Of AAtributoPlantillaEntity)(plantilla.GetRelationInfoAAtributoPlantilla2())

                    Dim indice1 As Decimal = desdePlanilla1
                    Dim total = ((hastaPlanilla1 - desdePlanilla1 + 1) / plantilla.AAtributoPlantilla1Intervalo) * ((hastaPlanilla2 - desdePlanilla2 + 1) / plantilla.AAtributoPlantilla2Intervalo)
                    Dim i As Integer = 0
                    Do
                        Dim indice2 As Decimal = desdePlanilla2
                        Do

                            Dim valorID1 As Integer = AAtributoPlantillaValorBEntity.CrearSiNoExiste(da, plantilla.AAtributoPlantilla1, indice1)
                            Dim valorID2 As Integer = AAtributoPlantillaValorBEntity.CrearSiNoExiste(da, plantilla.AAtributoPlantilla2, indice2)

                            Dim existe As Boolean = False

                            'Buscamos si la combinación ya está creada
                            For Each row As DataRow In dtComb.Rows
                                If CType(row(atributo1ColName), Integer) = valorID1 AndAlso
                                    CType(row(atributo2ColName), Integer) = valorID2 Then
                                    existe = True
                                    'Obligar a que se actualice la descripción de las variantes
                                    row.SetModified()
                                    Exit For
                                End If
                            Next
                            If Not existe Then
                                Dim rowToAdd As DataRow = dtComb.NewRow()
                                rowToAdd.Item(atributo1ColName) = valorID1
                                rowToAdd.Item(atributo2ColName) = valorID2
                                dtComb.Rows.Add(rowToAdd)
                            End If
                            indice2 += plantilla.AAtributoPlantilla2Intervalo
                            i += 1

                            RaiseEvent CrearVarianteProgress(Me, New PercentageStepEventArgs(CInt(i * 100 / total)))

                        Loop Until indice2 > hastaPlanilla2

                        indice1 += plantilla.AAtributoPlantilla1Intervalo
                    Loop Until indice1 > hastaPlanilla1

                    articuloController.SaveCombinacion(da, cristal.Id, New List(Of Integer)(New Integer() {plantilla.AAtributoPlantillaID1, plantilla.AAtributoPlantillaID2}), dtComb)

                    da.Commit()
                Catch ex As Exception
                    If da.IsTransactionInProgress Then
                        da.Rollback()
                    End If
                    Throw
                Finally
                    da.Dispose()
                End Try

            End Using

        End Sub

        'Public Function CrearVariantes(ByVal source As DV_CristalEntity, ByVal diametro As Integer, ByVal esfDesde As Decimal, ByVal esfHasta As Decimal, ByVal cilDesde As Decimal, ByVal cilHasta As Decimal, ByVal valorMasMenos As Boolean)

        '    If diametro < 0 Then
        '        Throw New ArgumentException("El valor del diámetro no puede ser menor a cero.")
        '    End If
        '    If Not esfDesde <= esfHasta Then
        '        Throw New ArgumentException("El valor del esférico desde no puede ser mayor al esférico hasta")
        '    End If
        '    If Not cilDesde <= cilHasta Then
        '        Throw New ArgumentException("El valor del cilíndrico desde no puede ser mayor al cilíndrico hasta")
        '    End If
        '    If valorMasMenos AndAlso (esfDesde < 0 OrElse esfHasta < 0 OrElse cilDesde < 0 OrElse cilHasta < 0) Then
        '        Throw New ArgumentException("Si marca la opción +/- TODOS los valores del rango cilíndrico y esférico deben ser mayor o igual a cero.")
        '    End If

        '    Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

        '        Try
        '            Const graduacionStep As Decimal = 0.25

        '            da.StartTransaction(IsolationLevel.Serializable, "trn")
        '            Dim esferico As Decimal = esfDesde
        '            Dim cilindrico = cilDesde
        '            Dim toReturn As New EntityCollection(Of DV_CristalEntity)
        '            Dim totalSteps As Long = (((esfHasta - esfDesde) / graduacionStep) + 1) * (((cilHasta - cilDesde) / graduacionStep) + 1)
        '            If valorMasMenos Then totalSteps *= 2
        '            Dim cantSteps As Long = 0I
        '            Do While Not esferico > esfHasta
        '                cilindrico = cilDesde
        '                Do While Not cilindrico > cilHasta
        '                    Dim cloned As DV_CristalEntity = CrearVariante(da, source, diametro, esferico, cilindrico)
        '                    da.SaveEntity(cloned, True)
        '                    toReturn.Add(cloned)
        '                    cilindrico += graduacionStep
        '                    cantSteps += 1
        '                    RaiseEvent CrearVarianteProgress(Me, New PercentageStepEventArgs(cantSteps * 100 / totalSteps))
        '                Loop
        '                esferico += graduacionStep
        '            Loop

        '            If valorMasMenos Then

        '                esferico = esfDesde * Decimal.MinusOne
        '                cilindrico = cilDesde * Decimal.MinusOne

        '                Do While Not (esferico * Decimal.MinusOne) < (esfHasta * Decimal.MinusOne)
        '                    cilindrico = cilDesde

        '                    Do While Not (cilindrico * Decimal.MinusOne) < (cilHasta * Decimal.MinusOne)
        '                        Dim cloned As DV_CristalEntity = CrearVariante(da, source, diametro, esferico * Decimal.MinusOne, cilindrico * Decimal.MinusOne)
        '                        da.SaveEntity(cloned, True)
        '                        toReturn.Add(cloned)
        '                        cilindrico += graduacionStep
        '                        cantSteps += 1
        '                        RaiseEvent CrearVarianteProgress(Me, New PercentageStepEventArgs(cantSteps * 100 / totalSteps))
        '                    Loop
        '                    esferico += graduacionStep
        '                Loop

        '            End If

        '            da.Commit()

        '            Return toReturn

        '        Catch ex As Exception
        '            If da.IsTransactionInProgress Then
        '                da.Rollback()
        '            End If
        '            Throw
        '        End Try
        '    End Using
        'End Function

        'Private Shared Function CrearVariante(ByVal da As IDataAccessAdapter, ByVal source As DV_CristalEntity, ByVal diametro As Integer, ByVal esferico As Decimal, ByVal cilindrico As Decimal) As DV_CristalEntity

        '    Dim foundVar As DV_CristalEntity = BuscarVariante(da, source.Id, diametro, esferico, cilindrico)
        '    If foundVar IsNot Nothing Then
        '        Return foundVar
        '    End If

        '    Dim cloned As DV_CristalEntity = ArticuloController.ClonarArticulo(da, source, True, New DV_CristalEntityFactory())
        '    cloned.ArticuloIdGuia = source.Id
        '    cloned.GuiaDeVariante = False
        '    cloned.Diametro = diametro
        '    cloned.Esferico = esferico
        '    cloned.Cilindrico = cilindrico

        '    'Cargar las variantes de los atributo diámetro, esferico, cilindrivo
        '    Dim param As VisionParametroTree = Studio.Config.BLL.ParametroSistemaTreeManager.GetParametroTree(Of VisionParametroTree)()
        '    Dim aValor As AAtributoPlantillaValorEntity = DV_AAtributoPlantillaController.VerificarValor(da, param.Optica.AAtributoPlantillaIDCristalesDiametro, diametro.ToString())
        '    cloned.CombinacionesDeVariante.Add(New ArticuloVariante_CombinacionEntity With {.Articulo = cloned, .ValorDePlantilla = aValor, .AAtributoPlantillaID = param.Optica.AAtributoPlantillaIDCristalesDiametro})
        '    aValor = DV_AAtributoPlantillaController.VerificarValor(da, param.Optica.AAtributoPlantillaIDCristalesEsferico, esferico.ToString())
        '    cloned.CombinacionesDeVariante.Add(New ArticuloVariante_CombinacionEntity With {.Articulo = cloned, .ValorDePlantilla = aValor, .AAtributoPlantillaID = param.Optica.AAtributoPlantillaIDCristalesEsferico})
        '    aValor = DV_AAtributoPlantillaController.VerificarValor(da, param.Optica.AAtributoPlantillaIDCristalesCilindrico, cilindrico.ToString())
        '    cloned.CombinacionesDeVariante.Add(New ArticuloVariante_CombinacionEntity With {.Articulo = cloned, .ValorDePlantilla = aValor, .AAtributoPlantillaID = param.Optica.AAtributoPlantillaIDCristalesCilindrico})

        '    Return cloned

        'End Function

        Public Shared Function BuscarVariante(ByVal da As IDataAccessAdapter, ByVal articuloId As Integer, ByVal diametro As Integer, ByVal esferico As Decimal, ByVal cilindrico As Decimal) As DV_CristalEntity
            Dim db As New Linq.LinqMetaData(da)
            Return (From c In db.DV_Cristal Where c.ArticuloIdGuia = articuloId AndAlso c.Diametro = diametro AndAlso c.Esferico = esferico AndAlso c.Cilindrico = cilindrico Select c).SingleOrDefault()
        End Function

        Public Shared Function VariantesDeCristalBasicos(ByVal articuloId As Integer) As IQueryable
            Return VariantesDeCristalBasicos(Nothing, articuloId)
        End Function

        Public Shared Function VariantesDeCristalBasicos(ByVal da As IDataAccessAdapter, ByVal articuloId As Integer) As IQueryable

            If da Is Nothing Then
                da = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
            End If
            Dim db As New LinqMetaData(da)
            Return (From v In db.DV_Cristal Where v.ArticuloIdGuia = articuloId Select New With {.Id = v.Id, .Nombre = v.DescripcionVariante})

        End Function


        Public Overrides Function SaveEntity(ByVal da As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter, ByVal entity As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2) As Boolean

            Dim flagDa As Boolean = False, flagTrn As Boolean = False
            If da Is Nothing Then
                da = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                flagDa = True
            End If
            If Not da.IsTransactionInProgress Then
                da.StartTransaction(IsolationLevel.ReadCommitted, "trn")
                flagTrn = True
            End If
            Dim cristal As DV_CristalEntity = entity
            Try
                cristal.Vendible = True
                'Si ya no maneja variante entonces inactivar todas las variantes
                If Not cristal.IsNew AndAlso (Not cristal.GuiaDeVariante AndAlso cristal.Fields(DV_CristalFieldIndex.GuiaDeVariante).DbValue OrElse
                    cristal.GuiaDeVariante AndAlso Not cristal.Fields(DV_CristalFieldIndex.GuiaDeVariante).DbValue) Then
                    InactivarActivarVariantes(da, cristal)
                End If
                If cristal.IsNew Then
                    cristal.ArticuloClaseId = ArticuloClase.Cristal
                End If
                MyBase.SaveEntity(da, entity)
                If flagTrn Then
                    da.Commit()
                End If
                Return True
            Catch ex As Exception
                If flagTrn AndAlso da.IsTransactionInProgress Then
                    da.Rollback()
                End If
                Throw
            Finally
                If flagDa Then
                    da.Dispose()
                End If
            End Try

        End Function

        Private Shared Sub InactivarActivarVariantes(ByVal da As IDataAccessAdapter, ByVal cristal As DV_CristalEntity)
            Dim db As New LinqMetaData(da)
            Dim q = (From v In db.DV_Cristal Where v.ArticuloIdGuia = cristal.Id Select v)
            Dim variantes As EntityCollection(Of DV_CristalEntity) =
                        CType(q, ILLBLGenProQuery).Execute(Of EntityCollection(Of DV_CristalEntity))()
            For Each variante As DV_CristalEntity In variantes
                variante.Activo = cristal.GuiaDeVariante
            Next
            da.SaveEntityCollection(variantes)
        End Sub

        Public Overrides Function GetDataForComboAsQueryable(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable
            If adapter Is Nothing Then
                adapter = CreateAdapter()
            End If
            Dim db As New LinqMetaData(adapter)
            Return (From c In db.DV_Cristal Select c.Id, c.Descripcion)
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

        Public Shared Function GetQueryableForCristalesGuiaDeVarianteCompras(ByRef da As IDataAccessAdapter, ByVal documento As DocumentoEntradaEntity, ByVal modoLibre As Boolean) As System.Linq.IQueryable
            If da Is Nothing Then
                da = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
            End If
            Dim localId As Integer = LocalController.BuscarLocalIdFromDeposito(da, documento.DepositoId)
            Dim db As New LinqMetaData(da)
            'Los artículos asociados al proveedor, asociados al depósito y asociados al local del depósito y activos
            Dim q = (From c In db.DV_Cristal Where c.GuiaDeVariante = True AndAlso c.Activo = True)

            If Not modoLibre Then
                q = (From c In q Where (From p In c.Proveedores
                                        Where (From pl In p.PorLocal Where pl.ProveedorId = documento.ProveedorId AndAlso
                                        pl.MonedaId = documento.MonedaId AndAlso pl.LocalId = localId).Any()).Any() _
                    AndAlso (From s In c.Stock Where s.DepositoId = documento.DepositoId).Any() _
                    AndAlso (From l In c.Locales Where l.LocalId = localId AndAlso l.Activo = True).Any()
                     Select c)

            End If
            'Todos los articulo que estén asociados a TODOS los depósitos de la lista
            'If depositos IsNot Nothing AndAlso depositos.Count > 0 Then
            '    q = (From c In q Where (From s In c.Stock Where depositos.Contains(s.DepositoId)).Count() = depositos.Count())
            'End If
            Return (From c In q Select c.Id, c.Descripcion)

        End Function

        Public Shared Shadows Function GetMatrixData(ByVal detalles As Studio.Phone.DAL.HelperClasses.EntityCollection(Of AjusteDetalleEntity)) As CristalesMatrixData

            Dim toReturn As New CristalesMatrixData
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                For Each detalle As AjusteDetalleEntity In detalles
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

                    Dim guias As List(Of DV_CristalEntity) = GetGuiasDeArticulos(da, cristales.Select(Function(f) f.ArticuloIdGuia.Value).Distinct().ToList())
                    For Each guia As DV_CristalEntity In guias

                        Dim toAdd As New CristalData With {.ArticuloId = guia.Id, .Descripcion = guia.Descripcion, .PlantillaId1 = guia.Plantilla.AAtributoPlantillaID1, .PlantillaId2 = guia.Plantilla.AAtributoPlantillaID2}
                        toReturn.Cristales.Add(toAdd)

                        For Each detalle As AjusteDetalleEntity In detalles.Where(Function(f) f.Articulo.ArticuloIdGuia = toAdd.ArticuloId)

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

        Public Shared Shadows Function GetMatrixData(ByVal detalles As Studio.Phone.DAL.HelperClasses.EntityCollection(Of TraspasoDetalleEntity)) As CristalesMatrixData

            Dim toReturn As New CristalesMatrixData
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                For Each detalle As TraspasoDetalleEntity In detalles
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

                    Dim guias As List(Of DV_CristalEntity) = GetGuiasDeArticulos(da, cristales.Select(Function(f) f.ArticuloIdGuia.Value).Distinct().ToList())
                    For Each guia As DV_CristalEntity In guias

                        Dim toAdd As New CristalData With {.ArticuloId = guia.Id, .Descripcion = guia.Descripcion, .PlantillaId1 = guia.Plantilla.AAtributoPlantillaID1, .PlantillaId2 = guia.Plantilla.AAtributoPlantillaID2}
                        toReturn.Cristales.Add(toAdd)

                        For Each detalle As TraspasoDetalleEntity In detalles.Where(Function(f) f.Articulo.ArticuloIdGuia = toAdd.ArticuloId)

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
                                                                     .Valor = detalle.CantidadEnviada})

                        Next
                    Next
                End If

            End Using
            Return toReturn
        End Function

        Public Shared Shadows Function GetMatrixData(ByVal detalles As Studio.Phone.DAL.HelperClasses.EntityCollection(Of DocEntradaDetalleEntity)) As CristalesMatrixData

            Dim toReturn As New CristalesMatrixData
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                For Each detalle As DocEntradaDetalleEntity In detalles
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

                    Dim guias As List(Of DV_CristalEntity) = GetGuiasDeArticulos(da, cristales.Select(Function(f) f.ArticuloIdGuia.Value).Distinct().ToList())
                    For Each guia As DV_CristalEntity In guias

                        Dim toAdd As New CristalData With {.ArticuloId = guia.Id, .Descripcion = guia.Descripcion, .PlantillaId1 = guia.Plantilla.AAtributoPlantillaID1, .PlantillaId2 = guia.Plantilla.AAtributoPlantillaID2}
                        toReturn.Cristales.Add(toAdd)

                        For Each detalle As DocEntradaDetalleEntity In detalles.Where(Function(f) f.Articulo.ArticuloIdGuia = toAdd.ArticuloId)

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

        Public Shared Shadows Function GetMatrixData(ByVal detalles As EntityCollection(Of ListaPreVtaLinEntity)) As CristalesMatrixData

            Dim toReturn As New CristalesMatrixData
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                For Each detalle As ListaPreVtaLinEntity In detalles
                    If detalle.Articulo Is Nothing Then
                        detalle.Articulo = da.FetchNewEntity(Of ArticuloEntity)(detalle.GetRelationInfoArticulo(), ArticuloController.CrearPrefetchPorCombinacionesYValores())
                    End If
                    If detalle.Articulo.CombinacionesDeVariante.Count = 0 Then
                        da.FetchEntityCollection(detalle.Articulo.CombinacionesDeVariante, detalle.Articulo.GetRelationInfoCombinacionesDeVariante(), ArticuloVariante_CombinacionBEntity.CrearPrefetchPorValor())
                    End If
                Next

                Dim cristales As List(Of DV_CristalEntity) = detalles.Where(Function(f) (TypeOf f.Articulo Is DV_CristalEntity)).Select(Function(f) DirectCast(f.Articulo, DV_CristalEntity)).ToList()
                Dim fieldsBuffer As New Dictionary(Of Integer, IEntityField2)

                'If cristales.Count > 0 Then

                Dim guias As List(Of DV_CristalEntity) = GetGuiasDeArticulos(da, cristales.Select(Function(f) f.ArticuloIdGuia.Value).Distinct().ToList())
                For Each guia As DV_CristalEntity In guias

                    Dim toAdd As New CristalData With {.ArticuloId = guia.Id, .Descripcion = guia.Descripcion, .PlantillaId1 = guia.Plantilla.AAtributoPlantillaID1, .PlantillaId2 = guia.Plantilla.AAtributoPlantillaID2}
                    toReturn.Cristales.Add(toAdd)

                    For Each detalle As ListaPreVtaLinEntity In detalles.Where(Function(f) f.Articulo.ArticuloIdGuia = toAdd.ArticuloId)

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
                                                                .PlantillaValor2 = detalle.Articulo.CombinacionesDeVariante(1).ValorDePlantilla.Fields(field2.Name).CurrentValue})

                        With toAdd.Valores(toAdd.Valores.Count - 1)
                            .SetValor(detalle.Importe)
                        End With

                    Next
                Next
                'End If

            End Using
            Return toReturn
        End Function

        Public Shared Shadows Function GetMatrixData(ByVal detalles As EntityCollection(Of Articulo_Local_ProveedorEntity)) As CristalesMatrixData

            Dim toReturn As New CristalesMatrixData
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                For Each detalle As Articulo_Local_ProveedorEntity In detalles
                    If detalle.ArticuloProveedor Is Nothing Then
                        detalle.ArticuloProveedor = da.FetchNewEntity(Of Articulo_ProveedorEntity)(detalle.GetRelationInfoArticuloProveedor(), ArticuloController.CrearPrefetchPorCombinacionesYValores())
                    End If
                    If detalle.ArticuloProveedor.Articulo Is Nothing Then
                        detalle.ArticuloProveedor.Articulo = da.FetchNewEntity(Of ArticuloEntity)(detalle.ArticuloProveedor.GetRelationInfoArticulo(), ArticuloController.CrearPrefetchPorCombinacionesYValores())
                    End If
                    If detalle.ArticuloProveedor.Articulo.CombinacionesDeVariante.Count = 0 Then
                        da.FetchEntityCollection(detalle.ArticuloProveedor.Articulo.CombinacionesDeVariante, detalle.ArticuloProveedor.Articulo.GetRelationInfoCombinacionesDeVariante(), ArticuloVariante_CombinacionBEntity.CrearPrefetchPorValor())
                    End If
                Next

                Dim cristales As List(Of DV_CristalEntity) = detalles.Where(Function(f) (TypeOf f.ArticuloProveedor.Articulo Is DV_CristalEntity)).Select(Function(f) DirectCast(f.ArticuloProveedor.Articulo, DV_CristalEntity)).ToList()
                Dim fieldsBuffer As New Dictionary(Of Integer, IEntityField2)

                'If cristales.Count > 0 Then

                Dim guias As List(Of DV_CristalEntity) = GetGuiasDeArticulos(da, cristales.Select(Function(f) f.ArticuloIdGuia.Value).Distinct().ToList())
                For Each guia As DV_CristalEntity In guias

                    Dim toAdd As New CristalData With {.ArticuloId = guia.Id, .Descripcion = guia.Descripcion, .PlantillaId1 = guia.Plantilla.AAtributoPlantillaID1, .PlantillaId2 = guia.Plantilla.AAtributoPlantillaID2}
                    toReturn.Cristales.Add(toAdd)

                    For Each detalle As Articulo_Local_ProveedorEntity In detalles.Where(Function(f) f.ArticuloProveedor.Articulo.ArticuloIdGuia = toAdd.ArticuloId)

                        Dim plantillaID1 = detalle.ArticuloProveedor.Articulo.CombinacionesDeVariante(0).AAtributoPlantillaID
                        Dim plantillaID2 = detalle.ArticuloProveedor.Articulo.CombinacionesDeVariante(1).AAtributoPlantillaID

                        If Not fieldsBuffer.ContainsKey(plantillaID1) Then
                            fieldsBuffer.Add(plantillaID1, AAtributoPlantillaValorBEntity.GetFieldFromPlantilla(AAtributoPlantillaBEntity.GetById(da, plantillaID1)))
                        End If
                        If Not fieldsBuffer.ContainsKey(plantillaID2) Then
                            fieldsBuffer.Add(plantillaID2, AAtributoPlantillaValorBEntity.GetFieldFromPlantilla(AAtributoPlantillaBEntity.GetById(da, plantillaID2)))
                        End If

                        Dim field1 As IEntityField2 = fieldsBuffer(plantillaID1)
                        Dim field2 As IEntityField2 = fieldsBuffer(plantillaID2)

                        toAdd.Valores.Add(New CristalValor With {.ArticuloId = detalle.ArticuloId,
                                                                .PlantillaValorID1 = detalle.ArticuloProveedor.Articulo.CombinacionesDeVariante(0).AAtributoPlantillaValorID,
                                                                .PlantillaValorID2 = detalle.ArticuloProveedor.Articulo.CombinacionesDeVariante(1).AAtributoPlantillaValorID,
                                                                .PlantillaValor1 = detalle.ArticuloProveedor.Articulo.CombinacionesDeVariante(0).ValorDePlantilla.Fields(field1.Name).CurrentValue,
                                                                .PlantillaValor2 = detalle.ArticuloProveedor.Articulo.CombinacionesDeVariante(1).ValorDePlantilla.Fields(field2.Name).CurrentValue})

                        With toAdd.Valores(toAdd.Valores.Count - 1)
                            .SetValor(detalle.ImporteFinal)
                        End With

                    Next
                Next
                'End If

            End Using
            Return toReturn
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

        Public Shared Sub UpdateMatrixData(ByVal dsSource As CristalesMatrixData, ByVal detalles As Studio.Phone.DAL.HelperClasses.EntityCollection(Of AjusteDetalleEntity))
            'Eliminar los datos viejos
            detalles.RemoveRange(detalles.Where(Function(f) (TypeOf f.Articulo Is DV_CristalEntity)).ToList())
            For Each guia As CristalData In dsSource.Cristales
                For Each valor As CristalValor In guia.Valores.Where(Function(f) f.Valor > Decimal.Zero AndAlso f.ArticuloId > 0)
                    detalles.Add(New AjusteDetalleEntity With {.ArticuloId = valor.ArticuloId, .Numero = detalles.Count + 1, .Cantidad = valor.Valor})
                Next
            Next
        End Sub

        Public Shared Sub UpdateMatrixData(ByVal dsSource As CristalesMatrixData, ByVal detalles As Studio.Phone.DAL.HelperClasses.EntityCollection(Of TraspasoDetalleEntity))
            'Eliminar los datos viejos
            detalles.RemoveRange(detalles.Where(Function(f) (TypeOf f.Articulo Is DV_CristalEntity)).ToList())
            For Each guia As CristalData In dsSource.Cristales
                For Each valor As CristalValor In guia.Valores.Where(Function(f) f.Valor > Decimal.Zero AndAlso f.ArticuloId > 0)
                    detalles.Add(New TraspasoDetalleEntity With {.ArticuloId = valor.ArticuloId, .Numero = detalles.Count + 1, .CantidadEnviada = valor.Valor, .CantidadOriginal = valor.Valor, .CantidadRecibida = Decimal.Zero})
                Next
            Next
        End Sub

        Public Shared Sub UpdateMatrixData(ByVal dsSource As CristalesMatrixData, ByVal documento As DocumentoEntradaEntity)

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)

                'Eliminar los datos viejos
                Dim detalles As EntityCollection(Of DocEntradaDetalleEntity) = documento.Detalles
                detalles.RemoveRange(detalles.Where(Function(f) (TypeOf f.Articulo Is DV_CristalEntity)).ToList())
                For Each guia As CristalData In dsSource.Cristales
                    For Each valor As CristalValor In guia.Valores.Where(Function(f) f.Valor > Decimal.Zero AndAlso f.ArticuloId > 0)
                        detalles.Add(New DocEntradaDetalleEntity With {.ArticuloId = valor.ArticuloId,
                                                                       .Numero = detalles.Count + 1, .Cantidad = valor.Valor,
                                                                       .Descripcion = ArticuloController.DescripcionFromId(da, valor.ArticuloId)
                                                                      })
                    Next
                Next
            End Using

        End Sub

        Public Shared Sub SaveMatrixData(ByVal dsSource As CristalesMatrixData, ByVal listaPreVtaId As Integer, ByVal monedaId As Integer, ByVal articuloId As Integer)

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                Try
                    da.StartTransaction(IsolationLevel.ReadCommitted, "ttt")
                    Dim detalles As EntityCollection(Of ListaPreVtaLinEntity) = ListaPreVtaLinBEntity.GetByListaMonedaYGuiaVariante(da, listaPreVtaId, monedaId, articuloId)
                    For Each guia As CristalData In dsSource.Cristales
                        Dim varianteId As Integer = guia.ArticuloId
                        For Each valor As CristalValor In guia.Valores.Where(Function(f) f.IsChanged AndAlso f.ArticuloId > 0)
                            Dim detalle As ListaPreVtaLinEntity = detalles.SingleOrDefault(Function(f) f.ArticuloId = valor.ArticuloId)
                            If detalle Is Nothing Then
                                detalle = New ListaPreVtaLinEntity With {.ArticuloId = valor.ArticuloId, .ListaPrecioVentaId = listaPreVtaId, .MonedaId = monedaId, .EscalaInicial = Decimal.One, .EscalaFinal = Decimal.Zero}
                                detalles.Add(detalle)
                            End If
                            detalle.Importe = valor.Valor
                            'detalles.Add(New TraspasoDetalleEntity With {.ArticuloId = valor.ArticuloId, .Numero = detalles.Count + 1, .CantidadEnviada = valor.Valor, .CantidadOriginal = valor.Valor, .CantidadRecibida = Decimal.Zero})
                        Next
                    Next
                    Dim validator As New Studio.Net.BLL.ValidatorHelper
                    Dim precioGuia As ListaPreVtaLinEntity = ListaPreVtaLinController.BuscarporPk(da, listaPreVtaId, articuloId, monedaId, 1I)
                    If precioGuia Is Nothing Then
                        precioGuia = New ListaPreVtaLinEntity With {.ArticuloId = articuloId, .ListaPrecioVentaId = listaPreVtaId, .MonedaId = monedaId, .EscalaInicial = Decimal.One, .EscalaFinal = Decimal.Zero}
                    End If
                    detalles.Add(precioGuia)
                    validator.Validate(detalles, False)
                    da.SaveEntityCollection(detalles)
                    da.Commit()
                Catch
                    If da.IsTransactionInProgress Then
                        da.Rollback()
                    End If
                    Throw

                End Try
            End Using

        End Sub

        Public Shared Sub SaveMatrixDataPreciosCompra(ByVal dsSource As CristalesMatrixData, ByVal proveedorId As Integer, ByVal monedaId As Integer, ByVal articuloId As Integer, localId As Integer)

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                Try
                    da.StartTransaction(IsolationLevel.ReadCommitted, "ttt")
                    Dim artGuia As Articulo_Local_ProveedorEntity = Articulo_Local_ProveedorController.BuscarPorPk(da, articuloId, proveedorId, monedaId, localId)
                    If artGuia Is Nothing Then
                        artGuia = New Articulo_Local_ProveedorEntity With {.ArticuloId = articuloId, .ProveedorId = proveedorId, .MonedaId = monedaId, .LocalId = localId, .ImporteLista = Decimal.Zero}
                        Dim artProv As Articulo_ProveedorEntity = Articulo_ProveedorController.BuscarPorArticuloIdAndProveedorId(da, articuloId, proveedorId)
                        If artProv Is Nothing Then
                            artProv = New Articulo_ProveedorEntity With {.ArticuloId = articuloId, .ProveedorId = proveedorId, .Activo = True, .Codigo = articuloId.ToString(), .Descripcion = ArticuloController.DescripcionFromId(da, articuloId), .FactorEmpaque = Decimal.One}
                        End If
                        artGuia.ArticuloProveedor = artProv
                        da.SaveEntity(artGuia, True, True)
                    End If

                    Dim detalles As EntityCollection(Of Articulo_Local_ProveedorEntity) = Articulo_Local_ProveedorBEntity.GetByProveedorArticuloYMoneda(da, proveedorId, monedaId, articuloId)
                    For Each guia As CristalData In dsSource.Cristales
                        Dim varianteId As Integer = guia.ArticuloId
                        For Each valor As CristalValor In guia.Valores.Where(Function(f) f.IsChanged AndAlso f.ArticuloId > 0)
                            Dim detalle As Articulo_Local_ProveedorEntity = detalles.SingleOrDefault(Function(f) f.ArticuloId = valor.ArticuloId)
                            If detalle Is Nothing Then
                                Dim artProv As Articulo_ProveedorEntity = Articulo_ProveedorController.BuscarPorArticuloIdAndProveedorId(da, valor.ArticuloId, proveedorId)
                                If artProv Is Nothing Then
                                    artProv = New Articulo_ProveedorEntity With {.ArticuloId = valor.ArticuloId, .ProveedorId = proveedorId, .Descripcion = ArticuloController.DescripcionFullFromId(da, valor.ArticuloId), .Codigo = valor.ArticuloId.ToString(), .FactorEmpaque = Decimal.One}
                                End If

                                detalle = New Articulo_Local_ProveedorEntity With {.ArticuloId = valor.ArticuloId, .ProveedorId = proveedorId, .MonedaId = monedaId}
                                detalle.ArticuloProveedor = artProv
                                detalles.Add(detalle)

                            End If
                            detalle.ImporteLista = valor.Valor
                        Next
                    Next
                    Dim validator As New Studio.Net.BLL.ValidatorHelper
                    Dim precioGuia As Articulo_Local_ProveedorEntity = Articulo_Local_ProveedorController.BuscarPorPk(da, proveedorId, articuloId, monedaId, localId)
                    If precioGuia Is Nothing Then
                        precioGuia = New Articulo_Local_ProveedorEntity With {.ArticuloId = articuloId, .ProveedorId = proveedorId, .MonedaId = monedaId, .LocalId = localId}
                    End If
                    detalles.Add(precioGuia)
                    validator.Validate(detalles, False)
                    da.SaveEntityCollection(detalles)
                    da.Commit()
                Catch
                    If da.IsTransactionInProgress Then
                        da.Rollback()
                    End If
                    Throw

                End Try
            End Using

        End Sub


        Public Shared Function GetQueryableParaControlDeStock(ByRef adapter As SD.LLBLGen.Pro.ORMSupportClasses.IDataAccessAdapter) As System.Linq.IQueryable
            If adapter Is Nothing Then
                adapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
            End If
            Dim db As New LinqMetaData(adapter)
            Dim q = (From a In db.DV_Cristal Where a.ControlaStock = True AndAlso a.Activo = True _
                   AndAlso a.GuiaDeVariante = True AndAlso a.Material IsNot Nothing
                     Select a.Id, a.Descripcion)
            Return q
        End Function

        ''' <summary>
        ''' Devuelve el artículo consultado y todos los datos relacionados que se necesitan para
        ''' cargar la matriz de stock
        ''' </summary>
        ''' <param name="articuloId"></param>
        ''' <param name="depositoId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDataForControlStock(ByVal articulos As List(Of Integer), ByVal depositoId As Integer) As IEntityCollection2

            Dim prefetch As IPrefetchPath2 = New PrefetchPath2(CInt(EntityType.DV_CristalEntity))
            Dim fields As New ExcludeIncludeFieldsList(False)
            fields.Add(DV_CristalFields.Descripcion)
            prefetch.Add(DV_CristalEntity.PrefetchPathPlantilla)
            Dim variante As IPrefetchPathElement2 = prefetch.Add(DV_CristalEntity.PrefetchPathVariantes, fields)
            variante.SubPath.Add(DV_CristalEntity.PrefetchPathPlantilla)
            variante.SubPath.Add(DV_CristalEntity.PrefetchPathStock, 0I, New PredicateExpression(Deposito_ArticuloFields.DepositoId = depositoId))
            variante.SubPath.Add(DV_CristalEntity.PrefetchPathCombinacionesDeVariante).SubPath.Add(ArticuloVariante_CombinacionEntity.PrefetchPathValorDePlantilla)

            Return (New DV_CristalBEntity).GetData(Nothing, New RelationPredicateBucket(DV_CristalFields.Id = articulos), 0I, Nothing, prefetch, fields)

        End Function
        ''' <summary>
        ''' Devuelve el artículo consultado y todos los datos relacionados que se necesitan para
        ''' cargar la matriz de stock
        ''' </summary>
        ''' <param name="articuloId"></param>
        ''' <param name="depositoId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDataForControlStockAFecha(ByVal articulos As List(Of Integer), ByVal depositoId As Integer, fecha As Date) As IEntityCollection2

            Dim prefetch As IPrefetchPath2 = New PrefetchPath2(CInt(EntityType.DV_CristalEntity))
            Dim fields As New ExcludeIncludeFieldsList(False)
            fields.Add(DV_CristalFields.Descripcion)
            prefetch.Add(DV_CristalEntity.PrefetchPathPlantilla)
            Dim variante As IPrefetchPathElement2 = prefetch.Add(DV_CristalEntity.PrefetchPathVariantes, fields)
            variante.SubPath.Add(DV_CristalEntity.PrefetchPathPlantilla)
            'variante.SubPath.Add(DV_CristalEntity.PrefetchPathStock, 0I, New PredicateExpression(Deposito_ArticuloFields.DepositoId = depositoId))
            variante.SubPath.Add(DV_CristalEntity.PrefetchPathMovimientos, 0I, New PredicateExpression(MovimientoDetalleFields.DepositoId = depositoId And MovimientoDetalleFields.Fecha < fecha.AddDays(1)))
            variante.SubPath.Add(DV_CristalEntity.PrefetchPathCombinacionesDeVariante).SubPath.Add(ArticuloVariante_CombinacionEntity.PrefetchPathValorDePlantilla)

            Return (New DV_CristalBEntity).GetData(Nothing, New RelationPredicateBucket(DV_CristalFields.Id = articulos), 0I, Nothing, prefetch, fields)

        End Function

        ''' <summary>
        ''' Devuelve el artículo consultado y todos los datos relacionados que se necesitan para
        ''' cargar la matriz de stock
        ''' </summary>
        ''' <param name="articuloId"></param>
        ''' <param name="depositoId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDataForVentas(ByVal articulos As List(Of Integer), ByVal fechaDesde As Date, fechaHasta As Date) As IEntityCollection2
            Dim prefetch As IPrefetchPath2 = New PrefetchPath2(CInt(EntityType.DV_CristalEntity))
            Dim fields As New ExcludeIncludeFieldsList(False)
            fields.Add(DV_CristalFields.Descripcion)
            prefetch.Add(DV_CristalEntity.PrefetchPathPlantilla)
            Dim variante As IPrefetchPathElement2 = prefetch.Add(DV_CristalEntity.PrefetchPathVariantes, fields)
            variante.SubPath.Add(DV_CristalEntity.PrefetchPathPlantilla)
            Dim subExpr As New PredicateExpression
            If fechaDesde > DateTime.MinValue Then
                subExpr.Add(DocumentoSalidaFields.FechaEmitida >= fechaDesde)
            End If
            If fechaHasta > DateTime.MinValue Then
                subExpr.Add(DocumentoSalidaFields.FechaEmitida <= fechaHasta)
            End If
            subExpr.Add(DocSalidaDetalleFields.DocumentoSalidaId = DocumentoSalidaFields.Id And DocSalidaDetalleFields.CajaId = DocumentoSalidaFields.CajaId And DocumentoSalidaFields.MovimientoArticulos = True)
            Dim subFiltro As New PredicateExpression(New FieldCompareSetPredicate(DocSalidaDetalleFields.ImpuestoId, Nothing, DocumentoSalidaFields.Id, Nothing, SetOperator.Exist, subExpr))

            Dim fieldsDetalle As New ExcludeIncludeFieldsList(False, New IEntityFieldCore() {DocSalidaDetalleFields.ArticuloId, DocSalidaDetalleFields.Cantidad, DocSalidaDetalleFields.DocumentoSalidaId, DocSalidaDetalleFields.CajaId})
            Dim fieldsCabezal As New ExcludeIncludeFieldsList(False, New IEntityFieldCore() {DocumentoSalidaFields.DocumentoTipoId})

            variante.SubPath.Add(DV_CristalEntity.PrefetchPathVentas, 0I, subFiltro, Nothing, Nothing, Nothing, fieldsDetalle).SubPath.Add(DocSalidaDetalleEntity.PrefetchPathVenta, fieldsCabezal).SubPath.Add(DocumentoSalidaEntity.PrefetchPathDocumentoTipo).SubPath.Add(DocumentoTipoEntity.PrefetchPathSigno)
            variante.SubPath.Add(DV_CristalEntity.PrefetchPathCombinacionesDeVariante).SubPath.Add(ArticuloVariante_CombinacionEntity.PrefetchPathValorDePlantilla)
            Dim filtro As New RelationPredicateBucket(DV_CristalFields.Id = articulos)
            'filtro.Relations.Add(DV_CristalEntity.Relations.DocSalidaDetalleEntityUsingArticuloId)
            'filtro.Relations.Add(DocSalidaDetalleEntity.Relations.DocumentoSalidaEntityUsingCajaIdDocumentoSalidaId)


            Return (New DV_CristalBEntity).GetData(Nothing, filtro, 0I, Nothing, prefetch, fields)
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

        Public Shared Function GetByIdForReceta(da As IDataAccessAdapter, Id As Integer) As DV_CristalEntity

            Dim fields As New ExcludeIncludeFieldsList(False)
            fields.Add(DV_CristalFields.CristalPlantillaID)
            fields.Add(DV_CristalFields.GuiaDeVariante)
            fields.Add(DV_CristalFields.CristalPlantillaID)
            fields.Add(DV_CristalFields.Descripcion)
            fields.Add(DV_CristalFields.DescripcionVariante)

            Return da.FetchNewEntity(Of DV_CristalEntity)(New RelationPredicateBucket(DV_CristalFields.Id = Id), Nothing, Nothing, fields)

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
                                                ByVal parametroTree As VisionParametroTree) As IQueryable

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

            Return (From c In q Select c.Id, c.Descripcion, c.DescripcionVariante)

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
        '    Public Shared Function GetQueryableForCompra(ByRef da As IDataAccessAdapter, _
        '                                            ByVal cilindrico1 As Decimal, ByVal cilindrico2 As Decimal, _
        '                                            ByVal esferico1 As Decimal, ByVal esferico2 As Decimal, _
        '                                            ByVal adicion1 As Decimal, adicion2 As Decimal, _
        '                                            ByVal proveedorId As Integer, depositoId As Integer, monedaId As Integer, _
        '                                            ByVal cristalMaterialID As Integer, ByVal tipo As Integer, _
        '                                            ByVal parametroTree As VisionParametroTree) As IQueryable

        '        If da Is Nothing Then
        '            da = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
        '        End If

        '        Dim db As New LinqMetaData(da)
        '        Dim q = (From c In db.DV_Cristal Where c.Vendible = True AndAlso c.VisibleEnReceta = True AndAlso c.Activo = True AndAlso c.ArticuloGuiaDeVariante Is Nothing _
        '                 AndAlso c.Tipo = tipo AndAlso c.CristalMaterialId = cristalMaterialID AndAlso _
        '                (c.Clasificacion = CInt(CristalClasificacion.Maquina) OrElse parametroTree.Optica.Venta.EsfericoMaxParaTerminados = Decimal.Zero OrElse _
        '                 (Math.Abs(esferico1) <= parametroTree.Optica.Venta.EsfericoMaxParaTerminados AndAlso Math.Abs(esferico2) <= parametroTree.Optica.Venta.EsfericoMaxParaTerminados)) AndAlso _
        '             ( _
        '                 (c.GuiaDeVariante = False AndAlso (From loc In c.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso _
        '                   (From p In c.PreciosPorGraduacion Where p.ListaPreVtaId = listaPrecioVentaId AndAlso _
        '                     p.EsfericoDesde <= esferico1 AndAlso p.EsfericoHasta >= esferico1 AndAlso _
        '                     ((p.CilindricoDesde <= cilindrico1 AndAlso p.CilindricoHasta >= cilindrico1) AndAlso (p.AdicionDesde <= adicion1 AndAlso p.AdicionHasta >= adicion1))).Any() AndAlso _
        '                    (From p In c.PreciosPorGraduacion Where p.ListaPreVtaId = listaPrecioVentaId AndAlso _
        '                    ((p.CilindricoDesde <= cilindrico2 AndAlso p.CilindricoHasta >= cilindrico2) AndAlso (p.AdicionDesde <= adicion2 AndAlso p.AdicionHasta >= adicion2)) AndAlso _
        '                p.EsfericoDesde <= esferico2 AndAlso p.EsfericoHasta >= esferico2).Any()) _
        '              OrElse
        '              ( _
        '                  (From var In _
        '                      (From col In c.Variantes Where _
        '                            (From v In col.CombinacionesDeVariante Where ((v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesCilindrico _
        '                            AndAlso v.ValorDePlantilla.ValorDecimal = cilindrico1) OrElse (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesAdicion _
        '                            AndAlso v.ValorDePlantilla.ValorDecimal = adicion1))).Any() AndAlso _
        '                            (From v In col.CombinacionesDeVariante Where (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesEsferico _
        '                            AndAlso v.ValorDePlantilla.ValorDecimal = esferico1)).Any()) _
        '                    Where (From loc In var.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso _
        '                        (From p In var.PreciosDeVenta Where p.ListaPrecioVentaId = listaPrecioVentaId).Any()).Any() AndAlso _
        '        (From var In _
        '                      (From col In c.Variantes Where _
        '                            (From v In col.CombinacionesDeVariante Where ((v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesCilindrico _
        '                            AndAlso v.ValorDePlantilla.ValorDecimal = cilindrico2) OrElse (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesAdicion _
        '                            AndAlso v.ValorDePlantilla.ValorDecimal = adicion2))).Any() AndAlso _
        '                            (From v In col.CombinacionesDeVariante Where (v.AAtributoPlantillaID = parametroTree.Optica.AAtributoPlantillaIDCristalesEsferico _
        '                            AndAlso v.ValorDePlantilla.ValorDecimal = esferico2)).Any()) _
        '                    Where (From loc In var.Locales Where (From cj In loc.Local.Caja Where cj.Id = ConfigReaderSpecific.GetCajaId()).Any() AndAlso loc.Activo = True).Any() AndAlso _
        '                        (From p In var.PreciosDeVenta Where p.ListaPrecioVentaId = listaPrecioVentaId).Any()).Any()
        '       )))

        '        Return (From c In q Select c.Id, c.Descripcion, c.DescripcionVariante)

        '    End Function

    End Class

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

            'whereExpr.AppendLine(String.Format(" AND ({0} = null) AND ({2} = {3} AND {4} = {5})))", _
            '                                   DV_CristalFieldIndex.ArticuloIdGuia.ToString(), _
            '                                   DV_CristalFieldIndex.Esferico.ToString(), Esferico, _
            '                                   DV_CristalFieldIndex.Cilindrico.ToString(), Cilindrico))

            'Dim predicate = PredicateBuilder.Null(Of DV_CristalEntity)()
            'predicate.And(Function(c) c.Tipo = RecetaTipoId AndAlso c.CristalMaterialId = CristalMaterialId)

            'Dim subExpr = PredicateBuilder.Null(Of DV_CristalEntity)()
            'subExpr.And(Function(c) c.GuiaDeVariante = False)
            'subExpr.Or(Function(c) c.ArticuloIdGuia IsNot Nothing AndAlso c.Esferico = Esferico AndAlso c.Cilindrico = Cilindrico AndAlso c.Diametro = Diametro)

            'predicate.And(subExpr)

            Dim q = db.DV_Cristal.Where(whereExpr.ToString(), Nothing)
            Return q.Select(Function(c) New With {c.Id, c.Descripcion})

            'Return q

        End Function


    End Class


    Public Class CristalBEntityParaBonificacionDinamica
        Inherits ArticuloBEntity

        Protected Overrides Function CreateEntityFactory() As IEntityFactory2
            Return New DV_CristalEntityFactory
        End Function

        Public Overrides Function GetDataForCombo(ByVal da As IDataAccessAdapter, ByVal filterFields() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityField2, ByVal filterResult As Boolean, ByVal filtro As IRelationPredicateBucket, ByVal sort As SortExpression, ByVal maxItems As Integer) As System.Data.DataTable
            Return MyBase.GetDataForCombo(da, filterFields, filterResult, CrearFiltroParaBonificacionDinamica(), sort, maxItems)
        End Function

        Private Shared Function CrearFiltroParaBonificacionDinamica() As IRelationPredicateBucket
            Dim toReturn As New RelationPredicateBucket
            toReturn.PredicateExpression.Add(ArticuloFields.Activo = True And ArticuloFields.Vendible = True And (ArticuloFields.GuiaDeVariante = True) And ArticuloFields.ArticuloIdGuia = DBNull.Value)
            Return toReturn

        End Function

    End Class


End Namespace