using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsUserOnline { get; set; }

        public User(string name, string password, bool isUserOnline)
        {
            this.Name = name;
            this.Password = password;
            this.IsUserOnline = isUserOnline;
        }

        public User()
        {
        }
        public override string ToString()
        {
            return String.Format("({0}, {1})", this.Id, this.Name);
        }


    }
}