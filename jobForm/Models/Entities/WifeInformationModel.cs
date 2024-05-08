namespace jobForm.Models.Entities
{
    public class HusbandOrWifeModel
    {
        public int Id { get; set; }
        public string HusbandOrWifeFulllName { get; set; }// اسم الزوج او الزوجه الكامل
        public string HusbandOrWifeModelFirstName { get; set; }// اسم الزوج او الزوجه الاول
        public string HusbandOrWifeModelSecondName { get; set; }// اسم الزوج او الزوجه الثاني
        public string HusbandOrWifeModelThirdName { get; set; } // اسم الزوج او الزوجه الثالث
        public int NumberOfBoys { get; set; } // عدد الأطفال الذكور
        public int NumberOfGirls { get; set; } // عدد الأطفال الإناث
        public string PhoneNumber { get; set; } // رقم الهاتف
        public string EducationLevel { get; set; } // التحصيل الدراسي
        public string FieldOfStudy { get; set; } // التخصص الدراسي
        public string Occupation { get; set; } // العمل 
        public string Nationality { get; set; } // الجنسية
        public string Religion { get; set; } // الديانة
        public string Sect { get; set; } // المذهب
        public string Notes { get; set; } // الملاحظات

        public int Final_InfomationId { get; set; }
        public Final_Infomation final_Infomation { get; set; }
    }
}
