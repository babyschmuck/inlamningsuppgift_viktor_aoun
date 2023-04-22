using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.DTO;
using WebApi.Models.Entities;

namespace WebApi.Repositories
{
    public class ContactRepository
    {
        private readonly DataContext _dataContext;

        public ContactRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual async Task<ContactModel> AddAsync(ContactEntity entity)
        {
            _dataContext.Contacts.Add(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<ContactModel>> GetAllAsync()
        {
            var contactList = await _dataContext.Contacts.ToListAsync();
            var contacts = new List<ContactModel>();

            foreach (var contact in contactList)
                contacts.Add(contact);

            return contacts;
        }
    }
}
