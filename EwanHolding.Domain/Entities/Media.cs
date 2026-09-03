using EwanHolding.Domain.Common;
using EwanHolding.Domain.Enums;

namespace EwanHolding.Domain.Entities
{
    public class Media : BaseEntity
    {
        public string Url { get; set; }
        public int EntityId { get; set; }
        public int DisplayOrder { get; set; }
        public MediaType Type { get; set;  }
        public MediaEntityType EntityType { get; set; }
    }
}
