Imports System.Data
Partial Class Employers_JobDetails
    Inherits System.Web.UI.Page

    Private _JobID As Integer
    Private Property JobID() As Integer
        Get
            Return _JobID
        End Get
        Set(ByVal value As Integer)
            _JobID = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Not Session("JobID") = Nothing Then
                JobID = Session("JobID")
                populateJobDetails()
                gdvAddedEmployees.DataSource = cJob.GetEmployeesByJob(JobID)
                gdvAddedEmployees.DataBind()
            Else
                Response.Redirect("ReviewJobs.aspx")
            End If
        End If
    End Sub


    Private Sub populateJobDetails()
        Dim dt As New DataTable
        dt = cJob.getJobDetailsByJobID(JobID)
        dvJobDetails.DataSource = dt
        dvJobDetails.DataBind()
    End Sub

    Protected Sub btnReview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReview.Click
        Dim objSelected As cUser.selectedUsers = cUser.GetSelectedUsers(gdvAddedEmployees, 1)
        If Not (objSelected.UserIds.Count = 0) Then
            Session("EmployeesToReview") = objSelected
            Response.Redirect("AddReview.aspx")
        End If
    End Sub

    Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        Session.Remove("JobID")
        Response.Redirect("ReviewJobs.aspx")
    End Sub
End Class
