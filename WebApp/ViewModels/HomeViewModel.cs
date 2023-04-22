using WebApp.Models;

namespace WebApp.ViewModels
{
    public class HomeViewModel
    {
        public List<CollectionItemModel> collectionList = new List<CollectionItemModel>();
        public IEnumerable<CollectionItemModel> NewItemList { get; set; } = new List<CollectionItemModel>();
        public IEnumerable<CollectionItemModel> FeaturedItemList { get; set; } = new List<CollectionItemModel>();
        public IEnumerable<CollectionItemModel> PopularItemList { get; set; } = new List<CollectionItemModel>();
    }
}
