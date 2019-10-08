'TODO: VARS AND EXCETIONS
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.DataColumn

Public Class cEmployee
    Inherits cUser

    Private _name, _surname, _dob, _address, _
        _streetAddress, _town, _state, _
        _postCode, _telephone, _email, _
        _username, _password As String
    Private _gender As Boolean
    Private _nationalityID As Integer



#Region "Private Attributes"

    Private pEmployeeId As Integer
    Private pPassportNo As String
    Private pIsEmployed As Boolean

    Private pIsSeeking As Boolean
    Private pCenterID As Integer
    Private pSponsored As Boolean

#End Region


#Region "Public Attributes"

    Public ReadOnly Property EmployeeId() As Integer
        Get
            Return pEmployeeId
        End Get
    End Property

    Public Property passportNo() As String
        Get
            Return pPassportNo
        End Get
        Set(ByVal Value As String)
            pPassportNo = Value
        End Set

    End Property

    Public Property isEmployed() As Boolean
        Get
            Return pIsEmployed
        End Get
        Set(ByVal Value As Boolean)
            pIsEmployed = Value
        End Set
    End Property

    Public Property isSeeking() As Boolean
        Get
            Return pIsSeeking
        End Get

        Set(ByVal Value As Boolean)
            pIsSeeking = Value
        End Set
    End Property

    Public Property CenterID() As Integer
        Get
            Return pCenterID
        End Get

        Set(ByVal Value As Integer)
            pCenterID = Value
        End Set
    End Property

    Public Property Sponsored() As Boolean
        Get
            Return pSponsored
        End Get

        Set(ByVal Value As Boolean)
            pSponsored = Value
        End Set
    End Property

