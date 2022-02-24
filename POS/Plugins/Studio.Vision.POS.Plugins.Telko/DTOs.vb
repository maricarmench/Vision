Imports Newtonsoft.Json

Public Class DTOs

    Public Class ReciboDTO
        Public Property Numero As String
        Public Property ClienteId As Integer
        Public Property FechaEmision As DateTime
        Public Property MonedaId As Integer
        Public Property Importe As Decimal
        Public Property Observaciones As String
        Public Property Cobros As List(Of CobroDTO)
    End Class

    Public Class CobroDTO
        Public Sub New(ByVal recibo As ReciboDTO)
            recibo = recibo
        End Sub

        <JsonIgnore>
        Public ReadOnly Property Recibo As ReciboDTO
        Public Property PlanFinancieroId As Integer
        Public Property MonedaId As Integer
        Public Property TipodeCambio As Decimal
        Public Property Monto As Decimal
        Public Property Atributos As List(Of CobroAtributoDTO)
    End Class

    Public Class CobroAtributoDTO
        Public Sub New(ByVal cobro As CobroDTO)
            cobro = cobro
        End Sub

        <JsonIgnore>
        Public ReadOnly Property Cobro As CobroDTO
        Public Property AtributoId As Integer
        Public Property Valor As String
    End Class

End Class
