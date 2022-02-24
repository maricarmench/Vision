Imports Studio.Phone.POS.BLL
Imports Studio.Phone.POS.DAL.EntityClasses
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Vision.POS.BLL.Business
Imports Studio.Net.Controls.New
Imports Studio.Vision.POS.BLL
Imports Studio.Phone.POS.DAL


Public Class OrdenTrabajoRecetaComun_Ticket
    Implements IImprimirFactura

    Public Sub Proceso(venta As Phone.POS.DAL.EntityClasses.DocumentoSalidaEntity) Implements IImprimirFactura.Proceso

        Const C_INT_ANCHO As Integer = 48

        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create()
            Dim receta As DV_RecetaComunEntity = DV_RecetaComunBEntity.GetRecetaParaImpresion(venta.Id, venta.CajaId)
            With receta

                Dim prn As New Studio.Net.Printing.StarPSTPrinter
                Try
                    prn.OpenPrinter(ConfigReaderSpecific.GetDefaultPrinterName(.CajaId, .DocumentoTipoId))
                    Dim lResult As Long
                    lResult = prn.NewDocument()
                    lResult = prn.NewPage()
                    'Si es una devolución imprimimos el texto ">> DEVOLUCION <<"
                    Dim signo As Integer = SignoController.SignoDeDocumento(da, .DocumentoTipoId)
                    If signo < Decimal.Zero Then
                        '                        prn.SetAlignment(Net.Printing.EpsonTMU950Printer.Aligment.Center)
                        'prn.SetFontBold(True)
                        prn.WriteLine(">> DEVOLUCION <<")
                        prn.WriteLine(" ")
                    End If

                    'CABEZAL (Razon Social + Fecha Hora)
                    Dim empresa As String = EmpresaController.BuscarPorCajaId(.CajaId).RazonSocial
                    Dim fecha As String = DateTime.Now.ToString("g")
                    Dim cabezal As String = empresa & StrDup(C_INT_ANCHO - empresa.Length - fecha.Length, " ") & fecha
                    'prn.ReserPrinter()
                    'prn.WriteLine(cabezal)
                    prn.WriteLine(" ")
                    ''prn.SetFontBold(True)
                    'prn.SetAlignment(Net.Printing.EpsonTMU950Printer.Aligment.Center)
                    'prn.Font.DoubleHeight = True
                    'prn.Font.DoubleWidth = True
                    prn.WriteLine(DocumentoTipoController.DescripcionFromId(da, .DocumentoTipoId))
                    'prn.ReserPrinter()
                    'prn.WriteLine(" " )
                    'Nro. documento
                    ''prn.SetFontBold(True)
                    'prn.Font.DoubleWidth = True
                    Dim linea As String = "Nro. orden: " & .NumeroDocumento
                    Dim linea1 As String
                    Dim linea2 As String
                    Dim linea3 As String
                    Dim linea4 As String
                    Dim linea5 As String
                    Dim linea6 As String
                    Dim linea7 As String
                    ''prn.Write(Chr(&H1B) & Chr(&H21) & Chr(2))
                    ''prn.SetFontBold(True)
                    'prn.WriteLine(linea)
                    ''prn.Write(Chr(&H1B) & Chr(&H21) & Chr(1))
                    ''prn.SetFontBold(False)
                    'prn.Font.DoubleWidth = False
                    'Cliente
                    linea = "Cliente: " & .ClienteId.ToString() & " - " & .Nombre
                    prn.WriteLine(linea)
                    'Fecha emision
                    linea = "Fecha emi: " & .FechaEmitida.ToString("d") & "   " & "F. entrega: " & .FechaEntrega.ToString("d")
                    prn.WriteLine(linea)

                    Dim separador As String = StrDup(C_INT_ANCHO, "-")
                    prn.WriteLine(separador)

                    Dim Espacio01 As String = " "
                    Dim Espacio05 As String = "     "
                    Dim Espacio06 As String = "      "
                    Dim Espacio07 As String = "       "
                    Dim Espacio08 As String = "        "
                    Dim Espacio11 As String = "           "
                    Dim Espacio15 As String = "               "
                    Dim Espacio16 As String = "                "
                    Dim Espacio19 As String = "                   "
                    Dim Espacio20 As String = "                    "
                    Dim Espacio25 As String = "                         "

                    'LENTE DE LEJOS
                    If .CristalIdLejosDerecho > 0 OrElse .CristalIdOjoLejosIzquierdo > 0 OrElse .ArmazonIdLejos > 0 OrElse .ServiciosLejos.Count > 0 Then
                        'CAMBIAMOS EL TIPO DE LETRA
                        ''prn.Write(Chr(&H1B) & Chr(&H21) & Chr(2))
                        'prn.SetFontBold(True)
                        prn.WriteLine("LENTE DE LEJOS:")
                        'VOLVEMOS A LA LETRA POR DEFECTO
                        ''prn.Write(Chr(&H1B) & Chr(&H21) & Chr(1))
                        ''prn.SetFontBold(False)
                        prn.WriteLine(separador)
                        'Ojo Derecho
                        If .CristalIdLejosDerecho > 0 Then
                            ''prn.SetFontBold(True)
                            prn.WriteLine(String.Format("Derecho"))
                            ''prn.SetFontBold(False)
                            prn.WriteLine(separador)
                            'Eje, Cil, Esf, Ad, Dst, Alt
                            'Cambiamos el tipo de letra
                            ''prn.Write(Chr(&H1B) & Chr(&H21) & Chr(2))
                            ''prn.SetFontBold(True)
                            prn.WriteLine("    Eje" & "    Cil" & "    Esf" & "     Ad" & "    Dst" & "    Alt")
                            ''prn.SetFontBold(False)
                            'Eje
                            If .Fields(DV_RecetaComunFieldIndex.EjeOjoLejosDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea1 = Left(String.Format("{0,8}", .EjeOjoLejosDerecho.ToString()), 8)
                            Else
                                linea1 = Espacio07
                            End If
                            'Cil
                            If .Fields(DV_RecetaComunFieldIndex.CilindricoOjoLejosDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea2 = Right(String.Format("{0,7}", .CilindricoOjoLejosDerecho.ToString("\+0.00;\-0.00;0")), 7)
                            Else
                                linea2 = Espacio07
                            End If
                            'Esf
                            If .Fields(DV_RecetaComunFieldIndex.EsfericoOjoLejosDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea3 = Right(String.Format("{0,7}", .EsfericoOjoLejosDerecho.ToString("\+0.00;\-0.00;0")), 7)
                            Else
                                linea3 = Espacio07
                            End If
                            'Ad
                            If .Fields(DV_RecetaComunFieldIndex.AdicionOjoLejosDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea4 = Right(String.Format("{0,7}", .AdicionOjoLejosDerecho.ToString("\+0.00;\-0.00;0")), 7)
                            Else
                                linea4 = Espacio07
                            End If
                            'Dst
                            If .Fields(DV_RecetaComunFieldIndex.DistanciaOjoLejosDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea5 = Right(String.Format("{0,7}", .DistanciaOjoLejosDerecho.ToString()), 7)
                            Else
                                linea5 = Espacio07
                            End If
                            'Alt
                            If .Fields(DV_RecetaComunFieldIndex.AlturaOjoLejosDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea6 = Right(String.Format("{0,7}", .AlturaOjoLejosDerecho.ToString()), 7)
                            Else
                                linea6 = Espacio07
                            End If
                            'Imprimo resultados
                            linea = linea1 & linea2 & linea3 & linea4 & linea5 & linea6
                            prn.WriteLine(linea)
                            ''prn.SetFontBold(True)
                            'Pri y grado
                            prn.WriteLine("    Pri" & "    Gr.")
                            ''prn.SetFontBold(False)
                            If .Fields(DV_RecetaComunFieldIndex.PrismaOjoLejosDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea1 = Right(String.Format("{0,7}", .PrismaOjoLejosDerecho.ToString()), 7)
                            Else
                                linea1 = Espacio07
                            End If
                            If .Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoLejosDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea2 = Right(String.Format("{0,7}", .PrismaGraduacionOjoLejosDerecho.ToString()), 7)
                            Else
                                linea2 = Espacio07
                            End If
                            'Imprimo resultados pri y grado
                            linea = linea1 & linea2
                            prn.WriteLine(linea)
                            'Tipo de letra comun
                            ''prn.Write(Chr(&H1B) & Chr(&H21) & Chr(1))
                            ''prn.SetFontBold(True)

                            'Imprimo los valores calculados ********* TRANSPOSICIÓN ************

                            'Cambiamos el tipo de letra
                            'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(2))
                            ''prn.SetFontBold(True)
                            If .CilindricoOjoLejosDerecho <> .CilindricoOjoLejosDerechoCalc Then
                                prn.WriteLine("(TRANSP) Eje" & "    Cil" & "    Esf")
                                ''prn.SetFontBold(False)
                                'Eje
                                If .Fields(DV_RecetaComunFieldIndex.EjeOjoLejosDerechoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea1 = Left(String.Format("{0,13}", .EjeOjoLejosDerechoCalc.ToString()), 13)
                                Else
                                    linea1 = Espacio07
                                End If
                                'Cil
                                If .Fields(DV_RecetaComunFieldIndex.CilindricoOjoLejosDerechoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea2 = Right(String.Format("{0,7}", .CilindricoOjoLejosDerechoCalc.ToString("\+0.00;\-0.00;0")), 7)
                                Else
                                    linea2 = Espacio07
                                End If
                                'Esf
                                If .Fields(DV_RecetaComunFieldIndex.EsfericoOjoLejosDerechoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea3 = Right(String.Format("{0,7}", .EsfericoOjoLejosDerechoCalc.ToString("\+0.00;\-0.00;0")), 7)
                                Else
                                    linea3 = Espacio07
                                End If


                                'Imprimo resultados
                                linea = linea1 & linea2 & linea3
                                prn.WriteLine(linea)
                            End If
                            ' 'prn.SetFontBold(True)

                            'FIN ********* TRANSPOSICIÓN ************





                            'Material
                            prn.Write("Material:" & Espacio06)

                            ''prn.SetFontBold(False)
                            If .MaterialOjoLejosDerecho IsNot Nothing Then
                                linea = Left(.MaterialOjoLejosDerecho.Descripcion, 18)
                            Else
                                linea = ""
                            End If
                            prn.WriteLine(linea)
                            ''prn.SetFontBold(True)
                            'Cristal
                            prn.Write("Cristal:" & Espacio07)
                            'prn.SetFontBold(False)
                            If .CristalOjoLejosDerecho IsNot Nothing Then
                                linea = Left(.CristalOjoLejosDerecho.Descripcion, 30)
                            Else
                                linea = ""
                            End If
                            prn.WriteLine(linea)
                            'Cantidad de Unidades LejosDerecho
                            prn.WriteLine(String.Format("Unidad(es):{0}", .CantidadOjoLejosDerecho))
                            prn.WriteLine(separador)
                            'prn.SetFontBold(True)
                        End If

                        'Ojo izquierdo
                        If .CristalIdLejosIzquierdo > 0 Then
                            'prn.SetFontBold(True)
                            prn.WriteLine(String.Format("Izquierdo"))
                            'prn.SetFontBold(False)
                            prn.WriteLine(separador)
                            'Eje, Cil, Esf, Ad, Dst, Alt
                            'Cambio de letra
                            'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(2))
                            'prn.SetFontBold(True)
                            prn.WriteLine("    Eje" & "    Cil" & "    Esf" & "     Ad" & "    Dst" & "    Alt")
                            'prn.SetFontBold(False)
                            'Eje
                            If .Fields(DV_RecetaComunFieldIndex.EjeOjoLejosIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea1 = Right(String.Format("{0,8}", .EjeOjoLejosIzquierdo.ToString()), 8)
                            Else
                                linea1 = Espacio07
                            End If
                            'Cil
                            If .Fields(DV_RecetaComunFieldIndex.CilindricoOjoLejosIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea2 = Right(String.Format("{0,7}", .CilindricoOjoLejosIzquierdo.ToString("\+0.00;\-0.00;0")), 7)
                            Else
                                linea2 = Espacio07
                            End If
                            'Esf
                            If .Fields(DV_RecetaComunFieldIndex.EsfericoOjoLejosIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea3 = Right(String.Format("{0,7}", .EsfericoOjoLejosIzquierdo.ToString("\+0.00;\-0.00;0")), 7)
                            Else
                                linea3 = Espacio07
                            End If
                            'Ad
                            If .Fields(DV_RecetaComunFieldIndex.AdicionOjoLejosIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea4 = Right(String.Format("{0,7}", .AdicionOjoLejosIzquierdo.ToString("\+0.00;\-0.00;0")), 7)
                            Else
                                linea4 = Espacio07
                            End If
                            'Dst
                            If .Fields(DV_RecetaComunFieldIndex.DistanciaOjoLejosIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea5 = Right(String.Format("{0,7}", .DistanciaOjoLejosIzquierdo.ToString()), 7)
                            Else
                                linea5 = Espacio07
                            End If
                            'Alt
                            If .Fields(DV_RecetaComunFieldIndex.AlturaOjoLejosIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea6 = Right(String.Format("{0,7}", .AlturaOjoLejosIzquierdo.ToString()), 7)
                            Else
                                linea6 = Espacio07
                            End If
                            'Imprimo resultados
                            linea = linea1 & linea2 & linea3 & linea4 & linea5 & linea6
                            prn.WriteLine(linea)
                            'prn.SetFontBold(True)
                            'Pri y Grado
                            prn.WriteLine("    Pri" & "    Gr.")
                            If .Fields(DV_RecetaComunFieldIndex.PrismaOjoLejosIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea1 = Right(String.Format("{0,7}", .PrismaOjoLejosIzquierdo.ToString()), 7)
                            Else
                                linea1 = Espacio07
                            End If
                            If .Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoLejosIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea2 = Right(String.Format("{0,7}", .PrismaGraduacionOjoLejosIzquierdo.ToString()), 7)
                            Else
                                linea2 = Espacio07
                            End If
                            'Imprimo resultados Pri y grado
                            'prn.SetFontBold(False)
                            linea = linea1 & linea2
                            prn.WriteLine(linea)
                            'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(1))
                            'prn.SetFontBold(True)


                            'Imprimo los valores calculados ********* TRANSPOSICIÓN ************
                            If .CilindricoOjoLejosIzquierdo <> .CilindricoOjoLejosIzquierdoCalc Then
                                'Cambiamos el tipo de letra
                                'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(2))
                                'prn.SetFontBold(True)
                                prn.WriteLine("(TRANSP) Eje" & "    Cil" & "    Esf")
                                'prn.SetFontBold(False)
                                'Eje
                                If .Fields(DV_RecetaComunFieldIndex.EjeOjoLejosIzquierdoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea1 = Left(String.Format("{0,13}", .EjeOjoLejosIzquierdoCalc.ToString()), 13)
                                Else
                                    linea1 = Espacio07
                                End If
                                'Cil
                                If .Fields(DV_RecetaComunFieldIndex.CilindricoOjoLejosIzquierdoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea2 = Right(String.Format("{0,7}", .CilindricoOjoLejosIzquierdoCalc.ToString("\+0.00;\-0.00;0")), 7)
                                Else
                                    linea2 = Espacio07
                                End If
                                'Esf
                                If .Fields(DV_RecetaComunFieldIndex.EsfericoOjoLejosIzquierdoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea3 = Right(String.Format("{0,7}", .EsfericoOjoLejosIzquierdoCalc.ToString("\+0.00;\-0.00;0")), 7)
                                Else
                                    linea3 = Espacio07
                                End If

                                linea = linea1 & linea2 & linea3
                                prn.WriteLine(linea)
                                'prn.SetFontBold(True)
                            End If

                            'FIN ********* TRANSPOSICIÓN ************


                            'Material
                            prn.Write("Material:" & Espacio06)
                            'prn.SetFontBold(False)
                            If .MaterialOjoLejosIzquierdo IsNot Nothing Then
                                linea = Left(.MaterialOjoLejosIzquierdo.Descripcion, 18)
                            Else
                                linea = ""
                            End If
                            prn.WriteLine(linea)
                            'prn.SetFontBold(True)
                            'Cristal
                            prn.Write("Cristal:" & Espacio07)
                            'prn.SetFontBold(False)
                            If .CristalOjoLejosIzquierdo IsNot Nothing Then
                                linea = Left(.CristalOjoLejosIzquierdo.Descripcion, 30)
                            Else
                                linea = ""
                            End If
                            prn.WriteLine(linea)
                            'Cantidad de unidades LejosIzquierdo
                            prn.WriteLine(String.Format("Unidad(es):{0}", .CantidadOjoLejosIzquierdo))
                            prn.WriteLine(separador)
                        End If

                        'Armazon
                        'prn.SetFontBold(True)
                        prn.Write("Armazon:" & Espacio07)
                        'prn.SetFontBold(False)
                        If .ArmazonLejos IsNot Nothing Then
                            linea = String.Format("{0}", .ArmazonLejos.Descripcion)
                            linea1 = String.Format("Unidad(es):{0}", .CantidadArmazonLejos)
                        Else
                            linea = ""
                            linea1 = ""
                        End If
                        prn.WriteLine(linea)
                        prn.WriteLine(linea1)
                        'prn.SetFontBold(True)
                        'Servicios
                        prn.WriteLine("Servicios:")
                        'prn.SetFontBold(False)
                        For Each servicio As DocSalidaDetalleEntity In .ServiciosLejos
                            prn.WriteLine(Espacio15 & servicio.Descripcion)
                        Next
                    End If
                    'LENTE DE CERCA
                    If .CristalIdCercaDerecho > 0 OrElse .CristalIdOjoCercaIzquierdo > 0 OrElse .ArmazonIdCerca > 0 OrElse .ServiciosCerca.Count > 0 Then
                        'prn.SetFontBold(False)
                        prn.WriteLine(separador)
                        'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(2))
                        'prn.SetFontBold(True)
                        prn.WriteLine("LENTE DE CERCA:")
                        'prn.SetFontBold(False)
                        'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(1))
                        prn.WriteLine(separador)
                        'prn.SetFontBold(True)
                        'Ojo Derecho
                        If .CristalIdCercaDerecho > 0 Then
                            'prn.SetFontBold(True)
                            prn.WriteLine(String.Format("Derecho"))
                            'prn.SetFontBold(False)
                            prn.WriteLine(separador)
                            'Eje, Cil, Esf, Dst, Alt
                            'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(2))
                            'prn.SetFontBold(True)
                            prn.WriteLine("    Eje" & "    Cil" & "    Esf" & "    Dst" & "    Alt")
                            'prn.SetFontBold(False)
                            'Eje
                            If .Fields(DV_RecetaComunFieldIndex.EjeOjoCercaDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea1 = Right(String.Format("{0,8}", .EjeOjoCercaDerecho.ToString()), 8)
                            Else
                                linea1 = Espacio07
                            End If
                            'Cil
                            If .Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea2 = Right(String.Format("{0,7}", .CilindricoOjoCercaDerecho.ToString("\+0.00;\-0.00;0")), 7)
                            Else
                                linea2 = Espacio07
                            End If
                            'Esf
                            If .Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea3 = Right(String.Format("{0,7}", .EsfericoOjoCercaDerecho.ToString("\+0.00;\-0.00;0")), 7)
                            Else
                                linea3 = Espacio07
                            End If
                            'Dst
                            If .Fields(DV_RecetaComunFieldIndex.DistanciaOjoCercaDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea5 = Right(String.Format("{0,7}", .DistanciaOjoCercaDerecho.ToString()), 7)
                            Else
                                linea5 = Espacio07
                            End If
                            'Alt
                            If .Fields(DV_RecetaComunFieldIndex.AlturaOjoCercaDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea6 = Right(String.Format("{0,7}", .AlturaOjoCercaDerecho.ToString()), 7)
                            Else
                                linea6 = Espacio07
                            End If
                            'Imprimo resultados
                            linea = linea1 & linea2 & linea3 & linea5 & linea6
                            prn.WriteLine(linea)
                            'prn.SetFontBold(True)
                            'Pri y Grado
                            prn.WriteLine("    Pri" & "    Gr.")
                            If .Fields(DV_RecetaComunFieldIndex.PrismaOjoCercaDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea1 = Right(String.Format("{0,7}", .PrismaOjoCercaDerecho.ToString()), 7)
                            Else
                                linea1 = Espacio07
                            End If
                            If .Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoCercaDerecho.ToString()).CurrentValue IsNot Nothing Then
                                linea2 = Right(String.Format("{0,7}", .PrismaGraduacionOjoCercaDerecho.ToString()), 7)
                            Else
                                linea2 = Espacio07
                            End If
                            'Imprimo resultados Pri y grado
                            'prn.SetFontBold(False)
                            linea = linea1 & linea2
                            prn.WriteLine(linea)
                            'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(1))
                            'prn.SetFontBold(True)

                            'Imprimo los valores calculados ********* TRANSPOSICIÓN ************

                            'Cambiamos el tipo de letra
                            'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(2))
                            'prn.SetFontBold(True)
                            If .CilindricoOjoCercaDerecho <> .CilindricoOjoCercaDerechoCalc Then
                                prn.WriteLine("(TRANSP) Eje" & "    Cil" & "    Esf")
                                'prn.SetFontBold(False)
                                'Eje
                                If .Fields(DV_RecetaComunFieldIndex.EjeOjoCercaDerechoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea1 = Left(String.Format("{0,13}", .EjeOjoCercaDerechoCalc.ToString()), 13)
                                Else
                                    linea1 = Espacio07
                                End If
                                'Cil
                                If .Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaDerechoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea2 = Right(String.Format("{0,7}", .CilindricoOjoCercaDerechoCalc.ToString("\+0.00;\-0.00;0")), 7)
                                Else
                                    linea2 = Espacio07
                                End If
                                'Esf
                                If .Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaDerechoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea3 = Right(String.Format("{0,7}", .EsfericoOjoCercaDerechoCalc.ToString("\+0.00;\-0.00;0")), 7)
                                Else
                                    linea3 = Espacio07
                                End If

                                linea = linea1 & linea2 & linea3
                                prn.WriteLine(linea)
                                'prn.SetFontBold(True)
                            End If
                            'FIN ********* TRANSPOSICIÓN ************

                            'material
                            prn.Write("Material:" & Espacio06)
                            'prn.SetFontBold(False)
                            If .MaterialOjoCercaDerecho IsNot Nothing Then
                                linea = Left(.MaterialOjoCercaDerecho.Descripcion, 18)
                            Else
                                linea = ""
                            End If
                            prn.WriteLine(linea)
                            'prn.SetFontBold(True)
                            'Cristal
                            prn.Write("Cristal:" & Espacio07)
                            'prn.SetFontBold(False)
                            If .CristalOjoCercaDerecho IsNot Nothing Then
                                linea = Left(.CristalOjoCercaDerecho.Descripcion, 30)
                            Else
                                linea = ""
                            End If
                            prn.WriteLine(linea)
                            'Cantidad de unidades CercaDerecho
                            prn.WriteLine(String.Format("Unidad(es):{0}", .CantidadOjoCercaDerecho))
                            prn.WriteLine(separador)
                            'prn.SetFontBold(True)
                        End If
                        'Ojo Izquierdo
                        If .CristalIdCercaIzquierdo > 0 Then
                            'prn.SetFontBold(True)
                            prn.WriteLine(String.Format("Izquierdo"))
                            'prn.SetFontBold(False)
                            prn.WriteLine(separador)
                            'Eje, Cil, Esf, Dst, Alt,Pri
                            'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(2))
                            'prn.SetFontBold(True)
                            prn.WriteLine("    Eje" & "    Cil" & "    Esf" & "    Dst" & "    Alt")
                            'prn.SetFontBold(False)
                            'Eje
                            If .Fields(DV_RecetaComunFieldIndex.EjeOjoCercaIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea1 = Right(String.Format("{0,8}", .EjeOjoCercaIzquierdo.ToString()), 8)
                            Else
                                linea1 = Espacio07
                            End If
                            'Cil
                            If .Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea2 = Right(String.Format("{0,7}", .CilindricoOjoCercaIzquierdo.ToString("\+0.00;\-0.00;0")), 7)
                            Else
                                linea2 = Espacio07
                            End If
                            'Esf
                            If .Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea3 = Right(String.Format("{0,7}", .EsfericoOjoCercaIzquierdo.ToString("\+0.00;\-0.00;0")), 7)
                            Else
                                linea3 = Espacio07
                            End If
                            'Dst
                            If .Fields(DV_RecetaComunFieldIndex.DistanciaOjoCercaIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea5 = Right(String.Format("{0,7}", .DistanciaOjoCercaIzquierdo.ToString()), 7)
                            Else
                                linea5 = Espacio07
                            End If
                            'Alt
                            If .Fields(DV_RecetaComunFieldIndex.AlturaOjoCercaIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea6 = Right(String.Format("{0,7}", .AlturaOjoCercaIzquierdo.ToString()), 7)
                            Else
                                linea6 = Espacio07
                            End If
                            'Imprimo resultados
                            linea = linea1 & linea2 & linea3 & linea5 & linea6
                            prn.WriteLine(linea)
                            'prn.SetFontBold(True)
                            'Pri y grado
                            prn.WriteLine("    Pri" & "    Gr.")
                            If .Fields(DV_RecetaComunFieldIndex.PrismaOjoCercaIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea1 = Right(String.Format("{0,7}", .PrismaOjoCercaIzquierdo.ToString()), 7)
                            Else
                                linea1 = Espacio07
                            End If
                            If .Fields(DV_RecetaComunFieldIndex.PrismaGraduacionOjoCercaIzquierdo.ToString()).CurrentValue IsNot Nothing Then
                                linea2 = Right(String.Format("{0,7}", .PrismaGraduacionOjoCercaIzquierdo.ToString()), 7)
                            Else
                                linea2 = Espacio07
                            End If
                            'Imprimo resultados Pri y grado
                            'prn.SetFontBold(False)
                            linea = linea1 & linea2
                            prn.WriteLine(linea)
                            'prn.Write(Chr(&H1B) & Chr(&H21) & Chr(1))
                            'prn.SetFontBold(True)

                            'Imprimo los valores calculados ********* TRANSPOSICIÓN ************

                            'Cambiamos el tipo de letra
                            If .CilindricoOjoCercaIzquierdo <> .CilindricoOjoCercaIzquierdoCalc Then
                                prn.WriteLine("(TRANSP) Eje" & "    Cil" & "    Esf")
                                'prn.SetFontBold(False)
                                'Eje
                                If .Fields(DV_RecetaComunFieldIndex.EjeOjoCercaIzquierdoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea1 = Left(String.Format("{0,13}", .EjeOjoCercaIzquierdoCalc.ToString()), 13)
                                Else
                                    linea1 = Espacio07
                                End If
                                'Cil
                                If .Fields(DV_RecetaComunFieldIndex.CilindricoOjoCercaIzquierdoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea2 = Right(String.Format("{0,7}", .CilindricoOjoCercaIzquierdoCalc.ToString("\+0.00;\-0.00;0")), 7)
                                Else
                                    linea2 = Espacio07
                                End If
                                'Esf
                                If .Fields(DV_RecetaComunFieldIndex.EsfericoOjoCercaIzquierdoCalc.ToString()).CurrentValue IsNot Nothing Then
                                    linea3 = Right(String.Format("{0,7}", .EsfericoOjoCercaIzquierdoCalc.ToString("\+0.00;\-0.00;0")), 7)
                                Else
                                    linea3 = Espacio07
                                End If
                                linea = linea1 & linea2 & linea3
                                prn.WriteLine(linea)
                                'prn.SetFontBold(True)
                            End If

                            'FIN ********* TRANSPOSICIÓN ************


                            'material
                            prn.Write("Material:" & Espacio06)
                            'prn.SetFontBold(False)
                            If .MaterialOjoCercaIzquierdo IsNot Nothing Then
                                linea = Left(.MaterialOjoCercaIzquierdo.Descripcion, 18)
                            Else
                                linea = ""
                            End If
                            prn.WriteLine(linea)
                            'prn.SetFontBold(True)
                            'Cristal
                            prn.Write("Cristal:" & Espacio07)
                            'prn.SetFontBold(False)
                            If .CristalOjoCercaIzquierdo IsNot Nothing Then
                                linea = Left(.CristalOjoCercaIzquierdo.Descripcion, 30)
                            Else
                                linea = ""
                            End If
                            prn.WriteLine(linea)
                            'Cantidad Unidades CercaIzquierdo
                            prn.WriteLine(String.Format("Unidad(es):{0}", .CantidadOjoCercaIzquierdo))
                            prn.WriteLine(separador)
                        End If
                        'Armazon
                        'prn.SetFontBold(True)
                        prn.Write("Armazon:" & Espacio07)
                        'prn.SetFontBold(False)
                        If .ArmazonCerca IsNot Nothing Then
                            linea = String.Format("{0}", .ArmazonCerca.Descripcion)
                            linea1 = String.Format("Unidad(es):{0}", .CantidadArmazonCerca)
                        Else
                            linea = ""
                            linea1 = ""
                        End If
                        prn.WriteLine(linea)
                        prn.WriteLine(linea1)
                        'prn.SetFontBold(True)
                        'Servicios
                        prn.WriteLine("Servicios:")
                        'prn.SetFontBold(False)
                        For Each servicio As DocSalidaDetalleEntity In .ServiciosCerca
                            prn.WriteLine(Espacio15 & servicio.Descripcion)
                        Next
                        prn.WriteLine(separador)
                    End If
                    'Observaciones
                    If Not String.IsNullOrEmpty(.Observaciones) Then
                        'prn.SetFontBold(True)
                        prn.WriteLine("Observaciones:")
                        'prn.SetFontBold(False)
                        Dim obs As String() = Studio.Net.Helper.WordWrap.WrapAsArray(.Observaciones, C_INT_ANCHO)
                        For Each obsLinea As String In obs
                            prn.WriteLine(obsLinea)
                        Next
                    End If

                    prn.WriteLine(" ")
                    prn.WriteLine(" ")
                    prn.WriteLine(" ")

                    linea = "Nro. orden: " & .NumeroDocumento

                    prn.WriteLine(linea)
                    prn.WriteLine(" ")

                    CutPaper(prn, True)
                    prn.EndPage()
                    prn.EndDocument()

                Catch ex As Exception
                    MyMsgBox.Show(ex.Message, MsgBoxStyle.Critical)
                Finally
                    prn.ClosePrinter()
                End Try

            End With

        End Using
    End Sub

    Protected Overridable Sub CutPaper(prn As Studio.Net.Printing.ITicketPrinter, partialCut As Boolean)

        prn.CutPaper(partialCut)

    End Sub




End Class
