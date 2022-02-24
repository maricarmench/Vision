Imports System.Runtime.CompilerServices
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.EntityClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses

Public Module RubroControllerExtensions

    <Extension()> _
    Public Function CrearRubroParaCristal(ByVal controller As RubroController, ByVal da As IDataAccessAdapter) As RubroEntity
        Dim toAdd As New RubroEntity
        toAdd.Descripcion = "Cristales"
        toAdd.Sistema = True
        controller.SaveEntity(da, toAdd)
        'da.SaveEntity(toAdd, True)
        Return toAdd

    End Function

End Module
