using RepositoryPatternTask.Core.Entities;
using RepositoryPatternTask.DAL.DAL;
using RepositoryPatternTask.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternTask.DAL.Repositories.Implementations
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context) { }
        
    }
}
