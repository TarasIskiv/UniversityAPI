using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOS
{
    public class CreateLecturerDTO
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [Required]
        public string Degree { get; set; }
    }
}