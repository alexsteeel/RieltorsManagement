using Microsoft.EntityFrameworkCore;

namespace RieltorsManagement.DAL
{
    public class RieltorContext : DbContext
    {
        public RieltorContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Риэлторы.
        /// </summary>
        public DbSet<Rieltor> Rieltors { get; set; }

        /// <summary>
        /// Подразделения.
        /// </summary>
        public DbSet<Division> Divisions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rieltor>().ToTable("tRieltors", schema: "dbo");
            modelBuilder.Entity<Division>().ToTable("tDivisions", schema: "dbo");
        }

    }
}
