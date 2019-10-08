
Partial Class Employees_JobRequestInbox
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
        UserDetails = Session("UserObject")
        If Not (Page.IsPostBack) Then
            BindGridView()
        End If
    End Sub

    Private Sub BindGridView()
        gdvJobRequests.DataSource = cJob.GetJobRequestsforUser(UserDetails.userId)
        gdvJobRequests.DataBind()
        Try
            gdvJobRequests.HeaderRow.Cells(1).Visible = False
            For Each gvr As GridViewRow In gdvJobRequests.Rows
                gvr.Cells(1).Visible = False
            Next
        Catch
        End Try
    End Sub

    Protected Sub gdvJobRequests_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvJobRequests.SelectedIndexChanged
        Session.Add("RequestID", gdvJobRequests.SelectedRow.Cells(1).Text)
        Response.Redirect("~/AllRegisteredUsers/JobRequestDetails.aspx")
    End Sub
End Class
