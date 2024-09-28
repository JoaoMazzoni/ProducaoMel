using Models;
using ProducaoMel.Repositories;

namespace ProducaoMel.Controller
{
    public class MelController
    {
        private MelRepository _melRepository;
        private FloresRepository _floresRepository;

        public MelController()
        {
            _melRepository = new MelRepository();
            _floresRepository = new FloresRepository();
        }

        public void AddMel(Mel mel)
        {
            _floresRepository.GetFloresById(mel.FlorID.Value);
            if (_floresRepository.GetFloresById(mel.FlorID.Value) == null)
            {
                Console.WriteLine("Flor não encontrada");
            }
            _melRepository.AddMel(mel);
        }

        public void UpdateMel(Mel mel)
        {
            _floresRepository.GetFloresById(mel.FlorID.Value);
            if (_floresRepository.GetFloresById(mel.FlorID.Value) == null)
            {
                Console.WriteLine("Flor não encontrada");
            }
            _melRepository.UpdateMel(mel);
        }

        public void DeleteMel(int id)
        {
            _melRepository.DeleteMel(id);
        }

        public List<Mel> GetAllMel()
        {
            return _melRepository.GetAllMel();
        }

        public Mel GetMelByID(int id)
        {
            return _melRepository.GetMelByID(id);
        }
    }
}
