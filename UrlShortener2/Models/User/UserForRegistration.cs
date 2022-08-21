namespace UrlShortener2.Models.User
{
    public class UserForRegistration:UserInfo
    {
        public string ConfirmPassword { get; set; }
        public bool IsConfirmPassword()
        {
            return Password==ConfirmPassword;
        }
    }

    
}
