using BusinessLayer;
using DataAccess.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;

namespace RepoWithAspWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private static List<int> listOfIds = new List<int>(); // This list to save selected IDs from razor view
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int id)
        {
            if(listOfIds.Any())
            {
                listOfIds= new List<int>();
            }
            var allProducts = await _productService.GetAll();
            if (id !=0)
            {
                var prodList = await _productService.GetByCatId(id);
                return View(prodList);
            }
            return View(allProducts);
        }
        

        
        public IActionResult BuyIdList(int id)
        {
            listOfIds.Add(id);
            return StatusCode(204); // This helps me to return nothing from this IActionResult
        }

        public IActionResult IncreaseBuyList(int id)
        {
            listOfIds.Add(id);
            return RedirectToAction("Buy");
        }
        public IActionResult DecreaseBuyList(int id)
        {
            listOfIds.Remove(id);
            return RedirectToAction("Buy");
        }

        public async Task<IActionResult> Buy()
        {
            //TempData["idList"] = listOfIds; 
            TempData["idList"] = string.Join(",", listOfIds);
            var prods = await _productService.GetMultipleProducts(listOfIds);
            return View(prods);
        }
         
        public async Task<IActionResult> Details(int id)
        {
            var _product = await _productService.GetById(id);
            return View(_product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedProd = await _productService.GetById(id);
            if(deletedProd == null)
            {
                return View("NotFound");
            }
            return View(deletedProd);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodDetails = await _productService.GetById(id);
            if (prodDetails == null)
            {
                return View("NotFound");
            }

            await _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
