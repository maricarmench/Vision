Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Vision.POS.BLL.Business
Imports System.Linq

Public Class BonificacionDinamicaController
    Inherits Studio.Phone.POS.BLL.BonificacionDinamicaController

    Protected Overrides Function CumpleCondicion(da As IDataAccessAdapter, documento As Tmp_DocumentoSalidaEntity, bonificacion As BonificacionDinamicaParametroEntity) As Boolean
        Dim toReturn As Boolean = MyBase.CumpleCondicion(da, documento, bonificacion)
        Dim parametro As VisionParametroTree = DirectCast(ParametroSistemaController.GetParametroTree(), VisionParametroTree)

        If toReturn Then
            Dim cumpleGraduacion As Boolean = True
            If bonificacion.FiltraPorGraduacion Then
                'Si tiene aglún filtro por graduación entonces cambiamos la bandera a falso 
                cumpleGraduacion = False
                documento.Detalles.ToList().ForEach(Sub(s) cumpleGraduacion = cumpleGraduacion OrElse CumpleGraduacionArticulo(da, s, bonificacion, parametro, cumpleGraduacion))
            End If

            toReturn = cumpleGraduacion
        End If
        Return toReturn
    End Function

    Private Function CumpleGraduacionArticulo(da As IDataAccessAdapter, detalle As Tmp_DocSalidaDetalleEntity, bonificacion As BonificacionDinamicaParametroEntity, parametro As VisionParametroTree, cumple As Boolean) As Boolean

        If detalle.Articulo Is Nothing Then
            detalle.Articulo = ArticuloController.BuscarPorId(da, detalle.ArticuloId)
        End If

        Dim articulo As ArticuloEntity = detalle.Articulo

        Dim cristal As DV_CristalEntity = TryCast(articulo, DV_CristalEntity)
        If cristal Is Nothing Then Return cumple
        Dim toReturn As Boolean = True

        If bonificacion.FiltraPorCilindrico Then
            Dim valor As Decimal = DV_CristalBEntity.GetValorPlantilla(da, articulo.Id, parametro.Optica.AAtributoPlantillaIDCristalesCilindrico)
            toReturn = (bonificacion.CilindricoDesde <= valor AndAlso bonificacion.CilindricoHasta >= valor)
        End If
        If toReturn AndAlso bonificacion.FiltraPorEsferico Then
            Dim valor As Decimal = DV_CristalBEntity.GetValorPlantilla(da, articulo.Id, parametro.Optica.AAtributoPlantillaIDCristalesEsferico)
            toReturn = (bonificacion.EsfericoDesde <= valor AndAlso bonificacion.EsfericoHasta >= valor)
        End If
        If toReturn = False Then
            _lineasCumplen.Remove(detalle)
        End If

        Return toReturn

    End Function

End Class
