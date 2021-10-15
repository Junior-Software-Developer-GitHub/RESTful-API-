using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        
        public DatabaseContext()
        {
            
        }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {    
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            modelBuilder.Entity<Student>().hash;
        }
        
        

    }
}