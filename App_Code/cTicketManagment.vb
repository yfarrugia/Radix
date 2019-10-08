Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class cTicketManagment
    Enum TicketStatus
        Created = 1
        Wip = 2
        Solved = 4
    End Enum

    ''' <summary>
    ''' Saves the ticket.
    ''' </summary>
    ''' <param name="Ticket">The ticket.</param>
    ''' <returns></returns>
    Public Shared Function SaveTicket(ByVal Ticket As cTicket) As Integer
        Try
            Dim _ticketInsertID As Integer = cDBManager.SetReturnID(New SqlCommand(String.Format("INSERT INTO tblSupportTicket VALUES ({0}, {1}, NULL,{2}, GETDATE(), 'False')", Ticket.MessageID, Ticket.Priority, Ticket.TicketStatusID)))
            cLogging.AddLog(String.Format("Successfully stored ticket: {0}", _ticketInsertID), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
            Return _ticketInsertID
        Catch ex As Exception
            cLogging.AddLog(String.Format("SaveTicket {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Updates the ticket status.
    ''' </summary>
    ''' <param name="ticketID">The ticket ID.</param>
    ''' <param name="Status">The status.</param>
    ''' <returns></returns>
    Public Shared Function UpdateTicketStatus(ByVal ticketID As Integer, ByVal Status As cTicketManagment.TicketStatus) As Integer
        Try
            Return cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblSupportTicket SET TicketStatusID = {0} WHERE SupportTicketID = {1}", Convert.ToInt16(Status), ticketID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("UpdateTicketStatus {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Assigns the ticket to a userID.
    ''' </summary>
    ''' <param name="ticketID">The ticket ID.</param>
    ''' <param name="assignto">The Id of the user to assign the ticket.</param>
    ''' <returns></returns>
    Public Shared Function AssignTicket(ByVal ticketID As Integer, ByVal assignto As Integer) As Integer
        Try
            Return cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblSupportTicket SET AssignedTo = {0} WHERE SupportTicketID = {1}", assignto, ticketID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("AssignTicket {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the support open tickets.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetSupportOpenTickets() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblSupportTicket.SupportTicketID, tblMessage.Subject, tblSupportTicket.Priority, " & _
                             "tblUser.Name + ' ' + tblUser.Surname AS [Ticket Assign To], tblSupportTicket.DateSent " & _
                             "FROM tblSupportTicket " & _
                             "INNER JOIN tblMessage ON tblSupportTicket.MessageID = tblMessage.MessageID " & _
                             "INNER JOIN tblUser ON tblUser.UserID = tblSupportTicket.AssignedTo " & _
                             "WHERE NOT (tblSupportTicket.TicketStatusID = {0}) AND (tblSupportTicket.Escalated = 'False')", Convert.ToInt16(cTicketManagment.TicketStatus.Solved))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("GetSupportOpenTickets {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the support un assigned tickets.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetSupportUnAssignedTickets() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT tblSupportTicket.SupportTicketID, tblSupportTicket.Priority, tblMessage.Subject, " & _
                             "tblUser.Name + ' ' + tblUser.Surname AS 'From User', tblSupportTicket.DateSent " & _
                             "FROM tblSupportTicket " & _
                             "INNER JOIN tblMessage ON tblSupportTicket.MessageID = tblMessage.MessageID " & _
                             "INNER JOIN tblUser ON tblMessage.FromUser = tblUser.UserID " & _
                             "WHERE (tblSupportTicket.AssignedTo IS NULL) AND (tblSupportTicket.Escalated = 'False')"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("GetSupportUnAssignedTickets {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the assigned tickets.
    ''' </summary>
    ''' <param name="AdminID">The admin ID.</param>
    ''' <returns></returns>
    Public Shared Function getAssignedTickets(ByVal AdminID As Integer) As DataTable

        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblSupportTicket.SupportTicketID, tblSupportTicket.Priority, " & _
                                    "tblTicketStatus.TicketStatus, tblMessage.Subject, tblUser.Name + ' ' + tblUser.Surname AS 'From User', " & _
                                    "tblSupportTicket.DateSent " & _
                                    "FROM tblMessage " & _
                                    "INNER JOIN tblSupportTicket ON tblMessage.MessageID = tblSupportTicket.MessageID " & _
                                    "INNER JOIN tblSupportAdmin ON tblSupportTicket.AssignedTo = tblSupportAdmin.SupportAdminID " & _
                                    "INNER JOIN tblTicketStatus ON tblSupportTicket.TicketStatusID = tblTicketStatus.TicketStatusID " & _
                                    "INNER JOIN tblUser ON tblMessage.FromUser = tblUser.UserID " & _
                                    "LEFT OUTER JOIN tblMessageToUser ON tblMessage.MessageID = tblMessageToUser.MessageID " & _
                                    "WHERE (tblSupportAdmin.SupportAdminID = {0}) AND NOT(tblTicketStatus.TicketStatus = 'Solved')", AdminID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("getAssignedTickets {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Un the assign a ticket.
    ''' </summary>
    ''' <param name="TicketID">The ticket ID.</param>
    ''' <returns></returns>
    Public Shared Function UnAssignTicket(ByVal TicketID As Integer) As Boolean
        Try
            If (cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblSupportTicket SET AssignedTo = NULL WHERE SupportTicketID = {0}", TicketID)))) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("UnAssignTicket {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the ticket by message ID.
    ''' </summary>
    ''' <param name="MessageID">The message ID.</param>
    ''' <returns></returns>
    Public Shared Function GetTicketByMessageID(ByVal MessageID As Integer) As Integer
        Try
            Return cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT tblSupportTicket.SupportTicketID " & _
                             "FROM tblSupportTicket " & _
                             "WHERE MessageID = {0}", MessageID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("GetTicketByMessageID {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Escalates a ticket.
    ''' </summary>
    ''' <param name="ticketID">The ticket ID.</param>
    ''' <returns></returns>
    Public Shared Function EscalateTicket(ByVal ticketID As Integer) As Boolean
        Try
            If (cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblSupportTicket SET Escalated = 'True' WHERE SupportTicketID = {0}", ticketID)))) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("EscalateTicket {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the system's unassigned tickets.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetSystemUnAssignedTickets() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT tblSupportTicket.SupportTicketID, tblSupportTicket.Priority, " & _
                                    "tblMessage.Subject, tblUser.Name + ' ' + tblUser.Surname AS 'From User', tblSupportTicket.DateSent " & _
                                    "FROM tblSupportTicket " & _
                                    "INNER JOIN tblMessage ON tblSupportTicket.MessageID = tblMessage.MessageID " & _
                                    "INNER JOIN tblUser ON tblMessage.FromUser = tblUser.UserID " & _
                                    "WHERE tblSupportTicket.AssignedTo IS NULL AND (tblSupportTicket.Escalated = 'True')"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("GetSystemUnAssignedTickets {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets all tickets.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetAllTickets() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT tblSupportTicket.SupportTicketID, tblSupportTicket.Priority, tblMessage.Subject, " & _
                                    "tblUser.Name + ' ' + tblUser.Surname AS 'From User', tblSupportTicket.DateSent, " & _
                                    "(SELECT tblUser.Name + ' ' + tblUser.Surname " & _
                                    "FROM tblSupportTicket " & _
                                    "INNER JOIN tblUser ON tblSupportTicket.AssignedTo = tblUser.UserID) AS 'Assigned To' " & _
                                    "FROM tblSupportTicket " & _
                                    "INNER JOIN tblMessage ON tblSupportTicket.MessageID = tblMessage.MessageID " & _
                                    "INNER JOIN tblUser ON tblMessage.FromUser = tblUser.UserID"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("SavGetAllTicketseTicket {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
