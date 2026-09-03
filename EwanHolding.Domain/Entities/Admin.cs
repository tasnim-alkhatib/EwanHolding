using EwanHolding.Domain.Common;
using EwanHolding.Domain.Enums;

namespace EwanHolding.Domain.Entities
{
    public class Admin : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; } = true;
        public AdminRole Role { get; set; }
        public DateTime? LastLoginAt { get; set; } 
    }
}
