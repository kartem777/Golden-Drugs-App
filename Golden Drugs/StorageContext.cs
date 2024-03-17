using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golden_Drugs
{
    public class StorageContext : DbContext
    {
        public DbSet<Item> Items { get; set; } = null!;
        public StorageContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=storage.db");
        }
    }
}
