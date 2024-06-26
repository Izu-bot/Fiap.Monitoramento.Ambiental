using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Data.Repository
{
    public interface IDesastresNaturaisRepository
    {
        IEnumerable<DesastresNaturaisModel> GetAll();
        IEnumerable<DesastresNaturaisModel> GetAllPaginable(int page, int pageSize);
        DesastresNaturaisModel GetById(int id);
        void Add(DesastresNaturaisModel desastresNaturais);
        void Update(DesastresNaturaisModel desastresNaturais);
        void Delete(DesastresNaturaisModel desastresNaturais);
    }
}
