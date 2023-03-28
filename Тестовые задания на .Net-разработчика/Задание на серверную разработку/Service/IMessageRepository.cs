using Entity;

namespace Service
{
    public interface IMessageRepository
    {
        /// <summary>
        /// Add message
        /// </summary>
        /// <param name="message"></param>
        void AddMessage(Message message);

        /// <summary>
        /// Get message by user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Message> GetMessageByUser(int userId);

        /// <summary>
        /// Find user message
        /// </summary>
        /// 
        List<Message> FindUserMessage(int userId, string message);
    }
}