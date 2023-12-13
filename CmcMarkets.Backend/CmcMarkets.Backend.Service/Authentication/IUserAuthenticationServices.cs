using CmcMarkets.Backend.Core.Model;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Service.Authentication
{
    public interface IUserAuthenticationServices
    {
        Task<UserLoginResponse> Login(UserLoginModel model);
        Task<UserRegisterResponse> RegisterUser(UserRegisterModel model);
        Task<UserRegisterResponse> RegisterAdmin(UserRegisterModel model);
    }
}
