using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operas.Data.Models;

namespace Operas.Data.Context
{
    public class OperaDbContext: DbContext
    {
        private readonly string _connectionString;
        public OperaDbContext(): this("Server=BMMBQG3;Database=Opera;User Id=sa;Password=sqlserver")
        {

        }
        public OperaDbContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public DbSet<Opera> Operas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this._connectionString);
            }
        }
    }
}
