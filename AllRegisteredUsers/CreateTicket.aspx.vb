Imports System.Globalization
Partial Class AllRegisteredUsers_CreateTicket
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
    Private _browserLanguage As String
    Public Property BrowserLanguage() As String
        Get
            Return _browserLanguage
        End Get
        Set(ByVal value As String)
            _browserLanguage = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BrowserLanguage = cRegional.getLangaugefromLanguageCode((Request.ServerVariables("HTTP_ACCEPT_LANGUAGE")).Substring(0, 2))
        mvTickets.SetActiveView(vwCreate)
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
    End Sub


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If (txtSubject.Text.Trim <> "" And txtMessage.Text.Trim <> "") Then
            lblTicketID.Text = "Your Support Ticket ID is <b># " & StoreTicket() & "</b>"
            mvTickets.SetActiveView(vwTicketRegistered)
        End If
    End Sub

    Private Function StoreTicket() As Integer
        Dim objMessage As New cMessages(txtSubject.Text, txtMessage.Text, UserDetails.userId, cMessageManagement.MessageType.Ticket, cRegional.getLanguageIDfromLanguage(BrowserLanguage))
        Dim MessageID As Integer = cMessageManagement.StoreMessage(objMessage)
        Dim strpriority As String = rdblPriority.SelectedValue
        Dim ipriority As Integer
        If strpriority = "Medium" Then
            ipriority = 2
        ElseIf strpriority = "High" Then
            ipriority = 2
        Else
            ipriority = 1
        End If
        Dim objTicket As New cTicket(MessageID, ipriority, cTicketManagment.TicketStatus.Created)
        Return cTicketManagment.SaveTicket(objTicket)
    End Function
End Class
