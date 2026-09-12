namespace EwanHolding.Application.DTOs
{
    public class CreatePageContentDto
    {
        public string Key { get; set; }
        public string Value_Ar { get; set; }
        public string Value_En { get; set; }
        public string PageName { get; set; }
    }

    public class UpdatePageContentDto
    {
        public int Id { get; set; }
        public string Value_Ar { get; set; }
        public string Value_En { get; set; }
    }

    public class PageContentResponseDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value_Ar { get; set; }
        public string Value_En { get; set; }
        public string PageName { get; set; }
    }
}