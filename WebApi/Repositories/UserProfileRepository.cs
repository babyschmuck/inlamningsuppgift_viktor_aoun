using System.Runtime.CompilerServices;
using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories
{
    public class UserProfileRepository : Repository<UserProfileEntity>
    {
        private readonly IdentityContext _identityContext;

        public UserProfileRepository(IdentityContext identityContext) : base(identityContext)
        {
            _identityContext = identityContext;
        }

    }
}
