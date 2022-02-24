Imports DevExpress.Data.Filtering
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.Linq
Imports Studio.Net.BLL
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports SD.LLBLGen.Pro.LinqSupportClasses
Imports System.Linq
Imports System.Linq.Dynamic
Imports Studio.Phone.DAL
Imports Studio.Phone.BLL

Public Class UtilsForm
    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click

        Try
            Using daS As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                Using daD As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                    daD.ConnectionString = txtCSDest.Text
                    Dim cnv As New CriteriaConverter(New ArticuloEntity, Nothing)

                    Dim filterToApply As New RelationPredicateBucket(cnv.Convert(CriteriaOperator.Parse(txtFiltroDest.Text)))
                    filterToApply.Relations.AddRange(cnv.Relations)

                    Dim artsS As New EntityCollection(Of ArticuloEntity)

                    Dim artsD As New EntityCollection(Of ArticuloEntity)

                    Dim dbD As New LinqMetaData(daD)
                    Dim dbs As New LinqMetaData(daS)

                    Dim prefetch As New PrefetchPath2(CInt(EntityType.ArticuloEntity))
                    prefetch.Add(ArticuloEntity.PrefetchPathRubro())
                    prefetch.Add(ArticuloEntity.PrefetchPathMarca())
                    prefetch.Add(ArticuloEntity.PrefetchPathModelo())
                    prefetch.Add(ArticuloEntity.PrefetchPathNivelDeArticulo())
                    prefetch.Add(ArticuloEntity.PrefetchPathImpuestos())

                    daS.FetchEntityCollection(artsS, filterToApply, prefetch)
                    daD.StartTransaction(IsolationLevel.ReadCommitted, "ttt")

                    'RUBROS
                    Dim rubrosD As New EntityCollection(Of RubroEntity)
                    daD.FetchEntityCollection(rubrosD, New RelationPredicateBucket(RubroFields.Id <= 11))

                    For Each rubroD As RubroEntity In rubrosD
                        If rubroD.IdExterno = 0 Then
                            rubroD.IdExterno = rubroD.Id
                        End If
                    Next

                    'MARCAS
                    Dim MarcasD As New EntityCollection(Of MarcaEntity)
                    daD.FetchEntityCollection(MarcasD, Nothing)

                    For Each MarcaD As MarcaEntity In MarcasD
                        If MarcaD.IdExterno = 0 Then
                            MarcaD.IdExterno = MarcaD.Id
                        End If
                    Next

                    'MODELOS
                    Dim modelosD As New EntityCollection(Of ModeloEntity)
                    daD.FetchEntityCollection(modelosD, Nothing)

                    For Each modeloD As ModeloEntity In modelosD
                        If modeloD.IdExterno = 0 Then
                            modeloD.IdExterno = modeloD.Id
                        End If
                    Next


                    
                    'NivelS
                    Dim NivelsD As New EntityCollection(Of NivelEntity)
                    daD.FetchEntityCollection(NivelsD, Nothing)

                    For Each NivelD As NivelEntity In NivelsD
                        If string.IsNullOrEmpty(NivelD.IdExterno ) Then
                            NivelD.IdExterno = NivelD.Id
                        End If
                    Next


                    For Each artS As ArticuloEntity In artsS
                        Dim artD As New ArticuloEntity
                        Studio.Net.Helper.DAL.EntityHelper.CopySameFields(artS, artD, True)
                        artD.IdExterno = artS.Id

                        Dim rubroD As RubroEntity = (From r In rubrosD Where r.IdExterno = artS.RubroId Select r).SingleOrDefault()

                        If rubroD Is Nothing Then

                            Dim rubroS As RubroEntity = (From r In dbs.Rubro Where r.Id = artS.RubroId Select r).Single()
                            rubroD = New RubroEntity
                            Studio.Net.Helper.DAL.EntityHelper.CopySameFields(rubroS, rubroD, True)
                            'daD.SaveEntity(rubroD, True)

                            rubroD.IdExterno = rubroS.Id
                            rubrosD.Add(rubroD)

                        End If

                        artD.Rubro = rubroD



                        'MARCA

                        Dim marcaD As MarcaEntity = (From r In MarcasD Where r.IdExterno = artS.MarcaId Select r).SingleOrDefault()

                        If marcaD Is Nothing Then

                            Dim marcaS As MarcaEntity = (From r In dbs.Marca Where r.Id = artS.MarcaId Select r).Single()
                            marcaD = New MarcaEntity
                            Studio.Net.Helper.DAL.EntityHelper.CopySameFields(marcaS, marcaD, True)

                            marcaD.IdExterno = marcaS.Id
                            MarcasD.Add(marcaD)

                        End If

                        artD.Marca = marcaD
                        

                        'MODELO

                        Dim modeloD As ModeloEntity = (From r In modelosD Where r.IdExterno = artS.ModeloId Select r).SingleOrDefault()

                        If modeloD Is Nothing Then

                            Dim modeloS As ModeloEntity = (From r In dbs.Modelo Where r.Id = artS.ModeloId Select r).WithPath(ModeloController.CrearPretchPorMarcas()).Single()
                            modeloD = New ModeloEntity
                            Studio.Net.Helper.DAL.EntityHelper.CopySameFields(modeloS, modeloD, True)

                            modeloD.IdExterno = modeloS.Id
                            For Each marcModS As Marca_ModeloEntity In modeloS.Marcas
                                modeloD.Marcas.Add((From m In dbD.Marca_Modelo Where m.Marca.IdExterno = marcModS.MarcaId).Single())
                            Next
                            modelosD.Add(modeloD)

                        End If

                        artD.Modelo = modeloD



                        For Each taxS As Articulo_ImpuestoEntity In artS.Impuestos
                            Dim taxD As New Articulo_ImpuestoEntity
                            Studio.Net.Helper.DAL.EntityHelper.CopySameFields(taxS, taxD, True)
                            artD.Impuestos.Add(taxD)
                        Next
                        artsD.Add(artD)
                        daD.SaveEntity(artD, True, True)
                    Next

                    'daD.SaveEntityCollection(artsD, True, True)
                    daD.Commit()
                End Using

            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
End Class