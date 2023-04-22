using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Principal;
using WebApi.Contexts;

namespace WebApi.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        private readonly IdentityContext _identityContext;


        protected Repository(IdentityContext identityContext)
        {
            _identityContext = identityContext;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _identityContext.Set<TEntity>().Add(entity);
            await _identityContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _identityContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _identityContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (entity != null)
                return entity;

            return null!;
        }
    }
}
