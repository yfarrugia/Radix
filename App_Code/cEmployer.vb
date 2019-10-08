'TODO: VARS AND EXCETIONS
Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class cEmployer
    Inherits cUser

    Private _name, _surname, _dob, _address, _
     _streetAddress, _town, _state, _
     _postCode, _telephone, _email, _
     _username, _password As String
    Private _gender As Boolean
    Private _nationalityID As Integer

#Region "Private Attributes"

    Private pEmployerId As Integer

#End Region

#Region "Public Attributes"

    Public ReadOnly Property EmployeeId() As Integer
        Get
            Return pEmployerId
        End Get
    End Property

#End Region


    ''' <summary>
    ''' Gets the finished jobs.
    ''' </summary>
    ''' <param name="userID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function getFinishedJobs(ByVal userID As Integer) As DataTable
        Dim sqlcmd As New StringBuilder
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblJob.JobID, tblJob.Title AS [Job Title], tblJob.Description AS [Job Description], tblCompany.CompanyName AS [Company Name], tblOccupation.Occupation, tblJobType.JobType AS [Job Type] " & _
                                            "FROM tblJob INNER JOIN tblJobType ON tblJob.JobTypeID = tblJobType.JobTypeID INNER JOIN tblCompany ON tblJob.CompanyID = tblCompany.CompanyID INNER JOIN tblOccupation ON tblJob.OccupationID = tblOccupation.OccupationID " & _
                                            "WHERE (tblJob.EndDate < GETDATE()) AND (tblCompany.EmployerID = {0})" & _
                                            "AND ((SELECT COUNT(*) AS notReviewedCount FROM tblJobRequestTo AS tblJobRequestTo_1 WHERE (isReviewed = 0) AND (JobID = tblJob.JobID)) > 0)", userID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployer.getFinishedJobs: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try

    End Function

End Class
