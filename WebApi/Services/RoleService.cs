using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class RoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRolesAsync()
        {
            if (!await _roleManager.Roles.AnyAsync())
            {
                IdentityRole adminRole = new IdentityRole("admin");
                await _roleManager.CreateAsync(adminRole);
                IdentityRole productManagerRole = new IdentityRole("productmanager");
                await _roleManager.CreateAsync(productManagerRole);
                return false;
            }
            return true;

        }
    }
}
