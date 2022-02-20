using System.Linq;
using System.Net;
using System.Net.Mail;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;

namespace UniversityAPI.Services
{
    public class MailSendler : IMailSendler
    {
        private const string _login = "webapi.tarasiskiv@gmail.com";
        private const string _password = "xhjelxitheiksrrl";
        private string _userLogin;
        private readonly UniversityDBContext _context;

        public MailSendler(UniversityDBContext context)
        {
            _context = context;
        }
        public void SendMailForNewUsers(string firstName, string lastName, string login)
        {
            string content = string.Format(@" <h1>Dear, {0} {1}!</h1><br>
            <p>You were successfully registered</p>
            <p> With love, <b> University Web Api. </b> </p>",
            firstName, lastName);

            _userLogin = login;
            string subjectForLetter = "Thanks for registation in University system!!"; 

            SendingMail(content, subjectForLetter);            
        }

        public void SendStudentsMarks(int studentId, string subject, double mark)
        {
            var selectedStudent = _context.Students.SingleOrDefault(x => x.Id == studentId);
            _userLogin = selectedStudent.Login;

            string content = string.Format(@" <h1>Dear, {0} {1}!</h1>
            <p>You've got new mark</p>
            <p>Subject : {2}</p>
            <p>Mark : {3}</p>
            <p> With love, <b> University Web Api. </b> </p>",
            selectedStudent.FirstName, selectedStudent.LastName, subject, mark);
            
            string subjectForLetter = "New Mark!"; 

            SendingMail(content, subjectForLetter);
        }

        private void SendingMail(string content, string subject)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_login);
                mail.To.Add(_userLogin);
                mail.Subject = subject;
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