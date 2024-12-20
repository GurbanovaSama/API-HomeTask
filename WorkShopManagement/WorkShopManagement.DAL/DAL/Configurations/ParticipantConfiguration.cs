using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkShopManagement.Core.Entities;

namespace WorkShopManagement.DAL.DAL.Configurations
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant> 
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(80);
            builder.Property(x => x.Phone).HasMaxLength(20);
        }
    }
}
