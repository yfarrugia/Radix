
Partial Class Employees_ReportReview
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("ReviewReport") = Nothing Then
            If Not (Page.IsPostBack) Then
                Dim getMsg As Object = cDBManager.GetExecuteScalar(New System.Data.SqlClient.SqlCommand(String.Format("SELECT reportMessage FROM tblReviewTo WHERE (ReviewToID = {0})", Session("ReviewReport"))))
                
                If Not DBNull.Value.Equals(getMsg) Then
                    txtReportText.Text = getMsg
                End If
            End If
            dvReportReview.DataSource = cReview.getReviewReportDetails(Session("ReviewReport"))
            dvReportReview.DataBind()
        Else
            Response.Redirect("MyReviews.aspx")
        End If
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        cReview.reportReview(Session("ReviewReport"), txtReportText.Text)
        Session.Remove("ReviewReport")
        Response.Redirect("MyReviews.aspx")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Session.Remove("ReviewReport")
        Response.Redirect("MyReviews.aspx")
    End Sub

    Protected Sub dvReportReview_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvReportReview.PreRender
        Dim ratingText As String = dvReportReview.Rows(3).Cells(1).Text
        Dim imgMessageType As New Image
        imgMessageType.ImageUrl = "../Images/Icons/Stars" & ratingText & ".png"
        imgMessageType.ToolTip = ratingText
        dvReportReview.Rows(3).Cells(1).Controls.Clear()
        dvReportReview.Rows(3).Cells(1).Controls.Add(imgMessageType)
    End Sub
End Class
