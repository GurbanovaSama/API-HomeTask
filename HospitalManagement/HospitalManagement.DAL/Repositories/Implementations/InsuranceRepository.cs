using HospitalManagement.Core.Entities;
using HospitalManagement.DAL.DAL;
using HospitalManagement.DAL.Repositories.Abstractions;

namespace HospitalManagement.DAL.Repositories.Implementations
{
    public class InsuranceRepository : GenericRepository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
