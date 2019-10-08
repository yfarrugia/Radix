
Partial Class LukeTestingFolder_imageTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        banner.Src = "../Centers/Images/Banners/Banner1.png"
        banner.Width = 690
        banner.Height = 157
        Label1.Text = "luke Camilleri"
    End Sub
End Class
