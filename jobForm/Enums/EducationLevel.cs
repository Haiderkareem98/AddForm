using System.ComponentModel;

namespace jobForm.Enums
{
    public enum EducationLevel
    {
    
        [Description("أمي")]
        Illiterate= 1,
        [Description("يقرأ ويكتب")]
        Literate,
        [Description("ابتدائية")]
        Primary,
        [Description("متوسطة")]
        Intermediate,
        [Description("إعدادية")]
        Secondary,
        [Description("بكالوريوس")]
        Bachelor,
        [Description("ماجستير")]
        Master,
        [Description("دكتوراه")]
        Doctorate
    }

}

