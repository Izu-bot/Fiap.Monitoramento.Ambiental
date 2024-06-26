using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Services
{
    public interface IDesastresNaturaisService
    {
        IEnumerable<DesastresNaturaisModel> GetAll();
        IEnumerable<DesastresNaturaisModel> GetAllPaginable(int page = 0, int pageSize = 10);
        DesastresNaturaisModel GetId(int id);
        void Add(DesastresNaturaisModel model);
        void Update(DesastresNaturaisModel model);
        void Delete(int id);
    }
}
