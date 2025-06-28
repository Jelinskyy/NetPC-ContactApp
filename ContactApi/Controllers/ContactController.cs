using ContactApi.Dtos.Contacts;
using ContactApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = await _service.CreateContactAsync(contactDto);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] UpdateContactDto contactUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactDto = await _service.UpdateContactAsync(id, contactUpdateDto);
            if (contactDto == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }

            return Ok(contactDto);
        }
    }
}