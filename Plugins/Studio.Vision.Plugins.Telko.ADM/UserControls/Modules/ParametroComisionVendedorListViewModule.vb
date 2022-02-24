Imports Studio.Phone.DAL
Imports DevExpress.XtraGrid.Views.Grid
Imports Studio.Net.Controls.New
Imports DevExpress.XtraGrid
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.Controls.New
Imports Studio.Phone.BLL

Public Class ParametroComisionVendedorListViewModule

    Protected Overrides Sub OnAddPageGroup(group As DevExpress.XtraBars.Ribbon.RibbonPageGroup, page As DevExpress.XtraBars.Ribbon.RibbonPage)

        'Solo mostrar las opciones de manejo de registros y buscar
        If group Is rpgRecordManager OrElse group Is rpgClose Then
            MyBase.OnAddPageGroup(group, page)
        End If
    End Sub

    Protected Overrides Sub OnAddItemLinkToPageGroup(group As DevExpress.XtraBars.Ribbon.RibbonPageGroup, link As DevExpress.XtraBars.BarItem, beginGroup As Boolean)
        If Not (link Is bbiAdd OrElse link Is bbiEdit) Then
            MyBase.OnAddItemLinkToPageGroup(group, link, beginGroup)
        End If
    End Sub

    Protected Overrides Sub OnLoad(e As System.EventArgs)
        MyBase.OnLoad(e)

        ListViewToUse = New ParametroComisionVendedorListView(New ParametroComisionVendedorBEntity)
        With DirectCast(ListViewToUse.GridControl.MainView, GridView)
            AddHandler .FocusedRowChanged, AddressOf OnFocusedRowChanged
            AddHandler .CellValueChanged, AddressOf OnCellValueChanged
        End With
        CheckButtons()
    End Sub

    Protected Overrides Sub LoadPageSizeCombo()

        riLkpPageSize.BindFromEnum(GetType(PageSizes), Function(v) v.Key = PageSizes.Unlimited)
        bbiPageSize.EditValue = PageSizes.Unlimited

    End Sub

    Protected Overrides Sub OnDeleteClicked()
        Try
            MyListView.PreDeleteActiveEntity()
        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Protected Overrides Sub OnRibbonItemClick(item As DevExpress.XtraBars.ItemClickEventArgs)
        If item.Item Is bbiSave Then
            MyListView.GuardarCambios()
        Else
            If item.Item Is bbiMoveDown Then
                MyListView.MoverAbajo()
            Else
                If item.Item Is bbiMoveUp Then
                    MyListView.MoverArriba()
                End If
            End If
        End If
        MyBase.OnRibbonItemClick(item)
    End Sub

    Private ReadOnly Property MyListView As ParametroComisionVendedorListView
        Get
            Return DirectCast(ListViewToUse, ParametroComisionVendedorListView)
        End Get
    End Property

    Private Sub CheckButtons()
        Dim dirtyContent As Boolean = AreDirtyContent()
        Dim view As GridView = ListViewToUse.GridControl.MainView
        bbiMoveDown.Enabled = view.FocusedRowHandle <> GridControl.NewItemRowHandle AndAlso
            view.FocusedRowHandle < view.DataRowCount - 1
        bbiMoveUp.Enabled = view.FocusedRowHandle <> GridControl.NewItemRowHandle AndAlso
            view.FocusedRowHandle > 0I
        bbiDelete.Enabled = view.FocusedRowHandle <> GridControl.NewItemRowHandle
        bbiSave.Enabled = dirtyContent

    End Sub

    Private Function AreDirtyContent() As Boolean
        Return ListViewToUse.EntityCollection.ContainsDirtyContents OrElse ListViewToUse.EntityCollection.RemovedEntitiesTracker.Count > 0
    End Function

    Private Sub OnFocusedRowChanged(sender As Object, e As Views.Base.FocusedRowChangedEventArgs)
        CheckButtons()
    End Sub

    Private Sub OnCellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs)
        CheckButtons()
    End Sub
    'No guardar layout
    Protected Overrides Sub OnLoadLayout()
        'MyBase.OnLoadLayout()

    End Sub
    Protected Overrides Sub OnSaveLayout()
        '
    End Sub

    Public Overrides Function CanLeaveModule() As Boolean

        If AreDirtyContent() Then
            If MyMsgBox.Show("Tiene datos sin guardar. ¿Desea salir y perder los cambios realizados?.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                Return False
            End If
        End If

        Return True

    End Function
    ''item As DevExpress.XtraBars.ItemClickEventArgs

    Private Sub bbiSave_ItemClick(sender As Object, item As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSave.ItemClick
        'If item.Item Is bbiSave Then
        '    MyListView.GuardarCambios()
        'Else
        '    If item.Item Is bbiMoveDown Then
        '        MyListView.MoverAbajo()
        '    Else
        '        If item.Item Is bbiMoveUp Then
        '            MyListView.MoverArriba()
        '        End If
        '    End If
        'End If
        'MyBase.OnRibbonItemClick(item)
    End Sub
End Class
