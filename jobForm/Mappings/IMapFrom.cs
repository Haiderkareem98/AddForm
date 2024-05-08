using AutoMapper.QueryableExtensions;
using AutoMapper;
using System.Reflection;
using jobForm.Models.Dto.Global;
using jobForm.Models.Form.Global;
using Microsoft.EntityFrameworkCore;

namespace jobForm.Mappings
{

    public interface IMapFrom<T>
    {
        void Mapping(Profile profile)
        {
            var map = profile.CreateMap(typeof(T), GetType());

            foreach (var property in typeof(T).GetProperties()
                         .Where(e => e.GetCustomAttributes().Any(x => x.GetType() == typeof(IgnoreMapperAttribute))))
                map.ForMember(property.Name, opt => opt.Ignore());
        }
    }

    public static class MappingExtensions
    {
        public static Task<PaginationResponse<TDestination>> PaginatedListAsync<TDestination>(
            this IQueryable<TDestination> queryable, Pagination pagination) where TDestination : class
        {
            return PaginationResponse<TDestination>.CreateAsync(queryable, pagination);
        }

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable)
            where TDestination : class
        {
            // get IConfigurationProvider automatically
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            return queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
        }

        // pagination and thin projection to TDestination
        public static Task<PaginationResponse<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable,
            Pagination pagination) where TDestination : class
        {
            // get IConfigurationProvider automatically
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            return PaginationResponse<TDestination>.CreateAsync(queryable.ProjectTo<TDestination>(configuration),
                pagination);
        }
    }


    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom<>);

            var mappingMethodName = nameof(IMapFrom<object>.Mapping);

            bool HasInterface(Type t)
            {
                return t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;
            }

            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

            Type[] argumentTypes = [typeof(Profile)];

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod(mappingMethodName);

                if (methodInfo != null)
                {
                    methodInfo.Invoke(instance, [this]);
                }
                else
                {
                    var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                    if (interfaces.Count <= 0) continue;
                    foreach (var @interface in interfaces)
                    {
                        var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

                        interfaceMethodInfo?.Invoke(instance, [this]);
                    }
                }
            }
        }
    }
}
