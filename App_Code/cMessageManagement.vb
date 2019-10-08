Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class cMessageManagement

    Enum MessageType
        Enquire = 1
        Normal = 2
        System = 3
        Ticket = 4
    End Enum

    ''' <summary>
    ''' Stores the message.
    ''' </summary>
    ''' <param name="Message">The message.</param>
    ''' <returns></returns>
    Public Shared Function StoreMessage(ByVal Message As cMessages) As Integer
        Try
            Return cDBManager.SetReturnID(New SqlCommand(String.Format("INSERT INTO tblMessage " & _
                                        "VALUES ('{0}', '{1}', {2}, {3},GETDATE(), {4})", _
                                        Message.Subject, Message.Message, Message.FromUser, Message.MessageTypeID, Message.LanguageID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageManagement.StoreMessage: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Stores the message to user.
    ''' </summary>
    ''' <param name="MessageToUser">The message to user.</param>
    ''' <returns></returns>
    Public Shared Function StoreMessageToUser(ByVal MessageToUser As cMessageToUser) As Integer
        Try
            If MessageToUser.ParentMessageID = Nothing Then
                Return cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblMessageToUser VALUES ({0}, {1}, '{2}', '{3}', '{4}', NULL, NULL)", _
                              MessageToUser.MessageID, MessageToUser.ToUser, MessageToUser.IsRead, MessageToUser.IsClosed, MessageToUser.IsDeleted)))

            Else
                Return cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblMessageToUser " & _
                                            "VALUES ({0}, {1}, '{2}', '{3}', '{4}', NULL, {5})", _
                                            MessageToUser.MessageID, MessageToUser.ToUser, MessageToUser.IsRead, MessageToUser.IsClosed, _
                                            MessageToUser.IsDeleted, MessageToUser.ParentMessageID)))
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageManagement.StoreMessageToUser: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets all messages for user.
    ''' </summary>
    ''' <param name="userID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function GetAllMessagesForUser(ByVal userID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblMessage.MessageID, tblMessageToUser.MessageToUserID, tblMessageToUser.IsRead, " & _
                                        "tblMessageType.MessageType, tblUser.Name + ' ' + tblUser.Surname AS Sender, " & _
                                        "tblMessage.Subject, tblMessage.DateSent " & _
                                        "FROM tblMessage " & _
                                        "INNER JOIN tblMessageType ON tblMessageType.MessageTypeID = tblMessage.MessageTypeID " & _
                                        "INNER JOIN tblMessageToUser ON tblMessage.MessageID = tblMessageToUser.MessageID " & _
                                        "LEFT OUTER JOIN tblUser ON tblMessage.FromUser = tblUser.UserID " & _
                                        "WHERE((tblMessageToUser.ToUserID = {0}) OR (tblMessage.FromUser = {0})) " & _
                                        "AND (tblMessageToUser.ParentMessageID IS NULL) AND tblMessageToUser.IsDeleted = 'False' " & _
                                        "ORDER BY tblMessage.DateSent DESC ", userID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageManagement.GetAllMessagesForUser: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the top messages for user.
    ''' </summary>
    ''' <param name="userID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function GetTopMessagesForUser(ByVal userID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT TOP (10) tblMessage.MessageID, tblMessageToUser.MessageToUserID, " & _
                                        "tblMessageToUser.IsRead, tblMessageType.MessageType, tblUser.Name + ' ' + tblUser.Surname AS Sender, " & _
                                        "tblMessage.Subject, tblMessage.DateSent " & _
                                        "FROM tblMessage " & _
                                        "INNER JOIN tblMessageType ON tblMessageType.MessageTypeID = tblMessage.MessageTypeID " & _
                                        "INNER JOIN tblMessageToUser ON tblMessage.MessageID = tblMessageToUser.MessageID " & _
                                        "LEFT OUTER JOIN tblUser ON tblMessage.FromUser = tblUser.UserID " & _
                                        "WHERE((tblMessageToUser.ToUserID = {0}) OR (tblMessage.FromUser = {0})) AND (tblMessageToUser.ParentMessageID IS NULL) " & _
                                        "AND tblMessageToUser.IsDeleted = 'False' " & _
                                        "ORDER BY tblMessage.DateSent DESC ", userID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageManagement.GetTopMessagesForUser: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the message details.
    ''' </summary>
    ''' <param name="messageToUser">The message to user.</param>
    ''' <param name="MessageID">The message ID.</param>
    ''' <returns></returns>
    Public Shared Function GetMessageDetails(ByVal messageToUser As Integer, ByVal MessageID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblMessage.Subject, tblMessage.DateSent, tblMessage.Message, tblUser.Name + ' ' + tblUser.Surname AS Sender, tblMessage.LanguageID " & _
                                    "FROM tblMessage " & _
                                    "LEFT OUTER JOIN tblUser ON tblMessage.FromUser = tblUser.UserID " & _
                                    "RIGHT OUTER JOIN tblMessageToUser ON tblMessage.MessageID = tblMessageToUser.MessageID " & _
                                    "WHERE (tblMessageToUser.MessageToUserID = {0}) OR (tblMessageToUser.ParentMessageID = {1})", messageToUser, MessageID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageManagement.GetMessageDetails: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Updates the deleted status.
    ''' </summary>
    ''' <param name="MessageToUser">The message to user.</param>
    ''' <returns></returns>
    Public Shared Function UpdateDeletedStatus(ByVal MessageToUser As Integer) As Boolean
        Try
            If cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("Update tblMessageToUser SET IsDeleted='True' WHERE MessageToUserID = {0}", MessageToUser))) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageManagement.UpdateDeletedStatus: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Updates the closed status.
    ''' </summary>
    ''' <param name="MessageToUser">The message to user.</param>
    ''' <returns></returns>
    Public Shared Function UpdateClosedStatus(ByVal MessageToUser As Integer) As Boolean
        Try
            If cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("Update tblMessageToUser SET IsClosed='True' WHERE MessageToUserID = {0}", MessageToUser))) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageManagement.UpdateClosedStatus: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Updates the message to unread.
    ''' </summary>
    ''' <param name="MessageToUser">The message to user.</param>
    ''' <returns></returns>
    Public Shared Function UpdateMessageToUnread(ByVal MessageToUser As Integer) As Boolean
        Try
            If cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblMessageToUser SET IsRead='False' WHERE MessageToUserID = {0}", MessageToUser))) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageManagement.UpdateMessageToUnread: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
