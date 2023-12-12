
using MimeKit;
using MailKit.Net.Smtp;

namespace WaiBao;

public class Email
{
    public string RecipientEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public Email(string recipientEmail, string subject, string body)
    {
        RecipientEmail = recipientEmail;
        Subject = subject;
        Body = body;
    }
}

public class EmailSender
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _senderEmail;
    private readonly string _senderPassword;

    public EmailSender(string smtpServer, int smtpPort, string senderEmail, string senderPassword)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
        _senderEmail = senderEmail;
        _senderPassword = senderPassword;
    }
    public void SendEmail(Email email)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(AppConfig.EmailSetting.SenderName, _senderEmail));
        message.To.Add(new MailboxAddress("", email.RecipientEmail));
        message.Subject = email.Subject;
        message.Body = new TextPart("html") { Text = email.Body };//plain

        using (var client = new SmtpClient())
        {
            client.Connect(_smtpServer, _smtpPort, true);
            client.Authenticate(_senderEmail, _senderPassword);
            client.Send(message);
            client.Disconnect(true);
        }
    }

}
