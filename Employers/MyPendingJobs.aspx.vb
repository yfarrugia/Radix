Imports System.Data
Partial Class Employers_MyPendingJobs
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
        popupateGridView()
    End Sub
    Private Sub popupateGridView()
        Dim dtJobs As New DataTable
        dtJobs = cJob.getPendingJobsByEmployer(UserDetails.userId)
        gdvPendingJobs.DataSource = dtJobs
        gdvPendingJobs.DataBind()

        Try
            gdvPendingJobs.HeaderRow.Cells(1).Visible = False
            gdvPendingJobs.HeaderRow.Cells(0).Text = ""
            For Each gvr As GridViewRow In gdvPendingJobs.Rows
                gvr.Cells(1).Visible = False
            Next
        Catch ex As Exception

        End Try
        
    End Sub

    Protected Sub gdvPendingJobs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvPendingJobs.SelectedIndexChanged
        Session.Add("JobID", gdvPendingJobs.SelectedRow.Cells(1).Text)
        Response.Redirect("Jobdetails.aspx")
    End Sub
End Class
