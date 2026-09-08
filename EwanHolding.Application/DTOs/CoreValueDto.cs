namespace EwanHolding.Application.DTOs
{
    public class CreateCoreValueDto
    {
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public string IconUrl { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class UpdateCoreValueDto
    {
        public int Id { get; set; }
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public string IconUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
    public class CoreValueResponseDto
    {
        public int Id { get; set; }
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public string IconUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}
