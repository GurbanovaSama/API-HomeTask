using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPatternTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternTask.DAL.DAL.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(130);
            builder.Property(x => x.Location).HasMaxLength(130);
        }
    }
}
