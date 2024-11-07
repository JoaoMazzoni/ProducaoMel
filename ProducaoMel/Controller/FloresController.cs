using Models;
using ProducaoMel.Repositories;

namespace ProducaoMel.Controller
{
    public class FloresController
    {
        private FloresRepository _floresRepository;

        public FloresController()
        {
            _floresRepository = new FloresRepository();
        }

        public void AddFlores(Flores flores)
        {
            _floresRepository.AddFlores(flores);
        }

        public void UpdateFlores(Flores flores)
        {
            _floresRepository.UpdateFlores(flores);
        }

        public void DeleteFlores(int id)
        {
            _floresRepository.DeleteFlores(id);
        }

        public List<Flores> GetAllFlores()
        {
            return _floresRepository.GetAllFlores();
        }

        public Flores GetFloresById(int id)
        {
            return _floresRepository.GetFloresById(id);
        }
    }
}