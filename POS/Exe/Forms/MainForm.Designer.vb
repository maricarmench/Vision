<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mainform
    Inherits Studio.Net.Controls.New.Forms.MainFormBase

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mainform))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.NavBarItem2 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem1 = New DevExpress.XtraNavBar.NavBarItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.bsiUsuario = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiCaja = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiUploading = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiWriting = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiDownloading = New DevExpress.XtraBars.BarStaticItem()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel.SuspendLayout()
        CType(Me.NavBarControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xTab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.bsiUsuario, Me.bsiCaja, Me.bsiUploading, Me.bsiWriting, Me.bsiDownloading})
        Me.RibbonControl.MaxItemId = 20
        Me.RibbonControl.Size = New System.Drawing.Size(1094, 146)
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.bsiCaja)
        Me.RibbonStatusBar.ItemLinks.Add(Me.bsiUsuario, True)
        Me.RibbonStatusBar.ItemLinks.Add(Me.bsiDownloading)
        Me.RibbonStatusBar.ItemLinks.Add(Me.bsiWriting)
        Me.RibbonStatusBar.ItemLinks.Add(Me.bsiUploading)
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 587)
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1094, 21)
        '
        'rgbiSkins
        '
        '
        '
        '
        Me.rgbiSkins.Gallery.AllowHoverImages = True
        Me.rgbiSkins.Gallery.ColumnCount = 4
        Me.rgbiSkins.Gallery.FixedHoverImageSize = False
        '
        'bbiExitApp
        '
        Me.bbiExitApp.ImageOptions.Image = CType(resources.GetObject("bbiExitApp.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiExitApp.ImageOptions.LargeImage = CType(resources.GetObject("bbiExitApp.ImageOptions.LargeImage"), System.Drawing.Image)
        '
        'panel
        '
        Me.panel.Size = New System.Drawing.Size(1094, 441)
        '
        'NavBarControl
        '
        Me.NavBarControl.OptionsNavPane.ExpandedWidth = 174
        Me.NavBarControl.Size = New System.Drawing.Size(174, 437)
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitterControl1.Size = New System.Drawing.Size(12, 437)
        '
        'xTab
        '
        Me.xTab.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.xTab.Size = New System.Drawing.Size(904, 437)
        '
        'NavBarItem2
        '
        Me.NavBarItem2.Name = "NavBarItem2"
        '
        'NavBarItem1
        '
        Me.NavBarItem1.Name = "NavBarItem1"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Id = 12
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Id = 13
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Id = 14
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'bsiUsuario
        '
        Me.bsiUsuario.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bsiUsuario.Caption = "Usuario:"
        Me.bsiUsuario.Id = 15
        Me.bsiUsuario.Name = "bsiUsuario"
        Me.bsiUsuario.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'bsiCaja
        '
        Me.bsiCaja.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bsiCaja.Caption = "Caja:"
        Me.bsiCaja.Id = 16
        Me.bsiCaja.Name = "bsiCaja"
        Me.bsiCaja.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'bsiUploading
        '
        Me.bsiUploading.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bsiUploading.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.bsiUploading.Id = 17
        Me.bsiUploading.Name = "bsiUploading"
        ToolTipItem1.Text = "Subiendo actualización"
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.bsiUploading.SuperTip = SuperToolTip1
        Me.bsiUploading.TextAlignment = System.Drawing.StringAlignment.Near
        Me.bsiUploading.Width = 25
        '
        'bsiWriting
        '
        Me.bsiWriting.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bsiWriting.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.bsiWriting.Id = 18
        Me.bsiWriting.Name = "bsiWriting"
        ToolTipItem2.Text = "Guardando actualización"
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.bsiWriting.SuperTip = SuperToolTip2
        Me.bsiWriting.TextAlignment = System.Drawing.StringAlignment.Near
        Me.bsiWriting.Width = 25
        '
        'bsiDownloading
        '
        Me.bsiDownloading.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bsiDownloading.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.bsiDownloading.Id = 19
        Me.bsiDownloading.Name = "bsiDownloading"
        ToolTipItem3.Text = "Descargando actualización"
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.bsiDownloading.SuperTip = SuperToolTip3
        Me.bsiDownloading.TextAlignment = System.Drawing.StringAlignment.Near
        Me.bsiDownloading.Width = 25
        '
        'Mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 608)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "Mainform"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel.ResumeLayout(False)
        CType(Me.NavBarControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xTab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NavBarItem2 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem1 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bsiUsuario As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiCaja As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiUploading As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiWriting As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiDownloading As DevExpress.XtraBars.BarStaticItem

End Class
