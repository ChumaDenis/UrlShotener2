using System.ComponentModel.DataAnnotations;

namespace UrlShortener2.Models
{
    public class UrlInfo
    {
       
        public string Id { get; set; } = "";

        [Required]
        public string Url { get; set; } = "";
  
        public string ShortenedUrl { get; set; } = "";

        public DateTime TimeOfCreation { get; set; }

        public string IdOfUser { get; set; } = "";

    }
}
