using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CiPlatform.Repository.Repository
{
    public class EmailRepository : IEmailRepository
    {

        void IEmailRepository.SendEmail(string recipient, string subject, string body)
        {

            //MailMessage mail = new MailMessage();
            MailSend mail = new MailSend();
            mail.From = "meetpanchal194@gmail.com";
            mail.To = recipient;
            mail.Subject = subject;
            mail.Body = body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                                          // ** HERE! **
                                          // ***********
            smtp.Credentials = new System.Net.NetworkCredential("meetpanchal194@gmail.com", "ksdqxndnbbsofpyz"); // ***use valid credentials***

            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Port = 587;
            try
            {
                smtp.Send(mail.From, mail.To, mail.Subject, mail.Body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }

        }
        ////}
    }
}
