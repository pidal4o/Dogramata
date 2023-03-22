using DiplomaApp.Models;
using DiplomaApp.Models.Catalog;
using DiplomaApp.Models.GlassPane;
using DiplomaApp.Models.Order;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiplomaApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProducts>()
                .HasKey(op => new { op.OrderId, op.GlassPaneId });

            modelBuilder.Entity<OrderProducts>()
                .HasOne(bc => bc.Order)
                .WithMany(b => b.OrderProducts)
                .HasForeignKey(bc => bc.OrderId);

            modelBuilder.Entity<OrderProducts>()
                .HasOne(bc => bc.GlassPaneParent)
                .WithMany(c => c.OrderProducts)
                .HasForeignKey(bc => bc.GlassPaneId);
        }

        public DbSet<PPD> PPD { get; set; }
        public DbSet<GlassPaneParent> GlassPaneParent { set; get; }
        public DbSet<Wing> Wing { set; get; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Catalog> Catalog { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }



    }
}