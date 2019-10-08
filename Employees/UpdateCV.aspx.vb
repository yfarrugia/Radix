Imports System.Data
Imports System.Globalization

Partial Class Employees_UpdateCV
    Inherits System.Web.UI.Page

    Public _QualificationId As New Integer
    Public _PreviousJobId As New Integer

    Private _objUser As cUser

    Public Property myUser() As cUser
        Get
            Return _objUser
        End Get
        Set(ByVal value As cUser)
            _objUser = value
        End Set
    End Property

    Public QualificationSelected As Integer
    'Public JobSelected As Integer
    'Public PreferredJobSelected As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myUser = Session("UserObject")

        If Not Page.IsPostBack Then
            loadQualifications()
            loadJobHistory()
            loadPreferredJob()

            TabContainerUpdateCV.ActiveTabIndex = 0
        End If


    End Sub


    '' QUALIFICATIONS

    Private Sub loadQualifications()

        'If Not Page.IsPostBack Then
        If gvQualifications.Rows.Count > 0 Then
            gvQualifications.DataSource = Nothing
            gvQualifications.DataBind()
        End If

        gvQualifications.DataSource = cEmployee.getEmployeeQualifications(myUser.userId)
        gvQualifications.DataBind()

        If gvQualifications.Rows.Count > 0 Then
            gvQualifications.HeaderRow.Cells(2).Visible = False
            For Each gvrID As GridViewRow In gvQualifications.Rows
                gvrID.Cells(2).Visible = False
            Next
        End If

    End Sub

    Protected Sub gvQualifications_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvQualifications.RowCommand
        'Dim QualificationSelected As Integer

        If e.CommandName = "QualificationE" Then

            QualificationSelected = gvQualifications.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
            EditQualifications()
        End If


        If e.CommandName = "QualificationD" Then

            QualificationSelected = gvQualifications.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
            cQualification.deleteQualification(QualificationSelected)

        End If

    End Sub

    Private Sub viewQualificationControls()

        pnlQualification.Visible = True
        btnSaveQualification.Visible = True
        btnAddQualification.Visible = False


    End Sub

    Protected Sub EditQualifications()
        Dim dt As New DataTable
        dt = cQualification.getQualificationsByID(QualificationSelected)

        txtQualification.Text = dt.Rows(0).Item("Qualification").ToString
        txtQualiAwardingBody.Text = dt.Rows(0).Item("AwardingBody").ToString
        txtQualiDate.Text = dt.Rows(0).Item("DateAwarded")

        viewQualificationControls()
        btnSaveUpdates.Visible = True
    End Sub

    Protected Sub btnSaveQualification_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveQualification.Click
        'Dim DateFormat As String = "mm/dd/yyyy h:mm:ss tt"
        'Dim culture As CultureInfo = CultureInfo.CurrentCulture
        Dim Qualidate As Date = CDate(txtQualiDate.Text)
        Dim qualification As New cQualification

        If Qualidate <= Today Then
            qualification.saveQualification(txtQualification.Text, Qualidate, txtQualiAwardingBody.Text, myUser.userId)
            'afterSaveQualification()
            loadQualifications()
            pnlQualification.Visible = False
            lblQualiSaved.Visible = True

        Else
            lblInvalidDate.Visible = True
        End If


    End Sub

    Protected Sub btnSaveUpdates_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveUpdates.Click

        Dim dt As DataTable = cQualification.getQualificationsByID(_QualificationId)
        Dim qualificationObject = New cQualification(dt)
        qualificationObject.ParseDataTableDetailsQualification(dt)
        Dim d As Date = CDate(txtQualiDate.Text)
        If txtQualiDate.Text >= Today Then

            'Dim qualiDate As Date = DateTime.Parse(txtQualiDate.Text)
            qualificationObject.updateQualification(txtQualification.Text, d, txtQualiAwardingBody.Text, qualificationObject.QualificationID)

            loadQualifications()
            lblQualiSaved.Text = "Qualification Updates saved Successfully"
            lblQualiSaved.Visible = True
        Else
            lblInvalidDate.Visible = True
        End If

    End Sub

    Protected Sub btnAddQualification_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddQualification.Click
        viewQualificationControls()
        btnSaveQualification.Visible = True
    End Sub

    'Private Sub afterSaveQualification()

    '    txtQualification.Visible = False
    '    txtQualiAwardingBody.Visible = False
    '    txtQualiDate.Visible = False

    '    lblQualiAdd.Visible = False
    '    lblAwardingBody.Visible = False
    '    lblQualiDate.Visible = False

    '    imgQualiDate.Visible = False
    '    btnSaveQualification.Visible = False
    '    btnSaveUpdates.Visible = False
    '    loadQualifications()

    'End Sub


    '' JOB HISTORY
    Private Sub loadJobHistory()


        If gvJobHistory.Rows.Count > 0 Then
            gvJobHistory.DataSource = Nothing
            gvJobHistory.DataBind()
        End If

        gvJobHistory.DataSource = cJobHistory.getJobHistory(myUser.userId)
        gvJobHistory.DataBind()

        GetIndustry(ddlIndustry)
        GetJobType(ddlJobType)

        If Not Page.IsPostBack Then
            GetAllOccupation(ddlOccupation)
        Else
            GetOccupation(ddlOccupation, ddlIndustry)
        End If

        If gvJobHistory.Rows.Count > 0 Then
            gvJobHistory.HeaderRow.Cells(1).Visible = False

            For Each gvrID As GridViewRow In gvJobHistory.Rows
                gvrID.Cells(1).Visible = False
            Next
        End If
        

    End Sub

    Public Sub GetJobType(ByVal _ddl As DropDownList)

        Dim dtJobType As DataTable
        dtJobType = cJob.getJobTypes()

        _ddl.DataSource = dtJobType
        _ddl.DataValueField = "JobTypeID"
        _ddl.DataTextField = "JobType"
        _ddl.DataBind()

    End Sub

    Public Sub GetAllOccupation(ByVal _ddl As DropDownList)

        _ddl.DataSource = cOccupation.GetAllOccupations
        _ddl.DataValueField = "OccupationID"
        _ddl.DataTextField = "Occupation"
        _ddl.DataBind()

    End Sub

    Public Sub GetOccupation(ByVal _ddl As DropDownList, ByVal _ddlIndustry As DropDownList)

        _ddl.DataSource = cOccupation.GetAllOccupationsByIndustry(_ddlIndustry.SelectedValue)
        _ddl.DataValueField = "OccupationID"
        _ddl.DataTextField = "Occupation"
        _ddl.DataBind()


    End Sub

    Public Sub GetIndustry(ByVal _ddl As DropDownList)
        _ddl.DataSource = cIndustry.GetAllIndustries()
        _ddl.DataValueField = "JobIndustryID"
        _ddl.DataTextField = "JobIndustry"
        _ddl.DataBind()

    End Sub

    Protected Sub gvJobHistory_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvJobHistory.RowCommand


        Dim JobSelected As Integer
        If e.CommandName = "PreviousJobE" Then

            JobSelected = gvJobHistory.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            _PreviousJobId = JobSelected
            editJobHistory()


        End If

    End Sub

    'Private Sub viewJobControls()

    '    txtTitle.Visible = True
    '    txtDescription.Visible = True
    '    txtCompany.Visible = True
    '    txtStartDate.Visible = True
    '    txtEndDate.Visible = True

    '    lblTitle.Visible = True
    '    lblDescription.Visible = True
    '    lblCompanyName.Visible = True
    '    lblStartDate.Visible = True
    '    lblEndDate.Visible = True
    '    lblOccupation.Visible = True
    '    lblIndustry.Visible = True
    '    lblJobType.Visible = True

    '    ddlJobType.Visible = True
    '    ddlOccupation.Visible = True
    '    ddlIndustry.Visible = True

    '    imgEnding.Visible = True
    '    imgStarting.Visible = True

    '    btnAddJob.Visible = True

    'End Sub

    Private Sub editJobHistory()

        Dim dt As New DataTable
        dt = cJobHistory.getJobHistoryByID(_PreviousJobId)
        If dt.Rows.Count > 0 Then

            For Each dr In dt.Rows

                txtTitle.Text = dt.Rows(0).Item("Title").ToString
                txtDescription.Text = dt.Rows(0).Item("Description").ToString
                txtCompany.Text = dt.Rows(0).Item("CompanyName").ToString
                txtStartDate.Text = dt.Rows(0).Item("StartDate")
                txtEndDate.Text = dt.Rows(0).Item("EndDate")

                ddlIndustry.SelectedValue = dr("IndustryID")
                ddlOccupation.SelectedValue = dr("OccupationID")
                ddlJobType.SelectedValue = dr("JobTypeID")

            Next
        End If

        'viewJobControls()

        btnAddJob.Visible = False
        btnUpdateJob.Visible = True

    End Sub

    Protected Sub btnJobSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJobSave.Click

        Dim oJobHistory As New cJobHistory
        Try

            ''START AND END DATE INPUTTED BOTH

            If txtEndDate.Text <> Nothing Then

                If (txtStartDate.Text < txtEndDate.Text) Then
                    lblInvalidDate.Text = "Invalid Date End date is prior to Starting date"
                    lblInvalidDate.Visible = True

                ElseIf (txtStartDate.Text <= Today) And (txtEndDate.Text <= Today) Then
                    oJobHistory.savePreviousJob(txtTitle.Text, txtDescription.Text, txtCompany.Text, txtStartDate.Text, txtEndDate.Text, myUser.userId, ddlIndustry.SelectedValue, ddlOccupation.SelectedValue, ddlJobType.SelectedValue)

                    loadJobHistory()
                    pnlJobHistory.Visible = False
                    btnAddJob.Visible = True
                    lblSavedPreviousJob.Visible = True
                    pnlJobHistory.Visible = False

                Else
                    lblInvalidDate.Visible = True
                End If
            End If

            'END DATE NOT INPUTTED
            If (txtStartDate.Text <= Today) And (txtEndDate.Text = Nothing) Then
                oJobHistory.savePreviousJobWithoutEndDate(txtTitle.Text, txtDescription.Text, txtCompany.Text, txtStartDate.Text, myUser.userId, ddlIndustry.SelectedValue, ddlOccupation.SelectedValue, ddlJobType.SelectedValue)

                loadJobHistory()
                pnlJobHistory.Visible = False
                btnAddJob.Visible = True
                lblSavedPreviousJob.Visible = True
            Else
                lblInvalidDate.Visible = True
            End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnUpdateJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateJob.Click
        ' _PreviousJobId = gvJobHistory.SelectedRow.Cells(1).Text

        Dim dt As DataTable = cJobHistory.getJobHistoryByID(_PreviousJobId)
        Dim objJobHistory = New cJobHistory(dt)
        objJobHistory.ParseDataTableDetails(dt)
        Dim qualiDate As Date = DateTime.Parse(txtQualiDate.Text)

        Try
            If (txtStartDate.Text <> Nothing) And (txtEndDate.Text <> Nothing) And (txtStartDate.Text >= Today) And (txtEndDate.Text >= Today) Then

                objJobHistory.updatePreviousJob(txtDescription.Text, txtCompany.Text, txtStartDate.Text, txtEndDate.Text, myUser.userId, ddlOccupation.SelectedValue, ddlJobType.SelectedValue)
                loadJobHistory()
                pnlJobHistory.Visible = False

                lblSavedPreviousJob.Text = "Updated Prefvious Job Successfully"
                lblSavedPreviousJob.Visible = True

            ElseIf (txtEndDate.Text = Nothing) And (txtStartDate.Text <> Nothing) And (txtStartDate.Text >= Today) Then
                objJobHistory.updatePreviousJob(txtDescription.Text, txtCompany.Text, txtStartDate.Text, txtEndDate.Text, myUser.userId, ddlOccupation.SelectedValue, ddlJobType.SelectedValue)
                loadJobHistory()
                pnlJobHistory.Visible = False

                lblSavedPreviousJob.Text = "Updated Prefvious Job Successfully"
                lblSavedPreviousJob.Visible = True


            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddJob.Click
        pnlJobHistory.Visible = True

        'viewJobControls()
        btnJobSave.Visible = True
        btnAddJob.Visible = False
    End Sub

    Protected Sub ddlIndustry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIndustry.SelectedIndexChanged
        GetOccupation(ddlOccupation, ddlIndustry)
    End Sub

    'Private Sub afterSaveJobHistory()

    '    txtTitle.Visible = False
    '    txtDescription.Visible = False
    '    txtCompany.Visible = False
    '    txtStartDate.Visible = False
    '    txtEndDate.Visible = False

    '    lblTitle.Visible = False
    '    lblDescription.Visible = False
    '    lblCompanyName.Visible = False
    '    lblStartDate.Visible = False
    '    lblEndDate.Visible = False
    '    lblOccupation.Visible = False
    '    lblIndustry.Visible = False
    '    lblJobType.Visible = False

    '    ddlJobType.Visible = False
    '    ddlOccupation.Visible = False
    '    ddlIndustry.Visible = False

    '    imgEnding.Visible = False
    '    imgStarting.Visible = False

    '    btnJobSave.Visible = False
    '    btnAddJob.Visible = False

    '    loadJobHistory()

    'End Sub

    '' PREFERRED JOBS

    Private Sub loadPreferredJob()

        'If Not Page.IsPostBack Then
        If gvPreferredJob.Rows.Count > 0 Then
            gvPreferredJob.DataSource = Nothing
            gvPreferredJob.DataBind()
        End If

        GetIndustry(ddlPrefIndustry)
        GetJobType(ddlPrefJobType)

        If Not Page.IsPostBack Then
            GetAllOccupation(ddlPrefOccupation)
        Else
            GetOccupation(ddlPrefOccupation, ddlPrefIndustry)
        End If

        populateGridview()

        'End If

    End Sub

    Private Sub populateGridview()

        gvPreferredJob.DataSource = cPreferredJob.getJobPreferenceByEmployeeID(myUser.userId)
        gvPreferredJob.DataBind()

        btnSaveJobPreference.Visible = False

        If gvPreferredJob.Rows.Count > 0 Then
            gvPreferredJob.HeaderRow.Cells(1).Visible = False
            gvPreferredJob.HeaderRow.Cells(2).Visible = False

            For Each gvrID As GridViewRow In gvPreferredJob.Rows
                gvrID.Cells(1).Visible = False
                gvrID.Cells(2).Visible = False
            Next

        End If

    End Sub

    Protected Sub btnAddJobPreference_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddJobPreference.Click
        viewPreferredJobControls()
        btnAddJobPreference.Visible = False
        btnSaveJobPreference.Visible = True
    End Sub

    Public Sub viewPreferredJobControls()
        lblPrefIndustry.Visible = True
        lblPrefOccupation.Visible = True
        lblPrefJobType.Visible = True

        ddlPrefIndustry.Visible = True
        ddlPrefJobType.Visible = True
        ddlPrefOccupation.Visible = True
    End Sub

    Protected Sub ddlPrefIndustry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPrefIndustry.SelectedIndexChanged
        GetOccupation(ddlPrefOccupation, ddlPrefIndustry)
    End Sub

    Protected Sub gvPreferredJob_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPreferredJob.RowCommand
        If e.CommandName = "JobPreferenceD" Then

            Dim PreferredJobSelected As Integer
            PreferredJobSelected = gvPreferredJob.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            cPreferredJob.deleteJobPreference(PreferredJobSelected)

        End If
    End Sub

    Protected Sub btnSaveJobPreference_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveJobPreference.Click
        Try
            Dim checkUnique As Integer = cPreferredJob.checkExisting(ddlPrefOccupation.SelectedValue, ddlPrefJobType.SelectedValue, myUser.userId)

            If checkUnique >= 1 Then
                lblSaved.Text = "This Job Preferrence has already been Saved"
                lblSaved.Visible = True
                pnlPreferredJob.Visible = False
            Else
                cPreferredJob.savePreferredJob(ddlPrefIndustry.SelectedValue, ddlPrefOccupation.SelectedValue, ddlPrefJobType.SelectedValue, myUser.userId)
                loadPreferredJob()
                pnlPreferredJob.Visible = False
                lblSaved.Visible = True
                'afterSave()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub afterSave()
    '    lblPrefIndustry.Visible = False
    '    lblPrefJobType.Visible = False
    '    lblPrefOccupation.Visible = False

    '    ddlPrefIndustry.Visible = False
    '    ddlPrefJobType.Visible = False
    '    ddlPrefOccupation.Visible = False

    '    btnSaveJobPreference.Visible = False
    '    loadPreferredJob()
    '    'populateGridview()

    'End Sub

  
End Class
