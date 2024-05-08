using jobForm.Common;
using jobForm.Enums;
using jobForm.Mappings;
using jobForm.Models.Dto.Form;
using jobForm.Models.Dto.Form.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobForm.Models.Entities
{
    public class MediaFile : FullAuditableEntity, IMapFrom<Dto.Form.jobForm>
    {
        public string? FileName { get; set; }
        public string? OriginalFileName { get; set; }
        public string? FileExtension { get; set; }
        public long FileSize { get; set; }
      

        [NotMapped]
        public string FileUrl =>
            $"{Helper.StaticConfiguration?["MediaFileUrl"]}/{UploadDirectory.ToString()}/{FileName}{FileExtension}";

        public UploadDirectory UploadDirectory { get; set; } = UploadDirectory.Job;
    }
}
