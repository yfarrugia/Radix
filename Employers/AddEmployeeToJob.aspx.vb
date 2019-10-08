
Partial Class Employers_AddEmployeeToJob
    Inherits System.Web.UI.Page

    Private _JobID As Integer

    Private Property JobID() As Integer
        Get
            Return _JobID
        End Get
        Set(ByVal value As Integer)
            _JobID = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        JobID = Session("JobID")

        If Not (Page.IsPostBack) Then
            BindGridView()
        End If

        If gdvEmployees.Rows.Count > 0 Then
            btnAddEmployees.Visible = True
        Else
            btnAddEmployees.Visible = False
        End If
    End Sub

    Private Sub BindGridView()
        gdvEmployees.DataSource = Nothing
        gdvEmployees.DataBind()
        gdvEmployees.DataSource = cEmployee.GetEmployeesForJob(JobID)
        gdvEmployees.DataBind()
        DesignGridView()
    End Sub

    Protected Sub btnAddEmployees_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddEmployees.Click
        Dim obj As cUser.selectedUsers
        obj = cUser.GetSelectedUsers(gdvEmployees, 2)
        Dim rowseffected As Integer = cJob.StoreJobRequests(obj.UserIds, JobID)
        If rowseffected > 0 Then
            lblError.Visible = False
            lblSuccess.Text = "Sucessfully added " & obj.UserNameString & " to this Job."
        ElseIf rowseffected = -1 Then
            lblError.Text = "Already added " & obj.UserNameString & " to this Job."
            lblError.Visible = True
            lblSuccess.Visible = False
        Else
            lblError.Text = "You must first select an employee."
            lblError.Visible = True
            lblSuccess.Visible = False
        End If
        BindGridView()
    End Sub

    Protected Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        gdvEmployees.DataSource = Nothing
        gdvEmployees.DataBind()
        gdvEmployees.DataSource = cEmployee.GetEmployeesForJob(JobID, cbxOccupation.Checked, cbxJobType.Checked, rdblSeeking.SelectedValue, rdblEmployed.SelectedValue, rdblSponsored.SelectedValue)
        gdvEmployees.DataBind()
        DesignGridView()
    End Sub

    Private Sub DesignGridView()
        Try
            gdvEmployees.HeaderRow.Cells(2).Visible = False
            gdvEmployees.HeaderRow.Cells(7).ColumnSpan = 2
            gdvEmployees.HeaderRow.Cells(8).Visible = False

            gdvEmployees.HeaderRow.Cells(4).Text = ""
            gdvEmployees.HeaderRow.Cells(5).Text = ""
            gdvEmployees.HeaderRow.Cells(6).Text = ""

            Dim isEmployed As New CheckBox
            Dim isSeeking As New CheckBox
            Dim isSponsored As New CheckBox
            Dim flagname As String
            For Each gvr As GridViewRow In gdvEmployees.Rows
                gvr.Cells(2).Visible = False
                Dim imgEmployed As New Image
                Dim imgSeeking As New Image
                Dim imgSponsored As New Image
                Dim imgFlag As New Image
                isEmployed = gvr.Cells(4).Controls(0)
                isSeeking = gvr.Cells(5).Controls(0)
                isSponsored = gvr.Cells(6).Controls(0)
                gvr.Cells(4).Controls.Clear()
                gvr.Cells(5).Controls.Clear()
                gvr.Cells(6).Controls.Clear()
                If isEmployed.Checked Then
                    imgEmployed.ImageUrl = "../Images/Icons/Employed.png"
                    imgEmployed.ToolTip = "Currently Employed"
                Else
                    imgEmployed.ImageUrl = "../Images/Icons/NotEmployed.png"
                    imgEmployed.ToolTip = "Not Currently Employed"
                End If
                If isSeeking.Checked Then
                    imgSeeking.ImageUrl = "../Images/Icons/Seeking.png"
                    imgSeeking.ToolTip = "Currently Seeking"
                Else
                    imgSeeking.ImageUrl = "../Images/Icons/NotSeeking.png"
                    imgSeeking.ToolTip = "Not Currently Seeking"
                End If
                If isSponsored.Checked Then
                    imgSponsored.ImageUrl = "../Images/Icons/Sponsored.png"
                    imgSponsored.ToolTip = "Sponsored"
                Else
                    imgSponsored.ImageUrl = "../Images/Icons/NotSponsored.png"
                    imgSponsored.ToolTip = "Not Sponsored"
                End If
                gvr.Cells(4).Controls.Add(imgEmployed)
                gvr.Cells(5).Controls.Add(imgSeeking)
                gvr.Cells(6).Controls.Add(imgSponsored)
                flagname = gvr.Cells(8).Text
                imgFlag.ImageUrl = "../Images/Flags/" & flagname & ".png"
                gvr.Cells(8).Controls.Add(imgFlag)
            Next
        Catch
        End Try

    End Sub


    Protected Sub gdvEmployees_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvEmployees.SelectedIndexChanged
        Try

            'Dim _UserId As New Integer
            '_UserId = gdvEmployees.SelectedRow.Cells(2).Text


            'Session("SelectedUserID") = _UserId

            If Page.IsPostBack Then
                'Dim mySession As Integer = Session("SelectedUserID")
                'Dim strCommand As String = "window.open('" & "../AllRegisteredUsers/CurriculumVitae.aspx?UserID=" & gdvEmployees.SelectedRow.Cells(2).Text & "','mywindow','status=1','toolbar=1');" & vbCrLf

                'Response.Write("<script>" & vbCrLf)
                'Response.Write("window.open('" & "../AllRegisteredUsers/CurriculumVitae.aspx?UserID=" & gdvEmployees.SelectedRow.Cells(2).Text & "','mywindow','status=0','toolbar=0','width=200',heigth='800'');" & vbCrLf)
                'Response.Write("<" & Chr(47) & "script>")

                Response.Redirect("~/AllRegisteredUsers/CurriculumVitae.aspx?UserID=" & gdvEmployees.SelectedRow.Cells(2).Text, False)
                'Response.Redirect("UserProfile.aspx", False)
            End If


        Catch ex As Exception


        End Try
    End Sub


End Class
