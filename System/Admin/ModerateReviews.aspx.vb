Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Diagnostics


Partial Class System_Admin_ModerateReviews
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillReportedReviews()

    End Sub

    Private Sub fillReportedReviews()
        Try
            'Dim dt As New DataTable
            'dt = cDBManager.GetDataTable(New SqlCommand("SELECT tblReviewTo.ReviewToID, tblJob.Title, tblJob.Description, tblReviewMessage.Comment, tblReviewMessage.Rating, tblReviewTo.reportMessage, tblUser.Name + ' ' + tblUser.Surname AS [Full Name] FROM tblReviewTo INNER JOIN tblReviewMessage ON tblReviewTo.ReviewMessageID = tblReviewMessage.ReviewMessageID INNER JOIN tblJob ON tblReviewMessage.JobID = tblJob.JobID INNER JOIN tblUser ON tblReviewTo.EmployeeID = tblUser.UserID WHERE (tblReviewTo.isReported = 1) AND (tblReviewTo.flagedNoShow = 0)"))

            gvReviews.DataSource = cReview.getReportedReviews
            gvReviews.DataBind()

            Debug.Write("Reported revies loaded")
        Catch ex As Exception
            Debug.Write(String.Format("{0} {1}", ex.Message, ex.StackTrace))
        End Try
    End Sub

    Protected Sub gvReviews_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReviews.PreRender
        Dim ratingText As String = ""
        For Each gvr As GridViewRow In gvReviews.Rows
            Dim imgMessageType As New Image
            ratingText = gvr.Cells(6).Text
            gvr.Cells(6).Controls.Clear()
            imgMessageType.ImageUrl = "../../Images/Icons/Stars" & ratingText & ".png"
            imgMessageType.ToolTip = ratingText
            gvr.Cells(6).Controls.Add(imgMessageType)
        Next
    End Sub


    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
    '    Try
    '        'GridView1.SelectedRow.Cells(1).Text
    '        cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblReviewTo SET flagedNoShow = 1 WHERE ReviewToID = {0}", GridView1.SelectedRow.Cells(1).Text)))
    '        Debug.Write("Review Purged")
    '        Response.AddHeader("REFRESH", 1)
    '    Catch ex As Exception
    '        Debug.Write(String.Format("{0} {1}", ex.Message, ex.StackTrace))
    '    End Try
    'End Sub

    Protected Sub gvReviews_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReviews.SelectedIndexChanged
        'dvReportedReivewDetails.DataSource = cDBManager.GetDataTable(New SqlCommand(String.Format("SELECTtblUser.Name AS [Employee Name], tblJob.Title AS [Job Title], tblCompany.CompanyName AS Company, tblReviewMessage.Comment AS [Review Message], tblReviewMessage.Rating, tblReviewTo.reportMessage AS [Report Comment] FROM tblReviewMessage INNER JOIN tblJob ON tblReviewMessage.JobID = tblJob.JobID INNER JOIN tblCompany ON tblJob.CompanyID = tblCompany.CompanyID INNER JOIN tblReviewTo ON tblReviewMessage.ReviewMessageID = tblReviewTo.ReviewMessageID INNER JOIN tblUser ON tblReviewTo.EmployeeID = tblUser.UserID")))
        ReviewDetailsArea.Visible = True
        dvReportedReivewDetails.DataSource = cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblUser.Name + ' ' + tblUser.Surname AS [Employee Name], tblJob.Title AS [Job Title], tblCompany.CompanyName AS Company, tblReviewMessage.Comment AS [Review Message], tblReviewMessage.Rating, tblReviewTo.reportMessage AS [Report Comment] FROM         tblReviewMessage INNER JOIN tblJob ON tblReviewMessage.JobID = tblJob.JobID INNER JOIN tblCompany ON tblJob.CompanyID = tblCompany.CompanyID INNER JOIN tblReviewTo ON tblReviewMessage.ReviewMessageID = tblReviewTo.ReviewMessageID INNER JOIN tblUser ON tblReviewTo.EmployeeID = tblUser.UserID WHERE (tblReviewTo.ReviewToID = {0})", gvReviews.SelectedRow.Cells(1).Text)))
        dvReportedReivewDetails.DataBind()

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ReviewDetailsArea.Visible = False
        dvReportedReivewDetails.DataSource = Nothing
    End Sub

    Protected Sub btnRemoveReview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveReview.Click
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblReviewTo SET flagedNoShow = 1 WHERE ReviewToID = {0}", gvReviews.SelectedRow.Cells(1).Text)))
            Debug.Write("Review Purged")
            lblSuccess.Visible = True
            lblError.Visible = False
            Response.Redirect("ModerateReviews.aspx")
        Catch ex As Exception
            lblSuccess.Visible = False
            lblError.Visible = True
            Debug.Write(String.Format("{0} {1}", ex.Message, ex.StackTrace))
        End Try
    End Sub

    Protected Sub dvReportedReivewDetails_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvReportedReivewDetails.PreRender
        Dim ratingText As String = dvReportedReivewDetails.Rows(4).Cells(1).Text
        Dim imgMessageType As New Image
        imgMessageType.ImageUrl = "../../Images/Icons/Stars" & ratingText & ".png"
        imgMessageType.ToolTip = ratingText
        dvReportedReivewDetails.Rows(4).Cells(1).Controls.Clear()
        dvReportedReivewDetails.Rows(4).Cells(1).Controls.Add(imgMessageType)
    End Sub
End Class
