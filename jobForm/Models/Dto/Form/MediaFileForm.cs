using jobForm.Enums;

namespace jobForm.Models.Dto.Form
{
    public class jobForm
    {
        public required string FileName { get; set; }
        public required string OriginalFileName { get; set; }
        public required string FileExtension { get; set; }
        public long FileSize { get; set; }
        public UploadDirectory UploadDirectory { get; set; } = UploadDirectory.Job;
    }
}
