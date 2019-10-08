Imports System.Data.SqlClient

Partial Class System_Admin_ApprovedCountries
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindGridView()
            BindDropDown()
        End If
    End Sub

    Private Sub BindGridView()
        gdvApproved.DataSource = cRegional.GetApprovedCountries
        gdvApproved.DataBind()
    End Sub

    Private Sub BindDropDown()
        ddlUnapprovedCountries.DataSource = cRegional.GetUnApprovedCountries
        ddlUnapprovedCountries.DataValueField = "CountryID"
        ddlUnapprovedCountries.DataTextField = "Country"
        ddlUnapprovedCountries.DataBind()
    End Sub

    Protected Sub lnkRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRefresh.Click
        BindGridView()
        BindDropDown()
    End Sub

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        ApproveCountry()
        BindGridView()
        BindDropDown()
    End Sub

    Private Sub ApproveCountry()

        If cRegional.SetApprovedCountry(ddlUnapprovedCountries.SelectedValue) > 0 Then
            lblSuccess.Visible = True
            lblError.Visible = False
        Else
            lblSuccess.Visible = False
            lblError.Visible = True
        End If

    End Sub


End Class
