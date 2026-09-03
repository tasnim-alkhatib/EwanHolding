using EwanHolding.Domain.Common;

namespace EwanHolding.Domain.Entities
{
    public class Terms : BaseEntity
    {
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
    }
}
