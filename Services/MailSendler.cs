using System.Net;
using System.Net.Mail;
using UniversityAPI.DTOS;

namespace UniversityAPI.Services
{
    public class MailSendler : IMailSendler
    {
        private const string _login = "webapi.tarasiskiv@gmail.com";
        private const string _password = "xhjelxitheiksrrl";
        public MailSendler()
        {
            
        }
        public void SendMailForNewUsers(string firstName, string lastName, string login)
        {

            string content = string.Format(@" <h1>Dear, {0} {1}!</h1><br>
            <p>You were successfully registered</p>
            <p> With love, <b> University Web Api. </b> </p>",
            firstName, lastName);

             using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_login);
                mail.To.Add(login);
                mail.Subject = "Thanks for registation in University system!";
                mail.Body = content;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_login, _password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}