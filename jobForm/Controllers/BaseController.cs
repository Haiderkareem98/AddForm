using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using System;
using jobForm.Models.Entities;
using jobForm.Enums;
using jobForm.Service;
using jobForm.Db;
using jobForm.Authentication;

public abstract class BaseController(IServiceProvider serviceProvider) : ControllerBase
{
    private IConfiguration _configuration = serviceProvider.GetService(typeof(IConfiguration)) as IConfiguration ??
                                            throw new NullReferenceException("IConfiguration is null");

    protected Guid? UserId => new(GetClaim(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());

    protected User? UserInfo => UserId != Guid.Empty ? DbContext.Users.Find(UserId) : null;

    protected Roles Role => Enum.TryParse<Roles>(GetClaim(ClaimTypes.Role), out var role) ? role : Roles.NotAuthorized;


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

    private string? GetClaim(string type)
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var claim = claimsIdentity?.FindFirst(type);
        return claim?.Value;
    }
}