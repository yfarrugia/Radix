Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class cJobHistory
    Inherits cJobManagement

#Region "Private Attributes"

    Private pPreviousJobID As Integer
    Private pTitle As String
    Private pDescription As String
    Private pCompanyName As String
    Private pStartDate As Date
    Private pEndDate As Date
    Private pEmployeeID As Integer
    Private pIndustryID As Integer
    Private pOccupationID As Integer
    Private pJobTypeID As Integer

#End Region

#Region "Public Attributes"

    Public ReadOnly Property PreviousJobID() As Integer
        Get
            Return pPreviousJobID
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

    Public ReadOnly Property CompanyName() As String
        Get
            Return pCompanyName
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

    Public ReadOnly Property EmployeeID() As Integer
        Get
            Return pEmployeeID
        End Get
    End Property

    Public ReadOnly Property IndustryID() As Integer
        Get
            Return pIndustryID
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

#End Region

    Public Sub New(ByVal datatable As Data.DataTable)
        ParseDataTableDetails(datatable)
    End Sub

    Public Sub New()

    End Sub

    ''' <summary>
    ''' Parses the data table details with the following fields: PreviousJobID, Title
    ''' Description, CompanyName, StartDate, EndDate, EmployeeID, OccupationID, JobTypeID.
    ''' </summary>
    ''' <param name="dataTable">The data table.</param>
    Public Sub ParseDataTableDetails(ByVal dataTable As Data.DataTable)
        Try
            pPreviousJobID = dataTable.Rows(0).Item("PreviousJobID")
            pTitle = dataTable.Rows(0).Item("Title")
            pDescription = dataTable.Rows(0).Item("Description")
            pCompanyName = dataTable.Rows(0).Item("CompanyName")
            pStartDate = dataTable.Rows(0).Item("StartDate")
            pEndDate = dataTable.Rows(0).Item("EndDate")
            pEmployeeID = dataTable.Rows(0).Item("EmployeeID")
            pOccupationID = dataTable.Rows(0).Item("OccupationID")
            pJobTypeID = dataTable.Rows(0).Item("JobTypeID")
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobHistory.ParseDataTableDetails: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Gets the job history.
    ''' </summary>
    ''' <param name="EmployeeID">The employee ID.</param>
    ''' <returns></returns>
    Public Shared Function getJobHistory(ByVal EmployeeID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblPreviousJob.PreviousJobID,tblPreviousJob.Title, tblPreviousJob.Description, " & _
                                     "tblPreviousJob.CompanyName AS [Company Name], tblOccupation.Occupation, tblJobType.JobType as [Job Type], " & _
                                     "Convert(nvarchar(16),tblPreviousJob.StartDate,103) AS [Start Date], Convert(nvarchar(16),tblPreviousJob.EndDate,103) AS [End Date] " & _
                                     "FROM   tblPreviousJob INNER JOIN tblOccupation ON tblPreviousJob.OccupationID = tblOccupation.OccupationID " & _
                                     "INNER JOIN tblJobType ON tblPreviousJob.JobTypeID = tblJobType.JobTypeID " & _
                                     "WHERE tblPreviousJob.EmployeeID = '{0}'", EmployeeID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobHistory.getJobHistory: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Gets the job history by ID.
    ''' </summary>
    ''' <param name="PreviousJobID">The previous job ID.</param>
    ''' <returns></returns>
    Public Shared Function getJobHistoryByID(ByVal PreviousJobID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblPreviousJob.PreviousJobID,tblPreviousJob.Title, tblPreviousJob.Description, " & _
                                     "tblPreviousJob.CompanyName, tblPreviousJob.OccupationID, tblPreviousJob.IndustryID, " & _
                                     "tblPreviousJob.JobTypeID, tblPreviousJob.StartDate, tblPreviousJob.EndDate " & _
                                     "FROM tblPreviousJob " & _
                                     "WHERE tblPreviousJob.PreviousJobID ='{0}'", PreviousJobID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cJobHistory.getJobHistoryByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function



    ''' <summary>
    ''' Saves the previous job.
    ''' </summary>
    ''' <param name="Title">The title.</param>
    ''' <param name="Description">The description.</param>
    ''' <param name="CompanyName">Name of the company.</param>
    ''' <param name="StartDate">The start date.</param>
    ''' <param name="EndDate">The end date.</param>
    ''' <param name="EmployeeID">The employee ID.</param>
    ''' <param name="IndustryID">The industry ID.</param>
    ''' <param name="OccupationID">The occupation ID.</param>
    ''' <param name="JobTypeID">The job type ID.</param>
    Public Sub savePreviousJob(ByVal Title As String, _
                               ByVal Description As String, _
                               ByVal CompanyName As String, _
                               ByVal StartDate As Date, _
                               ByVal EndDate As Date, _
                               ByVal EmployeeID As Integer, _
                               ByVal IndustryID As Integer, _
                               ByVal OccupationID As Integer, _
                               ByVal JobTypeID As Integer)
        Try
            Dim savedJobID As Integer = cDBManager.SetReturnID(New SqlCommand(String.Format("INSERT INTO tblPreviousJob " & _
                                     "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", _
                                     Title, Description, CompanyName, StartDate, EndDate, EmployeeID, IndustryID, OccupationID, JobTypeID)))
            cLogging.AddLog(String.Format("Successfully Saved Previous Job: {0}", savedJobID), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
        Catch ex As Exception
            cLogging.AddLog("cJobHistory.savePreviousJob: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' Saves the previous job without end date.
    ''' </summary>
    ''' <param name="Title">The title.</param>
    ''' <param name="Description">The description.</param>
    ''' <param name="CompanyName">Name of the company.</param>
    ''' <param name="StartDate">The start date.</param>
    ''' <param name="EmployeeID">The employee ID.</param>
    ''' <param name="IndustryID">The industry ID.</param>
    ''' <param name="OccupationID">The occupation ID.</param>
    ''' <param name="JobTypeID">The job type ID.</param>
    Public Sub savePreviousJobWithoutEndDate(ByVal Title As String, _
                               ByVal Description As String, _
                               ByVal CompanyName As String, _
                               ByVal StartDate As Date, _
                               ByVal EmployeeID As Integer, _
                               ByVal IndustryID As Integer, _
                               ByVal OccupationID As Integer, _
                               ByVal JobTypeID As Integer)
        Try
            Dim savedJobID As Integer = cDBManager.SetReturnID(New SqlCommand(String.Format("INSERT INTO tblPreviousJob " & _
                                     "(Title, Description, CompanyName, StartDate, EmployeeID, IndustryID, OccupationID, JobTypeID) " & _
                                     "VALUES ('{0}', '{1}', '{2}', CONVERT(VARCHAR(10),'{3}',101), '{4}', '{5}', '{6}', '{7}')", _
                                     Title, Description, CompanyName, StartDate, EmployeeID, IndustryID, OccupationID, JobTypeID)))
            cLogging.AddLog(String.Format("Successfully Saved Previous Job: {0}", savedJobID), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
        Catch ex As Exception
            cLogging.AddLog("cJobHistory.savePreviousJobWithoutEndDate: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try

    End Sub


    ''' <summary>
    ''' Updates the previous job.
    ''' </summary>
    ''' <param name="Description">The description.</param>
    ''' <param name="CompanyName">Name of the company.</param>
    ''' <param name="StartDate">The start date.</param>
    ''' <param name="EndDate">The end date.</param>
    ''' <param name="OccupationID">The occupation ID.</param>
    ''' <param name="JobTypeID">The job type ID.</param>
    ''' <param name="PreviousJobID">The previous job ID.</param>
    Public Sub updatePreviousJob(ByVal Description As String, _
                                 ByVal CompanyName As String, _
                                 ByVal StartDate As Date, _
                                 ByVal EndDate As Date, _
                                 ByVal OccupationID As Integer, _
                                 ByVal JobTypeID As Integer, _
                                 ByVal PreviousJobID As Integer)
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblJob SET Description = '{0}', CompanyName  = '{1}', StartDate = '{2}', EndDate = '{3}', " & _
                                     "OccupationID = '{4}', JobTypeID = '{5}' WHERE PreviousJobID = '{6}'", _
                                     Description, CompanyName, StartDate, EndDate, OccupationID, Description, JobTypeID, PreviousJobID)))
        Catch ex As Exception
            cLogging.AddLog("cJobHistory.updatePreviousJob: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub
End Class
