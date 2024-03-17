using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golden_Drugs
{
    public class CurrentUserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public CurrentUserContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=usertest2.db");
        }
    }
}
