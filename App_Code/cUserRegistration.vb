Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class cUserRegistration
    Enum UserType
        EMPLOYER = 1
        EMPLOYEE = 2
        SYSTEMADMIN = 3
        CENTERADMIN = 4
    End Enum

    ''' <summary>
    ''' Determines whether the specified compare username exists.
    ''' </summary>
    ''' <param name="compareUsername">The compare username.</param>
    ''' <returns>
    ''' <c>true</c> if the specified compare username is exists; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function isExists(ByVal compareUsername As String) As Boolean
        Try
            If compareUsername = cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT Username FROM tblUser WHERE Username= '{0}'", compareUsername))) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cUserRegistration.isExists: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Creates the user.
    ''' </summary>
    ''' <param name="newUser">The new user.</param>
    ''' <param name="userType">Type of the user.</param>
    ''' <returns></returns>
    Public Shared Function CreateUser(ByVal newUser As cUser, ByVal userType As UserType) As Integer
        Try
            Return cDBManager.SetReturnID(New SqlCommand(String.Format( _
                                                         "INSERT INTO tblUser ([Name],[Surname],[Gender],[DOB], " & _
                                                         "[Address],[StreetAddress],[Town],[State],[CountryID],[PostCode], " & _
                                                         "[NationalityID],[TelephoneNo],[EmailAddress],[Username],[Password], " & _
                                                         "[isEnabled],[UserTypeID],[Stamp])  " & _
                                                         "VALUES('{0}', " & _
                                                         "'{1}', " & _
                                                         "'{2}', " & _
                                                         "'{3}', " & _
                                                         "'{4}', " & _
                                                         "'{5}', " & _
                                                         "'{6}', " & _
                                                         "'{7}', " & _
                                                         "{8}, " & _
                                                         "'{9}', " & _
                                                         "{10}, " & _
                                                         "'{11}', " & _
                                                         "'{12}', " & _
                                                         "'{13}', " & _
                                                         "'{14}', " & _
                                                         "0, " & _
                                                         "{15}, " & _
                                                         "getdate()) ", newUser.name, newUser.surname, newUser.gender, newUser.dob, _
                                                         newUser.address, newUser.streetaddress, newUser.town, _
                                                         newUser.state, newUser.countryID, newUser.postCode, newUser.nationalityID, _
                                                         newUser.telephone, newUser.email, newUser.username, newUser.password, Convert.ToInt16(userType))))

            'String.Format("INSERT INTO tblUser " & _
            '                                "VALUES ('{0}', '{1}', '{2}' ," & _
            '                                "'{3}', '{4}', '{5}' ," & _
            '                                "'{6}','{7}', {8}," & _
            '                                "'{9}', {10}, '{11}' ," & _
            '                                "'{12}', '{13}','{14}', 0, {15}, GETDATE())", _
            '                                newUser.name, newUser.surname, newUser.gender, "GETDATE()", newUser.address, _
            '                                newUser.streetaddress, newUser.town, newUser.state, newUser.countryID, newUser.postCode, newUser.nationalityID, _
            '                                newUser.telephone, newUser.email, newUser.username, newUser.password, Convert.ToInt16(userType))))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Deletes the user.
    ''' </summary>
    ''' <param name="UserID">The user ID to delete.</param>
    Public Shared Sub DeleteUser(ByVal UserID As Integer)
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("DELETE FROM tblUser WHERE UserID = {0}", UserID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cUserRegistration.DeleteUser {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Deletes the center.
    ''' </summary>
    ''' <param name="CenterID">The center ID to delete.</param>
    Public Shared Sub DeleteCenter(ByVal CenterID As Integer)
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("DELETE FROM tblCenter WHERE CenterID = {0}", CenterID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cUserRegistration.DeleteUser {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Creates the employee.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <param name="PassportNo">The passport no.</param>
    ''' <param name="CenterID">The center ID.</param>
    ''' <returns></returns>
    Public Shared Function CreateEmployee(ByVal UserID As Integer, ByVal PassportNo As String, ByVal CenterID As Integer) As Boolean
        Try
            If (cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblEmployee VALUES ({0}, '{1}', 0, 0, 0, {2},0)", UserID, PassportNo, CenterID)))) > 0 Then
                cLogging.AddLog(String.Format("Employee {0} created.", UserID), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cUserRegistration.CreateEmployee {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Creates the employee.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <param name="PassportNo">The passport no.</param>
    ''' <returns></returns>
    Public Shared Function CreateEmployee(ByVal UserID As Integer, ByVal PassportNo As String) As Boolean
        Try
            If cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblEmployee VALUES ({0}, '{1}', 0, 0, 0, NULL, 0)", UserID, PassportNo))) > 0 Then
                cLogging.AddLog(String.Format("Employee {0} created.", UserID), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cUserRegistration.CreateEmployee {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Creates the employer.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function CreateEmployer(ByVal UserID As Integer) As Boolean
        Try
            If cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblEmployer VALUES ({0}, GETDATE())", UserID))) > 0 Then
                Return True
            Else
                cLogging.AddLog(String.Format("Employer {0} created.", UserID), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cUserRegistration.CreateEmployer {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Creates the company.
    ''' </summary>
    ''' <param name="Company">The company.</param>
    ''' <returns></returns>
    Public Shared Function CreateCompany(ByVal Company As cCompany) As Boolean
        Try
            If cDBManager.ExecuteNonQuery(New SqlCommand(String.Format( _
                                                         "INSERT INTO tblCompany ([CompanyName],[Address],[StreetAddress], " & _
                                                         "[Town],[State],[CountryID],[PostCode],[TelephoneNo],[EmailAddress], " & _
                                                         "[VATNo],[RegistrationNo],[EmployerID],[Stamp]) " & _
                                                         "VALUES " & _
                                                         "('{0}', " & _
                                                         "'{1}', " & _
                                                         "'{2}', " & _
                                                         "'{3}', " & _
                                                         "'{4}', " & _
                                                         "{5}, " & _
                                                         "'{6}', " & _
                                                         "'{7}', " & _
                                                         "'{8}', " & _
                                                         "'{9}', " & _
                                                         "'{10}', " & _
                                                         "{11}, " & _
                                                         "getDate())", Company.CompanyName, Company.Address, Company.StreetAddresss, Company.Town _
                                                         , Company.State, Company.CountryID, Company.PostCode, Company.TelephoneNo _
                                                         , Company.Email, Company.VATNo, Company.RegistrationNo, Company.EmployerID))) > 0 Then


                'String.Format("INSERT INTO tblUser " & _
                '                        "VALUES ('{0}', '{1}', '{2}' ," & _
                '                        "'{3}','{4}', {5} ," & _
                '                        "'{6}', {7}, " & _
                '                        "'{8}', '{9}','{10}', 0, {11}, GETDATE())", _
                '                        Company.CompanyName, Company.Address, Company.StreetAddresss, Company.Town, _
                '                        Company.State, Company.CountryID, Company.PostCode, Company.TelephoneNo, _
                '                        Company.Email, Company.VATNo, Company.RegistrationNo, Company.EmployerID))) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cUserRegistration.CreateCompany {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Creates the center admin.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <param name="CenterID">The center ID.</param>
    ''' <returns></returns>
    Public Shared Function CreateCenterAdmin(ByVal UserID As Integer, ByVal CenterID As Integer) As Boolean
        Try
            If cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblCenterAdmin VALUES ({0}, {1}, GETDATE())", UserID, CenterID))) > 0 Then
                cLogging.AddLog(String.Format("Center Admin {0} created on center {1}", UserID, CenterID), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cUserRegistration.CreateCenterAdmin {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Creates the center.
    ''' </summary>
    ''' <param name="NewCenter">The new center.</param>
    ''' <returns></returns>
    Public Shared Function CreateCenter(ByVal NewCenter As cCenter) As Integer
        Try
            Dim GeoLoc As New cGeoCoder(NewCenter.streetAddress, NewCenter.town, cRegional.GetCountry(NewCenter.countryID))

            Dim newCenterID As Integer = cDBManager.SetReturnID(New SqlCommand(String.Format("INSERT INTO tblCenter " & _
                                                    "VALUES ('{0}', '{1}', '{2}', ' {3}', '{4}', {5} , '{6}', '{7}' , '{8}', {9}, {10}, GETDATE())", _
                                                    NewCenter.centerName, NewCenter.address, NewCenter.streetAddress, NewCenter.town, NewCenter.state, _
                                                    NewCenter.countryID, NewCenter.postCode, NewCenter.telephoneNo, NewCenter.emailAddress, GeoLoc.Latitude, GeoLoc.Longitude)))
            cLogging.AddLog(String.Format("Center {0} created", newCenterID), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
            Return newCenterID
        Catch ex As Exception
            cLogging.AddLog(String.Format("cUserRegistration.CreateCenter {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
