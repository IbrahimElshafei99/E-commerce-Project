using DataAccess.Data;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public class OrderItemRepo : IOrderItemRepo
    {
        private readonly AppDbContext _appDbContext;
        public OrderItemRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public Task Add(OrderItems orderItems)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var delItem = await _appDbContext.ordersItems.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.ordersItems.Remove(delItem);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItems>> GetAll()
        {
            return await _appDbContext.ordersItems.ToListAsync();
        }
         
        public async Task<OrderItems> GetById(int id)
        {
            var _item = await _appDbContext.ordersItems.FirstOrDefaultAsync(o=>o.Id == id);
            return _item;
        }

        public async Task InsertData(int customerId, List<int> productIds)
        {
            // create purchased list that carries all products selected by their IDs
            var purchased = _appDbContext.products.Where(p=> p.Id == productIds[0]).ToList();
            for(int i=1; i<productIds.Count(); i++)
            {
                purchased.Add(_appDbContext.products.FirstOrDefault(p => p.Id == productIds[i]));
            }
            // group selected products by id
            var groupedProducts = purchased.GroupBy(p => p.Id)
                                           .Select(p=> new {ID = p.Key, Count = p.Count(), TotalPrice =p.Sum(s=>s.Price)})
                                           .ToList();
            // sum all product price in the order
            var totalAmount = groupedProducts.Select(p => p.TotalPrice).Sum();
            // add the new order
            Order order = new Order()
            {
                Amount = totalAmount,
                Date = DateTime.Now,
                CustomerId = customerId
            };

            Product product = new Product();
            foreach(var item in groupedProducts)
            {
                // get the selected products to update the quantity
                product = _appDbContext.products.FirstOrDefault(p => p.Id == item.ID);
                if(product != null)
                {
                    // add the new order Items
                    OrderItems orderItems = new OrderItems()
                    {
                        Price = item.TotalPrice / item.Count,
                        Quantity = item.Count,
                        ProductId = item.ID,
                        Order = order
                    };
                    _appDbContext.Add(orderItems);

                    product.Quantity -= item.Count;
                    _appDbContext.Update(product);
                }
            }
            _appDbContext.SaveChanges();
        }

        public async Task<OrderItems> UpdateAsync(int id, OrderItems orderItems)
        {
            orderItems.Id = id;
            for (int i = 0; i < orderItems.Quantity; i++)
            {
                var item = _appDbContext.products.Where(o => o.Id == orderItems.ProductId).Select(x => x.Price).First();
                orderItems.Price += item;
            }
            _appDbContext.ordersItems.Update(orderItems);
            await _appDbContext.SaveChangesAsync();
            return orderItems;
        }
    }
}
