using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.DAL.DAL.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(40);
            builder.Property(x => x.LastName).HasMaxLength(65);
            builder.Property(x => x.PhoneNumber).HasMaxLength(15);

        }
    }
}
