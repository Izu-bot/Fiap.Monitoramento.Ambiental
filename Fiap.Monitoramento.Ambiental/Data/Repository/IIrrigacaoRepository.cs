using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Data.Repository
{
    public interface IIrrigacaoRepository
    {
        IEnumerable<IrrigacaoModel> GetAll(int page, int pageSize);
        IrrigacaoModel GetId(int id);
        void Add(IrrigacaoModel model);
        void Update(IrrigacaoModel model);
        void Delete(IrrigacaoModel model);
    }
}
