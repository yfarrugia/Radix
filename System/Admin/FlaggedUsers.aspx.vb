
Partial Class System_Admin_FlaggedUsers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            gvFlaggedUsers.DataSource = cSystemAdmin.getFlaggedUsers
            gvFlaggedUsers.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
        
    End Sub
End Class
