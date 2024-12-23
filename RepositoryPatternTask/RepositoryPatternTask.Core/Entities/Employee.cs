using RepositoryPatternTask.Core.Entities.Base;

namespace RepositoryPatternTask.Core.Entities
{
    public class Employee : BaseAuditableEntity
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string Email { get; set; }       
        public string PhoneNumber { get; set; } 
        public string Position { get; set; }    
        public bool IsActive { get; set; }    
        public int DepartmentId { get; set; }     
        public Department? Department { get; set; } 
    }
}
