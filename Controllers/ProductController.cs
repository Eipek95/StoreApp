using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {

        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            // var context = new RepositoryContext(
            //     new DbContextOptionsBuilder<RepositoryContext>()
            //     .UseSqlite("DataSource=C:\\Users\\Msi\\Documents\\Sqlite\\ProductDb.db")
            //     .Options
            // );
            var model = _manager.Product.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Get(int id)
        {
            var product = _manager.Product.GetOneProduct(id,false);
            return View(product);
        }
    }
}