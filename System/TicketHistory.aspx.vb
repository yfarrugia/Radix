
Partial Class System_TicketHistory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindGridView()
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Dim UserDetails As cUser

        UserDetails = Session("UserObject")

        Select Case UserDetails.userType
            Case "SystemAdmin"
                Me.MasterPageFile = "~/System/Admin/SystemMasterPage.master"
            Case "SupportAdmin"
                Me.MasterPageFile = "~/System/Support/SupportMasterPage.master"

        End Select
    End Sub
    Private Sub BindGridView()
        gdvTickets.DataSource = cTicketManagment.GetAllTickets
        gdvTickets.DataBind()
    End Sub

    Protected Sub gdvTickets_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvTickets.SelectedIndexChanged
        Dim objTicket As New cTicket(Convert.ToInt64(gdvTickets.SelectedRow.Cells(1).Text))
        Dim objMessage As New cMessages(objTicket.MessageID)
        Dim objMessageTo As New cMessageToUser(cMessageToUser.GetMessageToUserFromMessage(objMessage.MessageID))
        Session("MessageToUser") = objMessageTo.MessageToUserID
        Session("MessageID") = objTicket.MessageID
        Response.Redirect("~/AllRegisteredUsers/Message.aspx")
    End Sub
End Class
