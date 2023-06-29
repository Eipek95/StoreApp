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
        public Cart Cart { get; set; }//buray� newlemeyiz ��nk� sepete sadece bir �r�n ekleme problemi ya�ar�z.onun yerine sepetin bilgilerini section �zerinde tutarak i�lemleri yapar�z

        public CartModel(IServiceManager serviceManager, Cart cartService)//program.cs �zerinde servisi tan�mlad�k.cart scoped
        {
            _serviceManager = serviceManager;
            Cart = cartService;
        }

        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            //Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();//session �zerinden cart nesnesi varsa getir yoksa yeni olu�tur.bu i�lemleri config yapt�ktan sonra ctor i�inde otomatik yapacakt�r
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
