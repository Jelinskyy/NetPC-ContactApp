using ContactApi.Dtos.Contacts;
using ContactApi.Interfaces;
using ContactApi.Mappers;
using ContactApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly ContactService _service;

        public ContactController(IContactRepository contactRepository, ContactService service)
        {
            _service = service;
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {   
            var contactsDtos = await _service.GetAllContactsAsync();
            return Ok(contactsDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contactDto = await _service.GetContactByIdAsync(id);
            if (contactDto == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }

            return Ok(contactDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDto contactDto)
        {
            if (contactDto == null)
            {
                return BadRequest("Contact data is required.");
            }
            
            var contact = await _service.CreateContactAsync(contactDto);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }
    }
}