using Fiap.Monitoramento.Ambiental.Data.Database;
using Fiap.Monitoramento.Ambiental.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Monitoramento.Ambiental.Data.Repository
{
    public class IrrigacaoRepository : IIrrigacaoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public IrrigacaoRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public void Add(IrrigacaoModel model)
        {
            _databaseContext.Irrigacao.Add(model);
            _databaseContext.SaveChanges();
        }

        public void Delete(IrrigacaoModel model)
        {
            _databaseContext.Irrigacao.Remove(model);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<IrrigacaoModel> GetAll(int page, int pageSize)
        {
            return _databaseContext.Irrigacao.Include(q => q.MonitoraQualidadeArModel)
                .Skip( (page - 1) * page)
                .Take(pageSize)
                .AsNoTracking()
                .ToList();
        }

        public IrrigacaoModel GetId(int id) => _databaseContext.Irrigacao.Find(id);

        public void Update(IrrigacaoModel model)
        {
            _databaseContext.Irrigacao.Update(model);
            _databaseContext.SaveChanges();
        }
    }
}
