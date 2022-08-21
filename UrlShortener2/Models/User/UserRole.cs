using System.ComponentModel.DataAnnotations;

namespace UrlShortener2.Models.User
{
    public class UserRole
    {
        [Required]
        public int RoleId { get; set; }
        [Key]
        [Required]
        public string UserId { get; set; } = "";

        public Boolean IsAdmin { get; set; } = false;

    }
}
