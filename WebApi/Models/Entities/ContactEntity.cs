using System.ComponentModel.DataAnnotations;
using WebApi.Models.DTO;

namespace WebApi.Models.Entities
{
    public class ContactEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Comment { get; set; } = null!;


        public static implicit operator ContactModel(ContactEntity entity)
        {
            return new ContactModel
            {
                Name = entity.Name,
                Email = entity.Email,
                Comment = entity.Comment
            };
        }
    }
}
