using EwanHolding.Domain.Enums;

namespace EwanHolding.Application.DTOs
{
    public class CreateAdminDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public AdminRole Role { get; set; }
    }

    public class UpdateAdminDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public AdminRole Role { get; set; }
    }

    public class AdminResponseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } 
        public AdminRole Role { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public string Token { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
