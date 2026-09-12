using EwanHolding.Domain.Enums;

namespace EwanHolding.Application.DTOs
{
    public class CreateContactDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

    public class UpdateContactStatusDto
    {
        public int Id { get; set; }
        public ContactStatus Status { get; set; }
    }

    public class ContactResponseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public ContactStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}