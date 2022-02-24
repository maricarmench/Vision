Imports Studio.Net.Controls.New.Forms
Imports DevExpress.XtraBars.Ribbon
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL
Imports DevExpress.XtraBars
Imports Studio.Net.Controls.New

Public Class DV_RecetaComunDetailViewModule

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal parent As MainFormBase, ByVal view As DV_RecetaLenteComunDetailView)

        MyBase.New(parent, view)

        InitializeComponent()

        InitializeRibbon()

    End Sub

    Private Sub InitializeRibbon()
        rpgEdit.Visible = False
        rpgSave.Visible = False

        RibbonControl.SelectedPage = rpInicio
        'Dim rpg As New RibbonPageGroup() With {.Text = "Tareas"}
        'Dim link As BarItemLink = rpg.ItemLinks.Add(bbiAgregarRecetaComunesBulk)

        'RibbonControl.SelectedPage.Groups.Insert(RibbonControl.SelectedPage.Groups.Count - 1, rpg)
    End Sub




End Class
