namespace UrlShortener2.Models
{
    public class UrlValidator
    {
        private string _localUrl { get; set; }

        public UrlValidator(string localUrl)
        {
            _localUrl = localUrl;
        }

        public string GetUrl()
        {
            return _localUrl;
        }

        public string GetUrl(string id)
        {
            return _localUrl + id;
        }

    }
}
