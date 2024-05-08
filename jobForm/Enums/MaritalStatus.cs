using System.ComponentModel;

namespace jobForm.Enums
{
    public enum MaritalStatus
    {
        [Description("اعزب")]
        Single,
        [Description("عزباء")]
        SingleFemale,
        [Description("متزوج")]
        Married,
        [Description("متزوجة")]
        MarriedFemale,
        [Description("منفصل")]
        Divorced,
        [Description("منفصلة")]
        DivorcedFemale,
        [Description("ارمل")]
        Widowed,
        [Description("أرملة")]
        WidowedFemale,
        [Description("أخرى")]
        Other
    }

}
