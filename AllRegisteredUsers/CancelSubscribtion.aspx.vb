Imports System.Diagnostics

Imports System.Data

Partial Class AllUsers_CancelSubscribtion
    Inherits System.Web.UI.Page

    Private Sub setStepLabels()

        Dim _step1 As String = "Step 1. Account Confirmation"
        Dim _step2 As String = "Step 2. Cancellation Feedback"
        Dim _step3 As String = "Step 3. Confirmation Code"


        lblStep1_1.Text = _step1
        lblStep1_2.Text = _step1
        lblStep1_3.Text = _step1

        lblStep2_1.Text = _step2
        lblStep2_2.Text = _step2
        lblStep2_3.Text = _step2

        lblStep3_1.Text = _step3
        lblStep3_2.Text = _step3
        lblStep3_3.Text = _step3

    End Sub


    Protected Sub btnClearView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearView1.Click
        txtPassword.Text = ""
        txtDOB.Text = ""

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        setStepLabels()
        CancelSubscribtionMultiView.SetActiveView(UserAccountView)
    End Sub

    Protected Sub btnContinueView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinueView1.Click
        If Not (txtPassword.Text = "" And txtDOB.Text = "") And validateDetials() Then
            CancelSubscribtionMultiView.SetActiveView(FeedbackUserView)
        Else
            lblWarning.Text = "Warning"
        End If
    End Sub

    Private Function validateDetials() As String
        Dim o As cUser = Session("UserObject")
        If (o.checkPass(txtPassword.Text) And o.dob = (txtDOB.Text)) Then
            Debug.Write("User Details match")
            'to be moved to email function
            Return True
        End If
        Debug.Write("User Details did not match")
        Return False
    End Function

   
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim o As cUser
        o = Session("UserObject")
        cFeedback.addFeedback(txtFeedbackBody.Text, cFeedback.feedBackType.CANCEL_EMPLOYEE_SUBSCRIBTION, o.username, "Cancelation Of User")
        ' ActivationKeyId, ActivationKey, TimeGenerated, KeyTypeID
        cAuthorizationMessage.insertConfirmationCode(cHash.getRandomGeneratedCode(TimeOfDay & o.userId), o.userId, cUser.ActivationKeyType.CANCELLATION)
        CancelSubscribtionMultiView.SetActiveView(ConfirmUserView)
    End Sub


    Protected Sub btnContinueView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinueView2.Click
        Dim o As cUser = Session("UserObject")

        cFeedback.confirmCode(o.userId, txtCode.Text)

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Dim UserDetails = Session("UserObject")
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
