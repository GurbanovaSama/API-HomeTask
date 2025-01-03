namespace FinalApiTask.Core.Entities.Base
{
    public abstract class BaseAuiditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
        public string? CreatedBy { get; set; }
    }
}
