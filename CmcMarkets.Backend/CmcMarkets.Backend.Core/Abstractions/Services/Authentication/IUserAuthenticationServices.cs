using CmcMarkets.Backend.Core.Model;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Core.Abstractions.Services.Authentication
{
    public interface IUserAuthenticationServices
    {
        Task<UserLoginResponse> Login(UserLoginModel model);
        Task<UserRegisterResponse> RegisterUser(UserRegisterModel model);
        Task<UserRegisterResponse> RegisterAdmin(UserRegisterModel model);
    }
}
