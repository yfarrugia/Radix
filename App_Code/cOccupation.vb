Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class cOccupation
    Inherits cPreferredJob

    ''' <summary>
    ''' Gets all occupations.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetAllOccupations() As Data.DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT Occupation,OccupationID FROM tblOccupation"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cOccupation.GetAllOccupations {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets all occupations by industry.
    ''' </summary>
    ''' <param name="JobIndustryID">The job industry ID.</param>
    ''' <returns></returns>
    Public Shared Function GetAllOccupationsByIndustry(ByVal JobIndustryID As Integer) As Data.DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand( _
                                           String.Format("SELECT tblOccupation.OccupationID, tblOccupation.Occupation " & _
                                "FROM tblJobIndustry " & _
                                "INNER JOIN tblOccupation ON tblJobIndustry.JobIndustryID = tblOccupation.JobIndustryID " & _
                                "WHERE tblJobIndustry.JobIndustryID =  '{0}'", JobIndustryID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cOccupation.GetAllOccupationsByIndustry {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the occupation ID.
    ''' </summary>
    ''' <param name="Occupation">The occupation.</param>
    ''' <returns></returns>
    Public Shared Function getOccupationID(ByVal Occupation As String) As Integer
        Try
            Dim occID As Integer = Convert.ToInt64(cDBManager.GetExecuteScalar( _
                                                   New SqlCommand(String.Format("SELECT OccupationID FROM tblOccupation WHERE Occupation = '{0}'", Occupation))))
            Return occID
        Catch ex As Exception
            cLogging.AddLog(String.Format("cOccupation.getOccupationID {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
