Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL
Imports Studio.Phone.DAL.Linq
Imports Studio.Net.BLL

Namespace Business
    <Serializable()> Public Class DV_RecetaComunBEntity
        Inherits DV_RecetaBEntity

#Region "Constantes"
        Public Const STR_FLAG_DISTANCIA_LEJOS As String = "l"
        Public Const STR_FLAG_DISTANCIA_CERCA As String = "c"
#End Region

        Public Sub New()
            MyBase.New()
        End Sub
        Public Shared Function CrearParaMantenimiento() As DV_RecetaComunBEntity

            Dim toReturn As New DV_RecetaComunBEntity
            toReturn.Fields(DV_RecetaComunFieldIndex.EjeOjoCercaDerecho.ToString()).DisplayDescription = "Eje"
            toReturn.Fields(DV_RecetaComunFieldIndex.EjeOjoCercaIzquierdo.ToString()).DisplayDescription = "Eje"
            toReturn.Fields(DV_RecetaComunFieldIndex.EjeOjoLejosDerecho.ToString()).DisplayDescription = "Eje"
            toReturn.Fields(DV_RecetaComunFieldIndex.EjeOjoLejosIzquierdo.ToString()).DisplayDescription = "Eje"
            toReturn.Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaDerecho.ToString()).DisplayDescription = "Cilíndrico"
            toReturn.Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaIzquierdo.ToString()).DisplayDescription = "Cilíndrico"
            toReturn.Fields(DV_RecetaComunFieldIndex.CilindricoOjoLejosDerecho.ToString()).DisplayDescription = "Cilíndrico"
            toReturn.Fields(DV_RecetaComunFieldIndex.CilindricoOjoLejosIzquierdo.ToString()).DisplayDescription = "Cilíndrico"
            toReturn.Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaDerecho.ToString()).DisplayDescription = "Esférico"
            toReturn.Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaIzquierdo.ToString()).DisplayDescription = "Esférico"
            toReturn.Fields(DV_RecetaComunFieldIndex.EsfericoOjoLejosDerecho.ToString()).DisplayDescription = "Esférico"
            toReturn.Fields(DV_RecetaComunFieldIndex.EsfericoOjoLejosIzquierdo.ToString()).DisplayDescription = "Esférico"
            toReturn.Fields(DV_RecetaComunFieldIndex.AdicionOjoLejosDerecho.ToString()).DisplayDescription = "Adición"
            toReturn.Fields(DV_RecetaComunFieldIndex.AdicionOjoLejosIzquierdo.ToString()).DisplayDescription = "Adición"
            toReturn.Fields(DV_RecetaComunFieldIndex.DistanciaOjoCercaDerecho.ToString()).DisplayDescription = "Distancia"
            toReturn.Fields(DV_RecetaComunFieldIndex.DistanciaOjoCercaIzquierdo.ToString()).DisplayDescription = "Distancia"
            toReturn.Fields(DV_RecetaComunFieldIndex.DistanciaOjoLejosDerecho.ToString()).DisplayDescription = "Distancia"
            toReturn.Fields(DV_RecetaComunFieldIndex.DistanciaOjoLejosIzquierdo.ToString()).DisplayDescription = "Distancia"
            toReturn.Fields(DV_RecetaComunFieldIndex.AlturaOjoCercaDerecho.ToString()).DisplayDescription = "Altura"
            toReturn.Fields(DV_RecetaComunFieldIndex.AlturaOjoCercaIzquierdo.ToString()).DisplayDescription = "Altura"
            toReturn.Fields(DV_RecetaComunFieldIndex.AlturaOjoLejosDerecho.ToString()).DisplayDescription = "Altura"
            toReturn.Fields(DV_RecetaComunFieldIndex.AlturaOjoLejosIzquierdo.ToString()).DisplayDescription = "Altura"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaOjoCercaDerecho.ToString()).DisplayDescription = "Prisma"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaOjoCercaIzquierdo.ToString()).DisplayDescription = "Prisma"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaOjoLejosDerecho.ToString()).DisplayDescription = "Prisma"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaOjoLejosIzquierdo.ToString()).DisplayDescription = "Prisma"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoCercaDerecho.ToString()).DisplayDescription = "º"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoCercaIzquierdo.ToString()).DisplayDescription = "º"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoLejosDerecho.ToString()).DisplayDescription = "º"
            toReturn.Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoLejosIzquierdo.ToString()).DisplayDescription = "º"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoCercaDerecho.ToString()).DisplayDescription = "Base"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoCercaIzquierdo.ToString()).DisplayDescription = "Base"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoLejosDerecho.ToString()).DisplayDescription = "Base"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoLejosIzquierdo.ToString()).DisplayDescription = "Base"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdCercaDerecho.ToString()).DisplayDescription = "Material"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdCercaIzquierdo.ToString()).DisplayDescription = "Material"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdLejosDerecho.ToString()).DisplayDescription = "Material"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalMaterialIdLejosIzquierdo.ToString()).DisplayDescription = "Material"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalIdCercaDerecho.ToString()).DisplayDescription = "Producto"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalIdLejosDerecho.ToString()).DisplayDescription = "Producto"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalIdCercaIzquierdo.ToString()).DisplayDescription = "Producto"
            toReturn.Fields(DV_RecetaComunFieldIndex.CristalIdLejosIzquierdo.ToString()).DisplayDescription = "Producto"

            toReturn.Fields(DV_RecetaComunFieldIndex.ClienteId.ToString()).DisplayDescription = "SELECCIÓN POR NOMBRE:"
            toReturn.Fields(DV_RecetaComunFieldIndex.ClienteIdentificacion.ToString()).DisplayDescription = "IDENTIFICACIÓN (CI/RUT/ID):"

            toReturn.Fields(DV_RecetaComunFieldIndex.ArmazonIdCerca.ToString()).ForeignBEntityFactory = New DV_ArmazonBEntityFactory
            toReturn.Fields(DV_RecetaComunFieldIndex.ArmazonIdLejos.ToString()).ForeignBEntityFactory = New DV_ArmazonBEntityFactory

            toReturn.Fields(DV_RecetaComunFieldIndex.DocumentoTipoId.ToString()).Locked = True
            toReturn.Fields(DV_RecetaComunFieldIndex.NumeroDocumento.ToString()).Locked = True
            toReturn.Fields(DV_RecetaComunFieldIndex.DocumentoTipoId.ToString()).EditMode = BEFieldEditMode.ReadOnly
            toReturn.Fields(DV_RecetaComunFieldIndex.NumeroDocumento.ToString()).EditMode = BEFieldEditMode.ReadOnly


            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoCercaDerecho.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoCercaIzquierdo.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoLejosDerecho.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoLejosIzquierdo.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoCercaDerecho.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoCercaIzquierdo.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoLejosDerecho.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoLejosIzquierdo.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoCercaDerecho.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoCercaIzquierdo.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoLejosDerecho.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoLejosIzquierdo.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoCercaDerecho.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoCercaIzquierdo.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoLejosDerecho.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoLejosIzquierdo.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.AireTipoArmadoCerca.ToString()).DisplayDescription = "Aire"
            toReturn.Fields(DV_RecetaComunFieldIndex.AireTipoArmadoLejos.ToString()).DisplayDescription = "Aire"
            toReturn.Fields(DV_RecetaComunFieldIndex.EnteroTipoArmadoCerca.ToString()).DisplayDescription = "Entero"
            toReturn.Fields(DV_RecetaComunFieldIndex.EnteroTipoArmadoLejos.ToString()).DisplayDescription = "Entero"
            toReturn.Fields(DV_RecetaComunFieldIndex.RanuraTipoArmadoCerca.ToString()).DisplayDescription = "Ranurado"
            toReturn.Fields(DV_RecetaComunFieldIndex.RanuraTipoArmadoLejos.ToString()).DisplayDescription = "Ranurado"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoCercaIzquierdo.ToString()).DisplayDescription = "Base O.I."
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoLejosIzquierdo.ToString()).DisplayDescription = "Base O.I."
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoCercaDerecho.ToString()).DisplayDescription = "Base O.D."
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoLejosDerecho.ToString()).DisplayDescription = "Base O.D."

            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadArmazonCerca.ToString()).DisplayDescription = "Cantidad"
            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadArmazonLejos.ToString()).DisplayDescription = "Cantidad"
            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadOjoCercaDerecho.ToString()).DisplayDescription = "Cantidad"
            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadOjoCercaIzquierdo.ToString()).DisplayDescription = "Cantidad"
            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadOjoLejosDerecho.ToString()).DisplayDescription = "Cantidad"
            toReturn.Fields(DV_RecetaComunFieldIndex.CantidadOjoLejosIzquierdo.ToString()).DisplayDescription = "Cantidad"
            Return toReturn

        End Function

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.DAL.FactoryClasses.DV_RecetaComunEntityFactory
        End Function

        Protected Overrides Sub CreateFields()
            MyBase.CreateFields()
        End Sub

        'Public Shared Function CrearFiltroParaFlujo(ByVal estado As RecetaEstado, ByVal clienteId As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date) As IRelationPredicateBucket
        '    Dim filtro As New RelationPredicateBucket
        '    filtro.PredicateExpression.Add(DV_RecetaComunFields.RecetaEstadoId = estado)
        '    If clienteId > 0 Then
        '        filtro.PredicateExpression.Add(DV_RecetaComunFields.ClienteId = clienteId)
        '    End If
        '    filtro.PredicateExpression.Add(DV_RecetaComunFields.FechaEmitida >= fechaInicio And DV_RecetaComunFields.FechaEmitida <= fechaFin)
        '    Return filtro
        'End Function

        Public Shared Function GetByRId(RId As Integer) As DV_RecetaComunEntity

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
                Dim db As New LinqMetaData(da)
                Return (From r In db.DV_RecetaComun Where r.RId = RId Select r).Single()
            End Using

        End Function

        Public Shared Function CrearBusinessParaDatosTaller() As DV_RecetaComunBEntity
            Dim toReturn As New DV_RecetaComunBEntity
            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoCercaDerecho.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoCercaIzquierdo.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoLejosDerecho.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DiametroOjoLejosIzquierdo.ToString()).DisplayDescription = "Ø Diametro"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoCercaDerecho.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoCercaIzquierdo.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoLejosDerecho.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.DescentrajeOjoLejosIzquierdo.ToString()).DisplayDescription = "Descentraje"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoCercaDerecho.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoCercaIzquierdo.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoLejosDerecho.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorCentroOjoLejosIzquierdo.ToString()).DisplayDescription = "Centro"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoCercaDerecho.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoCercaIzquierdo.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoLejosDerecho.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.EspesorBordeOjoLejosIzquierdo.ToString()).DisplayDescription = "Borde"
            toReturn.Fields(DV_RecetaComunFieldIndex.AireTipoArmadoCerca.ToString()).DisplayDescription = "Aire"
            toReturn.Fields(DV_RecetaComunFieldIndex.AireTipoArmadoLejos.ToString()).DisplayDescription = "Aire"
            toReturn.Fields(DV_RecetaComunFieldIndex.EnteroTipoArmadoCerca.ToString()).DisplayDescription = "Entero"
            toReturn.Fields(DV_RecetaComunFieldIndex.EnteroTipoArmadoLejos.ToString()).DisplayDescription = "Entero"
            toReturn.Fields(DV_RecetaComunFieldIndex.RanuraTipoArmadoCerca.ToString()).DisplayDescription = "Ranurado"
            toReturn.Fields(DV_RecetaComunFieldIndex.RanuraTipoArmadoLejos.ToString()).DisplayDescription = "Ranurado"
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoCercaIzquierdo.ToString()).DisplayDescription = "Base O.I."
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoLejosIzquierdo.ToString()).DisplayDescription = "Base O.I."
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoCercaDerecho.ToString()).DisplayDescription = "Base O.D."
            toReturn.Fields(DV_RecetaComunFieldIndex.BaseOjoLejosDerecho.ToString()).DisplayDescription = "Base O.D."
            Return toReturn
        End Function


        Public Shared Sub SaveEdicionReceta(ByVal receta As DV_RecetaComunEntity, relation As WorkFlowStepRelationEntity)

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()

                Dim colHistory As New EntityCollection(Of WorkFlowStepHistoryEntity)
                colHistory.Add(New WorkFlowStepHistoryEntity With {.RIdEntidad = receta.RId, .WorkFlowStepRelationID = relation.ID})
                da.StartTransaction(IsolationLevel.ReadCommitted, "trn")
                da.SaveEntity(receta, True)
                GenerarTareaDeActualizacionParaPos(da, receta)
                da.SaveEntityCollection(colHistory, True, False)
                da.Commit()

            End Using

        End Sub


        Public Shared Sub GenerarTareaDeActualizacionParaPos(ByVal da As IDataAccessAdapter, ByVal receta As DV_RecetaComunEntity)

            Dim nombreTabla As String = receta.LLBLGenProEntityName.Substring(0, receta.LLBLGenProEntityName.Length - 6)
            TareaPorDistribuirController.GenerarTareaDeInsercionParaPos(da, _
                                            nombreTabla, receta.RId, _
                                            String.Empty, 0I, LocalController.BuscarLocalIdFromCaja(da, receta.CajaId))
        End Sub

        Public Shared Function CrearBusinessParaListView() As DV_RecetaComunBEntity
            Dim toReturn As DV_RecetaComunBEntity = CrearParaMantenimiento()
            Dim fieldsToShow As String() = New String() {DV_RecetaComunFieldIndex.Id.ToString(), _
                                                         DV_RecetaComunFieldIndex.DocumentoTipoId.ToString(), _
                                                         DV_RecetaComunFieldIndex.NumeroDocumento.ToString(), _
                                                         DV_RecetaComunFieldIndex.ClienteId.ToString(), _
                                                         DV_RecetaComunFieldIndex.FechaEmitida.ToString(), _
                                                         DV_RecetaComunFieldIndex.FechaIngresada.ToString(), _
                                                         DV_RecetaComunFieldIndex.MonedaId.ToString(), _
                                                         DV_RecetaComunFieldIndex.ImporteTotal.ToString(), _
                                                         DV_RecetaComunFieldIndex.FechaEntrega.ToString()}
            For Each item As IBEField In toReturn.Fields
                Dim name As String = item.Name
                item.Displayable = fieldsToShow.Any(Function(f) f = name)
            Next
            Return toReturn
        End Function

        Public Shared Sub FetchDetalles(receta As DV_RecetaComunEntity)

            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                receta.Detalles.Clear()
                'receta.DocSalida_PagoDocSalida.Clear()
                Dim prefetch As New PrefetchPath2(CInt(EntityType.DV_RecetaComunEntity))
                prefetch.Add(DV_RecetaComunEntity.PrefetchPathDetalles)
                da.FetchEntity(receta, prefetch)

            End Using

        End Sub


    End Class

End Namespace
