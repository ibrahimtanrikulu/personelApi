using Application.Models.User;
using Domain.Entities.Authentication;

namespace Application.Abstract
{
    public interface IToken
    {
        UserLoginResultModel CreateAccessToken(int minute, AppUser appUser);
    }
}
