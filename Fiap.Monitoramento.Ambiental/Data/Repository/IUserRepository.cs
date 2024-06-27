using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Data.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel GetByUserName(string name);
        void Add(UserModel user);
        void Update(UserModel user);
        void Delete(UserModel user);
    }
}
