using Entity;
using Ninject;
using Service;

namespace Repository
{
    public class MessageRepository : IMessageRepository
    {
        private IGenericRepository<Message> _messageRepository;
        private IUserRepository _userRepository;

        public MessageRepository(IGenericRepository<Message> genericRepository, IUserRepository userRepository)
        {
            _messageRepository = genericRepository;
            _userRepository = userRepository;

        }

        /// <summary>
        /// Add message
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(Message message)
        {
            message.User = _userRepository.GetUserById(message.UserId);
            message.SendTime = DateTime.Now;
            _messageRepository.Create(message);
        }

        /// <summary>
        /// Get message by user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Message> GetMessageByUser(int userContactId)
        {
            IEnumerable<Message> messageEntities = _messageRepository.Include(u => u.User);
            messageEntities = messageEntities.Where(u => u.UserContactId == userContactId).ToList();
            foreach (var messageEntity in messageEntities)
            {
                messageEntity.DeliveryTime = DateTime.Now;
                _messageRepository.Update(messageEntity);
            }

            return messageEntities.ToList();
        }

        /// <summary>
        /// Find user message
        /// </summary>
        /// 
        public List<Message> FindUserMessage(int userId, string message)
        {
            List<Message> messageList = GetMessageByUser(userId);
            return messageList.Where(m => m.Content.IndexOf(message) > -1).ToList();
        }
    }

}