using Fiap.Monitoramento.Ambiental.Data.Repository;
using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public UserModel Authenticate(string username, string password)
        {
            // Busca o usuario pelo nome
            var user = _userRepository.GetByUserName(username);

            // verifica se o usuario é null ou se a senha passada é diferente da senha armazenada
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return user;
        }
    }
}
