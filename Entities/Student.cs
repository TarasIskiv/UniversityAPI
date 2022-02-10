using System;
using System.Collections.Generic;

namespace UniversityAPI.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Registered { get; set; } = DateTime.UtcNow;
        public int CourseYear { get; set; }
        public virtual int DirectionId {get; set;}
        public virtual List<MarkTable> Marks{get; set;}
        public virtual int GroupId {get; set;}
        public double AverageMark { get; set; }


    }
}