
Partial Class CenterAdmin_CenterAdminMasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim LoggedUser As cUser = Session("UserObject")
        If Not LoggedUser.userType = "CenterAdmin" Then
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UpdatedMessagesLabels()
    End Sub

    Private Sub UpdatedMessagesLabels()
        Dim LoggedUser As cUser = Session("UserObject")

        Dim NumMessages As Integer
        NumMessages = cMessages.CheckNumberUnreadMessages(LoggedUser.userId())

        If NumMessages > 0 Then
            lblNumMsg.CssClass = "BlueTextBold"
        Else
            lblNumMsg.CssClass = "DarkBlueText"
        End If

        lblNumMsg.Text = NumMessages.ToString
    End Sub

    Protected Sub imgRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRefresh.Click
        UpdatedMessagesLabels()
    End Sub
End Class

