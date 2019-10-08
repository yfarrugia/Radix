
Partial Class LukeTestingFolder_Star
    Inherits System.Web.UI.Page

    Protected Sub Rating1_Changed(ByVal sender As Object, ByVal e As AjaxControlToolkit.RatingEventArgs) Handles Rating1.Changed
        Label1.Text = e.Value

        Rating2.CurrentRating = 4

    End Sub
End Class
