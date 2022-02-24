Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.UI
Imports System.ComponentModel
Imports DevExpress.XtraReports.Native
Imports Studio.Net.Controls.New
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports System.ComponentModel.Design
Imports Studio.Net.BLL

Public Class MyNewXtraReportWizardTreeView
    Inherits XtraReportStandardBuilderWizard

    Private _dataContainer As IDataContainer
    Private _binding As MyBindingSource
    Private _rootEntity As IEntity2

    Public Sub New(report As XtraReport, rootEntity As IEntity2, container As IDataContainer)
        MyBase.New(report)
        _dataContainer = container
        _rootEntity = rootEntity
    End Sub

    Protected Overrides Sub PrepareDataSet()

        If _binding Is Nothing Then
            Return
        End If

        DesignToolHelper.ForceAddToContainer(DesignerHost.Container, _binding, "OrigenDeDatos")
        _dataContainer.DataSource = _binding
        Dim svc As IComponentChangeService = DirectCast(Me.DesignerHost.GetService(GetType(IComponentChangeService)), IComponentChangeService)
        If svc IsNot Nothing Then
            svc.OnComponentChanged(_dataContainer, Nothing, Nothing, Nothing)
        End If

    End Sub

    Protected Overrides Function GetFieldType(fieldName As String) As System.Type
        Dim field As IEntityField2 = GraphTreeHelper.GetEntityField2FromFieldFullName(_rootEntity, fieldName)
        If field IsNot Nothing Then
            Return field.DataType
        End If
        Return Nothing
    End Function

    Public ReadOnly Property RootEntity As IEntity2
        Get
            Return _rootEntity
        End Get
    End Property

    Public Function ToObjectName(info As PropertySelectorInfo) As ObjectName
        Return New ObjectName(info.FullPath, info.ToStringFull(), info.FieldData.Name)
    End Function

End Class
