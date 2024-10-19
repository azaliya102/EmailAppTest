using System.Windows.Forms;
using System;

class Program
{
    [STAThread] 
    static void Main(string[] args)
    {
        string emailAdressSender = Environment.GetEnvironmentVariable("emailAdressSender");
        string emailAddressRecipient = Environment.GetEnvironmentVariable("emailAddressRecipient");
        string password = Environment.GetEnvironmentVariable("password");

        string body = "HELLO!";
        string subject = "Test Email";

        var email = new Email("Tester", emailAdressSender, emailAddressRecipient, subject, body);

        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
            openFileDialog.Title = "Choose an image: ";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                email.AddAttachment(openFileDialog.FileName);
                email.BuildMessage();

                var emailSender = new EmailSender("smtp.gmail.com", 465, true);
                emailSender.SendEmail(email, emailAdressSender, password);
            }
            else
            {
                Console.WriteLine("No image.");
            }
        }
    }
}