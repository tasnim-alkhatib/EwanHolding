using EwanHolding.Domain.Enums;

namespace EwanHolding.Application.DTOs
{
    public class CreateInvestmentOpportunitiesDto
    {
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }

        public int CompanyId { get; set; }
        public InvestmentStatus Status { get; set; }
    }

    public class UpdateInvestmentOpportunitiesDto
    {
        public int Id { get; set; }
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }

        public int CompanyId { get; set; }
        public InvestmentStatus Status { get; set; }
    }

    public class InvestmentOpportunitiesResponseDto
    {
        public int Id { get; set; }
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName_Ar { get; set; }
        public string CompanyName_En { get; set; }
        public InvestmentStatus Status { get; set; }
    }
}
