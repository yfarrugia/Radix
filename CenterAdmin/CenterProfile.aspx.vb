
Partial Class CenterAdmin_CenterProfile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Session("CenterObject") = New cCenter(cCenter.getDetails(4))
            Session("CenterObject") = 4
            fillCountries()
            fillDetails()
        End If
    End Sub

    Private Sub fillCountries()
        ddlCountry.DataSource = cRegional.GetCountries()
        ddlCountry.DataTextField = "Country"
        ddlCountry.DataValueField = "CountryID"
        ddlCountry.DataBind()
    End Sub

    Private Sub fillDetails()
        Dim dt As System.Data.DataTable = cCenter.getDetails(4)
        CenterName.InnerText = dt.Rows(0).Item("CenterName").ToString

        lblAddress.Text = dt.Rows(0).Item("Address").ToString
        txtAddress.Text = dt.Rows(0).Item("Address").ToString

        lblStreetAddress.Text = dt.Rows(0).Item("StreetAddress").ToString
        txtStreetAddress.Text = dt.Rows(0).Item("StreetAddress").ToString

        lblPostCode.Text = dt.Rows(0).Item("PostCode").ToString
        txtPostCode.Text = dt.Rows(0).Item("PostCode").ToString

        lblTown.Text = dt.Rows(0).Item("Town").ToString
        txtTown.Text = dt.Rows(0).Item("Town").ToString

        lblState.Text = dt.Rows(0).Item("State").ToString
        txtState.Text = dt.Rows(0).Item("State").ToString

        ddlCountry.SelectedValue = dt.Rows(0).Item("CountryID")

        lblContactNumber.Text = dt.Rows(0).Item("TelephoneNo").ToString
        txtContactNumber.Text = dt.Rows(0).Item("TelephoneNo").ToString

        lblEmail.Text = dt.Rows(0).Item("EmailAddress").ToString
        txtEmail.Text = dt.Rows(0).Item("EmailAddress").ToString

        'Dim centerRef As cCenter = Session("CenterObject")

        'CenterName.InnerText = centerRef.centerName

        'lblAddress.Text = centerRef.address
        'txtAddress.Text = centerRef.address

        'lblStreetAddress.Text = centerRef.streetAddress
        'txtStreetAddress.Text = centerRef.streetAddress

        'lblPostCode.Text = centerRef.postCode
        'txtPostCode.Text = centerRef.postCode

        'lblTown.Text = centerRef.town
        'txtTown.Text = centerRef.town

        'lblState.Text = centerRef.state
        'txtState.Text = centerRef.state

        'ddlCountry.SelectedValue = centerRef.countryID

        'lblContactNumber.Text = centerRef.telephoneNo
        'txtContactNumber.Text = centerRef.telephoneNo

        'lblEmail.Text = centerRef.emailAddress
        'txtEmail.Text = centerRef.emailAddress
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        toggleFields()
    End Sub



    Private Sub toggleFields()
        btnEdit.Visible = Not btnEdit.Visible
        btnSave.Visible = Not btnSave.Visible
        btnCancel.Visible = Not btnCancel.Visible

        lblAddress.Visible = Not lblAddress.Visible
        lblStreetAddress.Visible = Not lblStreetAddress.Visible
        lblPostCode.Visible = Not lblPostCode.Visible
        lblTown.Visible = Not lblTown.Visible
        lblState.Visible = Not lblState.Visible
        lblContactNumber.Visible = Not lblContactNumber.Visible
        lblEmail.Visible = Not lblEmail.Visible

        txtAddress.Visible = Not txtAddress.Visible
        txtStreetAddress.Visible = Not txtStreetAddress.Visible
        txtPostCode.Visible = Not txtPostCode.Visible
        txtTown.Visible = Not txtTown.Visible
        txtState.Visible = Not txtState.Visible
        txtContactNumber.Visible = Not txtContactNumber.Visible
        txtEmail.Visible = Not txtEmail.Visible

        ddlCountry.Enabled = Not ddlCountry.Enabled
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        toggleFields()
        fillDetails()
    End Sub

    Private Sub updateEditDetails()
        '(ByVal CenterID As Integer, _
        'ByVal Address As String, _
        'ByVal StreetAddress As String, _
        'ByVal PostCpde As String, _
        'ByVal Town As String, _
        'ByVal State As String, _
        'ByVal CountryID As Integer, _
        'ByVal TelephoneNo As String, _
        'ByVal EmailAddress As String) As Boolean

        'UPDATE tblCenter SET Address = '{1}', StreetAddress = '{2}', Town = '{3}', State = '{4}', CountryID  = {5}, PostCode = '{6}', TelephoneNo = '{7}', EmailAddress = '{8}' WHERE (CenterID = {0})", CenterID, Address, StreetAddress, Town, State, CountryID, PostCode, TelephoneNo, EmailAddress)))
        cCenter.updateEditDetials(4, txtAddress.Text, txtStreetAddress.Text, txtPostCode.Text, txtTown.Text, _
                                  txtState.Text, ddlCountry.SelectedValue, txtContactNumber.Text, _
                                  txtEmail.Text)
    End Sub


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        updateEditDetails()
        toggleFields()
        fillDetails()
    End Sub
End Class
