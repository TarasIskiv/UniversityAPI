using System;
using System.Linq;
using UniversityAPI.Entities;

namespace UniversityAPI.Indentity
{
    public class IndentityLoginedUser
    {
        private readonly UniversityDBContext _context;

        public IndentityLoginedUser(UniversityDBContext context)
        {
            _context = context;
        }
        public string getLogin(Tuple<int, string> loginedUser)
        {
            if(loginedUser.Item2.Equals("student"))
            {
                return _context.Students.SingleOrDefault(x => x.Id == loginedUser.Item1)?.Login;
            }
            else if(loginedUser.Item2.Equals("lecturer"))
            {
                return _context.Lecturers.SingleOrDefault(x => x.Id == loginedUser.Item1)?.Login;

            }
            else if(loginedUser.Item2.Equals("admin"))
            {
                return _context.Admins.SingleOrDefault(x => x.Id == loginedUser.Item1)?.Login;                
            }

            throw new Exception(); // not found user
        }
    }
}