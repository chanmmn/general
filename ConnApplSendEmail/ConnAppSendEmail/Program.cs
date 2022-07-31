using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace ConAppNetMail
{    
    class Program
    {
        static void Main(string[] args)
        {
            MailMessage newMessage = new MailMessage();
            SmtpClient mailService = new SmtpClient();
            newMessage.From = new MailAddress("starcraft@WIN-JE7GER2VIH5");
            newMessage.To.Add("ming@gmail.com");
            newMessage.Subject = "This is an email";
            newMessage.Body = "This is the body content of the email sent by WIN-JE7GER2VIH5 STMP Server.";
            mailService.Port = 25;
            mailService.Host = "localhost";
            mailService.UseDefaultCredentials = false;
            mailService.Send(newMessage);
        }
    }
}

