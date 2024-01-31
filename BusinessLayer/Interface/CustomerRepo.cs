using DataAccess.Data;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Add(Customer customer)
        {
            await _appDbContext.customers.AddAsync(customer);
            _appDbContext.SaveChanges(); 
        }

        public async Task<Customer> CheckCustomer(Customer customer)
        {
            var email = customer.Email;
            var _name = customer.Name;
            var client = _appDbContext.customers.FirstOrDefault(c => c.Email == email && c.Name == _name);
            return client;
        }

        public async Task Delete(int id)
        {
            var customerDetails = await _appDbContext.customers.FirstOrDefaultAsync(x => x.Id == id);
            
            _appDbContext.customers.Remove(customerDetails);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var result = await _appDbContext.customers.ToListAsync();
            return result;
        }

        public async Task<Customer> GetById(int id)
        {
            var result = await _appDbContext.customers.FirstOrDefaultAsync(x=>x.Id == id);
            return result;
            
        }

        public async Task<Customer> UpdateAsync(int id, Customer customer)
        {
            customer.Id = id;
            _appDbContext.customers.Update(customer);
            await _appDbContext.SaveChangesAsync();
            return customer;
        }
    }
}
