using HospitalManagement.Core.Entities.Base;
using HospitalManagement.Core.Entities.Enums;
using System.Reflection;

namespace HospitalManagement.Core.Entities
{
    public class Patient : BaseAuiditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SeriaNumber { get; set; }
        public string? RegistrationAddress { get; set; }
        public string? CurrentAddress { get; set; }
        public string? Email { get; set; }
        public int InsuranceId { get; set; }
        public Insurance? Insurance { get; set; }
        public Gender Gender { get; set; }
        public BloodGroup BloodGroup { get; set; }

    }
}
