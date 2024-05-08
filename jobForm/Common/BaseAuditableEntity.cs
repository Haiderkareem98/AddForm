namespace jobForm.Common;

public abstract class BaseAuditableEntity : BaseEntity<Guid>
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
}