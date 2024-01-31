using DataAccess.Entity;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<Customer> CheckCustomer(Customer customer)
        {
            return await _customerRepo.CheckCustomer(customer);
        }
        public async Task Add(Customer customer)
        {
            await _customerRepo.Add(customer);
        }

        public async Task Delete(int id)
        {
            await _customerRepo.Delete(id);
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            return _customerRepo.GetAll();
        }

        public Task<Customer> GetById(int id)
        {
            return _customerRepo.GetById(id);
        }

        public Task<Customer> UpdateAsync(int id, Customer customer)
        {
            return _customerRepo.UpdateAsync(id, customer);
        }
    }
}
