Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
''' Manages the Preferred Jobs
''' </summary>
Public Class cPreferredJob
    Inherits cJobManagement

    ''' <summary>
    ''' Gets the job preference by employee ID.
    ''' </summary>
    ''' <param name="EmployeeID">The employee ID.</param>
    ''' <returns></returns>
    Public Shared Function getJobPreferenceByEmployeeID(ByVal EmployeeID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblPreferredJob.PreferredJobID, tblPreferredJob.EmployeeID, " & _
                             "tblJobType.JobType, tblJobIndustry.JobIndustry, tblOccupation.Occupation " & _
                             "FROM tblPreferredJob " & _
                             "INNER JOIN tblJobType ON tblPreferredJob.JobTypeID = tblJobType.JobTypeID " & _
                             "INNER JOIN tblJobIndustry ON tblPreferredJob.JobIndustryID = tblJobIndustry.JobIndustryID " & _
                             "INNER JOIN tblOccupation ON tblPreferredJob.OccupationID = tblOccupation.OccupationID AND tblJobIndustry.JobIndustryID = tblOccupation.JobIndustryID " & _
                             "WHERE tblPreferredJob.EmployeeID = '{0}'", EmployeeID)))
        Catch ex As Exception
            cLogging.AddLog("getJobPreferenceByEmployeeID: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Deletes the job preference.
    ''' </summary>
    ''' <param name="PreferredJobID">The preferred job ID.</param>
    Public Shared Sub deleteJobPreference(ByVal PreferredJobID As Integer)
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("DELETE FROM tblPreferredJob WHERE PreferredJobID = '{0}'", PreferredJobID)))
        Catch ex As Exception
            cLogging.AddLog("deleteJobPreference: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Saves the preferred job.
    ''' </summary>
    ''' <param name="JobIndustryID">The job industry ID.</param>
    ''' <param name="OccupationID">The occupation ID.</param>
    ''' <param name="JobTypeID">The job type ID.</param>
    ''' <param name="EmployeeID">The employee ID.</param>
    Public Shared Sub savePreferredJob(ByVal JobIndustryID As Integer, ByVal OccupationID As Integer, ByVal JobTypeID As Integer, ByVal EmployeeID As Integer)
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblPreferredJob " & _
                             "VALUES ('{0}','{1}','{2}','{3}',GETDATE())", JobIndustryID, OccupationID, JobTypeID, EmployeeID)))
            cLogging.AddLog("Successfully Saved Preferred Job", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
        Catch ex As Exception
            cLogging.AddLog("savePreferredJob: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    Public Shared Function checkExisting(ByVal OccupationID As Integer, ByVal JobTypeID As Integer, ByVal EmployeeID As Integer) As Integer
        Try
            Dim Count As Integer
            Count = cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT COUNT(PreferredJobID) FROM tblPreferredJob WHERE (OccupationID =  '{0}') AND (EmployeeID =  '{1}') AND (JobTypeID =  '{2}')", OccupationID, EmployeeID, JobTypeID)))
            Return Count
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
