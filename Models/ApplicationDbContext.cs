using Microsoft.EntityFrameworkCore;

namespace tenorchem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Supplier> Suppliers {get; set;}
        public DbSet<PurchaseRecord> PurchaseRecords {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./TenorchemDB.db");
        }

    }
}