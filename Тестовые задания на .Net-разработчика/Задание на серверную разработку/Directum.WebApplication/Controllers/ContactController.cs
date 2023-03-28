using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Directum.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        IContactRepository _contactRepository;
        IUserRepository _userRepository;

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger, IContactRepository contactRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _contactRepository = contactRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get user contact
        /// </summary>
        /// <param name="userEntity"></param>
        [HttpGet("GetUserContact")]
        public Contact GetUserContact(int userId)
        {
            var contact = _contactRepository.GetUserContact(userId);
            if (contact == null)
            {
                _logger.LogInformation($"По ид пользователя {userId} не найден контакт");
                return null;
            }

            _logger.LogInformation($"По ид пользователя {userId} найден контакт");
            return contact;
        }

        /// <summary>
        /// Get user contact list
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetUserContactList")]
        public List<Contact> GetUserContactList(int userId)
        {
            var contactList = _contactRepository.GetUserContactList(userId);

            if (contactList == null)
            {
                _logger.LogInformation($"По ид пользователя {userId} не найден контакт");
                return null;
            }
           
            _logger.LogInformation($"По ид пользователя {userId} найден контакт");

            return contactList;
        }

        /// <summary>
        /// Get user by name
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [HttpGet("FindContactByUserName")]
        public Contact FindContactByUserName(int userId,string userName)
        {
            var contact = _contactRepository.FindContactByUserName(userId, userName);
            return contact;
        }

        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="contact"></param>
        ///   
        [HttpGet("UpdateContact")]
        public ActionResult UpdateContact(int userId, int userContactId)
        {
            _contactRepository.UpdateContact(userContactId, userId);
            return Ok();
        }


        [HttpPost("AddContact")]
        public ActionResult AddContact(int userId, int userContactId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user != null)
                _logger.LogInformation($"По ид {userId} найден пользователь");
            else
                return BadRequest($"Не удалось найти пользователя в базе {userId}");

            Contact contact = new Contact() { User = user, LastUpdateTime = DateTime.UtcNow };
            _contactRepository.AddContact(userContactId, user);
            return Ok();
        }

        // <summary>
        /// Delete contact
        /// </summary>
        /// <param name="contact"></param>
        [HttpDelete("DeleteContact")]
        public ActionResult DeleteContact(int contactId)
        {
            _contactRepository.DeleteContact(contactId);
            return Ok();
        }

    }
}