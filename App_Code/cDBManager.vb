Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Diagnostics


''' <summary>
''' Handles the opening and closing of the DB connection. 
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class cDBManager

    Enum CONNECTION_STRINGS
        CANADA
        GERMANY
        SINGAPORE
        INDIA
    End Enum

    ''' <summary>
    ''' Execute the query and retuns a Data Table. (SELECT)
    ''' </summary>
    ''' <param name="commandQuery">The SQL command to be executed</param>
    ''' <returns>A Data Table according to the SQL Query passed</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDataTable(ByVal commandQuery As SqlCommand) As DataTable
        Dim dtResults As New DataTable
        Dim conn As New SqlConnection

        Try
            conn.ConnectionString = getConnectionString()
            Dim daQuery As New SqlClient.SqlDataAdapter(commandQuery.CommandText, conn)

            If conn.State = ConnectionState.Closed Then
                conn.Open()
                'debug
                Debug.Write("DBM: " & commandQuery.CommandText)
            End If

            daQuery.Fill(dtResults)
        Catch ex As SqlException
            Debug.Write("SQL_ERROR: " & ex.Message)
            cLogging.AddLog("GetDataTable: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        Catch ex As Exception
            'pass exception to error handler
            Debug.Write("DBM_ERROR: " & ex.Message)
            cLogging.addSystemLog(ex)
            'cLogging.AddLog("GetDataTable: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            dtResults = Nothing
            Throw ex
        Finally
            conn.Close()
        End Try

        Return dtResults
    End Function

    ''' <summary>
    ''' Execute the query and retuns a Data Table. (SELECT)
    ''' </summary>
    ''' <param name="commandQuery">The MySQL Command to be executed</param>
    ''' <returns>A Data Table according to the MySQL Query passed</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDataTable(ByVal commandQuery As MySqlCommand, ByVal mySqlDbConn As CONNECTION_STRINGS) As DataTable
        Dim dtResults As New DataTable
        Dim conn As New MySqlConnection

        Try
            conn.ConnectionString = getConnectionString(mySqlDbConn)
            Dim daQuery As New MySqlDataAdapter(commandQuery.CommandText, conn)

            If conn.State = ConnectionState.Closed Then
                conn.Open()
                'debug
                Debug.Write("DBM: " & commandQuery.CommandText)
            End If

            daQuery.Fill(dtResults)
        Catch ex As SqlException
            Debug.Write("SQL_ERROR: " & ex.Message)
            cLogging.AddLog("GetDataTable: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        Catch ex As Exception
            'pass exception to error handler
            Debug.Write("DBM_ERROR: " & ex.Message)
            cLogging.addSystemLog(ex)
            'cLogging.AddLog("GetDataTable: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            dtResults = Nothing
            Throw ex
        Finally
            conn.Close()
        End Try

        Return dtResults
    End Function

    ''' <summary>
    ''' Executes the query, and returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored.
    ''' </summary>
    ''' <param name="commandQuery">The command to be executed.</param>
    ''' <returns>
    ''' The first column of the first row in the result set, or a null reference (Nothing in Visual Basic) if the result set is empty.
    ''' </returns>
    ''' <remarks>
    ''' Possible(Query)
    ''' commandQuery.CommandText = "SELECT MessageTypeID FROM tblMessageType WHERE MessageType = @MessageType"
    ''' commandQuery.Parameters.AddWithValue("@MessageType", "This is it's value")
    ''' </remarks>
    Public Shared Function GetExecuteScalar(ByVal commandQuery As SqlCommand) As Object
        Dim conn As New SqlConnection
        Dim objResults As New Object

        Try
            conn.ConnectionString = getConnectionString()
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                'debug
                Debug.Write("DBM: " & commandQuery.CommandText)
            End If

            commandQuery.Connection = conn
            objResults = commandQuery.ExecuteScalar
        Catch ex As SqlException
            Debug.Write("SQL_ERROR: " & ex.Message)
            cLogging.AddLog("GetExecuteScalar: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        Catch ex As Exception
            'pass exception to error handler
            Debug.Write("DBM_ERROR: " & ex.Message)
            cLogging.addSystemLog(ex)
            'cLogging.AddLog("GetExecuteScalar: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            objResults = Nothing
            Throw ex
        Finally
            conn.Close()
        End Try

        Return objResults
    End Function

    ''' <summary>
    ''' Executes the query, and returns the ID of a newly added record.
    ''' </summary>
    ''' <param name="commandQuery">The command to be executed.</param>
    ''' <returns>ID As Integer of a newly added record.</returns>
    ''' <remarks></remarks>
    Public Shared Function SetReturnID(ByVal commandQuery As SqlCommand) As Integer
        Dim conn As New SqlConnection
        Try
            conn.ConnectionString = getConnectionString()

            If conn.State = ConnectionState.Closed Then
                conn.Open()
                'debug
                Debug.Write("DBM: " & commandQuery.CommandText)
            End If

            commandQuery.CommandText += "; SELECT SCOPE_IDENTITY();"
            commandQuery.Connection = conn

            Return commandQuery.ExecuteScalar
        Catch ex As SqlException
            Debug.Write("SQL_ERROR: " & ex.Message)
            cLogging.AddLog("SetReturnID: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        Catch ex As Exception
            'pass exception to error "handler
            Debug.Write("DBM_ERROR: " & ex.Message)
            cLogging.addSystemLog(ex)
            'cLogging.AddLog("SetReturnID: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function

    ''' <summary>
    ''' Executes a Transact-SQL statement against the connection and returns the number of rows affected. (INSERT, UPDATE and DELETE)
    ''' </summary>
    ''' <param name="commandQuery">The command to be executed</param>
    ''' <returns>
    ''' The number of rows affected.
    ''' </returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteNonQuery(ByVal commandQuery As SqlCommand) As Integer
        Dim conn As New SqlConnection
        Dim _rowsEffected As Int32
        Try
            conn.ConnectionString = getConnectionString()

            If conn.State = ConnectionState.Closed Then
                conn.Open()
                'debug
                Debug.Write("DBM: " & commandQuery.CommandText)
            End If

            commandQuery.Connection = conn
            _rowsEffected = commandQuery.ExecuteNonQuery

            Return _rowsEffected
        Catch ex As SqlException
            Debug.Write("SQL_ERROR: " & ex.Message)
            cLogging.AddLog("ExecuteNonQuery: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        Catch ex As Exception
            Debug.Write("DBM_ERROR: " & ex.Message)
            cLogging.addSystemLog(ex)
            'cLogging.AddLog("ExecuteNonQuery: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    Private Shared Function getConnectionString() As String
        Return ConfigurationManager.ConnectionStrings("RadixSystemsDataBase").ConnectionString
    End Function

    Private Shared Function getConnectionString(ByVal database As CONNECTION_STRINGS) As String
        Select Case database
            Case CONNECTION_STRINGS.CANADA
                Return ConfigurationManager.ConnectionStrings("MySQLConnCANADA").ConnectionString
            Case CONNECTION_STRINGS.GERMANY
                Return ConfigurationManager.ConnectionStrings("MySQLConnGERMANY").ConnectionString
            Case CONNECTION_STRINGS.INDIA
                Return ConfigurationManager.ConnectionStrings("MySQLConnINDIA").ConnectionString
            Case CONNECTION_STRINGS.SINGAPORE
                Return ConfigurationManager.ConnectionStrings("MySQLConnSINGAPORE").ConnectionString
            Case Else
                Return Nothing
        End Select
        Return ConfigurationManager.ConnectionStrings("RadixSystemsDataBase").ConnectionString
    End Function
End Class

