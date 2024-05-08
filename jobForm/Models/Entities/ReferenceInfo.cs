using System.ComponentModel;

namespace jobForm.Models.Entities
{
    public class ReferenceInfo
    {
        public int Id { get; set; }

        [Description("اسم المعرف الأول")]
        public string? FirstReferenceName { get; set; }

        [Description("العنوان الوظيفي للمعرف الأول")]
        public string? FirstReferenceJobTitle { get; set; }

        [Description("عنوان سكن المعرف الأول")]
        public string? FirstReferenceAddress { get; set; }

        [Description("هاتف المعرف الأول")]
        public string? FirstReferencePhone { get; set; }

        [Description("الحالة الفعلية للمعرف الأول")]
        public string? FirstReferenceStatus { get; set; }

        [Description("تاريخ الحالة")]
        public DateTime? FirstReferenceStatusDate { get; set; }

        [Description("ملاحظة")]
        public string FirstReferenceNote { get; set; }

        [Description("اسم المعرف الثاني")]
        public string? SecondReferenceName { get; set; }

        [Description("العنوان الوظيفي للمعرف الثاني")]
        public string? SecondReferenceJobTitle { get; set; }

        [Description("عنوان سكن المعرف الثاني")]
        public string? SecondReferenceAddress { get; set; }

        [Description("هاتف المعرف الثاني")]
        public string? SecondReferencePhone { get; set; }

        [Description("الحالة الفعلية للمعرف الثاني")]
        public string? SecondReferenceStatus { get; set; }

        [Description("تاريخ الحالة للمعرف الثاني")]
        public DateTime? SecondReferenceStatusDate { get; set; }

        [Description("ملاحظة")]
        public string Note { get; set; }
        public int Final_InfomationId { get; set; }
        public Final_Infomation final_Infomation { get; set; }
    }
}
