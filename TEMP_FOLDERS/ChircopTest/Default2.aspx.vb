
Partial Class TEMP_FOLDERS_ChircopTest_Default2
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Text = cHash.ComputeHash(TextBox1.Text)

    End Sub
End Class
