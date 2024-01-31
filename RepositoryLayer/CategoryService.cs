using DataAccess.Entity;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task Add(Category category)
        {
            await _categoryRepo.Add(category);
        }

        public async Task Delete(int id)
        {
            await _categoryRepo.Delete(id);
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            return _categoryRepo.GetAll(); 
        }

        public Task<Category> GetById(int id)
        {
            return _categoryRepo.GetById(id);
        }

        public Task<Category> UpdateAsync(int id, Category category)
        {
            return _categoryRepo.UpdateAsync(id, category);
        }
    }
}
