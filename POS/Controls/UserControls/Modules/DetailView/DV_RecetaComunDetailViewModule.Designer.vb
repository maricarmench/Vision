<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_RecetaComunDetailViewModule
    Inherits Studio.Net.Controls.[New].UserControls.DetailViewModule


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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DV_RecetaComunDetailViewModule))
        Me.bbiFacturar = New DevExpress.XtraBars.BarButtonItem()
        Me.popUpFactura = New DevExpress.XtraBars.PopupControlContainer(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnFacturaManual = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNumeroDocumento = New DevExpress.XtraEditors.TextEdit()
        Me.txtFechaEmitida = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.bbiImprimirOrden = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiImprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.popUpMenuImprimir = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.bbiImprimirFactura = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiIngresarPago = New DevExpress.XtraBars.BarButtonItem()
        Me.rpgTareas = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgTools = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.bbiCambiarCristales = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiDevolverReceta = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiConfirmarPresupuesto = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiDatosTaller = New DevExpress.XtraBars.BarButtonItem()
        Me.rpTareas = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl.SuspendLayout()
        CType(Me.popUpFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popUpFactura.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtNumeroDocumento.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaEmitida.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaEmitida.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popUpMenuImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bbiClose
        '
        Me.bbiClose.ImageOptions.Image = CType(resources.GetObject("bbiClose.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiClose.ImageOptions.LargeImage = CType(resources.GetObject("bbiClose.ImageOptions.LargeImage"), System.Drawing.Image)
        '
        'bbiSaveAndNew
        '
        Me.bbiSaveAndNew.ImageOptions.Image = CType(resources.GetObject("bbiSaveAndNew.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiSaveAndNew.ImageOptions.LargeImage = CType(resources.GetObject("bbiSaveAndNew.ImageOptions.LargeImage"), System.Drawing.Image)
        '
        'bbiSave
        '
        Me.bbiSave.ImageOptions.Image = CType(resources.GetObject("bbiSave.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiSave.ImageOptions.LargeImage = CType(resources.GetObject("bbiSave.ImageOptions.LargeImage"), System.Drawing.Image)
        '
        'bbiSaveAndClose
        '
        Me.bbiSaveAndClose.ImageOptions.Image = CType(resources.GetObject("bbiSaveAndClose.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiSaveAndClose.ImageOptions.LargeImage = CType(resources.GetObject("bbiSaveAndClose.ImageOptions.LargeImage"), System.Drawing.Image)
        '
        'bbiDelete
        '
        Me.bbiDelete.ImageOptions.Image = CType(resources.GetObject("bbiDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiDelete.ImageOptions.LargeImage = CType(resources.GetObject("bbiDelete.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbiUndo
        '
        Me.bbiUndo.ImageOptions.Image = CType(resources.GetObject("bbiUndo.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiUndo.ImageOptions.LargeImage = CType(resources.GetObject("bbiUndo.ImageOptions.LargeImage"), System.Drawing.Image)
        '
        'RibbonPageCategory1
        '
        Me.RibbonPageCategory1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpTareas})
        '
        'bbiBack
        '
        Me.bbiBack.ImageOptions.Image = CType(resources.GetObject("bbiBack.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiBack.ImageOptions.LargeImage = CType(resources.GetObject("bbiBack.ImageOptions.LargeImage"), System.Drawing.Image)
        '
        'bbiNext
        '
        Me.bbiNext.ImageOptions.Image = CType(resources.GetObject("bbiNext.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiNext.ImageOptions.LargeImage = CType(resources.GetObject("bbiNext.ImageOptions.LargeImage"), System.Drawing.Image)
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiFacturar, Me.bbiImprimir, Me.bbiIngresarPago, Me.bbiImprimirOrden, Me.bbiCambiarCristales, Me.bbiDevolverReceta, Me.bbiImprimirFactura, Me.bbiConfirmarPresupuesto, Me.bbiDatosTaller})
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonControl1.MaxItemId = 22
        Me.RibbonControl1.Size = New System.Drawing.Size(853, 139)
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 361)
        Me.RibbonStatusBar1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(853, 26)
        '
        'PanelControl
        '
        Me.PanelControl.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl.Appearance.Options.UseBackColor = True
        Me.PanelControl.Controls.Add(Me.popUpFactura)
        Me.PanelControl.Location = New System.Drawing.Point(0, 139)
        Me.PanelControl.Size = New System.Drawing.Size(853, 222)
        '
        'bbiFacturar
        '
        Me.bbiFacturar.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.bbiFacturar.Caption = "Facturar receta"
        Me.bbiFacturar.DropDownControl = Me.popUpFactura
        Me.bbiFacturar.Id = 9
        Me.bbiFacturar.ImageOptions.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Facturar_16x16
        Me.bbiFacturar.ImageOptions.LargeImage = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Facturar
        Me.bbiFacturar.Name = "bbiFacturar"
        '
        'popUpFactura
        '
        Me.popUpFactura.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.popUpFactura.CloseOnLostFocus = False
        Me.popUpFactura.Controls.Add(Me.LayoutControl1)
        Me.popUpFactura.Location = New System.Drawing.Point(458, 39)
        Me.popUpFactura.Margin = New System.Windows.Forms.Padding(2)
        Me.popUpFactura.Name = "popUpFactura"
        Me.popUpFactura.Ribbon = Me.RibbonControl1
        Me.popUpFactura.Size = New System.Drawing.Size(276, 85)
        Me.popUpFactura.TabIndex = 0
        Me.popUpFactura.Visible = False
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnFacturaManual)
        Me.LayoutControl1.Controls.Add(Me.txtNumeroDocumento)
        Me.LayoutControl1.Controls.Add(Me.txtFechaEmitida)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.UseDefaultDragAndDropRendering = False
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(276, 85)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnFacturaManual
        '
        Me.btnFacturaManual.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Facturar
        Me.btnFacturaManual.Location = New System.Drawing.Point(5, 45)
        Me.btnFacturaManual.Name = "btnFacturaManual"
        Me.btnFacturaManual.Size = New System.Drawing.Size(266, 35)
        Me.btnFacturaManual.StyleController = Me.LayoutControl1
        Me.btnFacturaManual.TabIndex = 6
        Me.btnFacturaManual.Text = "Generar factura manual"
        '
        'txtNumeroDocumento
        '
        Me.txtNumeroDocumento.Location = New System.Drawing.Point(150, 21)
        Me.txtNumeroDocumento.MenuManager = Me.RibbonControl1
        Me.txtNumeroDocumento.Name = "txtNumeroDocumento"
        Me.txtNumeroDocumento.Size = New System.Drawing.Size(121, 20)
        Me.txtNumeroDocumento.StyleController = Me.LayoutControl1
        Me.txtNumeroDocumento.TabIndex = 5
        '
        'txtFechaEmitida
        '
        Me.txtFechaEmitida.EditValue = Nothing
        Me.txtFechaEmitida.Location = New System.Drawing.Point(5, 21)
        Me.txtFechaEmitida.MenuManager = Me.RibbonControl1
        Me.txtFechaEmitida.Name = "txtFechaEmitida"
        Me.txtFechaEmitida.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaEmitida.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFechaEmitida.Size = New System.Drawing.Size(141, 20)
        Me.txtFechaEmitida.StyleController = Me.LayoutControl1
        Me.txtFechaEmitida.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(276, 85)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtFechaEmitida
        Me.LayoutControlItem1.CustomizationFormText = "Fecha de emisión"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(145, 40)
        Me.LayoutControlItem1.Text = "Fecha de emisión"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtNumeroDocumento
        Me.LayoutControlItem2.CustomizationFormText = "Número de documento"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(145, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(125, 40)
        Me.LayoutControlItem2.Text = "Número de documento"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnFacturaManual
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(83, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(270, 39)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'bbiImprimirOrden
        '
        Me.bbiImprimirOrden.Caption = "Órden de trabajo"
        Me.bbiImprimirOrden.Id = 12
        Me.bbiImprimirOrden.ImageOptions.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.BO_Task
        Me.bbiImprimirOrden.ImageOptions.LargeImage = Global.Studio.Vision.POS.Controls.My.Resources.Resources.BO_Task_32x32
        Me.bbiImprimirOrden.Name = "bbiImprimirOrden"
        '
        'bbiImprimir
        '
        Me.bbiImprimir.ActAsDropDown = True
        Me.bbiImprimir.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.bbiImprimir.Caption = "Reimprimir"
        Me.bbiImprimir.DropDownControl = Me.popUpMenuImprimir
        Me.bbiImprimir.Id = 10
        Me.bbiImprimir.ImageOptions.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Print
        Me.bbiImprimir.ImageOptions.LargeImage = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Print
        Me.bbiImprimir.Name = "bbiImprimir"
        '
        'popUpMenuImprimir
        '
        Me.popUpMenuImprimir.ItemLinks.Add(Me.bbiImprimirFactura)
        Me.popUpMenuImprimir.ItemLinks.Add(Me.bbiImprimirOrden)
        Me.popUpMenuImprimir.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesText
        Me.popUpMenuImprimir.Name = "popUpMenuImprimir"
        Me.popUpMenuImprimir.Ribbon = Me.RibbonControl1
        '
        'bbiImprimirFactura
        '
        Me.bbiImprimirFactura.Caption = "Factura"
        Me.bbiImprimirFactura.Id = 18
        Me.bbiImprimirFactura.ImageOptions.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Facturar_16x16
        Me.bbiImprimirFactura.ImageOptions.LargeImage = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Facturar
        Me.bbiImprimirFactura.Name = "bbiImprimirFactura"
        '
        'bbiIngresarPago
        '
        Me.bbiIngresarPago.Caption = "Ingresar pago"
        Me.bbiIngresarPago.Id = 11
        Me.bbiIngresarPago.ImageOptions.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.BO_Sale
        Me.bbiIngresarPago.ImageOptions.LargeImage = Global.Studio.Vision.POS.Controls.My.Resources.Resources.BO_Sale_32x32
        Me.bbiIngresarPago.Name = "bbiIngresarPago"
        '
        'rpgTareas
        '
        Me.rpgTareas.ItemLinks.Add(Me.bbiFacturar)
        Me.rpgTareas.ItemLinks.Add(Me.bbiImprimir)
        Me.rpgTareas.Name = "rpgTareas"
        Me.rpgTareas.Text = "Facturación"
        '
        'rpgTools
        '
        Me.rpgTools.ItemLinks.Add(Me.bbiCambiarCristales)
        Me.rpgTools.ItemLinks.Add(Me.bbiDevolverReceta, True)
        Me.rpgTools.ItemLinks.Add(Me.bbiConfirmarPresupuesto)
        Me.rpgTools.ItemLinks.Add(Me.bbiDatosTaller, True)
        Me.rpgTools.Name = "rpgTools"
        Me.rpgTools.Text = "Herramientas"
        '
        'bbiCambiarCristales
        '
        Me.bbiCambiarCristales.Caption = "Cambiar cristales"
        Me.bbiCambiarCristales.Id = 16
        Me.bbiCambiarCristales.ImageOptions.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Switch_16x16
        Me.bbiCambiarCristales.ImageOptions.LargeImage = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Switch_32x32
        Me.bbiCambiarCristales.Name = "bbiCambiarCristales"
        '
        'bbiDevolverReceta
        '
        Me.bbiDevolverReceta.Caption = "Devolver receta"
        Me.bbiDevolverReceta.Id = 17
        Me.bbiDevolverReceta.ImageOptions.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Devolver_16x16
        Me.bbiDevolverReceta.ImageOptions.LargeImage = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Devolver_32x32
        Me.bbiDevolverReceta.Name = "bbiDevolverReceta"
        '
        'bbiConfirmarPresupuesto
        '
        Me.bbiConfirmarPresupuesto.Caption = "Confirmar presupuesto"
        Me.bbiConfirmarPresupuesto.Id = 20
        Me.bbiConfirmarPresupuesto.ImageOptions.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_Grant
        Me.bbiConfirmarPresupuesto.ImageOptions.LargeImage = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Action_Grant_32x32
        Me.bbiConfirmarPresupuesto.Name = "bbiConfirmarPresupuesto"
        '
        'bbiDatosTaller
        '
        Me.bbiDatosTaller.Caption = "Datos de taller"
        Me.bbiDatosTaller.Id = 21
        Me.bbiDatosTaller.ImageOptions.Image = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Llave_Inglesa_16x16
        Me.bbiDatosTaller.ImageOptions.LargeImage = Global.Studio.Vision.POS.Controls.My.Resources.Resources.Llave_Inglesa_32x32
        Me.bbiDatosTaller.Name = "bbiDatosTaller"
        '
        'rpTareas
        '
        Me.rpTareas.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgTareas, Me.rpgTools})
        Me.rpTareas.Name = "rpTareas"
        Me.rpTareas.Text = "Tareas"
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'DV_RecetaComunDetailViewModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_RecetaComunDetailViewModule"
        Me.Size = New System.Drawing.Size(853, 387)
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl.ResumeLayout(False)
        CType(Me.popUpFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popUpFactura.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtNumeroDocumento.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaEmitida.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaEmitida.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popUpMenuImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bbiFacturar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiImprimir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiIngresarPago As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiImprimirOrden As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgTareas As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiCambiarCristales As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgTools As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiDevolverReceta As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpTareas As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents popUpFactura As DevExpress.XtraBars.PopupControlContainer
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnFacturaManual As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNumeroDocumento As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFechaEmitida As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents bbiImprimirFactura As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents popUpMenuImprimir As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiConfirmarPresupuesto As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiDatosTaller As DevExpress.XtraBars.BarButtonItem
 

End Class
