using System.Collections.Generic;
using UniversityAPI.Entities;

namespace UniversityAPI.DTOS
{
    public class GroupDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Student> StudentsInGroup {get; set;}
        public int CountStudentsInGroup { get; set; }
    }
}