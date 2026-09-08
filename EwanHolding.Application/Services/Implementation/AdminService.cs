using System.Security.Claims;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using EwanHolding.Application.DTOs;

namespace EwanHolding.Application.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public AdminService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<IEnumerable<AdminResponseDto>> GetAllAsync()
        {
            var admins = await _unitOfWork.Admins.GetAllAsync();

            var adminDtos = admins.Select(admin => new AdminResponseDto
            {
                Id = admin.Id,
                FullName = admin.FullName,
                Email = admin.Email,
                IsActive = admin.IsActive,
                Role = admin.Role,
                LastLoginAt = admin.LastLoginAt
            });

            return adminDtos;
        }

        public async Task<AdminResponseDto> GetByIdAsync(int id)
        {
            var admin = await _unitOfWork.Admins.GetByIdAsync(id);
            if (admin == null) throw new Exception($"Admin with ID {id} not found.");

            var adminDto = new AdminResponseDto
            {
                Id = admin.Id,
                FullName = admin.FullName,
                Email = admin.Email,
                IsActive = admin.IsActive,
                Role = admin.Role,
                LastLoginAt = admin.LastLoginAt
            };

            return adminDto;
        }

        public async Task CreateAsync(CreateAdminDto adminRequestDto)
        {
            var emailExists = await _unitOfWork.Admins.GetByEmailAsync(adminRequestDto.Email);
            if (emailExists != null) throw new Exception($"Admin with email {adminRequestDto.Email} already exists.");

            var newAdmin = new Admin
            {
                FullName = adminRequestDto.FullName,
                Email = adminRequestDto.Email,
                IsActive = true,
                Role = adminRequestDto.Role
            };

            newAdmin.PasswordHash = new PasswordHasher<Admin>().HashPassword(newAdmin, adminRequestDto.Password);

            _unitOfWork.Admins.Create(newAdmin);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateAdminDto adminRequestDto)
        {
            var admin = await _unitOfWork.Admins.GetByIdAsync(adminRequestDto.Id);
            if (admin == null) throw new Exception($"Admin with ID {adminRequestDto.Id} not found.");

            admin.FullName = adminRequestDto.FullName;
            admin.Email = adminRequestDto.Email;
            admin.IsActive = adminRequestDto.IsActive;
            admin.Role = adminRequestDto.Role;
            admin.UpdatedAt = DateTime.Now;

            _unitOfWork.Admins.Update(admin);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var admin = await _unitOfWork.Admins.GetByIdAsync(id);
            if (admin == null) throw new Exception($"Admin with ID {id} not found.");

            _unitOfWork.Admins.Delete(admin);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<AdminResponseDto> LoginAsync(LoginDto loginDto)
        {
            var admin = await _unitOfWork.Admins.GetByEmailAsync(loginDto.Email);
            if (admin == null) throw new Exception("Invalid credentials.");

            var isPasswordValid = new PasswordHasher<Admin>().VerifyHashedPassword(admin, admin.PasswordHash, loginDto.Password) == PasswordVerificationResult.Success;
            if (!isPasswordValid) throw new Exception("Invalid credentials.");

            admin.LastLoginAt = DateTime.Now;

            _unitOfWork.Admins.Update(admin);
            await _unitOfWork.SaveChangesAsync();

            var token = CreateToken(admin);

            var adminDto = new AdminResponseDto
            {
                Id = admin.Id,
                FullName = admin.FullName,
                Email = admin.Email,
                IsActive = admin.IsActive,
                Role = admin.Role,
                LastLoginAt = admin.LastLoginAt,
                Token = token
            };

            return adminDto;
        }

        public async Task ChangePasswordAsync(int id, ChangePasswordDto passwordDto)
        {
            var admin = await _unitOfWork.Admins.GetByIdAsync(id);
            if (admin == null) throw new Exception($"The Admin with Id : {id} not found");

            var isOldPasswordTrue = 
                new PasswordHasher<Admin>().VerifyHashedPassword(admin, admin.PasswordHash, passwordDto.OldPassword) == PasswordVerificationResult.Success;
            if (!isOldPasswordTrue) throw new Exception($"Old password incorrect");

            if(passwordDto.OldPassword == passwordDto.NewPassword) throw new Exception($"New password cannot be the same as the old password");

            admin.PasswordHash = new PasswordHasher<Admin>().HashPassword(admin, passwordDto.NewPassword);

            _unitOfWork.Admins.Update(admin);
            await _unitOfWork.SaveChangesAsync();
        }

        private string CreateToken(Admin admin)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Name, admin.FullName),
                new Claim(ClaimTypes.Email, admin.Email),
                new Claim(ClaimTypes.Role, admin.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
