using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.DTOS
{
    public class CreateMarkDTO
    {
        [Required]
        public int StudentId {get; set;}
        
        [Required]
        public string Subject { get; set; }

        [Required]
        public double Mark { get; set; }
    }
}