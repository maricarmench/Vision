'Imports Studio.Vision.BLL
Imports Studio.Net.Controls.New
'Imports Studio.Vision.BLL.Business
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Vision.Plugins.Telko.ADM.Business
Public Class DV_PlantillaRepDetailView
    Public Sub New(ByVal business As PlantillaReposicionBEntity, ByVal binding As MyBindingSource)
        MyBase.New(business, binding)

        InitializeComponent()
    End Sub

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub ConfigDependencies()

        'ListViewModuleContainer1.xTab.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        'DV_CristalMaterialEntity.Relations.DV_CristalMaterial_ServicioEntityUsingCristalMaterialId
        ListViewModuleContainer1.AddModule(New DV_PlantillaRep_PlantRepDetEmbeddedListViewFactory(), NameOf(DV_PlantillaReposicionEntity.Relations.DV_PlantillaReposicionDetalleEntityUsingPlantillaReposicionId), "PlantillaReposicionDetalle")

    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        ConfigDependencies()
    End Sub

End Class
