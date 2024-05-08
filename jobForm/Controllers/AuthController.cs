using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jobForm.Db;
using jobForm.Mappings;
using jobForm.Models.Dto.Global;
using jobForm.Models.Entities;
using TatweerSwissTool.Db;
using jobForm.Models.Dto.Form.User;
using jobForm.Models.Form.Global;

namespace jobForm.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController(IServiceProvider serviceProvider) : BaseController(serviceProvider)
{
    [HttpPost]
    public async Task<ActionResult<GlobalResponse<User>>> Login(UserLogin loginForm)
    {
        var user = await JwtManager.Authenticate(loginForm.Username, loginForm.Password);

        if (user == null)
            return Unauthorized(new GlobalResponseEmpty("Invalid username or password", true));

        return Ok(new GlobalResponse<User>(user, "Login successful"));
    }


    [Authorize]
    [HttpPost]
    public async Task<ActionResult<GlobalResponse<User>>> RegisterUser(UserForm registerUserForm)
    {
        try
        {
            var newUser = await JwtManager.Register(registerUserForm, registerUserForm.Role);
            if (newUser.Item1 != 0)
                return BadRequest(new GlobalResponseEmpty(
                    newUser.Item1 == 1
                        ? "User with this Username already exists"
                        : "User with this phone already exists",
                    true));

            return Ok(new GlobalResponse<User?>(newUser.Item2, "Registered successfully"));
        }
        catch (Exception e)
        {
            return BadRequest(new GlobalResponseEmpty(e.Message, true));
        }
    }


  
    [HttpGet]
    public async Task<ActionResult<PaginationResponse<User>>> GetUsers([FromQuery] string? username,
        [FromQuery] Pagination pagination)
    {
        try
        {
            var users = DbContext.Users.IncludeAll().AsQueryable();


            if (!string.IsNullOrWhiteSpace(username))
                users = users.Where(c => EF.Functions.ILike(c.Username, $"%{username}%"));


            return Ok(await users.PaginatedListAsync(pagination));
        }
        catch (Exception e)
        {
            return BadRequest(new PaginationResponseEmpty(e.Message, true));
        }
    }


    // edit user
    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GlobalResponse<User>>> EditUser(Guid id, UserForm userForm)
    {
        try
        {
            var user = await DbContext.Users.FindAsync(id);

            if (user == null)
                return BadRequest(new GlobalResponseEmpty($"User with id {id} not found"));


            Mapper.Map(userForm, user);
            await DbContext.SaveChangesAsync();
            return Ok(new GlobalResponse<User>(user, "User updated successfully"));
        }
        catch (Exception e)
        {
            return BadRequest(new GlobalResponseEmpty(e.Message, true));
        }
    }

    // delete user
    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<GlobalResponse<User>>> DeleteUser(Guid id)
    {
        try
        {
            var user = await DbContext.Users.FindAsync(id);

            if (user == null)
                return NotFound(new GlobalResponseEmpty($"User with id {id} not found"));

            user.IsDeleted = true;
            await DbContext.SaveChangesAsync();
            return Ok(new GlobalResponse<User>(user, "User deleted successfully"));
        }
        catch (Exception e)
        {
            return BadRequest(new GlobalResponseEmpty(e.Message, true));
        }
    }
}