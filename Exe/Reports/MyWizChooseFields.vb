Imports DevExpress.XtraReports.Design
Imports Studio.Net.BLL

Public Class MyWizChooseFields

    Private _MyWizard As MyNewXtraReportWizardTreeView

    Public Sub New(runner As XRWizardRunnerBase)
        _MyWizard = DirectCast(runner.Wizard, MyNewXtraReportWizardTreeView)

        InitializeComponent()

        LoadFields()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overridable Sub LoadFields()
        MyPropertySelector1.RootEntity = _MyWizard.RootEntity
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click

        Dim pInfo As PropertySelectorInfo = MyPropertySelector1.FocusedPropertyInfo
        If Not FieldAlreadySelected(pInfo.FullPath) Then
            lvSelectedFields.Items.Add(pInfo.FullPath, pInfo.ToStringFull(), -1)
        End If

    End Sub

    Private Sub UpdateButtons()
        btnAdd.Enabled = MyPropertySelector1.FocusedNode IsNot Nothing
    End Sub

    Private Function FieldAlreadySelected(fullName As String) As Boolean
        For Each item As ListViewItem In lvSelectedFields.Items
            If item.Name = fullName Then
                Return True
            End If
        Next
        Return False
    End Function

End Class
