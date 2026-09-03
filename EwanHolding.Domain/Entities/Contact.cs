using EwanHolding.Domain.Common;
using EwanHolding.Domain.Enums;

namespace EwanHolding.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; } = string.Empty;
        public ContactStatus Status { get; set; } = ContactStatus.Unread;
    }
}
