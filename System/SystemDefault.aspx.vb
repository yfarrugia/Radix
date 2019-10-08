Imports System.Data.SqlClient

Partial Class System_SystemDefault
    Inherits System.Web.UI.Page
    Private UserDetails As cUser

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            FillContactsGridView()
        End If
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        UserDetails = Session("UserObject")

        Select Case UserDetails.userType
            Case "SystemAdmin"
                Me.MasterPageFile = "~/System/Admin/SystemMasterPage.master"
            Case "SupportAdmin"
                Me.MasterPageFile = "~/System/Support/SupportMasterPage.master"
        End Select
    End Sub

    Protected Sub lnkSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSearch.Click
        FillContactsGridViewSearch()
    End Sub

    Private Sub FillContactsGridView()
        Dim command As New SqlCommand
        Try
            command.CommandText = "SELECT tblUser.Name + ' ' + tblUser.Surname AS Name, tblUser.TelephoneNo AS [Contact Number], tblUser.EmailAddress AS [E-Mail], tblUserType.Type " & _
                            "FROM tblUser INNER JOIN " & _
                            "tblUserType ON tblUser.UserTypeID = tblUserType.UserTypeID " & _
                            "WHERE(tblUserType.Type = 'SystemAdmin') OR " & _
                            "(tblUserType.Type = 'SupportAdmin')"
            gdvContactList.DataSource = cDBManager.GetDataTable(command)
            gdvContactList.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillContactsGridViewSearch()
        Dim command As New SqlCommand

        If txtContactSearch.Text.Trim.Length > 0 Then
            Try
                command.CommandText = "SELECT tblUser.Name + ' ' + tblUser.Surname AS Name, tblUser.TelephoneNo AS [Contact Number], tblUser.EmailAddress AS [E-Mail], tblUserType.Type " & _
                                "FROM tblUser INNER JOIN " & _
                                "tblUserType ON tblUser.UserTypeID = tblUserType.UserTypeID " & _
                                "WHERE(tblUserType.Type = 'SystemAdmin') OR " & _
                                "(tblUserType.Type = 'SupportAdmin')  AND (tblUser.Name LIKE '%" + txtContactSearch.Text + "%')"
                gdvContactList.DataSource = cDBManager.GetDataTable(command)
                gdvContactList.DataBind()
            Catch ex As Exception

            End Try
        Else
            FillContactsGridView()
        End If
        
    End Sub

    Protected Sub lnkViewAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkViewAll.Click
        FillContactsGridView()
    End Sub
End Class
