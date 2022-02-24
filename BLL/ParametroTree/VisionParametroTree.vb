<Serializable()> _
Public Class VisionParametroTree
    Inherits Studio.Phone.BLL.DrakoParametroTree

    Public Sub New()
    End Sub

    Private _opticatree As OpticaTree
    Public Property Optica As OpticaTree
        Get
            If _opticatree Is Nothing Then
                _opticatree = New OpticaTree
            End If
            Return _opticatree
        End Get
        Set(ByVal value As OpticaTree)
            _opticatree = value
        End Set
    End Property

    <Serializable()> _
    Public Class OpticaTree

        Public Sub New()
        End Sub

        Public Property RubroIdCristales As Integer
        'Public Property AAtributoPlantillaIDCristalesDiametro As Integer
        Public Property AAtributoPlantillaIDCristalesEsferico As Integer
        Public Property AAtributoPlantillaIDCristalesCilindrico As Integer
        Public Property AAtributoPlantillaIDCristalesAdicion As Integer
        Public Property ManejoCilindrico As ManejoCilindricos

        Public Property DiaEntregaRecetaComun As Integer
        Public Property DiaEntregaRecetaContacto As Integer
        Public Property WorkFlowIDRecetaComun As Nullable(Of Integer)
        Public Property WorkFlowIDRecetaContacto As Nullable(Of Integer)
        Public Property WorkFlowIDReceta As Nullable(Of Integer)

        Private _venta As Venta
        Public Property Venta As Venta
            Get
                If _venta Is Nothing Then
                    _venta = New Venta
                End If
                Return _venta
            End Get
            Set(ByVal value As Venta)
                _venta = value
            End Set
        End Property
    End Class

    <Serializable()> _
    Public Class Venta

        Public Property EsfericoMaxParaTerminados As Decimal
        Public Property PorcentajeSeñaRecetaComun As Decimal
        Public Property PorcentajeSeñaRecetaContacto As Decimal
        Public Property NoPedirSeñaEnConvenios As Boolean
        Public Property IVAIdOverrideReceta As Nullable(Of Integer)
    End Class

End Class
