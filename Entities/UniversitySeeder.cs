using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniversityAPI.Entities
{
    public class UniversitySeeder
    {
        private readonly UniversityDBContext _context;

        public UniversitySeeder(UniversityDBContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Database.CanConnect())
            {
                if(!_context.Admins.Any())
                {
                    _context.Admins.AddRange(GetAdmins());
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Admin> GetAdmins()
        {
            var admins = new List<Admin>()
            {
                new Admin()
                {
                    Login = "taras.iskiv@gmail.com",
                    Password = "admin123"
                }
            };

            return admins;
        }
    }
}