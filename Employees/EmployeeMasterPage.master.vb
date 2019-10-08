
Partial Class Employees_EmployeeMasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UpdatedMessagesLabels()
        Dim LoggedUser As cUser = Session("UserObject")
        If Not LoggedUser.userType = "Employee" Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        TreeView1.Nodes.Item(2).ChildNodes.Item(1).NavigateUrl = "../AllRegisteredUsers/CurriculumVitae.aspx?UserID=" & LoggedUser.userId
    End Sub

    Private Sub UpdatedMessagesLabels()
        Dim LoggedUser As cUser = Session("UserObject")

        Dim NumMessages As Integer
        NumMessages = cMessages.CheckNumberUnreadMessages(LoggedUser.userId())

        Dim NumJobs As Integer
        NumJobs = cJob.CheckNumberUnreadJobs(LoggedUser.userId())

        If NumMessages > 0 Then
            lblNumMsg.CssClass = "BlueTextBold"
        Else
            lblNumMsg.CssClass = "DarkBlueText"
        End If

        If NumJobs > 0 Then
            lblNumJob.CssClass = "BlueTextBold"
        Else
            lblNumJob.CssClass = "DarkBlueText"
        End If

        lblNumMsg.Text = NumMessages.ToString
        lblNumJob.Text = NumJobs.ToString
    End Sub

    Protected Sub imgRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRefresh.Click
        UpdatedMessagesLabels()
    End Sub
End Class

