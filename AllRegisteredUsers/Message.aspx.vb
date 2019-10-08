
Partial Class AllRegisteredUsers_Message
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
    Private Sub BindAccordion()
        Dim dt As New System.Data.DataTable
        dt = cMessageManagement.GetMessageDetails(Session("MessageToUser"), Session("MessageID"))
        Accmessages.DataSource = dt.DefaultView
        Accmessages.DataBind()
    End Sub

    Private Sub BindAccordion(ByVal Lang As String)
        Dim dt As New System.Data.DataTable
        Try
            dt = cMessageManagement.GetMessageDetails(Session("MessageToUser"), Session("MessageID"))
            If Not (Lang = "") Then
                For Each r As System.Data.DataRow In dt.Rows
                    Dim oldsubject As String = r.Item("Subject")
                    r.Item("Subject") = cRegional.Translate(Lang, oldsubject)
                    Dim oldBody As String = r.Item("Message")
                    r.Item("Message") = cRegional.Translate(Lang, oldBody)
                Next
            End If
            Accmessages.DataSource = dt.DefaultView
            Accmessages.DataBind()
            lblTranslateError.Visible = False
        Catch ex As Exception
            lblTranslateError.Visible = True
        End Try
        
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objMessage As New cMessages(Session("MessageID"))
        If objMessage.MessageTypeID = cMessageType.MessageTypes.Ticket And UserDetails.userType = "SupportAdmin" Then
            plTicketFunctionality.Visible = True
        Else
            plTicketFunctionality.Visible = False
        End If
        If Not Page.IsPostBack Then
            LoadLanguageDropDown()
            BindAccordion()
        End If
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        UserDetails = Session("UserObject")
        If UserDetails.userType = "Employee" Then
            Me.MasterPageFile = "~/Employees/EmployeeMasterPage.master"
        End If
        If UserDetails.userType = "Employer" Then
            Me.MasterPageFile = "~/Employers/EmployerMasterPage.master"
        End If
        If UserDetails.userType = "CenterAdmin" Then
            Me.MasterPageFile = "~/CenterAdmin/CenterAdminMasterPage.master"
        End If
        If UserDetails.userType = "SupportAdmin" Then
            Me.MasterPageFile = "~/System/Support/SupportMasterPage.master"
        End If
    End Sub

    Protected Sub btnReply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkReply.Click
        If cMessageToUser.CheckIfClosed(Session("MessageToUser")) Then
            lblError.Text = "Message Is Closed"
        Else
            plReply.Visible = True
        End If
    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If txtSubject.Text.Trim <> "" And Message.Content.Trim <> "" Then
            lblInvalid.Visible = False
            Dim oldmess As New cMessages(Session("MessageID"))
            Dim oldmessto As New cMessageToUser(Session("MessageToUser"))
            Dim LangID As Integer
            If ddlLanguageSavingTo.SelectedValue = "" Then
                LangID = cRegional.getLanguageIDfromLanguage(cRegional.DetectLanguage(Message.Content))
            Else
                LangID = cRegional.getLanguageIDfromLanguage(ddlLanguageSavingTo.SelectedValue)
            End If
            If LangID = 0 Then
                LangID = cRegional.getLanguageIDfromLanguage("English")
            End If
            Dim objMessage As New cMessages(txtSubject.Text, Message.Content, UserDetails.userId, oldmess.MessageTypeID, LangID)
            Dim NewMessID As Integer = cMessageManagement.StoreMessage(objMessage)
            Dim objmessageTo As New cMessageToUser(NewMessID, oldmess.FromUser, False, Session("MessageID"))
            If cMessageManagement.StoreMessageToUser(objmessageTo) > 0 Then
                lblError.Visible = False
                lblSuccess.Visible = True
                plReply.Visible = False
                txtSubject.Text = ""
                Message.Content = ""
                cMessageManagement.UpdateMessageToUnread(Session("MessageToUser"))
            Else
                lblError.Visible = True
                lblSuccess.Visible = False
            End If
        Else
            lblInvalid.Visible = True
        End If
    End Sub

    Private Sub LoadLanguageDropDown()
        Dim dt As New System.Data.DataTable
        dt = cRegional.getAllLanguages
        ddlLanguages.DataSource = dt
        ddlLanguageSavingTo.DataSource = dt
        ddlLanguages.DataTextField = "Language"
        ddlLanguageSavingTo.DataTextField = "Language"
        ddlLanguages.DataBind()
        ddlLanguageSavingTo.DataBind()
        ddlLanguages.Items.Insert(0, "")
        ddlLanguageSavingTo.Items.Insert(0, "")
        ddlLanguages.SelectedIndex = 0
        ddlLanguageSavingTo.SelectedIndex = 0
    End Sub

    Protected Sub ddlLanguages_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLanguages.SelectedIndexChanged
        BindAccordion(ddlLanguages.SelectedValue)
    End Sub


    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDelete.Click
        If cMessageManagement.UpdateClosedStatus(Session("MessageToUser")) Then
            lblError.Text = "Message Updated as Closed"
        Else
            lblError.Text = "Message Not Updated"
        End If
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDelete.Click
        If cMessageManagement.UpdateDeletedStatus(Session("MessageToUser")) Then
            lblError.Text = "Message Deleted"
        Else
            lblError.Text = "Message Not Deleted"
        End If
    End Sub

    Protected Sub btnUnAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkUnAssign.Click
        cTicketManagment.UnAssignTicket(cTicketManagment.GetTicketByMessageID(Session("MessageID")))
        Response.Redirect("~/System/SystemDefault.aspx", False)
    End Sub

    
    Protected Sub btnEscalate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEscalate.Click
        cTicketManagment.EscalateTicket(cTicketManagment.GetTicketByMessageID(Session("MessageID")))
        cTicketManagment.UnAssignTicket(cTicketManagment.GetTicketByMessageID(Session("MessageID")))
        If UserDetails.userType = "SupportAdmin" Then
            Response.Redirect("~//System/Support/TicketManagement")
        Else
            Response.Redirect("~//System/Admin/EscalatedTickets")
        End If
    End Sub

    Protected Sub btnSolved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSolved.Click
        If cTicketManagment.UpdateTicketStatus(cTicketManagment.GetTicketByMessageID(Session("MessageID")), cTicketManagment.TicketStatus.Solved > 0) Then
            cMessageManagement.UpdateClosedStatus(Session("MessageToUser"))
            If UserDetails.userType = "SupportAdmin" Then
                Response.Redirect("~//System/Support/TicketManagement")
            Else
                Response.Redirect("~//System/Admin/EscalatedTickets")
            End If
        End If

    End Sub
End Class


