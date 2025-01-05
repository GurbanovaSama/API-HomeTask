using FinalApiTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalApiTask.DAL.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(ps => new { ps.ProductId, ps.SizeId });

            builder.HasOne(ps => ps.Product)
               .WithMany(p => p.ProductSizes)
               .HasForeignKey(ps => ps.ProductId);

            builder.HasOne(ps => ps.Size)
              .WithMany(s => s.ProductSizes)
              .HasForeignKey(ps => ps.SizeId);
        }
    }
}
