using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int UserContactId { get; set; }

        [Required]
        public DateTime	SendTime { get; set; }

        [Required]
        public DateTime DeliveryTime  { get; set; }

        [Required]
        public string Content  { get; set; }

        public Message(int userId, int userContactId, string content)
        {
            UserId = userId;
            UserContactId = userContactId;
            Content = content;
        }

    }

}