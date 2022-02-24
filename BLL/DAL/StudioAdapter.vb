Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Net.Helper
Imports System.Data.Common
Imports System.Collections.Generic
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Net.BLL
Imports System.Reflection
Imports System.Text

Public Class StudioDataAdapter
    Inherits Studio.Phone.BLL.StudioDataAdapter

    'Implements IStudioAdapter


    '#Region "Variables de módulo"

    '    Private _auditValues As Boolean = True
    '    'Private _auditingEntites As New ArrayList
    '    Private m_Pasos As Integer

    '    Private Shared m_Triggers As New Dictionary(Of String, IEntityTrigger)
    '    Private Shared m_FlagTrigger As Boolean = False
    '    Private m_EntitiesSavedInTransacction As Dictionary(Of Guid, IEntity2)



    '#End Region

    '#Region "Enums"

    '    Private Enum SaveMode
    '        Saving
    '        Saved
    '        Deleting
    '        Deleted
    '        Committing
    '    End Enum
    '#End Region

    '#Region "Constantes privadas"

    '    Private Const C_AUDIT_USR_INS = "UsrCreador"
    '    Private Const C_AUDIT_USR_UPD = "UsrModificador"
    '    Private Const C_AUDIT_FCH_INS = "FechaCreado"
    '    Private Const C_AUDIT_FCH_UPD = "FechaModificado"
    '    Private Const C_AUDIT_SAVEPOINT = "BeforeAudit"

    '#End Region

    '#Region "Métodos públicos"

    '    Public Function GetFieldPersistenceInfoFromCore(ByVal field As IEntityField2) As IFieldPersistenceInfo Implements IStudioAdapter.GetFieldPersistenceInfoFromCore
    '        Dim info As IFieldPersistenceInfo = MyBase.GetFieldPersistenceInfo(field)
    '        Return info
    '    End Function

    '    'Public Overloads Overrides Function SaveEntity(ByVal entityToSave As IEntity2, ByVal refetchAfterSave As Boolean, ByVal updateRestriction As IPredicateExpression, ByVal recurse As Boolean) As Boolean
    '    '    If entityToSave.IsDirty AndAlso Me.AuditValues Then
    '    '        Me.SetAuditValuesToEntiy(entityToSave)
    '    '    End If
    '    '    Me._auditingEntites.Clear()
    '    '    Return MyBase.SaveEntity(entityToSave, refetchAfterSave, updateRestriction, recurse)
    '    'End Function

    '    'Public Overloads Overrides Function DeleteEntity(ByVal entityToDelete As IEntity2) As Boolean
    '    '    'Validar antes de borrar
    '    '    If Not entityToDelete.Validator Is Nothing Then
    '    '        entityToDelete.Validator.ValidateEntityBeforeDelete(entityToDelete)
    '    '        'CType(entityToDelete.Validator, Studio.Net.BLL.IBEntityValidator).ValidateEntityBeforeDelete(entityToDelete)
    '    '    End If
    '    '    Return MyBase.DeleteEntity(entityToDelete)

    '    'End Function

    '    Public Overloads Overrides Function DeleteEntity(ByVal entityToDelete As IEntity2, ByVal deleteRestriction As IPredicateExpression) As Boolean
    '        'Validar antes de borrar
    '        'If Not entityToDelete.EntityValidatorToUse Is Nothing Then
    '        '    CType(entityToDelete.EntityValidatorToUse, Studio.Net.BLL.IBEntityValidator).Validate(entityToDelete, Net.BLL.ValidationMode.Deleting)
    '        'End If
    '        Me.VerifyValidator(entityToDelete)

    '        If Not entityToDelete.Validator Is Nothing Then
    '            entityToDelete.Validator.ValidateEntityBeforeDelete(entityToDelete)
    '        End If
    '        Return MyBase.DeleteEntity(entityToDelete, deleteRestriction)
    '    End Function

    '#End Region

    '#Region "Procedimientos privados"

    '    Private Sub SetAuditValuesToEntiy(ByVal entityToSave As IEntity2)

    '        Dim UserInfo As IUserInfo = Studio.Net.Helper.UserManager.UserInfo

    '        If UserInfo Is Nothing Then
    '            UserInfo = New Studio.Net.BLL.UserInfo("traffic")
    '        End If


    '        With entityToSave

    '            Try
    '                If Not IsTransactionInProgress Then
    '                    .SaveFields(C_AUDIT_SAVEPOINT)
    '                End If
    '                'End If
    '                For Each item As EntityField2 In entityToSave.Fields

    '                    If item.IsForeignKey AndAlso item.IsChanged AndAlso item.CurrentValue IsNot Nothing AndAlso item.CurrentValue = 0I Then
    '                        item.CurrentValue = Nothing
    '                    End If

    '                    Select Case item.Name
    '                        Case C_AUDIT_USR_UPD
    '                            item.CurrentValue = UserInfo.Login
    '                        Case C_AUDIT_FCH_UPD
    '                            item.CurrentValue = System.DateTime.Now
    '                        Case item.Name = C_AUDIT_USR_INS And .IsNew
    '                            item.CurrentValue = UserInfo.Login
    '                        Case item.Name = C_AUDIT_FCH_INS And .IsNew
    '                            .Fields(C_AUDIT_FCH_INS).CurrentValue = DateTime.Now
    '                    End Select

    '                Next

    '                '.Fields(C_AUDIT_USR_UPD).CurrentValue = UserInfo.Login
    '                'Me.VerifyValidator(entityToSave)

    '            Catch ex As Exception
    '                If Not IsTransactionInProgress Then
    '                    .RollbackFields(C_AUDIT_SAVEPOINT)
    '                End If
    '                Throw
    '            End Try

    '        End With


    '    End Sub

    '    'Private Sub VerifyValidator(ByVal entity As IEntity2)
    '    '    If Not entity.Validator Is Nothing Then Return
    '    '    Select Case entity.LLBLGenProEntityName
    '    '        Case Studio.Phone.DAL.EntityType.DocumentoEntradaEntity.ToString()
    '    '            entity.Validator = New DocumentoEntradaEntityValidator
    '    '    End Select

    '    'End Sub

    '    Public Overrides Sub ExecuteMultiRowRetrievalQuery(ByVal queryToExecute As IRetrievalQuery, ByVal entityFactory As IEntityFactory2, _
    '                                                                                        ByVal collectionToFill As IEntityCollection2, ByVal fieldsPersistenceInfo As IFieldPersistenceInfo(), _
    '                                                                                        ByVal allowDuplicates As Boolean, ByVal fieldsUsedForQuery As IEntityFields2)
    '        MyBase.ExecuteMultiRowRetrievalQuery(queryToExecute, entityFactory, collectionToFill, fieldsPersistenceInfo, _
    '                           allowDuplicates, fieldsUsedForQuery)
    '    End Sub

    '    Public Overrides Function ExecuteActionQuery(ByVal queryToExecute As IActionQuery) As Integer
    '        If UseProtectionMode Then
    '            Throw New InvalidOperationException("No están permitdas las actualizaciones")
    '        End If

    '        'Dim sql = CType(queryToExecute, BatchActionQuery).ActionQueries(0).Command.CommandText
    '        Return MyBase.ExecuteActionQuery(queryToExecute)
    '    End Function

    '    Public Overloads Overrides Function ExecuteMultiRowDataTableRetrievalQuery(ByVal queryToExecute As IRetrievalQuery, ByVal dataAdapterToUse As DbDataAdapter, ByVal tableToFill As DataTable, ByVal fieldsPersistenceInfo() As IFieldPersistenceInfo) As Boolean
    '        Dim sql As String = CType(queryToExecute, SD.LLBLGen.Pro.ORMSupportClasses.RetrievalQuery).Command.CommandText
    '        Return MyBase.ExecuteMultiRowDataTableRetrievalQuery(queryToExecute, dataAdapterToUse, tableToFill, fieldsPersistenceInfo)
    '    End Function

    '    Public Overloads Overrides Function ExecuteScalarQuery(ByVal queryToExecute As SD.LLBLGen.Pro.ORMSupportClasses.IRetrievalQuery) As Object
    '        Return MyBase.ExecuteScalarQuery(queryToExecute)
    '    End Function

    '    Protected Overrides Sub OnBeforeEntitySave(ByVal entitySaved As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2, ByVal insertAction As Boolean)

    '        If entitySaved.IsDirty Then
    '            If Me.AuditValues Then
    '                Me.SetAuditValuesToEntiy(entitySaved)
    '            End If
    '            If IsTransactionInProgress AndAlso _
    '                Not EntitiesSavedInTransacction.ContainsKey(entitySaved.ObjectID) Then
    '                EntitiesSavedInTransacction.Add(entitySaved.ObjectID, entitySaved)
    '            End If
    '        End If

    '        VerifyValidator(entitySaved)

    '        'Me.VerifyValidator(entitySaved)
    '        VerifyTrigger(entitySaved, SaveMode.Saving)
    '        MyBase.OnBeforeEntitySave(entitySaved, insertAction)

    '    End Sub

    '    Protected Overrides Sub OnSaveEntity(ByVal saveQuery As SD.LLBLGen.Pro.ORMSupportClasses.IActionQuery, ByVal entityToSave As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2)
    '        MyBase.OnSaveEntity(saveQuery, entityToSave)
    '    End Sub

    '    'Public Overrides Function SaveEntity(ByVal entityToSave As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2, ByVal refetchAfterSave As Boolean, ByVal updateRestriction As SD.LLBLGen.Pro.ORMSupportClasses.IPredicateExpression, ByVal recurse As Boolean) As Boolean
    '    '    Dim toReturn As Boolean = MyBase.SaveEntity(entityToSave, refetchAfterSave, updateRestriction, recurse)
    '    '    If toReturn Then
    '    '        VerifyTrigger(entityToSave, SaveMode.Saved)
    '    '    End If
    '    '    Return toReturn
    '    'End Function

    '    Protected Overrides Sub OnSaveEntityComplete(ByVal saveQuery As SD.LLBLGen.Pro.ORMSupportClasses.IActionQuery, ByVal entityToSave As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2)
    '        MyBase.OnSaveEntityComplete(saveQuery, entityToSave)
    '        VerifyTrigger(entityToSave, SaveMode.Saved)

    '    End Sub


    '    Private Sub VerifyValidator(ByVal entitySaved As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2)
    '        If entitySaved.Validator IsNot Nothing And TryCast(entitySaved.Validator, BEntityValidatorBase) IsNot Nothing Then
    '            DirectCast(entitySaved.Validator, BEntityValidatorBase).DataAccessAdapterToUse = Me
    '        End If
    '    End Sub

    '    Private Sub VerifyTrigger(ByVal entity As IEntity2, ByVal mode As SaveMode)

    '        SyncLock m_Triggers
    '            If Not m_FlagTrigger Then

    '                m_FlagTrigger = True

    '            End If
    '        End SyncLock

    '        Dim trigger As IEntityTrigger = GetTrigger(entity)
    '        If trigger IsNot Nothing Then
    '            trigger.AdapterToUse = Me
    '            Select Case mode
    '                Case SaveMode.Saving
    '                    trigger.Saving(entity)
    '                Case SaveMode.Saved
    '                    trigger.Saved(entity)
    '                Case SaveMode.Deleting
    '                    trigger.Deleting(entity)
    '                Case SaveMode.Deleted
    '                    trigger.Deleted(entity)
    '                Case SaveMode.Committing
    '                    trigger.Committing(entity)
    '            End Select
    '        End If

    '    End Sub

    '    Private Function GetTrigger(ByVal entity As IEntity2) As IEntityTrigger
    '        If m_Triggers.ContainsKey(entity.LLBLGenProEntityName) Then
    '            Dim trigger As IEntityTrigger = m_Triggers(entity.LLBLGenProEntityName)
    '            trigger.AdapterToUse = Me
    '            Return trigger
    '        End If
    '        Return Nothing
    '    End Function

    '    Protected Overrides Sub OnAfterTransactionCommit()
    '        MyBase.OnAfterTransactionCommit()
    '        ClearEntitiesSavedInTransacction()
    '    End Sub

    '    Protected Overrides Sub OnBeforeTransactionCommit()
    '        MyBase.OnBeforeTransactionCommit()
    '    End Sub

    '    Protected Overrides Sub OnAfterTransactionRollback()
    '        MyBase.OnAfterTransactionRollback()
    '        ClearEntitiesSavedInTransacction()
    '    End Sub

    '    Protected Overrides Sub Dispose(ByVal isDisposing As Boolean)
    '        'Throw New InvalidOperationException("no disposable")
    '        ClearEntitiesSavedInTransacction()
    '        MyBase.Dispose(isDisposing)
    '    End Sub

    '    Public Overrides Sub StartTransaction(ByVal isolationLevelToUse As System.Data.IsolationLevel, ByVal name As String)
    '        MyBase.StartTransaction(isolationLevelToUse, name)
    '        ClearEntitiesSavedInTransacction()
    '    End Sub

    '    Protected Overrides Sub OnDeleteEntity(ByVal deleteQuery As SD.LLBLGen.Pro.ORMSupportClasses.IActionQuery, ByVal entityToDelete As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2)
    '        VerifyTrigger(entityToDelete, SaveMode.Deleting)
    '        MyBase.OnDeleteEntity(deleteQuery, entityToDelete)
    '    End Sub

    '    Protected Overrides Sub OnDeleteEntityComplete(ByVal deleteQuery As SD.LLBLGen.Pro.ORMSupportClasses.IActionQuery, ByVal entityToDelete As SD.LLBLGen.Pro.ORMSupportClasses.IEntity2)
    '        MyBase.OnDeleteEntityComplete(deleteQuery, entityToDelete)
    '        VerifyTrigger(entityToDelete, SaveMode.Deleted)
    '    End Sub

    '    Private Sub ClearEntitiesSavedInTransacction()
    '        If EntitiesSavedInTransacction IsNot Nothing Then
    '            EntitiesSavedInTransacction.Clear()
    '        End If

    '    End Sub

    '    Private Sub OnCommitting()

    '        For Each value As KeyValuePair(Of Guid, IEntity2) In EntitiesSavedInTransacction
    '            VerifyTrigger(value.Value, SaveMode.Committing)
    '        Next

    '    End Sub

    '#End Region

    '#Region "Propiedades públicas"

    '    Public Property UseProtectionMode As Boolean Implements IStudioAdapter.UseProtectionMode

    '    Public Property AuditValues() As Boolean
    '        Get
    '            Return Me._auditValues
    '        End Get
    '        Set(ByVal Value As Boolean)
    '            Me._auditValues = Value
    '        End Set
    '    End Property

    '    Public ReadOnly Property EntitiesSavedInTransacction() As Dictionary(Of Guid, IEntity2)
    '        Get
    '            If m_EntitiesSavedInTransacction Is Nothing Then
    '                m_EntitiesSavedInTransacction = New Dictionary(Of Guid, IEntity2)
    '            End If
    '            Return m_EntitiesSavedInTransacction
    '        End Get
    '    End Property


    '#Region "Insert Bulk"

    '    Private Sub CreateQueryFromElementsCore(ByVal fieldCollectionToFetch As IEntityFields2, ByVal filterBucket As IRelationPredicateBucket, ByVal maxNumberOfItemsToReturn As Integer, ByVal sortClauses As ISortExpression, ByVal allowDuplicates As Boolean, ByVal groupByClause As IGroupByCollection, _
    '            ByVal pageNumber As Integer, ByVal pageSize As Integer, ByVal persistenceInfo As IFieldPersistenceInfo(), ByVal selectQuery As IRetrievalQuery)

    '        Dim mi = GetType(DataAccessAdapterBase).GetMethod("CreateQueryFromElements", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.[Static])

    '        persistenceInfo = Nothing
    '        selectQuery = Nothing

    '        Dim parameters = New Object() {fieldCollectionToFetch, filterBucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, groupByClause, _
    '         pageNumber, pageSize, persistenceInfo, selectQuery}

    '        mi.Invoke(Me, parameters)

    '        persistenceInfo = DirectCast(parameters(8), IFieldPersistenceInfo())
    '        selectQuery = DirectCast(parameters(9), IRetrievalQuery)

    '    End Sub

    '    Public Function InsertMissingJoinTableEntitiesDirectly(Of T As {IEntity2, New})(ByVal filter1 As Predicate, ByVal filter2 As Predicate) As Integer
    '        Return InsertMissingJoinTableEntitiesDirectly(New T(), filter1, filter2)
    '    End Function

    '    Public Function InsertMissingJoinTableEntitiesDirectly(ByVal templateEntity As IEntity2, ByVal filter1 As Predicate, ByVal filter2 As Predicate) As Integer

    '        If templateEntity Is Nothing Then
    '            Throw New ArgumentNullException("templateEntity")
    '        End If
    '        If filter1 Is Nothing AndAlso filter2 Is Nothing Then
    '            Throw New ArgumentException("At least one filter must be specified.")
    '        End If

    '        Dim selectPersistenceInfo As IFieldPersistenceInfo()
    '        Dim selectQuery As IRetrievalQuery

    '        Dim relatedFields = New List(Of EntityField2)()
    '        Dim joinFields = New List(Of EntityField2)()
    '        Dim onClause = New PredicateExpression()

    '        ' Parse the relations and build up the on clause and lists of PK fields, FK fields
    '        For Each relation As IEntityRelation In templateEntity.GetAllRelations()
    '            If relation.TypeOfRelation <> RelationType.ManyToOne Then
    '                Continue For
    '            End If

    '            Dim pkField = DirectCast(relation.GetPKEntityFieldCore(0), EntityField2)
    '            Dim fkField = DirectCast(relation.GetFKEntityFieldCore(0), EntityField2)

    '            onClause.AddWithAnd(fkField = pkField)

    '            relatedFields.Add(pkField)
    '            joinFields.Add(fkField)
    '        Next

    '        ' Simple validation
    '        If relatedFields.Count <> 2 OrElse relatedFields(0).ContainingObjectName = relatedFields(1).ContainingObjectName Then
    '            Throw New InvalidOperationException("Must be exactly two FK relations each with a single field PK")
    '        End If

    '        ' Create a cross join relation between the non-join table tables
    '        Dim crossJoinRelation = New EntityRelation()
    '        crossJoinRelation.AddEntityFieldPair(relatedFields(0), relatedFields(1))
    '        crossJoinRelation.HintForJoins = JoinHint.Cross

    '        ' Create a relation between the join table and the cross join
    '        ' (we just use the first select field since we have to supply a pair)
    '        Dim joinTableRelation As IEntityRelation = New EntityRelation() With { _
    '         .CustomFilter = onClause, _
    '         .CustomFilterReplacesOnClause = True, _
    '         .StartEntityIsPkSide = True, _
    '         .HintForJoins = JoinHint.Left _
    '        }

    '        joinTableRelation.AddEntityFieldPair(Of EntityFieldCore)(relatedFields(0), templateEntity.PrimaryKeyFields(0))

    '        ' Build a RelationPredicateBucket with our joins and filter
    '        Dim filterBucket = New RelationPredicateBucket(DirectCast(templateEntity.PrimaryKeyFields(0), EntityField2) = DBNull.Value And filter1 And filter2)
    '        filterBucket.Relations.Add(crossJoinRelation)
    '        filterBucket.Relations.Add(joinTableRelation)


    '        ' Build select list fields (must use aliases but doesn't matter what they are)
    '        Dim selectFields = New EntityFields2(relatedFields.Count)
    '        For i As Integer = 0 To relatedFields.Count - 1
    '            selectFields.DefineField(relatedFields(i), i, "f" & i)
    '        Next

    '        ' Create the select query
    '        CreateQueryFromElementsCore(selectFields, filterBucket, 0, Nothing, True, Nothing, _
    '         0, 0, selectPersistenceInfo, selectQuery)

    '        ' Since the DynamicQueryEnginer doesn't support INSERT INTO SELECT
    '        ' we build the query directly here
    '        Dim creator = CreateDynamicQueryEngine().Creator
    '        Dim joinFieldPersistenceInfos = GetFieldPersistenceInfos(templateEntity)

    '        Dim queryText = New StringBuilder(DynamicQueryEngineBase.InsertQueryBufferLength)
    '        queryText.AppendFormat("INSERT INTO {0} (", creator.CreateObjectName(joinFieldPersistenceInfos(0)))

    '        For i As Integer = 0 To joinFields.Count - 1
    '            Dim field As IEntityFieldCore = joinFields(i)
    '            Dim joinFieldPersistenceInfo = joinFieldPersistenceInfos(field.FieldIndex)

    '            If i > 0 Then
    '                queryText.Append(", ")
    '            End If

    '            queryText.AppendFormat("{0}", creator.CreateFieldNameSimple(joinFieldPersistenceInfo, field.Name))
    '        Next

    '        queryText.Append(String.Format("){0}{1}", vbCr, vbLf))
    '        queryText.Append(selectQuery.Command.CommandText)

    '        selectQuery.Command.CommandText = queryText.ToString()

    '        Return ExecuteActionQuery(New ActionQuery(selectQuery.Connection, selectQuery.Command))
    '    End Function

    '#End Region
    '#End Region

End Class

