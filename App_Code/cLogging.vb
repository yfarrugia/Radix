Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Diagnostics



Public Class cLogging

    Public Sub New()
        MyBase.New()
    End Sub

    Enum LogType
        INFORMATION_LOG = 1
        WARNING_LOG = 2
        ERROR_LOG = 3
        SYSTEM_LOG = 4
    End Enum

    Private Const LOG_APPLICATION_NAME As String = "Radix Systems"

    ''' <summary>
    ''' Adds a log.
    ''' </summary>
    ''' <param name="LogMessage">The log message.</param>
    ''' <param name="IP">The IP.</param>
    ''' <param name="LogType">Type of the log.</param>
    ''' <param name="SessionID">The session ID.</param>
    ''' <param name="SessionUserID">The session user ID.</param>
    ''' <param name="SessionUserType">Type of the session user.</param>
    ''' <param name="SessionUserName">Name of the session user.</param>
    Public Shared Sub AddLog(ByVal LogMessage As String, _
                             ByVal IP As String, _
                             ByVal LogType As LogType, _
                             ByVal SessionID As String, _
                             ByVal SessionUserID As Integer, _
                             ByVal SessionUserType As String, _
                             ByVal SessionUserName As String)
        Try
            '[2892] DBM: INSERT INTO tblLogs ([Stamp], [Message], [Type], [IPLog], [SessionID], [SessionUserID], [SessionUserType], [SessionUserName]) 
            'VALUES (GETDATE(), '[YELLOWFISH-LT] checkPass[s]: Passowrd for yr mached', 2, '', '', , '', 'yr')
            If SessionUserID = Nothing Then
                SessionUserID = -1
            End If

            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblLogs ([Stamp], [Message], [Type], [IPLog], " & _
            "[SessionID], [SessionUserID], [SessionUserType], [SessionUserName]) " & _
            "VALUES (GETDATE(), '[{0}] {1}', {3}, '{2}', '{4}', {5}, '{6}', '{7}')", _
                          My.Computer.Name.ToString, LogMessage.Replace("'", "''"), IP, Convert.ToInt16(LogType), SessionID, SessionUserID, SessionUserType, SessionUserName)))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Adds the system log.
    ''' </summary>
    ''' <param name="e">The e.</param>
    Public Shared Sub addSystemLog(ByVal e As Exception)
        Dim eventLog As New System.Diagnostics.EventLog()
        Try
            If Not (System.Diagnostics.EventLog.SourceExists(LOG_APPLICATION_NAME)) Then
                System.Diagnostics.EventLog.CreateEventSource(LOG_APPLICATION_NAME, "Application")
            End If
            eventLog.Source = LOG_APPLICATION_NAME
            eventLog.WriteEntry(e.Message & vbCrLf & e.StackTrace, EventLogEntryType.Error)
        Catch ex As Exception
            Throw ex
        Finally
            eventLog.Close()
        End Try

    End Sub
End Class
