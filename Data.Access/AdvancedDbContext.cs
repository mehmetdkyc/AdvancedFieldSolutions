using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access
{
    public class AdvancedDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-QFIKDEC; Database=AdvancedFieldSolutionsDB; Trusted_Connection=True;");
        }
        public DbSet<User> User { get; set; }
        public DbSet<CallReport> CallReport { get; set; }

    }
}
