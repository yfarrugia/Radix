Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class cJobManagement


    ''' <summary>
    ''' Updates the request status.
    ''' </summary>
    ''' <param name="RequestStatus">The request status.</param>
    ''' <param name="JobRequestID">The job request ID.</param>
    ''' <returns></returns>
    Public Shared Function UpdateRequestStatus(ByVal RequestStatus As cJobRequestTo.RequestStatus, ByVal JobRequestID As Integer) As Integer
        Try
            Return cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblJobRequestTo SET JobRequestStatusID = {0} WHERE jobRequestToID = {1}", Convert.ToInt16(RequestStatus), JobRequestID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobManagement.UpdateRequestStatus: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the request details.
    ''' </summary>
    ''' <param name="requestID">The request ID.</param>
    ''' <returns></returns>
    Public Shared Function GetRequestDetails(ByVal requestID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblJobRequestTo.JobRequestToID, tblJob.Title, tblJob.Description, tblJob.Requirements, tblCompany.CompanyName, tblJob.DatePosted AS [Date Posted], tblJob.ClosingDate AS [Closing Date], tblJob.StartDate AS [Start Date], tblJob.EndDate AS [End Date], tblOccupation.Occupation, tblJobType.JobType " & _
                                "FROM tblJobRequestTo " & _
                                "INNER JOIN tblJob ON tblJobRequestTo.JobID = tblJob.JobID " & _
                                "INNER JOIN tblCompany ON tblJob.CompanyID = tblCompany.CompanyID " & _
                                "INNER JOIN tblOccupation ON tblJob.OccupationID = tblOccupation.OccupationID " & _
                                "INNER JOIN tblJobType ON tblJob.JobTypeID = tblJobType.JobTypeID " & _
                                "WHERE tblJobRequestTo.JobrequestToID = {0}", requestID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobManagement.GetRequestDetails: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Associates the message.
    ''' </summary>
    ''' <param name="MessageID">The message ID.</param>
    ''' <param name="JobRequest">The job request.</param>
    ''' <returns></returns>
    Public Shared Function AssociateMessage(ByVal MessageID As Integer, ByVal JobRequest As Integer) As Integer
        Try
            Return cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblJobRequestTo SET MessageID = {0} WHERE JobRequestToID = {1}", _
                                                                           MessageID, JobRequest)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobManagement.AssociateMessage: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the open jobs for employer.
    ''' </summary>
    ''' <param name="Employer">The employer.</param>
    ''' <returns></returns>
    Public Shared Function GetOpenJobsForEmployer(ByVal Employer As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblJob.JobID, tblJob.Title, tblCompany.CompanyName, tblJob.DatePosted, tblJob.ClosingDate, tblJob.StartDate, tblJob.EndDate, tblJobStatus.JobStatus " & _
                                 "FROM tblJob " & _
                                 "INNER JOIN tblCompany ON tblJob.CompanyID = tblCompany.CompanyID " & _
                                 "INNER JOIN tblJobStatus ON tblJob.JobstatusID = tblJobStatus.JobStatusID " & _
                                 "WHERE tblCompany.EmployerID = {0} AND (tblJob.EndDate > GETDATE()) AND (tblJob.StartDate < GETDATE())", Employer)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobManagement.GetOpenJobsForEmployer: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets all jobs for employer.
    ''' </summary>
    ''' <param name="Employer">The employer.</param>
    ''' <returns></returns>
    Public Shared Function GetAllJobsForEmployer(ByVal Employer As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblJob.JobID, tblJob.Title, tblCompany.CompanyName, tblJob.DatePosted, tblJob.ClosingDate, tblJob.StartDate, tblJob.EndDate, tblJobStatus.JobStatus " & _
                                     "FROM tblJob " & _
                                     "INNER JOIN tblCompany ON tblJob.CompanyID = tblCompany.CompanyID " & _
                                     "INNER JOIN tblJobStatus ON tblJob.JobstatusID = tblJobStatus.JobStatusID " & _
                                     "WHERE tblCompany.EmployerID = {0}", Employer)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobManagement.GetAllJobsForEmployer: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the interested employees for a job.
    ''' </summary>
    ''' <param name="JobID">The job ID.</param>
    ''' <returns></returns>
    Public Shared Function GetInterestedEmployeesForJob(ByVal JobID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblJobRequestTo.JobRequestToID, tblUser.Name + ' ' + tblUser.Surname AS [Employee Name], tblJobRequestStatus.JobRequestStatus " & _
                                      "FROM tblJobRequestTo " & _
                                      "INNER JOIN tblUser ON tblJobRequestTo.ToUser = tblUser.UserID " & _
                                      "INNER JOIN tblJobRequestStatus ON tblJobRequestTo.JobRequestStatusID = tblJobRequestStatus.JobRequestStatusID " & _
                                      "WHERE tblJobRequestTo.JobID = {0} AND tblJobRequestTo.JobRequestStatusID = {1}", JobID, Convert.ToInt16(cJobRequestTo.RequestStatus.Interested))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobManagement.GetInterestedEmployeesForJob: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function


    Public Shared Function checkIfEmployeeAlreadyAssociated(ByVal employeeID As Integer, ByVal jobID As Integer) As Boolean
        Try
            Return Convert.ToInt32(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("select count(JobRequestToID) from tblJobRequestTo where ToUser = {0} and JobID = {1}", employeeID, jobID))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobManagement.checkIfEmployeeAlreadyAssociated: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
        End Try
    End Function
End Class
