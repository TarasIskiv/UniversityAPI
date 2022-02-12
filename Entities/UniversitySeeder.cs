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

                if(!_context.Directions.Any())
                {
                    _context.Directions.AddRange(GetDirections());
                    _context.SaveChanges();
                }

                 if(!_context.Groups.Any())
                {
                    _context.Groups.AddRange(GetGroups());
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

        private IEnumerable<Group> GetGroups()
        {
            var groups = new List<Group>()
            {
                new Group()
                {
                    Name = "Default Group For New Students",
                    CountStudentsInGroup = 0
                }
            };

            return groups;
        }

        private IEnumerable<Direction> GetDirections()
        {
            var directions = new List<Direction>()
            {
                new Direction()
                {
                    DirectionName = "Economic"
                },
                new Direction()
                {
                    DirectionName = "Mathemathic"
                },
                new Direction()
                {
                    DirectionName = "Chemical"
                },
                new Direction()
                {
                    DirectionName = "Biological"
                },
                new Direction()
                {
                    DirectionName = "Physical"
                }
            };

            return directions;
        }
    }
}