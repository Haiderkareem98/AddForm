namespace TatweerSwissTool.Models.Dto;

public class UploadFileDto
{
    public string? FileName { get; set; }

    public string? FileExtension { get; set; }

    public long FileSize { get; set; }

    public string? OriginalFileName { get; set; }
}