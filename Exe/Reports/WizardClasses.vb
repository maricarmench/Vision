Imports DevExpress.XtraReports.UserDesigner
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.UI
Imports SD.LLBLGen.Pro.ORMSupportClasses

'Public Class MyWizardCommandHandler
'    Implements ICommandHandler

'    Private panel As XRDesignPanel
'    Private _rootEntity As IEntity2

'    Public Sub New(panel As XRDesignPanel, rootEntity As IEntity2)
'        Me.panel = panel
'        _rootEntity = _rootEntity
'    End Sub

'    Public Overridable Function CanHandleCommand(command As ReportCommand) As Boolean Implements ICommandHandler.CanHandleCommand
'        Return command = ReportCommand.NewReportWizard OrElse command = ReportCommand.AddNewDataSource OrElse command = ReportCommand.VerbReportWizard
'    End Function

'    Public Overridable Sub HandleCommand(command As ReportCommand, args As Object(), ByRef handled As Boolean) Implements ICommandHandler.HandleCommand
'        If Not CanHandleCommand(command) Then
'            Return
'        End If

'        Dim wizard As New CustomWizard(panel.Report, _rootEntity)

'        wizard.Run()
'        handled = True
'    End Sub
'End Class

Public Class CustomWizard
    Inherits XRWizardRunnerBase

    Public Sub New(report As XtraReport, rootEntity As IEntity2)
        MyBase.New(report)
        Me.Wizard = New MyNewXtraReportWizardTreeView(report, Nothing, rootEntity)
    End Sub



    Public Function Run() As DialogResult

        If Me.Report Is Nothing Then
            Return DialogResult.Cancel
        End If

        Dim form As New XtraReportWizardForm(Wizard.DesignerHost)

        form.Controls.AddRange(New Control() {New WizPageWelcome(Me), New MyWizChooseFields(Me), New WizPageGrouping(Me), _
                                New WizPageSummary(Me), New WizPageGroupedLayout(Me), New WizPageUngroupedLayout(Me), New WizPageStyle(Me), New WizPageReportTitle(Me), New WizPageLabelType(Me), _
                                New WizPageLabelOptions(Me)})

        Dim result As DialogResult = form.ShowDialog()

        If result = DialogResult.OK Then
            Wizard.BuildReport()
        End If

        For i As Integer = 0 To WizardHelper.SelectedFields.Count - 1
            Dim label As New XRLabel()

            label.Text = String.Format("[{0}]", WizardHelper.SelectedFields(i))
            label.Location = New System.Drawing.Point(20, 20 + i * 40)

            DesignToolHelper.AddToContainer(Me.Wizard.DesignerHost, label)

            Me.Report.Bands(BandKind.Detail).FindControl("panel1", True).Controls.Add(label)
        Next

        WizardHelper.SelectedFields.Clear()

        Return result
    End Function

End Class

Public Class WizardHelper
    Private Shared _lastDataSourceWizardType As String

    Public Shared Property LastDataSourceWizardType() As String
        Get
            Return WizardHelper._lastDataSourceWizardType
        End Get
        Set(value As String)
            WizardHelper._lastDataSourceWizardType = value
        End Set
    End Property

    Private Shared _selectedFields As New List(Of String)()

    Public Shared Property SelectedFields() As List(Of String)
        Get
            Return WizardHelper._selectedFields
        End Get
        Set(value As List(Of String))
            WizardHelper._selectedFields = value
        End Set
    End Property

End Class
