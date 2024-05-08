using jobForm.Common;
using jobForm.Enums;
using jobForm.Mappings;
using jobForm.Models.Dto.Form;
using System.ComponentModel.DataAnnotations;

namespace jobForm.Models.Entities
{
    public class Job : FullAuditableEntity, IMapFrom<JobForm>
    {

        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string? Fourth_Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string? ScientificSpecialization { get; set; }
        public Conservation Conservation { get; set; }
        public string? BirthYaer {  get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string? IdentifieName {  get; set; } 
        public string? IdentifieWorkPlace {  get; set; }
        public string? Sessions { get; set; }   
        public string? WorkplacesExperience {  get; set; }
        public string? Notes { get; set; }
        public bool IsFamiliesMartyrsAndWounded {  get; set; }
        [IgnoreMapper]
        public List<MartyrStatus>? MartyrStatus { get; set; }
        [IgnoreMapper]
        public List<Technical_Information>? MechnicalInformation { get; set; }
        public string? ProposedAddition { get; set;}
        public string? CommunityCovenant {  get; set; }
        public int DegreeOfConfrontation { get; set; }
        public InterviewPurpose InterviewPurpose { get; set; }
        public Guid MediaFileId {  get; set; }
        public MediaFile? MediaFile { get; set; }
        public string? RandomCode { get; set; }


    }
}
