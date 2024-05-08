using jobForm.Enums;
using jobForm.Mappings;
using jobForm.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace jobForm.Models.Dto.Form
{
    public class JobForm
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? SecondName { get; set; }
        [Required]
        public string? ThirdName { get; set; }
        [Required]

        public string? Fourth_Name { get; set; }
        [Required]

        public string? Surname { get; set; }
        [Required]

        public string? Phone { get; set; }
        [Required]

        public EducationLevel EducationLevel { get; set; }
        [Required]

        public string? ScientificSpecialization { get; set; }
        [Required]

        public Conservation Conservation { get; set; }
        [Required]

        public string? BirthYaer { get; set; }
        [Required]

        public MaritalStatus MaritalStatus { get; set; }
        [Required]

        public string? IdentifieName { get; set; }
        [Required]

        public string? IdentifieWorkPlace { get; set; }
        [Required]

        public string? Sessions { get; set; }
        [Required]

        public string? WorkplacesExperience { get; set; }
        [Required]

        public string? Notes { get; set; }
        [Required]

        public bool IsFamiliesMartyrsAndWounded { get; set; }

        [IgnoreMapper]
        public List<MartyrStatus>? MartyrStatus { get; set; }
        [IgnoreMapper]
        public List<Technical_Information>? MechnicalInformation { get; set; }
        [Required]

        public string? ProposedAddition { get; set; }
        [Required]

        public string? CommunityCovenant { get; set; }
        [Required]

        public int DegreeOfConfrontation { get; set; }
        [Required]

        public InterviewPurpose InterviewPurpose { get; set; }
        [Required]

        public IFormFile? Photo { get; set; }
    }
}
