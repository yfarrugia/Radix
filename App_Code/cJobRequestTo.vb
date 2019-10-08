Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class cJobRequestTo
    Inherits cJobManagement

    Private pJobRequstToID As Integer
    Private pJobRequestStatusID As Integer
    Private pMessageID As Integer
    Private pJobID As Integer
    Private pToUser As Integer
    Private pCC As Integer

#Region "Getters"
    Public ReadOnly Property JobRequestToID() As Integer
        Get
            Return pJobRequstToID
        End Get
    End Property

    Public ReadOnly Property JobRequestStatusID() As Integer
        Get
            Return pJobRequestStatusID
        End Get
    End Property

    Public ReadOnly Property MessageID() As Integer
        Get
            Return pMessageID
        End Get
    End Property

    Public ReadOnly Property JobID() As Integer
        Get
            Return pJobID
        End Get
    End Property

    Public ReadOnly Property ToUser() As Integer
        Get
            Return pToUser
        End Get
    End Property

    Public ReadOnly Property CC() As Integer
        Get
            Return pCC
        End Get
    End Property
#End Region

    Enum RequestStatus
        Interested = 1
        Not_Interested = 2
        Enquiring = 3
        Accepted = 4
        Denied = 5
        Pending_Confirmation = 6
        Pending_Interested = 7
    End Enum

    Public Sub New(ByVal _JobRequestID As Integer)
        Me.pJobRequstToID = _JobRequestID
        ParseDataTable(GetJobRequest())
    End Sub


    ''' <summary>
    ''' Parses the data table with fields: JobRequestToID, JobRequestStatusID, MessageID, JobID, ToUser, CC.
    ''' </summary>
    ''' <param name="datatable">The datatable.</param>
    Public Sub ParseDataTable(ByVal datatable As Data.DataTable)
        Try
            pJobRequstToID = datatable.Rows(0).Item("JobRequestToID")
            pJobRequestStatusID = datatable.Rows(0).Item("JobRequestStatusID")
            If IsDBNull(datatable.Rows(0).Item("MessageID")) Then
                pMessageID = Nothing
            Else
                pMessageID = datatable.Rows(0).Item("MessageID")
            End If
            pJobID = datatable.Rows(0).Item("JobID")
            pToUser = datatable.Rows(0).Item("ToUser")
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobRequestTo.ParseDataTable: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Gets the job request.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetJobRequest() As Data.DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT * FROM tblJobRequestTo WHERE JobRequestToID = {0}", pJobRequstToID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobRequestTo.GetJobRequest: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
