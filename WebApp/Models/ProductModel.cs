using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ProductModel
    {
        
        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StarRating { get; set; }

        public string Category { get; set; } = null!;

        public string Tag { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
