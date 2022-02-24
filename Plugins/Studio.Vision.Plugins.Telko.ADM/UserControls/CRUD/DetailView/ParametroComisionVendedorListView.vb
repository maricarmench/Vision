Imports System.Windows.Forms
Imports Studio.Net.Controls.New
Imports Studio.Phone.BLL
Imports DevExpress.XtraGrid.Views.Grid
Imports Studio.Phone.DAL
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Net.Helper
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Net.BLL
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls

Public Class ParametroComisionVendedorListView

    Public Sub New()

        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
      
    End Sub

    Public Sub New(ByVal bEntity As Studio.Phone.BLL.ParametroComisionVendedorBEntity)

        MyBase.New(bEntity)

        ' TODO: Complete member initialization 

        InitializeComponent()
        DirectCast(EntityCollection, Studio.Phone.DAL.HelperClasses.EntityCollection).RemovedEntitiesTracker = New EntityCollection(Of ParametroComisionVendedorEntity)

        lqsmsArticulo.QueryableSource = (New ArticuloBEntity).GetDataForComboAsQueryable()
    End Sub

    Protected Overrides Sub BindGridInternal()

        If GridControl.InvokeRequired Then
            Dim m As New MethodInvoker(AddressOf BindGridInternal)
            Invoke(m, Nothing)
        Else
            Try

                'bindingDone.Set()
                SyncLock GridControl
                    Dim f As New DevGridFormater(GridControl.MainView)
                    f.Format(BusinessEntity)
                    ConfigGrid()
                End SyncLock

            Catch ex As Exception
                Throw
            Finally
                'SyncLock Me
                _bindingDone = True
                'End SyncLock
                OnBindingCompleted(System.EventArgs.Empty)
            End Try
        End If
    End Sub

    Public Overloads Sub MoverArriba()

        Dim view As GridView = GridControl.MainView
        Dim position As Integer = view.FocusedRowHandle 'Me._jsgxDetalle.GetRow().Position
        If position >= 0 Then
            Dim orden As Integer = view.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.Orden.ToString())
            view.SetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.Orden.ToString(), view.GetRowCellValue(position - 1, ParametroComisionVendedorFieldIndex.Orden.ToString()))
            view.SetRowCellValue(position - 1, ParametroComisionVendedorFieldIndex.Orden.ToString(), orden)
            view.UpdateCurrentRow()
        End If
        MainView.RefreshData()

    End Sub

    Public Overloads Sub MoverAbajo()

        Dim view As GridView = GridControl.MainView
        Dim position As Integer = view.FocusedRowHandle 'Me._jsgxDetalle.GetRow().Position
        If position < view.DataRowCount - 1 Then
            Dim orden As Integer = view.GetRowCellValue(position, ParametroComisionVendedorFieldIndex.Orden.ToString())
            view.SetRowCellValue(position, ParametroComisionVendedorFieldIndex.Orden.ToString(), view.GetRowCellValue(position + 1, ParametroComisionVendedorFieldIndex.Orden.ToString()))
            view.SetRowCellValue(position + 1, ParametroComisionVendedorFieldIndex.Orden.ToString(), orden)
            view.UpdateCurrentRow()
        End If
        MainView.RefreshData()
    End Sub


    Private Function IsEmptyOrCero(ByVal value As Object) As Boolean
        Return IsDBNull(value) OrElse String.IsNullOrEmpty(value) OrElse value = 0
    End Function

    Private Function DatosValidos() As Boolean
        Dim view As GridView = GridControl.MainView

        With view

            If Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.ArticuloId.ToString())) Then
                If Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.CargoId.ToString())) Then
                    If Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.ClienteId.ToString())) Then
                        If Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.FuncionarioId.ToString())) Then
                            If Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.ListaPreVtaId.ToString())) Then
                                If Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.LocalId.ToString())) Then
                                    If Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.MonedaId.ToString())) Then
                                        If Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.RubroId.ToString())) Then
                                            If Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.NivId.ToString())) Then
                                                MyMsgBox.Show("Debe ingresar algún dato como parámetros.", MsgBoxStyle.Exclamation)
                                                Return False
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If Not Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.Importe.ToString())) And Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.MonedaId.ToString())) Then
                MyMsgBox.Show("Debe elegir la moneda del importe de la comisión.", MsgBoxStyle.Exclamation)
                Return False
            End If

            If Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.Importe.ToString())) AndAlso Me.IsEmptyOrCero(.GetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.Porcentaje.ToString())) Then
                MyMsgBox.Show("Debe ingresar el importe o el porcentaje de comisión.", MsgBoxStyle.Exclamation)
                Return False
            End If

        End With


        Return True

    End Function

    Private Sub CorregirDatosEntitySaved(ByVal entity As ParametroComisionVendedorEntity)

        With DirectCast(DirectCast(GridControl.MainView, GridView).GetFocusedRow(), ParametroComisionVendedorEntity)
            If .ArticuloId = 0I Then
                .SetNewFieldValue(ParametroComisionVendedorFieldIndex.ArticuloId, Nothing)
            End If
            If .CargoId = 0I Then
                .SetNewFieldValue(ParametroComisionVendedorFieldIndex.CargoId, Nothing)
            End If
            If .ClienteId = 0I Then
                .SetNewFieldValue(ParametroComisionVendedorFieldIndex.ClienteId, Nothing)
            End If
            If .FuncionarioId = 0I Then
                .SetNewFieldValue(ParametroComisionVendedorFieldIndex.FuncionarioId, Nothing)
            End If
            If .ListaPreVtaId = 0I Then
                .SetNewFieldValue(ParametroComisionVendedorFieldIndex.ListaPreVtaId, Nothing)
            End If
            If .LocalId = 0I Then
                .SetNewFieldValue(ParametroComisionVendedorFieldIndex.LocalId, Nothing)
            End If
            If .MonedaId = 0I Then
                .SetNewFieldValue(ParametroComisionVendedorFieldIndex.MonedaId, Nothing)
            End If
            If .RubroId = 0I Then
                .SetNewFieldValue(ParametroComisionVendedorFieldIndex.RubroId, Nothing)
            End If
        End With

    End Sub

    Public Sub gridview_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles AdvBandedGridView1.ValidateRow

        Dim view As GridView = DirectCast(sender, GridView)
        e.Valid = DatosValidos()
        If e.Valid Then
            If e.RowHandle = GridControl.NewItemRowHandle Then
                view.SetFocusedRowCellValue(ParametroComisionVendedorFieldIndex.Orden.ToString(), MaxOrden() + 1)

            End If
        End If

    End Sub

    Private Sub gridview_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles AdvBandedGridView1.InvalidValueException
        e.ExceptionMode = ExceptionMode.Ignore
    End Sub

    Private Sub gridview_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles AdvBandedGridView1.InvalidRowException
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Private Sub gridview_CellValueChanging(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles AdvBandedGridView1.ValidatingEditor

        If e.Value = Nothing Then
            e.Value = 0
        End If

    End Sub

    Private Function MaxOrden() As Integer
        Return EntityCollection.ToList(Of ParametroComisionVendedorEntity)().Max(Function(p) p.Orden)
    End Function

    Private _deletedEntities As New EntityCollection(Of ParametroComisionVendedorEntity)

    Public Overloads Function GuardarCambios() As Boolean

        If Not MainView.UpdateCurrentRow() Then
            Return False
        End If

        Try

            Me.Enabled = False
            CursorManager.WaitCursor()
            For Each item As ParametroComisionVendedorEntity In EntityCollection.DirtyEntities
                CorregirDatosEntitySaved(item)
            Next
            ParametroComisionVendedorController.GuardarCambios(EntityCollection)
            'Dim bentity As New ParametroComisionVendedorBEntity
            'bentity.SaveEntityCollection(EntityCollection)
            'Me._deletedEntities.Clear()
            'Me.ConfigButtons()
            LoadData()
            Return True

        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            CursorManager.Default()
            Enabled = True
        End Try

    End Function

    Public Overloads Sub PreDeleteActiveEntity()

        Dim view As GridView = GridControl.MainView
        'DirectCast(EntityCollection, Studio.Phone.DAL.HelperClasses.EntityCollection).RemovedEntitiesTracker = _deletedEntities
        'Dim entityToDelete As ParametroComisionVendedorEntity = DirectCast(view.GetFocusedRow(), ParametroComisionVendedorEntity)
        'If Not entityToDelete.IsNew Then
        '    Me._deletedEntities.Add(entityToDelete)
        'End If

        view.DeleteRow(view.FocusedRowHandle)
        ' EntityCollection.Remove(entityToDelete)
    End Sub

    Private Sub ConfigGrid()
        Dim view As GridView = GridControl.MainView
        For Each item As GridColumn In view.Columns
            item.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False
            item.OptionsColumn.AllowMove = False
            'item.OptionsColumn.AllowShowHide = False
            'item.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
            'item.OptionsFilter.AllowFilter = False
        Next
        view.OptionsBehavior.Editable = True
        view.OptionsView.ShowGroupPanel = False
        view.OptionsFind.AllowFindPanel = True
        view.OptionsFind.AlwaysVisible = True
        'view.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        view.OptionsCustomization.AllowFilter = False
        view.OptionsCustomization.AllowQuickHideColumns = False
        view.OptionsCustomization.AllowSort = False



        'view.OptionsView.fi= ShowFilterPanelMode.ShowAlways
        view.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
        colOrden.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        colOrden.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        colOrden.OptionsColumn.ShowInCustomizationForm = False
    End Sub

    Protected Overrides Sub LoadDataInternal(resetStructure As Boolean)
        MyBase.LoadDataInternal(resetStructure)

    End Sub


End Class
