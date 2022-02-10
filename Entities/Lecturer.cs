using System;

namespace UniversityAPI.Entities
{
    public class Lecturer
    {
         public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Registered { get; set; } = DateTime.UtcNow;
        public string Degree { get; set; }

        
    }
}