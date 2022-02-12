using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOS
{
    public class ModifyDirectionDTO
    {
        public int Id {get; set;}

        [Required]
        public string Name { get; set; }
    }
}