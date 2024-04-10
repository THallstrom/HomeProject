using Data.Context;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactSilicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactApiController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpPost]
        public async Task<IActionResult> Get(ContactForm form)
        {
            if (ModelState.IsValid)
            {
                var entity = ContactFactory.Contact(form);
                _context.Contacts.Add(entity);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
