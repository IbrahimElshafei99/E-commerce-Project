using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IOrderItemRepo
    {
        Task InsertData(int c_id, List<int> p_id);
        Task<IEnumerable<OrderItems>> GetAll();
        Task<OrderItems> GetById(int id);
        Task Add(OrderItems orderItems); 
        Task<OrderItems> UpdateAsync(int id, OrderItems orderItems);
        Task Delete(int id);
    }
}
