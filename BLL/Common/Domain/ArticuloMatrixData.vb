Public Class CristalesMatrixData

    ' Fields...
    Private _cristales As List(Of CristalData)
    Public Property Cristales As List(Of CristalData)
        Get
            Return _cristales
        End Get
        Set(ByVal Value As List(Of CristalData))
            _cristales = Value
        End Set
    End Property

End Class

Public Class CristalData

    Public Property ArticuloId As Integer
    Public Property Descripcion As String
    Public Property PlantillaId1 As Integer
    Public Property PlantillaId2 As Integer
    Public Property PlantillaDescripcion1 As String
    Public Property PlantillaDescripcion2 As String


    ' Fields...
    Private _valores As List(Of CristalValor)
    Public Property Valores As List(Of CristalValor)
        Get
            Return _valores
        End Get
        Set(ByVal Value As List(Of CristalValor))
            _valores = Value
        End Set
    End Property

End Class

Public Class CristalValor

    Public Property ArticuloId As Integer
    Public Property PlantillaValorID1 As Integer
    Public Property PlantillaValorID2 As Integer
    Public Property Valor As Decimal

End Class