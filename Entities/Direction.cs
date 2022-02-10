using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Entities
{
    public class Direction
    {
        [Key]
        public int Id {get; set;}

        [Required]
        public string DirectionName { get; set; }
    }
}