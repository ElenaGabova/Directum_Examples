using Entity;
using Ninject;
using Service;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private IGenericRepository<User> _userRepository;


        public UserRepository(IGenericRepository<User> genericRepository)
        {
            _userRepository = genericRepository;

        }

        /// <summary>
        /// получения пользователя по ИД;
        /// </summary>
        /// <param name="userId"></param>
        public User GetUserById(int userId)
        {
            return _userRepository.FindById(userId);
        }

        /// <summary>
        /// получения пользователя по ИД;
        /// </summary>
        /// <param name="userId"></param>
        public User GetUserByName(string UserName)
        {
            IEnumerable<User> userEntities = _userRepository.Get();
            return userEntities.FirstOrDefault(u => u.Name == UserName);
        }

        /// <summary>
        /// добавление нового пользователя и возврат его ИД
        /// </summary>
        /// <param name="userId"></param>
        public void AddUser(User userEntity)
        {
            _userRepository.Create(userEntity);
        }

        /// <summary>
        /// обновление данных пользователя.
        /// </summary>
        /// <param name="userId"></param>
        public void UpdateUser(User userEntity)
        {
            _userRepository.Update(userEntity);
        }
    }
}