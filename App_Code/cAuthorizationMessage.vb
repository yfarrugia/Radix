Imports Microsoft.VisualBasic

Public Class cAuthorizationMessage
    Inherits cEmail

    ''' <summary>
    ''' Registrations the message.
    ''' </summary>
    ''' <param name="AuthKey">The auth key.</param>
    ''' <param name="Username">The username.</param>
    ''' <param name="ToEmail">To email.</param>
    ''' <returns></returns>
    Public Shared Function RegistrationMessage(ByVal AuthKey As String, _
                                               ByVal Username As String, _
                                               ByVal ToEmail As String) As Boolean
        Try
            Dim msg As New StringBuilder
            With msg
                .Append("Dear Customer,")
                .Append(vbCrLf)
                .Append(vbCrLf)
                .Append("Thank you for registering with Radix Systems.  In doing so you have decided to take an active role in Building An Integrated Future!")
                .Append("Below you will find your unique Authorization Code that will complete the final part of your registration.  This code is valid for only ONE USE and will EXPIRE 1(ONE) HOUR from the time it was issued.")
                .Append(vbCrLf)
                .Append(vbCrLf)
                .Append("If your Authorization Code expires or becomes invalid, you may request a new one from http://radix-systems.net/Anonymous/EnableAccount.aspx?Username=")
                .Append(Username)
                .Append(" .")
                .Append(vbCrLf)
                .Append(vbCrLf)
                .Append("Your Authorization Code: ")
                .Append(AuthKey)
                .Append(vbCrLf)
                .Append("To enable your account click on the link below:")
                .Append(vbCrLf)
                .Append(vbCrLf)
                .Append("http://radix-systems.net/Anonymous/UserAuth.aspx?Auth=")
                .Append(AuthKey)
                .Append("&Username=")
                .Append(Username)
                .Append(vbCrLf)
                .Append(vbCrLf)
                .Append("Should you require an further assistance, please do not hesitate to send us an email on support@radix-systems.net")
                .Append(vbCrLf)
                .Append(vbCrLf)
                .Append(vbCrLf)
                .Append("Sincerely,")
                .Append(vbCrLf)
                .Append("The Radix Systems Team")
            End With
            Return cEmail.SendEmail(cEmail.Email.NOREPLY, ToEmail, Username, cEmail.MessageType.ACCOUNT_CREATE, msg.ToString)
        Catch ex As Exception
            cLogging.AddLog(String.Format("cAuthorizationMessage.RegistrationMessage: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Inserts the confirmation code.
    ''' </summary>
    ''' <param name="ActivationCode">The activation code.</param>
    ''' <param name="userID">The user ID.</param>
    ''' <param name="keyType">Type of the key.</param>
    ''' <returns></returns>
    Public Shared Function insertConfirmationCode(ByVal ActivationCode As String, ByVal userID As Integer, ByVal keyType As cUser.ActivationKeyType) As Boolean
        Try
            Dim sb As New StringBuilder
            With sb
                .Append("INSERT INTO tblActivationKey (ActivationKey, TimeGenerated, KeyTypeID, UserID) VALUES ('")
                .Append(ActivationCode)
                .Append("', GETDATE(),")
                .Append(keyType)
                .Append(",")
                .Append(userID)
                .Append(")")
            End With
            Dim bRet As Boolean = Convert.ToBoolean(cDBManager.ExecuteNonQuery(New Data.SqlClient.SqlCommand(sb.ToString)))
            Return bRet
        Catch ex As Exception
            cLogging.AddLog(String.Format("cAuthorizationMessage.insertConfirmationCode: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
