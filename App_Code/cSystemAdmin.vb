Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Diagnostics

''' <summary>
''' Manages all system admin action
''' </summary>
Public Class cSystemAdmin
    Inherits cUser

    ''' <summary>
    ''' Gets all users.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function getAllUsers() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT tblUser.Name + ' ' + tblUser.Surname AS [Full Name], tblUser.Gender, " & _
                             "tblCountry.Country, " & _
                             "tblNationality.Nationality, tblUser.EmailAddress AS [E-Mail Address], " & _
                             "tblUser.isEnabled, tblUserType.Type AS [Account Type], tblUser.Stamp AS [Registration Date]" & _
                             "FROM tblUser " & _
                             "INNER JOIN tblCountry ON tblUser.CountryID = tblCountry.CountryID " & _
                             "INNER JOIN tblNationality ON tblUser.NationalityID = tblNationality.NationalityID " & _
                             "INNER JOIN tblUserType ON tblUser.UserTypeID = tblUserType.UserTypeID"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cSystemAdmin.getAllUsers: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the flagged users.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function getFlaggedUsers() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT " & _
                             "(SELECT Name + ' ' + Surname AS [Name_1] FROM tblUser WHERE (UserID = tblFlaggedUsers.ReporterUserId)) AS Reporter, " & _
                             "(SELECT Name + ' ' + Surname AS [Name_2] FROM tblUser AS tblUser_2 WHERE (UserID = tblFlaggedUsers.ReportedUserId)) AS [Reported User], " & _
                             "tblFlaggedUsers.ReportMessage AS [Report Message], tblFlagStatus.FlagStatus AS [Flag Status]" & _
                             "FROM tblFlaggedUsers INNER JOIN tblFlagStatus ON tblFlaggedUsers.FlagStatusId = tblFlagStatus.FlagStatusId"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("getAllUsers.getFlaggedUsers: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
