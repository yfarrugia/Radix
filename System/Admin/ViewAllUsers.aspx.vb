
Partial Class System_Admin_ViewAllUsers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gvAllUsers.DataSource = cSystemAdmin.getAllUsers
        gvAllUsers.DataBind()
    End Sub


    Protected Sub gvAllUsers_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvAllUsers.PageIndexChanging
        gvAllUsers.PageIndex = e.NewPageIndex
        gvAllUsers.DataBind()
    End Sub

    Protected Sub gvAllUsers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAllUsers.PreRender
        Try
            Const GENDER_COL As Int16 = 1
            Const ENABLED_ACCOUNT_COL As Int16 = 5

            gvAllUsers.HeaderRow.Cells(ENABLED_ACCOUNT_COL).Text = Nothing

            For Each gvr As GridViewRow In gvAllUsers.Rows
                Dim imgAccountEnabled As New Image

                Dim tmpCbx As CheckBox = gvr.Cells(ENABLED_ACCOUNT_COL).Controls(0)

                gvr.Cells(ENABLED_ACCOUNT_COL).Controls.Clear()
                imgAccountEnabled.ImageUrl = "../../Images/Icons/Account" & tmpCbx.Checked.ToString & ".png"
                If (tmpCbx.Checked) Then
                    imgAccountEnabled.ToolTip = "Account Enabled"
                Else
                    imgAccountEnabled.ToolTip = "Account Disabled"
                End If
                gvr.Cells(ENABLED_ACCOUNT_COL).Controls.Add(imgAccountEnabled)


                tmpCbx = gvr.Cells(GENDER_COL).Controls(0)
                gvr.Cells(GENDER_COL).Controls.Clear()
                If tmpCbx.Checked.ToString Then
                    gvr.Cells(GENDER_COL).Text = "F"
                Else
                    gvr.Cells(GENDER_COL).Text = "M"
                End If
            Next
        Catch ex As Exception
            System.Diagnostics.Debug.Write(ex.Message)
        End Try
        
    End Sub
End Class
