using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Entities
{
    public class MarkTable
    {
        [Key]
        public int Id {get; set;}
        public virtual int StudentId {get; set;}
        [Required]
        public string Subject { get; set; }
        [Required]
        public double Mark { get; set; }
    }
}