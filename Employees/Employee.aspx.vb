Imports System.Data

Partial Class Employees_Employee
    Inherits System.Web.UI.Page

    Private UserDetails As cUser

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            UserDetails = Session("UserObject")
            GetLatestJobs()
            GetLatestMsgs()
            GetLatestReviews()
        End If
    End Sub

    Private Sub GetLatestJobs()
        gdvLatestJobs.DataSource = cJob.GetJobRequestsforUser(UserDetails.userId)
        gdvLatestJobs.DataBind()
        Try
            gdvLatestJobs.HeaderRow.Cells(1).Visible = False
            For Each gvr As GridViewRow In gdvLatestJobs.Rows
                gvr.Cells(1).Visible = False
            Next
        Catch
        End Try
    End Sub

    Protected Sub gdvLatestJobs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvLatestJobs.SelectedIndexChanged
        Session.Add("RequestID", gdvLatestJobs.SelectedRow.Cells(1).Text)
        Response.Redirect("~/AllRegisteredUsers/JobRequestDetails.aspx")
    End Sub

    Private Sub GetLatestMsgs()

        Dim dtMessages As New DataTable
        dtMessages = cMessageManagement.GetTopMessagesForUser(UserDetails.userId)
        gdvMessages.DataSource = dtMessages
        gdvMessages.DataBind()
        Try
            gdvMessages.HeaderRow.Cells(1).Visible = False
            gdvMessages.HeaderRow.Cells(2).Visible = False
            gdvMessages.HeaderRow.Cells(3).Visible = False
            gdvMessages.HeaderRow.Cells(0).Text = ""
            gdvMessages.HeaderRow.Cells(4).Text = ""
            For Each gvr As GridViewRow In gdvMessages.Rows
                gvr.Cells(1).Visible = False
                gvr.Cells(2).Visible = False
                gvr.Cells(3).Visible = False
                Dim imgMessageType As New Image
                Dim MesType As String = gvr.Cells(4).Text
                gvr.Cells(4).Controls.Clear()
                imgMessageType.ImageUrl = "../Images/Icons/" & MesType & ".png"
                imgMessageType.ToolTip = MesType
                gvr.Cells(4).Controls.Add(imgMessageType)
                Dim received As CheckBox = gvr.Cells(3).Controls(0)
                gvr.Cells(3).Controls.Clear()
                If Not (received.Checked) Then
                    gvr.Font.Bold = True
                Else
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub gdvMessages_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvMessages.SelectedIndexChanged
        UserDetails = Session("UserObject")
        Session("MessageID") = gdvMessages.SelectedRow.Cells(1).Text
        Session("MessageToUser") = gdvMessages.SelectedRow.Cells(2).Text
        Dim RowsEffected As Integer = cMessages.UpdateMessageToRead(gdvMessages.SelectedRow.Cells(2).Text)
        If RowsEffected > 0 Then
            cLogging.AddLog("Message Updated as Read", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, UserDetails.userId, UserDetails.userType, UserDetails.username)
        Else
            cLogging.AddLog("Error Updating Message as Read", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, UserDetails.userId, UserDetails.userType, UserDetails.username)
        End If
        Response.Redirect("~/AllRegisteredUsers/Message.aspx")
    End Sub

    Private Sub GetLatestReviews()

        gdvLatestReviews.DataSource = cEmployee.getReviews(UserDetails.userId)
        gdvLatestReviews.DataBind()
    End Sub

    Protected Sub gdvLatestReviews_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvLatestReviews.PreRender
        Const RATING_COLUMN As Int16 = 5
        Const REVIEW_REPORTED_COLUMN As Int16 = 6
        Try
            Dim ratingText As String = ""
            Dim reviewReportState As String = ""

            For Each gvr As GridViewRow In gdvLatestReviews.Rows
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
End Class
