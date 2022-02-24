Imports System.Runtime.CompilerServices
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.EntityClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Net.BLL

Public Module AAtributoPlantillaControllerExtensions

    <Extension()> _
    Public Function CrearPlantillasParaCristales(ByVal controller As AAtributoPlantillaController, ByVal da As IDataAccessAdapter) As EntityCollection(Of AAtributoPlantillaEntity)
        Dim toReturn As New EntityCollection(Of AAtributoPlantillaEntity)
        'toReturn.Add(CrearPlantillaEntity("Diámetros"))
        toReturn.Add(CrearPlantillaEntity("ESFÉRICO"))
        toReturn.Add(CrearPlantillaEntity("CILÍNDRICO"))
        toReturn.Add(CrearPlantillaEntity("ADICIÓN"))
        controller.SaveEntityCollection(da, toReturn)
        'da.SaveEntityCollection(toReturn, True, False)
        Return toReturn

    End Function

    Private Function CrearPlantillaEntity(ByVal descripcion As String) As AAtributoPlantillaEntity
        Dim plantilla As New AAtributoPlantillaEntity
        plantilla.Nombre = descripcion
        plantilla.Sistema = True
        plantilla.Tipo = CustomFieldType.Decimal
        Return plantilla
    End Function

End Module
