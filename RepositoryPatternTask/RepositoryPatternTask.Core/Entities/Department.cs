using RepositoryPatternTask.Core.Entities.Base;

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
