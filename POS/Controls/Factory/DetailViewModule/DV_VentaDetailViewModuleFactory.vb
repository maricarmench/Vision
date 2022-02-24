Imports Studio.Net.Controls.New.UserControls
Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New
Imports Studio.Net.Controls.New.Forms
Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL.HelperClasses
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Phone.POS.Controls.New

Public Class DV_VentaDetailViewModuleFactory
    Implements IDetailViewModuleFactory

    Public Function Create(ByVal parent As Net.Controls.New.Forms.MainFormBase, ByVal listModule As Net.Controls.New.IListViewModule, ByVal isNew As Boolean) As Net.Controls.New.UserControls.DetailViewModule Implements Net.Controls.New.Factory.IDetailViewModuleFactory.Create
        'Usar un nuevo binding que use la entity Tmp_DocumentoSalidaEntity para que todo funcione como antes
        Dim newBinding As New MyBindingSource
        newBinding.DataSource = New EntityCollection(Of Tmp_DocumentoSalidaEntity)
        Return New VentaDetailViewModule() With {.DetailViewToUse = New DV_VentaDetailView(listModule.ListViewToUse.BusinessEntity, newBinding, ConfigReaderSpecific.GetCajaId())}
    End Function

End Class

