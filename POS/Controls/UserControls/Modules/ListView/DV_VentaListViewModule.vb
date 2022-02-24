Imports Studio.Net.Controls.New
Imports Studio.Vision.POS.BLL.Business
Imports Studio.Phone.POS.DAL.EntityClasses
Imports DevExpress.Data.Filtering
Imports Studio.Phone.POS.DAL
Imports Studio.Net.BLL
Imports Studio.Phone.POS.BLL
Imports SD.LLBLGen.Pro.ORMSupportClasses

Public Class DV_VentaListViewModule

    'Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
    '    'MyBase.OnLoad(e)
    'End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConfigRibbon()

    End Sub

    Private Sub ConfigRibbon()
        'Pasar el bbinewVenta a la primera posición
        rpgRecordManager.ItemLinks.Remove(bbiNewVenta)
        rpgRecordManager.ItemLinks.Insert(0, bbiNewVenta)
        RibbonControl.SelectedPage = rpInicio


    End Sub

    Protected Overrides Sub OnRibbonItemClick(ByVal item As DevExpress.XtraBars.ItemClickEventArgs)
        'MyBase.OnRibbonItemClick(item)
        Select Case item.Item.Name
            Case bbiNewRecetaComun.Name
                OnNewRecetaComunClicked()
            Case bbiNewRecetaLenteContacto.Name
                OnNewRecetaContactoClicked()
            Case bbiBuscar.Name
                pnlBuscar.Visible = bbiBuscar.Down
            Case bbiNewVenta.Name
            Case Else
                MyBase.OnRibbonItemClick(item)
        End Select

    End Sub

    Private Sub OnNewRecetaComunClicked()

        Try
            Try
                Studio.Net.Helper.CursorManager.WaitCursor()

                DetailModule.SetCaller(Me)

                ListViewToUse.EntityCollection.Add(DV_RecetaComunBEntity.CreateNewEntity())
                'Posicionarse en el registro recién agregado
                ListViewToUse.Binding.Position = ListViewToUse.Binding.Count - 1
                DetailModule.OnShowingModule() 'DetailViewToUse.OnAddingToModule()
                _parent.ShowModule(DetailModule)

            Catch ex As Exception
                MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            Finally
                Studio.Net.Helper.CursorManager.Default()
            End Try



        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub OnNewRecetaContactoClicked()
        Throw New NotImplementedException
    End Sub


    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click

        Try

            ApplySearchFilter()
            bbiBuscar.PerformClick()
        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub ApplySearchFilter()

        Dim criteria As New GroupOperator
        Dim root As New DocumentoSalidaEntity
        Dim fInfo As FilterFieldInfo
        Dim fields As New List(Of FilterFieldInfo)

        If cboClienteId.EditValue IsNot Nothing Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, DocumentoSalidaFieldIndex.ClienteId.ToString())
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, CType(cboClienteId.EditValue, Integer)))
            fields.Add(fInfo)
        End If
        If txtNroDocumento.Text <> String.Empty Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, DocumentoSalidaFieldIndex.NumeroDocumento.ToString())
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, txtNroDocumento.Text, BinaryOperatorType.Equal))
            fields.Add(fInfo)
        End If

        If txtCedulaRUT.Text <> String.Empty Then
            If txtCedulaRUT.Text.Length <= 10 Then
                fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("Cliente.ClienteParticular.{0}", ClienteParticularFieldIndex.DocumentoIdentidad.ToString()))
                criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, txtCedulaRUT.Text))
                fields.Add(fInfo)
            Else
                fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, String.Format("Cliente.ClienteEmpresa.{0}", ClienteEmpresaFieldIndex.Ruc.ToString()))
                criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, txtCedulaRUT.Text))
                fields.Add(fInfo)
            End If
        End If
        If txtFDesde.DateTime > System.DateTime.MinValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, DocumentoSalidaFieldIndex.FechaEmitida.ToString())
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, txtFDesde.DateTime, BinaryOperatorType.GreaterOrEqual))
            fields.Add(fInfo)
        End If
        If txtFHasta.DateTime > System.DateTime.MinValue Then
            fInfo = GraphTreeHelper.GetFilterFieldInfoFromFieldFullName(root, DocumentoSalidaFieldIndex.FechaEmitida.ToString())
            criteria.Operands.Add(New BinaryOperator(fInfo.PropertyInfo.FullPath, txtFHasta.DateTime, BinaryOperatorType.LessOrEqual))
            fields.Add(fInfo)
        End If

        ListViewToUse.DXCriteria = String.Empty
        ListViewToUse.UserFilter = Nothing

        If fields.Count > 0 Then
            ListViewToUse.ApplyFilter(fields, criteria)

            ListViewToUse.LoadData()
        End If


    End Sub

    Private Sub LinqInstantFeedbackSource1_DismissQueryable(sender As Object, e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles LinqInstantFeedbackSource1.DismissQueryable
        Dim da As IDataAccessAdapter = TryCast(e.Tag, IDataAccessAdapter)
        If da IsNot Nothing Then
            da.Dispose()
        End If
        e.Tag = Nothing
    End Sub

    Private Sub LinqInstantFeedbackSource1_GetQueryable(sender As System.Object, e As DevExpress.Data.Linq.GetQueryableEventArgs) Handles LinqInstantFeedbackSource1.GetQueryable
        Dim da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
        e.QueryableSource = (New ClienteBEntity).GetDataForComboAsQueryable(da)
        e.Tag = da
    End Sub


    Private Sub InitializeForm()
        cboClienteId.Properties.PopulateViewColumns()
        'cboClienteId.Properties.View.Columns(ClienteFieldIndex.Id.ToString()).Width = 30
    End Sub

    Protected Overrides Sub OnLoad(e As System.EventArgs)
        MyBase.OnLoad(e)
        InitializeForm()
    End Sub

    Private Sub cboClienteId_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboClienteId.QueryPopUp
        cboClienteId.Properties.View.Columns(ClienteFieldIndex.Id.ToString()).MaxWidth = 40
    End Sub

End Class
