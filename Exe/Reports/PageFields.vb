Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.Utils.Controls
Imports DevExpress.Data.Browsing.Design
Imports DevExpress.XtraReports.Native
Imports DevExpress.XtraReports.UserDesigner
Imports DevExpress.XtraReports.Design


<ToolboxItem(False)> _
Public Class WizPageChooseFields
    Inherits DevExpress.Utils.InteriorWizardPage
    Private label1 As DevExpress.XtraEditors.LabelControl
    Private btnAddAll As DevExpress.XtraEditors.SimpleButton
    Private btnRemoveAll As DevExpress.XtraEditors.SimpleButton
    Private btnRemove As DevExpress.XtraEditors.SimpleButton
    Private btnAdd As DevExpress.XtraEditors.SimpleButton
    Private lvSelectedFields As System.Windows.Forms.ListView
    Private columnHeader2 As System.Windows.Forms.ColumnHeader
    Private columnHeader1 As System.Windows.Forms.ColumnHeader
    Private lvAvailableFields As System.Windows.Forms.ListView
    Private imageList As System.Windows.Forms.ImageList
    Private components As System.ComponentModel.IContainer = Nothing
    Private label2 As LabelControl
    Private wizardBase As XtraReportStandardWizardBase
    Private labelControl1 As LabelControl
    Private fillFieldsListOnActivate As Boolean = True
    Public Sub New(runner As XRWizardRunnerBase)
        Me.wizardBase = DirectCast(runner.Wizard, XtraReportStandardWizardBase)
        InitializeComponent()
        'btnRemove.Image = ResourceImageHelper.CreateBitmapFromResources("Images.MoveLeft.gif", GetType(LocalResFinder))
        'btnRemoveAll.Image = ResourceImageHelper.CreateBitmapFromResources("Images.MoveAllLeft.gif", GetType(LocalResFinder))
        'btnAdd.Image = ResourceImageHelper.CreateBitmapFromResources("Images.MoveRight.gif", GetType(LocalResFinder))
        'btnAddAll.Image = ResourceImageHelper.CreateBitmapFromResources("Images.MoveAllRight.gif", GetType(LocalResFinder))
        'DataSourceTreeView.FillDataSourceImageList(imageList)
        'headerPicture.Image = ResourceImageHelper.CreateBitmapFromResources("Images.WizTopFields.gif", GetType(LocalResFinder))
    End Sub
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Designer generated code"
    Private Sub InitializeComponent()
        Me.label1 = New DevExpress.XtraEditors.LabelControl()
        Me.lvSelectedFields = New System.Windows.Forms.ListView()
        Me.columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imageList = New System.Windows.Forms.ImageList()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRemoveAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAvailableFields = New System.Windows.Forms.ListView()
        Me.label2 = New DevExpress.XtraEditors.LabelControl()
        Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.headerPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(0, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(0, 16)
        Me.label1.TabIndex = 13
        '
        'lvSelectedFields
        '
        Me.lvSelectedFields.AllowDrop = True
        Me.lvSelectedFields.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader2})
        Me.lvSelectedFields.FullRowSelect = True
        Me.lvSelectedFields.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvSelectedFields.HideSelection = False
        Me.lvSelectedFields.Location = New System.Drawing.Point(3, 66)
        Me.lvSelectedFields.Name = "lvSelectedFields"
        Me.lvSelectedFields.Size = New System.Drawing.Size(246, 219)
        Me.lvSelectedFields.SmallImageList = Me.imageList
        Me.lvSelectedFields.TabIndex = 11
        Me.lvSelectedFields.UseCompatibleStateImageBehavior = False
        Me.lvSelectedFields.View = System.Windows.Forms.View.Details
        '
        'imageList
        '
        Me.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageList.TransparentColor = System.Drawing.Color.Lime
        '
        'btnAdd
        '
        Me.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAdd.Location = New System.Drawing.Point(0, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 10
        '
        'btnAddAll
        '
        Me.btnAddAll.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAddAll.Location = New System.Drawing.Point(0, 0)
        Me.btnAddAll.Name = "btnAddAll"
        Me.btnAddAll.Size = New System.Drawing.Size(75, 23)
        Me.btnAddAll.TabIndex = 9
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnRemoveAll.Location = New System.Drawing.Point(0, 0)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveAll.TabIndex = 7
        '
        'btnRemove
        '
        Me.btnRemove.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnRemove.Location = New System.Drawing.Point(0, 0)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 8
        '
        'lvAvailableFields
        '
        Me.lvAvailableFields.AllowDrop = True
        Me.lvAvailableFields.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1})
        Me.lvAvailableFields.FullRowSelect = True
        Me.lvAvailableFields.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvAvailableFields.HideSelection = False
        Me.lvAvailableFields.Location = New System.Drawing.Point(0, 0)
        Me.lvAvailableFields.Name = "lvAvailableFields"
        Me.lvAvailableFields.Size = New System.Drawing.Size(121, 97)
        Me.lvAvailableFields.SmallImageList = Me.imageList
        Me.lvAvailableFields.TabIndex = 12
        Me.lvAvailableFields.UseCompatibleStateImageBehavior = False
        Me.lvAvailableFields.View = System.Windows.Forms.View.Details
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(0, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(0, 16)
        Me.label2.TabIndex = 6
        '
        'labelControl1
        '
        Me.labelControl1.Location = New System.Drawing.Point(0, 0)
        Me.labelControl1.Name = "labelControl1"
        Me.labelControl1.Size = New System.Drawing.Size(0, 16)
        Me.labelControl1.TabIndex = 5
        '
        'WizPageChooseFields
        '
        Me.Controls.Add(Me.labelControl1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.btnRemoveAll)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAddAll)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lvSelectedFields)
        Me.Controls.Add(Me.lvAvailableFields)
        Me.Controls.Add(Me.label1)
        Me.Name = "WizPageChooseFields"
        Me.Controls.SetChildIndex(Me.label1, 0)
        Me.Controls.SetChildIndex(Me.lvAvailableFields, 0)
        Me.Controls.SetChildIndex(Me.headerPanel, 0)
        Me.Controls.SetChildIndex(Me.headerSeparator, 0)
        Me.Controls.SetChildIndex(Me.titleLabel, 0)
        Me.Controls.SetChildIndex(Me.subtitleLabel, 0)
        Me.Controls.SetChildIndex(Me.headerPicture, 0)
        Me.Controls.SetChildIndex(Me.lvSelectedFields, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnAddAll, 0)
        Me.Controls.SetChildIndex(Me.btnRemove, 0)
        Me.Controls.SetChildIndex(Me.btnRemoveAll, 0)
        Me.Controls.SetChildIndex(Me.label2, 0)
        Me.Controls.SetChildIndex(Me.labelControl1, 0)
        CType(Me.headerPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Shared Sub UpdateListViewColumnWidth(lv As ListView)
        lv.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub
    Private Sub MoveItems(from As ListView, [to] As ListView, items As ArrayList)
        If items.Count <= 0 Then
            Return
        End If
        Dim index As Integer = Integer.MaxValue
        For Each item As ListViewItem In items
            If item.Index < index Then
                index = item.Index
            End If
            from.Items.Remove(item)
            item.Selected = False
            [to].Items.Add(item)
        Next
        If index + 1 > from.Items.Count Then
            index = from.Items.Count - 1
        End If
        If index >= 0 Then
            from.Items(index).Selected = True
        End If
        UpdateListViewColumnWidth(from)
        UpdateListViewColumnWidth([to])
        UpdateButtons()
        from.Focus()
    End Sub
    Private Sub MoveSelectedItems(from As ListView, [to] As ListView)
        Dim items As New ArrayList()
        items.AddRange(from.SelectedItems)
        MoveItems(from, [to], items)
    End Sub
    Private Sub MoveAll(from As ListView, [to] As ListView)
        Dim items As New ArrayList()
        items.AddRange(from.Items)
        MoveItems(from, [to], items)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        MoveSelectedItems(lvAvailableFields, lvSelectedFields)
    End Sub
    Private Sub btnAddAll_Click(sender As Object, e As System.EventArgs) Handles btnAddAll.Click
        MoveAll(lvAvailableFields, lvSelectedFields)
    End Sub
    Private Sub btnRemove_Click(sender As Object, e As System.EventArgs) Handles btnRemove.Click
        MoveSelectedItems(lvSelectedFields, lvAvailableFields)
    End Sub
    Private Sub btnRemoveAll_Click(sender As Object, e As System.EventArgs) Handles btnRemoveAll.Click
        MoveAll(lvSelectedFields, lvAvailableFields)
    End Sub
    Private Sub lvAvailableFields_DoubleClick(sender As Object, e As System.EventArgs) Handles lvAvailableFields.DoubleClick
        MoveSelectedItems(lvAvailableFields, lvSelectedFields)
    End Sub
    Private Sub lvSelectedFields_DoubleClick(sender As Object, e As System.EventArgs) Handles lvSelectedFields.DoubleClick
        MoveSelectedItems(lvSelectedFields, lvAvailableFields)
    End Sub
    Private Sub lvAvailableFields_Resize(sender As Object, e As System.EventArgs) Handles lvAvailableFields.Resize
        UpdateListViewColumnWidth(lvAvailableFields)
    End Sub
    Private Sub lvSelectedFields_Resize(sender As Object, e As System.EventArgs) Handles lvSelectedFields.Resize
        UpdateListViewColumnWidth(lvSelectedFields)
    End Sub
    Private Sub HandleItemDrag(from As ListView, e As ItemDragEventArgs)
        If e.Button <> MouseButtons.Left Then
            Return
        End If
        DoDragDrop(New DataObject(from), DragDropEffects.Move)
    End Sub
    Private Sub lvAvailableFields_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles lvAvailableFields.ItemDrag
        HandleItemDrag(lvAvailableFields, e)
    End Sub
    Private Shared Sub HandleDragOver(from As ListView, e As DragEventArgs)
        If from.Equals(e.Data.GetData(GetType(ListView))) Then
            e.Effect = e.AllowedEffect
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub UpdateButtons()
        Dim enable As Boolean = lvAvailableFields.Items.Count > 0
        btnAdd.Enabled = enable AndAlso lvAvailableFields.SelectedItems.Count > 0
        btnAddAll.Enabled = enable
        enable = lvSelectedFields.Items.Count > 0
        btnRemove.Enabled = enable AndAlso lvSelectedFields.SelectedItems.Count > 0
        btnRemoveAll.Enabled = enable
        UpdateWizardButtons()
    End Sub
    Private Sub lvSelectedFields_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvSelectedFields.DragOver
        HandleDragOver(lvAvailableFields, e)
    End Sub
    Private Sub lvSelectedFields_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvSelectedFields.DragEnter
        HandleDragOver(lvAvailableFields, e)
    End Sub
    Private Sub lvSelectedFields_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles lvSelectedFields.ItemDrag
        HandleItemDrag(lvSelectedFields, e)
    End Sub
    Private Sub lvAvailableFields_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvAvailableFields.DragEnter
        HandleDragOver(lvSelectedFields, e)
    End Sub
    Private Sub lvAvailableFields_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvAvailableFields.DragOver
        HandleDragOver(lvSelectedFields, e)
    End Sub
    Private Sub lvSelectedFields_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvSelectedFields.DragDrop
        MoveSelectedItems(lvAvailableFields, lvSelectedFields)
    End Sub
    Private Sub lvAvailableFields_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvAvailableFields.DragDrop
        MoveSelectedItems(lvSelectedFields, lvAvailableFields)
    End Sub
    Private Function CanLeavePage() As Boolean
        If lvSelectedFields.Items.Count > 0 Then
            Return True
        End If
        Dim msg As String = DevExpress.XtraReports.Localization.ReportLocalizer.GetString(DevExpress.XtraReports.Localization.ReportStringId.Wizard_PageChooseFields_Msg)
        XtraMessageBox.Show(DesignLookAndFeelHelper.GetLookAndFeel(wizardBase.DesignerHost), msg, "Report Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return False
    End Function
    Private Sub ApplyChanges()
        fillFieldsListOnActivate = False
        wizardBase.SelectedFields.Clear()
        For Each item As ListViewItem In lvSelectedFields.Items
            wizardBase.SelectedFields.Add(TryCast(item.Tag, ObjectName))
        Next
    End Sub
    Protected Overrides Function OnWizardBack() As String
        fillFieldsListOnActivate = True
        Return WizardForm.NextPage
    End Function
    Protected Overrides Function OnWizardNext() As String
        If CanLeavePage() Then
            ApplyChanges()
            Return WizardForm.NextPage
        Else
            Return WizardForm.NoPageChange
        End If
    End Function
    Protected Overrides Function OnWizardFinish() As Boolean
        If CanLeavePage() Then
            ApplyChanges()
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub FillFieldLists()
        wizardBase.FillFields()
        lvAvailableFields.Items.Clear()
        lvSelectedFields.Items.Clear()
        Dim fields As ObjectNameCollection = wizardBase.Fields
        Dim count As Integer = fields.Count
        For i As Integer = 0 To count - 1
            Dim item As New ListViewItem(fields(i).DisplayName, 1)
            item.Tag = fields(i)
            lvAvailableFields.Items.Add(item)
        Next
        UpdateListViewColumnWidth(lvAvailableFields)
        UpdateListViewColumnWidth(lvSelectedFields)
        UpdateButtons()
    End Sub
    Protected Overrides Function OnSetActive() As Boolean
        If fillFieldsListOnActivate Then
            FillFieldLists()
        End If
        If lvAvailableFields.Items.Count > 0 AndAlso lvAvailableFields.SelectedItems.Count <= 0 Then
            lvAvailableFields.Items(0).Selected = True
        End If
        Return True
    End Function
    Protected Overrides Sub UpdateWizardButtons()
        If lvSelectedFields.Items.Count > 0 Then
            Wizard.WizardButtons = WizardButton.Back Or WizardButton.[Next] Or WizardButton.Finish
        Else
            Wizard.WizardButtons = WizardButton.Back Or WizardButton.Finish
        End If
    End Sub

    Private Sub lvSelectedFields_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvSelectedFields.SelectedIndexChanged
        UpdateButtons()
    End Sub
    Private Sub lvAvailableFields_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvAvailableFields.SelectedIndexChanged
        UpdateButtons()
    End Sub

End Class
