using System.ComponentModel.DataAnnotations.Schema;
using jobForm.Common;
using jobForm.Models.Entities;

namespace jobForm.Common;

public abstract class FullAuditableEntity : BaseAuditableEntity
{
    [ForeignKey(nameof(CreatedById))] public virtual User? CreatedBy { get; set; }

    public Guid? CreatedById { get; set; }

    [ForeignKey(nameof(ModifiedById))] public virtual User? ModifiedBy { get; set; }

    public Guid? ModifiedById { get; set; }

    [ForeignKey(nameof(DeletedById))] public virtual User? DeletedBy { get; set; }

    public Guid? DeletedById { get; set; }
}