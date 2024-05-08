using AutoMapper;
using jobForm.Authentication;
using jobForm.Db;
using System;

namespace jobForm.Service.Utilities
{
    public class BaseService(IServiceProvider serviceProvider)
    {
        protected readonly IConfiguration Configuration =
            serviceProvider.GetService(typeof(IConfiguration)) as IConfiguration ??
            throw new NullReferenceException("IConfiguration is null");

        protected IMediaFileService UploadService =>
            serviceProvider.GetService(typeof(IMediaFileService)) as IMediaFileService ??
            throw new NullReferenceException("IMediaFileService is null");


        protected AppDbContext DbContext => serviceProvider.GetService(typeof(AppDbContext)) as AppDbContext ??
        throw new NullReferenceException("AppDbContext is null");

        protected IMapper Mapper => serviceProvider.GetService(typeof(IMapper)) as IMapper ??
                                    throw new NullReferenceException("IMapper is null");

        protected IJwtAuthenticationManager JwtManager =>
            serviceProvider.GetService(typeof(IJwtAuthenticationManager)) as IJwtAuthenticationManager ??
            throw new NullReferenceException("IJwtAuthenticationManager is null");
    }
}
