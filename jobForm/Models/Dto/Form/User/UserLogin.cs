using System.ComponentModel.DataAnnotations;

namespace jobForm.Models.Dto.Form.User
{
    public class UserLogin
    {
        [Required] public string Username { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
    }
}
