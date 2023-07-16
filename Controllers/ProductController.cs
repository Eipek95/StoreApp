using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {

        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            // var context = new RepositoryContext(
            //     new DbContextOptionsBuilder<RepositoryContext>()
            //     .UseSqlite("DataSource=C:\\Users\\Msi\\Documents\\Sqlite\\ProductDb.db")
            //     .Options
            // );
            var model = _serviceManager.ProductService.GetAllProductsWithDetails(p);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var product = _serviceManager.ProductService.GetOneProduct(id, false);
            return View(product);
        }
    }
}