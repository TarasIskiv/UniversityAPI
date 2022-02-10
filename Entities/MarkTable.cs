using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Entities
{
    public class MarkTable
    {
        [Key]
        public int Id {get; set;}
        public int StudentId {get; set;}

        public virtual Student Student {get; set;}
        [Required]
        public string Subject { get; set; }
        [Required]
        public double Mark { get; set; }
    }
}