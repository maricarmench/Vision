Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Vision.POS.BLL.Business
Imports Studio.Phone.POS.BLL
Imports System.Runtime.CompilerServices

Public Module EntityExtensions
    <Extension()> _
    Public Function ServiciosLejos(receta As DV_RecetaComunEntity) As List(Of DocSalidaDetalleEntity)
        Return receta.Detalles.Where(Function(f) f.DatoExtra = DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_LEJOS AndAlso f.Articulo.ArticuloClaseId = ArticuloClase.ServicioCristal).ToList()
    End Function

    <Extension()> _
    Public Function ServiciosCerca(receta As DV_RecetaComunEntity) As List(Of DocSalidaDetalleEntity)
        Return receta.Detalles.Where(Function(f) f.DatoExtra = DV_RecetaComunBEntity.STR_FLAG_DISTANCIA_CERCA AndAlso f.Articulo.ArticuloClaseId = ArticuloClase.ServicioCristal).ToList()
    End Function

End Module
