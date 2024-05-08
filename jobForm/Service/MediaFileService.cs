using AutoMapper;
using jobForm.Enums;
using jobForm.Models.Dto.Form;
using jobForm.Models.Entities;
using jobForm.Service.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Imaging;

namespace jobForm.Service
{
    public interface IMediaFileService
    {
        Task<MediaFile> UploadFileAsync(IFormFile file, UploadDirectory uploadDirectory);
        Task<MediaFile?> GetMediaFileAsync(int mediaFileId);
        Task<MediaFile?> UpdateMediaFileAsync(IFormFile file, Guid id);
        Task DeleteMediaFileAsync(Guid mediaFileId);
    }


    public class MediaFileService(IServiceProvider serviceProvider) : BaseService(serviceProvider), IMediaFileService
    {
        public async Task<MediaFile> UploadFileAsync(IFormFile file, UploadDirectory uploadDirectory)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            var fileName = Guid.NewGuid().ToString();
            var fileExtension = Path.GetExtension(file.FileName);
            var fileSize = file.Length;

            var mediaFileDto = new Models.Dto.Form.jobForm
            {
                FileName = fileName,
                OriginalFileName = file.FileName,
                FileExtension = fileExtension,
                FileSize = fileSize,
                UploadDirectory = uploadDirectory
            };

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                // save file to disk
                var path = Path.Combine(Helper.GetUploadDirectory(uploadDirectory), fileName + fileExtension);

                await using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(fileStream);
                }
            }

            var mediaFile = Mapper.Map<MediaFile>(mediaFileDto);
            DbContext.MediaFiles.Add(mediaFile);
            await DbContext.SaveChangesAsync();

            return mediaFile;
        }

        public async Task<MediaFile?> GetMediaFileAsync(int mediaFileId)
        {
            return await DbContext.MediaFiles.FindAsync(mediaFileId);
        }

        public async Task<MediaFile?> UpdateMediaFileAsync(IFormFile file, Guid id)
        {
            var mediaFile = await DbContext.MediaFiles.FindAsync(id);
            if (mediaFile == null) return mediaFile;
            var fileName = Guid.NewGuid().ToString();
            var fileExtension = Path.GetExtension(file.FileName);
            var fileSize = file.Length;

            var mediaFileDto = new Models.Dto.Form.jobForm
            {
                FileName = fileName,
                OriginalFileName = file.FileName,
                FileExtension = fileExtension,
                FileSize = fileSize,
                UploadDirectory = mediaFile.UploadDirectory
            };

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                // save file to disk
                var path = Path.Combine(Helper.GetUploadDirectory(mediaFile.UploadDirectory), fileName + fileExtension);
                await using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(fileStream);
                }
            }

            Mapper.Map(mediaFileDto, mediaFile);
            // delete old file
            // var oldFilePath = Path.Combine(Helper.GetUploadDirectory(mediaFile.UploadDirectory), mediaFile.FileName + mediaFile.FileExtension);
            // if (File.Exists(oldFilePath))
            //     File.Delete(oldFilePath);

            await DbContext.SaveChangesAsync();
            return mediaFile;
        }

        public async Task DeleteMediaFileAsync(Guid mediaFileId)
        {
            var mediaFile = await DbContext.MediaFiles.FindAsync(mediaFileId);
            if (mediaFile != null)
            {
                DbContext.MediaFiles.Remove(mediaFile);
                await DbContext.SaveChangesAsync();
                // delete file from disk
                // var filePath = Path.Combine(Helper.GetUploadDirectory(mediaFile.UploadDirectory), mediaFile.FileName + mediaFile.FileExtension);
                // if (File.Exists(filePath))
                //     File.Delete(filePath);
            }
        }
    }



}
