using jobForm.Common;
using jobForm.Enums;
using jobForm.Mappings;
using jobForm.Models.Dto.Form.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace jobForm.Models.Entities
{
    public class User : FullAuditableEntity, IMapFrom<UserForm>
    {
        public  string? Username { get; set; }
        [JsonIgnore] public  string? Password { get; set; }
        public Roles Role { get; set; }
        [NotMapped] public string? Token { get; set; }
    }

}
