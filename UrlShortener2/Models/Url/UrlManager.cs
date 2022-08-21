namespace UrlShortener2.Models
{
    public static class UrlManager
    {
        public static UrlInfo Create(UrlInfo urlInfo, UrlValidator validator)
        {
            UrlInfo _urlInfo = new UrlInfo();
            
            _urlInfo.Id = Guid.NewGuid().ToString();

            _urlInfo.Url = urlInfo.Url;

            _urlInfo.ShortenedUrl = validator.GetUrl(_urlInfo.Id);

            _urlInfo.TimeOfCreation= DateTime.Now;

            _urlInfo.IdOfUser= Guid.NewGuid().ToString();

            return _urlInfo;

        }
        

    }
}
