Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Studio.Net.Controls.New
Imports Studio.Net.Controls.New.Forms
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Vision.Plugins.Telko.ADM.Business

Public Class ParComEmbedableListViewModule
    Public Sub New(parentRelationName As String, parent As MainFormBase)
        MyBase.New(parentRelationName, parent)
    End Sub

    Protected Overrides Sub OnDownClicked()

        Dim detalle As DV_PlantillaReposicionDetalleEntity = ListViewToUse.CurrentEntity
        Dim view As GridView = ListViewToUse.GridControl.MainView
        If detalle IsNot Nothing Then
            'AQUI VAMOS A MOVER HACIA ARRIBA, ES DECIR INTERCAMBIAR EL ORDEN CON EL REGISTRO CONTIGUO CON MENOR VALOR EN EL CAMPO ORDEN. 
            'Si la tecla shift no está presionado sunimos un nivel, pero si lo está, lo subimos hasta la cima
            If My.Computer.Keyboard.ShiftKeyDown Then
                PlantillaRepDetalleBEntity.MoveBottom(detalle, view)
            Else
                PlantillaRepDetalleBEntity.MoveDown(detalle, view)
            End If

        End If
    End Sub
    Protected Overrides Sub OnUpClicked()

        Dim detalle As DV_PlantillaReposicionDetalleEntity = ListViewToUse.CurrentEntity
        Dim view As GridView = ListViewToUse.GridControl.MainView
        If detalle IsNot Nothing Then
            'AQUI VAMOS A MOVER HACIA ARRIBA, ES DECIR BAJAR EL NUMERO DE ORDEN (SI ES MAYOR A UNO).
            'Si la tecla shift no está presionado sunimos un nivel, pero si lo está, lo subimos hasta la cima
            If My.Computer.Keyboard.ShiftKeyDown Then
                PlantillaRepDetalleBEntity.MoveTop(detalle, view)
            Else
                PlantillaRepDetalleBEntity.MoveUp(detalle, view)
            End If

        End If
    End Sub

    Private Sub ConfigGrid()
        Dim view As GridView = ListViewToUse.GridControl.MainView
        For Each item As GridColumn In view.Columns
            item.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False
            item.OptionsColumn.AllowMove = False
        Next
        view.OptionsBehavior.Editable = True
        view.OptionsView.ShowGroupPanel = False
        view.OptionsFind.AllowFindPanel = True
        view.OptionsFind.AlwaysVisible = True
        view.OptionsCustomization.AllowFilter = False
        view.OptionsCustomization.AllowQuickHideColumns = False
        view.OptionsCustomization.AllowSort = False

        view.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
    End Sub
End Class
