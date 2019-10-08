
Partial Class Employers_ManageEmployees
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadGridView()
        End If
    End Sub

    Private Sub LoadGridView()
        Dim dt As New Data.DataTable
        dt = cJobManagement.GetInterestedEmployeesForJob(Session("JobID"))
        gdvInterestedEmployees.DataSource = dt
        gdvInterestedEmployees.DataBind()
        If dt.Rows.Count > 0 Then
            gdvInterestedEmployees.HeaderRow().Cells(3).Visible = False
            gdvInterestedEmployees.HeaderRow().Cells(4).Visible = False
            For Each gvrow As GridViewRow In gdvInterestedEmployees.Rows
                gvrow.Cells(3).Visible = False
                gvrow.Cells(4).Visible = False
            Next
        End If
    End Sub

    Protected Sub gdvInterestedEmployees_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdvInterestedEmployees.RowCommand
        Dim rowseffected As Integer
        If e.CommandName = "Accept" Then
            rowseffected = cJobManagement.UpdateRequestStatus(cJobRequestTo.RequestStatus.Pending_Confirmation, gdvInterestedEmployees.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text)
            If rowseffected > 0 Then
                LoadGridView()
            End If
        End If
        If e.CommandName = "Deny" Then
            rowseffected = cJobManagement.UpdateRequestStatus(cJobRequestTo.RequestStatus.Denied, gdvInterestedEmployees.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text)
            LoadGridView()
            'Response.Redirect("../Employers/ManageEmployees.aspx")
        End If
        If e.CommandName = "View" Then
            rowseffected = gdvInterestedEmployees.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text
            If Page.IsPostBack Then
                Response.Write("<script>window.open('../AllRegisteredUsers/CurriculumVitae.aspx?UserID=" & rowseffected & "','mywindow','status=0','toolbar=0','width=200',heigth='800''); </script> ")

                'Response.Redirect("~/AllRegisteredUsers/CurriculumVitae.aspx?UserID=" & rowseffected, False)
            End If
        End If

    End Sub

    
    Protected Sub gdvInterestedEmployees_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvInterestedEmployees.SelectedIndexChanged
        Dim obj As Object = sender
        Response.Redirect("~/AllRegisteredUsers/JobRequestDetails.aspx")
    End Sub
End Class
