using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.DTOs;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace EwanHolding.Application.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
             
            admin.LastLoginAt = DateTime.UtcNow;
            
            _unitOfWork.Admins.Update(admin);
            await _unitOfWork.SaveChangesAsync();

            // jwt token generation logic should be implemented here
            // For now, we will return the admin details without a token

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
    }
}
