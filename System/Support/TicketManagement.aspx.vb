
Partial Class System_Support_NewTickets
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

    Private Sub BindGridViewUnassignedTickets()
        _refUserObj = Session("UserObject")
        gdvTickets.DataSource = cTicketManagment.GetSupportUnAssignedTickets()
        gdvTickets.DataBind()
        Try
            gdvTickets.HeaderRow.Cells(1).Visible = False
            For Each gvr As GridViewRow In gdvTickets.Rows
                gvr.Cells(1).Visible = False
            Next
        Catch
        End Try
    End Sub

    Private Sub BindGridViewMyTickets()
        gdvMytickets.DataSource = cTicketManagment.getAssignedTickets(UserDetails.userId)
        gdvMytickets.DataBind()
        Try
            gdvMytickets.HeaderRow.Cells(1).Visible = False
            For Each gvr As GridViewRow In gdvMytickets.Rows
                gvr.Cells(1).Visible = False
            Next
        Catch
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindGridViewUnassignedTickets()
        BindGridViewMyTickets()
    End Sub

    Protected Sub gdvTickets_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvTickets.SelectedIndexChanged
        Dim ticketID As Integer = gdvTickets.SelectedRow.Cells(1).Text
        Dim objTicket As New cTicket(ticketID)
        If objTicket.MessageID = Nothing Then
            Dim objMessageToUser As New cMessageToUser(objTicket.MessageID, UserDetails.userId, False, Nothing)
            cMessageManagement.StoreMessageToUser(objMessageToUser)
        End If
        cTicketManagment.AssignTicket(ticketID, UserDetails.userId)
        cTicketManagment.UpdateTicketStatus(ticketID, cTicketManagment.TicketStatus.Wip)
        BindGridViewUnassignedTickets()
    End Sub

    Protected Sub gdvMytickets_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvMytickets.SelectedIndexChanged
        Dim objTicket As New cTicket(Convert.ToInt64(gdvMytickets.SelectedRow.Cells(1).Text))
        Dim objMessage As New cMessages(objTicket.MessageID)
        Dim objMessageTo As New cMessageToUser(cMessageToUser.GetMessageToUserFromMessage(objMessage.MessageID))
        Session("MessageToUser") = objMessageTo.MessageToUserID
        Session("MessageID") = objTicket.MessageID
        Response.Redirect("~/AllRegisteredUsers/Message.aspx")
    End Sub

    Protected Sub tmrRefreshNewTickets_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrRefreshNewTickets.Tick
        BindGridViewUnassignedTickets()
    End Sub
End Class
