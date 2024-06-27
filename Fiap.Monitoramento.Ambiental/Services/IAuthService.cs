using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);
    }
}
