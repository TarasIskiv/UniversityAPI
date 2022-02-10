using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Entities
{
    public class Lecturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Registered { get; set; } = DateTime.UtcNow;
        [Required]
        public string Degree { get; set; }

        
    }
}