using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.DTO
{
    public class AuthRegisterModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; } = null!;

        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
        public string Password { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string RoleName { get; set; } = "productmanager";

        public static implicit operator IdentityUser(AuthRegisterModel model)
        {
            return new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber
            };
        }

        public static implicit operator UserProfileEntity(AuthRegisterModel model)
        {
            return new UserProfileEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }
    }
}
