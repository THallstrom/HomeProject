using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silicon.Factories;

namespace Silicon.Controllers
{
    public class CategoryController(DataContext dataContext) : Controller
    {
        private readonly DataContext _dataContext = dataContext;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _dataContext.Categories.OrderBy(o => o.CategoryName).ToListAsync();
            return Ok(CategoryFactory.Create(categories));
        }
    }
}
