using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

public class EmailSender
{
    private string smtpServer;
    private int port;
    private bool useSsl;

    public EmailSender(string smtpServer, int port, bool useSsl)
    {
        this.smtpServer = smtpServer;
        this.port = port;
        this.useSsl = useSsl;
    }

    public void SendEmail(Email email, string fromAddress, string password)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(smtpServer, port, SecureSocketOptions.StartTls);
                client.Authenticate(fromAddress, password);
                client.Send(email.Message);
                Console.WriteLine("Email Sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
            finally
            {
                client.Disconnect(true);
            }
        }
    }
}