<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.NavBarItem2 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem1 = New DevExpress.XtraNavBar.NavBarItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
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
        Me.RibbonControl.ExpandCollapseItem.Name = ""
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3})
        Me.RibbonControl.MaxItemId = 15
        Me.RibbonControl.Size = New System.Drawing.Size(1344, 178)
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 709)
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1344, 39)
        '
        'rgbiSkins
        '
        '
        'rgbiSkins
        '
        Me.rgbiSkins.Gallery.AllowHoverImages = True
        Me.rgbiSkins.Gallery.ColumnCount = 4
        Me.rgbiSkins.Gallery.FixedHoverImageSize = False
        '
        'panel
        '
        Me.panel.Location = New System.Drawing.Point(0, 178)
        Me.panel.Size = New System.Drawing.Size(1344, 531)
        '
        'NavBarControl
        '
        Me.NavBarControl.Location = New System.Drawing.Point(3, 3)
        Me.NavBarControl.OptionsNavPane.ExpandedWidth = 203
        Me.NavBarControl.Size = New System.Drawing.Size(203, 525)
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Location = New System.Drawing.Point(206, 3)
        Me.SplitterControl1.Margin = New System.Windows.Forms.Padding(7)
        Me.SplitterControl1.Size = New System.Drawing.Size(4, 525)
        '
        'xTab
        '
        Me.xTab.Location = New System.Drawing.Point(210, 3)
        Me.xTab.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.xTab.Size = New System.Drawing.Size(1131, 525)
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
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(1344, 748)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "MainForm"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel.ResumeLayout(False)
        CType(Me.NavBarControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xTab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NavBarItem2 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem1 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem

End Class
