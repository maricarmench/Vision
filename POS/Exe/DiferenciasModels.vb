Imports Studio.Net.BLL.Model
Imports SD.LLBLGen.Pro.ORMSupportClasses

Public Class DiferenciasModels

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click

        Dim messages As New System.Text.StringBuilder()
        Dim iTypes As List(Of Type) = GetEntityTypes()
        For Each eType As Type In iTypes
            Dim entity As IEntity2 = Activator.CreateInstance(eType)
            Dim eData As EntityData = ModelManager.GetInstance().GetEntity(entity)
            If eData Is Nothing Then
                messages.AppendLine(String.Format("Entity {0} no encontrada en Models.", entity.LLBLGenProEntityName))
            Else
                VerifyFields(entity, eData, messages)
            End If
        Next

        MemoEdit1.Text = messages.ToString()

    End Sub


    Private Function GetEntityTypes() As List(Of Type)
        Dim toReturn As New List(Of Type)
        For Each tp As Type In GetType(Studio.Phone.POS.DAL.EntityClasses.ArticuloEntity).Assembly.GetTypes()
            If tp.GetInterface("IEntity2") IsNot Nothing AndAlso Not tp.IsAbstract Then
                toReturn.Add(tp)
            End If
        Next
        Return toReturn
    End Function

    Private Sub VerifyFields(ByVal entity As IEntity2, ByVal eData As EntityData, ByRef messages As System.Text.StringBuilder)
        'If entity.LLBLGenProEntityName = "DV_CristalEntity" Then
        '    Stop
        'End If
        For Each field As IEntityField2 In entity.Fields
            If field.ContainingObjectName = field.ActualContainingObjectName AndAlso Not eData.Fields.ContainsKey(field.Name) Then
                messages.AppendLine(String.Format("El campo {0} no se encuentra en la EntityData {1}.", field.Name, eData.Name))
            End If
        Next
        For Each eField As KeyValuePair(Of String, FieldData) In eData.Fields

            If entity.Fields(eField.Key) Is Nothing Then
                messages.AppendLine(String.Format("El campo {0} no se encuentra en la Entity {1}.", eField.Key, entity.LLBLGenProEntityName))
            End If
        Next

    End Sub

End Class