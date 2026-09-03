using EwanHolding.Domain.Common;

namespace EwanHolding.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public string WebsiteUrl { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
