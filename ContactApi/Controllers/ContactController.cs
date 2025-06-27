using ContactApi.Interfaces;
using ContactApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _contactRepository.GetAllContactsAsync();
            if (contacts == null || !contacts.Any())
            {
                return NotFound("No contacts found.");
            }
            
            var contactDtos = contacts.Select(c => c.ToContactGeneralDto()).ToList();
            
            return Ok(contacts);
        }
    }
}