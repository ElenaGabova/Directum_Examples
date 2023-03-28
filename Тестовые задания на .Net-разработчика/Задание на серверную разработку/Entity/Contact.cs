using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Contact
    {
        [Key]
        public int contactId;

        [Required]
        public int userContactId { get; set; }
        [Required]
        public User User { get; set; }

        [Required]
        public DateTime LastUpdateTime { get; set; } = DateTime.UtcNow;
    }
}