using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Services
{
    public interface IIrrigacaoService
    {
        IEnumerable<IrrigacaoModel> GetAll(int page = 0, int pageSize = 10);
        IrrigacaoModel Get(int id);
        void Add(IrrigacaoModel model);
        void Update(IrrigacaoModel model);
        void Delete(int id);
    }
}
