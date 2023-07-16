using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly Cart _cart;

        public OrderController(IServiceManager serviceManager, Cart cart)
        {
            _serviceManager = serviceManager;
            _cart = cart;
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
            if (_cart.lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry,your cart is empty.");
            }
            if (ModelState.IsValid)
            {
                order.lines = _cart.lines.ToArray();
                _serviceManager.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = order.OrderId });
            }
            else
            {
                return View();
            }
        }
    }
}
