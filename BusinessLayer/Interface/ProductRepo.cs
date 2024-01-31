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
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepo (AppDbContext appDbContext) { _appDbContext = appDbContext; }

        public async Task Add(Product product)
        {
            await _appDbContext.products.AddAsync(product);
            _appDbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var deletedPro = await _appDbContext.products.FirstOrDefaultAsync(p=> p.Id == id);
            _appDbContext.products.Remove(deletedPro);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Product> UpdateAsync(int id, Product product)
        {
            product.Id = id;
            _appDbContext.products.Update(product);
            await _appDbContext.SaveChangesAsync();
            return product;

        }

        async Task<IEnumerable<Product>> IProductRepo.GetAll()
        {
            return await _appDbContext.products.Include(c=> c.Category).ToListAsync();
        }

        async Task<Product> IProductRepo.GetById(int id)
        {
            var _product = await _appDbContext.products.FirstOrDefaultAsync(p=> p.Id == id);
            return _product;
        }

        // Can be better
        async Task<List<Product>> IProductRepo.GetMultipleProducts(List<int> ids)
        {
            List<Product> products = new List<Product>();
            foreach (int id in ids)
            {
                var p = await _appDbContext.products.Include(x=> x.Category).FirstOrDefaultAsync(x => x.Id == id);
                products.Add(p);
            }

            return products;
        }

        // Methods deal with category entity
        async Task<IEnumerable<Product>> IProductRepo.GetByCatId(int catId)
        {
            var prodlist = await _appDbContext.products.Where(y=> y.CategoryId == catId).ToListAsync();
            return prodlist;
        }

    }
}
