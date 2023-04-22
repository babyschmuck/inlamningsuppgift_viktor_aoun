using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApi.Helpers;
using WebApi.Models.DTO;
using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleService _roleService;
        private readonly UserProfileRepository _userProfileRepository;
        private readonly JwtToken _jwt;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthService(UserManager<IdentityUser> userManager, RoleService roleService, UserProfileRepository userProfileRepository, JwtToken jwt, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleService = roleService;
            _userProfileRepository = userProfileRepository;
            _jwt = jwt;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterAsync(AuthRegisterModel model)
        {
            try
            {
                await _roleService.CreateRolesAsync();
                if (!await _userManager.Users.AnyAsync())
                {
                    model.RoleName = "admin";
                }
                else
                {
                    model.RoleName = "productmanager";
                }

                
                var identityResult = await _userManager.CreateAsync(model, model.Password);
                if (identityResult.Succeeded)
                {

                    var identityUser = await _userManager.FindByEmailAsync(model.Email);
                    await _userManager.AddToRoleAsync(identityUser, model.RoleName);

                    UserProfileEntity userProfile = model;
                    userProfile.UserId = identityUser!.Id;

                    await _userProfileRepository.AddAsync(userProfile);

                    return true;
                }

                
            }
            catch {  }
            return false;
        }

        public async Task<string> LoginAsync(AuthLoginModel model)
        {
            var identityUser = await _userManager.FindByEmailAsync(model.Email);
            if (identityUser != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, model.Password, false);
                if (signInResult.Succeeded)
                {
                    
                    var role = await _userManager.GetRolesAsync(identityUser);
                    string roleName = role.FirstOrDefault();
                    var claimsIdentity = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("id", identityUser.Id.ToString()),
                        new Claim("role", roleName),
                        new Claim(ClaimTypes.Name, identityUser.Email!)
                    });

                    return _jwt.Generate(claimsIdentity, DateTime.Now.AddHours(1));
                }
            }
            return string.Empty;
        }
    }
}
