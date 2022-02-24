Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Net.Controls.New
Imports Studio.Net.Helper
Imports Studio.Net.Controls.New.Forms
Imports Studio.Vision.BLL.Business

Public Class DV_CrearVariantesDeCristales

#Region "CTor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Caption = "Creación de variante de cristales en forma masiva"
        Icon = Icon.FromHandle(My.Resources.Commands_Icon.GetHicon())

    End Sub

    Public Sub New(ByVal cristal As DV_CristalEntity)
        Me.New()

        _cristalEntity = cristal
        labDescripcion.Text = _cristalEntity.Descripcion
    End Sub

#End Region

#Region "Variables de modulo"

    Private _cristalEntity As DV_CristalEntity
    Private _pgForm As ProgressForm
#End Region

#Region "Eventos de acción"

    'Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

    '    Dim cristalBs As New DV_CristalBEntity

    '    If MyMsgBox.Show("¿Esta seguro que desea generar las variantes de cristales?.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
    '        Return
    '    End If

    '    Try
    '        Me.ParentForm.Enabled = False
    '        CursorManager.WaitCursor()
    '        _pgForm = New Studio.Net.Controls.[New].Forms.ProgressForm
    '        _pgForm.Owner = Me.ParentForm
    '        _pgForm.StartPosition = FormStartPosition.CenterScreen
    '        _pgForm.ShowProgress(100, "Progreso")
    '        Application.DoEvents()
    '        AddHandler cristalBs.CrearVarianteProgress, AddressOf OnCrearVarianteProgress
    '        cristalBs.CrearVariantes(_cristalEntity, Int32.Parse(txtDiametro.EditValue), _
    '                                 Decimal.Parse(txtEsfericoDesde.EditValue), Decimal.Parse(txtEsfericoHasta.EditValue), _
    '                                 Decimal.Parse(txtCilindricoDesde.EditValue), Decimal.Parse(txtCilindricoHasta.EditValue), chkValoresMesMenos.Checked)
    '        _pgForm.HideProgress()
    '        MyMsgBox.Show("Variantes generadas existosamente.", MsgBoxStyle.Information)
    '        ParentForm.DialogResult = DialogResult.OK
    '        'ParentForm.Close()
    '    Catch ex As Exception
    '        _pgForm.HideProgress()
    '        MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
    '    Finally
    '        _pgForm.Close()
    '        _pgForm.Dispose()
    '        _pgForm = Nothing
    '        RemoveHandler cristalBs.CrearVarianteProgress, AddressOf OnCrearVarianteProgress
    '        Me.ParentForm.Enabled = True
    '        CursorManager.Default()
    '        If ParentForm.DialogResult = DialogResult.OK Then
    '            CloseDialog()
    '        End If
    '    End Try

    'End Sub

#End Region

#Region "Procedimientos privados"

    Private Sub OnCrearVarianteProgress(ByVal sender As Object, ByVal e As Net.BLL.PercentageStepEventArgs)
        _pgForm.Progress(e.Percentage)
        Application.DoEvents()
    End Sub

#End Region

End Class

