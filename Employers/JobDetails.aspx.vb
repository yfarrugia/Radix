Imports System.Data
Partial Class Employers_JobDetails
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
        

        Try
            If Not Page.IsPostBack Then
                GetJobType()
                'GetIndustry()
                'GetOccupation()
                'populateJobDetails()

                If Not Session("JobID") = Nothing Then
                    JobID = Session("JobID")
                    populateJobDetails()
                    gdvAddedEmployees.DataSource = cJob.GetEmployeesByJob(JobID)
                    gdvAddedEmployees.DataBind()

                    Dim objJob As New cJob(JobID)
                    If (objJob.EndDate < System.DateTime.Now) Then
                        lnkAddEmployees.Visible = False
                        lnkManageEmployees.Visible = False
                    End If



                Else
                    Response.Redirect("MyPendingJobs.aspx")
                End If
            End If

        Catch ex As Exception
            cLogging.AddLog("Job Details could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        Finally
            imgAddEmployee.Visible = lnkAddEmployees.Visible
            imgManageEmployees.Visible = lnkManageEmployees.Visible
        End Try
    End Sub

    Public Sub GetJobType()

        ddlJobType.DataSource = cJob.getJobTypes()
        ddlJobType.DataValueField = "JobTypeID"
        ddlJobType.DataTextField = "JobType"
        ddlJobType.DataBind()

    End Sub

    'Public Sub GetOccupation()

    '    ddlOccupation.DataSource = cOccupation.GetAllOccupationsByIndustry(ddlIndustry.SelectedValue)
    '    ddlOccupation.DataValueField = "OccupationID"
    '    ddlOccupation.DataTextField = "Occupation"
    '    ddlOccupation.DataBind()

    'End Sub

    'Public Sub GetIndustry()

    '    ddlIndustry.DataSource = cIndustry.GetAllIndustries()
    '    ddlIndustry.DataValueField = "JobIndustryID"
    '    ddlIndustry.DataTextField = "JobIndustry"
    '    ddlIndustry.DataBind()

    'End Sub

    Private Sub populateJobDetails()

        Dim dt As New DataTable
        dt = cJob.getJobDetailsByJobID(JobID)

        If dt.Rows.Count > 0 Then

            lblTitle.Text = dt.Rows(0).Item("Title").ToString()

            If Not dt.Rows(0).Item("Description").ToString = "" Then
                txtDesc.Text = dt.Rows(0).Item("Description").ToString
            End If

            If Not dt.Rows(0).Item("Requirements").ToString = "" Then
                txtReq.Text = dt.Rows(0).Item("Requirements").ToString
            End If

            lblPostDate.Text = dt.Rows(0).Item("DatePosted").ToString
            txtClosingDate.Text = dt.Rows(0).Item("ClosingDate").ToString
            txtStartingDate.Text = dt.Rows(0).Item("StartDate").ToString

            If Not dt.Rows(0).Item("EndDate").ToString = "" Then
                txtEndingDate.Text = dt.Rows(0).Item("EndDate").ToString
            End If

            'ddlOccupation.SelectedValue = dt.Rows(0).Item("Occupation")
            'ddlIndustry.SelectedValue = dt.Rows(0).Item("JobIndustry")

            txtOccupation.Text = dt.Rows(0).Item("Occupation")
            txtIndustry.Text = dt.Rows(0).Item("JobIndustry")
            ddlJobType.SelectedValue = dt.Rows(0).Item("JobType")


            If Not dt.Rows(0).Item("NoRequestedEmployees").ToString = "" Then
                txtNoEmp.Text = dt.Rows(0).Item("NoRequestedEmployees").ToString
            End If

            lblJobStatus.Text = dt.Rows(0).Item("JobStatus").ToString

        End If
    End Sub

    Protected Sub gdvAddedEmployees_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvAddedEmployees.SelectedIndexChanged
        Try
            Response.Write("<script>" & vbCrLf)
            Response.Write("window.open('" & "../AllRegisteredUsers/CurriculumVitae.aspx?UserID=" & gdvAddedEmployees.SelectedRow.Cells(1).Text & "','mywindow','status=0','toolbar=0','width=200',heigth='800'');" & vbCrLf)
            Response.Write("<" & Chr(47) & "script>")
        Catch
        End Try
    End Sub

    Private Sub populateAddedEmployees()
        gdvAddedEmployees.DataSource = cJob.GetEmployeesByJob(JobID)
        gdvAddedEmployees.DataBind()
        Try
            gdvAddedEmployees.HeaderRow.Cells(1).Visible = False
            For Each gvr As GridViewRow In gdvAddedEmployees.Rows
                gvr.Cells(1).Visible = False
            Next
        Catch
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim dt As DataTable = cJob.getJobByID(Session("JobID"))
        Dim jobObject = New cJob(dt)
        jobObject.ParseDataTableDetails(dt)

        Dim Employer As cUser = Session("UserObject")

        Dim StartDate As Date = CDate(txtStartingDate.Text)
        Dim EndDate As Date = CDate(txtEndingDate.Text)
        Dim ClosingDate As Date = CDate(txtClosingDate.Text)

        If ((StartDate > EndDate) Or (ClosingDate < StartDate)) Then
            jobObject.updateJob(txtDesc.Text, txtReq.Text, ClosingDate, StartDate, EndDate, txtOccupation.Text, ddlJobType.SelectedValue, txtNoEmp.Text, jobObject.JobID)
            Response.Redirect("MyPendingJobs.aspx")
        Else
            lblInvalidDate.Visible = True
        End If


    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        ddlJobType.Enabled = True
        'ddlOccupation.Enabled = True
        'ddlIndustry.Enabled = True

        txtOccupation.Enabled = True
        txtIndustry.Enabled = True


        txtDesc.ReadOnly = False
        txtReq.ReadOnly = False
        txtClosingDate.ReadOnly = False
        txtEndingDate.ReadOnly = False
        txtStartingDate.ReadOnly = False
        txtNoEmp.ReadOnly = False

        imgClosing.Visible = True
        imgEnding.Visible = True
        imgStarting.Visible = True

        btnSave.Visible = True

    End Sub

    Protected Sub btnManageEmployees_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkManageEmployees.Click
        Response.Redirect("ManageEmployees.aspx")
    End Sub

    Protected Sub btnAddEmployees_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddEmployees.Click
        Response.Redirect("AddEmployeeToJob.aspx")
    End Sub

    'Protected Sub ddlIndustry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIndustry.SelectedIndexChanged
    '    GetOccupation()
    'End Sub

    'Protected Sub ddlIndustry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIndustry.TextChanged
    '    GetOccupation()
    'End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Try
            If Not Page.IsPostBack Then
                GetJobType()
                'GetIndustry()
                'GetOccupation()
                'populateJobDetails()

                If Not Session("JobID") = Nothing Then
                    JobID = Session("JobID")
                    populateJobDetails()
                    gdvAddedEmployees.DataSource = cJob.GetEmployeesByJob(JobID)
                    gdvAddedEmployees.DataBind()

                    Dim objJob As New cJob(JobID)
                    If (objJob.EndDate < System.DateTime.Now) Then
                        lnkAddEmployees.Visible = False
                        lnkManageEmployees.Visible = False
                    End If



                Else
                    Response.Redirect("MyPendingJobs.aspx")
                End If
            End If

        Catch ex As Exception
            cLogging.AddLog("Job Details could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        End Try
    End Sub
End Class
