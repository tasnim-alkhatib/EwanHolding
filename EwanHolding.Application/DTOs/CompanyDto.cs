
namespace EwanHolding.Application.DTOs
{
    public class CreateCompanyDto
    {
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public string WebsiteUrl { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class UpdateCompanyDto
    {
        public int Id { get; set; }
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public string WebsiteUrl { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class CompanyResponseDto
    {
        public int Id { get; set; }
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public string WebsiteUrl { get; set; }
        public string LogoUrl { get; set; }
        //public List<MediaResponseDto> Media { get; set; }
    }
}
