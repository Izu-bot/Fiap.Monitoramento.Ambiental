using Fiap.Monitoramento.Ambiental.Data.Repository;
using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Services
{
    public class IrrigacaoService : IIrrigacaoService
    {

        private readonly IIrrigacaoRepository _repository;

        public IrrigacaoService(IIrrigacaoRepository repository)
        {
            _repository = repository;
        }
        public void Add(IrrigacaoModel model) => _repository.Add(model);

        public void Delete(int id)
        {
            var irrigacao = _repository.GetId(id);
            if(irrigacao != null)
                _repository.Delete(irrigacao);
        }

        public IrrigacaoModel Get(int id) => _repository.GetId(id);

        public IEnumerable<IrrigacaoModel> GetAll(int page = 0, int pageSize = 10)
        {
            return _repository.GetAll(page, pageSize);
        }

        public void Update(IrrigacaoModel model) => _repository.Update(model);
    }
}
