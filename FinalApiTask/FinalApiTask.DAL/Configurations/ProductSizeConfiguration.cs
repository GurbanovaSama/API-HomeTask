using FinalApiTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalApiTask.DAL.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasOne(p => p.Product)
               .WithMany(p => p.ProductSizes)
               .HasForeignKey(p => p.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Size)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(p => p.SizeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
