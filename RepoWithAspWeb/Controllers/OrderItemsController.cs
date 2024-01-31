using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace RepoWithAspWeb.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            if (TempData.ContainsKey("idList"))
            {
                List<int> ProdIDs =TempData["idList"].ToString().Split(',').Select(int.Parse).ToList();
                //List<int> ProdIDs =TempData["idList"] as List<int>;
                if (TempData.ContainsKey("customerId"))
                {
                    int customer_Id = int.Parse(TempData["customerId"].ToString());
                    _orderItemService.InsertData(customer_Id, ProdIDs);
                    return View();
                }
            }
            return View("Error");
        }
    }
}
