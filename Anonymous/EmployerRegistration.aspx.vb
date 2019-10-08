﻿Imports System.Data

Partial Class Anonymous_EmployeeRegistration
    Inherits System.Web.UI.Page
    Dim _selectedCountry As String
    Dim _selectedGenderBool As Boolean
    Dim _selectedGenderStr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            setStepLabels()
            GetNationalities()
            GetCountries()
            SetCountry()
            GetCompanyCountries()
            RegistrationProcessView.SetActiveView(UserAccountView)
        End If
    End Sub

    Private Sub setStepLabels()
        Dim _step1 As String = "Step 1. User Account"
        Dim _step2 As String = "Step 2. Personal Details"
        Dim _step3 As String = "Step 3. Personal Contact Details"
        Dim _step4 As String = "Step 4. Company Details"
        Dim _step5 As String = "Step 5. Summary"

        lblStep1_1.Text = _step1
        lblStep1_2.Text = _step1
        lblStep1_3.Text = _step1
        lblStep1_5.Text = _step1
        lblStep1_6.Text = _step1

        lblStep2_1.Text = _step2
        lblStep2_2.Text = _step2
        lblStep2_3.Text = _step2
        lblStep2_5.Text = _step2
        lblStep2_6.Text = _step2

        lblStep3_1.Text = _step3
        lblStep3_2.Text = _step3
        lblStep3_3.Text = _step3
        lblStep3_5.Text = _step3
        lblStep3_6.Text = _step3

        lblStep4_1.Text = _step4
        lblStep4_2.Text = _step4
        lblStep4_3.Text = _step4
        lblStep4_5.Text = _step4
        lblStep4_6.Text = _step4

        lblStep5_1.Text = _step5
        lblStep5_2.Text = _step5
        lblStep5_3.Text = _step5
        lblStep5_5.Text = _step5
        lblStep5_6.Text = _step5
    End Sub

    Protected Sub lnkAvailability_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAvailability.Click
        CheckUsernameExists()
    End Sub

    Public Function CheckUsernameExists() As Boolean
        If UsernameExists() Then
            imgTick.Visible = True
            imgCross.Visible = False
            Return True
        Else
            imgTick.Visible = False
            imgCross.Visible = True
            Return False
        End If
    End Function

    Public Function UsernameExists() As Boolean
        Return cUserRegistration.isExists(Trim(txtUsername.Text))
    End Function

    Public Sub GetNationalities()
        Dim dtNationalities As DataTable

        If Not cRegional.GetNationalities().Equals(Nothing) Then
            dtNationalities = cRegional.GetNationalities()

            ddlNationality.DataSource = dtNationalities
            ddlNationality.DataValueField = "NationalityID"
            ddlNationality.DataTextField = "Nationality"
            ddlNationality.DataBind()
        Else
            cLogging.AddLog("Nationalities could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        End If

    End Sub

    Public Sub GetCountries()
        Dim dtCountries As DataTable

        If Not cRegional.GetCountries().Equals(Nothing) Then
            dtCountries = cRegional.GetCountries()

            ddlCountry.DataSource = dtCountries
            ddlCountry.DataValueField = "CountryID"
            ddlCountry.DataTextField = "Country"
            ddlCountry.DataBind()
        Else
            cLogging.AddLog("Countries could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        End If
    End Sub

    Public Sub GetCompanyCountries()
        Dim dtCompanyCountries As DataTable
        dtCompanyCountries = cRegional.GetCountries()

        If dtCompanyCountries.Rows.Count > 0 Then
            ddlCompanyCountry.DataSource = dtCompanyCountries
            ddlCompanyCountry.DataValueField = "CountryID"
            ddlCompanyCountry.DataTextField = "Country"
            ddlCompanyCountry.DataBind()
        Else
            cLogging.AddLog("Company Countries could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        End If

    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearPG1.Click
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtConfPassword.Text = ""

        imgCross.Visible = False
        imgTick.Visible = False
    End Sub

    Protected Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinueAccount.Click
        If CheckUsernameExists() Then
            Session("Password") = cHash.ComputeHash(txtPassword.Text)
            RegistrationProcessView.SetActiveView(PersonalDetailsView)
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        RegistrationProcessView.SetActiveView(UserAccountView)
    End Sub

    Protected Sub btnBack_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStep1_3.Click
        RegistrationProcessView.SetActiveView(UserAccountView)
    End Sub
    Protected Sub btnBack_Click2(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStep1_2.Click
        RegistrationProcessView.SetActiveView(UserAccountView)
    End Sub

    Protected Sub ddlCountry_ChangedIndex(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCountry.SelectedIndexChanged
        _selectedCountry = ddlCountry.SelectedItem.ToString
        regexTelephone.ValidationExpression = cRegional.GetPhoneNumberRegex(_selectedCountry)
        regexPostCode.ValidationExpression = cRegional.GetPostCodeRegex(_selectedCountry)

        Select Case _selectedCountry
            Case "United States"
                lblCode.Text = "ZIP Code:"
            Case Else
                lblCode.Text = "Post Code:"
        End Select
    End Sub

    Protected Sub SetCountry()
        Dim UserCountry As New cIpDetails(Request.ServerVariables("REMOTE_ADDR").ToString)
        '"81.226.123.3" - Swedish IP used for testing.

        Dim _userCountry As String
        _userCountry = UserCountry.getCountryName

        Dim i As Integer = cRegional.GetCountryID(_userCountry)

        If i > 0 Then
            ddlCountry.SelectedValue = i
        Else
            'The country does not exist in our DB.
        End If

    End Sub

    Protected Sub btnContinuePersonal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinuePersonal.Click
        setUserGender()

        RegistrationProcessView.SetActiveView(ContactDetailsView)
    End Sub

    Private Sub setUserGender()
        If rdbMale.Checked Then
            _selectedGenderBool = 0
            _selectedGenderStr = rdbMale.Text
        Else
            _selectedGenderBool = 1
            _selectedGenderStr = rdbFemale.Text
        End If
    End Sub

    'Protected Sub lblStep3_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStep3_4.Click
    '    RegistrationProcessView.SetActiveView(ContactDetailsView)
    'End Sub

    Protected Sub btnBackContact_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBackContact.Click
        'This feature has been disabled
        'RegistrationProcessView.SetActiveView(PersonalDetailsView)
    End Sub


    'Protected Sub btnBackContact_Click2(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStep2_4.Click
    'This feature has been disabled
    'RegistrationProcessView.SetActiveView(PersonalDetailsView)
    'End Sub

    Protected Sub btnContinueContact_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinueContact.Click
        RegistrationProcessView.SetActiveView(ViewCompanyDetails)
    End Sub

    Public Sub SetSummary()
        lblSummaryUsername.Text = txtUsername.Text

        lblSummaryName.Text = txtName.Text
        lblSummarySurname.Text = txtSurname.Text
        lblSummaryDOB.Text = txtDOB.Text

        setUserGender()
        lblSummaryGender.Text = _selectedGenderStr
        lblSummaryNationality.Text = ddlNationality.SelectedItem.ToString

        lblSummaryCountry.Text = ddlCountry.SelectedItem.ToString

        lblSummaryAddress.Text = txtAddress.Text + ", " _
                                & "<BR>" & txtStreet.Text & ", " _
                                & "<BR>" & txtTown.Text _
                                & "<BR>" & txtState.Text

        lblSummaryPostCode.Text = txtPostCode.Text

        lblSummaryTelephone.Text = txtTel.Text
        lblSummaryEmail.Text = txtEmail.Text

        lblSummaryCompName.Text = txtCompanyName.Text
        lblSummaryVAT.Text = txtVATNo.Text
        lblSummaryReg.Text = txtRegNo.Text

        lblSummaryCompCountry.Text = ddlCompanyCountry.SelectedItem.ToString

        lblSummaryCompEmail.Text = txtCompanyEmail.Text
        lblSummaryCompTel.Text = txtCompanyTel.Text

        lblSummaryCompAdress.Text = txtCompanyAddress.Text + ", " _
                                & "<BR>" & txtCompanyStreet.Text & ", " _
                                & "<BR>" & txtCompanyTown.Text _
                                & "<BR>" & txtCompanyState.Text

        lblSummaryCompanyCode.Text = txtCompanyPostCode.Text
    End Sub


    Protected Sub btnModifyDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModifyDetails.Click
        RegistrationProcessView.SetActiveView(UserAccountView)
    End Sub

    Protected Sub btnConfirmDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmDetails.Click
        Dim _userID As Integer
        _userID = cUserRegistration.CreateUser(CollectUserDetails, cUserRegistration.UserType.EMPLOYER)

        If CreateEmployer(_userID) Then
            If CreateCompany(_userID) Then
                ConfirmationProcess(_userID)
                RegistrationProcessView.SetActiveView(SuccessfullView)
                Session.Remove("Password")
            Else
                cUserRegistration.DeleteUser(_userID)
                RegistrationProcessView.SetActiveView(FailedView)
            End If
        Else
            cUserRegistration.DeleteUser(_userID)
            RegistrationProcessView.SetActiveView(FailedView)
        End If
    End Sub

    Private Sub ConfirmationProcess(ByVal UserID As Integer)
        Dim AuthCode As String
        AuthCode = cHash.getRandomGeneratedCode(Date.Now.ToString)

        'if successfully inserted auth code into DB = true 
        Dim bRet As Boolean = cAuthorizationMessage.insertConfirmationCode(AuthCode, UserID, cUser.ActivationKeyType.REGISTRATION)
        If Convert.ToInt16(bRet) > 0 Then
            cAuthorizationMessage.RegistrationMessage(AuthCode, txtUsername.Text, txtEmail.Text)
        Else
            'Key was not inserted into the DB.
        End If

    End Sub

    Private Function CollectUserDetails() As cUser
        'Creates and returns the user details as a User Object
        Dim NewUser As New cUser(txtName.Text, _
                                     txtSurname.Text, _
                                     txtDOB.Text, _
                                     txtAddress.Text, _
                                     txtStreet.Text, _
                                     txtTown.Text, _
                                     txtState.Text, _
                                     txtPostCode.Text, _
                                     txtTel.Text, _
                                     txtEmail.Text, _
                                     txtUsername.Text, _
                                     Session("Password"), _
                                     _selectedGenderBool, _
                                     ddlNationality.SelectedValue, _
                                     ddlCountry.SelectedValue)
        Return NewUser
    End Function

    Private Function CollectCompanyDetails(ByVal _userID As Integer) As cCompany
        Dim NewCompany As New cCompany(txtCompanyName.Text, _
                               txtCompanyAddress.Text, _
                               txtCompanyStreet.Text, _
                               txtCompanyTown.Text, _
                               txtCompanyState.Text, _
                               ddlCompanyCountry.SelectedValue, _
                               txtCompanyPostCode.Text, _
                               txtCompanyTel.Text, _
                               txtEmail.Text, _
                               txtVATNo.Text, _
                               txtRegNo.Text, _
                               _userID)
        Return NewCompany
    End Function

    Private Function CreateEmployer(ByVal _userID As Integer) As Boolean
        Return cUserRegistration.CreateEmployer(_userID)
    End Function

    Private Function CreateCompany(ByVal _userID As Integer) As Boolean
        Return cUserRegistration.CreateCompany(CollectCompanyDetails(_userID))
    End Function

    Protected Sub btnContinueCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinueCompany.Click
        If CheckCompanyValid() > 0 Then
            lblInvalidCompany.Visible = False
            SetSummary()
            RegistrationProcessView.SetActiveView(SummaryView)
        Else
            lblInvalidCompany.Visible = True
        End If
    End Sub

    Private Function CheckCompanyValid() As Integer
        Dim dtResults As New DataTable
        dtResults = cCompany.VerifyCompany(Trim(txtCompanyName.Text), txtVATNo.Text, txtRegNo.Text, ddlCompanyCountry.SelectedItem.ToString)
        Return dtResults.Rows.Count
    End Function

End Class
