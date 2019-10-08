
Partial Class System_Admin_EscalatedTickets
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
        If Not Page.IsPostBack Then
            BindUnassignedGridView()
            BindAssignedGridView()
        End If
    End Sub

    Private Sub BindUnassignedGridView()
        UserDetails = Session("UserObject")
        gdvTickets.DataSource = cTicketManagment.GetSystemUnAssignedTickets
        gdvTickets.DataBind()
    End Sub

    Private Sub BindAssignedGridView()
        UserDetails = Session("UserObject")
        gdvMytickets.DataSource = cTicketManagment.getAssignedTickets(UserDetails.userId)
        gdvMytickets.DataBind()
    End Sub

    Protected Sub gdvTickets_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvTickets.SelectedIndexChanged
        Dim ticketID As Integer = gdvTickets.SelectedRow.Cells(1).Text
        Dim objTicket As New cTicket(ticketID)
        UserDetails = Session("UserObject")
        If objTicket.MessageID = Nothing Then
            Dim objMessageToUser As New cMessageToUser(objTicket.MessageID, UserDetails.userId, False, Nothing)
            cMessageManagement.StoreMessageToUser(objMessageToUser)
        End If
        cTicketManagment.AssignTicket(ticketID, UserDetails.userId)
        cTicketManagment.UpdateTicketStatus(ticketID, cTicketManagment.TicketStatus.Wip)
        BindUnassignedGridView()
    End Sub

    Protected Sub gdvMytickets_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvMytickets.SelectedIndexChanged
        Dim objTicket As New cTicket(gdvMytickets.SelectedRow.Cells(1).Text)
        Dim objMessage As New cMessages(objTicket.MessageID)
        Dim objMessageTo As New cMessageToUser(cMessageToUser.GetMessageToUserFromMessage(objMessage.MessageID))
        Session("MessageToUser") = objMessageTo.MessageToUserID
        Session("MessageID") = objTicket.MessageID
        Response.Redirect("~/AllRegisteredUsers/Message.aspx")
    End Sub

    Protected Sub lnkRefreshUnassigned_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRefreshUnassigned.Click
        BindUnassignedGridView()
    End Sub

    Protected Sub lnkRefreshMy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRefreshMy.Click
        BindAssignedGridView()
    End Sub

    Protected Sub lnkRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRefresh.Click
        BindUnassignedGridView()
        BindAssignedGridView()
    End Sub

    Protected Sub tmrRefreshNewTickets_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrRefreshNewTickets.Tick
        BindUnassignedGridView()
    End Sub
End Class
