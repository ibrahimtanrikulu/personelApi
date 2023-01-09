namespace Domain.Entities.Base
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
