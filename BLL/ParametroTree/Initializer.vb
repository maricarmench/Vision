Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.BLL
Imports System.Linq
Imports Studio.Vision.BLL.RubroControllerExtensions
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Config.BLL

Public Class Initializer
    Public Shared Function CrearValoresPorDefecto() As VisionParametroTree

        Dim param As VisionParametroTree = ParametroSistemaController.GetParametroTree()
        If param Is Nothing OrElse Not param.IsSaved Then
            param = New VisionParametroTree
            Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
                Try
                    da.StartTransaction(IsolationLevel.Serializable, "trn")
                    'param.Optica.RubroIdCristales = (New RubroController).CrearRubroParaCristal(da).Id
                    Dim colPlantilla As EntityCollection(Of AAtributoPlantillaEntity) = (New AAtributoPlantillaController).CrearPlantillasParaCristales(da)
                    'param.Optica.AAtributoPlantillaIDCristalesDiametro = colPlantilla(0).ID
                    param.Optica.AAtributoPlantillaIDCristalesEsferico = colPlantilla(0).ID
                    param.Optica.AAtributoPlantillaIDCristalesCilindrico = colPlantilla(1).ID
                    param.Optica.AAtributoPlantillaIDCristalesAdicion = colPlantilla(2).ID
                    If CInt(param.CostoDeVenta.ModoCalculo) = 0 Then
                        param.CostoDeVenta.ModoCalculo = CostoVentaModoCalculo.UltimoPrecioDeCompra
                    End If

                    param.IsSaved = True
                    ParametroSistemaController.SaveParametroTree(da, param)
                    da.Commit()

                Catch ex As Exception
                    If da.IsTransactionInProgress Then
                        da.Rollback()
                    End If
                    Throw
                End Try
            End Using

        End If

        Return param

    End Function
End Class
