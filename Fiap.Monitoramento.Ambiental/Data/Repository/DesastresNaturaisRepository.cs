using Fiap.Monitoramento.Ambiental.Data.Database;
using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Data.Repository
{
    public class DesastresNaturaisRepository : IDesastresNaturaisRepository
    {

        private readonly DatabaseContext _databaseContext;

        public DesastresNaturaisRepository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public void Add(DesastresNaturaisModel desastresNaturais)
        {
            _databaseContext.desastresNaturais.Add(desastresNaturais);
            _databaseContext.SaveChanges();
        }

        public void Delete(DesastresNaturaisModel desastresNaturais)
        {
            _databaseContext.desastresNaturais.Remove(desastresNaturais);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<DesastresNaturaisModel> GetAll() => _databaseContext.desastresNaturais.ToList();

        public IEnumerable<DesastresNaturaisModel> GetAllPaginable(int page, int pageSize)
        {
            return _databaseContext.desastresNaturais
                .Skip( (page - 1) * pageSize )
                .Take(pageSize)
                .ToList();
        }

        public DesastresNaturaisModel GetById(int id) => _databaseContext.desastresNaturais.Find(id);

        public void Update(DesastresNaturaisModel desastresNaturais)
        {
            _databaseContext.desastresNaturais.Update(desastresNaturais);
            _databaseContext.SaveChanges();
        }
    }
}
