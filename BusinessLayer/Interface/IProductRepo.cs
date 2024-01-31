using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Add(Product product);
        Task<Product> UpdateAsync(int id, Product product);
        Task Delete(int id);
        Task<List<Product>> GetMultipleProducts(List<int> ids);
        // Methods deal with category entity
        Task<IEnumerable<Product>> GetByCatId(int catId);
        //Task<IEnumerable<Product>> JoinWithCategory();
    }
}
