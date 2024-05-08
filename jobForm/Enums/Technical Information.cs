using System.ComponentModel;

namespace jobForm.Enums
{
    public enum Technical_Information
    {
        [Description("المعلومات حول التخصص الاكاديمي ممتاز")]
        Excellent=1,
        [Description("المعلومات حول التخصص الاكاديمي جيد")]
        Good,
        [Description("المعلومات حول التخصص الاكاديمي متوسط")]
        Average,
        [Description("المعلومات حول التخصص الاكاديمي ضعيف")]
        Weak,
        [Description("لم يمارس العمل في مجال تخصصه الاكاديمي")]
        NoExperienceInField,
        [Description("يجيد العمل على برامج الحاسوب")]
        ProficientComputerSkills,
        [Description("يجيد العمل على برنامج الوورد والاكسل")]
        ProficientInWordAndExcel,
        [Description("يجيد العمل على برنامج الاكسل فقط")]
        ProficientInExcelOnly,
        [Description("يجيد العمل على برنامج الوورد فقط")]
        ProficientInWordOnly,
        [Description("يجيد قيادة العجلات الصالون")]
        SkilledInDrivingSedans,
        [Description("يجيد قيادة المعدات الثقيلة")]
        SkilledInDrivingHeavyEquipment,
        [Description("يجيد استخدام السلاح المتوسط")]
        ProficientWithMediumWeapons,
        [Description("يجيد استخدام السلاح الثقيل")]
        ProficientWithHeavyWeapons,
        [Description("المعلومات العقائدية (جيد)")]
        ReligiousKnowledgeGood,
        [Description("المعلومات العقائدية (متوسط)")]
        ReligiousKnowledgeAverage,
        [Description("المعلومات العقائدية (ضعيف)")]
        ReligiousKnowledgeWeak,
        [Description("ليس لديه معلومات عقائدية")]
        NoReligiousKnowledge,
        [Description("المظهر الخارجي لائق")]
        GoodAppearance,
        [Description("المظهر الخارجي غير لائق")]
        InappropriateAppearance,
        [Description("المظهر الخارجي غير محتشم")]
        ImmodestAppearance,
        [Description("يجيد تحدث اللغة الانكليزية")]
        FluentInEnglish,
        [Description("يجيد تحدث اللغة الفارسية")]
        FluentInPersian,
        [Description("يجيد تحدث اللغة الفرنسية")]
        FluentInFrench
    }

}
