namespace EwanHolding.Application.DTOs
{
    public class CreateTermsAndConditionsDto
    {
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
    }

    public class UpdateTermsAndConditionsDto
    {
        public int Id { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
    }

    public class TermsAndConditionsResponseDto
    {
        public int Id { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
    }
}