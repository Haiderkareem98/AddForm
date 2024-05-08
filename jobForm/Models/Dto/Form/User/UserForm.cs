using jobForm.Enums;

namespace jobForm.Models.Dto.Form.User
{
    public class UserForm
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public Roles Role { get; set; }

    }
}
