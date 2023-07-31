using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMvc.DataAccess;
using ProniaMvc.Services.Interfaces;
using ProniaMvc.ViewModels.HomeVMs;

namespace ProniaMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;

        private readonly IProductService _productService;
        public HomeController(ISliderService sliderService, IProductService productService)
        {
            _sliderService = sliderService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVm vm = new HomeVm
            {
                Sliders = await _sliderService.GetAll(),
                Products = await _productService.GetAll(false)
            };
            return View(vm);
        }
    }
}
