using Microsoft.EntityFrameworkCore;

namespace TatweerSwissTool.Db;

public static class EfExtensions
{
    public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable) where T : class
    {
        var type = typeof(T);
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var isVirtual = property.GetGetMethod()!.IsVirtual;
            // ignore just a comment : && properties.FirstOrDefault(c => c.Name == property.Name + "Id") != null
            if (isVirtual)
                queryable = queryable.Include(property.Name);
        }

        return queryable;
    }
    // TODO: Add ThenIncludeAll method
}