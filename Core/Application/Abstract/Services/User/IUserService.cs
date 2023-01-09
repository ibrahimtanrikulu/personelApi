using Application.Models.User;

namespace Application.Abstract.Services.User
{
    public interface IUserService
    {
        public Task<bool> CreateAsync(UserCreateModel model);
        public Task<UserLoginResultModel> LoginAsync(UserLoginModel model);
    }
}
