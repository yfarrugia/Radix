Imports System.Data
Partial Class Employers_MessageInbox
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
        PopulateGridView()
    End Sub
    Private Sub PopulateGridView()
        Dim dtMessages As New DataTable
        dtMessages = cMessageManagement.GetAllMessagesForUser(UserDetails.userId)
        gdvAllMessages.DataSource = dtMessages
        gdvAllMessages.DataBind()
        Try
            gdvAllMessages.HeaderRow.Cells(1).Visible = False
            gdvAllMessages.HeaderRow.Cells(2).Visible = False
            gdvAllMessages.HeaderRow.Cells(3).Visible = False
            gdvAllMessages.HeaderRow.Cells(0).Text = ""
            gdvAllMessages.HeaderRow.Cells(4).Text = ""
            For Each gvr As GridViewRow In gdvAllMessages.Rows
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
    
    Protected Sub gdvAllMessages_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvAllMessages.SelectedIndexChanged
        Session("MessageID") = gdvAllMessages.SelectedRow.Cells(1).Text
        Session("MessageToUser") = gdvAllMessages.SelectedRow.Cells(2).Text
        Dim RowsEffected As Integer = cMessages.UpdateMessageToRead(gdvAllMessages.SelectedRow.Cells(2).Text)
        If RowsEffected > 0 Then
            cLogging.AddLog("Message Updated as Read", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, UserDetails.userId, UserDetails.userType, UserDetails.username)
        Else
            cLogging.AddLog("Error Updating Message as Read", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, UserDetails.userId, UserDetails.userType, UserDetails.username)
        End If
        Response.Redirect("Message.aspx")

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
        If UserDetails.userType = "SupportAdmin" Then
            Me.MasterPageFile = "~/System/Support/SupportMasterPage.master"
        End If
    End Sub
End Class
