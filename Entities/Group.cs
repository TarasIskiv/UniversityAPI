using System.Collections.Generic;

namespace UniversityAPI.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Student> StudentsInGroup {get; set;}
        public int CountStudentsInGroup { get; set; }
    }
}