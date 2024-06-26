using Fiap.Monitoramento.Ambiental.Data.Repository;
using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Services
{
    public class MonitoraQualidadeArService : IMonitoraQualidadeArService
    {
        private readonly IMonitoraQualidadeArRepository _repository;

        public MonitoraQualidadeArService(IMonitoraQualidadeArRepository repository)
        {
            _repository = repository;
        }
        public void Add(MonitoraQualidadeArModel model) => _repository.Add(model);

        public void Delete(int id)
        {
            var monitoramento = _repository.GetId(id);
            if(monitoramento != null)
            {
                _repository.Delete(monitoramento);
            }
        }

        public IEnumerable<MonitoraQualidadeArModel> GetAll(int page = 0, int pageSize = 10) => _repository.GetAll(page, pageSize);

        public MonitoraQualidadeArModel GetId(int id) => _repository.GetId(id);

        public void Update(MonitoraQualidadeArModel model) => _repository.Update(model);
    }
}
