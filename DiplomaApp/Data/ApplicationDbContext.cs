using DiplomaApp.Models;
using DiplomaApp.Models.GlassPane;
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

        public DbSet<PPD> PPD { get; set; }
        public DbSet<GlassPaneParent> GlassPaneParent { set; get; }
        public DbSet<Wing> Wing { set; get; }
        public DbSet<Price> Price { get; set; }

    }
}