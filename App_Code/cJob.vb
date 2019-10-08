Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Data


Public Class cJob
    Inherits cJobManagement
#Region "Private Attributes"

    Private pJobID As Integer
    Private pTitle As String
    Private pDescription As String
    Private pRequirements As String
    Private pCompanyID As Integer
    Private pDatePosted As Date
    Private pClosingDate As Date
    Private pStartDate As Date
    Private pEndDate As Date
    Private pOccupationID As Integer
    Private pJobTypeID As Integer
    Private pNoRequestedEmployees As Integer
    Private pJobStatusID As Integer

#End Region

#Region "Public Attributes"

    Public ReadOnly Property JobID() As Integer
        Get
            Return pJobID
        End Get
    End Property

    Public ReadOnly Property Title() As String
        Get
            Return pTitle
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return pDescription
        End Get
    End Property

    Public ReadOnly Property Requirments() As String
        Get
            Return pRequirements

        End Get
    End Property

    Public ReadOnly Property CompanyID() As String
        Get
            Return pCompanyID
        End Get
    End Property

    Public ReadOnly Property DatePosted() As Date
        Get
            Return pDatePosted
        End Get
    End Property

    Public ReadOnly Property ClosingDate() As Date
        Get
            Return pClosingDate
        End Get
    End Property

    Public ReadOnly Property StartDate() As Date
        Get
            Return pStartDate
        End Get
    End Property

    Public ReadOnly Property EndDate() As Date
        Get
            Return pEndDate
        End Get
    End Property

    Public ReadOnly Property OccupationID() As Integer
        Get
            Return pOccupationID
        End Get
    End Property

    Public ReadOnly Property JobTypeID() As Integer
        Get
            Return pJobTypeID
        End Get
    End Property

    Public ReadOnly Property NoRequestedEmployees() As Integer
        Get
            Return pNoRequestedEmployees
        End Get
    End Property

    Public ReadOnly Property JobStatusID() As Integer
        Get
            Return pJobStatusID
        End Get
    End Property



