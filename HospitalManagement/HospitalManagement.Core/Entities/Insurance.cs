using HospitalManagement.Core.Entities.Base;

namespace HospitalManagement.Core.Entities
{
    public class Insurance : BaseAuiditableEntity
    {
        public string? PersonInsurance { get; set; }
        public float Discount { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }
}
