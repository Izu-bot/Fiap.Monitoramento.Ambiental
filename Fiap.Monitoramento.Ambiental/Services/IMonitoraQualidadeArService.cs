using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Services
{
    public interface IMonitoraQualidadeArService
    {
        IEnumerable<MonitoraQualidadeArModel> GetAll(int page, int pageSize);
        MonitoraQualidadeArModel GetId(int id); 
        void Add(MonitoraQualidadeArModel model);
        void Update(MonitoraQualidadeArModel model);
        void Delete(int id);
    }

}
