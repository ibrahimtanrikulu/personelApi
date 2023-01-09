namespace Application.Models.User
{
    public class UserLoginResultModel
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
