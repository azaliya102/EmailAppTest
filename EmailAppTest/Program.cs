class Program
{
    static void Main(string[] args)
    {
        string emailAdress = "azaliamuratova628@gmail.com";
        string password = Environment.GetEnvironmentVariable("password");
        string body = "HELLO!";
        string subject = "";
        var email = new Email("Tester", emailAdress, "indonesianwesleysnipes@gmail.com", subject, body);

        email.AddAttachment(@"C:\Users\Azalia\Desktop\goose.jpeg");

        email.BuildMessage();

        var emailSender = new EmailSender("smtp.gmail.com", 465, true);
        emailSender.SendEmail(email, emailAdress, password);
    }
}



