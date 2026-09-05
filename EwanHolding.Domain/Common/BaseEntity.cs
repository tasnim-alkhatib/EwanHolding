namespace EwanHolding.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? CreatedByUserId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UpdatedByUserId { get; set; }
    }
}
