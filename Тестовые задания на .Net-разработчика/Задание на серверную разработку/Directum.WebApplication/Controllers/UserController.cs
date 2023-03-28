using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Directum.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository _userRepsitory;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserRepository userRepsitory)
        {
            _logger = logger;
            _userRepsitory = userRepsitory;
        }


        [HttpPost("AddUser")]
        public ActionResult AddUser(string userName, string password, bool isOnline)
        {
            var user = new User(userName, password, isOnline);
            _userRepsitory.AddUser(user);

            if (_userRepsitory.GetUserByName(userName) != null)
            {
                _logger.LogInformation($"Пользователь {user.ToString()} добавлен в базу");
                 return Ok(new { Message = $"Пользователь {user.ToString()} добавлен в базу" });
            }
               
            return BadRequest("Не удалось добавить пользователя в базу");
        }

        [HttpGet("GetUserByName")]
        public User GetUserByName(string userName)
        {
            var user = _userRepsitory.GetUserByName(userName);
            if (user != null)
                _logger.LogInformation($"По имени {userName} не найден пользователь");
            else
                _logger.LogInformation($"По имени {userName} найден пользователь {user}");

            return user;
        }

        [HttpGet("GetUserById")]
        public User GetUserById(int userId)
        {
            var user = _userRepsitory.GetUserById(userId);
            if (user != null)
                _logger.LogInformation($"По ид {userId} не найден пользователь");
            else
                _logger.LogInformation($"По ид {userId} найден пользователь {user}");

            return user;
        }

        [HttpPut("UpdateUser")]
        public ActionResult UpdateUser(User user)
        {
            var userInfo = _userRepsitory.GetUserById(user.Id); 
            if (userInfo == null)
                return BadRequest("Не удалось найти пользователя в базе с ид {user.Id}");

            userInfo.IsUserOnline = user.IsUserOnline;
            userInfo.Name = user.Name;
            userInfo.Password = user.Password;

            _userRepsitory.UpdateUser(userInfo);

            if (_userRepsitory.GetUserByName(user.Name) != null)
            {
                _logger.LogInformation($"Пользователь {user.ToString()} обновлен в базе");
                return Ok(new { Message = $"Пользователь {user.ToString()} обновлен в базе" });
            }

            return BadRequest("Не удалось обновить пользователя в базе");
        }
    }
}