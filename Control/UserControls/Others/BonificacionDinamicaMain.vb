Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Net.BLL
Imports Studio.Phone.BLL
Imports Studio.Phone.DAL.HelperClasses

Public Class BonificacionDinamicaMain

    Protected Overrides Sub OnLoad(e As EventArgs)

        MyBase.OnLoad(e)

        ConfigGrid(grdMarca, New MarcaBEntity, BonificacionDinamicaIdFields.MarcaId)
        ConfigGrid(grdArticuloNivel, New NivelBEntity, BonificacionDinamicaIdFields.NivelId)
        ConfigGrid(grdArticulo, New ArticuloBEntity, BonificacionDinamicaIdFields.ArticuloId)
        ConfigGrid(grdArticuloCategoria, New ArticuloCategoriaBEntity, BonificacionDinamicaIdFields.ArticuloCategoriaId)
        ConfigGrid(grdRubro, New RubroBEntity, BonificacionDinamicaIdFields.RubroId)
        ConfigGrid(grdLocal, New LocalBEntity, BonificacionDinamicaIdFields.LocalId)
        ConfigGrid(grdArticuloNivel, New NivelBEntity, BonificacionDinamicaIdFields.NivelId)
        ConfigGrid(grdCliente, New ClienteBEntity, BonificacionDinamicaIdFields.ClienteId)
        ConfigGrid(grdListaPreVta, New ListaPreVtaBEntity, BonificacionDinamicaIdFields.ListaPreVtaId)

    End Sub

    Private Sub ConfigGrid(grd As GridControl, business As BEntityBase, fieldSelected As IEntityField2)
        With grd
            .DataSource = BonificacionDinamicaController.GetSelected(business, fieldSelected)
            With DirectCast(.MainView, GridView)
                .PopulateColumns()
                .OptionsBehavior.Editable = False
            End With
        End With
    End Sub

End Class
