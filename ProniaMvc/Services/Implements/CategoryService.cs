using Microsoft.EntityFrameworkCore;
using MVCPronia.Models;
using MVCPronia.Services.Interfaces;
using ProniaMvc.DataAccess;
using ProniaMvc.Models;
using ProniaMvc.Services.Interfaces;

namespace MVCPronia.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        readonly ProniaDbContext _dbContext;

        public CategoryService(ProniaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Product> GetTable { get => _dbContext.Set<Product>(); }

        IQueryable<Category> ICategoryService.GetTable => throw new NotImplementedException();

        public async Task Create(string name)
        {
            if(name == null) throw new ArgumentNullException();
            if (await _dbContext.Categories.AnyAsync(c => c.Name == name))
                throw new ArgumentException();
            await _dbContext.Categories.AddAsync(new Category { Name = name });
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Category>> GetAll()
        =>
            await _dbContext.Categories.ToListAsync();
        

        public Task<Category> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsAllExist(List<int> ids)
        {
            foreach (var id in ids)
            {
                if (!await IsExist(id))
                    return false;
            }
            return true;
        }

        public async Task<bool> IsExist(int id)
         => await _dbContext.Categories.AnyAsync(c => c.Id == id);

        public Task Update(int id, string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(int? id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
