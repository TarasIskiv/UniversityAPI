using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityAPI.Entities;

namespace UniversityAPI.DTOS
{
    public class CreateStudentDTO
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
        public int CourseYear { get; set; }
        public int DirectionId {get; set;}
    }
}