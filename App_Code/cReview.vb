Imports System.Data.SqlClient
Imports System.Data
Imports System.Diagnostics
Imports Microsoft.VisualBasic

''' <summary>
''' Handles the managment of reviews
''' </summary>
Public Class cReview

    Private messageStoredID As Integer

    Private _toIDs As Integer()
    Public ReadOnly Property toIDs() As Integer()
        Get
            Return _toIDs
        End Get
    End Property

    Private _message As String
    Public ReadOnly Property Message() As String
        Get
            Return _message
        End Get
    End Property

    Private _rating As Byte
    Public ReadOnly Property rating() As Byte
        Get
            Return _rating
        End Get
    End Property

    Private _jobID As Integer
    Public ReadOnly Property jobID() As Integer
        Get
            Return _jobID
        End Get
    End Property

    ''' <summary>
    ''' Initializes a new instance of the <see cref="cReview" /> class.
    ''' </summary>
    ''' <param name="toID">To ID.</param>
    ''' <param name="message">The message.</param>
    ''' <param name="rating">The rating.</param>
    ''' <param name="jobID">The job ID.</param>
    Public Sub New(ByVal toID As Integer(), ByVal message As String, ByVal rating As Byte, ByVal jobID As Integer)
        MyBase.New()
        Me._toIDs = toID
        Me._message = message
        Me._rating = rating
        Me._jobID = jobID
    End Sub


    ''' <summary>
    ''' Gets the review report details.
    ''' </summary>
    ''' <param name="reviewID">The review ID.</param>
    ''' <returns></returns>
    Public Shared Function getReviewReportDetails(ByVal reviewID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblJob.Title AS [Job Title], tblJob.Description AS [Job Description], " & _
                             "tblReviewMessage.Comment AS [Review Comment], tblReviewMessage.Rating, tblReviewMessage.Stamp AS [Date Reviewed] " & _
                             "FROM tblJob " & _
                             "INNER JOIN tblReviewMessage ON tblJob.JobID = tblReviewMessage.JobID " & _
                             "INNER JOIN tblReviewTo ON tblReviewMessage.ReviewMessageID = tblReviewTo.ReviewMessageID " & _
                             "WHERE (tblReviewTo.ReviewToID = {0})", reviewID)))
        Catch ex As Exception
            cLogging.AddLog("getReviewReportDetails: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Stores the reivew to.
    ''' </summary>
    ''' <returns></returns>
    Private Function storeReivewTo() As Boolean
        Try
            For index As Integer = 0 To _toIDs.Length - 1
                cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblReviewTo " & _
                             "(ReviewMessageID,EmployeeID) " & _
                             "VALUES({0}, {1})", messageStoredID, toIDs(index))))

                cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblJobRequestTo SET  isReviewed = 1 " & _
                             "WHERE (ToUser = {0}) AND (JobID = {1})", toIDs(index), jobID)))

                cLogging.AddLog("Review Stored", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
            Next
            Return True
        Catch ex As Exception
            cLogging.AddLog("storeReivewTo: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Stores the review message.
    ''' </summary>
    Public Sub storeReviewMessage()
        Try
            messageStoredID = cDBManager.SetReturnID(New SqlCommand(String.Format("INSERT INTO tblReviewMessage " & _
                             "(Comment, Rating, JobID, Stamp) " & _
                             "VALUES('{0}',{1},{2},GETDATE())", Message, rating, jobID)))
            storeReivewTo()
        Catch ex As Exception
            cLogging.AddLog("storeReviewMessage: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Reports the review.
    ''' </summary>
    ''' <param name="reviewID">The review ID.</param>
    ''' <param name="reportMessage">The report message.</param>
    Public Shared Sub reportReview(ByVal reviewID As Integer, ByVal reportMessage As String)
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblReviewTo " & _
                             "SET isReported= 1, reportMessage = '{1}' " & _
                             "WHERE reviewToID = {0}", reviewID, reportMessage)))
        Catch ex As Exception
            cLogging.AddLog("reportReview: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Gets the reported reviews.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function getReportedReviews() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT tblReviewTo.ReviewToID, tblUser.Name + ' ' + tblUser.Surname AS [Full Name], " & _
                             "tblJob.Title AS [Job Title], tblJob.Description AS [Job Description], tblReviewMessage.Comment AS [Review Comment], " & _
                             "tblReviewMessage.Rating, tblReviewTo.reportMessage AS [Report Message] " & _
                             "FROM tblReviewTo " & _
                             "INNER JOIN tblReviewMessage ON tblReviewTo.ReviewMessageID = tblReviewMessage.ReviewMessageID " & _
                             "INNER JOIN tblJob ON tblReviewMessage.JobID = tblJob.JobID " & _
                             "INNER JOIN tblUser ON tblReviewTo.EmployeeID = tblUser.UserID " & _
                             "WHERE (tblReviewTo.isReported = 1) AND (tblReviewTo.flagedNoShow = 0)"))
        Catch ex As Exception
            cLogging.AddLog("reportReview: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
