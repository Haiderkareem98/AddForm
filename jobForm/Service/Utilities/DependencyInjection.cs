using AutoMapper;
using jobForm.Authentication;
using jobForm.Common.Interfaces;
using jobForm.Db;
using jobForm.Interceptors;

namespace jobForm.Service.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // var assembly = Assembly.GetExecutingAssembly();
            //
            // services.RegisterServicesWithAttributes(assembly);


            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddScoped<IMediaFileService, MediaFileService>();

            services.AddScoped<IJwtAuthenticationManager>(provider =>
            {
                var key = configuration["Jwt:Secret"];
                return new JwtAuthenticationManager(key!, provider.GetService<AppDbContext>()!,
                    provider.GetService<IMapper>()!);
            });
            return services;
        }
    }
}
