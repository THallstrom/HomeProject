using Data.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SubWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpPost]
        public async Task<IActionResult> Get(SubRegistrationForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _context.SubEntities.FirstOrDefaultAsync(x => x.Email == form.Email);
                if (result == null)
                {
                    var entity = SubFactory.Create(form);
                    _context.SubEntities.Add(entity);
                    await _context.SaveChangesAsync();
                    return Ok();
                } 
                return Conflict();

            }
            return BadRequest();
        }
    }
}
