using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProniaMvc.Services.Interfaces;
using ProniaMvc.ViewModels.HomeVMs;

namespace P137Pronia.Controllers;

public class HomeController : Controller
{
    private readonly ISliderService _sliderService;
    private readonly IProductService _productService;

    public HomeController(IProductService productService,
       ISliderService sliderService)
    {
        _productService = productService;
        _sliderService = sliderService;
    }

    public async Task<IActionResult> Index()
    {
        HomeVm vm = new HomeVm
        {
            Sliders = await _sliderService.GetAll(),
            Products = await _productService.GetTable.Take(4).ToListAsync()
        };
        ViewBag.ProductCount = await _productService.GetTable.CountAsync();
        return View(vm);
    }
    public async Task<IActionResult> LoadMore(int skip, int take)
    {
        return PartialView("_ProductPartial", await _productService.GetTable.Skip(skip).Take(take).ToListAsync());
    }
}