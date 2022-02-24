Imports DevExpress.Utils

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyWizChooseFields
    Inherits InteriorWizardPage

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
        Me.MyPropertySelector1 = New Studio.Net.Controls.[New].MyPropertySelector()
        Me.lvSelectedFields = New System.Windows.Forms.ListView()
        Me.columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.headerPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyPropertySelector1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'headerPanel
        '
        Me.headerPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.headerPanel.Size = New System.Drawing.Size(759, 52)
        '
        'headerPicture
        '
        Me.headerPicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.headerPicture.Location = New System.Drawing.Point(706, 2)
        '
        'headerSeparator
        '
        Me.headerSeparator.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.headerSeparator.Location = New System.Drawing.Point(0, 52)
        Me.headerSeparator.Size = New System.Drawing.Size(758, 3)
        '
        'MyPropertySelector1
        '
        Me.MyPropertySelector1.Location = New System.Drawing.Point(13, 61)
        Me.MyPropertySelector1.Name = "MyPropertySelector1"
        Me.MyPropertySelector1.Size = New System.Drawing.Size(332, 415)
        Me.MyPropertySelector1.TabIndex = 5
        '
        'lvSelectedFields
        '
        Me.lvSelectedFields.AllowDrop = True
        Me.lvSelectedFields.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader2})
        Me.lvSelectedFields.FullRowSelect = True
        Me.lvSelectedFields.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvSelectedFields.HideSelection = False
        Me.lvSelectedFields.Location = New System.Drawing.Point(412, 61)
        Me.lvSelectedFields.Name = "lvSelectedFields"
        Me.lvSelectedFields.Size = New System.Drawing.Size(343, 415)
        Me.lvSelectedFields.TabIndex = 12
        Me.lvSelectedFields.UseCompatibleStateImageBehavior = False
        Me.lvSelectedFields.View = System.Windows.Forms.View.Details
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Image = Global.DevExpressTest.My.Resources.Resources.insert_field_add_32
        Me.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAdd.Location = New System.Drawing.Point(351, 94)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(55, 43)
        Me.btnAdd.TabIndex = 13
        Me.btnAdd.ToolTip = "Agregar campo"
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.Image = Global.DevExpressTest.My.Resources.Resources.remove_field_32
        Me.btnRemove.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnRemove.Location = New System.Drawing.Point(351, 143)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(55, 43)
        Me.btnRemove.TabIndex = 14
        Me.btnRemove.ToolTip = "Quitar campo"
        '
        'MyWizChooseFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lvSelectedFields)
        Me.Controls.Add(Me.MyPropertySelector1)
        Me.Name = "MyWizChooseFields"
        Me.Size = New System.Drawing.Size(759, 485)
        Me.Controls.SetChildIndex(Me.MyPropertySelector1, 0)
        Me.Controls.SetChildIndex(Me.headerPanel, 0)
        Me.Controls.SetChildIndex(Me.headerSeparator, 0)
        Me.Controls.SetChildIndex(Me.titleLabel, 0)
        Me.Controls.SetChildIndex(Me.subtitleLabel, 0)
        Me.Controls.SetChildIndex(Me.headerPicture, 0)
        Me.Controls.SetChildIndex(Me.lvSelectedFields, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnRemove, 0)
        CType(Me.headerPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyPropertySelector1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyPropertySelector1 As Studio.Net.Controls.New.MyPropertySelector
    Private WithEvents lvSelectedFields As System.Windows.Forms.ListView
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRemove As DevExpress.XtraEditors.SimpleButton

End Class
