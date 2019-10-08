Imports System.Data

Partial Class CenterAdmin_EmplyeeMessageInbox
    Inherits System.Web.UI.Page
    Private EmployeeID As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            GetLatestJobs()
            GetLatestMsgs()
            GetLatestReviews()

            SetPageTitle()
        End If

    End Sub

    Private Sub SetPageTitle()
        lblCenterEmployee.Text = cUser.GetUserByID(Session("EmployeeID"))
    End Sub

    Private Sub GetLatestJobs()
        gdvJobs.DataSource = cJob.GetJobRequestsforUser(Session("EmployeeID"))
        gdvJobs.DataBind()
        Try
            gdvJobs.HeaderRow.Cells(1).Visible = False
            For Each gvr As GridViewRow In gdvJobs.Rows
                gvr.Cells(1).Visible = False
            Next
        Catch
        End Try
    End Sub

    Protected Sub gdvJobs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvJobs.SelectedIndexChanged
        Session.Add("RequestID", gdvJobs.SelectedRow.Cells(1).Text)
        Response.Redirect("~/AllRegisteredUsers/JobRequestDetails.aspx")
    End Sub

    Private Sub GetLatestMsgs()

        Dim dtMessages As New DataTable
        dtMessages = cMessageManagement.GetAllMessagesForUser(Session("EmployeeID"))
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
        Session("MessageID") = gdvMessages.SelectedRow.Cells(1).Text
        Session("MessageToUser") = gdvMessages.SelectedRow.Cells(2).Text
        Dim RowsEffected As Integer = cMessages.UpdateMessageToRead(gdvMessages.SelectedRow.Cells(2).Text)
        If RowsEffected > 0 Then
            cLogging.AddLog("Message Updated as Read", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Session("EmployeeID"), "", "")
        Else
            cLogging.AddLog("Error Updating Message as Read", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Session("EmployeeID"), "", "")
        End If
        Response.Redirect("~/AllRegisteredUsers/Message.aspx")
    End Sub

    Private Sub GetLatestReviews()
        gdvReviews.DataSource = cEmployee.getReviews(Session("EmployeeID"))
        gdvReviews.DataBind()
    End Sub

End Class
