Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL
Imports Studio.Phone.BLL

Friend Class DatabaseUpdate

    Private Const C_VERSION_KEY As String = "Database-Version"

    Public Shared Sub Update()

        Using da As IDataAccessAdapter = Studio.Net.Helper.DAL.DataAccessAdapter.Create(True)
            Try
                da.StartTransaction(IsolationLevel.ReadCommitted, "trn")



                Dim parametro As ParametroUsuarioEntity = ParametroUsuarioController.BuscarPorClave(da, C_VERSION_KEY)
                Dim version As Version

                If parametro Is Nothing Then
                    version = New Version("0.0.0")
                    ExecuteAllways(da)
                Else
                    version = Version.Parse(parametro.Data)
                End If
                If version < New Version("1.0.0") Then
                    Update_1_0_0(da)
                End If
                If version < New Version("4.0.0") Then
                    Update_4_0_0(da)
                End If
                If version < New Version("4.0.1") Then
                    Update_4_0_1(da)
                End If
                If version < New Version("4.0.2") Then
                    Update_4_0_2(da)
                End If
                If version < New Version("4.0.3") Then
                    Update_4_0_3(da)
                End If
                If version < New Version("4.0.4") Then
                    Update_4_0_4(da)
                End If
                If version < New Version("4.0.5") Then
                    Update_4_0_5(da)
                End If
                If version < New Version("4.0.6") Then
                    Update_4_0_6(da)
                End If
                If version < New Version("4.0.7") Then
                    Update_4_0_7(da)
                End If
                If version < New Version("4.0.8") Then
                    Update_4_0_8(da)
                End If

                'ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "4.0.6")

                'Proxima version
                'If version < New Version("1.0.2") Then
                '    Update_1_0_2(da)
                'End If

                da.Commit()

            Catch
                If da.IsTransactionInProgress Then
                    da.Rollback()
                End If
                Throw
            End Try

        End Using

    End Sub

#Region "Updates per version"



#Region "All versions"

    Private Shared Sub ExecuteAllways(da As StudioDataAdapter)

        'Actualizar las empresas que tengan las
        Dim Sql As String = "UPDATE documentosalida SET empid=l.empid FROM documentosalida d INNER JOIN caja c ON d.cajid=c.cajid INNER JOIN local l ON c.LocId=l.locid WHERE d.EmpId IS null"
        Using command As New SqlClient.SqlCommand(Sql, da.GetCurrentConnection(), da.GetPhysicalTransaction())
            command.ExecuteNonQuery()
        End Using

        EntidadBEntity.VerificarRegistros(da)

    End Sub

#End Region

#Region "1.0.0"

    Private Shared Sub Update_1_0_0(da As StudioDataAdapter)

        'Using con As New SqlClient.SqlConnection(da.ConnectionString)

        'con.Open()
        Dim con As IDbConnection = da.GetCurrentConnection()
        Dim sql As String
        '                    Dim nulos As Integer = da.GetScalar(Articulo_Local_ProveedorFields.Id, Nothing, AggregateFunction.Count, Articulo_Local_ProveedorFields.ImporteTotal = DBNull.Value And New FieldCompareSetPredicate(Articulo_Local_ProveedorFields.ArticuloId, Nothing, ArticuloFields.Id, Nothing, SetOperator.In, ArticuloFields.ArticuloIdGuia = DBNull.Value))
        Dim nulos As Integer = da.GetScalar(Articulo_Local_ProveedorFields.Id, Nothing, AggregateFunction.Count, Articulo_Local_ProveedorFields.ImporteTotal = DBNull.Value And New FieldCompareSetPredicate(Articulo_Local_ProveedorFields.ArticuloId, Nothing, ArticuloFields.Id, Nothing, SetOperator.In, ArticuloFields.ArticuloIdGuia = DBNull.Value))
        If nulos > 0I Then
            sql = "update Articulo_Local_Proveedor SET ArtLocProvTaxInc=0 " &
                "WHERE ArtLocProvTaxInc Is null"

            Using command As New SqlClient.SqlCommand(sql, con, da.GetPhysicalTransaction())
                command.ExecuteNonQuery()
            End Using

            sql = "Update Articulo_Local_Proveedor" &
                    " Set ArtLocProvImpNto=coalesce(" &
                    " Case When ArtLocProvTaxInc = 1 then artlocprovimpfin / (1 + ((select sum(taxpct) from articulo_impuesto a inner join impuesto i on a.taxid = i.taxid where a.artid=alp.artid) /100)) " &
                    " When ArtLocProvTaxInc = 0 then artlocprovimpfin END, 0), " &
                    " ArtLocProvImpTot=coalesce(" &
                    " Case When ArtLocProvTaxInc = 0 then artlocprovimpfin * (1 + ((select sum(taxpct) from articulo_impuesto a inner join impuesto i on a.taxid = i.taxid where a.artid=alp.artid) /100)) " &
                    " When ArtLocProvTaxInc = 1 then artlocprovimpfin END, 0)" &
                    " FROM articulo_local_proveedor alp where ArtLocProvImpTot is null"

            Using command As New SqlClient.SqlCommand(sql, con, da.GetPhysicalTransaction())
                command.ExecuteNonQuery()
            End Using

        End If
        nulos = da.GetScalar(DocEntradaDetalleFields.Id, Nothing, AggregateFunction.Count, DocEntradaDetalleFields.ImporteTotal = DBNull.Value)

        If nulos > 0I Then

            sql = "update DocumentoEntrada SET DocEntSinImpuestos=0 " &
            "WHERE DocEntSinImpuestos Is null"

            Using command As New SqlClient.SqlCommand(sql, con, da.GetPhysicalTransaction())
                command.ExecuteNonQuery()
            End Using

            sql = "UPDATE docentradadetalle " &
                    "SET docentdetimpnto=coalesce(" &
                    "CASE WHEN DocEntSinImpuestos=0 THEN DocEntDetImp " &
                    "ELSE DocEntDetImp-DocEntDetTotTax END, 0), " &
                    "docentdetimptot=coalesce(" &
                    "CASE WHEN DocEntSinImpuestos=0 THEN DocEntDetImp " &
                    "ELSE DocEntDetImp+DocEntDetTotTax END, 0) " &
                    "FROM dbo.DocEntradaDetalle dd INNER JOIN dbo.DocumentoEntrada d ON dd.DocEntId=dd.DocEntId " &
                    "WHERE docentdetimpnto IS null"

            Using command As New SqlClient.SqlCommand(sql, con, da.GetPhysicalTransaction())
                command.ExecuteNonQuery()
            End Using



        End If
        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "1.0.0")
        'End Using

    End Sub
