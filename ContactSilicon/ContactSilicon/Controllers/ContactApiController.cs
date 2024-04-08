using Data.Context;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                var result = await _context.Contacts.FirstOrDefaultAsync(x => x.Email == form.Email);
                if (result == null)
                {
                    var entity = ContactFactory.Contact(form);
                    _context.Contacts.Add(entity);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return Conflict();

            }
            return BadRequest();
        }
    }
}
