using Microsoft.AspNetCore.Mvc;

namespace MVCPronia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
