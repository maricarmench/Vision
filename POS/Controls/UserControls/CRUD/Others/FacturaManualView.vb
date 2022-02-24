Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL
Imports Studio.Net.BLL
Imports Studio.Net.Controls.New
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.DAL.HelperClasses

Public Class FacturaManualView

    Private _receta As DV_RecetaComunEntity

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'InitializeForm()

    End Sub

    Public Sub New(receta As DV_RecetaComunEntity)
        Me.New()

        _receta = receta

    End Sub


    Private Sub InitializeForm()
        Dim dummyBs As New DocumentoSalidaBEntity
        Dim docField As BEField = dummyBs.Fields(DocumentoSalidaFieldIndex.DocumentoTipoId.ToString())
        docField.DisplayControl = cboDocumentoTipoId
        Studio.Net.Controls.[New].BindingControlHelper.setControlProperties(docField, True)
        txtFechaEmitida.EditValue = System.DateTime.Today
        cboDocumentoTipoId.EditValue = _receta.DocumentoTipoId
        cboDocumentoTipoId.Properties.ReadOnly = True
        txtNumeroDocumento.Focus()
    End Sub

    Protected Overrides Sub OnLoad(e As System.EventArgs)

        MyBase.OnLoad(e)

        InitializeForm()

    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim dummyReceta As DV_RecetaComunEntity = _receta.DeepClone()
        Try
            DxErrorProvider1.ClearErrors()
            'If txtNumeroDocumento.Text = String.Empty Then
            '    DxErrorProvider1.SetError(txtNumeroDocumento, "Debe ingresar el número de documento.")
            'End If

            dummyReceta.NumeroDocumento = txtNumeroDocumento.Text
            dummyReceta.FechaEmitida = txtFechaEmitida.DateTime
            dummyReceta.IsNew = False

            Dim valid As New ValidatorHelper
            valid.Validate(dummyReceta, False)

            ParentForm.DialogResult = DialogResult.OK
            CloseDialog()
        Catch ex As EntitiesValidationException
            DxErrorProvider1.DataSource = New EntityCollection(Of DV_RecetaComunEntity)(New DV_RecetaComunEntity() {dummyReceta})
            DxErrorProvider1.UpdateBinding()
            ShowErrors(ex.InvalidEntities)

        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        ParentForm.DialogResult = DialogResult.Cancel
        CloseDialog()
    End Sub
End Class
