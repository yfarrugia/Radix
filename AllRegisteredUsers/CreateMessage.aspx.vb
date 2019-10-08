Imports System.Data
Partial Class AllRegisteredUsers_CreateMessage
    Inherits System.Web.UI.Page
    Private _refUserObj As cUser
    Public Property UserDetails() As cUser
        Get
            Return _refUserObj
        End Get
        Set(ByVal value As cUser)
            _refUserObj = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Enquire As String = Request.QueryString("Enquire")
        If enquire = "Yes" Then
            SetForEnquiry()
        Else
            Dim selected As cUser.selectedUsers
            selected = cUser.GetSelectedUsers(GdvRecipients, 1)
            txtRecepients.Text = selected.UserNameString
        End If
        If Not Page.IsPostBack Then
            Dim dtLangs As New DataTable
            dtLangs = cRegional.getAllLanguages()
            ddlLanguages.DataSource = dtLangs
            ddlLanguages.DataTextField = "Language"
            ddlLanguages.DataBind()
            ddlLanguages.Items.Insert(0, "")
        End If
    End Sub

    Private Sub SetForEnquiry()
        Dim objJobRequest As New cJobRequestTo(Session("RequestID"))
        Dim objJob As New cJob(objJobRequest.JobID)
        txtRecepients.Text = cCompany.getCompanyName(objJob.CompanyID)
        btnAddRecepients.Enabled = False
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        UserDetails = Session("UserObject")

        Select Case UserDetails.userType
            Case "Employer"
                Me.MasterPageFile = "~/Employers/EmployerMasterPage.master"
            Case "CenterAdmin"
                Me.MasterPageFile = "~/CenterAdmin/CenterAdminMasterPage.master"
            Case "SystemAdmin"
                Me.MasterPageFile = "~/System/Admin/SystemMasterPage.master"
            Case "SupportAdmin"
                Me.MasterPageFile = "~/System/Support/SupportMasterPage.master"
            Case "Employee"
                Me.MasterPageFile = "~/Employees/EmployeeMasterPage.master"
            Case Else
                FormsAuthentication.RedirectToLoginPage()
        End Select

    End Sub


    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim Enquire As String = Request.QueryString("Enquire")
        If Enquire = "Yes" Then
            lblMessage.Text = StoreMessage(Session("RequestID"))
        Else
            lblMessage.Text = StoreMessages(cUser.GetSelectedUsers(GdvRecipients, 1))
        End If
        
    End Sub

    Private Function StoreMessage(ByVal JobRequestID As Integer) As String
        Dim messageID As Integer
        Dim Language As String
        If ddlLanguages.SelectedValue = "" Then
            Language = cRegional.DetectLanguage(Message.Content)
        Else
            Language = ddlLanguages.SelectedValue
        End If
        If Language = "Unknown" Then
            Language = "English"
        End If
        Dim objJobRequest As New cJobRequestTo(Session("RequestID"))
        Dim objJob As New cJob(objJobRequest.JobID)
        Dim langID As Integer = cRegional.getLanguageIDfromLanguage(Language)
        If langID = 0 Then
            langID = cRegional.getLanguageIDfromLanguage("English")
        End If
        Dim objMessage As New cMessages(txtSubject.Text, Message.Content, objJobRequest.ToUser, cMessageType.MessageTypes.Enquire, langID)
        messageID = cMessageManagement.StoreMessage(objMessage)
        Dim objMessageTo As New cMessageToUser(messageID, cCompany.GetEmployerForCompany(objJob.CompanyID), False, Nothing)
        Dim rowseffected As Integer = cMessageManagement.StoreMessageToUser(objMessageTo)
        If rowseffected > 0 Then
            Return "Sent Message to " & cCompany.getCompanyName(objJob.CompanyID)
            txtSubject.Text = ""
            Message.Content = Nothing
        Else
            Return "Message Not Sent"
        End If
    End Function
    Private Function StoreMessages(ByVal selected As cUser.selectedUsers) As String
        Try
            Dim messageID As Integer
            Dim Language As String
            If ddlLanguages.SelectedValue = "" Then
                Language = cRegional.DetectLanguage(Message.Content)
            Else
                Language = ddlLanguages.SelectedValue
            End If
            If Language = "Unknown" Then
                Language = "English"
            End If
            If selected.UserIds.Count = 0 Then
                Dim e As NullReferenceException
                Throw e
            End If
            If UserDetails.userType = "SystemAdmin" Then
                Dim objMessage As New cMessages(txtSubject.Text, Message.Content, UserDetails.userId, cMessageType.MessageTypes.System, cRegional.getLanguageIDfromLanguage(Language))
                messageID = cMessageManagement.StoreMessage(objMessage)
            Else
                Dim objMessage As New cMessages(txtSubject.Text, Message.Content, UserDetails.userId, cMessageType.MessageTypes.Normal, cRegional.getLanguageIDfromLanguage(Language))
                messageID = cMessageManagement.StoreMessage(objMessage)
            End If
            For Each User As Integer In selected.UserIds
                Dim objMessageTo As New cMessageToUser(messageID, User, False, Nothing)
                cMessageManagement.StoreMessageToUser(objMessageTo)
            Next
            Return "Sent messages to " & selected.UserNameString
        Catch
            Return "Message(s) not Sent"
        End Try
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtCriteria.Text <> "" Then
            bindGridView()
        End If
    End Sub

    Private Sub bindGridView()
        Select Case UserDetails.userType
            Case "Employer"
                GdvRecipients.DataSource = cEmployee.GetEmployeesByValue(txtCriteria.Text)
                GdvRecipients.DataBind()
                GdvRecipients.HeaderRow.Cells(1).Visible = False
                GdvRecipients.HeaderRow.Cells(6).ColumnSpan = 2
                GdvRecipients.HeaderRow.Cells(7).Visible = False
                GdvRecipients.HeaderRow.Cells(0).Text = ""
                GdvRecipients.HeaderRow.Cells(3).Text = ""
                GdvRecipients.HeaderRow.Cells(4).Text = ""
                GdvRecipients.HeaderRow.Cells(5).Text = ""
                Dim isSeeking As New CheckBox
                Dim isEmployed As New CheckBox
                Dim isSponsored As New CheckBox
                Dim flagname As String
                For Each gvr As GridViewRow In GdvRecipients.Rows
                    gvr.Cells(1).Visible = False
                    Dim imgSeeking As New Image
                    Dim imgEmployed As New Image
                    Dim imgSponsored As New Image
                    Dim imgflag As New Image

                    isSeeking = gvr.Cells(3).Controls(0)
                    isEmployed = gvr.Cells(4).Controls(0)
                    isSponsored = gvr.Cells(5).Controls(0)
                    gvr.Cells(3).Controls.Clear()
                    gvr.Cells(4).Controls.Clear()
                    gvr.Cells(5).Controls.Clear()

                    If isSeeking.Checked Then
                        imgSeeking.ImageUrl = "../Images/Icons/Seeking.png"
                        imgSeeking.ToolTip = "Seeking Employment"
                    Else
                        imgSeeking.ImageUrl = "../Images/Icons/NotSeeking.png"
                        imgSeeking.ToolTip = "Not Seeking Employment"
                    End If
                    If isEmployed.Checked Then
                        imgEmployed.ImageUrl = "../Images/Icons/Employed.png"
                        imgEmployed.ToolTip = "Currently Employed"
                    Else
                        imgEmployed.ImageUrl = "../Images/Icons/NotEmployed.png"
                        imgEmployed.ToolTip = "Not Currently Employed"
                    End If
                    If isSponsored.Checked Then
                        imgSponsored.ImageUrl = "../Images/Icons/Sponsored.png"
                        imgSponsored.ToolTip = "Sponsored"
                    Else
                        imgSponsored.ImageUrl = "../Images/Icons/NotSponsored.png"
                        imgSponsored.ToolTip = "Not Sponsored"
                    End If
                    gvr.Cells(3).Controls.Add(imgSeeking)
                    gvr.Cells(4).Controls.Add(imgEmployed)
                    gvr.Cells(5).Controls.Add(imgSponsored)
                    flagname = gvr.Cells(7).Text
                    imgflag.ImageUrl = "../Images/Flags/" & flagname & ".png"
                    gvr.Cells(7).Controls.Add(imgflag)
                Next
            Case "CenterAdmin"
                GdvRecipients.DataSource = cEmployee.GetEmployeesByValue(txtCriteria.Text, cCenter.getCenterByUserID(UserDetails.userId))
                GdvRecipients.DataBind()
                GdvRecipients.HeaderRow.Cells(1).Visible = False
                GdvRecipients.HeaderRow.Cells(6).ColumnSpan = 2
                GdvRecipients.HeaderRow.Cells(7).Visible = False
                Dim isSeeking As New CheckBox
                Dim isEmployed As New CheckBox
                Dim isSponsored As New CheckBox
                Dim flagname As String
                For Each gvr As GridViewRow In GdvRecipients.Rows
                    gvr.Cells(1).Visible = False
                    Dim imgSeeking As New Image
                    Dim imgEmployed As New Image
                    Dim imgSponsored As New Image
                    Dim imgflag As New Image

                    isSeeking = gvr.Cells(3).Controls(0)
                    isEmployed = gvr.Cells(4).Controls(0)
                    isSponsored = gvr.Cells(5).Controls(0)
                    gvr.Cells(3).Controls.Clear()
                    gvr.Cells(4).Controls.Clear()
                    gvr.Cells(5).Controls.Clear()
                    If isSeeking.Checked Then
                        imgSeeking.ImageUrl = "../Images/Icons/Seeking.png"
                        imgSeeking.ToolTip = "Seeking Employment"
                    Else
                        imgSeeking.ImageUrl = "../Images/Icons/NotSeeking.png"
                        imgSeeking.ToolTip = "Not Seeking Employment"
                    End If
                    If isEmployed.Checked Then
                        imgEmployed.ImageUrl = "../Images/Icons/Employed.png"
                        imgEmployed.ToolTip = "Currently Employed"
                    Else
                        imgEmployed.ImageUrl = "../Images/Icons/NotEmployed.png"
                        imgEmployed.ToolTip = "Not Currently Employed"
                    End If
                    If isSponsored.Checked Then
                        imgSponsored.ImageUrl = "../Images/Icons/Sponsored.png"
                        imgSponsored.ToolTip = "Sponsored"
                    Else
                        imgSponsored.ImageUrl = "../Images/Icons/NotSponsored.png"
                        imgSponsored.ToolTip = "Not Sponsored"
                    End If
                    gvr.Cells(3).Controls.Add(imgSeeking)
                    gvr.Cells(4).Controls.Add(imgEmployed)
                    gvr.Cells(5).Controls.Add(imgSponsored)
                    flagname = gvr.Cells(7).Text
                    imgflag.ImageUrl = "../Images/Flags/" & flagname & ".png"
                    gvr.Cells(7).Controls.Add(imgflag)
                Next
            Case "SupportAdmin"
                GdvRecipients.DataSource = cUser.GetAllSystemAdminsByValue(txtCriteria.Text)
                GdvRecipients.DataBind()
                GdvRecipients.HeaderRow.Cells(1).Visible = False
                GdvRecipients.HeaderRow.Cells(3).ColumnSpan = 2
                GdvRecipients.HeaderRow.Cells(4).Visible = False
                Dim flagname As String
                For Each gvr As GridViewRow In GdvRecipients.Rows
                    gvr.Cells(1).Visible = False
                    Dim imgflag As New Image
                    flagname = gvr.Cells(4).Text
                    imgflag.ImageUrl = "../Images/Flags/" & flagname & ".png"
                    gvr.Cells(4).Controls.Add(imgflag)
                Next
            Case "SystemAdmin"
                GdvRecipients.DataSource = cUser.GetAllUsersByValue(txtCriteria.Text)
                GdvRecipients.DataBind()
                GdvRecipients.HeaderRow.Cells(1).Visible = False
                GdvRecipients.HeaderRow.Cells(4).ColumnSpan = 2
                GdvRecipients.HeaderRow.Cells(5).Visible = False
                Dim flagname As String
                For Each gvr As GridViewRow In GdvRecipients.Rows
                    gvr.Cells(1).Visible = False
                    Dim imgflag As New Image
                    flagname = gvr.Cells(5).Text
                    imgflag.ImageUrl = "../Images/Flags/" & flagname & ".png"
                    gvr.Cells(5).Controls.Add(imgflag)
                Next
        End Select


    End Sub
    Protected Function getPostBack() As String
        Return Page.ClientScript.GetPostBackEventReference(Me, "btnClose")
    End Function

End Class
