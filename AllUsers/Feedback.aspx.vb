Imports System.Net.Mail

Partial Class AllUsers_Feedback
    Inherits System.Web.UI.Page

    Protected Sub btnSubmitFeedback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmitFeedback.Click
        Dim SmtpClient As New SmtpClient()
        Dim message As New MailMessage()

        Try

            cEmail.SendEmail(cEmail.Email.FEEDBACK, Trim(txtEmail.Text), Trim(txtName.Text), cEmail.MessageType.FEEDBACK, Trim(txtMessage.Text))

            lblSuccess.Visible = True
            lblError.Visible = False

        Catch ex As Exception

            lblSuccess.Visible = False
            lblError.Visible = True

        End Try
    End Sub
End Class
