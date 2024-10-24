using System.Windows.Forms;
using System;
using CommandLine;

class Program
{
    public class Options
    {
        [Option('b', "body", Required = true, HelpText = "email body")]
        public string Body { get; set; }

        [Option('s', "subject", Required = true, HelpText = "subject of the message")]
        public string Subject { get; set; }

        [Option('r', "recipient", Required = true, HelpText = "recipient's email")]
        public string Recipient { get; set; }


        [STAThread]
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
               .WithParsed(options =>
               {
                   string emailAdressSender = Environment.GetEnvironmentVariable("emailSender");
                   string emailAddressRecipient = options.Recipient;
                   string password = Environment.GetEnvironmentVariable("password");

                   string body = options.Body;
                   string subject = options.Subject;

                   var email = new Email("Tester", emailAdressSender, emailAddressRecipient, subject, body);

                   using (OpenFileDialog openFileDialog = new OpenFileDialog())
                   {
                       openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                       openFileDialog.Title = "Choose an image: ";

                       if (openFileDialog.ShowDialog() == DialogResult.OK)
                       {
                           email.AddAttachment(openFileDialog.FileName);
                       }
                       else
                       {
                           Console.WriteLine("No image, but that's okay.");
                       }

                       email.BuildMessage();
                       var emailSender = new EmailSender("smtp.gmail.com", 587, true);
                       emailSender.SendEmail(email, emailAdressSender, password);
                       Console.WriteLine("Email sent from: " + emailAdressSender + " to: " + emailAddressRecipient);

                   }
               });
        }

    }
}


