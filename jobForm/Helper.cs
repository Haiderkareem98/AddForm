using jobForm.Enums;

namespace jobForm
{
    public class Helper
    {
        public static IConfiguration? StaticConfiguration { get; set; }

        public static string GetUploadDirectory(UploadDirectory mediaFileUploadDirectory)
        {
            var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var uploadDirectory = Path.Combine(wwwRootPath, mediaFileUploadDirectory.ToString());
            if (!Directory.Exists(wwwRootPath))
                Directory.CreateDirectory(wwwRootPath);
            if (!Directory.Exists(uploadDirectory))
                Directory.CreateDirectory(uploadDirectory);
            return uploadDirectory;
        }
    }
}
