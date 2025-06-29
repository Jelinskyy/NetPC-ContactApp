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
                return NotFound($"Nie ma kontaktu o ID {id}.");
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

            try
            {
                var contact = await _service.CreateContactAsync(contactDto);
                return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] UpdateContactDto contactUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var contactDto = await _service.UpdateContactAsync(id, contactUpdateDto);
                if (contactDto == null)
                {
                    return NotFound($"Nie ma kontaktu o ID {id}.");
                }

                return Ok(contactDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}