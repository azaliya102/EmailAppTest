using MimeKit;

public class Email
{
    public MimeMessage Message { get; private set; }
    private BodyBuilder bodyBuilder;

    public Email(string fromName, string fromAddress, string toAddress, string subject, string body)
    {
        Message = new MimeMessage();
        Message.From.Add(new MailboxAddress(fromName, fromAddress));
        Message.To.Add(MailboxAddress.Parse(toAddress));
        Message.Subject = subject;

        bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = body;
    }

    public void AddAttachment(string filePath)
    {
        bodyBuilder.Attachments.Add(filePath);
    }

    public void BuildMessage()
    {
        Message.Body = bodyBuilder.ToMessageBody();
    }
}

