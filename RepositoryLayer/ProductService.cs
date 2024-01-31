using DataAccess.Entity;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;
        public ProductService(IProductRepo productRepo, ICategoryRepo categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task Add(Product product)
        {
            await _productRepo.Add(product);
        }

        public async Task Delete(int id)
        {
            await _productRepo.Delete(id);
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return _productRepo.GetAll();
        }

        public Task<Product> GetById(int id)
        {
            return _productRepo.GetById(id);
        }

        public Task<Product> UpdateAsync(int id, Product product)
        {
            return _productRepo.UpdateAsync(id, product);
        }

        Task<List<Product>> IProductService.GetMultipleProducts(List<int> ids)
        {
            return _productRepo.GetMultipleProducts(ids);
        }
        //Methods deal with category entity
        public Task<IEnumerable<Product>> GetByCatId(int catId)
        {
            return _productRepo.GetByCatId(catId);
        }

        public Task<IEnumerable<Category>> GetCategories()
        {
            return _categoryRepo.GetAll();
        }

        
        /*
public Task<IEnumerable<Product>> JoinWithCategory()
{
   return _productRepo.JoinWithCategory();
}*/
    }
}
