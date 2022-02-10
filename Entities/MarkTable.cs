namespace UniversityAPI.Entities
{
    public class MarkTable
    {
        public int Id {get; set;}
        public virtual int StudentId {get; set;}
        public string Subject { get; set; }
        public double Mark { get; set; }
    }
}