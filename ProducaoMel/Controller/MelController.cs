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
            var flor = _floresRepository.GetFloresById(mel.FlorID.Value);
            if (flor.ID == 0)
            {
                Console.WriteLine("\nFlor não encontrada");
                Console.Write("\nPressione qualquer tecla para continuar: ");
                Console.ReadLine();
            }
            else 
            { 
                _melRepository.AddMel(mel);
            }
        }

        public void UpdateMel(Mel mel)
        {
            var flor = _floresRepository.GetFloresById(mel.FlorID.Value);
            if (flor.ID == 0)
            {
                Console.WriteLine("Flor não encontrada");
                Console.Write("Pressione qualquer tecla para continuar: ");
                Console.ReadLine();
            }
            else
            {
                _melRepository.AddMel(mel);
            }
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
