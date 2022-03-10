Imports Studio.Net.Controls.New.Forms
Imports Studio.Phone.DAL.EntityClasses

Public Class ParComEmbedableListViewModule
    Public Sub New(parentRelationName As String, parent As MainFormBase)
        MyBase.New(parentRelationName, parent)
    End Sub
    Protected Overrides Sub OnDownClicked()

        Dim detalle As DV_PlantillaReposicionDetalleEntity = ListViewToUse.CurrentEntity
        If detalle IsNot Nothing Then
            'AQUI VAMOS A MOVER HACIA ARRIBA, ES DECIR INTERCAMBIAR EL ORDEN CON EL REGISTRO CONTIGUO CON MENOR VALOR EN EL CAMPO ORDEN. 
            'Si la tecla shift no está presionado sunimos un nivel, pero si lo está, lo subimos hasta la cima
            If My.Computer.Keyboard.ShiftKeyDown Then
                'PlantillaRepDetalleBEntity.MoveBottom(detalle)
            Else
                'PlantillaRepDetalleBEntity.MoveDown(detalle)
            End If            '

        End If

    End Sub
    Protected Overrides Sub OnUpClicked()

        Dim detalle As DV_PlantillaReposicionDetalleEntity = ListViewToUse.CurrentEntity
        If detalle IsNot Nothing Then
            'AQUI VAMOS A MOVER HACIA ARRIBA, ES DECIR BAJAR EL NUMERO DE ORDEN (SI ES MAYOR A UNO).
            'Si la tecla shift no está presionado sunimos un nivel, pero si lo está, lo subimos hasta la cima
            If My.Computer.Keyboard.ShiftKeyDown Then
                'PlantillaRepDetalleBEntity.MoveTop(detalle)
            Else
                'PlantillaRepDetalleBEntity.MoveUp(detalle)
            End If            '

        End If

    End Sub

End Class
