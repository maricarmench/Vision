Imports Studio.Net.Controls.New.Forms
Imports DevExpress.XtraBars.Ribbon
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL
Imports DevExpress.XtraBars
Imports Studio.Net.Controls.New

Public Class DV_CristalDetailViewModule

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal parent As MainFormBase, ByVal view As DV_CristalDetailView)

        MyBase.New(parent, view)

        InitializeComponent()

        'InitializeRibbon()

    End Sub

    Private Sub InitializeRibbon()

        RibbonControl.SelectedPage = rpInicio
        'Dim rpg As New RibbonPageGroup() With {.Text = "Tareas"}
        'Dim link As BarItemLink = rpg.ItemLinks.Add(bbiAgregarCristalesBulk)

        'RibbonControl.SelectedPage.Groups.Insert(RibbonControl.SelectedPage.Groups.Count - 1, rpg)
    End Sub

    'Protected Overrides Sub OnCurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    MyBase.OnCurrentItemChanged(sender, e)
    '    CheckAsociarMasiva()
    'End Sub

    'Protected Overrides Sub OnCheckDirtiness(ByVal sender As Object, ByVal e As System.EventArgs)
    '    MyBase.OnCheckDirtiness(sender, e)
    '    CheckAsociarMasiva()
    'End Sub

    Private Sub CheckAsociarMasiva()
        bbiVariantes.Enabled = GetCurrentEntity(Of DV_CristalEntity).IsNew = False AndAlso DetailViewToUse.GetCurrentEntity(Of DV_CristalEntity).GuiaDeVariante AndAlso Not IsEntityDirty()
    End Sub

    Protected Overrides Sub OnDetailViewAssigned()
        MyBase.OnDetailViewAssigned()
        AddHandler DetailViewToUse.DirtyChanged, AddressOf OnDetailViewDirtyChanged
    End Sub

    Public Overrides Sub DisposeModule()
        RemoveHandler DetailViewToUse.DirtyChanged, AddressOf OnDetailViewDirtyChanged
        MyBase.DisposeModule()
    End Sub

    Private Sub OnDetailViewDirtyChanged(ByVal sender As Object, ByVal e As EventArgs)
        CheckAsociarMasiva()
    End Sub

    Protected Overrides Sub OnRibbonItemClick(ByVal item As DevExpress.XtraBars.ItemClickEventArgs)
        Select Case item.Item.Name
            Case bbiVariantes.Name
                OnAgregarVariantesClicked()
            Case bbiCambiarPrecios.Name
                OnCambiarPreciosClicked()
            Case Else
                MyBase.OnRibbonItemClick(item)

        End Select

    End Sub

    Private Sub OnAgregarVariantesClicked()

        DirectCast(DetailViewToUse, DV_CristalDetailView).ShowFormVariantes()

    End Sub

    'Protected Overrides Sub OnCheckDirtiness(ByVal sender As Object, ByVal e As System.EventArgs)

    '    MyBase.OnCheckDirtiness(sender, e)
    '    If DetailViewToUse Is Nothing Then Return

    '    Dim isDirty As Boolean = IsEntityDirty()
    '    bbiAgregarCristalesBulk.Enabled = Not isDirty

    'End Sub

    Private Sub OnCambiarPreciosClicked()

        Dim currentEntity As DV_CristalEntity = GetCurrentEntity(Of DV_CristalEntity)()

        If currentEntity Is Nothing OrElse currentEntity.IsNew Then
            Return
        End If

        Dim pForm As System.Windows.Forms.Form = FindForm()

        Try

            Using c As New DV_CambiarPreciosCristalesVarianteView(currentEntity.Id) With {.Dock = DockStyle.Fill, .Caption = "Cambio de precio de variante de cristales."}

                Using f As New DialogForm()
                    Dim parentForm As MainFormBase = TryCast(FindForm(), MainFormBase)
                    If parentForm IsNot Nothing Then
                        f.Location = parentForm.PointToScreen(New System.Drawing.Point(parentForm.xTab.Left, parentForm.panel.Top))
                        f.Size = parentForm.xTab.Size
                    Else
                        f.Location = FindForm().Location()
                        f.Size = FindForm().Size
                    End If
                    f.StartPosition = Windows.Forms.FormStartPosition.Manual
                    f.Icon = My.Resources.Cambiar_precios_16x16
                    If pForm IsNot Nothing Then
                        pForm.Enabled = False
                    End If
                    f.Text = c.Caption
                    f.Controls.Add(c)
                    If f.ShowDialog(pForm) = Windows.Forms.DialogResult.OK Then
                        'RaiseEvent ItemAdded(Me, New EntityAddedEventArgs(f.AddedEntity))
                    End If
                End Using
            End Using

        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        Finally
            If pForm IsNot Nothing Then
                pForm.Enabled = True
            End If
        End Try
    End Sub


End Class
