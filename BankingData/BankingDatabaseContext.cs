using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingData
{
    internal class BankingDatabaseContext : DbContext
    {
        public virtual DbSet<Account> Accounts {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=BankingDatabase;Integrated Security=True;Pooling=False;Connect Timeout=30;");
        }
    }
}
