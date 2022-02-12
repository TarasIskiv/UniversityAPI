using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOS
{
    public class CreateGroupDTO
    {
        [Required]
        public string Name { get; set; }
        public int CountStudentsInGroup { get; set; } = 0;
    }
}