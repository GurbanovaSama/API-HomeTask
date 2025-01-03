using FinalApiTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalApiTask.DAL.Configurations
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.HasOne(p => p.Product)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(p => p.ProductId)    
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(p => p.Color)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(p => p.ColorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
