Imports Studio.Net.Controls.New
Imports Studio.Net.Controls.New.Forms
Imports Studio.Net.Helper
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses

Public Class DV_CristalListViewModule

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RibbonControl1.SelectedPage = rpInicio

    End Sub

    Protected Overrides Sub OnRibbonItemClick(ByVal item As DevExpress.XtraBars.ItemClickEventArgs)

        Select Case item.Item.Name
            Case bbiCambiarPrecios.Name
                OnCambiarPreciosClicked()
            Case bbiCopiar.Name
                OnCopiarClicked()
            Case Else
                MyBase.OnRibbonItemClick(item)
        End Select

    End Sub

    Private Sub OnCambiarPreciosClicked()

        Dim pForm As System.Windows.Forms.Form = FindForm()

        Try

            Using c As New DV_CambiarPreciosCristalesVarianteView() With {.Dock = DockStyle.Fill, .Caption = "Cambio de precio de variante de cristales."}

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

    Private Sub OnCopiarClicked()

        If ListViewToUse.CurrentEntity Is Nothing Then Return

        Try

            CursorManager.WaitCursor()
            _parent.ShowWaitForm("Copiando artículo")
            Dim newArticulo As DV_CristalEntity = ArticuloController.ClonarArticulo(ListViewToUse.GetCurrentEntity(Of DV_CristalEntity))
            With DirectCast(ListViewToUse.GridControl.DataSource, MyBindingSource)
                DirectCast(.DataSource, IEntityCollection2).Add(newArticulo)
                .Position = .Count - 1
                OnEditClicked()
            End With

        Catch ex As Exception
            ShowMsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            _parent.CloseWaitForm()
            CursorManager.Default()
        End Try

    End Sub
    
End Class
