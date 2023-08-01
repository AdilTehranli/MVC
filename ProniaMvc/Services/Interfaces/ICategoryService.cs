using MVCPronia.Models;
using ProniaMvc.Models;
using ProniaMvc.ViewModels.SliderVMs;

namespace MVCPronia.Services.Interfaces;

public interface ICategoryService
{
    Task Create(string name);
    Task Update(int id,string name);
    Task Delete(int? id);
    Task<ICollection<Category>> GetAll();
    Task<Category> GetById(int? id);
}
