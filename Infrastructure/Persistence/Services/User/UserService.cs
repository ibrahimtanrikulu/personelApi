using Application.Abstract;
using Application.Abstract.Services.User;
using Application.Models.User;
using AutoMapper;
using Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Services.User
{
    public class UserService : IUserService
    {
        readonly IMapper _mapper;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly IToken _token;
        public UserService(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IToken token)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _token = token;
        }
        public async Task<bool> CreateAsync(UserCreateModel model)
        {
            var user = _mapper.Map<AppUser>(model);
            IdentityResult Result = await _userManager.CreateAsync(user, model.Password);
            if (Result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<UserLoginResultModel> LoginAsync(UserLoginModel model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                throw new Exception("Hata");
            }
            else
            {
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded) //Authentication başarılı!
                {
                    UserLoginResultModel token = _token.CreateAccessToken(60, user);
                    return token;
                }
                throw new Exception("Hata");
            }
        }
    }
}
