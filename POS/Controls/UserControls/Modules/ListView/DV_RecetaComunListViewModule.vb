Imports Studio.Net.Controls.New
Imports Studio.Phone.POS.BLL
Imports Studio.Net.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.POS.DAL.EntityClasses

Public Class DV_RecetaComunListViewModule

    'Protected Overrides Sub OnListViewAssigned(listViewToUse As Net.Controls.New.UserControls.ListView)
    'AddHandler listViewToUse.Source.CurrentChanged, AddressOf OnBindingCurrentChanged
    'End Sub

    'Private Sub OnBindingCurrentChanged(sender As Object, e As EventArgs)
    '    If ListViewToUse.Source.Position >= 0 Then
    '        ListViewToUse.GridControl.MyMainView.FocusedRowHandle = ListViewToUse.Source.Position
    '    End If
    'End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Protected Overrides Sub OnRibbonItemClick(item As DevExpress.XtraBars.ItemClickEventArgs)

        Select Case item.Item.Name
            Case bbiSeleccionarFacturas.Name
                If bbiSeleccionarFacturas.Down Then
                    OnSeleccionarFacturarClicked()
                Else
                    OnDeseleccionarFacturarClicked()
                End If
            Case bbiFacturar.Name
                OnFacturarClicked()
            Case bbiRefresh.Name
                If ListViewToUse.ActiveMode = DV_RecetaComunListView.ViewMode.Facturacion Then
                    bbiSeleccionarFacturas.PerformClick()
                Else
                    MyBase.OnRibbonItemClick(item)
                End If
            Case Else
                MyBase.OnRibbonItemClick(item)
        End Select

    End Sub

    Public Shadows Property ListViewToUse As DV_RecetaComunListView
        Get
            Return DirectCast(MyBase.ListViewToUse, DV_RecetaComunListView)
        End Get
        Set(value As DV_RecetaComunListView)
            MyBase.ListViewToUse = value
        End Set
    End Property

    Private Sub OnSeleccionarFacturarClicked()
        ListViewToUse.ActiveMode = DV_RecetaComunListView.ViewMode.Facturacion
        bbiFacturar.Enabled = PtkOperacionBEntity.TienePermiso(PermisoOperacion.FacturarRecetas)
    End Sub

    Private Sub OnDeseleccionarFacturarClicked()
        ListViewToUse.ActiveMode = DV_RecetaComunListView.ViewMode.Normal
        bbiFacturar.Enabled = False

    End Sub

    Private Sub OnFacturarClicked()
        Try
            If ListViewToUse.MainView.SelectedRowsCount = 0 Then
                ShowMsgBox("No hay ninguna receta seleccionada.", MsgBoxStyle.Exclamation)
                Return
            End If

            'If showmsgbox(String.Format("¿Seguro que desea facturar las recetas seleccionadas ({0}).?", ListViewToUse.Selector.SelectedCount), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'Using msg As New MyMsgBoxFacturarRecetas() With {.AditionalHeight = 30}
            'If MyMsgBox.Show("¿Seguro que desea facturar las recetas seleccionadas?.", msg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Using c As New RecetasSeleccionadas(ListViewToUse.MainView.GetSelectedRows(Of DV_RecetaComunEntity))
                If c.ShowDialog() <> DialogResult.OK Then
                    Return
                End If
            End Using

            _parent.ShowWaitForm("Facturando recetas")
            Application.DoEvents()

            _parent.Enabled = False
            Dim imprimir As Boolean = True
            If ListViewToUse.FacturarSeleccion(imprimir) Then
                'LoadData(False)
            End If

            'End If
            'End Using

        Catch ex As EntitiesValidationException
            _parent.CloseWaitForm()
            ShowErrors(ex.InvalidEntities)
        Catch ex As ORMEntityValidationException
            ex.EntityValidated.SetEntityError(ex.Message)
            _parent.CloseWaitForm()
            ShowErrors(DirectCast(ex.EntityValidated, IEntity2))

        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            _parent.Enabled = True
            _parent.CloseWaitForm()
            LoadData(False)
        End Try
    End Sub


    Public Overrides Sub DisposeModule()
        If bbiSeleccionarFacturas.Down Then
            bbiSeleccionarFacturas.PerformClick() ' = False
        End If
        MyBase.DisposeModule()
    End Sub

    Private Sub ShowErrors(entitiesWithErrors As List(Of IEntity2))
        Using f As New ErrorDisplayForm(New EntitiesValidationException(entitiesWithErrors))
            f.ShowDialog(ParentForm)
        End Using

    End Sub

    Private Sub ShowErrors(entityWithErrors As IEntity2)
        Dim list As New List(Of IEntity2)
        list.Add(entityWithErrors)
        Using f As New ErrorDisplayForm(New EntitiesValidationException(list))
            f.ShowDialog(ParentForm)
        End Using

    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        RibbonControl.SelectedPage = rpInicio
        
    End Sub


End Class
