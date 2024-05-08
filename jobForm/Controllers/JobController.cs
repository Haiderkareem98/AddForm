using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jobForm.Db;
using jobForm.Mappings;
using jobForm.Models.Dto.Global;
using jobForm.Models.Entities;
using TatweerSwissTool.Db;
using jobForm.Models.Dto.Form.User;
using jobForm.Models.Form.Global;
using jobForm.Models.Dto.Form;
using jobForm.Enums;
using jobForm.Filters;
using System.Linq;
using System.Text.RegularExpressions;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using Newtonsoft.Json;

namespace jobForm.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class JobController(IServiceProvider serviceProvider) : BaseController(serviceProvider)
{
    [HttpPost]
    public async Task<ActionResult<GlobalResponse<string>>> AddJob([FromForm] JobForm form , string captchaToken)
    {
          if (CheckVal(form) != "done")
          return BadRequest(new GlobalResponse<Job>(null, CheckVal(form)));

        bool isCaptchaValid = await VerifyCaptchaToken(captchaToken);
        if (!isCaptchaValid)
            return BadRequest(new GlobalResponse<string>(null, "reCAPTCHA validation failed."));

        var listOfMartyrStatus = form.MartyrStatus!.ToList();
        var listOfTechnicalInformation = form.MechnicalInformation!.ToList();

        var job = Mapper.Map<Job>(form);

        job.MartyrStatus = listOfMartyrStatus;
        job.MechnicalInformation = listOfTechnicalInformation;
        var randomCode = RandomCodeGenerator(10);
        job.RandomCode = randomCode;
       

        var photo = await UploadService.UploadFileAsync(form.Photo! , UploadDirectory.Job);

        job.MediaFileId = photo.Id;
        DbContext.Job.Add(job);
        await DbContext.SaveChangesAsync();

        return Ok(new GlobalResponse<string>(randomCode, "successful"));
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<PaginationResponse<Job>>> GetJobs([FromQuery] JobFilter filter,
                                                                 [FromQuery] Pagination pagination)
    {
        try
        {
            var jobs = DbContext.Job.Include(x=> x.MediaFile).AsQueryable();

            if (!string.IsNullOrEmpty(filter.fullName))
            {
                var fullName = filter.fullName; // Convert to lower case for case-insensitive search
                jobs = jobs.Where(x =>
                    x.FirstName!.Contains(fullName) ||
                    x.SecondName!.Contains(fullName) ||
                    x.ThirdName!.Contains(fullName) ||
                    x.Fourth_Name!.Contains(fullName) ||
                    x.Surname!.Contains(fullName)
                );
            }

            if (!string.IsNullOrEmpty(filter.phoneNumber))
                jobs = jobs.Where(x => x.Phone!.Contains(filter.phoneNumber));

            if (filter.birthYaer != null)
                jobs = jobs.Where(x => x.BirthYaer == filter.birthYaer);

            if (filter.isFamiliesMartyrsAndWounded.HasValue)
                jobs = jobs.Where(x => x.IsFamiliesMartyrsAndWounded == filter.isFamiliesMartyrsAndWounded);

            if (!string.IsNullOrEmpty(filter.randomCode))
                jobs = jobs.Where(x => x.RandomCode == filter.randomCode);

            return Ok(await jobs.PaginatedListAsync(pagination));
        }
        catch (Exception e)
        {
            return BadRequest(new GlobalResponseEmpty(e.Message, true));
        }
    }

    [HttpGet]
    public async Task<ActionResult<GlobalResponse<Job>>> CheckForm(string randomCode , string captchaToken)
    {
        try
        {
            bool isCaptchaValid = await VerifyCaptchaToken(captchaToken);
            if (!isCaptchaValid)
                return BadRequest(new GlobalResponse<string>(null, "reCAPTCHA validation failed."));


            var job = await DbContext.Job.FirstOrDefaultAsync(x => x.RandomCode == randomCode);

            if (job == null)
                return BadRequest(new GlobalResponseEmpty("Form not found", true));

            return Ok(new GlobalResponse<Job>(job, "Form found successfully"));
        }
        catch (Exception e)
        {
            return BadRequest(new GlobalResponseEmpty(e.Message, true));
        }
    }



    private static string CheckVal(JobForm form)
    {
        var arabicPattern = @"\p{IsArabic}";
        var birthYearPattern = @"^\d{4}$";

        if (!Regex.IsMatch(form.Phone!, @"^(75|79|78|77)\d{8}$"))
        {
            return "يجب أن يبدأ رقم الهاتف بـ 75، 79، 78، أو 77 ويجب أن يتكون من 10 أرقام.";
        }

        bool IsValidArabic(string input) => Regex.IsMatch(input, arabicPattern);

        if (!IsValidArabic(form.FirstName!) ||
            !IsValidArabic(form.SecondName!) ||
            !IsValidArabic(form.ThirdName!) ||
            !IsValidArabic(form.Fourth_Name!) ||
            !IsValidArabic(form.Surname!))
        {
            return "الاسم يجب ان يكون عربي";
        }

        if (!Regex.IsMatch(form.BirthYaer!, birthYearPattern))
        {
            return "السنة الصحيحة للميلاد يجب أن تكون رقماً مكوناً من أربعة أرقام.";
        }

        return "done";
    }
    private static string RandomCodeGenerator(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }



    private static async Task<bool> VerifyCaptchaToken(string token)
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret=6LeGj7QpAAAAAHgKwToi2NqTdGGijj69uHulcoHF&response={token}");
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var captchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(responseBody);
                return captchaResponse!.Success;
            }
            return false;
        }
    }
    public class ReCaptchaResponse
    {
        public bool Success { get; set; }
    }

}