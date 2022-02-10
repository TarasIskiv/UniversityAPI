using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Entities
{
    public class Student
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
        public int CourseYear { get; set; }
        public virtual int DirectionId {get; set;}
        public virtual List<MarkTable> Marks{get; set;}
        public virtual int GroupId {get; set;}
        public double AverageMark { get; set; }


    }
}