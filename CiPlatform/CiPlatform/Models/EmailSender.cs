
using System;
using System.Net;
using System.Net.Mail;

public class EmailSender
{
    public void SendEmail(string recipient, string subject, string body)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("npsmtp217@outlook.com");
        mail.To.Add(recipient);
        mail.Subject = subject;
        mail.Body = body;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp-mail.outlook.com";
        smtp.Port = 587;
        smtp.Credentials = new NetworkCredential("npsmtp217@outlook.com", "npSMTP@1234");
        smtp.EnableSsl = true;
        try
        {
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending email: " + ex.Message);
        }
    }
}