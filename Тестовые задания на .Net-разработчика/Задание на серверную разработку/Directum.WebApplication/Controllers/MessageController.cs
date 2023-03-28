using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Directum.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        IMessageRepository _messageRepository;
        IUserRepository _userRepository;
        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger, IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }


        [HttpPost("AddMessage")]
        public ActionResult AddMessage(int userId, int userContactId, string message)
        {
            _messageRepository.AddMessage(new Message(userId, userContactId, message));
            return Ok();
        }

        [HttpGet("GetMessageByUser")]
        public List<Message> GetMessageByUser(int userId)
        {
            return _messageRepository.GetMessageByUser(userId);
        }



        /// <summary>
        /// Find user message
        /// </summary>
        /// 

        [HttpGet("FindUserMessage")]
        public List<Message> FindUserMessage(int userId, string message)
        {
            return _messageRepository.FindUserMessage(userId, message);
        }

    }
}