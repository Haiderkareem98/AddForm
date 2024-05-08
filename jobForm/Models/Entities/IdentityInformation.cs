using System.ComponentModel;

namespace jobForm.Models.Entities
{
    public class IdentityInformation
    {
        [Description("رقم بطاقة السكن")]
        public int ResidenceCardNumber { get; set; }
        [Description("تاريخ اصدار بطاقة السكن")]
        public DateTime ResidenceReleaseDate { get; set; }
        [Description("جهة اصدار بطاقة السكن")]
        public string ResidenceResidence { get; set; }

        [Description("رقم البطاقة الوطنية")]
        public int NationalCardNumber { get; set; }
        [Description("رمز البطاقة الوطنية")]
        public string NationalCardPassword { get; set; }
        [Description("مكان الاصدار")]
        public string PlaceOfissue { get; set; }
        [Description("تاريخ الاصدار")]
        public DateTime ReleaseDate { get; set; }
        [Description("رقم السجل")]
        public int RegisterNumber { get; set; }
        [Description("رقم البطاقة التموينية")]
        public string RationCardNumber { get; set; }
        [Description("رقم مركز التموين")]
        public string SupplyCenterNumber { get; set; }
        [Description("اسم مركز التموين")]
        public string SupplyCenterName { get; set; }
        [Description("تاريخ اصدار التموينية")]
        public DateTime RationReleaseDate { get; set; }
        [Description("تاريخ اصدار التموينية")]
        public string Governorate { get; set; } // المحافظة
        public string Judiciary { get; set; } // القضاء
        public string District { get; set; } // الناحية
        public string Area { get; set; } // المنطقة
        public string Locality { get; set; } // المحلة
        public string Alley { get; set; } // الزقاق
        public string House { get; set; } // الدار
        public string NearestLandmark { get; set; } // أقرب نقطة دالة

        public int Final_InfomationId { get; set; }
        public Final_Infomation final_Infomation { get; set; }


    }
}
