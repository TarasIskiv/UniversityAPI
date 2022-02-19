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
        public string DirectionName {get;set;}

        public List<SimpleMarkDTO> Marks{get; set;}
        public string GroupName {get; set;}
        
        public double AverageMark { get; set; }
    }
}