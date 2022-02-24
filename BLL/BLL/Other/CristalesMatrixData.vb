Public Class CristalesMatrixData

    ' Fields...
    Private _cristales As List(Of CristalData)
    Public Property Cristales As List(Of CristalData)
        Get
            If _cristales Is Nothing Then
                _cristales = New List(Of CristalData)
            End If
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

    ' Fields...
    Private _valores As List(Of CristalValor)
    Public Property Valores As List(Of CristalValor)
        Get
            If _valores Is Nothing Then
                _valores = New List(Of CristalValor)
            End If
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
    Public Property PlantillaValor1 As Decimal
    Public Property PlantillaValor2 As Decimal
    Public Property IsChanged As Boolean = False

    Private _valor As Decimal
    Public Property Valor As Decimal
        Get
            Return _valor
        End Get
        Set(ByVal value As Decimal)
            If _valor <> value Then
                IsChanged = True
            End If
            _valor = value
        End Set
    End Property

    Public Sub SetValor(ByVal value As Decimal)
        _valor = value
    End Sub

    Public Property NoExiste As Boolean

End Class