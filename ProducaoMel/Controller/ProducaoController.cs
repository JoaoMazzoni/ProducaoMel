using Models;
using ProducaoMel.Repositories;

namespace ProducaoMel.Controller
{
    public class ProducaoController
    {
        private ProducaoRepository _producaoRepository;

        public ProducaoController()
        {
            _producaoRepository = new ProducaoRepository();
        }

        public void AddProducao(Producao producao)
        {
            _producaoRepository.AddProducao(producao);
        }

        public void UpdateProducao(Producao producao)
        {
            _producaoRepository.UpdateProducao(producao);
        }

        public void DeleteProducao(int id)
        {
            _producaoRepository.DeleteProducao(id);
        }

        public List<Producao> GetAllProducao()
        {
            return _producaoRepository.GetAllProducao();
        }

        public Producao GetProducaoByLote(int id)
        {
            return _producaoRepository.GetProducaoByLote(id);
        }
    }
}
