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
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _appDbContext;
        public OrderRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(Order order)
        {
            var orderList = _appDbContext.ordersItems.Where(o=> o.Order_Id == order.Id).ToList();
            order.Amount = orderList.Select(x=>x.Quantity).Sum();
            order.Date = DateTime.Now;
            await _appDbContext.orders.AddAsync(order);
            _appDbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var delOrder = await _appDbContext.orders.FirstOrDefaultAsync(o => o.Id == id);
            _appDbContext.orders.Remove(delOrder);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _appDbContext.orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            var _order = await _appDbContext.orders.FirstOrDefaultAsync(o=>o.Id == id);
            return _order;
        }

        public async Task<Order> UpdateAsync(int id, Order order)
        {
            order.Id = id;
            order.Amount = _appDbContext.ordersItems.Where(o => o.Order_Id == order.Id).ToList().Select(x => x.Quantity).Sum();
            _appDbContext.orders.Update(order);
            await _appDbContext.SaveChangesAsync();
            return order;
        }
    }
}