#End Region

#Region "1.0.1"

    Private Shared Sub Update_1_0_1(da As StudioDataAdapter)

        'da.DeleteEntitiesDirectly(GetType(TablaSistema_OrdenDistEntity).Name, Nothing)
        'da.DeleteEntitiesDirectly(GetType(TablaSistemaEntity).Name, Nothing)

        Dim sql As String = "delete from TablaSistema_OrdenDist;" &
                            "delete from TablaSistema;"

        Using command As New SqlClient.SqlCommand(sql, da.GetCurrentConnection(), da.GetPhysicalTransaction())
            command.ExecuteNonQuery()
        End Using

        sql =
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (1, CONVERT(TEXT, N'Articulo'), CONVERT(TEXT, N'Artículos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (2, CONVERT(TEXT, N'Articulo_Codigo'), CONVERT(TEXT, N'Articulos - Codigo de Barras'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (3, CONVERT(TEXT, N'Articulo_Composicion'), CONVERT(TEXT, N'Articulos - Recetas'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (4, CONVERT(TEXT, N'Articulo_Impuesto'), CONVERT(TEXT, N'Articulos - Impuestos'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (5, CONVERT(TEXT, N'Articulo_Local'), CONVERT(TEXT, N'Articulos - Locales'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (6, CONVERT(TEXT, N'Articulo_Local_Asociado'), CONVERT(TEXT, N'Articulos  Asociados - Locales'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (7, CONVERT(TEXT, N'Articulo_Local_Proveedor'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (9, CONVERT(TEXT, N'Articulo_Paquete'), CONVERT(TEXT, N'Articulos - Combos'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (10, CONVERT(TEXT, N'Articulo_Proveedor'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (11, CONVERT(TEXT, N'Articulo_Serie'), CONVERT(TEXT, N'Articulos - Nros. de Serie'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (12, CONVERT(TEXT, N'Articulo_SerieVta'), CONVERT(TEXT, N'Articulos - Nros. de Serie a la Venta'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (13, CONVERT(TEXT, N'Articulo_SerieVta_Deposito'), CONVERT(TEXT, N'Articulos - Nros. de Serie - Depositos'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (14, CONVERT(TEXT, N'ArticuloCategoria'), CONVERT(TEXT, N'Artículos - Categorías'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (15, CONVERT(TEXT, N'ArticuloClase'), CONVERT(TEXT, N'Artículos - Clases'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (16, CONVERT(TEXT, N'Articulo_Serie_Historia'), CONVERT(TEXT, N'Articulos - Serie - Historia'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (17, CONVERT(TEXT, N'Articulo_SerieEstado'), CONVERT(TEXT, N'Articulos - Estado de Series'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (18, CONVERT(TEXT, N'ArticuloTipo'), CONVERT(TEXT, N'Artículos - Tipos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (19, CONVERT(TEXT, N'Bonificacion'), CONVERT(TEXT, N'Bonificaciones'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (20, CONVERT(TEXT, N'Caja'), CONVERT(TEXT, N'Cajas'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (21, CONVERT(TEXT, N'CajaTipo'), CONVERT(TEXT, N'Cajas - Tipos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (22, CONVERT(TEXT, N'Cargo'), CONVERT(TEXT, N'Cargos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (23, CONVERT(TEXT, N'Ciudad'), CONVERT(TEXT, N'Ciudades'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (24, CONVERT(TEXT, N'Cliente'), CONVERT(TEXT, N'Clientes'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (25, CONVERT(TEXT, N'Cliente_Convenio'), CONVERT(TEXT, N'Clientes - Convenios'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (26, CONVERT(TEXT, N'Cliente_EntidadFinanciera'), CONVERT(TEXT, N'Clientes - Entidades Financieras'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (27, CONVERT(TEXT, N'Cliente_FormaPago'), CONVERT(TEXT, N'Clientes - Formas de Pago'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (30, CONVERT(TEXT, N'ClienteTipo'), CONVERT(TEXT, N'Clientes - Tipos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (37, CONVERT(TEXT, N'ConvCliCtaCte'), CONVERT(TEXT, N'Clientes - Convenios Cuenta Corriente'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (38, CONVERT(TEXT, N'Convenio'), CONVERT(TEXT, N'Convenios'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (39, CONVERT(TEXT, N'Convenio_Local'), CONVERT(TEXT, N'Convenios - Locales'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (40, CONVERT(TEXT, N'ConvenioCtaCte'), CONVERT(TEXT, N'Convenios Cuenta Corrientes'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (41, CONVERT(TEXT, N'ConvenioEstado'), CONVERT(TEXT, N'Convenios - Estados'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (42, CONVERT(TEXT, N'Cotizacion'), CONVERT(TEXT, N'Cotizaciones'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (43, CONVERT(TEXT, N'CotizacionTipo'), CONVERT(TEXT, N'Cotizaciones - Tipos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (44, CONVERT(TEXT, N'Deposito'), CONVERT(TEXT, N'Depósitos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (45, CONVERT(TEXT, N'Deposito_Articulo'), CONVERT(TEXT, N'Arículos en depósito'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (46, CONVERT(TEXT, N'DepositoTipo'), CONVERT(TEXT, N'Depósitos - Tipos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (47, CONVERT(TEXT, N'DiasPlazo'), CONVERT(TEXT, N'Convenios - Plazos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (48, CONVERT(TEXT, N'Distribuidor'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (49, CONVERT(TEXT, N'Distribuidor_Representante'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (50, CONVERT(TEXT, N'Documento_Vias'), CONVERT(TEXT, N'Documentos - Vias'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (51, CONVERT(TEXT, N'DocumentoTipo'), CONVERT(TEXT, N'Documentos - Tipos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (52, CONVERT(TEXT, N'dtproperties'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (53, CONVERT(TEXT, N'Empresa'), CONVERT(TEXT, N'Empresas'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (54, CONVERT(TEXT, N'EntidadFinanciera'), CONVERT(TEXT, N'Entidades Financieras'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (55, CONVERT(TEXT, N'FormaPago'), CONVERT(TEXT, N'Formas de Pago'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (56, CONVERT(TEXT, N'Funcionario'), CONVERT(TEXT, N'Funcionarios'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (57, CONVERT(TEXT, N'Funcionario_Empresa'), CONVERT(TEXT, N'Funcionarios - Empresas'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (58, CONVERT(TEXT, N'Funcionario_Local'), CONVERT(TEXT, N'Funcionarios - Locales'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (59, CONVERT(TEXT, N'Funcionario_Supervisa'), CONVERT(TEXT, N'Funcionarios Supervisores'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (60, CONVERT(TEXT, N'Impuesto'), CONVERT(TEXT, N'Impuestos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (61, CONVERT(TEXT, N'ImpuestoTipo'), CONVERT(TEXT, N'Impuestos - Tipos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (62, CONVERT(TEXT, N'Inconsistencia'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (63, CONVERT(TEXT, N'Institucion'), CONVERT(TEXT, N'Instituciones'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (64, CONVERT(TEXT, N'ListaPreVta'), CONVERT(TEXT, N'Listas de Precios'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (65, CONVERT(TEXT, N'ListaPreVtaLin'), CONVERT(TEXT, N'Listas de Precios '), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (66, CONVERT(TEXT, N'ListaPreVtaTipo'), CONVERT(TEXT, N'Listas de Precios - Tipos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (67, CONVERT(TEXT, N'Local'), CONVERT(TEXT, N'Locales'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (68, CONVERT(TEXT, N'Local_Bonificacion'), CONVERT(TEXT, N'Locales - Bonificaciones'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (69, CONVERT(TEXT, N'Local_FormaPago'), CONVERT(TEXT, N'Locales - Formas de Pago'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (70, CONVERT(TEXT, N'Local_Impuesto'), CONVERT(TEXT, N'Locales - Impuestos'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (71, CONVERT(TEXT, N'Local_ListaPreVta'), CONVERT(TEXT, N'Locales - Listas de Precio '), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (72, CONVERT(TEXT, N'Local_Proveedor'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (73, CONVERT(TEXT, N'Localidad'), CONVERT(TEXT, N'Localidades'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (74, CONVERT(TEXT, N'Marca'), CONVERT(TEXT, N'Marcas'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (75, CONVERT(TEXT, N'Marca_Modelo'), CONVERT(TEXT, N'Marcas -  Modelos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (76, CONVERT(TEXT, N'Modelo'), CONVERT(TEXT, N'Modelos'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (77, CONVERT(TEXT, N'Moneda'), CONVERT(TEXT, N'Monedas'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (78, CONVERT(TEXT, N'NegocioTipo'), CONVERT(TEXT, N'Negocios - Tipos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (79, CONVERT(TEXT, N'Nivel'), CONVERT(TEXT, N'Articulos - Niveles'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (80, CONVERT(TEXT, N'PagoDocumentoSalida'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (81, CONVERT(TEXT, N'Pais'), CONVERT(TEXT, N'Países'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (82, CONVERT(TEXT, N'ParametroSistema'), CONVERT(TEXT, N'Parámetros del Sistema'), 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (83, CONVERT(TEXT, N'ParametroSistemaTipo'), CONVERT(TEXT, N'Parametros del Sistema - Tipos'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (84, CONVERT(TEXT, N'PlanFinanciero'), CONVERT(TEXT, N'Planes Financieros'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (85, CONVERT(TEXT, N'Procedencia'), CONVERT(TEXT, N'Procedencias'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (86, CONVERT(TEXT, N'Proveedor'), CONVERT(TEXT, N'Proveedores'), 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (87, CONVERT(TEXT, N'Proveedor_Impuesto'), CONVERT(TEXT, N'Proveedores - Impuestos'), 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (88, CONVERT(TEXT, N'Proveedor_ProveedorTipo'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (89, CONVERT(TEXT, N'ProveedorClase'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (90, CONVERT(TEXT, N'ProveedorLinea'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (91, CONVERT(TEXT, N'ProveedorTipo'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (92, CONVERT(TEXT, N'Reparacion'), CONVERT(TEXT, N'Reparaciones'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (93, CONVERT(TEXT, N'Reparacion_Articulo'), CONVERT(TEXT, N'Reparaciones - Artículos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (94, CONVERT(TEXT, N'Reparacion_ReparacionEstado'), CONVERT(TEXT, N'Estado de las Reparaciones'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (95, CONVERT(TEXT, N'ReparacionEstado'), CONVERT(TEXT, N'Reparaciones - Estados'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (96, CONVERT(TEXT, N'Representante'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (97, CONVERT(TEXT, N'Rubro'), CONVERT(TEXT, N'Rubros'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (98, CONVERT(TEXT, N'Rubro_Impuesto'), CONVERT(TEXT, N'Rubros - Impuestos'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (99, CONVERT(TEXT, N'Sexo'), CONVERT(TEXT, N'Sexos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (100, CONVERT(TEXT, N'Signo'), CONVERT(TEXT, N'Signos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (102, CONVERT(TEXT, N'TablaSistema'), NULL, 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (103, CONVERT(TEXT, N'TareaPorDistribuir'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (104, CONVERT(TEXT, N'DocumentoSalida'), CONVERT(TEXT, N'Ventas'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (105, CONVERT(TEXT, N'DocSalida_Comision'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (106, CONVERT(TEXT, N'DocSalida_PagoDocSalida'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (107, CONVERT(TEXT, N'DocSalida_PagoDocSalida_Cambio'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (108, CONVERT(TEXT, N'DocSalida_Vencimiento'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (109, CONVERT(TEXT, N'DocSalidaDetalle'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (110, CONVERT(TEXT, N'DocSalidaDetalle_Impuesto'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (111, CONVERT(TEXT, N'Articulo_Local_Proveedor_Bonficacion'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (112, CONVERT(TEXT, N'Caja_DocumentoTipo'), CONVERT(TEXT, N'Tipos de Documentos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (113, CONVERT(TEXT, N'CajaMovHst'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (114, CONVERT(TEXT, N'CajaMovHst_Atributo'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (115, CONVERT(TEXT, N'CajaMovHst_Detalle'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (116, CONVERT(TEXT, N'CajaMovHst_Detalle_Efectivo'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (117, CONVERT(TEXT, N'CajaMovTipo'), CONVERT(TEXT, N'Cajas - Tipos de Movimientos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (118, CONVERT(TEXT, N'DatoTipo'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (119, CONVERT(TEXT, N'FormaPago_Atributo'), CONVERT(TEXT, N'Atributos de las formas de pago'), 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (120, CONVERT(TEXT, N'Moneda_ValorFacial'), CONVERT(TEXT, N'Monedas - Valores Faciales'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (121, CONVERT(TEXT, N'TablaSistema_OrdenDist'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (122, CONVERT(TEXT, N'TareaPendiente'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (123, CONVERT(TEXT, N'Traspaso'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (124, CONVERT(TEXT, N'TraspasoDetalle'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (125, CONVERT(TEXT, N'TraspasoDetalle_Serie'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (126, CONVERT(TEXT, N'Usuario'), CONVERT(TEXT, N'Usuarios - Permisos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (127, CONVERT(TEXT, N'DocSalida_PagoDocSalida_Atributo'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (128, CONVERT(TEXT, N'Reparto'), CONVERT(TEXT, N'Repartos'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (129, CONVERT(TEXT, N'Ruta'), CONVERT(TEXT, N'Rutas'), 1, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (130, CONVERT(TEXT, N'Articulo_Local_Proveedor_Impuesto'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (132, CONVERT(TEXT, N'DocSalidaDetalle_Serie'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (133, CONVERT(TEXT, N'Impuesto_Precedencia'), NULL, 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (134, CONVERT(TEXT, N'DocSalidaDetalle_Comision'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (135, CONVERT(TEXT, N'TareaPendienteError'), NULL, 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (138, CONVERT(TEXT, N'Grupo'), CONVERT(TEXT, N'Grupo'), 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (139, CONVERT(TEXT, N'Grupo_Permiso'), CONVERT(TEXT, N'Grupo_Permiso'), 0, 1, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (140, CONVERT(TEXT, N'Cliente_Local'), NULL, 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (141, CONVERT(TEXT, N'Operador'), CONVERT(TEXT, N'Operador'), 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (142, CONVERT(TEXT, N'DocumentoTipo_ArticuloClase'), NULL, 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (143, CONVERT(TEXT, N'Version'), NULL, 1, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (145, CONVERT(TEXT, N'ModoReposicion'), CONVERT(TEXT, N'Modo de reposición'), 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (146, CONVERT(TEXT, N'FormaPago_Estado'), CONVERT(TEXT, N'Estados de formas de pago'), 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (147, CONVERT(TEXT, N'PagoDocSalida_Detalle'), NULL, 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (148, CONVERT(TEXT, N'PagoDocSalida_Detalle_Atributo'), NULL, 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (149, CONVERT(TEXT, N'BonificacionAplicada'), NULL, 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (150, CONVERT(TEXT, N'ClienteCategoria'), CONVERT(TEXT, N'Categoria de cliente'), 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (151, CONVERT(TEXT, N'Caja_PlanFinanciero'), NULL, 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (152, CONVERT(TEXT, N'Imagen'), NULL, 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (153, CONVERT(TEXT, N'Articulo_Imagen'), NULL, 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (156, CONVERT(TEXT, N'PtkOperacion'), CONVERT(TEXT, N'Operaciones'), 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema] ([TblSysId], [TblSysNom], [TblSysDsc], [TblSysAutDist], [TblSysVisDist], [TblSysChkDist]) VALUES (157, CONVERT(TEXT, N'PtkOperacion_Grupo'), NULL, 0, 0, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 14, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 15, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 17, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 18, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 44, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 60, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 67, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 74, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 76, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 79, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 85, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (1, 97, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (2, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (3, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (4, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (5, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (5, 77, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (6, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (9, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (11, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (12, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (13, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (16, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (20, 21, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (20, 24, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (20, 51, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (20, 64, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (20, 67, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (20, 77, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (20, 117, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (23, 73, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (24, 23, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (24, 30, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (24, 54, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (24, 77, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (25, 24, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (25, 38, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (26, 24, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (27, 24, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (37, 24, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (38, 19, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (38, 24, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (38, 41, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (38, 63, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (38, 64, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (38, 77, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (39, 38, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (39, 67, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (40, 39, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (42, 43, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (42, 77, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (44, 23, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (44, 46, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (44, 67, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (45, 1, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (45, 44, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (45, 145, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (50, 51, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (51, 100, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (53, 23, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (53, 24, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (53, 78, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (54, 55, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (56, 22, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (56, 23, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (56, 24, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (56, 67, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (56, 99, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (57, 56, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (58, 56, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (59, 56, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (60, 61, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (63, 23, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (64, 66, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (64, 142, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (64, 149, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (65, 1, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (65, 64, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (65, 66, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (65, 67, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (65, 77, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (67, 19, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (67, 23, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (67, 53, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (67, 55, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (67, 60, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (68, 67, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (70, 67, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (71, 64, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (71, 67, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (73, 81, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (75, 74, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (75, 76, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (80, 104, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (82, 67, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (82, 83, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (84, 1, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (84, 47, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (84, 54, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (92, 11, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (92, 24, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (92, 44, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (92, 67, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (92, 95, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (93, 1, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (93, 92, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (94, 92, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (97, 60, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (97, 100, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (98, 97, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (104, 126, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (106, 80, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (106, 84, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (106, 109, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (106, 113, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (108, 104, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (109, 104, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (110, 109, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (112, 20, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (112, 51, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (113, 104, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (115, 113, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (116, 115, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (119, 55, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (119, 118, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (120, 77, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (126, 56, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (126, 58, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (127, 106, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (131, 60, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (132, 109, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (133, 60, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (138, 58, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (139, 157, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (140, 24, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (140, 67, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (141, 15, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (141, 51, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (143, 126, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (146, 55, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (147, 80, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (148, 147, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (150, 24, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (151, 84, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (152, 1, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (153, 152, 0)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (126, 157, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (157, 138, 1)	;" &
            "	INSERT INTO [TablaSistema_OrdenDist] ([TblSysHjoId], [TblSysPdrId], [TblSysPriId]) VALUES (157, 156, 1)	;"

        Dim cantidad As Integer = da.GetScalar(TablaSistemaFields.Id, AggregateFunction.Count)

        Using command As New SqlClient.SqlCommand(sql, da.GetCurrentConnection(), da.GetPhysicalTransaction())
            command.ExecuteNonQuery()
        End Using

        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "1.0.1")

    End Sub

#End Region

#Region "4.0.0"

    Private Shared Sub Update_4_0_0(da As IDataAccessAdapter)

        AgregarTipoComprobanteFE(da, 101, "e-Ticket", String.Format("DocumentoTipoId In (1,2) AND IngresoManual = False AND (Ruc Is Null Or ClienteDocumentoTipoId <> {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)), False)
        AgregarTipoComprobanteFE(da, 102, "Nota credito e-Ticket", String.Format("DocumentoTipoId In (3,4) AND IngresoManual = False AND (Ruc Is Null Or ClienteDocumentoTipoId <> {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)), False)
        AgregarTipoComprobanteFE(da, 111, "e-Factura", String.Format("DocumentoTipoId In (1,2) AND IngresoManual = False AND (Ruc Is Not Null AND ClienteDocumentoTipoId = {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)), False)
        AgregarTipoComprobanteFE(da, 112, "Nota credito e-Factura", String.Format("DocumentoTipoId In (3,4) AND IngresoManual = False AND (Ruc Is Not Null AND ClienteDocumentoTipoId = {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)), False)

        'AgregarTipoComprobanteFE(da, 131, "e-Ticket cuenta ajena", String.Format("DocumentoTipoId In (1,2) AND IngresoManual = False AND (Ruc Is Null Or ClienteDocumentoTipoId <> {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)))
        'AgregarTipoComprobanteFE(da, 132, "Nota credito e-Ticket cuenta ajena", String.Format("DocumentoTipoId In (3,4) AND IngresoManual = False AND (Ruc Is Null Or ClienteDocumentoTipoId <> {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)))
        'AgregarTipoComprobanteFE(da, 141, "e-Factura cuenta ajena", String.Format("DocumentoTipoId In (1,2) AND IngresoManual = False AND (Ruc Is Not Null Or ClienteDocumentoTipoId = {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)))
        'AgregarTipoComprobanteFE(da, 142, "Nota credito e-Factura cuenta ajena", String.Format("DocumentoTipoId In (3,4) AND IngresoManual = False AND (Ruc Is Not Null Or ClienteDocumentoTipoId = {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)))

        AgregarTipoComprobanteFE(da, 201, "e-Ticket Contingencia", String.Format("DocumentoTipoId In (1,2) AND IngresoManual = True AND (Ruc Is Null Or ClienteDocumentoTipoId <> {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)), True)
        AgregarTipoComprobanteFE(da, 202, "Nota credito e-Ticket Contingencia", String.Format("DocumentoTipoId In (3,4) AND IngresoManual = True AND (Ruc Is Null Or ClienteDocumentoTipoId <> {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)), True)
        AgregarTipoComprobanteFE(da, 211, "e-Factura Contingencia", String.Format("DocumentoTipoId In (1,2) AND IngresoManual = True AND (Ruc Is Not Null AND ClienteDocumentoTipoId = {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)), True)
        AgregarTipoComprobanteFE(da, 212, "Nota credito e-Factura Contingencia", String.Format("DocumentoTipoId In (3,4) AND IngresoManual = True AND (Ruc Is Not Null AND ClienteDocumentoTipoId = {0})", CInt(Drako.FE.Common.TipoDocumentoReceptor.RUT)), True)

        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "4.0.0")

    End Sub

    Private Shared Sub AgregarTipoComprobanteFE(da As IDataAccessAdapter, codigo As Integer, descripcion As String, condicion As String, contingencia As Boolean)

        Dim tipo As New FE_ComprobanteTipoEntity(codigo)
        da.FetchEntity(tipo)
        tipo.Descripcion = descripcion
        tipo.Condicion = condicion
        tipo.Contingencia = contingencia
        da.SaveEntity(tipo)

    End Sub

#End Region

#Region "4.0.1"

    Private Shared Sub Update_4_0_1(da As IDataAccessAdapter)

        Update_4_0_0(da)
        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "4.0.1")

    End Sub

#End Region

#Region "4.0.2"

    Private Shared Sub Update_4_0_2(da As IDataAccessAdapter)

        Update_4_0_0(da)
        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "4.0.2")

    End Sub

#End Region

#Region "4.0.3"

    Private Shared Sub Update_4_0_3(da As IDataAccessAdapter)
        AgregarClienteDocumentoTipo(da, Drako.FE.Common.TipoDocumentoReceptor.RUT, "RUT")
        AgregarClienteDocumentoTipo(da, Drako.FE.Common.TipoDocumentoReceptor.CI, "C.I. Uruguaya")
        AgregarClienteDocumentoTipo(da, Drako.FE.Common.TipoDocumentoReceptor.DNI, "DNI")
        AgregarClienteDocumentoTipo(da, Drako.FE.Common.TipoDocumentoReceptor.Pasaporte, "Pasaporte")
        AgregarClienteDocumentoTipo(da, Drako.FE.Common.TipoDocumentoReceptor.Otros, "Otros")

        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "4.0.3")

    End Sub

#End Region

#Region "4.0.4"

    Private Shared Sub Update_4_0_4(da As IDataAccessAdapter)

        Dim impuestoEy As ImpuestoEntity
        Using col As EntityCollectionNonGeneric = (New ImpuestoBEntity).GetData(da, Nothing)
            For Each impuestoEy In col
                Select Case impuestoEy.Id
                    Case Impuesto.IVAExcento
                        impuestoEy.IndicadorFacturacion = 1
                    Case Impuesto.IVAMinimo
                        impuestoEy.IndicadorFacturacion = 2
                    Case Impuesto.IVABasico
                        impuestoEy.IndicadorFacturacion = 3
                    Case Impuesto.Otros, Impuesto.Cofis
                        impuestoEy.IndicadorFacturacion = 4
                End Select
            Next
            da.SaveEntityCollection(col)

        End Using
        impuestoEy = ImpuestoController.BuscarPorIndicadorFacturacion(da, Impuesto.ItemaAnularResguardos)
        If impuestoEy Is Nothing Then
            impuestoEy = New ImpuestoEntity
            impuestoEy.IndicadorFacturacion = Impuesto.ItemaAnularResguardos
            impuestoEy.Descripcion = "Item anular resguardos"
            impuestoEy.ImpuestoTipoId = ImpuestoTipo.Basico
            impuestoEy.Id = CInt(Impuesto.ItemaAnularResguardos)
            da.SaveEntity(impuestoEy)
        End If


        impuestoEy = ImpuestoController.BuscarPorIndicadorFacturacion(da, Impuesto.ProductoOServicioNoFacturable)
        If impuestoEy Is Nothing Then
            impuestoEy = New ImpuestoEntity
            impuestoEy.IndicadorFacturacion = Impuesto.ProductoOServicioNoFacturable
            impuestoEy.Descripcion = "Producto o servicio no facturable"
            impuestoEy.ImpuestoTipoId = ImpuestoTipo.Basico
            impuestoEy.Id = CInt(Impuesto.ProductoOServicioNoFacturable)

            da.SaveEntity(impuestoEy)
        End If

        impuestoEy = ImpuestoController.BuscarPorIndicadorFacturacion(da, Impuesto.ProductoOServicioNoFacturableNegativo)
        If impuestoEy Is Nothing Then
            impuestoEy = New ImpuestoEntity
            impuestoEy.IndicadorFacturacion = Impuesto.ProductoOServicioNoFacturableNegativo
            impuestoEy.Descripcion = "Producto o servicio no facturable (negativo)"
            impuestoEy.ImpuestoTipoId = ImpuestoTipo.Basico
            impuestoEy.Id = CInt(Impuesto.ProductoOServicioNoFacturableNegativo)
            da.SaveEntity(impuestoEy)
        End If


        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "4.0.4")

    End Sub
#End Region

#Region "4.0.5"

    Private Shared Sub Update_4_0_5(da As StudioDataAdapter)


        'Ponemos en un todos los contandores
        Dim sql As String = "update dv_recetacomun set OLArmCnt=1 where OLArmId is not null;" &
                            "update dv_recetacomun set OCArmCnt=1 where OCArmId is not null;" &
                            "update dv_recetacomun Set OCDCnt=1 where CriIdOCD Is Not null;" &
                            "update dv_recetacomun set OCICnt=1 where CriIdOCI is not null;" &
                            "update dv_recetacomun set OLDCnt=1 where CriIdOLD Is Not null;" &
                            "update dv_recetacomun set OLICnt=1 where CriIdOLI is not null;"

        Using command As New SqlClient.SqlCommand(sql, da.GetCurrentConnection(), da.GetPhysicalTransaction())
            command.ExecuteNonQuery()
        End Using
        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "4.0.5")
    End Sub

#End Region

#Region "4.0.6"

    Private Shared Sub Update_4_0_6(da As IDataAccessAdapter)

        Using col As New EntityCollection(Of PaisEntity)
            da.FetchEntityCollection(col, Nothing)
            For Each pais As PaisEntity In col
                If pais.Descripcion.ToLower().Trim() = "uruguay" Then
                    pais.CodigoISO = Drako.FE.Common.CodPaisType.UY.ToString()
                End If
                If pais.Descripcion.ToLower().Trim() = "argentina" Then
                    pais.CodigoISO = Drako.FE.Common.CodPaisType.AR.ToString()
                End If
                If pais.Descripcion.ToLower().Trim() = "brasil" Then
                    pais.CodigoISO = Drako.FE.Common.CodPaisType.BR.ToString()
                End If
                If pais.Descripcion.ToLower().Trim() = "paraguay" Then
                    pais.CodigoISO = Drako.FE.Common.CodPaisType.PY.ToString()
                End If
                If pais.Descripcion.ToLower().Trim() = "chile" Then
                    pais.CodigoISO = Drako.FE.Common.CodPaisType.CL.ToString()
                End If
            Next

            da.SaveEntityCollection(col)

        End Using

        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "4.0.6")

    End Sub

#End Region

#Region "4.0.7"

    Private Shared Sub Update_4_0_7(da As IDataAccessAdapter)


        Dim impuestoEy As ImpuestoEntity = ImpuestoController.BuscarPorIndicadorFacturacion(da, Impuesto.ExportacionyAsimiladas)
        If impuestoEy Is Nothing Then
            impuestoEy = New ImpuestoEntity
            impuestoEy.IndicadorFacturacion = Impuesto.ExportacionyAsimiladas
            impuestoEy.Descripcion = "Exportación y asimiladas"
            impuestoEy.ImpuestoTipoId = ImpuestoTipo.Basico
            impuestoEy.Id = CInt(Impuesto.ExportacionyAsimiladas)
            da.SaveEntity(impuestoEy)
        End If


        impuestoEy = ImpuestoController.BuscarPorIndicadorFacturacion(da, Impuesto.ImpuestoPercibido)
        If impuestoEy Is Nothing Then
            impuestoEy = New ImpuestoEntity
            impuestoEy.IndicadorFacturacion = Impuesto.ImpuestoPercibido
            impuestoEy.Descripcion = "Impuesto percibido"
            impuestoEy.ImpuestoTipoId = ImpuestoTipo.Basico
            impuestoEy.Id = CInt(Impuesto.ImpuestoPercibido)

            da.SaveEntity(impuestoEy)
        End If

        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "4.0.7")

    End Sub

#End Region

#Region "4.0.8"

    Private Shared Sub Update_4_0_8(da As IDataAccessAdapter)

        Dim convenioestado As ConvenioEstadoEntity = ConvenioEstadoController.BuscarPorId(da, ConvenioEstadoEnum.Activo)
        If convenioestado Is Nothing Then
            convenioestado = New ConvenioEstadoEntity
            convenioestado.Id = ConvenioEstadoEnum.Activo
            convenioestado.AutorizadoVenta = True
            convenioestado.Descripcion = "Activo"
            da.SaveEntity(convenioestado)
        End If


        ParametroUsuarioController.Guardar(da, C_VERSION_KEY, "4.0.8")

    End Sub

#End Region

#End Region

#Region "Procedimientos Privados"

    Private Shared Sub AgregarClienteDocumentoTipo(da As IDataAccessAdapter, id As Integer, descripcion As String)
        Dim cliDocTpo As ClienteDocumentoTipoEntity = ClienteDocumentoTipoBEntity.BuscarPorId(da, id)
        If cliDocTpo Is Nothing Then
            cliDocTpo = New ClienteDocumentoTipoEntity(id)
        End If
        cliDocTpo.Id = id
        cliDocTpo.Descripcion = descripcion
        da.SaveEntity(cliDocTpo, True)

    End Sub

#End Region

End Class
