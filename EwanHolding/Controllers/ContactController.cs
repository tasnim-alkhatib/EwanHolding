using EwanHolding.Application.DTOs;
using EwanHolding.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EwanHolding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService) => _contactService = contactService;

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto dto)
        {
            await _contactService.CreateAsync(dto);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactService.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            return Ok(contact);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> UpdateStatus(int id, UpdateContactStatusDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch.");
            await _contactService.UpdateStatusAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin,ContentManager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteAsync(id);
            return Ok();
        }
    }
}