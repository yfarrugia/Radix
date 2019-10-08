Imports Microsoft.VisualBasic
Imports System.Net.Mail

Public Class cEmail

    Enum Email
        NOREPLY
        SUPPORT
        ADMIN
        INFO
        FEEDBACK
    End Enum

    Enum MessageType
        FEEDBACK
        ACCOUNT_CANCEL
        ACCOUNT_CREATE
        FORGOT_PASSWORD
        SYSTEM
        SUPPORT
    End Enum


    ''' <summary>
    ''' Sets the message subject.
    ''' </summary>
    ''' <param name="messageType">Type of the message.</param>
    ''' <returns></returns>
    Private Shared Function SetMessageSubject(ByVal messageType As MessageType) As String
        Select Case messageType
            Case MessageType.FEEDBACK
                Return "Radix Systems - Feedback:"
            Case MessageType.ACCOUNT_CANCEL
                Return "Radix Systems - Confirm Cancellation"
            Case MessageType.ACCOUNT_CREATE
                Return "Radix Systems - Confirm Registration"
            Case MessageType.FORGOT_PASSWORD
                Return "Radix Systems - Retrieve Password"
            Case MessageType.SYSTEM
                Return "Radix Systems - Notification"
            Case MessageType.SUPPORT
                Return "Support Request - " 'append incident id
            Case Else
                Return "Radix Systems "
        End Select
    End Function

    ''' <summary>
    ''' Sets from email.
    ''' </summary>
    ''' <param name="_email">The _email.</param>
    ''' <returns></returns>
    Private Shared Function SetFromEmail(ByVal _email As Email) As String
        Select Case _email
            Case Email.ADMIN
                Return "admin@radix-systems.net"
            Case Email.INFO
                Return "info@radix-systems.net"
            Case Email.NOREPLY
                Return "noreply@radix-systems.net"
            Case Email.SUPPORT
                Return "support@radix-systems.net"
            Case Email.FEEDBACK
                Return "feedback@radix-systems.net"
            Case Else
                Return "info@radix-systems.net"
        End Select
    End Function

    ''' <summary>
    ''' Sets the display name.
    ''' </summary>
    ''' <param name="_email">The _email.</param>
    ''' <returns></returns>
    Private Shared Function SetDisplayName(ByVal _email As Email) As String
        Select Case _email
            Case Email.NOREPLY
                Return "noreply"
            Case Else
                Return "Radix Systems"
        End Select
    End Function

    ''' <summary>
    ''' Sends the email.
    ''' </summary>
    ''' <param name="fromEmail">From email.</param>
    ''' <param name="toEmail">To email.</param>
    ''' <param name="toDisplayName">To display name.</param>
    ''' <param name="messageType">Type of the message.</param>
    ''' <param name="message">The message.</param>
    ''' <returns></returns>
    Public Shared Function SendEmail(ByVal fromEmail As Email, _
                                 ByVal toEmail As String, _
                                 ByVal toDisplayName As String, _
                                 ByVal messageType As MessageType, _
                                 ByVal message As String) As Boolean

        Dim _SmtpClient As New SmtpClient()
        Dim _MailMessage As New MailMessage()

        Try
            Dim fromAddress As New MailAddress(SetFromEmail(fromEmail), SetDisplayName(fromEmail))
            Dim toAddress As New MailAddress(toEmail, toDisplayName)
            Dim ccAddress As New MailAddress(SetFromEmail(fromEmail), SetDisplayName(fromEmail))

            'SET MESSAGETYPE ENUM AND ADD TO MESSAGE

            'Email Message Fields
            _MailMessage.From = fromAddress
            _MailMessage.To.Add(toAddress)
            _MailMessage.CC.Add(ccAddress)
            _MailMessage.Subject = SetMessageSubject(messageType)
            _MailMessage.Body = message

            'Go-Daddy SMTP Server
            '_SmtpClient.Host = "relay-hosting.secureserver.net"
            _SmtpClient.Host = "smtp.onvol.net"
            _SmtpClient.Port = 25
            _SmtpClient.Send(_MailMessage)

            'email sent successfully
            cLogging.AddLog(String.Format("Message Successfully Sent to {0}", toEmail), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Return True
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmail.SendEmail: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Sends the email.
    ''' </summary>
    ''' <param name="fromEmail">From email.</param>
    ''' <param name="toEmail">To email.</param>
    ''' <param name="toDisplayName">To display name.</param>
    ''' <param name="subject">The subject.</param>
    ''' <param name="messageType">Type of the message.</param>
    ''' <param name="message">The message.</param>
    ''' <returns></returns>
    Public Shared Function SendEmail(ByVal fromEmail As Email, _
                                     ByVal toEmail As String, _
                                     ByVal toDisplayName As String, _
                                     ByVal subject As String, _
                                     ByVal messageType As MessageType, _
                                     ByVal message As String) As Boolean

        Dim _SmtpClient As New SmtpClient()
        Dim _MailMessage As New MailMessage()

        Try
            Dim fromAddress As New MailAddress(SetFromEmail(fromEmail), SetDisplayName(fromEmail))
            Dim toAddress As New MailAddress(toEmail, toDisplayName)

            'SET MESSAGETYPE ENUM AND ADD TO MESSAGE

            'Email Message Fields
            _MailMessage.From = fromAddress
            _MailMessage.To.Add(toAddress)
            _MailMessage.Subject = SetMessageSubject(messageType) + subject
            _MailMessage.Body = message

            'Go-Daddy SMTP Server
            '_SmtpClient.Host = "relay-hosting.secureserver.net"
            _SmtpClient.Host = "smtp.onvol.net"
            _SmtpClient.Port = 25
            _SmtpClient.Send(_MailMessage)

            'email sent successfully
            cLogging.AddLog(String.Format("Message Successfully Sent to {}", toEmail), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)

            Return True
        Catch ex As Exception
            cLogging.AddLog(String.Format("cEmail.SendEmail: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
