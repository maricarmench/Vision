Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Vision.Plugins.Telko.ADM.Business

Namespace Business
    Public Class TenantBEntityFactory
        Implements Studio.Net.BLL.IBEntityFactory
        Public Overloads Function Create() As Studio.Net.BLL.IBEntity Implements Studio.Net.BLL.IBEntityFactory.Create
            Return New TenantBEntity
        End Function
    End Class
    Public Class PlantillaBEntityFactory
        Implements Studio.Net.BLL.IBEntityFactory
        Public Overloads Function Create() As Studio.Net.BLL.IBEntity Implements Studio.Net.BLL.IBEntityFactory.Create
            Return New PlantillaReposicionBEntity
        End Function
    End Class

End Namespace
