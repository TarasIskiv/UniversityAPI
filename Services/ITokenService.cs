using System;

namespace UniversityAPI.Services
{
    public interface ITokenService
    {
        public string GetUserToken(Tuple<int, string> result);

        public void ValidateToken(string token);
    }
}