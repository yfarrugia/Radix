Imports System.Data
Imports System.Diagnostics


Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Page.Form.DefaultFocus = txtUsername.UniqueID
        Page.Form.DefaultButton = btnSignIn.UniqueID

        'If Session("UserObject") = Nothing Then
        '    FormsAuthentication.SignOut()
        '    FormsAuthentication.RedirectToLoginPage()
        '    Session.Contents.Clear()
        '    'session expired
        '    cLogging.AddLog("Session Expired", Session("UserIP"), cLogging.LogType.INFORMATION_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page.Title = "Radix Systems"
        If Not (Page.IsPostBack) Then
            If (Session("UserIP") = "") Then

                Session("UserIP") = Request.ServerVariables("REMOTE_ADDR")
                Session("IPDetails") = New cIpDetails(Request.ServerVariables("REMOTE_ADDR"))
            End If
        End If

        MenuView.SetActiveView(AllUserView)
        'MenuView.  CONTINUE HERE
        tblLogin.Visible = True
        tblLoggedIn.Visible = False
        lblInvalidUser.Visible = False

        lblVersion.Text = String.Format("Version {0} Beta", ConfigurationManager.AppSettings.Item("Version"))

        'Checks if user is in a 'logged in' state or not.
        If Not (HttpContext.Current.User Is Nothing) Then
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                '                Dim o As cUser = Session("UserObject")
                tblLoggedIn.Visible = True
                tblLogin.Visible = False


                If Not Session("UserObject").Equals(Nothing) Then
                    Dim _UserObject As cUser = Session("UserObject")
                    Dim _UserIPDetails As cIpDetails = Session("IPDetails")


                    lblName.Text = _UserObject.name
                    lblUsername.Text = Request.ServerVariables("AUTH_USER")
                    lblUserType.Text = _UserObject.userType

                    lblUserCountry.Text = _UserIPDetails.getCountryName

                    Select Case _UserObject.userType
                        Case "Employee"
                            MenuView.SetActiveView(EmployeeView)
                        Case "Employer"
                            MenuView.SetActiveView(EmployerView)
                        Case "CenterAdmin"
                            MenuView.SetActiveView(CenterView)
                        Case "SystemAdmin"
                            MenuView.SetActiveView(SystemAdminView)
                        Case "SupportAdmin"
                            MenuView.SetActiveView(SystemSupportView)
                        Case Else
                            MenuView.SetActiveView(AllUserView)

                    End Select


                    'Dim myCountry As cIpDetails = Session("UserIP")

                    'lblUserCountry.Text = myCountry.getCountryName
                Else
                    FormsAuthentication.SignOut()
                    FormsAuthentication.RedirectToLoginPage()
                    Session.Contents.Clear()
                    'session expired
                    cLogging.AddLog("Session Expired", Session("UserIP"), cLogging.LogType.INFORMATION_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
                End If
                
            End If
        Else
            MenuView.SetActiveView(AllUserView)
            sessionVariableCleaner()
        End If
        Debug.Write("Session var count:" & Session.Count)
    End Sub

    Protected Sub btnSignIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        UserLogin()
    End Sub


    ''' <summary>
    ''' Clearing Session Variables that are not usable anymore 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub sessionVariableCleaner()
        Try
            If Not Request.Url.ToString.Contains("CenterProfile") Then
                If Not Session("CenterObject") = Nothing Then
                    Session.Remove("CenterObject")
                    Debug.Write("CenterObject Removed")
                End If
            End If
        Catch ex As Exception
            Debug.Write(String.Format("{0} {1}", ex.Message, ex.StackTrace))
        End Try
    End Sub

    Private Sub UserLogin()
        'Sign In Procedure
        If (LoginRegularEx(Trim(txtUsername.Text), Trim(txtPassword.Text))) Then
            If (cUser.checkPass(Trim(txtUsername.Text), Trim(txtPassword.Text))) Then
                'setSessionDetails()
                'TODO: make session user object
                Session("UserObject") = New cUser(cUserLogin.getUserDetails(Trim(txtUsername.Text)), Trim(txtUsername.Text))

                'TODO: test more plx
                FormsAuthentication.Initialize()
                If chkRemember.Checked Then
                    FormsAuthentication.RedirectFromLoginPage(Trim(txtUsername.Text), True)
                Else
                    FormsAuthentication.RedirectFromLoginPage(Trim(txtUsername.Text), False)
                End If


                cLogging.AddLog("User Login Sucessful - Username: " & txtUsername.Text, _
                                   Session("UserIP"), _
                                   cLogging.LogType.INFORMATION_LOG, _
                                   Session.SessionID, Session("UserID"), _
                                   Session("UserType"), _
                                   Request.ServerVariables("AUTH_USER"))

                Dim _UserObject As cUser = Session("UserObject")

                Select Case _UserObject.userType
                    Case "Employee"
                        Response.Redirect("~/Employees/Employee.aspx")
                    Case "Employer"
                        Response.Redirect("~/Employers/Employer.aspx")
                    Case "CenterAdmin"
                        Response.Redirect("~/CenterAdmin/CenterAdmin.aspx")
                    Case "SystemAdmin"
                        Response.Redirect("~/System/SystemDefault.aspx")
                    Case "SupportAdmin"
                        Response.Redirect("~/System/SystemDefault.aspx")
                End Select
            Else

                cLogging.AddLog("User Login Failed - Username: " & txtUsername.Text, _
                           Session("UserIP"), _
                           cLogging.LogType.WARNING_LOG, _
                           Session.SessionID, Session("UserID"), _
                           Session("UserType"), _
                           Request.ServerVariables("AUTH_USER"))
                lblInvalidUser.Visible = True
            End If
            'continue here....
        Else
            lblInvalidUser.Visible = True
        End If
    End Sub

    'TODO to e deleted
    'Private Sub setSessionDetails()
    '    Dim dtUsers As New DataTable
    '    dtUsers = cUserLogin.getUserDetails(Trim(txtUsername.Text))

    '    Dim _isEnabled As Boolean
    '    _isEnabled = Boolean.Parse((dtUsers.Rows.Item(0)("isEnabled")))
    '    If _isEnabled Then
    '        Dim _userID As Integer
    '        Dim _userType As String
    '        Dim _username As String
    '        Dim _name As String

    '        _userID = Convert.ToInt32(dtUsers.Rows.Item(0)("UserID"))
    '        _userType = Convert.ToString(dtUsers.Rows.Item(0)("Type"))
    '        _username = Trim(txtUsername.Text)
    '        _name = Convert.ToString(dtUsers.Rows.Item(0)("Name"))

    '        'CREATE USER OBJECT AND INIT HERE

    '        'Set Session variables
    '        Session("UserID") = _userID
    '        Session("UserType") = _userType
    '        Session("Name") = _name

    '        FormsAuthentication.Initialize()


    '    Else
    '        'account disabled/suspended
    '        'redirect user to the account re-enabling screen
    '    End If
    'End Sub

    Protected Sub btnSignOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignOut.Click
        'Sign Out Procedure
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
        Session.Contents.Clear()
        'logging
        cLogging.AddLog("Signed out", Session("UserIP"), cLogging.LogType.INFORMATION_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
    End Sub

    Private Function LoginRegularEx(ByVal Input1 As String, ByVal Input2 As String) As Boolean
        'Checks that the details entered are letters and/or numbers only
        Dim _re As Regex = New Regex("^[a-zA-Z0-9]*$")
        If _re.IsMatch(Input1) And _re.IsMatch(Input2) Then
            Return True
        Else
            cLogging.AddLog("Regex: Invalid characters", _
                           Session("UserIP"), _
                           cLogging.LogType.WARNING_LOG, _
                           Session.SessionID, Session("UserID"), _
                           Session("UserType"), _
                           Request.ServerVariables("AUTH_USER"))
            Return False
        End If
    End Function

End Class

