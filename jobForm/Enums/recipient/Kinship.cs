using System.ComponentModel;

namespace jobForm.Enums.recipient
{
    public enum Kinship
    {
        [Description("الاب")]
        FATHER =1,
        [Description("الأم")]
        MOTHER,
        [Description("الابن")]
        SON,
        [Description("الابنة")]
        DAUGHTER,
        [Description("الجد")]
        GRANDFATHER,
        [Description("الجدة")]
        GRANDMOTHER,
        [Description("العم")]
        UNCLE,
        [Description("العمة")]
        AUNT,
        [Description("الزوج او الزوجه")]
        SPOUSE
    }
}
