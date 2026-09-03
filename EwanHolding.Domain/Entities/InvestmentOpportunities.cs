using EwanHolding.Domain.Common;
using EwanHolding.Domain.Enums;

namespace EwanHolding.Domain.Entities
{
    public class InvestmentOpportunities : BaseEntity
    {
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }

        public int CompanyId { get; set; }
        public InvestmentStatus Status { get; set; }
    }
}
