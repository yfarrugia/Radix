Imports System.Data

Partial Class Employers_CreateJob
    Inherits System.Web.UI.Page

    Public Sub GetJobType()

        Dim dtJobType As DataTable

        'If Not cJob.getJobTypes.Equals(Nothing) Then
        dtJobType = cJob.getJobTypes()

        ddlJobType.DataSource = dtJobType
        ddlJobType.DataValueField = "JobTypeID"
        ddlJobType.DataTextField = "JobType"
        ddlJobType.DataBind()

        'Else
        cLogging.AddLog("Job Types populated successfully.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        'End If
    End Sub

    Public Sub GetOccupation()

        ddlOccupation.DataSource = cOccupation.GetAllOccupationsByIndustry(ddlIndustry.SelectedValue)
        ddlOccupation.DataValueField = "OccupationID"
        ddlOccupation.DataTextField = "Occupation"
        ddlOccupation.DataBind()

        'Else
        'cLogging.AddLog("Occupation could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        'End If


    End Sub

    Public Sub GetIndustry()


        'If Not cOccupation.GetAllOccupations.Equals(Nothing) Then

        ddlIndustry.DataSource = cIndustry.GetAllIndustries()
        ddlIndustry.DataValueField = "JobIndustryID"
        ddlIndustry.DataTextField = "JobIndustry"
        ddlIndustry.DataBind()


        'Else
        cLogging.AddLog("Industry populated successfully.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        'End If


    End Sub




    Public Sub GetCompany()

        'If Not cCompany.getCompaniesByEmployer(Session("UserID")).Equals(Nothing) Then
        lblCompany.Text = cCompany.getCompanyByEmployer(Session("UserObject"))
       
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            GetCompany()
            GetJobType()
            GetIndustry()
            GetOccupation()
        End If

    End Sub


    'Private Function CheckDate(ByVal strIn) As Boolean
    '    ' function to validate date input
    '    'Dim objRE As New Regex("(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d")

    '    objRE.Global = True
    '    CheckDate = objRE.test(strIn)
    '    objRE = Nothing
    'End Function

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        Dim job As New cJob
        Dim Employer As cUser = Session("UserObject")

        'Dim theCultureInfo As IFormatProvider = New System.Globalization.CultureInfo("en-US", True)

        Dim StartDate As Date = CDate(txtStartingDate.Text & " 12:00:00")
        Dim EndDate As Date = CDate(txtEndingDate.Text & " 12:00:00")
        Dim ClosingDate As Date = CDate(txtClosingDate.Text & " 12:00:00")
        Dim CompanyId As Integer = cCompany.getCompanyID(lblCompany.Text, Employer.userId)

        'Dim StartDate As Date = CDate(txtStartingDate.Text & " 12:00:00")
        'Dim EndDate As Date = CDate(txtEndingDate.Text & " 12:00:00")
        'Dim ClosingDate As Date = CDate(txtClosingDate.Text & " 12:00:00")
        'Dim CompanyId As Integer = cCompany.getCompanyID(lblCompany.Text, Employer.userId)




        If (DateDiff("s", StartDate, EndDate) < 0) Or (DateDiff("s", StartDate, EndDate) = 0) Or (DateDiff("s", ClosingDate, StartDate) < 0) Then
            'Start Date is later than End Date
            lblInvalidDate.Visible = True

        Else
            'End Date is later than Start Date
            lblInvalidDate.Visible = False

            Dim dtDate As New Date(2009, 11, 11)
            Session("JobId") = job.saveJob(txtJobTitle.Text, txtDescription.Text, txtRequirements.Text, CompanyId, dtDate, ClosingDate, StartDate, EndDate, ddlOccupation.SelectedValue, ddlJobType.SelectedValue, txtNoEmp.Text, 1)
            Response.Redirect("~/Employers/JobDetails.aspx")
        End If


        'If ((StartDate > EndDate) Or (ClosingDate < StartDate)) Then
        '    lblInvalidDate.Visible = False
        '    Session("JobId") = job.saveJob(txtJobTitle.Text, txtDescription.Text, txtRequirements.Text, CompanyId, Now, ClosingDate, StartDate, EndDate, ddlOccupation.SelectedValue, ddlJobType.SelectedValue, txtNoEmp.Text, 1)
        '    Response.Redirect("~/Employers/JobDetails.aspx")

        'ElseIf Not ((StartDate > EndDate) Or (ClosingDate < StartDate)) Then
        '    lblInvalidDate.Visible = True
        'End If

    End Sub

    Protected Sub ddlIndustry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIndustry.SelectedIndexChanged
        GetOccupation()
    End Sub


End Class
