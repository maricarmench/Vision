Imports Studio.Vision.POS.BLL.Business
Imports Studio.Net.Controls.New
Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Net.BLL
Imports Studio.Net.Helper
Imports Studio.Net.Controls.New.Forms

Public Class DV_RecetaComunChange_DetailView

    Private _origReceta As DV_RecetaComunEntity

#Region "CTor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal business As DV_RecetaComunBEntity, ByVal binding As MyBindingSource)

        MyBase.New(business, binding)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _origReceta = binding.CurrentEntity.DeepClone()

        Caption = "Cambio de cristales"

    End Sub

#End Region

    Protected Overrides Sub LockControls()


        LayoutControl.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True
        'LayoutControl.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False
        LayoutControl.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.Default

        For Each item As KeyValuePair(Of String, LayoutControlItem) In _bindedControls

            Dim c As BaseEdit = TryCast(item.Value.Control, BaseEdit)


            If c IsNot Nothing Then
                Dim fieldName As String = BindingControlHelper.Control2FieldName(c)
                If Not String.IsNullOrEmpty(fieldName) AndAlso BusinessToUse.Fields.FindByName(fieldName) IsNot Nothing Then
                    Dim isNotReadOnly As Boolean = _
                        (EntityToEdit.CristalIdLejosDerecho > 0 AndAlso (c Is cboCristalIdLejosDerecho OrElse c Is cboCristalMaterialIdLejosDerecho)) OrElse _
                        (EntityToEdit.CristalIdLejosIzquierdo > 0 AndAlso (c Is cboCristalIdLejosIzquierdo OrElse c Is cboCristalMaterialIdLejosIzquierdo)) OrElse _
                        (EntityToEdit.CristalIdCercaDerecho > 0 AndAlso _cercaEsSegundoPar AndAlso (c Is cboCristalIdCercaDerecho OrElse c Is cboCristalMaterialIdCercaDerecho)) OrElse _
                        (EntityToEdit.CristalIdCercaIzquierdo > 0 AndAlso _cercaEsSegundoPar AndAlso (c Is cboCristalIdCercaIzquierdo OrElse c Is cboCristalMaterialIdCercaIzquierdo))
                    c.Properties.ReadOnly = Not isNotReadOnly

                End If
            End If

        Next

        btnOpcionCliente.Enabled = False
        cboServiciosLejos.Properties.ReadOnly = True
        cboServiciosCerca.Properties.ReadOnly = True

        gvItems.OptionsBehavior.Editable = False

    End Sub

    Protected Overrides Sub OnCurrentEntityChanged(sender As Object, e As System.EventArgs)

        Entity2Controls()
        LockControls()
    End Sub

    Protected Overrides Sub OnLoad(e As System.EventArgs)
        'MyBase.OnLoad(e)
        OnCurrentEntityChanged(Me, EventArgs.Empty)
        _lockUpdate = False
        'AddHandler DirectCast(Me.ParentForm, , AddressOf
    End Sub

    Public Overrides Function SaveCurrent() As Boolean

        Dim toReturn As Boolean = False
        Dim isChanged As Boolean = False

        Controls2Entity()
        CargarArticulosInternal()

        DxErrorProvider1.ClearErrors()

        'TODO: Guardar cambio de serie
        If _origReceta.CristalIdLejosDerecho > 0 Then
            If EntityToEdit.CristalIdLejosDerecho = 0 Then
                DxErrorProvider1.SetError(cboCristalIdLejosDerecho, "No se puede dejar vacio el cristal de lejos derecho")
            Else
                If EntityToEdit.CristalIdLejosDerecho <> _origReceta.CristalIdLejosDerecho Then
                    isChanged = True
                End If
            End If
        End If

        If _origReceta.CristalIdLejosIzquierdo > 0 Then
            If EntityToEdit.CristalIdLejosIzquierdo = 0 Then
                DxErrorProvider1.SetError(cboCristalIdLejosIzquierdo, "No se puede dejar vacio el cristal de lejos izquierdo")
            Else
                If EntityToEdit.CristalIdLejosIzquierdo <> _origReceta.CristalIdLejosIzquierdo Then
                    isChanged = True
                End If
            End If
        End If

        If _origReceta.CristalMaterialIdCercaDerecho > 0 Then
            If EntityToEdit.CristalIdCercaDerecho = 0 Then
                DxErrorProvider1.SetError(cboCristalIdCercaDerecho, "No se puede dejar vacio el cristal de cerca derecho")
            Else
                If EntityToEdit.CristalIdCercaDerecho <> _origReceta.CristalIdCercaDerecho Then
                    isChanged = True
                End If
            End If
        End If

        If _origReceta.CristalMaterialIdCercaIzquierdo > 0 Then
            If EntityToEdit.CristalIdCercaIzquierdo = 0 Then
                DxErrorProvider1.SetError(cboCristalIdCercaIzquierdo, "No se puede dejar vacio el cristal de cerca izquierdo")
            Else
                If EntityToEdit.CristalIdCercaIzquierdo <> _origReceta.CristalIdCercaIzquierdo Then
                    isChanged = True
                End If
            End If
        End If

        If isChanged AndAlso Not DxErrorProvider1.HasErrors Then
            'GUARDAR
            Dim mainForm As MainFormBase = DirectCast(ParentForm.Owner, MainFormBase)
            ParentForm.Enabled = False
            Try

                CursorManager.WaitCursor()
                mainForm.ShowWaitForm("Guardando cambios")
                DV_RecetaComunBEntity.CambiarArticulos(EntityToEdit, _origReceta)
                Return True
            Catch ex As EntitiesValidationException
                ShowErrors(ex.InvalidEntities)
            Catch ex As Exception
                mainForm.CloseWaitForm()
                MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            Finally
                ParentForm.Enabled = True
                mainForm.CloseWaitForm()
                CursorManager.Default()
            End Try

        ElseIf Not isChanged AndAlso Not DxErrorProvider1.HasErrors Then
            If _origReceta.CristalIdLejosDerecho > 0 Then
                DxErrorProvider1.SetError(cboCristalIdLejosDerecho, "Debe cambiar el cristal derecho de cerca y/o lejos")
            End If
            If _origReceta.CristalIdLejosIzquierdo > 0 Then
                DxErrorProvider1.SetError(cboCristalIdLejosIzquierdo, "Debe cambiar el cristal izquierdo de cerca y/o lejos")
            End If
            If _origReceta.CristalIdCercaDerecho > 0 Then
                DxErrorProvider1.SetError(cboCristalIdCercaDerecho, "Debe cambiar el cristal derecho de cerca y/o lejos")
            End If
            If _origReceta.CristalIdCercaIzquierdo > 0 Then
                DxErrorProvider1.SetError(cboCristalIdCercaIzquierdo, "Debe cambiar el cristal Izquierdo de cerca y/o lejos")
            End If
        End If

        Return False

    End Function

    Public Overrides Sub OnAddingToContainer()
        MyBase.OnAddingToContainer()
    End Sub

    Protected Overrides Function CurrentEntityIsNew() As Boolean
        Return True
    End Function

    Protected Overrides Sub Entity2Controls()
        MyBase.Entity2Controls()
        cboCristalIdLejosDerecho.RefresDataSource()
        cboCristalIdCercaDerecho.RefresDataSource()

        cboCristalIdLejosIzquierdo.RefresDataSource()
        cboCristalIdCercaIzquierdo.RefresDataSource()


        With GetCurrentEntity(Of DV_RecetaComunEntity)()
            If .CristalIdCercaDerecho > 0 Then
                cboCristalIdCercaDerecho.EditValue = .CristalIdCercaDerecho
            End If
            If .CristalIdCercaIzquierdo > 0 Then
                cboCristalIdCercaIzquierdo.EditValue = .CristalIdCercaIzquierdo
            End If

            If .CristalIdLejosDerecho > 0 Then
                cboCristalIdLejosDerecho.EditValue = .CristalIdLejosDerecho
            End If
            If .CristalIdLejosIzquierdo > 0 Then
                cboCristalIdLejosIzquierdo.EditValue = .CristalIdLejosIzquierdo
            End If


        End With

    End Sub

    Protected Overrides Sub CargarArticulos()

        'NO HACEMOS NADA

    End Sub

End Class
