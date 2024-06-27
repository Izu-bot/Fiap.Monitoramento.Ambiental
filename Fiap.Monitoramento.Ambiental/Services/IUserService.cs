using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        void Add(UserModel user);
        void Update(UserModel user);
        void Delete(int id);
    }
}
