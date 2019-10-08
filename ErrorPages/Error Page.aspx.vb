
Partial Class ErrorPages_Error_Page
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ex As Exception = Session("LAST_ERROR")

        lblErrorMessage.Text = ex.Message
        lblStackTrace.Text = ex.StackTrace

        'lblError.Text = Session("LAST_ERROR_tmp")
    End Sub

    Protected Sub btnClearSession_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearSession.Click
        Session.RemoveAll()
        FormsAuthentication.SignOut() 'removes any opened Sessions
        Response.Write("Session Cleared")
    End Sub
End Class
