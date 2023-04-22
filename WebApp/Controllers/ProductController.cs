using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("product/{articleNumber}")]
        public async Task<IActionResult> Index(int articleNumber)
        {
            if (articleNumber != 0)
            {
                var product = await _productService.GetProductByArticleNumber(articleNumber);
                return View(product);
            }
            return View();
            
        }
    }
}
