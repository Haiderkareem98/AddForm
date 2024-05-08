using jobForm.Enums;
using jobForm.Models.Dto.Form.User;
using jobForm.Models.Entities;

namespace jobForm.Authentication
{
    public interface IJwtAuthenticationManager
    {
        Task<User?> Authenticate(string usernameOrEmail, string password);
        Task<(int, User?)> Register(UserForm userForm, Roles roles);
        string HashPassword(string password);
    }
}
