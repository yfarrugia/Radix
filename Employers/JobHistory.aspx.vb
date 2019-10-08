
Partial Class Employers_JobHistory
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
        BindGridView()
    End Sub

    Private Sub BindGridView()
        UserDetails = Session("UserObject")
        gdvJobs.DataSource = cJobManagement.GetAllJobsForEmployer(UserDetails.userId)
        gdvJobs.DataBind()

        gdvJobs.HeaderRow.Cells(1).Visible = False
        gdvJobs.HeaderRow.Cells(3).Visible = False
        gdvJobs.HeaderRow.Cells(4).Visible = False
        gdvJobs.HeaderRow.Cells(5).Visible = False

        For Each gvr As GridViewRow In gdvJobs.Rows
            gvr.Cells(1).Visible = False
            gvr.Cells(3).Visible = False
            gvr.Cells(5).Visible = False
            gvr.Cells(4).Visible = False
        Next


    End Sub


    Protected Sub gdvJobs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvJobs.SelectedIndexChanged
        Session.Add("JobID", gdvJobs.SelectedRow.Cells(1).Text)
        Response.Redirect("JobDetails.aspx")
    End Sub
End Class
