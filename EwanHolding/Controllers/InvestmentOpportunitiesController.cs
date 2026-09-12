using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Implementation;
using EwanHolding.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "SuperAdmin,ContentManager")]

    public class InvestmentOpportunitiesController : ControllerBase
    {
        private readonly InvestmentOpportunitiesService _investmentOpportunitiesService;
        public InvestmentOpportunitiesController(InvestmentOpportunitiesService investmentOpportunitiesService) => _investmentOpportunitiesService = investmentOpportunitiesService;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var investments = await _investmentOpportunitiesService.GetAllAsync();
            return Ok(investments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var investment = await _investmentOpportunitiesService.GetByIdAsync(id);
            return Ok(investment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateInvestmentOpportunitiesDto dto)
        {
            await _investmentOpportunitiesService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateInvestmentOpportunitiesDto dto)
        {
            if (id != dto.Id) return BadRequest("Id mismatch.");

            await _investmentOpportunitiesService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _investmentOpportunitiesService.DeleteAsync(id);
            return Ok();
        }
    }
}
