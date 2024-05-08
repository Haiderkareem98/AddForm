namespace TatweerSwissTool.Common;

public static class ConvertPhoneNumber
{
    public static Func<string, string> ToPlus964 = phone =>
        phone.Length == 15 ? "+" + phone[2..] :
        phone.Length == 10 ? "+964" + phone :
        phone.Length == 11 ? "+964" + phone[1..] : phone; //14

    public static Func<string, string> To00964 = phone =>
        phone.Length == 14 ? "00" + phone[1..] :
        phone.Length == 10 ? "00964" + phone :
        phone.Length == 11 ? "00964" + phone[1..] : phone; //15

    public static Func<string, string> To964 = phone => phone.Length == 14 ? phone[1..] :
        phone.Length == 10 ? "964" + phone :
        phone.Length == 11 ? "964" + phone[1..] : phone;

    public static Func<string, string> To07 = phone =>
        phone.Length == 15 ? "0" + phone[5..] :
        phone.Length == 14 ? "0" + phone[4..] :
        phone.Length == 10 ? "0" + phone[1..] : phone; //11

    public static Func<string, string> To7 = phone => phone.Length == 15 ? phone[5..] :
        phone.Length == 14 ? phone[4..] :
        phone.Length == 11 ? phone[1..] : phone; //10
}