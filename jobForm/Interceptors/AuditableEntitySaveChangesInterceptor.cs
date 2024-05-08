using jobForm.Common.Interfaces;
using jobForm.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using jobForm.Common.Interfaces;

namespace jobForm.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor(
      ICurrentUserService currentUserService,
      IDateTime dateTime)
      : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<FullAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedById = currentUserService.UserId;
                    entry.Entity.CreatedAt = dateTime.Now;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified ||
                    entry.HasChangedOwnedEntities())
                {
                    entry.Entity.ModifiedById = currentUserService.UserId;
                    entry.Entity.ModifiedAt = dateTime.Now;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedById = currentUserService.UserId;
                    entry.Entity.DeletedAt = dateTime.Now;
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public static class Extensions
    {
        public static bool HasChangedOwnedEntities(this EntityEntry entry)
        {
            return entry.References.Any(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                r.TargetEntry.State is EntityState.Added or EntityState.Modified);
        }
    }
}
