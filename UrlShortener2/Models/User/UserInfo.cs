﻿using System.ComponentModel.DataAnnotations;

namespace UrlShortener2.Models.User
{
    public class UserInfo
    {
        [Key]
        public string Id { get; set; } = (new Guid()).ToString();
        [Required]
        public string UserName { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        
        public DateTime DateOfCreating { get; set; } = DateTime.Now;
        
    }
}
