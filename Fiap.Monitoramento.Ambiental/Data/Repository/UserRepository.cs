using Fiap.Monitoramento.Ambiental.Data.Database;
using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public void Add(UserModel user)
        {
            _databaseContext.User.Add(user);
            _databaseContext.SaveChanges();
        }

        public void Delete(UserModel user)
        {
            _databaseContext.User.Remove(user);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _databaseContext.User.ToList();
        }

        public UserModel GetById(int id) => _databaseContext.User.Find(id);

        public UserModel GetByUserName(string name) => _databaseContext.User.SingleOrDefault(u => u.UserName == name);

        public void Update(UserModel user)
        {
            _databaseContext.User.Update(user);
            _databaseContext.SaveChanges();
        }
    }
}
