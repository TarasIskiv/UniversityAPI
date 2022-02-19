using UniversityAPI.DTOS;

namespace UniversityAPI.Services
{
    public interface IMailSendler
    {
         //
        public void SendMailForNewUsers(string firstName, string lastName, string login);
    }
}