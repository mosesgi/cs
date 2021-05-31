using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Packt.Shared;

namespace NorthwindMvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private Northwind db;

        public CategoryController(ILogger<CategoryController> logger, Northwind dbContext)
        {
            _logger = logger;
            db = dbContext;
        }

        [Route("category/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            Category category = await db.Categories.Include(c => c.Products).SingleOrDefaultAsync(c => c.CategoryID==id);
            if (category == null)
            {
                return NotFound($"Category with ID of {id} not found");
            }
            return View(category);
        }
    }
}