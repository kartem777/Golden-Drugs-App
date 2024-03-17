using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
namespace Golden_Drugs
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=usertest1.db");
        }
    }
}
