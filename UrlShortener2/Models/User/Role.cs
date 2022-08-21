using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace UrlShortener2.Models.User
{
    public class Role:IdentityRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NormalisedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
