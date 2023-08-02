using Microsoft.AspNetCore.Mvc;
using MVCPronia.Services.Interfaces;

namespace MVCPronia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        public async Task<IActionResult>  Index()
        {
            return View(await _category.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public async  Task<IActionResult> Update(string name) {
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)) return BadRequest();
            await _category.Create(name);
             return View();
        }
    }
}
