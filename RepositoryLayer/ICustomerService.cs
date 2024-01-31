using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> CheckCustomer(Customer customer);
        Task Add(Customer customer);
        Task<Customer> GetById(int id);
        Task<Customer> UpdateAsync(int id, Customer customer);
        Task Delete(int id);
    }
}
