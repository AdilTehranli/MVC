using ProniaMvc.Models;
using ProniaMvc.ViewModels.ProductVMs;

namespace ProniaMvc.Services.Interfaces;

public interface IProductService
{
    IQueryable<Product> GetTable { get; }
    public Task<List<Product>> GetAll(bool takeAll);
    public Task<Product> GetById(int? id, bool takeAll = false);
    Task Create(CreateProductVM productVM);
    Task Update(int? id, UpdateProductVM productVM);
    Task Delete(int? id);
    Task SoftDelete(int? id);
    Task DeleteImage(int? id);
}
