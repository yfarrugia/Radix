Imports System.Data


Partial Class AllUsers_UserProfile
    Inherits System.Web.UI.Page

    Private Emp As cEmployee


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetCountries()
            setTextboxes()

        End If


    End Sub

    Public Sub setTextboxes()
        Dim dtProfile As New DataTable
        Dim dr As DataRow
        System.Diagnostics.Debug.Write("test")
        Try

            dtProfile = cEmployee.getEmployeeProfile(Session("SelectedUserID"))

            If dtProfile.Rows.Count > 0 Then

                For Each dr In dtProfile.Rows

                    txtName.Text = dr("Name")
                    txtSurname.Text = dr("Surname")
                    txtNationality.Text = dr("Nationality")

                    txtAddress.Text = dr("Address")
                    txtStrAddress.Text = dr("StreetAddress")
                    txtPostCode.Text = dr("PostCode")
                    txtTown.Text = dr("Town")

                    Dim _countryID As Integer = dr("CountryID")
                    Dim Country As String = cRegional.GetCountry(_countryID)
                    ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByText(Country))


                    txtDOB.Text = dr("DOB")
                    txtEmail.Text = dr("EmailAddress")

                    If Not dr("TelephoneNo").ToString = "" Then
                        txtTelephoneNo.Text = dr("TelephoneNo")

                    End If

                    If dr("isEmployed") = True Then
                        chkEmployed.Checked = True
                    End If


                    If dr("isSeeking") = True Then
                        chkSeeking.Checked = True
                    End If

                    If dr("Sponsored") = True Then
                      chkSponsored.Checked = True
                    End If

                Next


                If gvQualifications.Rows.Count > 0 Then
                    gvQualifications.DataSource = Nothing
                    gvQualifications.DataBind()
                End If

                gvQualifications.DataSource = cEmployee.getEmployeeQualifications(Session("SelectedUserID"))
                gvQualifications.DataBind()

                gvQualifications.HeaderRow.Cells(0).Visible = False

                For Each gvrID As GridViewRow In gvQualifications.Rows
                    gvrID.Cells(0).Visible = False
                Next



            Else
                cLogging.AddLog("Employee Details could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
            End If


        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetCountries()
        Dim dtCountries As DataTable

        If Not cRegional.GetCountries().Equals(Nothing) Then
            dtCountries = cRegional.GetCountries()

            ddlCountry.DataSource = dtCountries
            ddlCountry.DataValueField = "CountryID"
            ddlCountry.DataTextField = "Country"
            ddlCountry.DataBind()
        Else
            cLogging.AddLog("Countries could not be retrieved or populated.", Session("UserIP"), cLogging.LogType.SYSTEM_LOG, Session.SessionID, Session("UserID"), Session("UserType"), Request.ServerVariables("AUTH_USER"))
        End If

    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtSurname.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        If txtAddress.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        If txtStrAddress.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

     
        If txtTown.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        If txtEmail.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        If txtTelephoneNo.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        If txtPostCode.ReadOnly Then
            ToggleButtons(False)
        Else
            ToggleButtons(True)
        End If

        chkEmployed.Enabled = True
        chkSeeking.Enabled = True
        chkSponsored.Enabled = True


    End Sub

    Private Sub ToggleButtons(ByVal _isReadOnly As Boolean)

        txtSurname.ReadOnly = _isReadOnly
        txtAddress.ReadOnly = _isReadOnly
        txtStrAddress.ReadOnly = _isReadOnly
        txtTown.ReadOnly = _isReadOnly
        txtEmail.ReadOnly = _isReadOnly
        ddlCountry.Enabled = Not (_isReadOnly)
        txtTelephoneNo.ReadOnly = _isReadOnly
        txtPostCode.ReadOnly = _isReadOnly

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'check validations

        Try

            Dim UpdateUser As cUser
            Dim originalCID As Integer = cUser.getCountryByUserID(Session("SelectedUserID"))
            Dim c As String = ddlCountry.SelectedValue

            If c <> originalCID Then
                UpdateUser = New cUser(txtAddress.Text, _
                                                  txtStrAddress.Text, _
                                                  txtTown.Text, _
                                                  txtState.Text, _
                                                  txtPostCode.Text, _
                                                  txtTelephoneNo.Text, _
                                                  txtEmail.Text, _
                                                  c)

            Else
                UpdateUser = New cUser(txtAddress.Text, _
                                                 txtStrAddress.Text, _
                                                 txtTown.Text, _
                                                 txtState.Text, _
                                                 txtPostCode.Text, _
                                                 txtTelephoneNo.Text, _
                                                 txtEmail.Text, _
                                                 originalCID)
            End If
            'intiate save sequence
            cUser.UpdateUser(UpdateUser, Session("SelectedUserID"))

            setEmployeeBooleans()
            cEmployee.UpdateEmployee(Emp, Session("SelectedUserID"))

            cLogging.AddLog("Successfully Updated User, UserID" & Session("SelectedUserID"), Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, Nothing, Nothing, Nothing)

        Catch ex As Exception
            cLogging.AddLog("Error Updating User: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)

        End Try

    End Sub

    Private Sub setEmployeeBooleans()

        Try
            Dim dt As DataTable = cEmployee.getEmployeeByID(Session("SelectedUserID"))
            Emp = New cEmployee(dt, Session("SelectedUserID"))
            Emp.ParseDataTableDetails(dt)

            If Not (chkEmployed.Checked = Emp.isEmployed) Then
                Emp.isEmployed = chkEmployed.Checked
            End If

            If Not (chkSeeking.Checked = emp.isSeeking) Then
                emp.isSeeking = chkSeeking.Checked
            End If

            If Not (chkSponsored.Checked = emp.Sponsored) Then
                emp.Sponsored = chkSponsored.Checked
            End If


        Catch ex as Exception


        End Try


    End Sub

    Protected Sub btnCancelCenter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelCenter.Click
    
        Try
            

        Catch ex As Exception


        End Try

    End Sub

    Protected Sub btnQualification_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQualification.Click

        txtQualification.Visible = True
        txtQualiAwardingBody.Visible = True
        txtQualiDate.Visible = True

        lblQualiAdd.Visible = True
        lblAwardingBody.Visible = True
        lblQualiDate.Visible = True


        imgCalendar.Visible = True
       'btnAddQuali.Visible = True
        btnQualification.Visible = False

    End Sub

    Protected Sub btnQualiAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQualiAdd.Click

        Try
            Dim q As New cQualification
            q.saveQualification(txtQualification.Text, txtQualiDate.Text, txtQualiAwardingBody.Text, Session("SelectedUserId"))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnCancelSub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelSub.Click
        Try
        
            Response.redirect("CancelSubscribtion.aspx")
        
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnViewCV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewCV.Click
     
        If Page.IsPostBack Then
            Dim mySession As Integer = Session("SelectedUserID")
            Response.Redirect("~/AllRegisteredUsers/CurriculumVitae.aspx?UserID=" & mySession, False)
        End If


    End Sub
End Class

