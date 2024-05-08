using jobForm.Enums.Final_Infomation;

namespace jobForm.Models.Entities
{
    public class Final_Infomation 
    {
        public int? Id { get; set; }
        public double? Weight { get; set; } // الوزن
        public double? Height { get; set; } // الطول
        public BloodType? BloodType { get; set; } // فصيلة الدم
        public string? MotherName { get; set; } // اسم الأم
        public string? MaternalGrandfatherName { get; set; } // اسم جد الأم
        public string? MaternalGrandmotherName { get; set; } // اسم جدة الأم
        public string? MaternalGrandfatherFatherName { get; set; } // اسم أب جد الأم

        //Relationship
        public Beneficiary? beneficiary { get; set; }

        public HusbandOrWifeModel? husbandOrWifeModel { get; set; }
        public ReferenceInfo? referenceInfo { get; set; }

        public  IdentityInformation? identityInformation { get; set; }

    }
}
