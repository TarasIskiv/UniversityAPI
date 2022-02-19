using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityAPI.DTOS;

namespace UniversityAPI.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual List<Student> StudentsInGroup {get; set;}
        public int CountStudentsInGroup { get; set; }
    }
}