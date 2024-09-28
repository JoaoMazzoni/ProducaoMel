using Models;
using ProducaoMel.Repositories;


namespace ProducaoMel.Controller
{
    public class ColmeiaController
    {
        private ColmeiaRepository _colmeiaRepository;

        public ColmeiaController()
        {
            _colmeiaRepository = new ColmeiaRepository();
        }

        public void AddColmeia(Colmeia colmeia)
        {
            _colmeiaRepository.AddColmeia(colmeia);
        }

        public void UpdateColmeia(Colmeia colmeia)
        {
            _colmeiaRepository.UpdateColmeia(colmeia);
        }

        public void DeleteColmeia(int id)
        {
            _colmeiaRepository.DeleteColmeia(id);
        }

        public List<Colmeia> GetAllColmeias()
        {
            return _colmeiaRepository.GetAllColmeias();
        }

        public Colmeia GetColmeiaById(int id)
        {
            return _colmeiaRepository.GetColmeiaById(id);
        }
    }
}
