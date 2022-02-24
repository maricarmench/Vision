Imports Studio.Net.Controls.New
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports System.Reflection
Imports Studio.Phone.DAL.EntityClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports Studio.Net.BLL
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Net.BLL.Model
Imports Studio.Phone.DAL
Imports DevExpress.XtraNavBar
Imports Studio.Vision.Controls
Imports System.Xml.Serialization
Imports System.Text
Imports System.IO
Imports Studio.Net.BLL.GraphTreeHelper
Imports Studio.Net.Plugins
Imports Studio.Phone.Plugins

Public Class MainForm

    Public Sub New()

        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try

            Studio.Vision.BLL.Initializer.CrearValoresPorDefecto()
            'MainFormHelper.LoadNavigationStatus(NavBarControl)
            LoadMisReportes()

        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)

        End Try
    End Sub

    Private m_Plugins As List(Of IPhonePlugin)

    Protected Overrides Sub OnLoadPlugins()

        Dim loader As New Studio.Phone.Plugins.PluginLoader
        m_Plugins = loader.Start()

        For Each plugin As IPhonePlugin In m_Plugins

            Dim menuItems = plugin.CreateMenuTree()

            If menuItems IsNot Nothing Then
                LoadMenuTree(menuItems)
            End If

        Next

    End Sub



    Protected Overrides Function GetMenuTree() As Studio.Net.Controls.New.MainMenuTree

        Dim dMnu As New Studio.Net.Controls.[New].MenuTreeDiff
        Dim itemDif As New Studio.Net.Controls.[New].MenuItemDifference With {.ID = Guid.NewGuid}
        itemDif.PropertiesDiffs.Add(New PropertyDiffEntry("Visible", False))
        dMnu.Differences.Add(itemDif)

        Dim menuOrig As Studio.Net.Controls.[New].MainMenuTree = MainMenuTree.Create(Of MainMenuTree)(Assembly.GetAssembly(GetType(Studio.Phone.Controls.[New].DrakoListView)).GetManifestResourceStream("Studio.Phone.Controls.New.MainMenu.xml"))
        Dim menuDiff As Studio.Net.Controls.[New].MenuTreeDiff = MainMenuTree.Create(Of MenuTreeDiff)(Assembly.GetExecutingAssembly().GetManifestResourceStream("Studio.Vision.Exe.MainMenu_Diff.xml"))

        Studio.Net.Controls.[New].MenuTreeHelper.MergeMenuTree(menuOrig, menuDiff)

        'WORKAROUND para sobrescribir un item
        Dim listaItem As MenuItem = menuOrig.FindNode(New Guid("fc1bb610-c9e9-476c-8fda-a42a29c86147"))
        listaItem.Invoker.FactoryType = "Studio.Vision.Controls.DV_ListaPreVtaListViewFactory, Studio.Vision.Controls"

        Dim cajaItem As MenuItem = menuOrig.FindNode(New Guid("99a7fd02-7d25-416e-aa8a-a75a91dbf8af"))
        cajaItem.Invoker.FactoryType = "Studio.Vision.Controls.DV_CajaListViewFactory, Studio.Vision.Controls"

        Dim traspasoItem As MenuItem = menuOrig.FindNode(New Guid("5bb4f80f-cf92-44e2-a455-b4dff8333b2c"))
        traspasoItem.Invoker.FactoryType = "Studio.Vision.Controls.DV_TraspasoIngresoListViewModuleFactory, Studio.Vision.Controls"


        Dim ajusteItem As MenuItem = menuOrig.FindNode(New Guid("db26f77f-f4aa-448c-ad2c-a2a3d69aba7a"))
        ajusteItem.Invoker.FactoryType = "Studio.Vision.Controls.DV_AjusteListViewModuleFactory, Studio.Vision.Controls"

        Dim parametroItem As MenuItem = menuOrig.FindNode(New Guid("a58c9a3f-46e1-4177-aea6-edccef7dfdf6"))
        parametroItem.Invoker.FactoryType = "Studio.Vision.Controls.DV_ParametroSistemaFactory, Studio.Vision.Controls"

        Dim documentoEntradaItem As MenuItem = menuOrig.FindNode(New Guid("8f2bf0f1-02d5-47e8-a526-fc13dceb9acf"))
        documentoEntradaItem.Invoker.FactoryType = "Studio.Vision.Controls.DV_DocumentoEntradaListViewModuleFactory, Studio.Vision.Controls"

        Dim bonificacionDinamicaItem As MenuItem = menuOrig.FindNode(New Guid("025791ca-c398-4c27-9df9-e0761ea61856"))
        bonificacionDinamicaItem.Invoker.FactoryType = "Studio.Vision.Controls.DV_BonificacionDinamicaFactory, Studio.Vision.Controls"

        Return menuOrig

    End Function

    Private Sub LoadMisReportes()
        Try

            Dim menuTree As MainMenuTree = GetMenuTree()
            Const STR_OnTheFlyReport As String = "OnTheFlyReport"
            Dim reportGroup As MenuGroup = New MenuGroup With {.Caption = "Mis Reportes", .Name = STR_OnTheFlyReport}

            'TODO: Check the licensing for this component in order to activate it
            Dim ng As NavBarGroup = NavBarControl.Groups(STR_OnTheFlyReport)
            If ng Is Nothing Then
                ng = NavBarControl.Groups.Add()
                ng.Name = STR_OnTheFlyReport
            End If
            ng.Caption = reportGroup.Caption
            Dim tv As New MyMainMenuTreeDynamicReports(reportGroup)
            'Dim tv As New MyMainMenuTreeDynamicReports()
            tv.Dock = DockStyle.Fill
            ng.GroupStyle = NavBarGroupStyle.Default
            ng.GroupStyle = NavBarGroupStyle.ControlContainer
            ng.ControlContainer.Controls.Add(tv)
            ng.LargeImage = My.Resources.MisReportes24
            ng.SmallImage = My.Resources.MisReportes16

        Catch ex As Exception
            LogError.Publish(ex)
        End Try

    End Sub

    Protected Overrides Function OnLogin() As Boolean
        Try

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
            Using fLogin As New LoginForm(Me)
                Dim resultado As Boolean = fLogin.ValidarUsuario(New UsuarioController)
                If Not resultado Then
                    Application.Exit()
                    Return False
                End If
                LayoutManager.Load(Me)
            End Using

            Return True

        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            Application.Exit()
        End Try

    End Function

    Protected Overrides Sub OnLoad(e As System.EventArgs)
        MyBase.OnLoad(e)
        Test()
        'SimpleButton1.PerformClick()
    End Sub

    Protected Overrides Function GetSplashScreenType() As System.Type
        Return GetType(VisionSplashScreenForm)
    End Function

    Protected Overrides Function GetPermisos() As System.Collections.Generic.List(Of String)
        Dim unUsuarioEntity As Studio.Phone.DAL.EntityClasses.UsuarioEntity
        'Dim unGrpPerEntity As Studio.Phone.DAL.EntityClasses.Grupo_PermisoEntity

        Dim usuario As String = Studio.Net.Helper.UserManager.UserInfo.Login
        unUsuarioEntity = Studio.Phone.BLL.UsuarioController.BuscarPorLogin(usuario)
        Dim grpPerCol As Studio.Phone.DAL.HelperClasses.EntityCollection
        Dim usrGrpBentity As New Studio.Phone.BLL.Grupo_PermisoBentity

        grpPerCol = usrGrpBentity.GetData(Studio.Phone.BLL.Grupo_PermisoController.CrearFiltroPorGrupoId(unUsuarioEntity.GrupoId))
        Return grpPerCol.Select(Function(p) DirectCast(p, Grupo_PermisoEntity).PermisoIdentificador).ToList()

    End Function

    Private Sub Test()

        Dim fields As New Studio.Phone.DAL.HelperClasses.ResultsetFields(3)
        fields.DefineField(DV_RecetaComunFields.EjeOjoCercaDerecho, 0, "f1")
        fields.DefineField(ClienteFields.Descripcion.SetObjectAlias("c"), 1, "f2")
        fields.DefineField(ArticuloFields.Descripcion.SetObjectAlias("a"), 2, "f3")
        Dim filtro As New RelationPredicateBucket
        filtro.PredicateExpression.Add(DV_RecetaComunFields.FechaEmitida >= New Date(2012, 1, 1))

        Dim root As New DV_RecetaComunEntity

        Dim pElement As IPrefetchPathElement2 = DV_RecetaComunEntity.PrefetchPathCliente
        pElement.Relation.SetAliases(String.Empty, "c")
        'filtro.Relations.Add(pElement.Relation, DirectCast(IIf(pElement.TypeOfRelation = RelationType.ManyToOne, JoinHint.Left, JoinHint.Right), JoinHint))
        'filtro.Relations.Add(pElement.Relation)
        'pElement = DV_RecetaComunEntity.PrefetchPathArmazonLejos
        'pElement.Relation.SetAliases(String.Empty, "a")
        'filtro.Relations.Add(pElement.Relation)
        ' filtro.Relations.Add(pElement.Relation, DirectCast(IIf(pElement.TypeOfRelation = RelationType.ManyToOne, JoinHint.Left, JoinHint.Right), JoinHint))

        'Dim rel As IEntityRelation = DV_RecetaComunEntity.Relations.ArticuloEntityUsingArmazonIdLejos
        'rel.SetAliases(String.Empty, "a")
        'filtro.Relations.Add(rel)

        'rel = DV_RecetaComunEntity.Relations.ClienteEntityUsingClienteId
        'rel.SetAliases(String.Empty, "c")
        'filtro.Relations.Add(rel)

        Dim dt As New DataTable
        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
            'da.FetchTypedList(fields, dt, filtro, 0, Nothing, True, Nothing, 1, 100)
        End Using

    End Sub
End Class
