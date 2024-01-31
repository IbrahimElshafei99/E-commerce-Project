using DataAccess.Data;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _categoryRepo;
        public CategoryRepo(AppDbContext categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task Add(Category category)
        {
            await _categoryRepo.categories.AddAsync(category);
            _categoryRepo.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var deletedCat = await _categoryRepo.categories.FirstOrDefaultAsync(c => c.Id == id);
            _categoryRepo.categories.Remove(deletedCat);
            await _categoryRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepo.categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var cat = await _categoryRepo.categories.FirstOrDefaultAsync(c=> c.Id == id);
            return cat;
        }

        public async Task<Category> UpdateAsync(int id, Category category)
        {
            category.Id = id;
            _categoryRepo.categories.Update(category);
            await _categoryRepo.SaveChangesAsync();
            return category;
        }
    }
}
