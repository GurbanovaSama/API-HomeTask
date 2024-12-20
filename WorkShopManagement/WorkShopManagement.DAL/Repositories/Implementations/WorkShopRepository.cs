using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopManagement.Core.Entities;
using WorkShopManagement.DAL.DAL;
using WorkShopManagement.DAL.Repositories.Abstractions;
using WorkShopManagement.DAL.Repositories.Implementations;

namespace WorkShopManagement.DAL.Repositories.Implementations
{
    public  class WorkShopRepository : GenericRepository<WorkShop>, IWorkShopRepository
    {
        public WorkShopRepository(AppDbContext context) : base(context) { }
    }
}
