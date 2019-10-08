
Partial Class System_Support_ViewAllTickets
    Inherits System.Web.UI.Page

    Private Sub FillGridView()
        gdvTickets.DataSource = cTicketManagment.GetSupportOpenTickets
        gdvTickets.DataBind()
    End Sub

    Protected Sub tmrUpdate_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrUpdate.Tick
        FillGridView()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            FillGridView()
        End If
    End Sub
End Class
