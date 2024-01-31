using DataAccess.Entity;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Add(Product product);
        Task<Product> UpdateAsync(int id, Product product);
        Task Delete(int id);
        Task<List<Product>> GetMultipleProducts(List<int> ids);
        //Methods deal with category entity
        Task<IEnumerable<Product>> GetByCatId(int catId);
        Task<IEnumerable<Category>> GetCategories();
        //Task<IEnumerable<Product>> JoinWithCategory();
    }
}
