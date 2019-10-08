Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization

Public Class cFeedback
    Public Enum feedBackType
        ANONYMOUS_FEEDBACK = 1
        CANCEL_EMPLOYEE_SUBSCRIBTION = 2
        CANCEL_EMPLOYER_SUBSCRIBTION = 3
        CANCEL_CENTER_SUBSCRIBTION = 4
    End Enum

    ''' <summary>
    ''' Adds the feedback.
    ''' </summary>
    ''' <param name="feedbackMessage">The feedback message.</param>
    ''' <param name="feedbackType">Type of the feedback.</param>
    ''' <param name="fromUser">From user.</param>
    ''' <param name="feedbackSubject">The feedback subject.</param>
    ''' <returns></returns>
    Public Shared Function addFeedback(ByVal feedbackMessage As String, ByVal feedbackType As feedBackType, ByVal fromUser As String, ByVal feedbackSubject As String) As Int32
        Try
            Return cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblFeedback (Feedback, FeedbackTypeID, FromUser, Subject, Stamp) VALUES ('{0}', {1}, '{2}', '{3}', GETDATE())", _
                          feedbackMessage.Replace("'", "''"), Convert.ToInt16(feedbackType), fromUser, feedbackSubject)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cFeedback.addFeedback: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    'TODO: NOT SUPPORTED
    ''' <summary>
    ''' Confirms the code.
    ''' </summary>
    ''' <param name="userID">The user ID.</param>
    ''' <param name="code">The code.</param>
    ''' <returns></returns>
    Public Shared Function confirmCode(ByVal userID As String, ByVal code As String) As Boolean
        Throw New NotSupportedException
        'Try
        '    Dim sb As New StringBuilder
        '    Dim usCulture = New CultureInfo("en-US")
        '    Dim datenow As DateTime = Convert.ToDateTime(System.DateTime.Now(), usCulture)
        '    With sb
        '        .Append("SELECT TimeGenerated FROM tblActivationKey WHERE (ActivationKey = '")
        '        .Append(code)
        '        .Append("') AND (UserID = ")
        '        .Append(userID)
        '        .Append(")")
        '    End With
        '    Dim td As String = ""

        '    td = cDBManager.GetExecuteScalar(New Data.SqlClient.SqlCommand(sb.ToString))

        '    'TODO: check if code is not valid fixme....
        '    If (datenow.ToString = td) Then

        '    End If
        '    If (True) Then
        '        Debug.Write("Confirmation Code Match!")
        '        Return True
        '    Else
        '        Debug.Write("Failed to Match Confirmation Code!")
        '        Return False
        '    End If

        'Catch ex As Exception
        '    cLogging.AddLog(String.Format("cFeedback.confirmCode: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
        '    Throw ex
        'End Try
    End Function
End Class
