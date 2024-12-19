using RepositoryPatternTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternTask.DAL.Repositories.Abstractions
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
    }
}
