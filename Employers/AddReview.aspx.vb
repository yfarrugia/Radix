
Partial Class Employers_AddReview
    Inherits System.Web.UI.Page

    Protected Sub Rating1_Changed(ByVal sender As Object, ByVal e As AjaxControlToolkit.RatingEventArgs) Handles Rating1.Changed
        lblRating.Text = e.Value
    End Sub


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            Dim er As cUser.selectedUsers = Session("EmployeesToReview")
            Dim o As New cReview(er.UserIds, Trim(txtReviewComment.Text).Replace("'", "''"), lblRating.Text, Session("JobID"))
            o.storeReviewMessage()
            Response.Redirect("ReviewJobs.aspx", False)
        Catch ex As Exception
            System.Diagnostics.Debug.Write(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim er As cUser.selectedUsers = Session("EmployeesToReview")
        lblUsers.Text = er.UserNameString
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Session.Remove("EmployeesToReview")
        Session.Remove("JobID")
        Response.Redirect("~/Employers/ReviewJobs.aspx", False)
    End Sub
End Class