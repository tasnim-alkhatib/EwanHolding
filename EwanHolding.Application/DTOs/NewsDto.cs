using EwanHolding.Domain.Enums;

namespace EwanHolding.Application.DTOs
{
    public class CreateNewsDto
    {
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public NewsStatus Status { get; set; } = NewsStatus.Draft;
    }

    public class UpdateNewsDto
    {
        public int Id { get; set; }
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public DateTime PublishDate { get; set; }
        public NewsStatus Status { get; set; }
    }

    public class NewsResponseDto
    {
        public int Id { get; set; }
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        public string Description_Ar { get; set; }
        public string Description_En { get; set; }
        public DateTime PublishDate { get; set; }
        public NewsStatus Status { get; set; }
        public List<MediaResponseDto> Media { get; set; } = new();
    }
}