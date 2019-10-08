
Partial Class Employers_JobInbox
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
        gdvJobs.DataSource = cJobManagement.GetOpenJobsForEmployer(UserDetails.userId)
        gdvJobs.DataBind()
    End Sub

    Protected Sub gdvJobs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvJobs.SelectedIndexChanged
        Session.Add("JobID", gdvJobs.SelectedRow.Cells(1).Text)
        Response.Redirect("JobDetails.aspx")
    End Sub
End Class
