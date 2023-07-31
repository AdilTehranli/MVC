using ProniaMvc.Models;
using ProniaMvc.ViewModels.ProductVMs;
using ProniaMvc.ViewModels.SliderVMs;

namespace ProniaMvc.Services.Interfaces;

public interface IProductService
{
    public Task<List<Product>> GetAll(bool takeAll);
    public Task<Product> GetById(int? id);
    Task Create(CreateProductVM productVM);
    Task Update(UpdateProductVM productVM);
    Task Delete(int? id);
    Task SoftDelete(int? id);
    IQueryable<Product> GetTable { get; }
}
