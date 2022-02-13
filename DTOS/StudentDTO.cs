using System.Collections.Generic;
using UniversityAPI.Entities;

namespace UniversityAPI.DTOS
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        
        public int CourseYear { get; set; }
        public Direction Direction{get;set;}

        public List<MarkTable> Marks{get; set;}
        public Group Group{get; set;}
        
        public double AverageMark { get; set; }
    }
}