using BusinessLayer;
using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RepoWithAspWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<IActionResult> Index() 
        {
            var allCustomers = await _customerService.GetAll();
            return View(allCustomers);
        }

        //Get : Check method
        public IActionResult Check()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Check([Bind("Name, Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var _customer = await _customerService.CheckCustomer(customer);
                if(_customer != null)
                {
                    // We used TempData to enable other IActionResult to access customer Id
                    TempData["customerId"] = _customer.Id;
                    return RedirectToAction("Add", "OrderItems");
                }
                return View("Error");
            }
            return View(customer); 
        }

        //Get : Create method
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, City,Email,PaymentInfo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.Add(customer);
                return View("Create");
            }
            return View(customer);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _customerService.GetById(id);
            return View(result);
        }

        // Get: Update
        public async Task<IActionResult> Edit(int id)
        {
            var customerDetails = await _customerService.GetById(id);
            if(customerDetails == null)
            {
                return View("NotFound");
            }
            return View(customerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name,City,Email,PaymentInfo")] Customer customer)
        {
            if(ModelState.IsValid)
            {
                await _customerService.UpdateAsync(id, customer);
                return RedirectToAction("Details", new {id = customer.Id});
            }
            return View(customer);
        }

        //Get: Remove
        public async Task<IActionResult> Delete(int id)
        {
            var customerDetails = await _customerService.GetById(id);
            if (customerDetails == null)
            {
                return View("NotFound");
            }
            return View(customerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerDetails = await _customerService.GetById(id);
            if (customerDetails == null)
            {
                return View("NotFound");
            }

            await _customerService.Delete(id);
            return RedirectToAction("Index");
        } 


    }
}
