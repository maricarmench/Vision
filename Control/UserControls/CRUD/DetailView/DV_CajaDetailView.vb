Imports Studio.Net.Controls.New.Forms
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.BLL
Imports Studio.Net.Controls.New

Public Class DV_CajaDetailView

#Region "CTor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As CajaBEntity, ByVal binding As MyBindingSource)


        MyBase.New(business, binding)

        InitializeComponent()

        'ConfigDependencies()

    End Sub

#End Region

#Region "Eventos de acción"

    Private Sub txtXML_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtXML.ButtonClick

        Dim caja As CajaEntity = GetCurrentEntity(Of CajaEntity)()

        Using c As New DV_CajaXMLDetailView(caja.XML)
            Using f As New Studio.Net.Controls.[New].Forms.SaveDeleteGenericDialog(c)
                f.StartPosition = FormStartPosition.CenterParent
                f.Text = "Datos por defecto en recetas"
                If f.ShowDialog(FindForm()) = DialogResult.OK Then
                    c.GuardarDatos()
                    txtXML.Text = c.Parametro.ToXML()
                End If
            End Using
        End Using

    End Sub

#End Region

End Class
