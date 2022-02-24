Imports System.Xml.Serialization
Imports System.IO

<Serializable()> _
Public Class ParametroCaja

    Public Property TipoReceta As Nullable(Of Integer)
    Public Property TipoOperacion As Nullable(Of Integer)
    Public Property TipoDeVenta As Nullable(Of Integer)
    Public Property CristalMaterialId As Nullable(Of Integer)
    Public Property ImpresoraBoletas As String

    Public Function ToXML() As String

        Dim ser As New XmlSerializer(Me.GetType())
        Dim sw As New StringWriter
        ser.Serialize(sw, Me)
        Return sw.ToString()

    End Function

    Public Shared Function FromXML(ByVal xmlString) As ParametroCaja

        If String.IsNullOrEmpty(xmlString) Then Return Nothing

        Dim x As New Xml.Serialization.XmlSerializer(GetType(ParametroCaja))
        Dim sr As New IO.StringReader(xmlString)
        Return CType(x.Deserialize(sr), ParametroCaja)

    End Function
End Class
