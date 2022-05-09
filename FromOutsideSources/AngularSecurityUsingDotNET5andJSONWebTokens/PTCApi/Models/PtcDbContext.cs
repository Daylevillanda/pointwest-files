using Microsoft.EntityFrameworkCore;
using PTCApi.EntityClasses;

namespace PTCApi.Model {
  public partial class PtcDbContext : DbContext {
    public PtcDbContext(DbContextOptions<PtcDbContext> options) : base(options) {
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating( ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
    }
  }
}
