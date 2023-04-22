using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Entities;

namespace WebApi.Models.DTO
{
    public class ProductModel
    {
        public int ArticleNumber { get; set; }

        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }
        public int StarRating { get; set; }

        public string Category { get; set; } = null!;

        public string Tag { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public static implicit operator ProductEntity(ProductModel model)
        {
            return new ProductEntity
            {
                ArticleNumber = model.ArticleNumber,
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
