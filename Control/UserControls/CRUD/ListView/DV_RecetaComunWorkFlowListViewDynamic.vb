Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Net.Controls.New
Imports Studio.Phone.DAL
Imports Studio.Net.BLL

Public Class DV_RecetaComunWorkFlowListViewDynamic

#Region "CTor"

    Public Sub New(ByVal rootEntity As IEntity2)

        MyBase.New(rootEntity)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New()

        MyBase.New(New DV_RecetaComunEntity)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Overrides"

    Protected Overrides Sub OnAddFields(ByVal fields As System.Collections.Generic.List(Of DynamicFieldMetaData))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.FechaEmitida.ToString()), GetRootEntity(), "Fecha emitida"))
        fields.Add(New DynamicFieldMetaData(String.Format("Cliente.{0}", ClienteFieldIndex.Descripcion.ToString()), GetRootEntity(), "Cliente"))
        fields.Add(New DynamicFieldMetaData(String.Format("{0}", DV_RecetaComunFieldIndex.NumeroDocumento.ToString()), GetRootEntity(), "Nro."))
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        'MyBase.OnLoad(e)
    End Sub

#End Region

End Class
