using HospitalManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagement.DAL.DAL.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .HasOne(p => p.Insurance)
                .WithMany(p => p.Patients)
                .HasForeignKey(p => p.InsuranceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
