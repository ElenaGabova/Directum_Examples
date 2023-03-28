using Entity;

namespace Service
{
    public interface IUserRepository
    {
        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="userEntity"></param>
        void AddUser(User userEntity);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUserById(int userId);

        /// <summary>
        /// Get user by name
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        User GetUserByName(string UserName);

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="userEntity"></param>
        void UpdateUser(User userEntity);
    }
}