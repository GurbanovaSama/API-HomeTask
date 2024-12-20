using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkShopManagement.Core.Entities;

namespace WorkShopManagement.DAL.DAL.Configurations
{
    public class WorkShopConfiguration : IEntityTypeConfiguration<WorkShop>
    {
        public void Configure(EntityTypeBuilder<WorkShop> builder)
        {
            builder.HasKey(x => x.Id);  
            builder.Property(x => x.Title).HasMaxLength(50);    
            builder.Property(x=>x.Description).HasMaxLength(80);
            builder.Property(x => x.Location).HasMaxLength(100);
        }
    }
}
