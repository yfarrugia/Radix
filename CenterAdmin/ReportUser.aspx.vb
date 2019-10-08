
Partial Class CenterAdmin_ReportUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dvUserDetails.DataSource = cUser.getUserDetails(Session("FlaggedUser"))
        dvUserDetails.DataBind()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Session.Remove("FlaggedUser")
        Response.Redirect("CenterAdmin.aspx", False)
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim refUserObject As cUser = Session("UserObject")
        cUser.ReportUser(refUserObject.userId, Session("FlaggedUser"), txtReportText.Text.Replace("'", "''"))
        Session.Remove("FlaggedUser")
        Response.Redirect("CenterAdmin.aspx", False)
    End Sub
End Class
