using Microsoft.EntityFrameworkCore;
using Moviy.Business.Models;

namespace Moviy.Data.Context
{
    public class MoviyDbContext : DbContext
    {
        public MoviyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<LineRoute> LineRoutes { get; set; }
        public DbSet<Local> Locals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Limitar o varchar para 100
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviyDbContext).Assembly);

            //Tirando o delete cascade.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
