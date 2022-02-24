Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.FactoryClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses

Namespace Business
    <Serializable()> Public Class DV_RecetaBEntity
        Inherits Studio.Phone.BLL.DocumentoSalidaBEntity

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub CreateFields()
            MyBase.CreateFields()
        End Sub

        Protected Overrides Function CreateEntityFactory() As SD.LLBLGen.Pro.ORMSupportClasses.IEntityFactory2
            Return New Studio.Phone.DAL.FactoryClasses.DV_RecetaEntityFactory
        End Function


        'Public Shared Function CrearFiltroParaFlujo(ByVal estado As RecetaEstado, ByVal clienteId As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date) As IRelationPredicateBucket
        '    Dim filtro As New RelationPredicateBucket
        '    filtro.PredicateExpression.Add(DV_RecetaFields.RecetaEstadoId = estado)
        '    If clienteId > 0 Then
        '        filtro.PredicateExpression.Add(DV_RecetaFields.ClienteId = clienteId)
        '    End If
        '    filtro.PredicateExpression.Add(DV_RecetaFields.FechaEmitida >= fechaInicio And DV_RecetaFields.FechaEmitida <= fechaFin)
        '    Return filtro
        'End Function


    End Class

End Namespace