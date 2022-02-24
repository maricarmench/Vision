<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_CristalMaterial_ServicioEmbeedableListViewModule
    Inherits Studio.Net.Controls.[New].UserControls.EmbeddableListViewModule

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.bbiAgregarServicios = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager
        '
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiAgregarServicios})
        Me.BarManager.MaxItemId = 18
        '
        'TopBar
        '
        Me.TopBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiAgregarServicios, True)})
        Me.TopBar.OptionsBar.AllowQuickCustomization = False
        Me.TopBar.OptionsBar.DisableClose = True
        Me.TopBar.OptionsBar.DisableCustomization = True
        Me.TopBar.OptionsBar.DrawDragBorder = False
        '
        'StatusBar
        '
        Me.StatusBar.OptionsBar.AllowQuickCustomization = False
        Me.StatusBar.OptionsBar.DrawDragBorder = False
        Me.StatusBar.OptionsBar.UseWholeRow = True
        '
        'PanelControl
        '
        Me.PanelControl.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl.Appearance.Options.UseBackColor = True
        '
        'bbiAgregarServicios
        '
        Me.bbiAgregarServicios.Caption = "Agregar servicios"
        Me.bbiAgregarServicios.Id = 17
        Me.bbiAgregarServicios.Name = "bbiAgregarServicios"
        '
        'DV_Cristal_Servicio_ImporteEmbeedableListViewModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_Cristal_Servicio_ImporteEmbeedableListViewModule"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmExportar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bbiAgregarServicios As DevExpress.XtraBars.BarButtonItem

End Class
