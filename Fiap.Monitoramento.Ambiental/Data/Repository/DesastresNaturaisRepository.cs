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
            _databaseContext.DesastresNaturais.Add(desastresNaturais);
            _databaseContext.SaveChanges();
        }

        public void Delete(DesastresNaturaisModel desastresNaturais)
        {
            _databaseContext.DesastresNaturais.Remove(desastresNaturais);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<DesastresNaturaisModel> GetAll() => _databaseContext.DesastresNaturais.ToList();

        public IEnumerable<DesastresNaturaisModel> GetAllPaginable(int page, int pageSize)
        {
            return _databaseContext.DesastresNaturais
                .Skip( (page - 1) * pageSize )
                .Take(pageSize)
                .ToList();
        }

        public DesastresNaturaisModel GetById(int id) => _databaseContext.DesastresNaturais.Find(id);

        public void Update(DesastresNaturaisModel desastresNaturais)
        {
            _databaseContext.DesastresNaturais.Update(desastresNaturais);
            _databaseContext.SaveChanges();
        }
    }
}
