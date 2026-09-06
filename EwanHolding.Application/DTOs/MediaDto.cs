using EwanHolding.Domain.Enums;

namespace EwanHolding.Application.DTOs
{
    public class MediaResponseDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public MediaType Type { get; set; }      // "Image" / "Video" / "Document"
        public int DisplayOrder { get; set; }
    }
}
