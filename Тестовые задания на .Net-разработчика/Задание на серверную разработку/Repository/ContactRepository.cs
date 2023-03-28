using Entity;
using Ninject;
using Service;

namespace Repository
{
    public class ContactRepository : IContactRepository
    {
        private IGenericRepository<Contact> _contactRepository;
        private IUserRepository _userRepository;

        public ContactRepository(IGenericRepository<Contact> genericRepository,
                                IUserRepository userRepository)
        {
            _contactRepository = genericRepository;
            _userRepository = userRepository;
        }

        public Contact GetUserContact(int userId)
        {
            IEnumerable<Contact> contactEntities = _contactRepository.Include(c => c.User);
            return contactEntities.FirstOrDefault(c => c.userContactId == userId);
        }

        public List<Contact> GetUserContactList(int userId)
        {
            IEnumerable<Contact> contactEntities = _contactRepository.Include(c => c.User);
            return contactEntities.Where(c => c.User.Id == userId).ToList();
        }

        public Contact FindContactByUserName(int userId, string userName)
        {
            var contactList = GetUserContactList(userId);
            return contactList?.FirstOrDefault(c => c.User.Name == userName);
        }

        public void UpdateContact(int userContactId,int userId)
        {
            if (_userRepository.GetUserById(userContactId) == null)
                return;

            if (_userRepository.GetUserById(userId) == null)
                return;

            var contactList = GetUserContactList(userId);
            var contact = contactList.FirstOrDefault(c => c.userContactId == userContactId);
            contact.LastUpdateTime = DateTime.UtcNow;
            _contactRepository.Update(contact);
        }

        public void AddContact(int userContactId, User userEntity)
        {
            if (_userRepository.GetUserById(userContactId) == null)
                return;

            Contact contact = new Contact() { userContactId = userContactId, User = userEntity, LastUpdateTime = DateTime.UtcNow };
            _contactRepository.Create(contact);
        }

        public void DeleteContact(int contactId)
        {
            var contact = _contactRepository.Get()?.FirstOrDefault(c => c.contactId == contactId);
            _contactRepository.Remove(contact);
        }
    }

}