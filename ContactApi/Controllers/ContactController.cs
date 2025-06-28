using ContactApi.Dtos.Contacts;
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }

            var contactDto = contact.ToContactGeneralDto();
            return Ok(contactDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDto contactDto)
        {
            if (contactDto == null)
            {
                return BadRequest("Contact data is required.");
            }

            var contact = contactDto.ToContact();
            contact = await _contactRepository.AddContactAsync(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact.ToContactGeneralDto());
        }
    }
}