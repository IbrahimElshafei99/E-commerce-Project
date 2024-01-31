using DataAccess.Entity;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepo _orderItemRepo;
        public OrderItemService(IOrderItemRepo orderItemRepo)
        {
            _orderItemRepo = orderItemRepo;
        }

        public async Task Add(OrderItems orderItems)
        {
            await _orderItemRepo.Add(orderItems);
        }

        public async Task Delete(int id)
        {
            await _orderItemRepo.Delete(id);
        }

        public Task<IEnumerable<OrderItems>> GetAll()
        {
            return _orderItemRepo.GetAll();
        }

        public Task<OrderItems> GetById(int id)
        {
            return _orderItemRepo.GetById(id);
        }

        public async Task InsertData(int customerId, List<int> productIds)
        {
            await _orderItemRepo.InsertData(customerId, productIds);
        }

        public Task<OrderItems> UpdateAsync(int id, OrderItems orderItems)
        {
            return _orderItemRepo.UpdateAsync(id, orderItems);
        }
    }
}
