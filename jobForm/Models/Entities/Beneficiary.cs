using jobForm.Enums.recipient;

namespace jobForm.Models.Entities
{
    // المستفيد
    public class Beneficiary
    {
      public int Id {  get; set; }

        public string BeneficiaryName { get; set; }//اسم المستفيد
        public int BirthYear { get; set; }// سنه الولاده 

        public string BeneficiaryMotherName { get; set; }//اسم ام المستفيد

        public Gender gender { get; set; }// اينم الجنس 

        public  Kinship kinship { get; set; } // اينم بصلة القرابه

        public string NationalID { get; set; } // رقم البطاقه الوطنيه
        public string IssuingAuthority { get; set; } // جهة الإصدار
        public DateTime IssueDate { get; set; } // تاريخ الإصدار
        public string Occupation { get; set; } // العمل
        public string MaritalStatus { get; set; } // الحالة الزوجية
        public int NumberOfBoys { get; set; } // عدد الأطفال الذكور
        public int NumberOfGirls { get; set; } // عدد الأطفال الإناث
        public string HousingType { get; set; } // نوع السكن
        public string Governorate { get; set; } // المحافظة
        public string Judiciary { get; set; } // القضاء
        public string District { get; set; } // الناحية
        public string Area { get; set; } // المنطقة
        public string Locality { get; set; } // المحلة
        public string Alley { get; set; } // الزقاق
        public string House { get; set; } // الدار
        public string NearestLandmark { get; set; } // أقرب نقطة دالة
        public string PhoneNumber { get; set; } // رقم الهاتف
       
        public int Final_InfomationId { get; set; }
        public Final_Infomation final_Infomation { get; set; }




    }
}
