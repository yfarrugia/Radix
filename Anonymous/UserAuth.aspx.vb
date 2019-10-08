
Partial Class Anonymous_UserAuth
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtAuth.Text = Request.QueryString("Auth")
            txtUsername.Text = Request.QueryString("Username")
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Auth()
    End Sub

    Private Sub Auth()
        Dim _userID As Integer = cUser.GetIdByUsername(Trim(txtUsername.Text))

        If cUser.CheckUserAuth(_userID, _
                               Trim(txtAuth.Text), _
                               cUser.ActivationKeyType.REGISTRATION) _
        Then
            If cUser.EnableUser(_userID) Then
                lblFail.Visible = False
                lblSuccess.Visible = True
            Else
                lblSuccess.Visible = False
                lblFail.Visible = True
            End If
        Else
            lblSuccess.Visible = False
            lblFail.Visible = True
        End If
    End Sub
End Class
