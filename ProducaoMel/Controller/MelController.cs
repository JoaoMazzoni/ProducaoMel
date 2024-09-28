using Models;
using ProducaoMel.Repositories;

namespace ProducaoMel.Controller
{
    public class MelController
    {
        private MelRepository _melRepository;

        public MelController()
        {
            _melRepository = new MelRepository();
        }

        public void AddMel(Mel mel)
        {
            _melRepository.AddMel(mel);
        }

        public void UpdateMel(Mel mel)
        {
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
