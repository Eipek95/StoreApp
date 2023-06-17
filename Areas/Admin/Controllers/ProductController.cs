using Entitites.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Product model)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateProduct(model);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Update([FromRoute(Name = "id")] int id)
        {
            var product = _manager.ProductService.GetOneProduct(id, false);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([FromForm] Product model)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateUpdate(model);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}
