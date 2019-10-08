Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class cTicket
    Inherits cTicketManagment

    Private pSupportTicketID As Integer
    Private pMessageID As Integer
    Private pPriority As Integer
    Private pAssignedTo As Integer
    Private pTicketStatusID As Integer
    Private pDateSent As DateTime

    Public ReadOnly Property SupportTicketID() As Integer
        Get
            Return pSupportTicketID
        End Get
    End Property

    Public ReadOnly Property MessageID() As Integer
        Get
            Return pMessageID
        End Get
    End Property

    Public ReadOnly Property Priority() As Integer
        Get
            Return pPriority
        End Get
    End Property

    Public ReadOnly Property AssignedTo() As Integer
        Get
            Return pAssignedTo
        End Get
    End Property

    Public ReadOnly Property TicketStatusID() As Integer
        Get
            Return pTicketStatusID
        End Get
    End Property

    Public ReadOnly Property DateSent() As DateTime
        Get
            Return pDateSent
        End Get
    End Property

    Public Sub New(ByVal MessageID As Integer, ByVal Priority As Integer, ByVal TicketStatusID As Integer)
        Me.pMessageID = MessageID
        Me.pPriority = Priority
        Me.pTicketStatusID = TicketStatusID
    End Sub

    Public Sub New(ByVal ticketID As Integer)
        Try
            Me.pSupportTicketID = ticketID
            Dim sqlGetTicket As New SqlCommand
            sqlGetTicket.CommandText = "SELECT * FROM tblSupportTicket WHERE SupportTicketID = " & ticketID
            Dim dtticket As New DataTable
            dtticket = cDBManager.GetDataTable(sqlGetTicket)
            Me.pMessageID = dtticket.Rows(0).Item("MessageID")
            Me.pPriority = dtticket.Rows(0).Item("Priority")
            If IsDBNull(dtticket.Rows(0).Item("AssignedTo")) Then
                Me.pAssignedTo = Nothing
            Else
                Me.pAssignedTo = dtticket.Rows(0).Item("AssignedTo")
            End If
            Me.pTicketStatusID = dtticket.Rows(0).Item("TicketStatusID")
            Me.pDateSent = dtticket.Rows(0).Item("DateSent")
        Catch ex As Exception
            cLogging.AddLog(String.Format("cTicket Init: on ID: {1} {0}", ex.Message, ticketID), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub
End Class
