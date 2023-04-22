namespace WebApp.Models
{
    public class CollectionItemModel
    {
        public int ArticleNumber { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public string Category { get; set; } = null!;
        public decimal Price { get; set; }
        public int StarRating { get; set; }
        public string Tag { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
