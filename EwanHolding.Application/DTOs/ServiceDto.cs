namespace EwanHolding.Application.DTOs
{
    public class CreateServiceDto 
    {
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public int CompanyId { get; set; }
    }

    public class UpdateServiceDto
    {
        public int Id { get; set; }
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public int CompanyId { get; set; }
    }

    public class ServiceResponseDto
    {
        public int Id { get; set; }
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName_Ar { get; set; }
        public string CompanyName_En { get; set; }
    }
}
