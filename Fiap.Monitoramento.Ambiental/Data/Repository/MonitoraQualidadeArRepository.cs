using Fiap.Monitoramento.Ambiental.Data.Database;
using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Data.Repository
{
    public class MonitoraQualidadeArRepository : IMonitoraQualidadeArRepository
    {
        private readonly DatabaseContext _databaseContext;

        public MonitoraQualidadeArRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }
        public void Add(MonitoraQualidadeArModel model)
        {
            _databaseContext.MonitorarQualidadeAr.Add(model);
            _databaseContext.SaveChanges();
        }

        public void Delete(MonitoraQualidadeArModel id)
        {
            _databaseContext.MonitorarQualidadeAr.Remove(id);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<MonitoraQualidadeArModel> GetAll(int page, int pageSize)
        {
            return _databaseContext.MonitorarQualidadeAr
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public MonitoraQualidadeArModel GetId(int id) => _databaseContext.MonitorarQualidadeAr.Find(id);

        public void Update(MonitoraQualidadeArModel model)
        {
            _databaseContext.MonitorarQualidadeAr.Update(model);
            _databaseContext.SaveChanges();
        }
    }
}
