using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShopManagement.Core.Entities;
using WorkShopManagement.DAL.DAL;
using WorkShopManagement.DAL.Repositories.Abstractions;

namespace WorkShopManagement.DAL.Repositories.Implementations
{
    public class ParticipantRepository : GenericRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(AppDbContext context) : base(context) { }  
    }
}
