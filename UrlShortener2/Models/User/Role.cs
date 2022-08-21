using System.ComponentModel.DataAnnotations;

namespace UrlShortener2.Models.User
{
    public class Role
    {
        [Key]
        public int Id { get; set; }= (new Random()).Next();
        [Required]
        public string RoleName { get; set; }
    }
}
