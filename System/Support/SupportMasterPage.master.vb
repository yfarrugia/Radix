
Partial Class System_Support_SupportMasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub lnkSignout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSignout.Click
        'Sign Out Procedure
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
        Session.Contents.Clear()
        'logging
        cLogging.AddLog("Signed out", Session("UserIP"), cLogging.LogType.INFORMATION_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Session("UserObject") = "" Then
        '    FormsAuthentication.SignOut()
        '    FormsAuthentication.RedirectToLoginPage()
        '    Session.Contents.Clear()
        '    'session expired
        '    cLogging.AddLog("Session Expired", Session("UserIP"), cLogging.LogType.INFORMATION_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        'End If
    End Sub

    Protected Sub lnkCollapse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCollapse.Click
        TreeView1.CollapseAll()
        lnkCollapse.Visible = False
        lnkExpand.Visible = True
    End Sub

    Protected Sub lnkExpand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpand.Click
        TreeView1.ExpandAll()
        lnkCollapse.Visible = True
        lnkExpand.Visible = False
    End Sub
End Class

