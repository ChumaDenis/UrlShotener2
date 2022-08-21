using Microsoft.AspNetCore.WebUtilities;
using System.Buffers.Text;

namespace UrlShortener2.Models
{
    public static class UrlManager
    {
        public static UrlInfo Create(UrlInfo urlInfo, UrlValidator validator)
        {
            UrlInfo _urlInfo = new UrlInfo();
            
            _urlInfo.Id = WebEncoders.Base64UrlEncode(Guid.NewGuid().ToByteArray());

            _urlInfo.Url = urlInfo.Url;

            _urlInfo.ShortenedUrl = validator.GetUrl(_urlInfo.Id);

            _urlInfo.TimeOfCreation= DateTime.Now;

            _urlInfo.IdOfUser= Guid.NewGuid().ToString();

            return _urlInfo;

        }
        

    }
}
