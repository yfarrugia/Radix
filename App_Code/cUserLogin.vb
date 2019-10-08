Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data


Public Class cUserLogin
    ''' <summary>
    ''' Gets the user details.
    ''' </summary>
    ''' <param name="Username">The username.</param>
    ''' <returns></returns>
    Public Shared Function getUserDetails(ByVal Username As String) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblUser.UserID, tblUser.Name, tblUserType.Type, tblUser.isEnabled, tblUser.DOB " & _
                                                "FROM tblUser INNER JOIN tblUserType ON tblUser.UserTypeID = tblUserType.UserTypeID " & _
                                                "WHERE Username = '{0}'", Username)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cUserLogin.getUserDetails {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
