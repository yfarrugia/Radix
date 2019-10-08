
Partial Class AllUsers_ViewCenterEmployees
    Inherits System.Web.UI.Page

    Const ID_CELL_NUMBER As Int16 = 4
    Const IS_EMPLOYED_CELL_NUMBER As Int16 = 8
    Const IS_SEEKING_CELL_NUMBER As Int16 = 9

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadGridView()
    End Sub

    Private Sub loadGridView()

        Try
            If gvCenterEmployees.Rows.Count > 0 Then
                gvCenterEmployees.DataSource = Nothing
                gvCenterEmployees.DataBind()
            End If

            Dim centerAdmin As cUser = Session("UserObject")
            Dim _centerID As Integer = cCenter.getCenterByUserID(centerAdmin.userId)

            gvCenterEmployees.DataSource = cEmployee.getCenterEmployees(_centerID)
            gvCenterEmployees.DataBind()

            If gvCenterEmployees.Rows.Count > 0 Then

                gvCenterEmployees.HeaderRow.Cells(ID_CELL_NUMBER).Visible = False
                gvCenterEmployees.HeaderRow.Cells(IS_EMPLOYED_CELL_NUMBER).Visible = False
                gvCenterEmployees.HeaderRow.Cells(IS_SEEKING_CELL_NUMBER).Visible = False


                Dim isSeeking As New CheckBox
                Dim isEmployed As New CheckBox

                For Each gvrID As GridViewRow In gvCenterEmployees.Rows
                    gvrID.Cells(ID_CELL_NUMBER).Visible = False

                    Dim imgSeeking As New Image
                    Dim imgEmployed As New Image

                    isEmployed = gvrID.Cells(IS_EMPLOYED_CELL_NUMBER).Controls(0)
                    isSeeking = gvrID.Cells(IS_SEEKING_CELL_NUMBER).Controls(0)
                    gvrID.Cells(IS_EMPLOYED_CELL_NUMBER).Controls.Clear()
                    gvrID.Cells(IS_SEEKING_CELL_NUMBER).Controls.Clear()

                    gvrID.Cells(7).HorizontalAlign = HorizontalAlign.Center

                    If isSeeking.Checked Then
                        imgSeeking.ImageUrl = "../Images/Icons/Seeking.png"
                        imgSeeking.ToolTip = "Seeking Employment"
                    Else
                        imgSeeking.ImageUrl = "../Images/Icons/NotSeeking.png"
                        imgSeeking.ToolTip = "Not Seeking Employment"
                    End If
                    If isEmployed.Checked Then
                        imgEmployed.ImageUrl = "../Images/Icons/Employed.png"
                        imgEmployed.ToolTip = "Currently Employed"
                    Else
                        imgEmployed.ImageUrl = "../Images/Icons/NotEmployed.png"
                        imgEmployed.ToolTip = "Not Currently Employed"
                    End If
                    gvrID.Cells(IS_EMPLOYED_CELL_NUMBER).Controls.Add(imgEmployed)
                    gvrID.Cells(IS_SEEKING_CELL_NUMBER).Controls.Add(imgSeeking)
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvCenterEmployees_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCenterEmployees.RowCommand

        Dim rowseffected As Integer
        If e.CommandName = "Profile" Then
            rowseffected = gvCenterEmployees.Rows(Convert.ToInt32(e.CommandArgument)).Cells(ID_CELL_NUMBER).Text
            Session("SelectedUserID") = rowseffected
            If Page.IsPostBack Then
                Response.Redirect("~/AllRegisteredUsers/UserProfile.aspx", False)
            End If

        End If

        If e.CommandName = "Report" Then
            System.Diagnostics.Debug.Write("Report clicked")
            Session("FlaggedUser") = gvCenterEmployees.Rows(Convert.ToInt32(e.CommandArgument)).Cells(ID_CELL_NUMBER).Text
            Response.Redirect("ReportUser.aspx")
        End If

        If e.CommandName = "Inbox" Then
            rowseffected = gvCenterEmployees.Rows(Convert.ToInt32(e.CommandArgument)).Cells(ID_CELL_NUMBER).Text
            Session("EmployeeID") = rowseffected
            Response.Redirect("~/CenterAdmin/EmplyeeMessageInbox.aspx")
        End If


        If e.CommandName = "CV" Then
            rowseffected = gvCenterEmployees.Rows(Convert.ToInt32(e.CommandArgument)).Cells(ID_CELL_NUMBER).Text
            Dim ID As Integer = rowseffected
            If Page.IsPostBack Then
                Response.Write("<script>" & vbCrLf)
                Response.Write("window.open('" & "../AllRegisteredUsers/CurriculumVitae.aspx?UserID=" & ID & "','mywindow','status=0','toolbar=0','width=200',heigth='800'');" & vbCrLf)
                Response.Write("<" & Chr(47) & "script>")
                'Response.Redirect("~/AllRegisteredUsers/CurriculumVitae.aspx?UserID=" & ID, False)
            End If
        End If

    End Sub

    'Protected Sub gvCenterEmployees_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCenterEmployees.SelectedIndexChanged
    '    Try

    '        Dim objSelectedButton As Object = sender
    '        Response.Redirect("UserProfile.aspx", False)

    '    Catch ex As Exception
    '    End Try
    'End Sub


End Class
