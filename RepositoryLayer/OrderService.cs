using DataAccess.Entity;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task Add(Order order)
        {
            await _orderRepo.Add(order);
        }

        public async Task Delete(int id)
        {
            await _orderRepo.Delete(id);
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            return _orderRepo.GetAll();
        }

        public Task<Order> GetById(int id)
        {
            return _orderRepo.GetById(id);
        }

        public Task<Order> UpdateAsync(int id, Order order)
        {
            return _orderRepo.UpdateAsync(id, order);
        }
    }
}
