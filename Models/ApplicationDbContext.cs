using Microsoft.EntityFrameworkCore;

namespace tenorchem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./TenorchemDB.db");
        }

    }
}