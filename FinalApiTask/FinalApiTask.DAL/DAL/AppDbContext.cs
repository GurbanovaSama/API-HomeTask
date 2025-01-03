using FinalApiTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinalApiTask.DAL.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions) { }


        public DbSet<AppUser> AppUsers { get; set; }  
        public DbSet<Category> Categories { get; set; }     
        public DbSet<Product> Products { get; set; }        
        public DbSet<Color> Colors { get; set; }    
        public DbSet<Size> Sizes { get; set; }  
        public DbSet<ProductColor> ProductColors { get; set; }  
        public DbSet<ProductSize> ProductSizes { get; set; }    



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
