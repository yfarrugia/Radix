
Partial Class Employees_MyReviews
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim refUserObject As cUser = Session("UserObject")


        gvMyReviews.DataSource = cEmployee.getReviews(refUserObject.userId)
        gvMyReviews.DataBind()

        If Not (gvMyReviews.Rows.Count = 0) Then
            'remove(ID)
            gvMyReviews.HeaderRow.Cells(1).Visible = False
            For Each gvr As GridViewRow In gvMyReviews.Rows
                gvr.Cells(1).Visible = False
            Next
        End If
    End Sub

    Protected Sub gvMyReviews_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMyReviews.PreRender
        Const RATING_COLUMN As Int16 = 5
        Const REVIEW_REPORTED_COLUMN As Int16 = 6
        Try
            Dim ratingText As String = ""
            Dim reviewReportState As String = ""

            For Each gvr As GridViewRow In gvMyReviews.Rows
                Dim imgMessageType, imgReportReviewState As New Image
                ratingText = gvr.Cells(RATING_COLUMN).Text
                gvr.Cells(RATING_COLUMN).Controls.Clear()
                imgMessageType.ImageUrl = "../Images/Icons/Stars" & ratingText & ".png"
                imgMessageType.ToolTip = ratingText
                gvr.Cells(RATING_COLUMN).Controls.Add(imgMessageType)

                Dim tmpCbx As CheckBox = gvr.Cells(REVIEW_REPORTED_COLUMN).Controls(0)
                
                If (tmpCbx.Checked) Then
                    reviewReportState = "On"
                Else
                    reviewReportState = "Off"
                End If
                gvr.Cells(REVIEW_REPORTED_COLUMN).Controls.Clear()
                imgReportReviewState.ImageUrl = "../Images/Icons/Flagged_" & reviewReportState & ".png"

                If reviewReportState = "On" Then
                    imgReportReviewState.ToolTip = "Pending report"
                Else
                    imgReportReviewState.ToolTip = "No pending report"
                End If

                gvr.Cells(REVIEW_REPORTED_COLUMN).Controls.Add(imgReportReviewState)

            Next
        Catch ex As Exception
            System.Diagnostics.Debug.Write(ex.Message)
        End Try
    End Sub

    Protected Sub gvMyReviews_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMyReviews.SelectedIndexChanged
        Session("ReviewReport") = gvMyReviews.SelectedRow.Cells(1).Text
        Response.Redirect("ReportReview.aspx")
    End Sub
End Class
