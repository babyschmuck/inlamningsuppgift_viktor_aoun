using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.DTO;
using WebApi.Models.Entities;

namespace WebApi.Repositories
{
    public class ProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual async Task<ProductModel> AddAsync(ProductEntity entity)
        {
            _dataContext.Products.Add(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var items = await _dataContext.Products.ToListAsync();
            var products = new List<ProductModel>();

            foreach (var item in items)
                products.Add(item);

            return products;
        }
        public async Task<IEnumerable<ProductModel>> GetAllByTagAsync(string tag)
        {
            var items = await _dataContext.Products.Where(x => x.Tag == tag).ToListAsync();
            var products = new List<ProductModel>();

            foreach (var item in items)
                products.Add(item);

            return products;
        }

        public async Task<ProductModel> GetAsync(int articleNumber)
        {
            var item = await _dataContext.Products.FindAsync(articleNumber);
            return item!;
        }

    }
}
