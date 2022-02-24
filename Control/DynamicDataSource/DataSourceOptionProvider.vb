Imports Studio.Net.Controls.New
Imports Studio.Phone.DAL.EntityClasses

Public Class DataSourceOptionProvider
    Inherits Studio.Phone.Controls.[New].DataSourceOptionProvider

    Public Overrides Function GetDataSources() As System.Collections.Generic.List(Of DynamicDataSourceOptionInfo)
        Dim toReturn As List(Of DynamicDataSourceOptionInfo) = MyBase.GetDataSources()
        toReturn.AddRange(New DynamicDataSourceOptionInfo() {New DynamicDataSourceOptionInfo("Recetas Rx", GetType(DV_RecetaComunEntity)), _
                                                                New DynamicDataSourceOptionInfo("Recetas Contacto", GetType(DV_RecetaContactoEntity)) _
                                                            })
        Return toReturn

    End Function

End Class
