using EwanHolding.Domain.Common;
using EwanHolding.Domain.Enums;

namespace EwanHolding.Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public NewsStatus Status { get; set; } = NewsStatus.Draft;
    }
}
