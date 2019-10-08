Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class cMessageToUser
    Inherits cMessageManagement

    Private pMessageToUserID As Integer
    Private pMessageID As Integer
    Private pToUserID As Integer
    Private pCCCenterID As Integer
    Private pisRead As Boolean
    Private pisClosed As Boolean
    Private pisDeleted As Boolean
    Private ponBehlfOf As Boolean
    Private pParentMessageID As Integer

#Region "Getters"
    Public ReadOnly Property MessageToUserID() As Integer
        Get
            Return pMessageToUserID
        End Get
    End Property

    Public ReadOnly Property MessageID() As Integer
        Get
            Return pMessageID
        End Get
    End Property

    Public ReadOnly Property ToUser() As Integer
        Get
            Return pToUserID
        End Get
    End Property

    Public ReadOnly Property IsRead() As Boolean
        Get
            Return pisRead
        End Get
    End Property

    Public ReadOnly Property IsClosed() As Boolean
        Get
            Return pisClosed
        End Get
    End Property

    Public ReadOnly Property IsDeleted() As Boolean
        Get
            Return pisDeleted
        End Get
    End Property

    Public ReadOnly Property OnBehalfOf() As Integer
        Get
            Return ponBehlfOf
        End Get
    End Property
    Public ReadOnly Property ParentMessageID() As Integer
        Get
            Return pParentMessageID
        End Get
    End Property
#End Region

    Public Sub New(ByVal MessageToUser As Integer)
        Try
            Me.pMessageToUserID = MessageToUser

            Dim dtmessage As DataTable = cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT * FROM tblMessageToUser WHERE MessageToUserID = {0}", MessageToUser)))

            Me.pMessageID = dtmessage.Rows(0).Item("MessageID").ToString
            Me.pToUserID = dtmessage.Rows(0).Item("ToUserID").ToString

            Me.pisRead = dtmessage.Rows(0).Item("IsRead").ToString
            Me.pisClosed = dtmessage.Rows(0).Item("IsClosed").ToString
            Me.pisDeleted = dtmessage.Rows(0).Item("IsDeleted").ToString

            If dtmessage.Rows(0).Item("OnBehalfof").ToString = Nothing Then
                Me.ponBehlfOf = Nothing
            Else
                Me.ponBehlfOf = dtmessage.Rows(0).Item("OnBehalfof").ToString
            End If

            If dtmessage.Rows(0).Item("ParentMessageID").ToString = Nothing Then
                Me.pParentMessageID = Nothing
            Else
                Me.pParentMessageID = dtmessage.Rows(0).Item("ParentMessageID").ToString
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageToUser init: on:{1} {0}", ex.Message, MessageToUser), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub
    Public Sub New(ByVal MessageID As Integer, ByVal ToUser As Integer, ByVal IsRead As Boolean, ByVal ParentMessageID As Integer)
        Me.pMessageID = MessageID
        Me.pToUserID = ToUser
        Me.pisRead = IsRead
        Me.pisClosed = False
        Me.pisDeleted = False
        Me.pParentMessageID = ParentMessageID
    End Sub

    ''' <summary>
    ''' Checks if a message is closed.
    ''' </summary>
    ''' <param name="MessageToUserID">The message to user ID.</param>
    ''' <returns></returns>
    Public Shared Function CheckIfClosed(ByVal MessageToUserID As Integer) As Boolean
        Try
            Return cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT IsClosed FROM tblMessageToUser WHERE MessageToUserID = {0}", MessageToUserID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageToUser.CheckIsClosed: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the message to user from message.
    ''' </summary>
    ''' <param name="MessageID">The message ID.</param>
    ''' <returns></returns>
    Public Shared Function GetMessageToUserFromMessage(ByVal MessageID As Integer) As Integer
        Try
            Dim objRet As Object = cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT tblMessageToUser.MessageToUserID " & _
                                    "FROM tblMessageToUser " & _
                                    "WHERE  (ParentMessageID IS NULL) AND (MessageID = {0})", MessageID)))

            If (DBNull.Value.Equals(objRet)) Then
                Return 0
            End If
            Return objRet
        Catch ex As Exception
            cLogging.AddLog(String.Format("cMessageToUser.GetMessageToUserFromMessage: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
