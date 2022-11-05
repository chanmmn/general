using System.Net.Mail;
using System.Net;

namespace ConAppSystemNetMail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MailMessage newMessage = new MailMessage();
            SmtpClient mailService = new SmtpClient();
            newMessage.From = new MailAddress("SenderAccount@Office365Domain.com");
            newMessage.To.Add("RecevierAccount@gmail.com");
            newMessage.Subject = "This is an email";
            newMessage.Body = "This is the body content of the email sent by WIN-JE7GER2VIH5 STMP Server.";
            mailService.Port = 25;
            mailService.EnableSsl = true;
            mailService.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailService.Host = "smtp.office365.com";
            mailService.UseDefaultCredentials = false;
            mailService.Credentials = new NetworkCredential("SenderAccount@Office365Domain.com ", "Password");
            mailService.Send(newMessage);

        }
    }
}