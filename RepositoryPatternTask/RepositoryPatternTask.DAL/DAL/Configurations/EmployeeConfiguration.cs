using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.DAL.DAL.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(35);
        builder.Property(x => x.LastName).HasMaxLength(45);
        builder.Property(x => x.Email).HasMaxLength(60);

    }
}
