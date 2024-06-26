using Fiap.Monitoramento.Ambiental.Data.Database;
using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Data.Repository
{
    public interface IMonitoraQualidadeArRepository
    {
        IEnumerable<MonitoraQualidadeArModel> GetAll(int page, int pageSize);
        MonitoraQualidadeArModel GetId(int id);
        void Add(MonitoraQualidadeArModel model);
        void Update(MonitoraQualidadeArModel model);
        void Delete(MonitoraQualidadeArModel id);
    }
}
