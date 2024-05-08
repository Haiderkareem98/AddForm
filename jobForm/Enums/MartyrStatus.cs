using System.ComponentModel;

namespace jobForm.Enums
{
    public enum MartyrStatus
    {
        [Description("أخ شهيد (حشد)")]
        BrotherMartyr_Hashd,
        [Description("ابن شهيد (حشد)")]
        SonMartyr_Hashd,
        [Description("أخ شهيد (طبابة)")]
        BrotherMartyr_Medical,
        [Description("ابن شهيد (طبابة)")]
        SonMartyr_Medical,
        [Description("أخ جريح (حشد)")]
        BrotherInjured_Hashd,
        [Description("أخ جريح (طبابة)")]
        BrotherInjured_Medical,
        [Description("أخ شهيد (دفاع)")]
        BrotherMartyr_Defense,
        [Description("أخ جريح (دفاع)")]
        BrotherInjured_Defense,
        [Description("ابن شهيد (دفاع)")]
        SonMartyr_Defense,
        [Description("ابن جريح (دفاع)")]
        SonInjured_Defense,
        [Description("أخ شهيد (داخلية)")]
        BrotherMartyr_Internal,
        [Description("ابن شهيد (داخلية)")]
        SonMartyr_Internal,
        [Description("ابن شهيد (ضحايا الإرهاب)")]
        SonMartyr_Terrorism,
        [Description("أخ شهيد (ضحايا الإرهاب)")]
        BrotherMartyr_Terrorism,
        [Description("ابن شهيد (ضحايا النظام البائد)")]
        SonMartyr_FormerRegime,
        [Description("أخ شهيد (ضحايا النظام البائد)")]
        BrotherMartyr_FormerRegime
    }

}

