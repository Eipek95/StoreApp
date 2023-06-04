using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {

        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // var context = new RepositoryContext(
            //     new DbContextOptionsBuilder<RepositoryContext>()
            //     .UseSqlite("DataSource=C:\\Users\\Msi\\Documents\\Sqlite\\ProductDb.db")
            //     .Options
            // );
            var model=_context.Products.ToList();
            return View(model);
        }

        public IActionResult Get(int id)
        { 
            var product=_context.Products.Where(x=>x.ProductId==id).First();
            return View(product);
        }
    }
}