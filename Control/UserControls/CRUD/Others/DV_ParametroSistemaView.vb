Imports Studio.Vision.BLL
Imports Studio.Config.BLL
Imports Studio.Phone.BLL
Imports Studio.Net.Controls.New
Imports Studio.Vision.BLL.Business
Imports Studio.Phone.DAL
Imports Studio.Net.BLL
Imports Studio.Phone.DAL.HelperClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses

Public Class DV_ParametroSistemaView

    Protected Overrides Function GetParametro() As DrakoParametroTree
        Return ParametroSistemaController.GetParametroTree()
    End Function

    Protected Overrides Sub Save(ByVal param As DrakoParametroTree)
        Controls2Data(param)
        ParametroSistemaController.SaveParametroTree(param)
    End Sub

    Protected Overrides Sub Controls2Data(ByVal param As Phone.BLL.DrakoParametroTree)
        MyBase.Controls2Data(param)
        With DirectCast(param, VisionParametroTree)
            .Optica.Venta.EsfericoMaxParaTerminados = txtEsfericoMaxParaTerminados.EditValue
            .Optica.Venta.PorcentajeSeñaRecetaComun = txtPorcentajeSeñaRecetaComun.EditValue
            .Optica.Venta.PorcentajeSeñaRecetaContacto = txtPorcentajeSeñaRecetaContacto.EditValue
            .Optica.Venta.NoPedirSeñaEnConvenios = chkNoPedirSeñaEnConvenios.Checked
            .Optica.AAtributoPlantillaIDCristalesCilindrico = CInt(cboAAtributoPlantillaIdCilindrico.EditValue)
            .Optica.AAtributoPlantillaIDCristalesEsferico = CInt(cboAAtributoPlantillaIdEsferico.EditValue)
            .Optica.AAtributoPlantillaIDCristalesAdicion = CInt(cboAAtributoPlantillaIdAdicion.EditValue)
            .Optica.DiaEntregaRecetaComun = CInt(txtDiasEntregaRecetaComun.EditValue)
            .Optica.DiaEntregaRecetaContacto = CInt(txtDiasEntregaRecetaContacto.EditValue)
            .Optica.Venta.IVAIdOverrideReceta = cboImpuestoIdOverrideIVA.EditValue
            .Optica.ManejoCilindrico = CType(cboManejoCilindricos.EditValue, ManejoCilindricos)
            .Optica.WorkFlowIDReceta = cboRecetaWorkFlowID.EditValue
            .Optica.WorkFlowIDRecetaComun = cboRecetaComunWorkFlowID.EditValue
            .Optica.WorkFlowIDRecetaContacto = cboRecetaContactoWorkFlowID.EditValue

        End With

    End Sub

    Protected Overrides Sub Data2Controls(ByVal param As Phone.BLL.DrakoParametroTree)
        MyBase.Data2Controls(param)
        With DirectCast(param, VisionParametroTree)
            txtEsfericoMaxParaTerminados.EditValue = .Optica.Venta.EsfericoMaxParaTerminados
            txtPorcentajeSeñaRecetaComun.EditValue = .Optica.Venta.PorcentajeSeñaRecetaComun
            txtPorcentajeSeñaRecetaContacto.EditValue = .Optica.Venta.PorcentajeSeñaRecetaContacto
            chkNoPedirSeñaEnConvenios.Checked = .Optica.Venta.NoPedirSeñaEnConvenios
            cboAAtributoPlantillaIdEsferico.EditValue = .Optica.AAtributoPlantillaIDCristalesEsferico
            cboAAtributoPlantillaIdCilindrico.EditValue = .Optica.AAtributoPlantillaIDCristalesCilindrico
            cboAAtributoPlantillaIdAdicion.EditValue = .Optica.AAtributoPlantillaIDCristalesAdicion

            txtDiasEntregaRecetaComun.EditValue = .Optica.DiaEntregaRecetaComun
            txtDiasEntregaRecetaContacto.EditValue = .Optica.DiaEntregaRecetaContacto
            cboImpuestoIdOverrideIVA.EditValue = .Optica.Venta.IVAIdOverrideReceta
            cboManejoCilindricos.EditValue = .Optica.ManejoCilindrico

            cboRecetaWorkFlowID.EditValue = .Optica.WorkFlowIDReceta
            cboRecetaComunWorkFlowID.EditValue = .Optica.WorkFlowIDRecetaComun
            cboRecetaContactoWorkFlowID.EditValue = .Optica.WorkFlowIDRecetaContacto

        End With

    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        Try

            Dim field1 As BEField = (New DV_CristalPlantillaBEntity).Fields(DV_CristalPlantillaFieldIndex.AAtributoPlantillaID1.ToString())
            Dim field2 As BEField = (New DV_CristalPlantillaBEntity).Fields(DV_CristalPlantillaFieldIndex.AAtributoPlantillaID1.ToString())
            Dim field3 As BEField = (New DV_CristalPlantillaBEntity).Fields(DV_CristalPlantillaFieldIndex.AAtributoPlantillaID1.ToString())
            Dim field4 As BEField = (New DocSalidaDetalleBEntity).Fields(DocSalidaDetalleFieldIndex.ImpuestoId.ToString())
            field1.DisplayControl = cboAAtributoPlantillaIdCilindrico
            field2.DisplayControl = cboAAtributoPlantillaIdEsferico
            field3.DisplayControl = cboAAtributoPlantillaIdAdicion
            field4.DisplayControl = cboImpuestoIdOverrideIVA
            field4.ForeignBEntity.SysFilterExpression = ImpuestoController.CrearFiltroPorSoloIVA()
            BindingControlHelper.setControlProperties(field1, True)
            BindingControlHelper.setControlProperties(field2, True)
            BindingControlHelper.setControlProperties(field3, True)
            BindingControlHelper.setControlProperties(field4, True)
            BindingControlHelper.SetDevExpressLookUpProperties(Nothing, False, New WorkFlowBEntity With {.SysFilterExpression = New RelationPredicateBucket(WorkFlowFields.EntidadID = EntidadBEntity.INT_ENTIDAD_RECETAS)}, cboRecetaWorkFlowID, Nothing, String.Empty)
            BindingControlHelper.SetDevExpressLookUpProperties(Nothing, False, New WorkFlowBEntity With {.SysFilterExpression = New RelationPredicateBucket(WorkFlowFields.EntidadID = EntidadBEntity.INT_ENTIDAD_RECETAS_COMUNES)}, cboRecetaComunWorkFlowID, Nothing, String.Empty)
            BindingControlHelper.SetDevExpressLookUpProperties(Nothing, False, New WorkFlowBEntity With {.SysFilterExpression = New RelationPredicateBucket(WorkFlowFields.EntidadID = EntidadBEntity.INT_ENTIDAD_RECETAS_CONTACTO)}, cboRecetaContactoWorkFlowID, Nothing, String.Empty)
            field1.DisplayControl = Nothing
            field2.DisplayControl = Nothing
            field3.DisplayControl = Nothing
            field4.DisplayControl = Nothing
            cboManejoCilindricos.BindFromEnum(GetType(ManejoCilindricos))

            MyBase.OnLoad(e)

        Catch ex As Exception
            MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
            CloseDialog()
        End Try
    End Sub

End Class
