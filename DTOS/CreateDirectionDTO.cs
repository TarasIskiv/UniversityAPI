using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOS
{
    public class CreateDirectionDTO
    {
        [Required]
        public string DirectionName { get; set; }
    }
}