using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.DTO;

namespace WebApi.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int ArticleNumber { get; set; }

        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int StarRating { get; set; }

        public string Category { get; set;} = null!;

        public string Tag { get; set; } = null!;

        public string? ImageUrl { get; set; } 

        public static implicit operator ProductModel(ProductEntity entity)
        {
            return new ProductModel
            {
                ArticleNumber = entity.ArticleNumber,
                ProductName = entity.ProductName,
                Description = entity.Description,
                Price = entity.Price,
                StarRating = entity.StarRating,
                Category = entity.Category,
                Tag = entity.Tag,
                ImageUrl = entity.ImageUrl
            };
        }
    }
}
