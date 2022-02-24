Imports DevExpress.Data.Linq
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Net.Controls.New
Imports DevExpress.XtraTab
Imports DevExpress.XtraPivotGrid
Imports Studio.Vision.BLL

Public Class CristalMatrixControl

#Region "CTor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal datasource As CristalesMatrixData, ByVal atributoValores As DataTable)
        Me.New()
        _datasource = datasource
        _atributoValores = atributoValores
    End Sub

#End Region

#Region "Propiedades Publicas"

    Public Property ArticuloIDName As String = "Id"
    Public Property ArticuloDescripcionName As String = "Descripcion"

#End Region

#Region "Variables de módulo"

    Private _atributoValores As DataTable
    Private _datasource As CristalesMatrixData
#End Region

#Region "Eventos de acción"


    Private Sub btnAddCristal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCristal.Click

        Try
            If cboArticuloId.EditValue Is Nothing Then
                MyMsgBox.Show("Debe seleccionar el artículo.", MsgBoxStyle.Exclamation)
            End If


        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub


    Private Sub lqifsArticulo_DismissQueryable(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles lqifsArticulo.DismissQueryable
        RaiseEvent ArticuloDismissQueryable(sender, e)
    End Sub

    Private Sub lqifsArticulo_GetQueryable(ByVal sender As System.Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles lqifsArticulo.GetQueryable
        RaiseEvent ArticuloGetQueryable(sender, e)
    End Sub

#End Region

#Region "Eventos Públicos"
    Public Event ArticuloGetQueryable(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

    Public Event ArticuloDismissQueryable(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)
#End Region

#Region "Procedimientos Privados"

    Private Sub LoadData()

        For Each item As CristalData In _datasource.Cristales
            Dim pg As XtraTabPage = tabControl.TabPages.Add(item.Descripcion)
            pg.Tag = item.ArticuloId

        Next

    End Sub

    Private Sub ConfigGrid(ByVal grdToConfig As PivotGridControl, ByVal template As CristalData)

        Dim field1 As PivotGridField = grdToConfig.Fields.Add()
        field1.FieldName = "PlantillaId1"
        field1.AreaIndex = 0
        field1.Area = PivotArea.ColumnArea
        field1.Caption = template.PlantillaDescripcion1
        Dim lookupAtributo As New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
        With lookupAtributo
            .DataSource = _atributoValores
            .ValueMember = "ID"
            .DisplayMember = "ValorDecimal"
            .PopulateViewColumns()
        End With
        field1.FieldEdit = lookupAtributo

        Dim field2 As PivotGridField = grdToConfig.Fields.Add()
        field2.FieldName = "PlantillaId2"
        field2.Caption = template.PlantillaDescripcion2
        field2.AreaIndex = 1
        field2.Area = PivotArea.ColumnArea
        field2.FieldEdit = lookupAtributo

        Dim fieldValor As PivotGridField = grdToConfig.Fields.Add()
        fieldValor.FieldName = "Valor"
        field2.Area = PivotArea.DataArea

        grdToConfig.OptionsBehavior.BestFitMode = PivotGridBestFitMode.FieldHeader
        grdToConfig.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        grdToConfig.OptionsCustomization.AllowCustomizationForm = False
        grdToConfig.OptionsCustomization.AllowDrag = False
        grdToConfig.OptionsCustomization.AllowEdit = True
        grdToConfig.OptionsCustomization.AllowExpand = False
        grdToConfig.OptionsCustomization.AllowHideFields = False
        grdToConfig.OptionsView.ShowColumnHeaders = False
        grdToConfig.OptionsView.ShowColumnGrandTotals = False
        'grdToConfig.OptionsView.ShowColumnTotals = False
        'grdToConfig.OptionsView.ShowRowGrandTotals = False


    End Sub


#End Region
End Class
