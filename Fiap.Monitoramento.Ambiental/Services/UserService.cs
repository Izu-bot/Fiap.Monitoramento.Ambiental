using Fiap.Monitoramento.Ambiental.Data.Repository;
using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public void Add(UserModel user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _userRepository.Add(user);
        }

        public void Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if(user != null)
                _userRepository.Delete(user);
        }

        public IEnumerable<UserModel> GetAll() => _userRepository.GetAll();

        public UserModel GetById(int id) => _userRepository.GetById(id);

        public void Update(UserModel user) => _userRepository.Update(user);
    }
}
