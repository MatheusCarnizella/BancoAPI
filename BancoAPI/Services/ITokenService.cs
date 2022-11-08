using BancoAPI.Models;

namespace BancoAPI.Services
{
    public interface ITokenService
    {
        string GerarToken(string key, UserModel user);
    }
}
