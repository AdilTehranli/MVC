using Microsoft.AspNetCore.Mvc;
using ProniaMvc.Extentions;
using ProniaMvc.Services.Interfaces;
using ProniaMvc.ViewModels.ProductVMs;

namespace ProniaMvc.Areas.Manage.Controllers;
[Area("Manage")]
public class ProductController : Controller
{
    readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _service.GetAll(true));
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductVM vm)
    {
        if(vm.MainImageFile != null)
        {
            if (!vm.MainImageFile.IsTypeValid("image"))
            {
                ModelState.AddModelError("MainImageFile", "Wrong file type");
            }
            if (!vm.MainImageFile.IsSizeValid(2))
            {
                ModelState.AddModelError("MainImageFile", "file max size is 2 mb");
            }
        }
        if (vm.HoverImageFile != null)
        {
            if (!vm.HoverImageFile.IsTypeValid("image"))
            {
                ModelState.AddModelError("HoverImageFile", "Wrong file type");
            }
            if (!vm.HoverImageFile.IsSizeValid(2))
            {
                ModelState.AddModelError("HoverImageFile", "file max size is 2 mb");
            }       
        }
        if(vm.ImageFiles != null)
        {
            foreach (var item in vm.ImageFiles)
            {
                if (!item.IsTypeValid("image"))
                {
                    ModelState.AddModelError("ImageFiles", "Wrong file type");
                }
                if (!item.IsSizeValid(2))
                {
                    ModelState.AddModelError("ImageFiles", "file max size is 2 mb");
                }
            }
        }
        if (!ModelState.IsValid) return View();
        await _service.Create(vm);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int? id)
    {
        await _service.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> ChangeStatus(int? id)
    {
        await _service.SoftDelete(id);
        TempData["IsDeleted"] = true;
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int? id)
    {
        var result = await _service.GetById(id);
        return View(result);
    }
    [HttpPost]
    public async Task<IActionResult> Update(int? id, UpdateProductVM vM)
    {
        await _service.Update(vM);
        return RedirectToAction(nameof(Index));
    }
}
