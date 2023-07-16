using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace StoreApp.Infrastructe.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "products")]
    public class LastestProductTagHelper : TagHelper
    {
        private readonly IServiceManager _serviceManager;

        [HtmlAttributeName("number")]//kaç tane ürün gösterilecek onun bilgisini aldıgımız attribute
        public int Number { get; set; }

        public LastestProductTagHelper(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "my-3");

            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class", "lead");

            TagBuilder icon = new TagBuilder("i");
            icon.Attributes.Add("class", "fa fa-box text-secondary");

            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.AppendHtml("Lastest Products");

            TagBuilder lg = new TagBuilder("list-group");
            lg.Attributes.Add("class", "list-group");
            var lastProducts = _serviceManager.ProductService.GetLastestProducts(Number, false);
            foreach (var item in lastProducts)
            {
                //TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");

                a.Attributes.Add("href", $"/product/get/{item.ProductId}");
                a.Attributes.Add("class", "list-group-item list-group-item-action");
                a.InnerHtml.AppendHtml(item.ProductName);

                //li.InnerHtml.AppendHtml(a);
                lg.InnerHtml.AppendHtml(a);
            }



            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(lg);
            output.Content.AppendHtml(div);


            /*
             html çıktısı
             
            <div class="my-3">
                    <h6 class="lead">
                        <i class="fa fa-box text-secondary"></i>
                        Lastest Products

                    </h6>
                    <ul>
                        <li><a href="#"> Computer</a></li>
                        <li><a href="#"> Keyboard</a></li>
                        <li><a href="#"> Mouse</a></li>
                        <li><a href="#"> Hamlet</a></li>
                        <li><a href="#"> Deck</a></li>
                    </ul>
                </div>
            */
        }
    }
}
