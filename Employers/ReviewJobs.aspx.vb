Imports System.Diagnostics

Partial Class Employers_ReviewJobs
    Inherits System.Web.UI.Page

    Private Sub fillFinishedJobs()
        Try
            Dim o As cUser = Session("UserObject")
            gdvFinishedJobs.DataSource = cEmployer.getFinishedJobs(o.userId)
            gdvFinishedJobs.DataBind()

            If Not (gdvFinishedJobs.Rows.Count <= 0) Then
                gdvFinishedJobs.HeaderRow.Cells(1).Visible = False
                For Each gvr As GridViewRow In gdvFinishedJobs.Rows
                    gvr.Cells(1).Visible = False
                Next

                Debug.Write("List of Jobs Filled")
            End If
            'remove ID
            
        Catch ex As Exception
            Debug.Write(ex.Message)
            Throw ex
        End Try
        

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillFinishedJobs()
        Catch ex As Exception
            Debug.Write(ex.Message)
        End Try

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvFinishedJobs.SelectedIndexChanged
        Session.Add("JobID", gdvFinishedJobs.SelectedRow.Cells(1).Text)
        Response.Redirect("ReviewJobDetails.aspx")
    End Sub
End Class
