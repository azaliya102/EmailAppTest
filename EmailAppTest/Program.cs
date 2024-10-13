class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your email: ");
        string emailAdressSender = Environment.GetEnvironmentVariable("emailAdressSender");
        string emailAddressRecipient = Environment.GetEnvironmentVariable("emailAddressRecipient");
        string password = Environment.GetEnvironmentVariable("password");
        string body = "HELLO!";
        string subject = "";
        var email = new Email("Tester", emailAdressSender, emailAddressRecipient, subject, body);

        email.AddAttachment(@"C:\Users\Azalia\Desktop\goose.jpeg");

        email.BuildMessage();

        var emailSender = new EmailSender("smtp.gmail.com", 465, true);
        emailSender.SendEmail(email, emailAdressSender, password);
    }
}



