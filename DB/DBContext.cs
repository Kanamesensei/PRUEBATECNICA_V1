using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class DBContext : DbContext

    {

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().ToTable("Usuario");
        }
    }
}
