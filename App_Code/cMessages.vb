Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Data

Public Class cMessages
    Inherits cMessageManagement

    Private pMessageID As Integer
    Private pSubject As String
    Private pMessage As String
    Private pFromUser As Integer
    Private pMessageTypeID As Integer
    Private pDateSent As DateTime
    Private pLanguageId As Integer

#Region "Getters"
    Public ReadOnly Property MessageID() As Integer
        Get
            Return pMessageID
        End Get
    End Property

    Public ReadOnly Property Subject() As String
        Get
            Return pSubject
        End Get
    End Property

    Public ReadOnly Property Message() As String
        Get
            Return pMessage
        End Get
    End Property

    Public ReadOnly Property FromUser() As Integer
        Get
            Return pFromUser
        End Get
    End Property

    Public ReadOnly Property MessageTypeID() As Integer
        Get
            Return pMessageTypeID
        End Get
    End Property

    Public ReadOnly Property DateSent() As DateTime
        Get
            Return pDateSent
        End Get
    End Property

    Public ReadOnly Property LanguageID() As Integer
        Get
            Return pLanguageId
        End Get
    End Property
#End Region


    Public Sub New(ByVal Subject As String, ByVal Message As String, ByVal FromUser As Integer, ByVal MessageTypeID As Integer, ByVal LanguageID As Integer)
        Me.pSubject = Subject
        Me.pMessage = Message
        Me.pFromUser = FromUser
        Me.pMessageTypeID = MessageTypeID
        Me.pLanguageId = LanguageID
    End Sub

    Public Sub New(ByVal MessageID As Integer)
        Try
            Me.pMessageID = MessageID

            Dim dtmessage As DataTable = cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT * FROM tblMessage WHERE MessageID = {0}", MessageID)))

            Me.pSubject = dtmessage.Rows(0).Item("Subject").ToString
            Me.pMessage = dtmessage.Rows(0).Item("Message").ToString
            Me.pFromUser = dtmessage.Rows(0).Item("FromUser").ToString
            Me.pMessageTypeID = dtmessage.Rows(0).Item("MessageTypeID").ToString
            Me.pDateSent = dtmessage.Rows(0).Item("DateSent").ToString
            Me.pLanguageId = dtmessage.Rows(0).Item("LanguageID").ToString
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessages init: on:{1} {0}", ex.Message, MessageID), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Updates the message to read.
    ''' </summary>
    ''' <param name="MessageToUserID">The message to user ID.</param>
    ''' <returns></returns>
    Public Shared Function UpdateMessageToRead(ByVal MessageToUserID As Integer) As Integer
        Try
            Return cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblMessageToUser " & _
                                                            "SET IsRead='True' " & _
                                                            "WHERE MessageToUserID = '{0}'", MessageToUserID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessages.UpdateMessageToRead: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets from ID by message ID.
    ''' </summary>
    ''' <param name="MessageID">The message ID.</param>
    ''' <returns></returns>
    Public Shared Function GetFromIDByMessageID(ByVal MessageID As Integer) As Integer
        Try
            Return cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT FromUser FROM tblMessage WHERE MessageID = '{0}'", MessageID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessages.GetFromIDByMessageID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the message by message ID.
    ''' </summary>
    ''' <param name="MessageID">The message ID.</param>
    ''' <returns></returns>
    Public Shared Function GetMessageByMessageID(ByVal MessageID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT * FROM tblMessage WHERE MessageID = '{0}'", MessageID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessages.GetMessageByMessageID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Checks the number unread messages.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function CheckNumberUnreadMessages(ByVal UserID As Integer) As Integer
        Try
            Return cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT COUNT(*) " & _
                      "FROM tblMessage INNER JOIN " & _
                      "tblMessageType ON tblMessageType.MessageTypeID = tblMessage.MessageTypeID INNER JOIN " & _
                      "tblMessageToUser ON tblMessage.MessageID = tblMessageToUser.MessageID LEFT OUTER JOIN " & _
                      "tblUser ON tblMessage.FromUser = tblUser.UserID " & _
                      "WHERE (tblMessageToUser.IsDeleted = 'False') AND ((tblMessageToUser.ToUserID = {0}) " & _
                      "OR (tblMessage.FromUser = {0})) AND (tblMessageToUser.ParentMessageID IS NULL) AND (tblMessageToUser.IsRead = 'False')", UserID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessages.CheckNumberUnreadMessages: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
