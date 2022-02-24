Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Vision.BLL
Imports Studio.Net.Controls.[New]
Imports Studio.Net.BLL
Imports Studio.Vision.BLL.Business
Imports Studio.Phone.DAL

Public Class DV_CajaXMLDetailView

    Private _parametro As ParametroCaja

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New(xml As String)

        Me.New()

        ConfigControls()

        If Not String.IsNullOrEmpty(xml) Then
            CargarDatos(ParametroCaja.FromXML(xml))
        End If

    End Sub

    Private Sub CargarDatos(parametro As ParametroCaja)

        cboMaterialTipoId.EditValue = parametro.CristalMaterialId
        cboRecetaTipo.EditValue = parametro.TipoReceta
        cboTipoOperacion.EditValue = parametro.TipoOperacion
        cboTipoVenta.EditValue = parametro.TipoDeVenta
        'txtImpresoraBoletas.Text = parametro.ImpresoraBoletas

    End Sub

    Public Sub GuardarDatos()

        _parametro = New ParametroCaja

        If cboMaterialTipoId.HasValue() Then
            _parametro.CristalMaterialId = cboMaterialTipoId.EditValue
        End If
        If cboRecetaTipo.HasValue() Then
            _parametro.TipoReceta = cboRecetaTipo.EditValue
        End If
        If cboTipoOperacion.HasValue() Then
            _parametro.TipoOperacion = cboTipoOperacion.EditValue
        End If
        If cboTipoVenta.HasValue() Then
            _parametro.TipoDeVenta = cboTipoVenta.EditValue
        End If
        'If txtImpresoraBoletas.Text <> String.Empty Then
        '    _parametro.ImpresoraBoletas = txtImpresoraBoletas.Text
        'End If

    End Sub

    Public ReadOnly Property Parametro As ParametroCaja
        Get
            Return _parametro
        End Get
    End Property

    Private Sub ConfigControls()

        cboTipoOperacion.BindFromEnum(GetType(RecetaComunOperacion))
        cboTipoVenta.BindFromEnum(GetType(RecetaVentaTipo))

        Dim field As BEField = (New DV_CristalBEntity).Fields(DV_CristalFieldIndex.CristalMaterialId.ToString())
        field.DisplayControl = cboMaterialTipoId
        Studio.Net.Controls.[New].BindingControlHelper.setControlProperties(field, True)

        field = (New DV_RecetaComunBEntity).Fields(DV_RecetaComunFieldIndex.RecetaComunTipo.ToString())
        field.DisplayControl = cboRecetaTipo
        Studio.Net.Controls.[New].BindingControlHelper.setControlProperties(field, True)

    End Sub

End Class
