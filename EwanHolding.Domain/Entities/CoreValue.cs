using EwanHolding.Domain.Common;

namespace EwanHolding.Domain.Entities
{
    public class CoreValue : BaseEntity
    {
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public string IconUrl { get; set; }
        public int DisplayOrder { get; set; } 
    }
}
