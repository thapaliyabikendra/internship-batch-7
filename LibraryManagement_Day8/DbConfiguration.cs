using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_Day8_
{
    public class DbConfiguration : DbContext
    {
        public DbSet<Author>Authors { get; set; }
        public DbSet<Books>Books { get; set; }
        public DbSet<Borrowers> Borrowers { get; set; }
        private string Dbpath = Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\LibraryManagement.db");
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={Dbpath}");
    }
}
