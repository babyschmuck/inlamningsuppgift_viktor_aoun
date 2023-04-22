using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        [RegularExpression(@"^[a-zA-Z]+(?:['-][a-zA-Z]+)*$", ErrorMessage = "Du måste ange ett giltigt förnamn")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        [RegularExpression(@"^[a-zA-Z]+(?:['-][a-zA-Z]+)*$", ErrorMessage = "Du måste ange ett giltigt efternamn")]
        public string LastName { get; set; } = null!;

        [Display(Name = "E-postadress")]
        [Required(ErrorMessage = "Du måste ange en e-post")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Ange en giltig e-post")]
        public string Email { get; set; } = null!;

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Du måste ange ett giltigt lösenord")]
        public string Password { get; set; } = null!;

        [Display(Name = "Bekräfta lösenord")]
        [Required(ErrorMessage = "Du måste bekräfta lösenordet")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Lösenordet matchar inte")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Telefonnummer")]
        public string? PhoneNumber { get; set; }
    }
}
