using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["title"] = "Featured Products";
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.NewItemList = await _productService.GetProductsByTag("new");
            homeViewModel.FeaturedItemList = await _productService.GetProductsByTag("featured");
            homeViewModel.PopularItemList = await _productService.GetProductsByTag("popular");
            //homeViewModel.collectionList.Add(new CollectionItemModel
            //{
            //    Name = "Black Coat of the Best Brandc And Design",
            //    Category = "Coats",
            //    Price = 3500,
            //    StarRating = 3,
            //    ImageUrl = "https://media.vogue.co.uk/photos/61dc386312345a6c1970c3a7/1:1/w_1080,h_1080,c_limit/wool%203.png"
            //});
            //homeViewModel.collectionList.Add(new CollectionItemModel { Name = "Black Coat of the Best Brandc And Design", Category = "Coats", Price = 3500, StarRating = 3, ImageUrl = "https://media.vogue.co.uk/photos/61dc386312345a6c1970c3a7/1:1/w_1080,h_1080,c_limit/wool%203.png" });
            //homeViewModel.collectionList.Add(new CollectionItemModel { Name = "Black Coat of the Best Brandc And Design", Category = "Coats", Price = 3500, StarRating = 4, ImageUrl = "https://media.vogue.co.uk/photos/61dc386312345a6c1970c3a7/1:1/w_1080,h_1080,c_limit/wool%203.png" });
            //homeViewModel.collectionList.Add(new CollectionItemModel { Name = "Black Coat of the Best Brandc And Design", Category = "Coats", Price = 3500, StarRating = 1, ImageUrl = "https://media.vogue.co.uk/photos/61dc386312345a6c1970c3a7/1:1/w_1080,h_1080,c_limit/wool%203.png" });
            //homeViewModel.collectionList.Add(new CollectionItemModel { Name = "Black Coat of the Best Brandc And Design", Category = "Coats", Price = 3500, StarRating = 2, ImageUrl = "https://media.vogue.co.uk/photos/61dc386312345a6c1970c3a7/1:1/w_1080,h_1080,c_limit/wool%203.png" });
            //homeViewModel.collectionList.Add(new CollectionItemModel { Name = "Black Coat of the Best Brandc And Design", Category = "Coats", Price = 3500, StarRating = 5, ImageUrl = "https://media.vogue.co.uk/photos/61dc386312345a6c1970c3a7/1:1/w_1080,h_1080,c_limit/wool%203.png" });

            return View(homeViewModel);
        }
    }
}
