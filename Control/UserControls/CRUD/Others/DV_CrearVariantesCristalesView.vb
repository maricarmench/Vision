Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Vision.BLL.Business
Imports Studio.Phone.BLL
Imports Studio.Net.Controls.New
Imports Studio.Net.Controls.New.Forms
Imports Studio.Net.Helper

Public Class DV_CrearVariantesCristalesView
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal cristal As DV_CristalEntity)

        Me.New()

        _cristal = cristal
        _plantilla = DV_CristalPlantillaBEntity.GetById(cristal.CristalPlantillaID)

        InitializeForm()

    End Sub

    Private _plantilla As DV_CristalPlantillaEntity
    Private _cristal As DV_CristalEntity

    Private Sub InitializeForm()

        lcgPlantilla1.Text = AAtributoPlantillaBEntity.GetNombreById(_plantilla.AAtributoPlantillaID1)
        lcgPlantilla2.Text = AAtributoPlantillaBEntity.GetNombreById(_plantilla.AAtributoPlantillaID2)

        txtAtributo1Min.Properties.MinValue = _plantilla.AAtributoPlantilla1Minimo
        txtAtributo1Min.Properties.MaxValue = _plantilla.AAtributoPlantilla1Maximo
        txtAtributo1Min.Properties.Increment = _plantilla.AAtributoPlantilla1Intervalo

        txtAtributo1Max.Properties.MinValue = _plantilla.AAtributoPlantilla1Minimo
        txtAtributo1Max.Properties.MaxValue = _plantilla.AAtributoPlantilla1Maximo
        txtAtributo1Max.Properties.Increment = _plantilla.AAtributoPlantilla1Intervalo

        txtAtributo2Min.Properties.MinValue = _plantilla.AAtributoPlantilla2Minimo
        txtAtributo2Min.Properties.MaxValue = _plantilla.AAtributoPlantilla2Maximo
        txtAtributo2Min.Properties.Increment = _plantilla.AAtributoPlantilla2Intervalo

        txtAtributo2Max.Properties.MinValue = _plantilla.AAtributoPlantilla2Minimo
        txtAtributo2Max.Properties.MaxValue = _plantilla.AAtributoPlantilla2Maximo
        txtAtributo2Max.Properties.Increment = _plantilla.AAtributoPlantilla2Intervalo

        txtAtributo1Min.EditValue = _plantilla.AAtributoPlantilla1Minimo
        txtAtributo1Max.EditValue = _plantilla.AAtributoPlantilla1Maximo
        txtAtributo2Min.EditValue = _plantilla.AAtributoPlantilla2Minimo
        txtAtributo2Max.EditValue = _plantilla.AAtributoPlantilla2Maximo

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Dim business As New DV_CristalBEntity
        Dim articuloController As New ArticuloController

        Try
            If MyMsgBox.Show("¿Seguro que desea crear las variantes?." & ControlChars.NewLine & "Se recomienda verificar que los rangos ingresados sean los correctos porque en caso contrario se generará una gran cantidad de datos y no se podrá deshacer esta operación.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                GetMainForm().ShowWaitForm("Generando variantes")
                CursorManager.WaitCursor()
                Enabled = False
                AddHandler business.CrearVarianteProgress, AddressOf OnCrearVarianteProgress
                AddHandler articuloController.SaveCombinacionProgress, AddressOf OnSaveCombinacion

                business.CrearVariantes(_cristal, articuloController, _
                        CType(txtAtributo1Min.EditValue, Decimal), _
                        CType(txtAtributo1Max.EditValue, Decimal), _
                        CType(txtAtributo2Min.EditValue, Decimal), _
                        CType(txtAtributo2Max.EditValue, Decimal))
                ParentForm.DialogResult = DialogResult.OK
                CloseDialog()
            End If

        Catch ex As Exception
            GetMainForm().CloseWaitForm()
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            Enabled = True
        Finally
            GetMainForm().CloseWaitForm()
            RemoveHandler business.CrearVarianteProgress, AddressOf OnCrearVarianteProgress
            RemoveHandler articuloController.SaveCombinacionProgress, AddressOf OnSaveCombinacion
        End Try

    End Sub

    Private Function GetMainForm() As MainFormBase
        If Not TypeOf ParentForm Is MainFormBase Then
            Return DirectCast(ParentForm.Owner, MainFormBase)
        End If
        Return DirectCast(ParentForm, MainFormBase)
    End Function

    Private Sub OnCrearVarianteProgress(ByVal sender As Object, ByVal e As Net.BLL.PercentageStepEventArgs)
        GetMainForm().SetWaiFormDescription(String.Format("Fase 1/2 - {0}%.", e.Percentage))
    End Sub

    Private Sub OnSaveCombinacion(ByVal sender As Object, ByVal e As Net.BLL.PercentageStepEventArgs)
        GetMainForm().SetWaiFormDescription(String.Format("Fase 2/2 - {0}%.", e.Percentage))
    End Sub

End Class
