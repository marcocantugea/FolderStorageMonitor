Imports System.Configuration
Imports System.Net.Mail

Namespace com.lib.notifications

    Public Class EmailSender

        Private Smtp_Server As New SmtpClient
        Private e_mail As New MailMessage()
        Private _MessageText As New Text.StringBuilder
        Private _EmailUserCredential As String
        Private _EmailUserPass As String
        Private _EmailSMTPPort As Integer
        Private _EmailSMTPHost As String
        Private _EmailToNotify As String

        Public Sub SetEmailToNotify()
            Dim emailnoti As String = ConfigurationSettings.AppSettings("EmailToNotify")
            If emailnoti.Count > 0 Then
                _EmailToNotify = emailnoti
            End If
        End Sub

        Public Sub SetEmailtoNotify(value As String)
            _EmailToNotify = value
        End Sub

        Public Sub SetSMTPHost()
            Dim smtphost As String = ConfigurationSettings.AppSettings("EmailSMTPHost")
            If smtphost.Count > 0 Then
                _EmailSMTPHost = smtphost
            End If
        End Sub

        Public Sub SetSMTPHost(value As String)
            _EmailSMTPHost = value
        End Sub

        Public Sub SetSMTPPort()
            Try
                Dim smtpport As String = Integer.Parse(ConfigurationSettings.AppSettings("EmailSMTPPort"))
                If smtpport.Count > 0 Then
                    _EmailSMTPPort = smtpport
                End If
            Catch ex As Exception
                _EmailSMTPPort = 25
            End Try
        End Sub

        Public Sub SetSMTPPort(value As String)
            _EmailSMTPPort = value
        End Sub

        Public Sub SetEmailUserPass()
            Dim userpass As String = ConfigurationSettings.AppSettings("EmailPasswordCredential")
            If userpass.Count > 0 Then
                _EmailUserPass = userpass
            End If
        End Sub

        Public Sub SetEmailUserPass(value As String)
            _EmailUserPass = value
        End Sub
        Public Sub SetEmailUserCredential()
            Dim usercredentias As String = ConfigurationSettings.AppSettings("EmailUserCredential")
            If usercredentias.Count > 0 Then
                _EmailUserCredential = usercredentias
            End If
        End Sub

        Public Sub SetEmailUserCredential(value As String)
            _EmailUserCredential = value
        End Sub

        Public Sub AddTextToMessage(value As String)
            _MessageText.Append(value & vbCrLf)
        End Sub
        Public Property MessageText As Text.StringBuilder
            Get
                Return _MessageText

            End Get
            Set(value As Text.StringBuilder)
                _MessageText = value
            End Set
        End Property

        Public Sub SendMail()
            Try

                SetEmailUserCredential()
                SetEmailUserPass()
                SetSMTPHost()
                SetSMTPPort()
                SetEmailToNotify()


                Smtp_Server.UseDefaultCredentials = False
                Smtp_Server.Credentials = New Net.NetworkCredential(_EmailUserCredential, _EmailUserPass)
                Smtp_Server.Port = _EmailSMTPPort
                Smtp_Server.EnableSsl = False
                Smtp_Server.Host = _EmailSMTPHost

                e_mail = New MailMessage()
                e_mail.From = New MailAddress("mainserver@grm4.com")
                e_mail.To.Add(_EmailToNotify)
                e_mail.Subject = "File Monitoring System  - Report"
                e_mail.IsBodyHtml = False
                e_mail.Body = _MessageText.ToString
                Smtp_Server.Send(e_mail)
            Catch ex As Exception
                Throw ex
            End Try

        End Sub




    End Class
End Namespace
