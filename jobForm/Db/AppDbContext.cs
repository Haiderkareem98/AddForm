using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using jobForm.Common;
using jobForm.Models.Entities;
using jobForm.Interceptors;
using jobForm.Common.Interfaces;


namespace jobForm.Db;

public class AppDbContext(
    DbContextOptions options,
    AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
    : DbContext(options), IApplicationDbContext
{
    public required DbSet<User> Users { get; set; }
    public required DbSet<MediaFile> MediaFiles { get; set; }
    public required DbSet<Job> Job { get; set; }
    public required DbSet<Final_Infomation> Finals { get; set; }
    public required DbSet<IdentityInformation> IdentityInformations { get; set; }
    public required DbSet<ReferenceInfo> ReferenceInfos { get; set; }
    public required DbSet<HusbandOrWifeModel> husbandOrWifeModels {  get; set; }
    public required DbSet<Beneficiary> beneficiaries { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // // builder.HasQueryFilter(x => x.IsDeleted == false);
        // Iterate through all entity types
        foreach (var entityType in builder.Model.GetEntityTypes())
            // Check if the entity type inherits from BaseAuditableEntity
            if (typeof(FullAuditableEntity).IsAssignableFrom(entityType.ClrType))
            {
                // Build lambda expression for the filter condition
                var parameter = Expression.Parameter(entityType.ClrType, "x");
                var property = Expression.Property(parameter, "IsDeleted");
                var condition = Expression.Equal(property, Expression.Constant(false));
                var lambda = Expression.Lambda(condition, parameter);

                // Apply query filter dynamically
                builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(auditableEntitySaveChangesInterceptor);
    }
}