#End Region


    Public Sub New(ByVal datatable As Data.DataTable)
        ParseDataTableDetails(datatable)
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(ByVal JobID As Integer, _
                   ByVal Title As String, _
                   ByVal Description As String, _
                   ByVal Requirements As String, _
                   ByVal CompanyID As Integer, _
                   ByVal DatePosted As Date, _
                   ByVal ClosingDate As Date, _
                   ByVal StartDate As Date, _
                   ByVal EndDate As Date, _
                   ByVal OccupationID As Integer, _
                   ByVal JobTypeID As Integer, _
                   ByVal NoRequestedEmployees As Integer, _
                   ByVal JobStatusID As Integer)

        Me.pTitle = Title
        Me.pDescription = Description
        Me.pRequirements = Requirements
        Me.pCompanyID = CompanyID
        Me.pDatePosted = DatePosted
        Me.pClosingDate = ClosingDate
        Me.pStartDate = StartDate
        Me.pEndDate = EndDate
        Me.pOccupationID = OccupationID
        Me.pJobTypeID = JobTypeID
        Me.pNoRequestedEmployees = NoRequestedEmployees
        Me.pJobStatusID = JobStatusID
    End Sub

    Public Sub New(ByVal JobID As Integer)
        ParseDataTableDetails(getJobByID(JobID))
    End Sub

    ''' <summary>
    ''' Parses the data table details with the following values: 
    ''' JobID, Title, Description, Requirements, CompanyID, DatePosted, 
    ''' ClosingDate, StartDate, EndDate, OccupationID, JobTypeID, NoRequestedEmployees, JobStatusID.
    ''' </summary>
    ''' <param name="dataTable">The data table.</param>
    Public Sub ParseDataTableDetails(ByVal dataTable As Data.DataTable)
        Try
            pJobID = dataTable.Rows(0).Item("JobID")
            pTitle = dataTable.Rows(0).Item("Title")
            pDescription = dataTable.Rows(0).Item("Description")
            pRequirements = dataTable.Rows(0).Item("Requirements")
            pCompanyID = dataTable.Rows(0).Item("CompanyID")
            pDatePosted = dataTable.Rows(0).Item("DatePosted")
            pClosingDate = dataTable.Rows(0).Item("ClosingDate")
            pStartDate = dataTable.Rows(0).Item("StartDate")
            pEndDate = dataTable.Rows(0).Item("EndDate")
            pOccupationID = dataTable.Rows(0).Item("OccupationID")
            pJobTypeID = dataTable.Rows(0).Item("JobTypeID")
            pNoRequestedEmployees = dataTable.Rows(0).Item("NoRequestedEmployees")
            pJobStatusID = dataTable.Rows(0).Item("JobStatusID")
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.ParseDataTableDetails: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Saves the job.
    ''' </summary>
    ''' <param name="Title">The title.</param>
    ''' <param name="Description">The description.</param>
    ''' <param name="Requirements">The requirements.</param>
    ''' <param name="CompanyID">The company ID.</param>
    ''' <param name="DatePosted">The date posted.</param>
    ''' <param name="ClosingDate">The closing date.</param>
    ''' <param name="StartDate">The start date.</param>
    ''' <param name="EndDate">The end date.</param>
    ''' <param name="OccupationID">The occupation ID.</param>
    ''' <param name="JobTypeID">The job type ID.</param>
    ''' <param name="NoRequestedEmployees">The no requested employees.</param>
    ''' <param name="JobStatusID">The job status ID.</param>
    ''' <returns></returns>
    Public Function saveJob(ByVal Title As String, _
                            ByVal Description As String, _
                            ByVal Requirements As String, _
                            ByVal CompanyID As Integer, _
                            ByVal DatePosted As Date, _
                            ByVal ClosingDate As Date, _
                            ByVal StartDate As Date, _
                            ByVal EndDate As Date, _
                            ByVal OccupationID As Integer, _
                            ByVal JobTypeID As Integer, _
                            ByVal NoRequestedEmployees As Integer, _
                            ByVal JobStatusID As Integer) As Integer
        Try
            Dim returnJobID As Integer = -1
            returnJobID = cDBManager.SetReturnID(New SqlCommand(String.Format("INSERT INTO tblJob VALUES ('{0}', '{1}', '{2}', '{3}', " & _
                                            "CONVERT(VARCHAR(10), '{4}', 101), CONVERT(VARCHAR(10), '{5}', 101), " & _
                                            "CONVERT(VARCHAR(10), '{6}', 101), CONVERT(VARCHAR(10), '{7}', 101), '{8}', '{9}', '{10}', '{11}', 0)", _
                                            Title, Description, Requirements, CompanyID, DatePosted, ClosingDate, StartDate, EndDate, _
                                            OccupationID, JobTypeID, NoRequestedEmployees, JobStatusID)))
            cLogging.AddLog(String.Format("Successfully Saved Job Post {0}", returnJobID), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
            Return returnJobID
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.saveJob: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Updates the job.
    ''' </summary>
    ''' <param name="Description">The description.</param>
    ''' <param name="Requirements">The requirements.</param>
    ''' <param name="ClosingDate">The closing date.</param>
    ''' <param name="StartDate">The start date.</param>
    ''' <param name="EndDate">The end date.</param>
    ''' <param name="OccupationID">The occupation ID.</param>
    ''' <param name="JobTypeID">The job type ID.</param>
    ''' <param name="NoRequestedEmployees">The no requested employees.</param>
    ''' <param name="JID">The JID.</param>
    Public Sub updateJob(ByVal Description As String, _
                         ByVal Requirements As String, _
                         ByVal ClosingDate As Date, _
                         ByVal StartDate As Date, _
                         ByVal EndDate As Date, _
                         ByVal OccupationID As Integer, _
                         ByVal JobTypeID As Integer, _
                         ByVal NoRequestedEmployees As Integer, _
                         ByVal JID As Integer)

        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblJob SET Description = '{0}', Requirements = '{1}', " & _
                                            "ClosingDate = '{2}', StartDate = '{3}', EndDate = '{4}', OccupationID = '{5}', " & _
                                            "JobTypeID = '{6}', NoRequestedEmployees  = '{7}' " & _
                                            "WHERE JobID = '{8}'", _
                                            Description, Requirements, ClosingDate, StartDate, EndDate, OccupationID, _
                                            JobTypeID, NoRequestedEmployees, JID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.updateJob: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Gets the job by ID.
    ''' </summary>
    ''' <param name="JobID">The job ID.</param>
    ''' <returns></returns>
    Public Shared Function getJobByID(ByVal JobID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT * from tblJob WHERE JobID = '{0}'", JobID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.getJobByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    'todo: NOT USED
    ''' <summary>
    ''' Gets the job status.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function getJobStatus() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT JobStatus FROM tblJobStatus ORDER BY JobStatus ASC"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.getJobStatus: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    'TODO: NOT USED
    ''' <summary>
    ''' Gets the job status ID.
    ''' </summary>
    ''' <param name="JobStatus">The job status.</param>
    ''' <returns></returns>
    Public Shared Function getJobStatusID(ByVal JobStatus As String) As Integer
        Try
            Dim JobStatusId As Integer = -1
            JobStatusId = Convert.ToInt64(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT JobStatusID from tblJobStatus WHERE JobStatus = '{0}'", JobStatus))))
            Return JobStatusId
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.getJobStatusID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the job types.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function getJobTypes() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT JobType, JobTypeID FROM tblJobType ORDER BY JobType ASC"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.getJobTypes: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    'TODO: NOT USED
    ''' <summary>
    ''' Gets the job type ID.
    ''' </summary>
    ''' <param name="JobType">Type of the job.</param>
    ''' <returns></returns>
    Public Shared Function getJobTypeID(ByVal JobType As String) As Integer
        Try
            Dim JobTypeId As Integer = -1
            JobTypeId = Convert.ToInt64(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT JobTypeID from tblJobType WHERE JobType = '{0}'", JobType))))
            Return JobTypeId
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.getJobTypeID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    'TODO NOT USED
    Public Shared Function getJobStatusByID(ByVal _JobStatusID As Integer) As String

        Try

            Dim command As New SqlCommand
            Dim JobStatus As String
            command.CommandText = "SELECT JobStatus from tblJobStatus WHERE JobStatusID = '" & _JobStatusID & "'"

            JobStatus = Convert.ToInt32(cDBManager.GetExecuteScalar(command))

            Return JobStatus

        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.getJobStatusByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex

        End Try


    End Function

    ''' <summary>
    ''' Gets the pending jobs by employer.
    ''' </summary>
    ''' <param name="EmployerID">The employer ID.</param>
    ''' <returns></returns>
    Public Shared Function getPendingJobsByEmployer(ByVal EmployerID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblJob.JobID, tblJob.Title, " & _
                                        "(CONVERT(varchar(16), tblJob.ClosingDate, 103)) AS [Date Created], " & _
                                        "tblOccupation.Occupation, tblJobType.JobType, tblCompany.CompanyName " & _
                                        "FROM tblJob " & _
                                        "INNER JOIN tblJobStatus ON tblJob.JobStatusID = tblJobStatus.JobStatusID " & _
                                        "INNER JOIN tblOccupation ON tblOccupation.OccupationID = tblJob.OccupationID " & _
                                        "INNER JOIN tblJobType ON tblJob.JobTypeID = tblJobType.JobTypeID " & _
                                        "INNER JOIN tblCompany ON tblJob.CompanyID = tblCompany.CompanyID " & _
                                        "WHERE (tblJobStatus.JobStatus = 'Created') AND (tblCompany.EmployerID = '{0}')", EmployerID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.getPendingJobsByEmployer: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the top pending jobs by employer.
    ''' </summary>
    ''' <param name="EmployerID">The employer ID.</param>
    ''' <returns></returns>
    Public Shared Function getTopPendingJobsByEmployer(ByVal EmployerID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT TOP (10) tblJob.JobID, tblJob.Title, tblJob.ClosingDate, " & _
                                    "tblOccupation.Occupation, tblJobType.JobType, tblCompany.CompanyName " & _
                                    "FROM tblJob " & _
                                    "INNER JOIN tblJobStatus ON tblJob.JobStatusID = tblJobStatus.JobStatusID " & _
                                    "INNER JOIN tblOccupation ON tblOccupation.OccupationID = tblJob.OccupationID " & _
                                    "INNER JOIN tblJobType ON tblJob.JobTypeID = tblJobType.JobTypeID " & _
                                    "INNER JOIN tblCompany ON tblJob.CompanyID = tblCompany.CompanyID " & _
                                    "WHERE (tblJobStatus.JobStatus = 'Created') AND (tblCompany.EmployerID = '{0}')", EmployerID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.getTopPendingJobsByEmployer: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the job details by job ID.
    ''' </summary>
    ''' <param name="JobID">The job ID.</param>
    ''' <returns></returns>
    Public Shared Function getJobDetailsByJobID(ByVal JobID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblJob.JobID, tblJob.Title, tblJob.CompanyID, tblJob.Description, " & _
                                                                "tblJob.Requirements, tblJob.DatePosted, tblJob.ClosingDate, tblJob.StartDate, " & _
                                                                "tblJob.EndDate, tblJob.NoRequestedEmployees, tblOccupation.Occupation, tblJobIndustry.JobIndustry," & _
                                                                "tblJobType.JobType, tblJobStatus.JobStatus " & _
                                                                "FROM tblJob " & _
                                                                "INNER JOIN tblOccupation ON tblJob.OccupationID = tblOccupation.OccupationID " & _
                                                                "INNER JOIN tblJobIndustry ON tblOccupation.JobIndustryId = tblJobIndustry.JobIndustryId " & _
                                                                "INNER JOIN tblJobType ON tblJob.JobTypeID = tblJobType.JobTypeID " & _
                                                                "INNER JOIN tblJobStatus ON tblJob.JobStatusID = tblJobStatus.JobStatusID " & _
                                                                "WHERE JobID = '{0}'", JobID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.getJobDetailsByJobID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    'TODO: NOT USED
    Private Shared Function GetJobRequestStatusID(ByVal Status As String) As Integer
        Dim sqlGetReqID As New SqlCommand
        sqlGetReqID.CommandText = "SELECT JobRequestStatusID FROM tblJobRequestStatus WHERE JobRequestStatus = N'" & Status & "'"
        Dim objReqStat As Object = cDBManager.GetExecuteScalar(sqlGetReqID)
        Try
            Dim iReqStatID As Integer = Convert.ToInt64(objReqStat)
            Return iReqStatID
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.GetJobRequestStatusID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Stores the job requests.
    ''' </summary>
    ''' <param name="EmployeeIDs">The employee I ds.</param>
    ''' <param name="JobID">The job ID.</param>
    ''' <returns></returns>
    Public Shared Function StoreJobRequests(ByVal EmployeeIDs As Integer(), ByVal JobID As Integer) As Integer
        Dim _rowsEffected As Integer
        Try
            For Each EmpID As Integer In EmployeeIDs
                If cJobManagement.checkIfEmployeeAlreadyAssociated(EmpID, JobID) = False Then
                    _rowsEffected += cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblJobRequestTo VALUES({0}, NULL, {1}, {2}, GETDATE(), 'False')", _
                                      Convert.ToInt16(cJobRequestTo.RequestStatus.Pending_Interested), JobID, EmpID)))
                Else
                    _rowsEffected = -1
                    '    'TODO: explain why the same....???
                    '    'sqlJobReqStore.CommandText = "INSERT INTO tblJobRequestTo VALUES(" & cJobRequestTo.RequestStatus.Pending_Interested & ", NULL, " & JobID & ", " & EmpID & ", GETDATE(), 'False')"
                    '    _rowsEffected += cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblJobRequestTo VALUES({0}, NULL, {1}, {2}, GETDATE(), 'False')", _
                    '                      Convert.ToInt16(cJobRequestTo.RequestStatus.Pending_Interested), JobID, EmpID)))
                End If
            Next

            Return _rowsEffected
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.StoreJobRequests: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employees by job.
    ''' </summary>
    ''' <param name="JobID">The job ID.</param>
    ''' <returns></returns>
    Public Shared Function GetEmployeesByJob(ByVal JobID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblUser.UserID, tblUser.Name + ' ' + tblUser.Surname AS [Employee Name], " & _
                                "tblJobRequestStatus.JobRequestStatus " & _
                                "FROM tblEmployee " & _
                                "INNER JOIN tblUser ON tblUser.UserID = tblEmployee.EmployeeID " & _
                                "INNER JOIN tblJobRequestTo ON tblEmployee.EmployeeID = tblJobRequestTo.ToUser " & _
                                "INNER JOIN tblJobRequestStatus ON tblJobRequestTo.JobRequestStatusID = tblJobRequestStatus.JobRequestStatusID " & _
                                "WHERE(tblJobRequestTo.JobID = " & JobID & ")", JobID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.GetEmployeesByJob: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the job requestsfor user.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function GetJobRequestsforUser(ByVal UserID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblJobRequestTo.JobRequestToID, tblJob.Title, tblCompany.CompanyName, tblJob.StartDate AS [Job Start Date], tblJobRequestStatus.JobRequestStatus " & _
                                "FROM tblJobRequestTo " & _
                                "INNER JOIN tblJob ON tblJobRequestTo.JobID = tblJob.JobID " & _
                                "INNER JOIN tblCompany ON tblJob.CompanyID = tblCompany.CompanyID " & _
                                "INNER JOIN tblJobRequestStatus ON tblJobRequestTo.JobRequestStatusID = tblJobRequestStatus.JobRequestStatusID " & _
                                "WHERE tblJobRequestTo.ToUser = {0} AND NOT (tblJobRequestTo.JobRequestStatusID = {1})", UserID, Convert.ToInt16(cJobRequestTo.RequestStatus.Not_Interested))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.GetJobRequestsforUser: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the top job requestsfor user.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function GetTopJobRequestsforUser(ByVal UserID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT TOP (8) tblJobRequestTo.JobRequestToID, tblJob.Title, tblCompany.CompanyName, tblJob.StartDate AS [Job Start Date], tblJobRequestStatus.JobRequestStatus " & _
                                "FROM tblJobRequestTo " & _
                                "INNER JOIN tblJob ON tblJobRequestTo.JobID = tblJob.JobID " & _
                                "INNER JOIN tblCompany ON tblJob.CompanyID = tblCompany.CompanyID " & _
                                "INNER JOIN tblJobRequestStatus ON tblJobRequestTo.JobRequestStatusID = tblJobRequestStatus.JobRequestStatusID " & _
                                "WHERE tblJobRequestTo.ToUser = ", UserID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.GetTopJobRequestsforUser: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Checks the number unread jobs.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function CheckNumberUnreadJobs(ByVal UserID As Integer) As Integer
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT JobRequestToID FROM tblJobRequestTo WHERE ToUser = {0} AND JobRequestStatusID = 7", UserID))).Rows.Count
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJob.CheckNumberUnreadJobs: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
