Imports System.Data


Partial Class AllRegisteredUsers_UserProfile
    Inherits System.Web.UI.Page
    Private Emp As cEmployee
    Private dtProfile As DataTable
    Private dtCompany As DataTable
    Private SelectedUser As Integer

    Private _refUserObj As cUser

    Public Property UserDetails() As cUser
        Get
            Return _refUserObj
        End Get
        Set(ByVal value As cUser)
            _refUserObj = value
        End Set
    End Property

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        UserDetails = Session("UserObject")

        Select Case UserDetails.userType
            Case "Employee"
                Me.MasterPageFile = "~/Employees/EmployeeMasterPage.master"
            Case "Employer"
                Me.MasterPageFile = "~/Employers/EmployerMasterPage.master"
            Case "CenterAdmin"
                Me.MasterPageFile = "~/CenterAdmin/CenterAdminMasterPage.master"
                'Session("FormName") = "CenterAdmin"
            Case "SupportAdmin"
                Me.MasterPageFile = "~/System/Support/SupportMasterPage.master"
        End Select


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetCountries()

            Try


                Select Case UserDetails.userType
                    Case "Employee"
                        pnlEmployeeDetails.Visible = True
                        TabPanel3.Visible = True
                        dtProfile = cEmployee.getEmployeeProfile(UserDetails.userId)
                        checkUserCenter(UserDetails.userId)

                        setUserTextboxes()
                        setEmployeeTextboxes()
                        setEmployeeBooleans()

                    Case "Employer"
                        'dtProfile = cEmployee.getEmployeeProfile(UserDetails.userId)
                        dtProfile = cUser.getUserProfile(UserDetails.userId)
                        setUserTextboxes()
                        dtCompany = cCompany.getCompanyDetailsByEmployer(UserDetails.userId)
                        TabPanel5.Visible = True
                        'enable company tab

                    Case "CenterAdmin"
                        'when center adminlogs in as an employee
                        'view center employees
                        If Session("SelectedUserID") <> Nothing Then
                            SelectedUser = Session("SelectedUserID")

                            pnlEmployeeDetails.Visible = True
                            TabPanel3.Visible = True
                            txtUsername.Text = cUser.getUsername(Session("SelectedUserID"))
                            dtProfile = cEmployee.getEmployeeProfile(Session("SelectedUserID"))
                            checkUserCenter(Session("SelectedUserID"))

                            setUserTextboxes()
                            setEmployeeTextboxes()
                            setEmployeeBooleans()

                            Session("SelectedUserID") = Nothing
                            dtProfile = Nothing

                            'center admin     
                        Else
                            dtProfile = cUser.getUserProfile(UserDetails.userId)
                            checkUserCenter(UserDetails.userId)
                            setUserTextboxes()

                            'enableUpdate Center Details tab

                        End If

                    Case "SupportAdmin"
                        'dtProfile = cEmployee.getEmployeeProfile(UserDetails.userId)
                        dtProfile = cUser.getUserProfile(Session("SelectedUserID"))
                        setUserTextboxes()

                End Select

            Catch ex As Exception

            Finally

                dtProfile = Nothing

            End Try



        End If
    End Sub

    Public Sub GetCountries()
        Dim dtCountries As DataTable
        dtCountries = Nothing

        dtCountries = cRegional.GetCountries()
        If Not dtCountries.Equals(Nothing) Then
            ddlCountry.DataSource = dtCountries
            ddlCountry.DataValueField = "CountryID"
            ddlCountry.DataTextField = "Country"
            ddlCountry.DataBind()
        Else
            cLogging.AddLog("Countries could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        End If

    End Sub

    Private Sub ToggleButtons(ByVal _isReadOnly As Boolean)

        txtSurname.ReadOnly = _isReadOnly
        txtAddress.ReadOnly = _isReadOnly
        txtStrAddress.ReadOnly = _isReadOnly
        txtTown.ReadOnly = _isReadOnly
        txtEmail.ReadOnly = _isReadOnly
        ddlCountry.Enabled = Not (_isReadOnly)
        txtTelephoneNo.ReadOnly = _isReadOnly
        txtPostCode.ReadOnly = _isReadOnly

    End Sub


    'Personal Details Tab

    Public Sub setUserTextboxes()

        Dim dr As DataRow

        Try

            If dtProfile.Rows.Count > 0 Then

                For Each dr In dtProfile.Rows

                    txtName.Text = dr("Name")
                    txtSurname.Text = dr("Surname")
                    txtNationality.Text = dr("Nationality")

                    txtAddress.Text = dr("Address")
                    txtStrAddress.Text = dr("StreetAddress")
                    txtPostCode.Text = dr("PostCode")
                    txtTown.Text = dr("Town")

                    Dim _countryID As Integer = dr("CountryID")
                    Dim Country As String = cRegional.GetCountry(_countryID)
                    ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByText(Country))


                    txtDOB.Text = dr("DOB")
                    txtEmail.Text = dr("EmailAddress")

                    If Not dr("TelephoneNo").ToString = "" Then
                        txtTelephoneNo.Text = dr("TelephoneNo")

                    End If



                    txtUsername.Text = checkIfSessionUser().username

                Next


            Else
                cLogging.AddLog("Employee Details could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
            End If


        Catch ex As Exception
            System.Diagnostics.Debug.Write(ex.Message)
        End Try
    End Sub

    Public Sub setEmployeeTextboxes()

        Dim dr As DataRow

        Try

            If dtProfile.Rows.Count > 0 Then

                For Each dr In dtProfile.Rows

                    'txtName.Text = dr("Name")
                    'txtSurname.Text = dr("Surname")
                    'txtNationality.Text = dr("Nationality")

                    'txtAddress.Text = dr("Address")
                    'txtStrAddress.Text = dr("StreetAddress")
                    'txtPostCode.Text = dr("PostCode")
                    'txtTown.Text = dr("Town")

                    'Dim _countryID As Integer = dr("CountryID")
                    'Dim Country As String = cRegional.GetCountry(_countryID)
                    'ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByText(Country))


                    'txtDOB.Text = dr("DOB")
                    'txtEmail.Text = dr("EmailAddress")

                    'If Not dr("TelephoneNo").ToString = "" Then
                    '    txtTelephoneNo.Text = dr("TelephoneNo")

                    'End If

                    If dr("isEmployed") = True Then
                        chkEmployed.Checked = True
                    End If


                    If dr("isSeeking") = True Then
                        chkSeeking.Checked = True
                    End If

                    If dr("Sponsored") = True Then
                        chkSponsored.Checked = True
                    End If

                    'txtUsername.Text = UserDetails.username

                Next


            Else
                cLogging.AddLog("Employee Details could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
            End If


        Catch ex As Exception
            System.Diagnostics.Debug.Write(ex.Message)
        End Try
    End Sub

    Private Function checkIfSessionUser() As cUser
        Dim tmpUser As cUser = Nothing
        If Session("SelectedUserID") <= 0 Then
            tmpUser = Session("UserObject")
        Else
            tmpUser = Session("SelectedUserID")
        End If
        Return tmpUser
    End Function
    Private Sub setEmployeeBooleans()
        Try
            Dim dt As DataTable = cEmployee.getEmployeeByID(checkIfSessionUser().userId)
            Emp = New cEmployee(dt, checkIfSessionUser().userId)
            Emp.ParseDataTableDetails(dt)

            If Not (chkEmployed.Checked = Emp.isEmployed) Then
                Emp.isEmployed = chkEmployed.Checked
            End If

            If Not (chkSeeking.Checked = Emp.isSeeking) Then
                Emp.isSeeking = chkSeeking.Checked
            End If

            If Not (chkSponsored.Checked = Emp.Sponsored) Then
                Emp.Sponsored = chkSponsored.Checked
            End If



        Catch ex As Exception


        End Try


    End Sub

    Protected Sub btnEditPersonalDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditPersonalDetails.Click
        If txtSurname.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If
        If UserDetails.userType = "Employee" Then

            pnlEmployeeDetails.Visible = True
            chkEmployed.Enabled = True
            chkSeeking.Enabled = True
            chkSponsored.Enabled = True
        End If

    End Sub

    Protected Sub btnSavePersonalDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSavePersonalDetails.Click
        Try

            Dim _UpdateUser As cUser = New cUser(txtSurname.Text)

            'intiate save sequence
            cUser.UpdateUser(_UpdateUser, Session("SelectedUserID"))
            'cUser.UpdateUser(UpdateUser, UserDetails.userId)




            If UserDetails.userType = "Employee" Then
                setEmployeeBooleans()
                cEmployee.UpdateEmployee(Emp, UserDetails.userId)

            ElseIf UserDetails.userType = "CenterAdmin" Then
                cEmployee.UpdateEmployee(Emp, SelectedUser)
            End If

            cLogging.AddLog("Successfully Updated User, UserID" & Session("SelectedUserID"), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)
        Catch ex As Exception
            cLogging.AddLog("Error Updating User: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)

        End Try

    End Sub


    'Contact Details Tab

    Protected Sub btnEditContactDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditContactDetails.Click
        If txtAddress.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        If txtStrAddress.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        If txtTown.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        If txtEmail.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        If txtTelephoneNo.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        If txtPostCode.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If


    End Sub

    Protected Sub btnSaveContactDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveContactDetails.Click

        Try

            Dim UpdateUser As cUser
            Dim originalCID As Integer = cUser.getCountryByUserID(Session("SelectedUserID"))
            'Dim originalCID As Integer = cUser.getCountryByUserID(UserDetails.userId)
            Dim c As String = ddlCountry.SelectedValue

            If c <> originalCID Then
                UpdateUser = New cUser(txtAddress.Text, _
                                                  txtStrAddress.Text, _
                                                  txtTown.Text, _
                                                  txtState.Text, _
                                                  txtPostCode.Text, _
                                                  txtTelephoneNo.Text, _
                                                  txtEmail.Text, _
                                                  c)

            Else
                UpdateUser = New cUser(txtAddress.Text, _
                                                 txtStrAddress.Text, _
                                                 txtTown.Text, _
                                                 txtState.Text, _
                                                 txtPostCode.Text, _
                                                 txtTelephoneNo.Text, _
                                                 txtEmail.Text, _
                                                 originalCID)
            End If
            'intiate save sequence
            cUser.UpdateUser(UpdateUser, UserDetails.userId)
        Catch ex As Exception
            cLogging.AddLog("Error Updating User: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try

    End Sub


    'Center Details Tab

    Private Sub checkUserCenter(ByVal _UserID As Integer)

        Dim centerID As Integer = cEmployee.GetAssociatedCenterID(_UserID)

        If Not centerID = 0 Then
            txtCenter.Text = cCenter.GetCenterNameById(centerID)
            txtCenterLocation.Text = cCenter.GetCenterLocationById(centerID)

        Else
            txtCenter.Text = "N/A"
            txtCenterLocation.Text = "N/A"

        End If

    End Sub

    Protected Sub SetCountry()
        Dim UserCountry As New cIpDetails(Request.ServerVariables("REMOTE_ADDR").ToString)
        Dim _userCountry As String
        _userCountry = UserCountry.getCountryName

        Dim i As Integer = cRegional.GetCountryID(_userCountry)

        If i > 0 Then
            ddlCenterCountry.SelectedValue = i
        Else
            'The country does not exist in our DB.
        End If

    End Sub

    Public Sub GetCenters()
        Dim dtCenters As DataTable
        dtCenters = cCenter.GetCenters(ddlCountry.SelectedValue)

        ddlCenter.Items.Clear()

        If dtCenters.Rows.Count > 0 Then
            ddlCenter.DataSource = dtCenters
            ddlCenter.DataValueField = "CenterID"
            ddlCenter.DataTextField = "CenterName"
            ddlCenter.DataBind()
            ddlCenter.Items.Add("None")
        Else
            ddlCenter.Items.Add("None")
            ddlCenter.SelectedValue = "None"
        End If
    End Sub

    Protected Sub btnChangeCenter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeCenter.Click
        pnlCenter.Visible = True
        btnChangeCenter.Visible = False

        GetCountries()
        SetCountry()
        GetCenters()
    End Sub

    Protected Sub btnSaveCenter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveCenter.Click
        If UserDetails.userType = "Employee" Then
            Dim myUser As cUser = Session("UserObject")
            cEmployee.MigrateEmployeeToCenter(ddlCenter.SelectedValue, myUser.userId)

        ElseIf UserDetails.userType = "CenterAdmin" Then
            cEmployee.MigrateEmployeeToCenter(ddlCenter.SelectedValue, SelectedUser)
        End If
    End Sub

    Protected Sub ddlCenterCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCenterCountry.SelectedIndexChanged
        Dim countryID As Integer = cRegional.GetCountryID(ddlCenterCountry.SelectedValue)
        ddlCenter.DataSource = cCenter.GetCenters(countryID)
    End Sub

    'Protected Sub TabPanel3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPanel3.Load
    '    If SelectedUser <> Nothing Then
    '        checkUserCenter(SelectedUser)
    '    Else
    '        checkUserCenter(checkIfSessionUser().userId)
    '    End If

    '    SelectedUser = Nothing

    'End Sub



    'Account Details Tab

    Protected Sub btnChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click

        'Dim _Username As String = cUser.getUsername(Session("SelectedUserId"))

        If cUser.checkPass(txtUsername.Text, txtOldPassword.Text) = True Then
            If txtNewPassword.Text = txtConfirmNewPassword.Text Then
                Dim newPassword As String = cHash.ComputeHash(txtNewPassword.Text)
                cUser.UpdateUserPassword(newPassword, UserDetails.userId)
            End If
        Else
            lblIncorrect.Visible = True
        End If

    End Sub


    'Company Details Tab

    Public Sub setCompanyTextboxes()

        Dim dr As DataRow

        Try

            If dtCompany.Rows.Count > 0 Then

                For Each dr In dtCompany.Rows

                    'SELECT tblCompany.CompanyName, tblCompany.Address, tblCompany.StreetAddress, tblCompany.Town, tblCompany.State, tblCountry.Country, tblCompany.PostCode, tblCompany.TelephoneNo, tblCompany.EmailAddress, tblCompany.VATNo, tblCompany.RegistrationNo FROM tblCompany INNER JOIN tblCountry ON tblCompany.CountryID = tblCountry.CountryID WHERE EmployerID = '" & _EmployerId & "'"
                    txtCompanyName.Text = dr("CompanyName")
                    txtCompanyAddress.Text = dr("Address")
                    txtCompStreetAddress.Text = dr("StreetAddress")
                    txtCompTown.Text = dr("Town")
                    txtCompState.Text = dr("State")
                    ddlCompCountry.Text = dr("Country")
                    txtCompPostCode.Text = dr("PostCode")

                    If Not dr("TelephoneNo").ToString = "" Then
                        txtCompanyTel.Text = dr("TelephoneNo")
                    End If

                    Dim Country As String = cRegional.GetCountry(ddlCompCountry.SelectedValue)
                    ddlCompCountry.SelectedIndex = ddlCompCountry.Items.IndexOf(ddlCompCountry.Items.FindByText(Country))

                    txtVatNo.Text = dr("VATNo")
                    txtCompEmail.Text = dr("EmailAddress")
                    txtRegNum.Text = dr("RegistrationNo")

                Next


            Else
                cLogging.AddLog("Company Details could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
            End If


        Catch ex As Exception
            System.Diagnostics.Debug.Write(ex.Message)
        End Try
    End Sub

    Protected Sub btnEditCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditCompany.Click
        enableCompanyControls()
    End Sub

    Private Sub enableCompanyControls()
        'txtCompanyName.ReadOnly = False
        txtCompanyAddress.ReadOnly = False
        txtCompanyTel.ReadOnly = False
        txtCompEmail.ReadOnly = False
        txtCompState.ReadOnly = False
        'txtVatNo.ReadOnly = False
        'txtRegNum.ReadOnly = False
        txtCompPostCode.ReadOnly = False
        txtCompStreetAddress.ReadOnly = False
        txtCompTown.ReadOnly = False

    End Sub

    Protected Sub btnSaveCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveCompany.Click

        Dim companyObject = New cCompany(dtCompany)
        companyObject.ParseDataTableDetails(dtCompany)
        companyObject.updateCompany(txtCompanyAddress.Text, txtCompStreetAddress.Text, txtCompTown.Text, txtCompState.Text, ddlCompCountry.SelectedValue, txtCompPostCode.Text, txtCompanyTel.Text, txtCompEmail.Text, UserDetails.userId, companyObject.CompanyID)

    End Sub


End Class
