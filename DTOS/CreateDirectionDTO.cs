using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOS
{
    public class CreateDirectionDTO
    {
        [Required]
        public string Name { get; set; }
    }
}