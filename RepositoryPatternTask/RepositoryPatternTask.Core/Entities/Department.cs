using RepositoryPatternTask.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternTask.Core.Entities
{
    public class Department : BaseAuditableEntity
    {
        public string Name { get; set; }    
        public string Description { get; set; }
        public string Location { get; set; }    
        public ICollection<Employee>? Employees { get; set; }    

    }
}
