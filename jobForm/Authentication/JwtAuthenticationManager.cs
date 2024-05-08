using AutoMapper;
using jobForm.Db;
using jobForm.Enums;
using jobForm.Models.Dto.Form.User;
using jobForm.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IBcrypt = BCrypt.Net.BCrypt;

namespace jobForm.Authentication
{
    public class JwtAuthenticationManager(string key, AppDbContext dbContext, IMapper mapper) : IJwtAuthenticationManager
    {
        public async Task<User?> Authenticate(string usernameOrEmail, string password)
        {
            // Verify the user's credentials.
            var isValidUser = await dbContext.Users
                .FirstOrDefaultAsync(user =>
                    user.Username == usernameOrEmail);
            if (isValidUser == null || !IBcrypt.Verify(password, isValidUser.Password))
                return null;
            GenerateToken(ref isValidUser);
            return isValidUser;
        }

        public string HashPassword(string password)
        {
            return IBcrypt.HashPassword(password);
        }

        public async Task<(int, User?)> Register(UserForm userForm, Roles roles)
        {
            // Verify the user's credentials.
            if (!string.IsNullOrEmpty(userForm.Username))
                if (await dbContext.Users.AsNoTracking().AnyAsync(f => f.Username == userForm.Username))
                    return (1, null);


            var user = mapper.Map<User>(userForm);
            user.Role = roles;
            user.Password = HashPassword(user.Password);
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return (0, await Authenticate(userForm.Username, userForm.Password));
        }

        private void GenerateToken(ref User isValidUser)
        {
            // Generate a JWT token.
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Convert.FromBase64String(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, isValidUser.Username),
                new Claim(ClaimTypes.NameIdentifier, isValidUser.Id.ToString()),
                new Claim(ClaimTypes.Role, isValidUser.Role.ToString())
            }),
                Issuer = "jobForm",
                Audience = "jobForm",
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            isValidUser.Token = tokenHandler.WriteToken(token);
        }
    }
}
