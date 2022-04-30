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
        public OperaDbContext(DbContextOptions<OperaDbContext> options) : base(options)
        {

        }
        public DbSet<OperaEntity> Operas { get; set; }

    }
}
