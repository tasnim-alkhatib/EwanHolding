using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Application.Services.Implementation
{
    public class StatService : IStatService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StatService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<StatResponseDto>> GetAllAsync()
        {
            var stats = await _unitOfWork.Stats.GetAllAsync();

            var stateDto =  stats.Select(stat => new StatResponseDto
            {
                Id = stat.Id,
                Label_Ar = stat.Label_Ar,
                Label_En = stat.Label_En,
                Value = stat.Value,
                DisplayOrder = stat.DisplayOrder
            });

            return stateDto;
        }

        public async Task<StatResponseDto> GetByIdAsync(int id)
        {
            var stat = await _unitOfWork.Stats.GetByIdAsync(id);
            if (stat == null) throw new Exception($"Stat with ID {id} not found.");

            var statDto = new StatResponseDto
            {
                Id = stat.Id,
                Label_Ar = stat.Label_Ar,
                Label_En = stat.Label_En,
                Value = stat.Value,
                DisplayOrder = stat.DisplayOrder
            };

            return statDto;
        }

        public async Task CreateAsync(CreateStatDto statDto)
        {
            var labelExists = await _unitOfWork.Stats.GetByLabelAsync(statDto.Label_Ar)
                ?? await _unitOfWork.Stats.GetByLabelAsync(statDto.Label_En);
            if (labelExists != null) throw new Exception("A stat with the same label already exists.");

            var displayOrderExists = await _unitOfWork.Stats.GetByDisplayOrderAsync(statDto.DisplayOrder);
            if (displayOrderExists != null) throw new Exception($"Display order {statDto.DisplayOrder} is already used.");

            var stat = new Stat
            {
                Label_Ar = statDto.Label_Ar,
                Label_En = statDto.Label_En,
                Value = statDto.Value,
                DisplayOrder = statDto.DisplayOrder
            };

            _unitOfWork.Stats.Create(stat);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateStatDto statDto)
        {
            var stat = await _unitOfWork.Stats.GetByIdAsync(statDto.Id);
            if (stat == null) throw new Exception($"Stat with ID {statDto.Id} not found.");

            var displayOrderExists = await _unitOfWork.Stats.GetByDisplayOrderAsync(statDto.DisplayOrder);
            if (displayOrderExists != null && displayOrderExists.Id != statDto.Id)
                throw new Exception($"Display order {statDto.DisplayOrder} is already used.");

            stat.Label_Ar = statDto.Label_Ar;
            stat.Label_En = statDto.Label_En;
            stat.Value = statDto.Value;
            stat.DisplayOrder = statDto.DisplayOrder;
            stat.UpdatedAt = DateTime.Now;

            _unitOfWork.Stats.Update(stat);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stat = await _unitOfWork.Stats.GetByIdAsync(id);
            if (stat == null) throw new Exception($"Stat with ID {id} not found.");

            _unitOfWork.Stats.Delete(stat);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
