using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class AdminViewModel
    {
        public int ArticleNumber { get; set; } = 1;

        [Required(ErrorMessage = "Du måste fylla i ett namn för produkten")]
        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Produkten måste ha ett pris/värde")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Glömde bort att man behövde den här")]
        //[RegularExpression(@"^[1-5]$/", ErrorMessage = "Får endast vara en siffra mellan 1-5")]
        //[DataType(DataType.Currency)]
        public int StarRating { get; set; }

        [Required(ErrorMessage = "Välj en kategori")]
        public string Category { get; set; } = null!;

        [Required(ErrorMessage = "Produkten behöver en tag")]
        public string Tag { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsAdmin { get; set; } = true;

        public static implicit operator ProductModel(AdminViewModel model)
        {
            return new ProductModel
            {
                ProductName = model.ProductName,
                Description = model.Description,
                Price = model.Price,
                StarRating = model.StarRating,
                Category = model.Category,
                Tag = model.Tag,
                ImageUrl = model.ImageUrl
            };
        }
    }
}
