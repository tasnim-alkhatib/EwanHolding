using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Services.Implementation
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<ServiceResponseDto>> GetAllAsync()
        {
            var services = await _unitOfWork.Services.GetAllAsync();
            
            var serviceDtos = services.Select(s => new ServiceResponseDto
            {
                Id = s.Id,
                Name_Ar = s.Name_Ar,
                Name_En = s.Name_En,
                Description_Ar = s.Description_Ar,
                Description_En = s.Description_En,
                CompanyId = s.CompanyId,
                CompanyName_Ar = s.Company.Name_Ar,
                CompanyName_En = s.Company.Name_En
            });

            return serviceDtos;
        }

        public async Task<ServiceResponseDto> GetByIdAsync(int id)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(id);
            if (service == null) throw new Exception($"Service with ID {id} not found.");

            var serviceDto = new ServiceResponseDto
            {
                Id = service.Id,
                Name_Ar = service.Name_Ar,
                Name_En = service.Name_En,
                Description_Ar = service.Description_Ar,
                Description_En = service.Description_En,
                CompanyId = service.CompanyId,
                CompanyName_Ar = service.Company.Name_Ar,
                CompanyName_En = service.Company.Name_En
            };

            return serviceDto;
        }

        public async Task CreateAsync(CreateServiceDto serviceDto)
        {
            var nameEnExists = await _unitOfWork.Services.GetByNameAsync(serviceDto.Name_En);
            if (nameEnExists != null) throw new Exception($"Service with name {serviceDto.Name_En} already exists.");

            var nameArExists = await _unitOfWork.Services.GetByNameAsync(serviceDto.Name_Ar);
            if (nameArExists != null) throw new Exception($"Service with name {serviceDto.Name_Ar} already exists.");

            var service = new Service
            {
                Name_Ar = serviceDto.Name_Ar,
                Name_En = serviceDto.Name_En,
                Description_Ar = serviceDto.Description_Ar,
                Description_En = serviceDto.Description_En,
                CompanyId = serviceDto.CompanyId,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Services.Create(service);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateServiceDto serviceDto)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(serviceDto.Id);
            if (service == null) throw new Exception($"Service with ID {serviceDto.Id} not found.");

            service.Name_Ar = serviceDto.Name_Ar;
            service.Name_En = serviceDto.Name_En;
            service.Description_Ar = serviceDto.Description_Ar;
            service.Description_En = serviceDto.Description_En;
            service.CompanyId = serviceDto.CompanyId;
            service.CreatedAt = DateTime.UtcNow;

            _unitOfWork.Services.Update(service);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(id);
            if (service == null) throw new Exception($"Service with ID {id} not found.");

            _unitOfWork.Services.Delete(service);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}