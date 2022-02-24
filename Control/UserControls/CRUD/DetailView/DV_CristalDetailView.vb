Imports Studio.Net.Helper
Imports Studio.Vision.BLL
Imports Studio.Net.Controls.New
Imports DevExpress.XtraGrid
Imports DevExpress.XtraTab
Imports DevExpress.XtraGrid.Columns
Imports Studio.Vision.BLL.Business
Imports Studio.Phone.DAL.EntityClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.Controls.New
Imports Studio.Phone.BLL
Imports Studio.Net.Controls.New.Forms
Imports Studio.Net.Controls.New.UserControls

Public Class DV_CristalDetailView

    Private Const STR_DV_Cristal_PrecioGraduacionEntityUsingArticuloId As String = "DV_Cristal_PrecioGraduacionEntityUsingArticuloId"
    Private Const STR_ListaPreVtaLinEntityUsingArticuloId As String = "ListaPreVtaLinEntityUsingArticuloId"

#Region "CTor"

    Public Sub New(ByVal business As DV_CristalBEntity, ByVal binding As MyBindingSource)
        MyBase.New(business, binding)

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConfigGrdVariantes()
        cboMarcaId.DetailViewType = GetType(Studio.Phone.Controls.[New].MarcaDetailView)

    End Sub

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Eventos de acción"

    Private Sub chkGuiaDeVariante_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkGuiaDeVariante.EditValueChanged

        ListViewModuleContainer1.SetTabVisible(STR_DV_Cristal_PrecioGraduacionEntityUsingArticuloId, Not chkGuiaDeVariante.Checked)
        'If Not chkGuiaDeVariante.Checked Then
        '    ListViewModuleContainer1.SetTabVisible(STR_DV_Cristal_PrecioGraduacionEntityUsingArticuloId, True)
        'Else
        '    Dim varianteDeGracuacion As Boolean = DV_CristalPlantillaBEntity.EsDeGraduacion(CInt(cboCristalPlantillaID.EditValue))
        '    ListViewModuleContainer1.SetTabVisible(STR_DV_Cristal_PrecioGraduacionEntityUsingArticuloId, Not varianteDeGracuacion)
        'End If

    End Sub

    Private Sub grdVariantes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdVariantes.DoubleClick
        Try
            If grvVariantes.FocusedRowHandle >= 0 Then

                Dim binding As New MyBindingSource
                Dim col As New EntityCollection(Of ArticuloEntity)
                col.Add(ArticuloController.BuscarPorId(grvVariantes.GetFocusedRowCellValue(DV_CristalFieldIndex.Id.ToString())))
                binding.DataSource = col
                Dim moduleToShow As New ArticuloVarianteDetailViewModule(_parent, New ArticuloVarianteDetailView(New ArticuloBEntity, binding) With {.Caption = String.Format("Variantes del artículo {0}", txtDescripcion.Text)})
                'moduleToShow.SetCaller(New EmbeddableListViewModule(String.Empty, _parent))
                moduleToShow.OnShowingModule() 'DetailViewToUse.OnAddingToModule()
                moduleToShow.ShowInCategoryView = True
                _parent.ShowModule(moduleToShow)
                'Binding.MoveFirst()

            End If
        Catch ex As Exception
            _parent.CloseWaitForm()
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally

        End Try

    End Sub

    Private Sub chkGuiaDeVariante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGuiaDeVariante.CheckedChanged

        cboCristalPlantillaID.Enabled = chkGuiaDeVariante.Checked

        'ListViewModuleContainer1.SetTabVisible(STR_ListaPreVtaLinEntityUsingArticuloId, Not chkGuiaDeVariante.Checked)
        'ListViewModuleContainer1.SetTabVisible(STR_DV_Cristal_PrecioGraduacionEntityUsingArticuloId, RequierePrecioXGraduacion())

    End Sub

    Private Sub LinqInstantFeedbackSource1_GetQueryable(ByVal sender As System.Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles LinqInstantFeedbackSource1.GetQueryable

        Dim da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
        e.QueryableSource = DV_CristalBEntity.VariantesDeCristalBasicos(GetCurrentEntity(Of DV_CristalEntity).Id)
        e.Tag = da

    End Sub

    'Protected Overrides Sub OnCurrentEntityChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    MyBase.OnCurrentEntityChanged(sender, e)
    '    LoadVariantes()
    'End Sub

    Private Sub LinqInstantFeedbackSource1_DismissQueryable(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles LinqInstantFeedbackSource1.DismissQueryable
        DirectCast(e.Tag, IDataAccessAdapter).Dispose()
    End Sub

    Private Sub rgrClasificacion_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgrClasificacion.EditValueChanged
        If rgrClasificacion.EditValue = CristalClasificacion.Maquina Then
            chkControlaStock.EditValue = False
        End If
        chkControlaStock.Enabled = rgrClasificacion.EditValue <> CristalClasificacion.Maquina
    End Sub

    Private Sub chkControlaStock_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkControlaStock.EditValueChanged
        If chkControlaStock.EditValue = False Then
            chkGuiaDeVariante.EditValue = False

        End If
        chkGuiaDeVariante.Enabled = (chkControlaStock.EditValue = True)
        'cboCristalPlantillaID.Enabled = chkGuiaDeVariante.Checked

    End Sub
#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        LoadVariantes()
        ConfigDependencies()
        chkControlaStock_EditValueChanged(chkControlaStock, EventArgs.Empty)
        chkGuiaDeVariante_CheckedChanged(chkGuiaDeVariante, EventArgs.Empty)
        rgrClasificacion_EditValueChanged(rgrClasificacion, EventArgs.Empty)
        chkGuiaDeVariante_EditValueChanged(chkGuiaDeVariante, EventArgs.Empty)
    End Sub

#End Region

#Region "Procedimientos Privados"

    Private Function RequierePrecioXGraduacion() As Boolean
        Return Not chkGuiaDeVariante.Checked AndAlso DV_CristalPlantillaBEntity.EsDeGraduacion(CInt(cboCristalPlantillaID.EditValue))
    End Function

    Protected Friend Sub ShowFormVariantes()
        Try
            Dim cristal As DV_CristalEntity = GetCurrentEntity(Of DV_CristalEntity)()
            If cristal IsNot Nothing Then
                If cristal.CristalPlantillaID > 0 Then
                    Using c As New DV_CrearVariantesCristalesView(cristal) With {.Caption = String.Format("Crear variantes para el artículo {0}", txtDescripcion.Text)}
                        If c.ShowDialog(FindForm()) = DialogResult.OK Then
                            Entity2Controls()
                        End If
                    End Using
                Else

                End If
            End If
        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Protected Overrides Sub BindControls()
        MyBase.BindControls()
        chkGuiaDeVariante.Enabled = False
    End Sub

    Protected Overrides Sub Entity2Controls()
        MyBase.Entity2Controls()
        LoadVariantes()
    End Sub

    Private Sub LoadVariantes()
        Try
            CursorManager.WaitCursor()

            If CurrentEntity Is Nothing Then Return

            If CurrentEntity.IsNew Then
                grdVariantes.DataSource = Nothing
                grdVariantes.Enabled = False
            Else
                Dim cristal As DV_CristalEntity = GetCurrentEntity(Of DV_CristalEntity)()
                grdVariantes.Enabled = cristal.GuiaDeVariante AndAlso cristal.CristalPlantillaID > 0
                grdVariantes.DataSource = Nothing
                If grdVariantes.Enabled Then
                    grdVariantes.DataSource = LinqInstantFeedbackSource1
                    grvVariantes.PopulateColumns()
                    If grvVariantes.Columns(ArticuloFieldIndex.Id.ToString()) IsNot Nothing Then
                        grvVariantes.Columns(DV_CristalFieldIndex.Id.ToString()).MaxWidth = 75
                    End If
                End If
                'grdVariantes.RefreshDataSource()
            End If
        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            CursorManager.Default()
        End Try
    End Sub

    Private Sub ConfigGrdVariantes()

        With grvVariantes

            .OptionsBehavior.Editable = False
            .OptionsView.ShowGroupPanel = False
            .OptionsView.ColumnAutoWidth = True
            .OptionsDetail.EnableMasterViewMode = False
            .OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel

        End With
        grdVariantes.UseEmbeddedNavigator = True
    End Sub

    Private Sub ConfigDependencies()

        ListViewModuleContainer1.xTab.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        ListViewModuleContainer1.AddModule(New Articulo_CodigoEmbeddedListViewFactory(), "Articulo_CodigoEntityUsingArticuloId", "Código")
        ListViewModuleContainer1.AddModule(New Deposito_ArticuloEmbeddedListViewFactory(), "Deposito_ArticuloEntityUsingArticuloId", "Depósitos")
        ListViewModuleContainer1.AddModule(New Articulo_LocalEmbeddedListViewFactory(), "Articulo_LocalEntityUsingArticuloId", "Locales")
        ListViewModuleContainer1.AddModule(New Articulo_ImpuestoEmbeddedListViewFactory(), "Articulo_ImpuestoEntityUsingArticuloId", "Impuestos")
        ListViewModuleContainer1.AddModule(New Articulo_ImagenEmbeddedListViewFactory(), "Articulo_ImagenEntityUsingArticuloId", "Imágenes")
        ListViewModuleContainer1.AddModule(New Articulo_ProveedorEmbeddedListViewFactory(), "Articulo_ProveedorEntityUsingArticuloId", "Proveedores")
        ListViewModuleContainer1.AddModule(New DV_Cristal_PrecioGraduacionEmbeddedListViewFactory(), STR_DV_Cristal_PrecioGraduacionEntityUsingArticuloId, "Precios por graduación")

        chkGuiaDeVariante_EditValueChanged(chkGuiaDeVariante, EventArgs.Empty)

    End Sub

#End Region

    'Private Sub chkControlaStock_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlaStock.CheckedChanged

    '    chkExterno.Properties.ReadOnly = chkControlaStock.Checked
    '    If Not _Loading AndAlso chkControlaStock.Checked Then
    '        chkExterno.Checked = False
    '    End If

    'End Sub

End Class
