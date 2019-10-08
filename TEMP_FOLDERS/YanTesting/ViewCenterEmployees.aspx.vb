
Partial Class AllUsers_ViewCenterEmployees
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If gvCenterEmployees.Rows.Count > 0 Then
                gvCenterEmployees.DataSource = Nothing
                gvCenterEmployees.DataBind()
            End If
            'Dim centerAdmin As cUser = Session("UserObject")
            'Dim _centerID As Integer = cCenter.getCenterByUserID(centerAdmin.userId)

            'gvCenterEmployees.DataSource = cEmployee.getCenterEmployees(_centerID)
            gvCenterEmployees.DataSource = cEmployee.getCenterEmployees(2)

            gvCenterEmployees.DataBind()

            gvCenterEmployees.HeaderRow.Cells(1).Visible = False


            For Each gvrID As GridViewRow In gvCenterEmployees.Rows
                gvrID.Cells(1).Visible = False
            Next


        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gvCenterEmployees_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCenterEmployees.SelectedIndexChanged
        Try

            Dim _UserId As New Integer
            _UserId = gvCenterEmployees.SelectedRow.Cells(1).Text


            Session("SelectedUserID") = _UserId
            If Page.IsPostBack Then
                Dim mySession As Integer = Session("SelectedUserID")
                Response.Redirect("~/YanTesting/CurriculumVitae.aspx?UserID=" & mySession, False)
                'Response.Redirect("UserProfile.aspx", False)
            End If


        Catch ex As Exception


        End Try
    End Sub
End Class
