using Microsoft.EntityFrameworkCore;

namespace UniversityAPI.Entities
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions options) : base(options){}

        public DbSet<Student> Students { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Direction> Directions {get; set;}

        public DbSet<MarkTable> MarkTables {get; set;}

        public DbSet<Admin> Admins {get; set;}
    }
}