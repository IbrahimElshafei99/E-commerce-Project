using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItems>> GetAll();
        Task<OrderItems> GetById(int id);
        Task Add(OrderItems orderItems);
        Task InsertData(int customerId, List<int> productIds);
        Task<OrderItems> UpdateAsync(int id, OrderItems orderItems);
        Task Delete(int id);
    }
}
