using EwanHolding.Domain.Enums;

namespace EwanHolding.Application.DTOs
{
    public class CreateMediaDto
    {
        public string Url { get; set; }
        public int EntityId { get; set; }
        public MediaEntityType EntityType { get; set; }
        public MediaType Type { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class MediaResponseDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public MediaEntityType EntityType { get; set; }
        public MediaType Type { get; set; }
        public int DisplayOrder { get; set; }
    }
}