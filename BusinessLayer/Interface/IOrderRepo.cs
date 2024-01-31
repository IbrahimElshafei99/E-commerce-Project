using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IOrderRepo
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(int id);
        Task Add(Order order);
        Task<Order> UpdateAsync(int id, Order order);
        Task Delete(int id); 
    }
}
