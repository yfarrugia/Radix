Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Diagnostics

''' <summary>
''' Generic data type that handles and stopres information about a generic user
''' </summary>
Public Class cUser

    Enum ActivationKeyType
        REGISTRATION = 1
        PASSWORD_RETRIEVAL = 2
        CANCELLATION = 3
        ENABLE_ACCOUNT
    End Enum

    Public Enum FLAGGED_USER_STATE
        FLAGGED = 1
        INVALID = 2
        VALID = 3
    End Enum
#Region "Private Attributes"

    Private pPassword As String = String.Empty
    Private pUsername As String = String.Empty
    Private pUserId As Integer = -1
    Private pName As String = String.Empty
    Private pSurname As String = String.Empty
    Private pDob As String = String.Empty
    Private pAddress As String = String.Empty
    Private pStreetaddress As String = String.Empty
    Private pTown As String = String.Empty
    Private pState As String = String.Empty
    Private pPostCode As String = String.Empty
    Private pTelephone As String = String.Empty
    Private pEmail As String = String.Empty
    Private pGender As Boolean
    Private pNationalityID As Integer = -1
    Private pCountryID As Integer = -1
    Private pIsEnabled As Boolean
    Private pUserType As String = String.Empty

#End Region

#Region "Public Attributes"


    Public ReadOnly Property password() As String
        Get
            Return pPassword
        End Get
    End Property

    Public ReadOnly Property username() As String
        Get
            Return pUsername
        End Get
    End Property

    Public ReadOnly Property userId() As Integer
        Get
            Return pUserId
        End Get
    End Property

    Public ReadOnly Property name() As String
        Get
            Return pName
        End Get
    End Property

    Public ReadOnly Property surname() As String
        Get
            Return pSurname
        End Get
    End Property

    Public ReadOnly Property dob() As String
        Get
            Return pDob
        End Get
    End Property

    Public ReadOnly Property address() As String
        Get
            Return pAddress
        End Get
    End Property

    Public ReadOnly Property streetaddress() As String
        Get
            Return pStreetaddress
        End Get
    End Property

    Public ReadOnly Property town() As String
        Get
            Return pTown
        End Get
    End Property

    Public ReadOnly Property state() As String
        Get
            Return pState
        End Get
    End Property

    Public ReadOnly Property postCode() As String
        Get
            Return pPostCode
        End Get
    End Property

    Public ReadOnly Property telephone() As String
        Get
            Return pTelephone
        End Get
    End Property

    Public ReadOnly Property email() As String
        Get
            Return pEmail
        End Get
    End Property

    Public ReadOnly Property gender() As Boolean
        Get
            Return pGender
        End Get
    End Property

    Public ReadOnly Property nationalityID() As Integer
        Get
            Return pNationalityID
        End Get
    End Property

    Public ReadOnly Property countryID() As Integer
        Get
            Return pCountryID
        End Get
    End Property

    Public ReadOnly Property isEnabled() As Boolean
        Get
            Return pIsEnabled
        End Get
    End Property

    Public ReadOnly Property userType() As String
        Get
            Return pUserType
        End Get
    End Property

#End Region


    ''' <summary>
    ''' Initializes a new instance of the <see cref="cUser" /> class.
    ''' </summary>
    ''' <param name="datatable">The datatable including the following fields: UserID, Name, Type, isEnables and DOB</param>
    ''' <param name="userName">Username of the user.</param>
    Public Sub New(ByVal datatable As Data.DataTable, ByVal userName As String)
        pUsername = userName
        ParseDataTableDetails(datatable)
    End Sub

    Public Sub New()
        'default constructor
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="cUser" /> class.
    ''' </summary>
    ''' <param name="Name">The name.</param>
    ''' <param name="Surname">The surname.</param>
    ''' <param name="DOB">The DOB.</param>
    ''' <param name="Address">The address.</param>
    ''' <param name="StreetAddress">The street address.</param>
    ''' <param name="Town">The town.</param>
    ''' <param name="State">The state.</param>
    ''' <param name="PostCode">The post code.</param>
    ''' <param name="Telephone">The telephone.</param>
    ''' <param name="Email">The email.</param>
    ''' <param name="Username">The username.</param>
    ''' <param name="Password">The password.</param>
    ''' <param name="Gender">if set to <c>true</c> [gender].</param>
    ''' <param name="NationalityID">The nationality ID.</param>
    ''' <param name="CountryID">The country ID.</param>
    Public Sub New(ByVal Name As String, _
                   ByVal Surname As String, _
                   ByVal DOB As String, _
                   ByVal Address As String, _
                   ByVal StreetAddress As String, _
                   ByVal Town As String, _
                   ByVal State As String, _
                   ByVal PostCode As String, _
                   ByVal Telephone As String, _
                   ByVal Email As String, _
                   ByVal Username As String, _
                   ByVal Password As String, _
                   ByVal Gender As Boolean, _
                   ByVal NationalityID As Integer, _
                   ByVal CountryID As Integer)

        Me.pName = Name
        Me.pSurname = Surname
        Me.pDob = DOB
        Me.pAddress = Address
        Me.pStreetaddress = StreetAddress
        Me.pTown = Town
        Me.pState = State
        Me.pPostCode = PostCode
        Me.pTelephone = Telephone
        Me.pEmail = Email
        Me.pUsername = Username
        Me.pPassword = Password
        Me.pGender = Gender
        Me.pNationalityID = NationalityID
        Me.pCountryID = CountryID
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="cUser" /> class.
    ''' </summary>
    ''' <param name="Address">The address.</param>
    ''' <param name="StreetAddress">The street address.</param>
    ''' <param name="Town">The town.</param>
    ''' <param name="State">The state.</param>
    ''' <param name="PostCode">The post code.</param>
    ''' <param name="Telephone">The telephone.</param>
    ''' <param name="Email">The email.</param>
    ''' <param name="CountryID">The country ID.</param>
    Public Sub New(ByVal Address As String, _
              ByVal StreetAddress As String, _
              ByVal Town As String, _
              ByVal State As String, _
              ByVal PostCode As String, _
              ByVal Telephone As String, _
              ByVal Email As String, _
              ByVal CountryID As Integer)

        Me.pAddress = Address
        Me.pStreetaddress = StreetAddress
        Me.pTown = Town
        Me.pState = State
        Me.pPostCode = PostCode
        Me.pTelephone = Telephone
        Me.pEmail = Email
        Me.pCountryID = CountryID

    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="cUser" /> class.
    ''' </summary>
    ''' <param name="Surname">The surname.</param>
    Public Sub New(ByVal Surname As String)
        Me.pSurname = Surname
    End Sub

    ''' <summary>
    ''' Updates the user.
    ''' </summary>
    ''' <param name="User">The User object.</param>
    ''' <param name="UID">The User ID.</param>
    ''' <returns></returns>
    Public Shared Function UpdateUser(ByVal User As cUser, ByVal UID As Integer) As Boolean
        If Not (UID <= 0) Then
            Try
                cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblUser " & _
                             "SET Surname = '{0}', Address = '{1}', StreetAddress = '{2}', Town ='{3}', State = '{4}', " & _
                             "PostCode='{5}', TelephoneNo='{6}', EmailAddress='{7}', CountryID = '{8}' WHERE UserID ='{9}'", User.surname, User.address, User.streetaddress, User.town, User.state, User.postCode, User.telephone, User.email, User.countryID, UID)))

                cLogging.AddLog("Successfully Updated User Detials", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
                Return True
            Catch ex As Exception
                cLogging.AddLog("Error Updating User: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
                Throw ex
            End Try
        End If
    End Function

    ''' <summary>
    ''' Updates the user password.
    ''' </summary>
    ''' <param name="Password">The password hashed password.</param>
    ''' <param name="UID">The User ID.</param>
    ''' <returns></returns>
    Public Shared Function UpdateUserPassword(ByVal Password As String, ByVal UID As Integer) As Boolean
        If Not (UID <= 0) Then
            Try
                cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblUser SET Password = '{0}' WHERE UserID ='{1}'", Password, UID)))
                cLogging.AddLog("Successfully Changed Password", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, UID, Nothing, Nothing)
                Return True
            Catch ex As Exception
                cLogging.AddLog("Error Updating User Password: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, UID, Nothing, Nothing)
                Throw ex
            End Try
        End If
    End Function

    ''' <summary>
    ''' Parses the user data table details.
    ''' </summary>
    ''' <param name="dataTable">The data table.</param>
    Private Sub ParseDataTableDetails(ByVal dataTable As Data.DataTable)
        Try
            pUserId = dataTable.Rows(0).Item("UserID")
            pName = dataTable.Rows(0).Item("Name")
            pUserType = dataTable.Rows(0).Item("Type")
            pIsEnabled = dataTable.Rows(0).Item("isEnabled")
            pDob = dataTable.Rows(0).Item("DOB")
        Catch ex As Exception
            cLogging.AddLog("ParseDataTableDetails: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder

        With sb
            .Append(<b>UserName: </b>)
            .Append(pUsername)
            .Append(<br/>)

            .Append(<b>Name: </b>)
            .Append(pName)
            .Append(<br/>)

            .Append(<b>ID: </b>)
            .Append(pUserId)
            .Append(<br/>)

            .Append(<b>Enabled: </b>)
            .Append(pIsEnabled)
            .Append(<br/>)

            .Append(<b>Type: </b>)
            .Append(pUserType)
            .Append(<br/>)
        End With

        Return sb.ToString
    End Function

    ''' <summary>
    ''' Gets the username.
    ''' </summary>
    ''' <param name="UserId">The user id.</param>
    ''' <returns></returns>
    Public Shared Function getUsername(ByVal UserId As Integer) As String
        Try
            Return Convert.ToString(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT Username FROM tblUser WHERE UserID= {0}", UserId))))
        Catch ex As Exception
            cLogging.AddLog("getUsername: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Checks the password.
    ''' </summary>
    ''' <param name="PlainPassword">The plain password.</param>
    ''' <returns></returns>
    Public Function checkPass(ByVal PlainPassword As String) As Boolean
        Try
            If (cHash.VerifyHash(PlainPassword, _
                                 cDBManager.GetExecuteScalar(New SqlCommand("SELECT password FROM tblUser WHERE username = '" & pUsername & "'")))) Then
                cLogging.AddLog(String.Format("Passowrd for {0} matched", pUsername), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, userId, Nothing, pUsername)
                Return True
            Else
                cLogging.AddLog(String.Format("Passowrd for {0} did not match", pUsername), Nothing, cLogging.LogType.WARNING_LOG, Nothing, Nothing, Nothing, Nothing)
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog("checkPass: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    '@Overloaded Shared
    ''' <summary>
    ''' Checks the pass.
    ''' </summary>
    ''' <param name="Username">The username.</param>
    ''' <param name="PlainPassword">The plain password.</param>
    ''' <returns></returns>
    Public Shared Function checkPass(ByVal Username As String, ByVal PlainPassword As String) As Boolean
        Try
            If (cHash.VerifyHash(PlainPassword, _
                                 cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT password FROM tblUser WHERE username = '{0}'", Username))))) Then
                cLogging.AddLog(String.Format("checkPass[s]: Passowrd for {0} matched", Username), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Username)
                Return True
            Else
                cLogging.AddLog("checkPass[s]: Pash did not match on: " & Username, Nothing, cLogging.LogType.WARNING_LOG, Nothing, Nothing, Nothing, Username)
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog("checkPass[s]: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the country by user ID.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function getCountryByUserID(ByVal UserID As Integer) As Integer
        Try
            Return Convert.ToInt32(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT CountryID FROM tblUser WHERE UserID = '{0}'", UserID))))
        Catch ex As Exception
            cLogging.AddLog("getCountryByUserID: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, UserID, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the user by ID.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function GetUserByID(ByVal UserID As Integer) As String
        Try
            Return Convert.ToString(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT Name + ' ' + Surname FROM tblUser WHERE UserID = {0}", UserID))))
        Catch ex As Exception
            cLogging.AddLog("GetUserByID: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, UserID, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the id by username.
    ''' </summary>
    ''' <param name="Username">The username.</param>
    ''' <returns></returns>
    Public Shared Function GetIdByUsername(ByVal Username As String) As Integer
        Try
            Return Convert.ToInt32(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT UserID FROM tblUser WHERE Username = '{0}'", Username))))
        Catch ex As Exception
            cLogging.AddLog("GetIdByUsername: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Username)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Checks the user auth.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <param name="UserAuthCode">The user auth code.</param>
    ''' <param name="AuthType">Type of the auth.</param>
    ''' <returns></returns>
    Public Shared Function CheckUserAuth(ByVal UserID As Integer, ByVal UserAuthCode As String, ByVal AuthType As ActivationKeyType) As Boolean
        Dim _AuthDateTime As DateTime
        Dim _CurrDateTime As DateTime

        Try
            _AuthDateTime = Convert.ToDateTime(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT tblActivationKey.TimeGenerated FROM tblActivationKey INNER JOIN " & _
                      "tblKeyType ON tblActivationKey.KeyTypeID = tblKeyType.KeyTypeID " & _
                             "WHERE tblActivationKey.ActivationKey = '{0}' AND tblActivationKey.UserID = {1} AND  tblKeyType.KeyType = '{2}'", UserAuthCode, UserID, AuthType))))
            _CurrDateTime = Convert.ToDateTime(cDBManager.GetExecuteScalar(New SqlCommand("SELECT GETDATE()")))

            If DateDiff(DateInterval.Minute, _AuthDateTime, _CurrDateTime) <= 30 Then
                Return True
            Else
                cLogging.AddLog("Checks the user auth failed:  timeDiff>30", Nothing, cLogging.LogType.WARNING_LOG, Nothing, UserID, Nothing, Nothing)
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog("CheckUserAuth: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, UserID, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Enables the user.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function EnableUser(ByVal UserID As Integer) As Boolean
        Try
            If cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblUser SET isEnabled = 'True' WHERE UserID = {0}", UserID))) > 0 Then
                Return True
            Else
                cLogging.AddLog("EnableUser: No users enabled", Nothing, cLogging.LogType.WARNING_LOG, Nothing, UserID, Nothing, Nothing)
                Return False
            End If
        Catch ex As Exception
            cLogging.AddLog("EnableUser: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, UserID, Nothing, Nothing)
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Gets all user types.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetAllUserTypes() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT Type FROM tblUserType"))
        Catch ex As Exception
            cLogging.AddLog("GetAllUserTypes: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the selected users form a given GridView.
    ''' </summary>
    ''' <param name="GridView">The grid view.</param>
    ''' <param name="Column">The column ID of the checkbox.</param>
    ''' <returns></returns>
    Public Shared Function GetSelectedUsers(ByVal GridView As GridView, ByVal Column As Integer) As selectedUsers
        Dim rIndex As Integer = 0
        Dim list As New LinkedList(Of Integer)
        Dim sb As New StringBuilder

        Try
            For Each row As GridViewRow In GridView.Rows
                Dim cb As CheckBox = row.FindControl("cbx")
                If (cb IsNot Nothing And cb.Checked) Then
                    list.AddLast(Convert.ToInt64(GridView.Rows(rIndex).Cells(Column).Text))
                    sb.Append(GridView.Rows(rIndex).Cells(3).Text)
                    sb.Append(", ")
                End If
                rIndex += 1
            Next
            Return New selectedUsers(sb.ToString, list.ToArray)
        Catch ex As Exception
            cLogging.AddLog("GetSelectedUsers: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets all users of a specific type.
    ''' </summary>
    ''' <param name="UserType">Type of the user.</param>
    ''' <returns></returns>
    Public Shared Function getAllUsersByUserType(ByVal UserType As String) As Integer()
        Try
            Dim dt As DataTable = cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblUser.UserID " & _
                             "FROM tblUser " & _
                             "INNER JOIN tblUserType ON tblUser.UserTypeID = tblUserType.UserTypeID " & _
                             "WHERE tblUserType.Type = '{0}'", UserType)))
            Dim list As New LinkedList(Of Integer)
            For index As Integer = 0 To dt.Rows.Count - 1
                list.AddLast(dt.Rows(index).Item("UserID"))
            Next
            Return list.ToArray
        Catch ex As Exception
            cLogging.AddLog("getAllUsersByUserType: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Gets the user details.
    ''' </summary>
    ''' <param name="userID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function getUserDetails(ByVal userID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblUser.Name, tblUser.Surname, tblCountry.Country, tblNationality.Nationality, " & _
                             "tblUser.DOB, tblUser.Town, tblUser.EmailAddress " & _
                             "FROM tblUser " & _
                             "INNER JOIN tblCountry ON tblUser.CountryID = tblCountry.CountryID " & _
                             "INNER JOIN tblNationality ON tblUser.NationalityID = tblNationality.NationalityID " & _
                             "INNER JOIN tblUserType ON tblUser.UserTypeID = tblUserType.UserTypeID " & _
                             "WHERE (tblUser.UserID = {0})", userID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("getUserDetails: for {0} {1}", userID, ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Reports the user.
    ''' </summary>
    ''' <param name="Reporter">The reporter.</param>
    ''' <param name="UserToReport">The user to report.</param>
    ''' <param name="Message">The message.</param>
    Public Shared Sub ReportUser(ByVal Reporter As Integer, ByVal UserToReport As Integer, ByVal Message As String)
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblFlaggedUsers " & _
                             "(ReporterUserId, ReportedUserId, ReportMessage, FlagStatusId) " & _
                             "VALUES ({0},{1},'{2}',1)", Reporter, UserToReport, Message)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("ReportUser: on reporter:{0} userToReport{1} {2}", Reporter, UserToReport, ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Gets all system admins by value.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function GetAllSystemAdminsByValue(ByVal value As String) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblUser.UserID, tblUser.Name + ' ' + tblUser.Surname AS [Admin Name], " & _
                             "tblCountry.Country, tblCountry.CountryCode " & _
                             "FROM tblUser " & _
                             "INNER JOIN tblCountry ON tblCountry.CountryID = tblUser.CountryID " & _
                             "WHERE ((tblUser.Name LIKE '%{0}%') OR (tblUser.Surname LIKE '%{0}') " & _
                             "OR (tblCountry.Country LIKE '%{0}%')) AND (tblUser.isEnabled = 'True')", value)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("GetAllSystemAdminsByValue: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets all users by value.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function GetAllUsersByValue(ByVal value As String) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblUser.UserID, tblUser.Name + ' ' + tblUser.Surname AS [User Name], " & _
                             "tblUserType.Type ,tblCountry.Country, tblCountry.CountryCode " & _
                             "FROM tblUser " & _
                             "INNER JOIN tblCountry ON tblCountry.CountryID = tblUser.CountryID " & _
                             "INNER JOIN tblUserType ON tblUser.UserTypeID = tblUserType.UserTypeID " & _
                             "WHERE ((tblUser.Name LIKE '%{0}%') OR (tblUser.Surname LIKE '%{0}%') OR (tblCountry.Country LIKE '%{0}%')) " & _
                             "AND (tblUser.isEnabled = 'True')", value)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("GetAllUsersByValue: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Gets the user profile.
    ''' </summary>
    ''' <param name="UserID">The user ID.</param>
    ''' <returns></returns>
    Public Shared Function getUserProfile(ByVal UserID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblUser.Name, tblUser.Surname, tblUser.DOB, tblNationality.Nationality, " & _
                             "tblUser.Address, tblUser.StreetAddress, tblUser.Town, tblUser.PostCode, tblUser.CountryID, tblUser.TelephoneNo, tblUser.EmailAddress " & _
                             "FROM tblUser " & _
                             "INNER JOIN tblNationality ON tblUser.NationalityID = tblNationality.NationalityID " & _
                             "WHERE tblUser.UserID ={0}", UserID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("getUserProfile: on {1} {0}", ex.Message, UserID), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Custom datatype that contains an array of UserIDs and array of UserNames
    ''' </summary>
    Public Class selectedUsers
        Private _userIds As Integer()
        Public ReadOnly Property UserIds() As Integer()
            Get
                Return _userIds
            End Get
        End Property

        Private _usernameString As String
        Public ReadOnly Property UserNameString() As String
            Get
                Return _usernameString
            End Get
        End Property

        Public Sub New(ByVal srt As String, ByVal id As Integer())
            Me._usernameString = srt
            Me._userIds = id
        End Sub

        Public Sub New(ByVal id As Integer())
            Me._userIds = id
        End Sub
    End Class
End Class




