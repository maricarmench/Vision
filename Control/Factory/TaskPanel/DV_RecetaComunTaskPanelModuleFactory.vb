Imports Studio.Net.Controls.New.Factory
Imports Studio.Net.Controls.New.UserControls
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Vision.BLL
Imports Studio.Vision.BLL.Business
Imports Studio.Phone.DAL.EntityClasses

Public Class DV_RecetaComunTaskPanelModuleFactory
    Implements IControlFactory

    Public Function Create() As Object Implements Studio.Net.Controls.New.Factory.IControlFactory.Create
        Return New DV_HistoricoRecetaComunTaskPanel() With {.ListViewToUse = New DV_HistoricoRecetaComunDynamicTabularListView(New DV_RecetaComunEntity)}
    End Function

End Class
