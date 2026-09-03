using EwanHolding.Domain.Common;

namespace EwanHolding.Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }

        public int CompanyId { get; set; }
    }
}
