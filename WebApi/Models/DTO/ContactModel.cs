using WebApi.Models.Entities;

namespace WebApi.Models.DTO
{
    public class ContactModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string Comment { get; set; } = null!;

        public static implicit operator ContactEntity(ContactModel model)
        {
            return new ContactEntity
            {
                Name = model.Name,
                Email = model.Email,
                Comment = model.Comment
            };
        }
    }
}
