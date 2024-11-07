using Models;
using ProducaoMel.Repositories;

namespace ProducaoMel.Controller
{
    public class ProducaoController
    {
        private ProducaoRepository _producaoRepository;
        private MelRepository _melRepository;
        private ColmeiaRepository _colmeiaRepository;

        public ProducaoController()
        {
            _producaoRepository = new ProducaoRepository();
            _melRepository = new MelRepository();
            _colmeiaRepository = new ColmeiaRepository();
        }

        public void AddProducao(Producao producao)
        {
            var colmeia = _colmeiaRepository.GetColmeiaById(producao.ColmeiaID.Value);
            var mel = _melRepository.GetMelByID(producao.MelID.Value);

            if (colmeia.ID == 0)
            {
                Console.WriteLine("\nColmeia não encontrada");
                Console.Write("\nPressione qualquer tecla para continuar: ");
                Console.ReadLine();
            }
            else if (mel.ID == 0)
            {
                Console.WriteLine("\nMel não encontrado");
                Console.Write("\nPressione qualquer tecla para continuar: ");
                Console.ReadLine();
            }
            else
            {
                _producaoRepository.AddProducao(producao);
            }
        }

        public void UpdateProducao(Producao producao)
        {
            var colmeia = _colmeiaRepository.GetColmeiaById(producao.ColmeiaID.Value);
            var mel = _melRepository.GetMelByID(producao.MelID.Value);

            if (colmeia.ID == 0)
            {
                Console.WriteLine("\nColmeia não encontrada");
                Console.Write("\nPressione qualquer tecla para continuar: ");
                Console.ReadLine();
            }
            else if (mel.ID == 0)
            {
                Console.WriteLine("\nMel não encontrado");
                Console.Write("\nPressione qualquer tecla para continuar: ");
                Console.ReadLine();
            }
            else
            {
                _producaoRepository.UpdateProducao(producao);
            }

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