#End Region


    Public Sub New(ByVal _passportNo As String, _
                   ByVal _isEmployed As Boolean, _
                   ByVal _isSeeking As Boolean, _
                   ByVal _CenterID As Integer, _
                   ByVal _Sponsored As Boolean)

        Me.pPassportNo = _passportNo
        Me.pIsEmployed = _isEmployed
        Me.pIsSeeking = _isSeeking
        Me.pCenterID = _CenterID
        Me.pSponsored = _Sponsored

    End Sub

    Public Sub New(ByVal datatable As Data.DataTable, ByVal EmployeeID As String)
        EmployeeID = EmployeeID
        ParseDataTableDetails(datatable)
    End Sub

    ''' <summary>
    ''' Parses the user data table details with the following fields:
    ''' EmployeeID, PasswordID, isEmployeed, isSeeking, CenterID, Sponsored.
    ''' </summary>
    ''' <param name="dataTable">The data table.</param>
    Public Sub ParseDataTableDetails(ByVal dataTable As Data.DataTable)
        Try
            pEmployeeId = dataTable.Rows(0).Item("EmployeeID")
            pPassportNo = dataTable.Rows(0).Item("PassportNo")
            pIsEmployed = dataTable.Rows(0).Item("isEmployed")
            pIsSeeking = dataTable.Rows(0).Item("isSeeking")
            pCenterID = dataTable.Rows(0).Item("CenterID")
            pSponsored = dataTable.Rows(0).Item("Sponsored")
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.ParseDataTableDetails: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Gets the employee by ID.
    ''' </summary>
    ''' <param name="EmpID">The emp ID.</param>
    ''' <returns></returns>
    Public Shared Function getEmployeeByID(ByVal EmpID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT * FROM tblEmployee WHERE EmployeeID ='{0}'", EmpID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employee sponsored by ID.
    ''' </summary>
    ''' <param name="EmpID">The emp ID.</param>
    ''' <returns></returns>
    Public Shared Function getEmployeeSponsoredByID(ByVal EmpID As Integer) As Boolean
        Try
            Return (cDBManager.GetExecuteScalar(New SqlCommand( _
                                                String.Format("SELECT Sponsored FROM tblEmployee WHERE EmployeeID = {0}", _
                                                EmpID))) <> 0)
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeSponsoredByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Updates the employee.
    ''' </summary>
    ''' <param name="Employee">The employee.</param>
    ''' <param name="UID">The UID.</param>
    ''' <returns></returns>
    Public Shared Function UpdateEmployee(ByVal Employee As cEmployee, ByVal UID As Integer) As Boolean
        Try
            Return Convert.ToBoolean(cDBManager.ExecuteNonQuery(New SqlCommand( _
                                           String.Format("UPDATE tblEmployee SET isEmployed = '{0}', isSeeking = '{1}', Sponsored = '{2}' WHERE EmployeeID ='{3}'", _
                                                         Employee.isEmployed, Employee.isSeeking, Employee.Sponsored, UID))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.UpdateEmployee: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Migrates the employee to center.
    ''' </summary>
    ''' <param name="CenterId">The center id.</param>
    ''' <param name="EmployeeId">The employee id.</param>
    ''' <returns></returns>
    Public Shared Function MigrateEmployeeToCenter(ByVal CenterId As Integer, ByVal EmployeeId As Integer) As Boolean
        Try
            Return Convert.ToBoolean(cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblEmployee SET CenterId = '{0}' WHERE EmployeeID ='{1}'", CenterId, EmployeeId))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employee profile.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function getEmployeeProfile(ByVal UserID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblUser.Name, tblUser.Surname, tblUser.DOB, tblNationality.Nationality, tblEmployee.isEmployed, tblEmployee.isSeeking, tblEmployee.Sponsored, tblUser.Address, tblUser.StreetAddress, tblUser.Town, tblUser.PostCode, tblUser.CountryID, tblUser.TelephoneNo, tblUser.EmailAddress FROM  tblUser INNER JOIN tblEmployee ON tblUser.UserID = tblEmployee.EmployeeID INNER JOIN tblNationality ON tblUser.NationalityID = tblNationality.NationalityID WHERE tblUser.UserID = {0}", UserID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employee qualifications.
    ''' </summary>
    ''' <param name="EmployeeID">The employee ID.</param>
    ''' <returns></returns>
    Public Shared Function getEmployeeQualifications(ByVal EmployeeID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblQualification.QualificationID, tblQualification.Qualification, Convert(nvarchar(16),tblQualification.DateAwarded,103) as [Date Awarded], tblQualification.AwardingBody as [Awarding Body] FROM tblEmployee INNER JOIN tblQualification ON tblEmployee.EmployeeID = tblQualification.EmployeeID WHERE tblEmployee.EmployeeID ='{0}'", EmployeeID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the center employees.
    ''' </summary>
    ''' <param name="CenterID">The center ID.</param>
    ''' <returns></returns>
    Public Shared Function getCenterEmployees(ByVal CenterID As Integer) As DataTable
        Try
            'Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblEmployee.EmployeeID, COUNT(tblMessageToUser.MessageToUserID) AS [Unread Messages], tblUser.Name, tblUser.Surname, tblNationality.Nationality, tblEmployee.isEmployed, tblEmployee.isSeeking FROM  tblUser INNER JOIN tblEmployee ON tblUser.UserID = tblEmployee.EmployeeID INNER JOIN tblMessageToUser ON tblUser.UserID = tblMessageToUser.ToUserID INNER JOIN tblNationality ON tblUser.NationalityID = tblNationality.NationalityID  INNER JOIN tblCenter ON tblEmployee.CenterID = tblCenter.CenterID WHERE (tblUser.isEnabled = 1) AND (tblCenter.CenterID = '" & CenterID & "') AND (tblMessageToUser.isRead = 1) GROUP BY tblEmployee.EmployeeID, tblUser.Name, tblUser.Surname, tblNationality.Nationality, tblEmployee.isEmployed, tblEmployee.isSeeking")))

            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblEmployee.EmployeeID, tblUser_1.Name + ' ' + tblUser_1.Surname AS [Full Name], tblNationality.Nationality, (SELECT     COUNT(*) AS CountUnread FROM tblMessage INNER JOIN tblMessageType ON tblMessageType.MessageTypeID = tblMessage.MessageTypeID INNER JOIN tblMessageToUser ON tblMessage.MessageID = tblMessageToUser.MessageID LEFT OUTER JOIN tblUser ON tblMessage.FromUser = tblUser.UserID WHERE (tblMessageToUser.IsDeleted = 'False') AND (tblMessageToUser.ToUserID = tblEmployee.EmployeeID) AND (tblMessageToUser.ParentMessageID IS NULL) AND (tblMessageToUser.IsRead = 'False') OR (tblMessageToUser.IsDeleted = 'False') AND (tblMessageToUser.ParentMessageID IS NULL) AND (tblMessageToUser.IsRead = 'False') AND (tblMessage.FromUser = tblEmployee.EmployeeID)) AS [Unread Messages], tblEmployee.isEmployed, tblEmployee.isSeeking FROM tblEmployee INNER JOIN tblUser AS tblUser_1 ON tblEmployee.EmployeeID = tblUser_1.UserID INNER JOIN tblNationality ON tblUser_1.NationalityID = tblNationality.NationalityID WHERE (tblEmployee.CenterID = '" & CenterID & "') AND (tblUser_1.isEnabled = 1) ORDER BY [Unread Messages] DESC")))


        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Gets the associated center ID.
    ''' </summary>
    ''' <param name="EmployeeID">The employee ID.</param>
    ''' <returns></returns>
    Public Shared Function GetAssociatedCenterID(ByVal EmployeeID As Integer) As Integer
        Try
            Dim objReturn As Object = cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT CenterID FROM tblEmployee WHERE EmployeeID = {0}", EmployeeID)))
            If (objReturn.Equals(DBNull.Value)) Then
                Return 0
            Else
                Return Convert.ToInt32(objReturn)
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employees by value.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function GetEmployeesByValue(ByVal value As String) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format( _
                "SELECT tblUser.UserID, tblUser.Name + ' ' + tblUser.Surname AS [Employee Name], tblEmployee.isSeeking AS Seeking, tblEmployee.isEmployed AS Employed, tblEmployee.Sponsored, tblCountry.Country, tblCountry.CountryCode " & _
                "FROM tblUser " & _
                    "INNER JOIN tblEmployee ON tblUser.UserID = tblEmployee.EmployeeID " & _
                    "INNER JOIN tblCountry ON tblUser.CountryID = tblCountry.CountryID " & _
                    "INNER JOIN tblUserType ON tblUser.UserTypeID = tblUserType.UserTypeID " & _
                    "WHERE ((tblUserType.Type = 'Employee') AND (tblUser.isEnabled = 'True')) AND " & _
                    "((tblUser.Name LIKE '%{0}%') OR (tblUser.Surname LIKE '%{0}%') OR  " & _
                    "(tblCountry.Country LIKE N'%{0}%')) ORDER BY tblUser.Name ASC", value)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employees by value.
    ''' </summary>
    ''' <param name="Value">The value.</param>
    ''' <param name="CenterID">The center ID.</param>
    ''' <returns></returns>
    Public Shared Function getEmployeesByValue(ByVal Value As String, ByVal CenterID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format( _
                "SELECT tblUser.UserID, tblUser.Name + ' ' + tblUser.Surname AS [Employee Name], tblEmployee.isSeeking AS Seeking, tblEmployee.isEmployed AS Employed, tblEmployee.Sponsored, tblCountry.Country, tblCountry.CountryCode " & _
                "FROM tblUser " & _
                    "INNER JOIN tblEmployee ON tblUser.UserID = tblEmployee.EmployeeID " & _
                    "INNER JOIN tblCountry ON tblUser.CountryID = tblCountry.CountryID " & _
                    "INNER JOIN tblUserType ON tblUser.UserTypeID = tblUserType.UserTypeID " & _
                    "WHERE ((tblUserType.Type = 'Employee') AND (tblUser.isEnabled = 'True') AND (tblEmployee.CenterID = {0})) AND " & _
                    "((tblUser.Name LIKE '%{1}%') OR (tblUser.Surname LIKE '%{1}%') OR  " & _
                    "(tblCountry.Country LIKE N'%{1}%'))", CenterID, Value)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employees by criteria.
    ''' </summary>
    ''' <param name="name">The name.</param>
    ''' <param name="surname">The surname.</param>
    ''' <param name="country">The country.</param>
    ''' <param name="gender">if set to <c>true</c> [gender].</param>
    ''' <param name="isemployed">if set to <c>true</c> [isemployed].</param>
    ''' <param name="isseeking">if set to <c>true</c> [isseeking].</param>
    ''' <param name="prefoccupation">The prefoccupation.</param>
    ''' <param name="isSponsored">The is sponsored.</param>
    ''' <returns></returns>
    Public Shared Function GetEmployeesByCriteria(ByVal name As String, _
                                                  ByVal surname As String, _
                                                  ByVal country As String, _
                                                  ByVal gender As Boolean, _
                                                  ByVal isemployed As Boolean, _
                                                  ByVal isseeking As Boolean, _
                                                  ByVal prefoccupation As String, _
                                                  ByVal isSponsored As String) As DataTable
        Try
            Dim sqlGetEmplyeesByCriteria As New SqlCommand
            Dim whereClause As New StringBuilder
            whereClause.Append("WHERE ")
            If Not (name = Nothing) Then
                whereClause.Append("(tblUser.Name = '" & name & "') AND ")
            End If
            If Not (surname = Nothing) Then
                whereClause.Append("tblUser.Surname = '" & surname & "') AND ")
            End If
            If Not (country = Nothing) Then
                Dim sqlGetCountryID As New SqlCommand
                sqlGetCountryID.CommandText = "SELECT tblCountry.CountryID FROM tblCountry WHERE (tblCountry.Country = '" & country & "')"
                whereClause.Append("(tblUser.CountryID = " & cDBManager.GetExecuteScalar(sqlGetCountryID) & ") AND ")
            End If
            If Not (prefoccupation = Nothing) Then
                Dim sqlGetOccupationID As New SqlCommand
                sqlGetOccupationID.CommandText = "SELECT tblOccupation.OccupationID FROM tblOccupation WHERE tblOccupation.Occupation = '" & prefoccupation & "'"
                whereClause.Append("(tblPreferredJob.OccupationID = " & cDBManager.GetExecuteScalar(sqlGetOccupationID) & ") AND ")
            End If
            whereClause.Append("(tblUser.Gender = '" & gender & "') AND ")
            whereClause.Append("(tblEmployee.isEmployed = '" & isemployed & "') AND ")
            whereClause.Append("(tblEmployee.isSeeking = '" & isseeking & "') AND ")
            whereClause.Append("(tblEmployee.Sponsored = '" & isSponsored & "')")
            sqlGetEmplyeesByCriteria.CommandText = "SELECT tblUser.UserID, tblUser.Name, tblUser.Surname, tblCountry.Country, tblCountry.CountryCode, tblUser.Gender, tblEmployee.isEmployed, tblEmployee.isSeeking, tblEmployee.Sponsored, tblOccupation.Occupation " & _
                        "FROM tblUser " & _
                            "INNER JOIN tblCountry ON tblUser.CountryID = tblCountry.CountryID " & _
                            "INNER JOIN tblEmployee ON tblUser.UserID = tblEmployee.EmployeeID " & _
                            "INNER JOIN tblPreferredJob ON tblPreferredJob.EmployeeID = tblUser.UserID " & _
                            "INNER JOIN tblOccupation ON tblPreferredJob.OccupationID = tblOccupation.OccupationID " & whereClause.ToString
            Return cDBManager.GetDataTable(sqlGetEmplyeesByCriteria)
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employees for job.
    ''' </summary>
    ''' <param name="JobID">The job ID.</param>
    ''' <returns></returns>
    Public Overloads Shared Function GetEmployeesForJob(ByVal JobID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT     tblUser.UserID, tblUser.Name + ' ' + tblUser.Surname AS Name, tblEmployee.isEmployed, tblEmployee.isSeeking, tblEmployee.Sponsored, tblCountry.Country, " & _
            "tblCountry.CountryCode " & _
"FROM         tblUser INNER JOIN " & _
                      "tblEmployee ON tblUser.UserID = tblEmployee.EmployeeID INNER JOIN " & _
                      "tblPreferredJob ON tblEmployee.EmployeeID = tblPreferredJob.EmployeeID INNER JOIN " & _
                      "tblJobIndustry ON tblPreferredJob.JobIndustryID = tblJobIndustry.JobIndustryID INNER JOIN " & _
                      "tblCountry ON tblUser.CountryID = tblCountry.CountryID " & _
                                        "WHERE (tblJobIndustry.JobIndustryID = " & _
                                        "(SELECT tblJobIndustry_1.JobIndustryID " & _
                                        "FROM tblJobIndustry AS tblJobIndustry_1 INNER JOIN " & _
                                        "tblOccupation ON tblJobIndustry_1.JobIndustryID = tblOccupation.JobIndustryID INNER JOIN " & _
                                        "tblJob ON tblOccupation.OccupationID = tblJob.OccupationID " & _
                                        "WHERE (tblJob.JobID = {0})))", JobID)))
            '"SELECT DISTINCT tblUser.UserID, tblUser.Name + ' ' + tblUser.Surname AS 'Employee Name', tblEmployee.isEmployed AS Employed, tblEmployee.isSeeking AS Seeking, tblEmployee.Sponsored, tblCountry.Country, tblCountry.CountryCode " & _
            '                                      "FROM tblUser " & _
            '                                      "INNER JOIN tblJobRequestTo ON tblUser.UserID = tblJobRequestTo.ToUser " & _
            '                                      "INNER JOIN tblPreferredJob ON tblUser.UserID = tblPreferredJob.EmployeeID " & _
            '                                      "INNER JOIN tblEmployee ON tblUser.UserID = tblEmployee.EmployeeID AND tblPreferredJob.EmployeeID = tblEmployee.EmployeeID " & _
            '                                      "INNER JOIN tblCountry ON tblUser.CountryID = tblCountry.CountryID " & _
            '                                      "INNER JOIN tblJobType ON tblPreferredJob.JobTypeID = tblJobType.JobTypeID " & _
            '                                      "INNER JOIN tblOccupation ON tblPreferredJob.OccupationID = tblOccupation.OccupationID " & _
            '                                      "WHERE (tblUser.isEnabled = 'True') AND (tblOccupation.JobIndustryID = {0}) AND (NOT (SELECT ToUser FROM tblJobRequestTo WHERE JobID = {1}) = tblUser.UserID)", GetIndustryIDByJob(JobID), JobID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the industry ID by job.
    ''' </summary>
    ''' <param name="JobID">The job ID.</param>
    ''' <returns></returns>
    Public Shared Function GetIndustryIDByJob(ByVal JobID As Integer) As Integer
        Try
            Return Convert.ToInt64(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT tblJobIndustry.JobIndustryID " & _
                                        "FROM tblJob " & _
                                        "INNER JOIN tblOccupation ON tblJob.OccupationID = tblOccupation.OccupationID " & _
                                        "INNER JOIN  tblJobIndustry ON tblOccupation.JobIndustryID = tblJobIndustry.JobIndustryID " & _
                                        "WHERE(tblJob.JobID = '{0}')", JobID))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employees for job.
    ''' </summary>
    ''' <param name="JobID">The job ID.</param>
    ''' <param name="Occupation">if set to <c>true</c> [occupation].</param>
    ''' <param name="jobType">if set to <c>true</c> [job type].</param>
    ''' <param name="isSeeking">The is seeking.</param>
    ''' <param name="isEmployed">The is employed.</param>
    ''' <param name="isSponsored">The is sponsored.</param>
    ''' <returns></returns>
    Public Overloads Shared Function GetEmployeesForJob(ByVal JobID As Integer, ByVal Occupation As Boolean, ByVal jobType As Boolean, ByVal isSeeking As String, ByVal isEmployed As String, ByVal isSponsored As String) As DataTable
        Dim sqlJobIndustry As New SqlCommand
        Dim sb As New StringBuilder

        Try
            sb.Append("SELECT DISTINCT tblUser.UserID, tblUser.Name + ' ' + tblUser.Surname AS 'Employee Name', tblEmployee.isEmployed AS Employed, tblEmployee.isSeeking AS Seeking, tblEmployee.Sponsored, tblCountry.Country, tblCountry.CountryCode " & _
                                      "FROM tblUser " & _
                                      "INNER JOIN tblJobRequestTo ON tblUser.UserID = tblJobRequestTo.ToUser " & _
                                      "INNER JOIN tblPreferredJob ON tblUser.UserID = tblPreferredJob.EmployeeID " & _
                                      "INNER JOIN tblEmployee ON tblUser.UserID = tblEmployee.EmployeeID AND tblPreferredJob.EmployeeID = tblEmployee.EmployeeID " & _
                                      "INNER JOIN tblCountry ON tblUser.CountryID = tblCountry.CountryID " & _
                                      "INNER JOIN tblJobType ON tblPreferredJob.JobTypeID = tblJobType.JobTypeID " & _
                                      "INNER JOIN tblOccupation ON tblPreferredJob.OccupationID = tblOccupation.OccupationID " & _
                                      "WHERE (tblUser.isEnabled = 'True') AND (tblOccupation.JobIndustryID = " & GetIndustryIDByJob(JobID) & ")  AND (NOT (SELECT ToUser FROM tblJobRequestTo WHERE JobID = " & JobID & ") = tblUser.UserID)")


            If Occupation Then
                Dim objOccuID As Object
                objOccuID = cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT tblJob.OccupationID FROM tblJob WHERE JobID = '{0}'", JobID)))

                If Not (objOccuID = Nothing) Then
                    Try
                        Dim intOccuID As Integer = Convert.ToInt64(objOccuID)
                        sb.Append(" AND (tblPreferredJob.OccupationID = '" & intOccuID & "')")
                    Catch ex As Exception
                        cLogging.AddLog("Error Parcing OccupationID", Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
                        Throw New Exception("Could not parse OccupationID")
                    End Try
                End If
            End If

            If jobType Then
                Dim objJobType As Object
                objJobType = cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT JobTypeID FROM tblJob WHERE JobID = '{0}'", JobID)))

                If Not (objJobType = Nothing) Then
                    Try
                        Dim intJobTypeID As Integer = Convert.ToInt64(objJobType)
                        sb.Append(" AND (tblPreferredJob.JobTypeID = '" & intJobTypeID & "')")
                    Catch ex As Exception
                        cLogging.AddLog("Error Parcing JobTypeID", Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
                        Throw New Exception("Could not parse JobTypeID")
                    End Try
                End If
            End If

            If isSeeking = "Is Seeking" Then
                sb.Append(" AND (tblEmployee.isSeeking = 'True')")
            ElseIf (isSeeking = "Not Seeking") Then
                sb.Append(" AND (tblEmployee.isSeeking = 'False')")
            End If
            If isEmployed = "Employed" Then
                sb.Append(" AND (tblEmployee.isEmployed = 'True')")
            ElseIf (isEmployed = "Not Employed") Then
                sb.Append(" AND (tblEmployee.isEmployed = 'False')")
            End If
            If isSponsored = "Sponsored" Then
                sb.Append(" AND (tblEmployee.Sponsored = 'True')")
            ElseIf (isSponsored = "Not Sponsored") Then
                sb.Append(" AND (tblEmployee.Sponsored = 'False')")
            End If

            sb.Append("GROUP BY tblUser.UserID, tblUser.Name, tblUser.Surname, tblEmployee.isEmployed, tblEmployee.isSeeking, tblEmployee.Sponsored, tblCountry.Country, tblCountry.CountryCode")

            Dim sqlGetEmployees As New SqlCommand
            sqlGetEmployees.CommandText = sb.ToString

            Return cDBManager.GetDataTable(sqlGetEmployees)
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.GetEmployeesForJob: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the reviews.
    ''' </summary>
    ''' <param name="userID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function getReviews(ByVal userID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblReviewTo.ReviewToID, tblJob.Title AS [Job Title], tblJob.Description AS [Job Description], tblReviewMessage.Comment AS [Review Message], tblReviewMessage.Rating, tblReviewTo.isReported AS [Pending Report] FROM tblJob INNER JOIN tblReviewMessage ON tblJob.JobID = tblReviewMessage.JobID INNER JOIN tblReviewTo ON tblReviewMessage.ReviewMessageID = tblReviewTo.ReviewMessageID WHERE (tblReviewTo.EmployeeID = {0}) AND (tblReviewTo.flagedNoShow = 0)", userID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the top reviews.
    ''' </summary>
    ''' <param name="userID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function GetTopReviews(ByVal userID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT TOP (10) tblReviewTo.ReviewToID, tblJob.Title, tblReviewMessage.Comment, tblReviewMessage.Rating, tblReviewTo.isReported, tblReviewTo.reportMessage FROM tblJob INNER JOIN tblReviewMessage ON tblJob.JobID = tblReviewMessage.JobID INNER JOIN tblReviewTo ON tblReviewMessage.ReviewMessageID = tblReviewTo.ReviewMessageID WHERE(tblReviewTo.EmployeeID = {0}) AND (flagedNoShow = 0)", userID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employee I dsfrom centre.
    ''' </summary>
    ''' <param name="CenterID">The center ID.</param>
    ''' <returns></returns>
    Public Shared Function getEmployeeIDsfromCentre(ByVal CenterID As Integer) As Integer()
        Try
            Dim dt As New DataTable
            dt = cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT EmployeeID FROM tblEmployee WHERE CenterID = {0}", CenterID)))

            Dim list As New LinkedList(Of Integer)
            For index As Integer = 0 To dt.Rows.Count - 1
                list.AddLast(dt.Rows(index).Item("EmployeeID"))
            Next
            Return list.ToArray
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Updates as employeed.
    ''' </summary>
    ''' <param name="EmployeeID">The employee ID.</param>
    ''' <returns></returns>
    Public Shared Function UpdateAsEmployeed(ByVal EmployeeID As Integer) As Boolean
        Try
            If cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblEmployee SET isEmployed='True' WHERE EmployeeID = {0}", EmployeeID))) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmployee.getEmployeeByID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
