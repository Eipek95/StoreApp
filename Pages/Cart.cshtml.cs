using Entities.Models;
using Entitites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _serviceManager;
        public Cart Cart { get; set; }//burayý newlemeyiz çünkü sepete sadece bir ürün ekleme problemi yaþarýz.onun yerine sepetin bilgilerini section üzerinde tutarak iþlemleri yaparýz

        public CartModel(IServiceManager serviceManager, Cart cartService)//program.cs üzerinde servisi tanýmladýk.cart scoped
        {
            _serviceManager = serviceManager;
            Cart = cartService;
        }

        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            //Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();//session üzerinden cart nesnesi varsa getir yoksa yeni oluþtur.bu iþlemleri config yaptýktan sonra ctor içinde otomatik yapacaktýr
        }
        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _serviceManager.ProductService.GetOneProduct(productId, false);

            if (product != null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
                Cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("Cart", Cart);
            }

            return RedirectToPage(new
            {
                returnUrl = returnUrl,
            });
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            Cart.RemoveLine(Cart.lines.First(x => x.Product.ProductId.Equals(id)).Product);
            //HttpContext.Session.SetJson<Cart>("Cart", Cart);
            return Page();
        }
    }
}
