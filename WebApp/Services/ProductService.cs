using System.Collections;
using System.Reflection;
using WebApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApp.Services
{
    public class ProductService
    {
        public async Task<IEnumerable<CollectionItemModel>> GetProductsByTag(string tag)
        {
            using var http = new HttpClient();
            http.DefaultRequestHeaders.Add("X-Api-Key", "1a2f82c0-c1dd-4a4d-9a11-8fed4cfd3f2b");

            var result = await http.GetFromJsonAsync<IEnumerable<CollectionItemModel>>($"https://localhost:7022/api/Products/tag/{tag}");
            List<CollectionItemModel> products = new List<CollectionItemModel>();
            foreach(var product in result)
            {
                CollectionItemModel prod = new CollectionItemModel
                {
                    ArticleNumber = product.ArticleNumber,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    StarRating = product.StarRating,
                    Category = product.Category,
                    Tag = product.Tag,
                    ImageUrl = product.ImageUrl
                };
                if (string.IsNullOrEmpty(prod.ImageUrl))
                    prod.ImageUrl = "images/370x295.svg";

                products.Add(prod);
            }
            result = products;
            return result;
        }

        public async Task<CollectionItemModel> GetProductByArticleNumber(int articleNumber)
        {
            using var http = new HttpClient();
            http.DefaultRequestHeaders.Add("X-Api-Key", "1a2f82c0-c1dd-4a4d-9a11-8fed4cfd3f2b");

            var result = await http.GetFromJsonAsync<CollectionItemModel>($"https://localhost:7022/api/Products/{articleNumber}");
            
            var product = new CollectionItemModel
            {
                ArticleNumber = result.ArticleNumber,
                ProductName = result.ProductName,
                Description = result.Description,
                Price = result.Price,
                StarRating = result.StarRating,
                Category = result.Category,
                Tag = result.Tag,
                ImageUrl = result.ImageUrl
            };
            if(string.IsNullOrEmpty(product.ImageUrl))
                product.ImageUrl = "/images/370x295.svg";

            return product;
        }
    }
}
