using Fiap.Monitoramento.Ambiental.Data.Repository;
using Fiap.Monitoramento.Ambiental.Models;

namespace Fiap.Monitoramento.Ambiental.Services
{
    public class DesastresNaturaisService : IDesastresNaturaisService
    {
        private readonly IDesastresNaturaisRepository _repository;
        public DesastresNaturaisService(IDesastresNaturaisRepository desastresNaturais)
        {
            _repository = desastresNaturais;
        }
        public void Add(DesastresNaturaisModel model) => _repository.Add(model);

        public void Delete(int id)
        {
            var desastre = _repository.GetById(id);
            if (desastre != null)
            {
                _repository.Delete(desastre);
            }
        }

        public IEnumerable<DesastresNaturaisModel> GetAll() => _repository.GetAll();

        public IEnumerable<DesastresNaturaisModel> GetAllPaginable(int page = 0, int pageSize = 10)
        {
            return _repository.GetAllPaginable(page, pageSize);
        }

        public DesastresNaturaisModel GetId(int id) => _repository.GetById(id);

        public void Update(DesastresNaturaisModel model) => _repository.Update(model);

    }
}
