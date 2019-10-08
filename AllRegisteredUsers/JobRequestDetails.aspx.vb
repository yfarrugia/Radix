
Partial Class Employees_JobRequestDetails
    Inherits System.Web.UI.Page

    Private _refUserObj As cUser
    Public Property UserDetails() As cUser
        Get
            Return _refUserObj
        End Get
        Set(ByVal value As cUser)
            _refUserObj = value
        End Set
    End Property

    Private _JobRequest As cJobRequestTo
    Public Property JobRequest() As cJobRequestTo
        Get
            Return _JobRequest
        End Get
        Set(ByVal value As cJobRequestTo)
            _JobRequest = value
        End Set
    End Property



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objRequest As New cJobRequestTo(Session("RequestID"))
        objRequest.ParseDataTable(objRequest.GetJobRequest)
        JobRequest = objRequest
        DisplayCorrectPanel()
        CheckRefererAndAssociateMessage()
        If Not Page.IsPostBack Then
            dtvRequest.DataSource = cJobManagement.GetRequestDetails(JobRequest.JobRequestToID)
            dtvRequest.DataBind()
        End If
    End Sub

    Private Sub CheckRefererAndAssociateMessage()
        If Not Session("referer") = Nothing Then
            If Session("MessageID") > -1 Then
                cJobManagement.AssociateMessage(Session("MessageID"), JobRequest.JobRequestToID)
            End If
            Session.Remove("referer")
            Session.Remove("MessageID")
        End If
    End Sub

    Private Sub DisplayCorrectPanel()
        If (JobRequest.JobRequestStatusID = cJobRequestTo.RequestStatus.Pending_Interested Or JobRequest.JobRequestStatusID = cJobRequestTo.RequestStatus.Enquiring) Then
            plAcceptDeny.Visible = False
            plInterested.Visible = True
        ElseIf (JobRequest.JobRequestStatusID = cJobRequestTo.RequestStatus.Pending_Confirmation) Then
            plInterested.Visible = False
            plAcceptDeny.Visible = True
        Else
            plInterested.Visible = False
            plAcceptDeny.Visible = False
        End If
    End Sub

    Protected Sub btnInterested_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInterested.Click
        Dim rowseffected As Integer = cJobManagement.UpdateRequestStatus(cJobRequestTo.RequestStatus.Interested, JobRequest.JobRequestToID)
        If rowseffected = 1 Then
            lblMessage.Text = "Update Successful"
            Response.Redirect("~/Employees/Employee.aspx")
        Else
            lblMessage.Text = "Update Not Successful"
        End If
    End Sub

    Protected Sub btnNotInterested_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNotInterested.Click
        Dim rowseffected As Integer = cJobManagement.UpdateRequestStatus(cJobRequestTo.RequestStatus.Not_Interested, JobRequest.JobRequestToID)
        If rowseffected = 1 Then
            lblMessage.Text = "Update Successful"
            Response.Redirect("~/Employees/Employee.aspx")
        Else
            lblMessage.Text = "Update Not Successful"
        End If
    End Sub

    Protected Sub btnEnquire_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnquire.Click
        Dim rowseffected As Integer = cJobManagement.UpdateRequestStatus(cJobRequestTo.RequestStatus.Enquiring, JobRequest.JobRequestToID)
        If rowseffected = 1 Then
            'Dim objJob As New cJob(cJob.getJobByID(JobRequest.JobID))
            Session.Add("RequestID", JobRequest.JobRequestToID)
            Response.Redirect("CreateMessage.aspx?Enquire=Yes")
        Else
            lblMessage.Text = "Update Not Successful"
        End If
    End Sub

    Protected Sub btnAccept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Dim roweffected As Integer = cJobManagement.UpdateRequestStatus(cJobRequestTo.RequestStatus.Accepted, JobRequest.JobRequestToID)
        If roweffected = 1 Then
            lblMessage.Text = "Update Successful"
            cEmployee.UpdateAsEmployeed(UserDetails.userId)
            Response.Redirect("~/Employees/Employee.aspx")
        Else
            lblMessage.Text = "Update Unsuccessful"
        End If
    End Sub

    Protected Sub btnDeny_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeny.Click
        Dim roweffected As Integer = cJobManagement.UpdateRequestStatus(cJobRequestTo.RequestStatus.Denied, JobRequest.JobRequestToID)
        If roweffected = 1 Then
            lblMessage.Text = "Update Successful"
            Response.Redirect("~/Employees/Employee.aspx")
        Else
            lblMessage.Text = "Update Unsuccessful"
        End If
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        UserDetails = Session("UserObject")
        If UserDetails.userType = "Employee" Then
            Me.MasterPageFile = "~/Employees/EmployeeMasterPage.master"
        End If
        If UserDetails.userType = "Employer" Then
            Me.MasterPageFile = "~/Employers/EmployerMasterPage.master"
        End If
        If UserDetails.userType = "CenterAdmin" Then
            Me.MasterPageFile = "~/CenterAdmin/CenterAdminMasterPage.master"
        End If
    End Sub
End Class
