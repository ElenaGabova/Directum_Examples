using Entity;

namespace Service
{
    public interface IContactRepository
    {
        /// <summary>
        /// Get user contact
        /// </summary>
        /// <param name="userEntity"></param>
        Contact GetUserContact(int userId);

        /// <summary>
        /// Get user contact list
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Contact> GetUserContactList(int userId);

        /// <summary>
        /// Get user by name
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        Contact FindContactByUserName(int userId, string userName);

        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="contact"></param>
        void UpdateContact(int userContactId, int userId);

        // <summary>
        /// Add contact
        /// </summary>
        /// <param name="contact"></param>
        void AddContact(int userContactId, User userEntity);

        // <summary>
        /// Delete contact
        /// </summary>
        /// <param name="contact"></param>
        void DeleteContact(int userContactId);

    }
}