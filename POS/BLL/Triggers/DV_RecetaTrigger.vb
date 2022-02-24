Imports Studio.Net.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Vision.POS.BLL.Business

Namespace Triggers

    Public Class DV_RecetaTrigger
        Inherits EntityTrigger(Of DV_RecetaEntity)

        Protected Overrides Sub SavingInternal(entity As Phone.POS.DAL.EntityClasses.DV_RecetaEntity)

            ''NO SE HACE NADA POR AHORA
            'If entity.IsNew Then
            '    If String.IsNullOrEmpty(entity.Numero) Then
            '        entity.Numero = DV_RecetaBEntity.GetNumero(AdapterToUse, entity)
            '    End If
            'End If
        End Sub

    End Class

End Namespace
